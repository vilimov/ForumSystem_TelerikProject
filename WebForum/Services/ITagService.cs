using WebForum.Models;

namespace WebForum.Services
{
    public interface ITagService
    {
        IEnumerable<Tag> GetAllTags();
        Tag GetTagById(int id);
        Tag GetTagByName(string name);
        Tag CreateTag(Tag newTag);
        Tag UpdateTag(int id, string newTagName);
        void DeleteTag(int tagId, User currentUser);
        void AddTagToPost(int postId, string tagName, int userId);
        void RemoveTagFromPost(int postId, string tagName, int userId);
        void AdminAddTagToPost(int postId, string tagName, int adminId);
        void AdminRemoveTagFromPost(int postId, string tagName, int adminId);
    }
}
