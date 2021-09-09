using BusinessLayer.Services;
using BusinessLayer.Services.Abstraction;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Threading.Tasks;

namespace Test
{
    [TestClass]
    public class KeyServiceTests
    {
        private readonly IKeyService _keyService;

        public KeyServiceTests()
        {
            var _configuration = new Mock<IConfiguration>();
            _configuration.Setup(x => x[It.IsAny<string>()]).Returns("0123456789bcdfghjklmnpqrstvwxzBCDFGHJKLMNPQRSTVWXZ");

            _keyService = new KeyService(_configuration.Object);
        }

        [DataTestMethod]
        [DataRow(12345, "TV4")]
        [DataRow(1, "1")]
        [DataRow(98765, "htM")]
        public async Task GetKeyAsync(int number, string expectedKey)
        {
            // Act
            var key = await _keyService.GetKeyAsync(number);

            // Assert
            Assert.AreEqual(key, expectedKey);
        }

        [DataTestMethod]
        [DataRow("TV4", 12345)]
        [DataRow("1", 1)]
        [DataRow("htM", 98765)]
        public async Task GetIdAsync(string expectedKey, int number)
        {
            // Act
            var key = await _keyService.GetKeyAsync(number);

            // Assert
            Assert.AreEqual(key, expectedKey);
        }
    }
}
