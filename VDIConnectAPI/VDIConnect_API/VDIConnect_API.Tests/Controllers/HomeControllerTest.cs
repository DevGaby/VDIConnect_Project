using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using VDIConnect_API;
using VDIConnect_API.Controllers;

namespace VDIConnect_API.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void Index()
        {
            // Disposer
            HomeController controller = new HomeController();

            // Agir
            ViewResult result = controller.Index() as ViewResult;

            // Affirmer
            Assert.IsNotNull(result);
            Assert.AreEqual("VDIConnect API", result.ViewBag.Title);
        }
    }
}
