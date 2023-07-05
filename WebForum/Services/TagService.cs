using System.Transactions;
using WebForum.Helpers.Exceptions;
using WebForum.Models;
using WebForum.Repository;
using WebForum.Repository.Contracts;

namespace WebForum.Services
{
    public class TagService : ITagService
    {
        private readonly ITagRepository tagRepository;
        private readonly IPostRepository postRepository;
        private readonly IUserRepository userRepository;

        public TagService(ITagRepository tegRepository, IPostRepository postRepository, IUserRepository userRepository)
        {
            this.tagRepository = tegRepository;
            this.postRepository = postRepository;
            this.userRepository = userRepository;
        }

        public IEnumerable<Tag> GetAllTags()
        {
            return tagRepository.GetAllTags();
        }
        public Tag GetTagById(int id)
        {
            return tagRepository.GetTagById(id) ?? throw new EntityNotFoundException($"Tag with id {id} not found");
        }

        public Tag GetTagByName(string name)
        {
            return tagRepository.GetTagByName(name.ToLower()) ?? throw new EntityNotFoundException($"Tag with name {name} not found");
        }
        public void AddTagToPost(int postId, string tagName, int userId)
        {
            var post = postRepository.GetPostById(postId);
            var user = userRepository.GetUserById(userId);

            if (post == null || user == null)
            {
                throw new EntityNotFoundException("Post or User not found");
            }
            if (post.Autor.Id != userId)
            {
                throw new UnauthorizedOperationException("Only the author of the post can add tags");
            }
            var tag = tagRepository.GetTagByName(tagName.ToLower());

            if (tag == null)
                tag = tagRepository.CreateTag(new Tag { Name = tagName });

            if (post.PostTags.Any(pt => pt.TagId == tag.Id))
                throw new DuplicateEntityException("Tag is already assigned to this post");

            try
            {
                tagRepository.AddTagToPost(post, tag);
/*                post.PostTags.Add(new PostTag { PostId = postId, TagId = tag.Id });
                postRepository.UpdatePost(post.Id, post); // Here we pass the post id and the post object*/
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Could not add tag to post", ex);
            }
        }

        public void AdminAddTagToPost(int postId, string tagName, int adminId)
        {
            User admin = userRepository.GetUserById(adminId);
            if (!admin.IsAdmin)
            {
                throw new UnauthorizedOperationException("Only admins can add tags to posts.");
            }

            Tag tag = tagRepository.GetTagByName(tagName);
            Post post = postRepository.GetPostById(postId);

            if (post.PostTags.Any(pt => pt.TagId == tag.Id))
            {
                throw new DuplicateEntityException($"Tag {tagName} already added to the post.");
            }

            tagRepository.AddTagToPost(post, tag);
        }
        public Tag CreateTag(Tag newTag)
        {
            if (tagRepository.GetTagByName(newTag.Name.ToLower()) != null)
            {
                throw new DuplicateEntityException($"Tag with name {newTag.Name} already exists");
            }
            return tagRepository.CreateTag(newTag);
        }
        public Tag UpdateTag(int id, string newTagName)
        {
            var existingTag = GetTagById(id);
            existingTag.Name = newTagName.ToLower();
            return tagRepository.UpdateTag(existingTag);
        }
        public void DeleteTag(int tagId, User currentUser)
        {
            if (!currentUser.IsAdmin)
            {
                throw new UnauthorizedOperationException("Only admins can delete tags.");
            }

            tagRepository.DeleteTag(tagId);
        }
        public void AdminRemoveTagFromPost(int postId, string tagName, int adminId)
        {
            User admin = userRepository.GetUserById(adminId);
            if (!admin.IsAdmin)
            {
                throw new UnauthorizedOperationException("Only admins can remove tags from posts.");
            }

            Tag tag = tagRepository.GetTagByName(tagName);
            Post post = postRepository.GetPostById(postId);

            if (!post.PostTags.Any(pt => pt.TagId == tag.Id))
            {
                throw new EntityNotFoundException($"Tag {tagName} not found on the post.");
            }

            tagRepository.RemoveTagFromPost(postId, tag.Id);
        }
        public void RemoveTagFromPost(int postId, string tagName, int userId)
        {
            User user = userRepository.GetUserById(userId);
            Post post = postRepository.GetPostById(postId);

            if (post.AutorId != user.Id)
            {
                throw new UnauthorizedOperationException("Users can only remove tags from their own posts.");
            }

            Tag tag = tagRepository.GetTagByName(tagName);

            if (tag == null || !post.PostTags.Any(pt => pt.TagId == tag.Id))
            {
                throw new EntityNotFoundException($"Tag {tagName} not found on the post.");
            }

            tagRepository.RemoveTagFromPost(postId, tag.Id);
        }
    }
}
