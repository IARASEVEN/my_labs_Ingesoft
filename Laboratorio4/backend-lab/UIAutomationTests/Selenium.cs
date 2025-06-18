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
            options.AddArgument("--start-maximized");  
            _driver = new EdgeDriver(options);          
        }

        [TearDown]
        public void TearDown()
        {
            _driver?.Quit();    
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

        [Test]
        public void Crear_Pais_Desde_Formulario_Test()
        {
            // Arrange
            const string url = "http://localhost:8080/";
            string nombrePais = "Noruega";
            string continente = "Europa";
            string idioma = "Noruego";

            // Act
            _driver.Navigate().GoToUrl(url);

    
            var botonAgregar = _driver.FindElement(By.XPath("//button[contains(text(),'Agregar país')]"));
            botonAgregar.Click();

          
            var inputNombre = _driver.FindElement(By.Id("name"));
            var selectContinente = _driver.FindElement(By.Id("continente"));
            var inputIdioma = _driver.FindElement(By.Id("idioma"));

            inputNombre.SendKeys(nombrePais);
            selectContinente.Click();
            
            var opcionContinente = selectContinente.FindElement(By.XPath($"//option[text()='{continente}']"));
            opcionContinente.Click();
            inputIdioma.SendKeys(idioma);

          
            var botonGuardar = _driver.FindElement(By.XPath("//button[contains(text(),'Guardar')]"));
            botonGuardar.Click();

           
            System.Threading.Thread.Sleep(1500);

            // Assert
            var filas = _driver.FindElements(By.XPath("//table//tbody/tr"));
            bool paisCreado = filas.Any(fila =>
                fila.Text.Contains(nombrePais) &&
                fila.Text.Contains(continente) &&
                fila.Text.Contains(idioma)
            );
            Assert.IsTrue(paisCreado, "El país no fue creado correctamente");
        }
    }
}

