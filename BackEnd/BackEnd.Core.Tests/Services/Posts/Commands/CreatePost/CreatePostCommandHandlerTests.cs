using BackEnd.Core.Interfaces;
using BackEnd.Core.Models;
using BackEnd.Core.Services.Posts.Commands.CreatePost;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BackEnd.Core.Tests.Services.Posts.Commands.CreatePost
{
    [TestClass]
    public class CreatePostCommandHandlerTests
    {
        private CreatePostCommandHandler _handler;
        private readonly Mock<IPostStore> _postStoreMock = new();
        private readonly Post _post = new()
        {
            Content = nameof(Post.Content),
            PhotoUrl = nameof(Post.PhotoUrl),
            Id = default
        };

        public CreatePostCommandHandlerTests()
        {
            SetupPostStoreForValidScenario();
            _handler = new CreatePostCommandHandler(_postStoreMock.Object);
        }

        [TestMethod]
        public async Task HandleCreatePostCommand_NullContent_ThrowsException()
        {
            var command = new CreatePostCommand
            {
                Content = null,
                PhotoUrl = null,
            };

            var exception = await Assert.ThrowsExceptionAsync<ArgumentNullException>(() => _handler.Handle(command, CancellationToken.None));

            Assert.AreEqual(exception.ParamName, "Content");
        }

        [TestMethod]
        public async Task HandleCreatePostCommand_NullPhotoUrl_ThrowsException()
        {
            var command = new CreatePostCommand
            {
                Content = "Some content",
                PhotoUrl = null,
            };

            var exception = await Assert.ThrowsExceptionAsync<ArgumentNullException>(() => _handler.Handle(command, CancellationToken.None));

            Assert.AreEqual(exception.ParamName, "PhotoUrl");
        }

        [TestMethod]
        public async Task HandleCreatePostCommand_NullCommand_ThrowsException()
        {
            var exception = await Assert.ThrowsExceptionAsync<ArgumentNullException>(() => _handler.Handle(null, CancellationToken.None));

            Assert.AreEqual(exception.ParamName, "request");
        }

        [TestMethod]
        public async Task HandleCreatePostCommand_ValidCommand_PostCreated()
        {
            var post = await _handler.Handle(new CreatePostCommand()
            {
                Content = _post.Content,
                PhotoUrl = _post.PhotoUrl
            }, CancellationToken.None);

            Assert.IsNotNull(post);
            Assert.AreEqual(post.Content, _post.Content);
            Assert.AreEqual(post.PhotoUrl, _post.PhotoUrl);
        }

        [TestMethod]
        public async Task HandleCreatePostCommand_ValidCommand_PostNotCreated()
        {
            SetupPostStoreForInvalidScenario();
            _handler = new CreatePostCommandHandler(_postStoreMock.Object);

            var post = await _handler.Handle(new CreatePostCommand()
            {
                Content = _post.Content,
                PhotoUrl = _post.PhotoUrl
            }, CancellationToken.None);


            Assert.IsNull(post);            
        }

        private void SetupPostStoreForValidScenario()
        {
            _postStoreMock.Setup(ps => ps.Add(It.IsAny<Post>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(_post);
        }

        private void SetupPostStoreForInvalidScenario()
        {
            _postStoreMock.Setup(ps => ps.Add(It.IsAny<Post>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(null, new TimeSpan(1));
        }
    }
}
