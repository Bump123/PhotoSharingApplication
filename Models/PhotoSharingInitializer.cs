using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;

namespace PhotoSharingApplication.Models
{
    public class PhotoSharingInitializer : DropCreateDatabaseAlways<PhotoSharingContext>
    {
        private byte[] getFileBytes(string path)
        {
            FileStream fileOnDisk = new FileStream(HttpRuntime.AppDomainAppPath + path, FileMode.Open);
            byte[] fileBytes;
            using (BinaryReader br = new BinaryReader(fileOnDisk))
            {
                fileBytes = br.ReadBytes((int)fileOnDisk.Length);
            }
            return fileBytes;
        }

        protected override void Seed(PhotoSharingContext context)
        {
            base.Seed(context);
            var photos = new List<Photo>
            {
                new Photo
                {
                    title = "Test Photo",
                    description = "Your Description",
                    userName = "NaokiSato",
                    photoFile = getFileBytes("\\Images\\flower.jpg"), imageMimeType = "image/jpeg",
                    createdDate = DateTime.Today,
                } 

                
            };
            
            photos.ForEach(photo => context.Photos.Add(photo));
            context.SaveChanges();

            var comments = new List<Comment>
            {
                new Comment
                {
                    photoID = 1,
                    userName = "NaokiSato",
                    subject = "Test Comment",
                    body = "This comment" + "should appear in" + "photo 1"
                }
            };
            comments.ForEach(comment => context.Comments.Add(comment));
            context.SaveChanges();
        }





    }

}