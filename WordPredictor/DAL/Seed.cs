using System;
using Microsoft.EntityFrameworkCore;
using WordPredictor.Models;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
namespace WordPredictor.DAL
{
    public static class Seed
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new WordContext(
                serviceProvider.GetRequiredService<DbContextOptions<WordContext>>()))
            {
                if (context.Words.Any())
                {
                    //context.Words.RemoveRange(context.Words);
                    return;
                }

                context.AddRange(
                    new Word
                    {
                        Phrase = "GOOD",
                        Code = "4663"
                    },
                    new Word
                    {
                        Phrase = "BAD",
                        Code = "223"
                    },
                    new Word
                    {
                        Phrase = "YES",
                        Code = "937"
                    },
                    new Word
                    {
                        Phrase = "NO",
                        Code = "66"
                    },
                    new Word
                    {
                        Phrase = "ON",
                        Code = "66"
                    },
                    new Word
                    {
                        Phrase = "ROOT",
                        Code = "7668"
                    },
                    new Word
                    {
                        Phrase = "SNOT",
                        Code = "7668"
                }
                );
                context.SaveChanges();

            }
        }
    }
}
