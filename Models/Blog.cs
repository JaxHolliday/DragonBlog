using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DragonBlog.Models
{
    public class Blog
    {
        //This model is intended for categorization of posts
        //Not have properties for the blog

        #region Keys
        public int Id { get; set; }
        #endregion

        #region Blog Properties
        
        public string Name { get; set; }
        public string URL { get; set; }       
        
        #endregion

        #region Navigation
       
        #endregion
      
        public virtual ICollection<Post> Posts { get; set; }

        //Constructor
        public Blog()
        {
            Posts = new HashSet<Post>();
        }
    }
}
