using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace BlogBlazor.Models
{
    public class Kategori
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Nama kategori harus diisi!")]
        public string KategoriName { get; set; }
    }
}
