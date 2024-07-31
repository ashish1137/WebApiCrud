using ecommerce.Model;
using ecommerce.Services.Interface;

namespace ecommerce.Services
{
    public class OrderService : IOrderService
    {
        private readonly List<Order> _ordersList;
        public OrderService()
        {
            _ordersList = new List<Order>()
                {
                    new Order(){
                        Id = 1,
                        FirstName = "FirstName1",
                        LastName = "LastName1",
                        Description = "Description1",
                        Quantity = 1,
                    }
                };
        }

        public List<Order> GetAllOrders()
        {
            return _ordersList;
        }

        public Order? GetOrderByID(int id)
        {
            return _ordersList.FirstOrDefault(order => order.Id == id);
        }

        public Order AddOrder(ModifyOrder obj)
        {
            var addOrder = new Order()
            {
                Id = _ordersList.Max(order => order.Id) + 1,
                FirstName = obj.FirstName,
                LastName = obj.LastName,
                Description = obj.Description,
                Quantity = obj.Quantity,
            };

            _ordersList.Add(addOrder);

            return addOrder;
        }

        public Order? UpdateOrder(int id, ModifyOrder obj)
        {
            var order = _ordersList.Where(order => order.Id == id).FirstOrDefault();
            if (order != null)
            { 
                order.FirstName = obj.FirstName;
                order.LastName = obj.LastName;
                order.Description = obj.Description;
                order.Quantity = obj.Quantity;

                return order;
            }
            else
            {
                return null;
            }
        }
        public bool DeleteOrderByID(int id)
        {
            var order = _ordersList.Where(order => order.Id == id).FirstOrDefault();
            if (order != null)
            {
                _ordersList.Remove(order);
                return true;
            }
            return false;
        }
    }
}
