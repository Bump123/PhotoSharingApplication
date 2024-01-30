using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PhotoSharingApplication.Models
{
    public class Photo
    {
        public int photoId { get; set; }
        [Required]
        public string title { get; set; }
        [DataType(DataType.MultilineText)]
        public string description { get; set; }
        public string userName { get; set; }
        [DataType(DataType.DateTime)]
        [DisplayName("Created Date")]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yy}")]
        public DateTime createdDate { get; set; }
        [DisplayName("Picture")]
        public byte[] photoFile { get; set; }
        public string imageMimeType { get; set; }
        public virtual ICollection<Comment> comments { get; set; }
    }
}