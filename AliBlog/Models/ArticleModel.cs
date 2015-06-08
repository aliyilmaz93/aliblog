using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AliBlog.Models
{
    public class ArticleModel
    {

        public ArticleModel()
        {
            ReleasedDate = DateTime.Now;
        }

        public int Id { get; set; }
        [Required]
        [DisplayName("Author")]
        public string Name { get; set; }

        [Required]
        public string Subject { get; set; }

        [Required]
        public string Content { get; set; }

        [Editable(false)]
        public DateTime ReleasedDate { get; set; }

    }
}