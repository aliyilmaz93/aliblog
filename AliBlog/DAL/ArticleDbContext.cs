using AliBlog.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace AliBlog.DAL
{
    public class ArticleDbContext : DbContext
    {
        public ArticleDbContext() : base("ArticleDbContext") { }

        public DbSet<ArticleModel> Articles { get; set; }

    }
}