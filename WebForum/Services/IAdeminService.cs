namespace WebForum.Services
{
    public interface IAdeminService
    {
        void BlockUser(int adminId, int userId);
        void UnblockUser(int adminId, int userId);
        void DeletePost(int adminId, int postId);
    }
}
