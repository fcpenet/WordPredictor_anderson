using System;
using WordPredictor.Models;
using Microsoft.EntityFrameworkCore;
using WordPredictor.DAL;
namespace WordPredictor.DAL
{
    public class WordContext: DbContext
    {
        public WordContext(DbContextOptions<WordContext> options)
            :base(options)
        {
        }
        public virtual DbSet<Word> Words { get; set; }
    }
}
