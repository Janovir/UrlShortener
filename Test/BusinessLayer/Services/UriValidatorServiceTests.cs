using Microsoft.VisualStudio.TestTools.UnitTesting;
using BusinessLayer.Services.Abstraction;

namespace Test
{
    [TestClass]
    public class UriValidatorServiceTests
    {
        private readonly IUrlValidatorService _ValidatorService;

        public UriValidatorServiceTests()
        {
            _ValidatorService = new UrlValidatorService();
        }

        [DataTestMethod]
        [DataRow("https://google.com", true)]
        [DataRow("www.google.com", false)]
        [DataRow("https://google.com", true)]
        public void UriIsValidAsync(string url, bool expectedResult)
        {
            // Act
            var result = _ValidatorService.ValidateUrl(url);

            // Assert
            Assert.AreEqual(result.IsValid, expectedResult);
        }
    }
}
