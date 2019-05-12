using System;
using EttvAPI.Controllers;
using Xunit;

namespace EttvAPI.Tests
{
    public class UnitTest1
    {
        ValuesController controller = new ValuesController();
        [Fact]
        public void GetReturnsCorrectNumber()
        {
            var returnValue = controller.Get(1);
            Assert.Equal("EminjanO", returnValue.Value);
        }
        [Fact]
        public void Test1()
        {
            var returnValue = controller.Get(2);
            Assert.Equal("EminjanO", returnValue.Value);
        }
    }
    }
}
