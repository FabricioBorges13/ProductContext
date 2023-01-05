using FluentAssertions;
using NUnit.Framework;
using ProductContext.Domain.Features.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductContext.Domain.Tests.Features.Products
{
    [TestFixture]
    public class ProductDomainTests
    {
        Product _product;

        [SetUp]
        public void SetUp()
        {
            _product = new Product();
        }

        [Test]
        public void Domain_Product_Delete_Should_Be_Ok()
        {
            //Action
            _product.Delete();

            //Assert
            _product.Situation.Should().BeFalse();
        }

        [Test]
        public void Domain_Product_ValidateManufacturingDate_Should_Be_Ok()
        {
            //Arrange
            _product.ManufacturingDate = DateTime.Now;
            _product.DueDate = DateTime.Now.AddDays(1);

            //Action
            Action validate = () => _product.ValidateManufacturingDate();

            //Assert
            validate.Should().NotThrow<Exception>();
        }

        [Test]
        public void Domain_Product_ValidateManufacturingDate_Should_Be_Fail()
        {
            //Arrange
            _product.ManufacturingDate = DateTime.Now;
            _product.DueDate = DateTime.Now.AddDays(-1);

            //Action
            Action validate = () => _product.ValidateManufacturingDate();

            //Assert
            validate.Should().Throw<Exception>();
        }

        [Test]
        public void Domain_Product_ValidateManufacturingDate_Date_Equals_Should_Be_Fail()
        {
            //Arrange
            var date = DateTime.Now;
            _product.ManufacturingDate = date;
            _product.DueDate = date;

            //Action
            Action validate = () => _product.ValidateManufacturingDate();

            //Assert
            validate.Should().Throw<Exception>();
        }

        [Test]
        public void Domain_Product_ValidateManufacturingDate_DueDate_Null_Should_Be_Fail()
        {
            //Arrange
            var date = DateTime.Now;
            _product.ManufacturingDate = date;

            //Action
            Action validate = () => _product.ValidateManufacturingDate();

            //Assert
            validate.Should().Throw<Exception>();
        }

        [Test]
        public void Domain_Product_ValidateCNPJ_Mask_Should_Be_Ok()
        {
            //Arrange
            _product.CNPJProvider = "74.451.742/0001-70";

            //Action            
            Action validate = () => _product.ValidateCNPJ();

            //Assert
            validate.Should().NotThrow<Exception>();
        }

        [Test]
        public void Domain_Product_ValidateCNPJ_Should_Be_Ok()
        {
            //Arrange
            _product.CNPJProvider = "07256912000178";

            //Action            
            Action validate = () =>  _product.ValidateCNPJ();

            //Assert
            validate.Should().NotThrow<Exception>();
        }

        [Test]
        public void Domain_Product_ValidateCNPJ_Should_Be_Fail()
        {
            //Arrange
            _product.CNPJProvider = "01234567891011";

            //Action            
            Action validate = () => _product.ValidateCNPJ();

            //Assert
            validate.Should().Throw<Exception>();
        }

        [Test]
        public void Domain_Product_ValidateCNPJ_Null_Should_Be_Ok()
        {

            //Action            
            Action validate = () => _product.ValidateCNPJ();

            //Assert
            validate.Should().NotThrow<Exception>();
        }
    }
}
