using mvc.DB;
using mvc.Entities;
using System.Collections.Generic;
using System.Linq;
namespace mvc.Models
{

    public class CommentsRepository
    {
        private readonly RockfestDB _rockfestDB;

        public CommentsRepository(RockfestDB rockfestDB)
        {
            _rockfestDB = rockfestDB;
        }

        public List<Comments> GetCommentsByPostId(int postId)
        {
            var data = _rockfestDB.Comments.Where(x => x.postId == postId);
            if (data != null)
            {
                return data.ToList();
            }
            return new List<Comments>();
        }
        public List<Comments> GetCommentsByParrentCommentId(int parId)
        {
            var data = _rockfestDB.Comments.Where(x => x.commentId == parId);
            if (data != null)
            {
                return data.ToList();
            }
            return new List<Comments>();
        }

        public bool AddOneCommentToPost(Comments comment)
        {
            _rockfestDB.Comments.Add(comment);
            if (this.SaveChanges() == 1)
            {
                return true;
            }
            return false;
        }

        public int SaveChanges()
        {
            return _rockfestDB.SaveChanges();
        }
    }
}
