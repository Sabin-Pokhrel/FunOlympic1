using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Authorization;

namespace FunOlympic1
{
    public class Video
    {
        [Key]
        public int VideoID { get; set; }
        [Required]
        [Display(Name ="Video Title:")]
        public string VideoTitle { get; set; }
        [Display(Name ="Video Link:")]
        public string VideoLink { get; set; }
        [Display(Name = "Thumbnail Link:")]
        public string ThumbnailLink { get; set; }
        [Required]
        public string Category { get; set; }
        [Display(Name = "Published Date:")]
        public DateTime PublishDate { get; set; }= DateTime.Now;
        [Display(Name = "Video Discription:")]
        public string VideoDescription { get; set; }



    }
}
