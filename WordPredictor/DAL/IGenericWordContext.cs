using System;
using WordPredictor.Models;
using Microsoft.EntityFrameworkCore;
namespace WordPredictor.DAL
{
    public interface IGenericWordContext : IDisposable
    {
        DbSet<Word> Words { get; set; }
    }
}
