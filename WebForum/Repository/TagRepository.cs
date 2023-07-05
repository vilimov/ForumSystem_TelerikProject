using Microsoft.EntityFrameworkCore;
using WebForum.Data;
using WebForum.Helpers.Exceptions;
using WebForum.Models;
using WebForum.Repository.Contracts;

namespace WebForum.Repository
{
    public class TagRepository : ITagRepository
    {
        private readonly ForumContext context;

        public TagRepository(ForumContext context)
        {
            this.context = context;
        }

        public Tag GetTagById(int id)
        {
            var tag = this.context.Tags.Find(id);
            if (tag == null)
            {
                throw new EntityNotFoundException($"Tag with id {id} doesn't exist.");
            }
            return tag;
        }

        public Tag GetTagByName(string name)
        {
            var tag = this.context.Tags.FirstOrDefault(t => t.Name == name.ToLower());
            return tag;
        }

        public List<Tag> GetAllTags()
        {
            return this.context.Tags.ToList();
        }

        public Tag CreateTag(Tag newTag)
        {
            newTag.Name = newTag.Name.ToLower();

            var existingTag = GetTagByName(newTag.Name);
            if (existingTag != null)
            {
                return existingTag;
            }

            this.context.Tags.Add(newTag);
            this.context.SaveChanges();

            return newTag;
        }

        public List<Post> GetPostsByTagName(string tagName)
        {
            var posts = this.context.Posts
                                    .Include(p => p.PostTags)
                                    .ThenInclude(pt => pt.Tag)
                                    .Where(p => p.PostTags.Any(pt => pt.Tag.Name == tagName.ToLower()))
                                    .ToList();
            return posts;
        }

        public void AddTagToPost(Post postToAddTagTo, Tag tag)
        {
            //var post = this.context.Posts.Find(postId);
            if (postToAddTagTo == null)
            {
                throw new EntityNotFoundException($"Post with id {postToAddTagTo.Id} doesn't exist.");
            }

            var postTag = new PostTag { Post = postToAddTagTo, Tag = tag };
            this.context.PostTags.Add(postTag);
            this.context.SaveChanges();
        }
        public Tag UpdateTag(Tag tag)
        {
            var existingTag = this.context.Tags.Find(tag.Id);
            if (existingTag == null)
            {
                throw new EntityNotFoundException($"Tag with id {tag.Id} does not exist.");
            }

            existingTag.Name = tag.Name.ToLower();
            this.context.SaveChanges();

            return existingTag;
        }
        public void RemoveTagFromPost(int postId, int tagId)
        {
            var postTag = this.context.PostTags.FirstOrDefault(pt => pt.PostId == postId && pt.TagId == tagId);
            if (postTag != null)
            {
                this.context.PostTags.Remove(postTag);
                this.context.SaveChanges();
            }
        }
        public void DeleteTag(int tagId)
        {
            var tag = this.context.Tags.Find(tagId);
            if (tag == null)
            {
                throw new EntityNotFoundException($"Tag with id {tagId} doesn't exist.");
            }

            // Remove all PostTag records associated with this tag
            var postTags = this.context.PostTags.Where(pt => pt.TagId == tagId);
            this.context.PostTags.RemoveRange(postTags);

            this.context.Tags.Remove(tag);
            this.context.SaveChanges();
        }
    }
}
