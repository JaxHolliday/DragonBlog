using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DragonBlog.Models
{
    public class Post
    {

        #region Keys
        public int Id { get; set; }

        public int BlogId { get; set; }
        #endregion

        #region Post Properties
        //Describe the "things" that a blog post should have 
        public string Title { get; set; }

        public string Abstract { get; set; }

        public string Content { get; set; } 
        
        public string Slug { get; set; }

        [Display(Name ="File Name")]
        public string FileName { get; set; }
        // Can incorporate the code to turn this data into a usable image inside the get();
        public byte[] Image { get; set; }

        public DateTime Created { get; set; }

        public DateTime? Update { get; set; }

        public bool IsPublished { get; set; }
        #endregion

        #region Navigation 
        //MS Doc is written in public type type
        public virtual Blog Blog { get; set; }
        //In MS Docs this is public List<Type> Types
        public virtual ICollection<Comment> Comments { get; set; }

        public virtual ICollection<Tag> Tags { get; set; }

        
        public Post()
        {
            Comments = new HashSet<Comment>();
            Tags = new HashSet<Tag>();
        }
        #endregion

    }
}
