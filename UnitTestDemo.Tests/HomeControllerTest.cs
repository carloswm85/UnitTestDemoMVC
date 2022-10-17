using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTestDemo.Controllers;
using UnitTestDemo.Web.Models;

namespace UnitTestDemo.Tests
{
    public class HomeControllerTest
    {
        [Fact]
        public void Test_Index_ReturnsViewName()
        {
            var controller = new HomeController();
            var result = controller.Index() as ViewResult;
            Assert.Equal("Index", result?.ViewName);
        }
        [Fact]
        public void Test_Index_ReturnsViewData()
        {
            var controller = new HomeController();
            var result = controller.Index() as ViewResult;
            var product = (Product?)result?.ViewData.Model;
            Assert.Null(product);
        }
    }
}
