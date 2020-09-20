using System;
using System.ComponentModel.DataAnnotations;

namespace BlogBlazor.Models
{
    public class Post
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Judul post harus diisi!")]
        public string Title { get; set; }
        public string Summary { get; set; }
        [Required(ErrorMessage = "Body post harus diisi!")]
        public string Body { get; set; }
        [Required(ErrorMessage = "Author harus diisi!")]
        public string Author { get; set; }

        public int KategoriId { get; set; }
        public Kategori Kategori { get; set; }
    }
}
