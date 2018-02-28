using System;
using Xunit;
using WordPredictor.Controllers;
using WordPredictor.DAL;
using WordPredictor.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

namespace WordPredictor.Test
{
    public class WordControllerTest
    {
        [Fact]
        public void IndexReturnsIndexView()
        {
            using (var context = GetContextWithData())
            using (var controller = new WordController(context))
            {
                var result = controller.Index() as ViewResult;
                Assert.True(result.ViewName == "Index");
            }  
        }

        [Fact]
        public void OnTextChangeReturnsEmptyStringWhenInputIsEmpty()
        {
            using (var context = GetContextWithData())
            using (var controller = new WordController(context))
            {
                var response = controller.OnTextChange(string.Empty);
                Assert.Equal(string.Empty, response);
            }
        }

        [Fact]
        public void OnTextChangeReturnsAppropriateMessageWhenNotFound()
        {
            using (var context = GetContextWithData())
            using (var controller = new WordController(context))
            {
                var response = controller.OnTextChange("000");
                Assert.Equal("No word matched the phrase", response);
            }
        }

        [Fact]
        public void OnTextChangeReturnsWordsJoinedByComma()
        {
            using (var context = GetContextWithData())
            using (var controller = new WordController(context))
            {
                var response = controller.OnTextChange("7668");
                Assert.Equal("ROOT,SNOT", response);
            }
        }

        [Fact]
        public void OnTextChangeReturnsSortedWordsJoinedByComma()
        {
            using (var context = GetContextWithData())
            using (var controller = new WordController(context))
            {
                var response = controller.OnTextChange("688");
                Assert.Equal("NUT,OUT", response);
            }
        }

        [Fact]
        public void OnTextChangeReturnsWordOnlyWhenSingleMatch()
        {
            using (var context = GetContextWithData())
            using (var controller = new WordController(context))
            {
                var response = controller.OnTextChange("4663");
                Assert.Equal("GOOD", response);
            }
        }

        private WordContext GetContextWithData()
        {
            var options = new DbContextOptionsBuilder<WordContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;
            var context = new WordContext(options);

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
            },
            new Word
            {
                Phrase = "OUT",
                Code = "688"
            },
            new Word
            {
                Phrase = "NUT",
                Code = "688"
            }
            );
            context.SaveChanges();

            return context;
        }
    }
}
