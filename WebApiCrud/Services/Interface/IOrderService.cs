using ecommerce.Model;

namespace ecommerce.Services.Interface
{
    public interface IOrderService
    {
        List<Order> GetAllOrders();
        Order? GetOrderByID(int id);
        Order AddOrder(ModifyOrder obj);
        Order? UpdateOrder(int id, ModifyOrder obj);
        bool DeleteOrderByID(int id);
    }
}
