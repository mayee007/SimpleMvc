using Microsoft.AspNetCore.Mvc;
using Xunit;
using SimpleMvc.Controllers; 

namespace SimpleMvcApps.tests 
{
    public class HelloWorldControllerWelcomeTest 
    {
        HelloWorldController controller; 

        public HelloWorldControllerWelcomeTest() 
        {
            controller = new HelloWorldController(); 
        }

        [Theory]
        [InlineData("Welcome")] 
        public void ViewTest(string viewName) 
        {
            var result = controller.Welcome() as ViewResult; 
            Assert.Equal(viewName, result.ViewName); 
        }

        [Theory]
        [InlineData("")] 
        [InlineData(" ")]
        [InlineData("Welcome   ")]  
        public void ViewFailedTestCases(string viewName) 
        {
            var result = controller.Welcome() as ViewResult; 
            Assert.NotEqual(viewName, result.ViewName); 
        }

        [Theory]
        [InlineData("Message", "Hello Aliens, Welcome to Earth!")] 
        public void ViewTestData(string var, string msg) 
        {
            var result = controller.Welcome() as ViewResult; 
            Assert.Equal(msg, result.ViewData[var]); 
        }

        [Theory]
        [InlineData("Message", "")] 
        [InlineData("Message", " ")] 
        [InlineData("Message", "message from aliens")] 
        public void ViewTestDataFailTestCases(string var, string msg) 
        {
            var result = controller.Welcome() as ViewResult; 
            Assert.NotEqual(msg, result.ViewData[var]); 
        }
    }
}