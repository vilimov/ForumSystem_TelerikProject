﻿using WebForum.Models;

namespace WebForum.Services
{
    public interface ICommentsServices
    {
        List<Comment> GetAll();
        List<Comment> FilterBy(CommentQueryParameters filterParameters);

        Comment GetCommentById(int id);

        List<Comment> GetByPostId(int id);

        List<Comment> GetByAuthorId(int id);

        Comment CreateComment(Comment comment, Post post, User autor);


        Comment Update(int id, Comment comment, User author);
        
        Comment Delete(int id, User author);

        Comment AddLikeComment(Comment comment, User author);

        Comment RemoveLikeComment(Comment comment, User author);

	}
}
