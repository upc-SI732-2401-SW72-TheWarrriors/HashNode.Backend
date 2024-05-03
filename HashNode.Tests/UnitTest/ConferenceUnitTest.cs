using NUnit.Framework;
using Moq;
using HashNode.API.ConferenceManagement.Application.Internal.Services.CommandServices;
using HashNode.API.ConferenceManagement.Domain.Repositories;
using HashNode.API.ConferenceManagement.Domain.Models.Entities;
using HashNode.API.ConferenceManagement.Domain.Commands;
using HashNode.API.ConferenceManagement.Domain.Services.Communication;
using System.Threading.Tasks;
using System;
using HashNode.API.ConferenceManagement.Application.Internal.Services.Factories;

namespace HashNode.Tests.UnitTest
{
    [TestFixture]
    public class ConferenceUnitTest
    {
        private Mock<IConferenceRepository> _mockRepository;
        private Mock<IConferenceCommandFactory> _mockFactory;
        private ConferenceCommandServiceImpl _service;

        [SetUp]
        public void Setup()
        {
            _mockRepository = new Mock<IConferenceRepository>();
            _mockFactory = new Mock<IConferenceCommandFactory>();
            _service = new ConferenceCommandServiceImpl(_mockRepository.Object, _mockFactory.Object);
        }

        [Test]
        public async Task CreateConference_Success_ReturnsResponseWithConference()
        {
            // Arrange
            var command = new CreateConferenceCommand("1", "Test Conference", "Test Description");
            var conference = new Conference { Title = "Test Conference", Description = "Test Description" };
            _mockFactory.Setup(f => f.CreateConference(command)).Returns(conference);
            _mockRepository.Setup(r => r.CreateConferenceAsync(conference)).Returns(Task.CompletedTask);

            // Act
            var result = await _service.handle(command);

            // Assert
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Success);
            Assert.AreEqual(conference, result.Resource);
        }

        [Test]
        public async Task CreateConference_Failure_ReturnsErrorResponse()
        {
            // Arrange
            var command = new CreateConferenceCommand("1", "Test Conference", "Test Description");
            var conference = new Conference { Title = "Test Conference", Description = "Test Description" };
            _mockFactory.Setup(f => f.CreateConference(command)).Returns(conference);
            _mockRepository.Setup(r => r.CreateConferenceAsync(conference)).Throws(new Exception("Database error"));
            var expectedErrorMessage = "An error occurred while creating the conference: Database error";

            // Act
            var result = await _service.handle(command);

            // Assert
            Assert.IsNotNull(result);
            Assert.IsFalse(result.Success);
            Assert.AreEqual(expectedErrorMessage, result.Message);
        }

        [Test]
        public async Task UpdateConference_NotFound_ReturnsNotFoundResponse()
        {
            // Arrange
            string conferenceId = "123";
            var command = new UpdateConferenceCommand("Updated Title", "Updated Description");
            _mockRepository.Setup(r => r.FindConferenceByIdAsync(conferenceId)).Returns(Task.FromResult<Conference>(null));

            // Act
            var result = await _service.handle(conferenceId, command);

            // Assert
            Assert.IsFalse(result.Success);
            Assert.AreEqual("Conference not found", result.Message);
        }

        [Test]
        public async Task DeleteConference_Success_ReturnsSuccessResponse()
        {
            // Arrange
            string conferenceId = "123";
            var conference = new Conference { Id = conferenceId, Title = "Test Conference", Description = "Test Description" };
            _mockRepository.Setup(r => r.ConferenceExists(conferenceId)).Returns(true);
            _mockRepository.Setup(r => r.FindConferenceByIdAsync(conferenceId)).Returns(Task.FromResult(conference));
            _mockRepository.Setup(r => r.DeleteAsync(conference)).Returns(Task.CompletedTask);

            // Act
            var result = await _service.handle(new DeleteConferenceCommand(conferenceId));

            // Assert
            Assert.IsTrue(result.Success);
            Assert.AreEqual(conference, result.Resource);
        }

        [Test]
        public async Task DeleteConference_NotFound_ReturnsNotFoundResponse()
        {
            // Arrange
            string conferenceId = "123";
            _mockRepository.Setup(r => r.ConferenceExists(conferenceId)).Returns(false);

            // Act
            var result = await _service.handle(new DeleteConferenceCommand(conferenceId));

            // Assert
            Assert.IsFalse(result.Success);
            Assert.AreEqual("Conference not found", result.Message);
        }
    }
}
