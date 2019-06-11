using BupaWebAPI.Clients;
using BupaWebAPI.Controllers;
using BupaWebAPI.Messages;
using FluentAssertions;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using NSubstitute;
using NUnit.Framework;
using NUnit.Framework.Internal;
using System;
using System.Threading.Tasks;

namespace BupaWebAPIUnitTest
{
    public class MemberControllerTests
    {
        private MembersController _controller;
        private IMemberApiClient _membetApiClient;
        private ILogger<MembersController> _logger = new Logger<MembersController>(new NullLoggerFactory());

        [SetUp]
        public void Setup()
        {
            _logger = new Logger<MembersController>(new NullLoggerFactory());
            _membetApiClient = Substitute.For<IMemberApiClient>();
            _controller = new MembersController(_logger, _membetApiClient);
        }

        [Test()]
        public async Task Can_Create_Member()
        {
            var request = new CreateMemberRequest
            {
                Id = Guid.NewGuid(),
                Name = "Hugo"
            };

            var response = new CreateMemberResponse
            {
                Id = Guid.NewGuid()
            };
            _membetApiClient.CreateMemberAsync(request).Returns(Task.FromResult(response));

            var result = await _controller.CreateMember(request);
            result.Id.Should().NotBeEmpty();
        }
         
        [Test()]
        public async Task Cannot_Create_MemberAsync()
        {
            var request = new CreateMemberRequest
            {
                Id = Guid.NewGuid(),
                Name = "Hugo"
            };

            var response = new CreateMemberResponse
            {
                Message = "Can not create member"
            };

            _membetApiClient.CreateMemberAsync(request).Returns(Task.FromResult(response));

            var result = await _controller.CreateMember(request);
            result.Message.Should().Be("Can not create member");
        }
    }
}
