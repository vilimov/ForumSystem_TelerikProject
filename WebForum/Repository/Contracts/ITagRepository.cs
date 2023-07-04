using WebForum.Models;

namespace WebForum.Repository.Contracts
{
    public interface ITagRepository
    {
        Tag GetTagById(int id);
        Tag GetTagByName(string name);
        List<Tag> GetAllTags();
        Tag CreateTag(Tag newTag);
        List<Post> GetPostsByTagName(string tagName);
        void AddTagToPost(int postId, Tag tag);
        void RemoveTagFromPost(int postId, int tagId);
    }
}
