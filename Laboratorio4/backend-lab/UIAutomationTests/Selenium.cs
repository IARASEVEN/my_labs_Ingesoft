using OpenQA.Selenium;
using OpenQA.Selenium.Edge;

namespace UIAutomationTests
{
    [TestFixture]
    public class ListaPaisesTests
    {
        private IWebDriver _driver;

        [SetUp]
        public void Setup()
        {
            // Configuración para Microsoft Edge
            var options = new EdgeOptions();
            options.AddArgument("--start-maximized");   // abre la ventana maximizada
            _driver = new EdgeDriver(options);          // Selenium Manager obtiene msedgedriver
        }

        [TearDown]
        public void TearDown()
        {
            _driver?.Quit();    // Cierra el navegador y finaliza la sesión WebDriver
        }

        [Test]
        public void Enter_To_List_Of_Countries_Test()
        {
            // Arrange
            const string url = "http://localhost:8080/";

            // Act
            _driver.Navigate().GoToUrl(url);

            // Assert
            // 1) Verifica el título de la pestaña
            Assert.AreEqual("frontend-lab", _driver.Title, "El título de la página no coincide");

        }
    }
}

