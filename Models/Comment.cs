using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PhotoSharingApplication.Models
{
    public class Comment
    {
        public int commentId {  get; set; }
        public int photoID { get; set; }
        public string userName { get; set; }
        [Required]
        [StringLength(250)]
        public string subject { get; set; }
        [DataType(DataType.MultilineText)]
        public string body { get; set; }
        public virtual ICollection<Photo> photos { get; set;}

    }
}