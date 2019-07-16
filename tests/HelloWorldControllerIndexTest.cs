using Microsoft.AspNetCore.Mvc;
using Xunit;
using SimpleMvc.Controllers; 

namespace SimpleMvcApps.tests 
{
    public class HelloWorldControllerIndexTest 
    {
        HelloWorldController controller; 

        public HelloWorldControllerIndexTest() 
        {
            controller = new HelloWorldController(); 
        }

        [Theory]
        [InlineData("Index")] 
        public void ViewTest(string viewName) 
        {
            var result = controller.Index() as ViewResult; 
            Assert.Equal(viewName, result.ViewName); 
        }

        [Theory]
        [InlineData("")] 
        [InlineData(" ")]
        [InlineData("Index    ")]  
        public void ViewFailedTestCases(string viewName) 
        {
            var result = controller.Index() as ViewResult; 
            Assert.NotEqual(viewName, result.ViewName); 
        }

        [Theory]
        [InlineData("Message", "message from aliens, earth is under attack")] 
        public void ViewTestData(string var, string msg) 
        {
            var result = controller.Index() as ViewResult; 
            Assert.Equal(msg, result.ViewData[var]); 
        }

        [Theory]
        [InlineData("Message", "")] 
        [InlineData("Message", " ")] 
        [InlineData("Message", "message from aliens")] 
        public void ViewTestDataFailTestCases(string var, string msg) 
        {
            var result = controller.Index() as ViewResult; 
            Assert.NotEqual(msg, result.ViewData[var]); 
        }
    }
}