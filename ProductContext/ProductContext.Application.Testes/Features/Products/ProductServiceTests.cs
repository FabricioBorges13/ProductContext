using AutoMapper;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using ProductContext.Application.Features.Products;
using ProductContext.Application.Features.Products.Commands;
using ProductContext.Domain.Features.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductContext.Application.Testes.Features.Products
{
    [TestFixture]
    public class ProductServiceTests
    {
        private Mock<IMapper> _mapper;
        private Mock<IProductRepository> _repository;
        private ProductService _service;
        [SetUp]
        public void SetUp()
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<ProductAddCommand, Product>();
                cfg.CreateMap<ProductUpdateCommand, Product>();
            });

            var mapper = config.CreateMapper();

            _mapper = new Mock<IMapper>();
            _repository = new Mock<IProductRepository>();
            _service = new ProductService(mapper, _repository.Object);
        }

        [Test]
        public void Service_Product_Add_Should_Be_Ok()
        {
            //Arrange
            var productAddCommand = new ProductAddCommand { };
            productAddCommand.ManufacturingDate = DateTime.Now;
            productAddCommand.DueDate = DateTime.Now.AddDays(1);
            _repository.Setup(x => x.AddAsync(It.IsAny<Product>())).Returns(Task.FromResult(true));

            //Action
            var result = _service.AddAsync(productAddCommand).Result;
            
            //Assert
            result.Should().BeTrue();
            _repository.Verify(x => x.AddAsync(It.IsAny<Product>()), Times.Once);
            _repository.VerifyNoOtherCalls();
        }

        [Test]
        public void Service_Product_Update_Should_Be_Ok()
        {
            //Arrange
            var productUpdateCommand = new ProductUpdateCommand { };
            productUpdateCommand.ManufacturingDate = DateTime.Now;
            productUpdateCommand.DueDate = DateTime.Now.AddDays(1);
            _repository.Setup(x => x.UpdateAsync(It.IsAny<Product>())).Returns(Task.FromResult(true));

            //Action
            var result = _service.UpdateAsync(productUpdateCommand).Result;

            //Assert
            result.Should().BeTrue();
            _repository.Verify(x => x.UpdateAsync(It.IsAny<Product>()), Times.Once);
            _repository.VerifyNoOtherCalls();
        }

        [Test]
        public void Service_Product_GetAll_Should_Be_Ok()
        {
            //Arrange
            List<Product> productList = new List<Product>();
            _repository.Setup(x => x.GetAllAsync()).Returns(Task.FromResult(productList));

            //Action
            var result = _service.GetAllAsync().Result;

            //Assert
            _repository.Verify(x => x.GetAllAsync());
            result.Should().NotBeNull();
            _repository.VerifyNoOtherCalls();
        }

        [Test]
        public void Service_Product_Delete_Should_Be_Ok()
        {
            //Arrange
            var product = new Product { };
            _repository.Setup(x => x.GetByIdAsync(It.IsAny<long>())).Returns(Task.FromResult(product));
            _repository.Setup(x => x.DeleteAsync(It.IsAny<Product>())).Returns(Task.FromResult(true));

            //Action
            var result = _service.DeleteAsync(It.IsAny<long>()).Result;

            //Assert
            result.Should().BeTrue();
            _repository.Verify(x => x.DeleteAsync(It.IsAny<Product>()), Times.Once);
            _repository.Verify(x => x.GetByIdAsync(It.IsAny<long>()), Times.Once);
        }

        [Test]
        public void Service_Product_GetById_Should_Be_Ok()
        {
            //Arrange
            Product product = new Product();
            _repository.Setup(x => x.GetByIdAsync(It.IsAny<long>())).Returns(Task.FromResult(product));

            //Action
            var result = _service.GetByIdAsync(It.IsAny<long>()).Result;

            //Assert
            _repository.Verify(x => x.GetByIdAsync(It.IsAny<long>()));
            result.Should().NotBeNull();
            _repository.VerifyNoOtherCalls();
        }

        [Test]
        public void Service_Product_Delete_Should_Be_Fail()
        {
            //Arrange
            Product product = null;
            _repository.Setup(x => x.GetByIdAsync(It.IsAny<long>())).Returns(Task.FromResult(product));
            _repository.Setup(x => x.DeleteAsync(It.IsAny<Product>())).Returns(Task.FromResult(true));

            //Action
            var result = _service.DeleteAsync(It.IsAny<long>()).Result;

            //Assert
            result.Should().BeFalse();
            _repository.Verify(x => x.DeleteAsync(It.IsAny<Product>()), Times.Never);
            _repository.Verify(x => x.GetByIdAsync(It.IsAny<long>()), Times.Once);
        }

        [Test]
        public void Service_Product_GetById_Should_Be_Fail()
        {
            //Arrange
            _repository.Setup(x => x.GetByIdAsync(It.IsAny<long>()));

            //Action
            var result = _service.GetByIdAsync(It.IsAny<long>()).Result;

            //Assert
            _repository.Verify(x => x.GetByIdAsync(It.IsAny<long>()));
            result.Should().BeNull();
            _repository.VerifyNoOtherCalls();
        }

        [Test]
        public void Service_Product_GetAll_Should_Be_Fail()
        {
            //Arrange
            _repository.Setup(x => x.GetAllAsync());

            //Action
            var result = _service.GetAllAsync().Result;

            //Assert
            _repository.Verify(x => x.GetAllAsync());
            result.Should().BeNull();
            _repository.VerifyNoOtherCalls();
        }

        [Test]
        public void Service_Product_Update_Should_Be_Fail()
        {
            //Arrange
            var productUpdateCommand = new ProductUpdateCommand { };
            productUpdateCommand.ManufacturingDate = DateTime.Now;
            productUpdateCommand.DueDate = DateTime.Now.AddDays(1);
            _repository.Setup(x => x.UpdateAsync(It.IsAny<Product>()));

            //Action
            var result = _service.UpdateAsync(productUpdateCommand).Result;

            //Assert
            result.Should().BeFalse();
            _repository.Verify(x => x.UpdateAsync(It.IsAny<Product>()), Times.Once);
            _repository.VerifyNoOtherCalls();
        }
    }
}
