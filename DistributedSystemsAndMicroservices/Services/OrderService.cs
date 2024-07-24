
using DistributedSystemsAndMicroservices.Models;

namespace DistributedSystemsAndMicroservices.Services;

public class OrderService
{
    private static readonly List<Order> Orders = new List<Order>();
    private readonly HttpClient _httpClient;

    public OrderService(HttpClient httpClient)
    {
        _httpClient = httpClient;
        
        var baseUrl = Environment.GetEnvironmentVariable("BaseUrl");
        var urlPort = Environment.GetEnvironmentVariable("UrlPort");
        
        _httpClient.BaseAddress = new Uri($"{baseUrl}:{urlPort}");
    }

    public List<Order> GetAllOrders()
    {
        return Orders.ToList();
    }
    
    public Order? GetOrderById(int id)
    {
        var order =  Orders.FirstOrDefault(u => u.OrderId == id);
        if (order == null)
        {
            throw new ArgumentException($"Order with ID {id} not found.");
        }
        return order;
    }

    public async Task<Order> CreateOrder(Order order)
    {
        // Validate UserID by calling User Service API
        var userUrl = $"api/users/GetUser/{order.UserId}";

        try
        {
            var response = await _httpClient.GetAsync(userUrl);
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"User with ID {order.UserId} not found.");
            }
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }

        order.OrderId = Orders.Count + 1;
        Orders.Add(order);
        return order;
    }
}