using Microsoft.AspNetCore.Mvc;
using UnitTestDemo.Web.Controllers;
using UnitTestDemo.Web.Models;

namespace UnitTestDemo.Tests
{
    public class ProductControllerTest
    {
        /*
         * Testing: Model.
         * Product list content count returned.
         */
        [Fact]
        public void Test_Index_Returns_ProductCount()
        {
            // Arrage all variables
            var controller = new ProductController();
            var result = controller.Index() as ViewResult;
            // Act over variables
            var productList = (List<Product>?)result?.ViewData.Model;
            // Assert
            Assert.Equal(3, productList?.Count);
        }

        /*
         * Testing: View return.
         */
        [Fact]
        public void Test_Details_Returns_ViewName()
        {
            var controller = new ProductController();
            var result = controller.Details(2) as ViewResult;
            Assert.Equal("Details", result?.ViewName);
        }

        /*
         * Testing: Action result.
         */
        [Fact]
        public void Test_Details_RedirectToIndex_IfIdLessThanOne()
        {
            var controller = new ProductController();
            var result = controller.Details(0) as RedirectToActionResult;
            Assert.Equal("Index", result?.ActionName);
        }

        [Fact]
        public void Test_Details_Returns_ViewData()
        {
            var controller = new ProductController();
            var result = controller.Details(2) as ViewResult;
            var product = result?.ViewData?.Model;
            //Assert.Equal("Mobile", product?.ToString()); // Will fail
            Assert.Equal("Television", product?.ToString()); // Will succed
        }
    }
}
