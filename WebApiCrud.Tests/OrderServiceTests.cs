using ecommerce.Model;
using ecommerce.Services;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
namespace WebApiCrud.Tests
{
    [TestClass]
    public class OrderServiceTests
    {
        [TestMethod]
        public void GetOrderByID_filters_by_id()
        {
            //Arrange
            var existingOrder = new Order()
            {
                Id = 1,
                FirstName = "FirstName1",
                LastName = "LastName1",
                Description = "Description1",
                Quantity = 1,
            };
            //No mocking
            var orderService = new OrderService();

            //Act
            var obj = orderService.GetOrderByID(1);

            //Assert
            Assert.IsNotNull(obj);
            Assert.IsTrue(obj.Id == existingOrder.Id);
            Assert.IsTrue(obj.FirstName == existingOrder.FirstName);
            Assert.IsTrue(obj.LastName == existingOrder.LastName);
            Assert.IsTrue(obj.Description == existingOrder.Description);
            Assert.IsTrue(obj.Quantity == existingOrder.Quantity);

            //Act
            var obj2 = orderService.GetOrderByID(2);

            //Assert
            Assert.IsNull(obj2);
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
            var orderService = new OrderService();

            //Act
            var obj = orderService.AddOrder(newOrder);
            var response = orderService.GetAllOrders();

            //Assert
            Assert.IsNotNull(response);
            Assert.IsTrue(response.Count() == 2);
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
            var orderService = new OrderService();

            //Act
            var obj = orderService.AddOrder(newOrder);
            var response = orderService.GetAllOrders();

            //Assert
            Assert.IsNotNull(response);
            Assert.IsTrue(response.Count() == 2);
        }

        [TestMethod]
        public void UpdateOrder_updates_existing_order()
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
            var orderService = new OrderService();

            //Act
            var response = orderService.UpdateOrder(1, updatedOrder);
            var obj = orderService.GetOrderByID(1);

            //Assert
            Assert.IsNotNull(obj);
            Assert.IsTrue(obj.Id == 1);
            Assert.IsTrue(obj.FirstName == updatedOrder.FirstName);
            Assert.IsTrue(obj.LastName == updatedOrder.LastName);
            Assert.IsTrue(obj.Description == updatedOrder.Description);
            Assert.IsTrue(obj.Quantity == updatedOrder.Quantity);
        }

        [TestMethod]
        public void DeleteOrderByID_deletes_order()
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
            var orderService = new OrderService();

            //Act
            var obj = orderService.AddOrder(newOrder);
            var response = orderService.GetAllOrders();

            //Assert
            Assert.IsNotNull(response);
            Assert.IsTrue(response.Count() == 2);

            //Act
            var objAfterDeletion = orderService.DeleteOrderByID(1);
            var responseAfterDeletion = orderService.GetOrderByID(1);

            //Assert
            Assert.IsNull(responseAfterDeletion);
        }
    }
}