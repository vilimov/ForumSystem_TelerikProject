namespace Web.Forum.Services
{
    public interface IAdminService
    {
        void BlockUser(int adminId, int userId);
        void UnblockUser(int adminId, int userId);
        void DeletePost(int adminId, int postId);
    }
}
