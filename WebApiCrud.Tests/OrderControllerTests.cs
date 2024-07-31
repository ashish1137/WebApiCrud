using ecommerce.Model;
using ecommerce.Services;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using Moq;
using ecommerce.Services.Interface;
using ecommerce.Controllers;
namespace WebApiCrud.Tests
{
    [TestClass]
    public class OrderControllerTests
    {
        [TestMethod]
        public void GetOrderByID_filters_by_id()
        {
            //var orderServiceMock = new Mock<IOrderService>();
            //var controller = new OrderController(orderServiceMock.Object);
            var controller = new OrderController(new OrderService());
            //Arrange
            var existingOrder = new Order()
            {
                Id = 1,
                FirstName = "FirstName1",
                LastName = "LastName1",
                Description = "Description1",
                Quantity = 1,
            };

            //Act
            var response = controller.Get(1);

            //Assert
            Assert.IsNotNull(response);
            var obj = (Order)((Microsoft.AspNetCore.Mvc.ObjectResult)response).Value;


            Assert.IsTrue(obj.Id == existingOrder.Id);
            Assert.IsTrue(obj.FirstName == existingOrder.FirstName);
            Assert.IsTrue(obj.LastName == existingOrder.LastName);
            Assert.IsTrue(obj.Description == existingOrder.Description);
            Assert.IsTrue(obj.Quantity == existingOrder.Quantity);

            //Act
            var response2 = controller.Get(2);

            //Assert
            var obj2 = ((Microsoft.AspNetCore.Mvc.StatusCodeResult)response2).StatusCode;
            Assert.IsTrue(obj2 == 404);
        }

        [TestMethod]
        public void GetAllOrders_returns_all_orders()
        {
            //Arrange
            var newOrder = new ModifyOrder()
            {
                FirstName = "FirstName2",
                LastName = "LastName2",
                Description = "Description2",
                Quantity = 2,
            };
            //No mocking
            var controller = new OrderController(new OrderService());

            //Act
            var obj = controller.Post(newOrder);
            var response = controller.Get();

            //Assert
            Assert.IsNotNull(response);
            var obj2 = (List<Order>)((Microsoft.AspNetCore.Mvc.ObjectResult)response).Value;
            Assert.IsTrue(obj2.Count() == 2);
        }

        [TestMethod]
        public void AddOrders_adds_new_order()
        {
            //Arrange
            var newOrder = new ModifyOrder()
            {
                FirstName = "FirstName2",
                LastName = "LastName2",
                Description = "Description2",
                Quantity = 2,
            };
            //No mocking
            var controller = new OrderController(new OrderService());

            //Act
            var obj = controller.Post(newOrder);
            var response = controller.Get();

            //Assert
            Assert.IsNotNull(response);
            var obj2 = (List<Order>)((Microsoft.AspNetCore.Mvc.ObjectResult)response).Value;
            Assert.IsTrue(obj2.Count() == 2);
        }

        [TestMethod]
        public void Put_updates_existing_order()
        {
            //Arrange
            var updatedOrder = new ModifyOrder()
            {
                FirstName = "FirstName2",
                LastName = "LastName2",
                Description = "Description2",
                Quantity = 2,
            };
            //No mocking
            var controller = new OrderController(new OrderService());

            //Act
            var response1 = controller.Put(1, updatedOrder);
            var response = controller.Get(1);

            //Assert
            Assert.IsNotNull(response);
            var obj = (Order)((Microsoft.AspNetCore.Mvc.ObjectResult)response).Value;

            Assert.IsTrue(obj.FirstName == updatedOrder.FirstName);
            Assert.IsTrue(obj.LastName == updatedOrder.LastName);
            Assert.IsTrue(obj.Description == updatedOrder.Description);
            Assert.IsTrue(obj.Quantity == updatedOrder.Quantity);
        }

        [TestMethod]
        public void Delete_deletes_order()
        {
            //Arrange
            var newOrder = new ModifyOrder()
            {
                FirstName = "FirstName2",
                LastName = "LastName2",
                Description = "Description2",
                Quantity = 2,
            };
            //No mocking
            var controller = new OrderController(new OrderService());

            //Act
            var obj = controller.Post(newOrder);
            var response = controller.Get();

            //Assert
            Assert.IsNotNull(response);
            var obj2 = (List<Order>)((Microsoft.AspNetCore.Mvc.ObjectResult)response).Value;
            Assert.IsTrue(obj2.Count() == 2);

            //Act
            var objAfterDeletion = controller.Delete(1);
            var responseAfterDeletion = controller.Get(1);

            //Assert
            var noFoundStatusCode = ((Microsoft.AspNetCore.Mvc.StatusCodeResult)responseAfterDeletion).StatusCode;
            Assert.IsTrue(noFoundStatusCode == 404);
        }
    }
}