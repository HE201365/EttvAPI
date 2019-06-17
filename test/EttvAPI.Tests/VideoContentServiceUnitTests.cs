using System;
using System.Linq;
using EttvAPI.Data.Models;
using EttvAPI.Repos.Repositories;
using EttvAPI.Services;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace EttvAPI.Tests
{
    public class VideoContentServiceUnitTests
    {
        [Fact]
        public void ShouldBeReturnAllVideoContents()
        {
            var options = new DbContextOptionsBuilder<EttvDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;
            var context = new EttvDbContext(options);

            Seed(context);

            var query = context.VideoContents
                .OrderBy(a => a.Tag)
                .ToList();

            Assert.Equal(3, query.Count);
        }

        [Fact]
        public void ShouldBOrderVideoContentsByTitle()
        {
            var options = new DbContextOptionsBuilder<EttvDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;
            var context = new EttvDbContext(options);

            Seed(context);

            var query = context.VideoContents
                .OrderBy(a => a.Title)
                .ToList();

            Assert.Equal("title1", query.First().Title);
            Assert.Equal("title3", query.Last().Title);
        }

        [Fact]
        public void ShouldResturnVideoContents()
        {
            var options = new DbContextOptionsBuilder<EttvDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;
            var context = new EttvDbContext(options);

            Seed(context);

            var videocontentservice = new VideoContentService(unitOfWork: new UnitOfWork(context));

            var list = videocontentservice.List();
            
            Assert.Equal("title1", videocontentservice.List().Where(x=>x.VideoId=="videoId1").SingleOrDefault().Title);
            Assert.Equal("title3", videocontentservice.List().Where(x => x.VideoId == "videoId3").LastOrDefault().Title);
        }

        private void Seed(EttvDbContext context)
        {
            var videoContents = new[]
            {
                new VideoContent { VideoId = "videoId1", Title = "title1", Thumbnail = "thumbnail1", Tag = "tag1", AppUserId = 1, Duration = 1000 },
                new VideoContent { VideoId = "videoId2", Title = "title2", Thumbnail = "thumbnail2", Tag = "tag2", AppUserId = 1, Duration = 2000 },
                new VideoContent { VideoId = "videoId3", Title = "title3", Thumbnail = "thumbnail3", Tag = "tag3", AppUserId = 2, Duration = 3000 },
            };

            var appUser = new[]
            {
                new AppUser { Id = 1, Email = "aa@aa.aa", FirstName = "aa", LastName = "aaLast", HashPassword = "aaPassword", Profile = null },
                new AppUser { Id = 2, Email = "bb@bb.bb", FirstName = "bb", LastName = "bbLast", HashPassword = "bbPassword", Profile = null },
                new AppUser { Id = 3, Email = "cc@cc.cc", FirstName = "cc", LastName = "ccLast", HashPassword = "ccPassword", Profile = null }
            };

            context.AppUsers.AddRange(appUser);
            context.VideoContents.AddRange(videoContents);
            context.SaveChanges();
        }
    }
}
