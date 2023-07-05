using WebForum.Models;

namespace WebForum.Repository.Contracts
{
    public interface ITagRepository
    {
        Tag GetTagById(int id);
        Tag GetTagByName(string name);
        List<Tag> GetAllTags();
        Tag CreateTag(Tag newTag);
        Tag UpdateTag(Tag tag);
        List<Post> GetPostsByTagName(string tagName);
        void AddTagToPost(Post postToAddTagTo, Tag tag);
        void RemoveTagFromPost(int postId, int tagId);
        void DeleteTag(int tagId);
    }
}
