using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5
{
    public class EF6PhotographContext
    {
        public void Function()
        {
            byte[] thumbBits = new Byte[100];
            byte[] fullBits = new Byte[2000];
            using (var context = new Scenariu3Context())
            {
                var photo = new Photograph()
                {
                    Title = "My Dog",
                    ThumbnailBits = thumbBits
                };
                var fullImage = new PhotographFullImage
                {
                    HighResolutionBits = fullBits
                };
                photo.PhotographFullImage = fullImage;
                context.Photographs.Add(photo);
                context.SaveChanges();

                foreach (var photograph in context.Photographs)
                {
                    Console.WriteLine("Photo: {0}, ThumbnailSize {1} bytes", photograph.Title, photograph.ThumbnailBits.Length);
                    context.Entry(photograph).Reference(p => p.PhotographFullImage).Load();
                    Console.WriteLine("Full Image Size: {0} bytes", photograph.PhotographFullImage.HighResolutionBits.Length);
                }
            }
        }

    }
}