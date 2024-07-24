using DistributedSystemsAndMicroservices.Models;
using DistributedSystemsAndMicroservices.Services;
using Microsoft.AspNetCore.Mvc;

namespace DistributedSystemsAndMicroservices.Controllers;

public class OrdersController : ControllerBase
{
    private readonly OrderService _orderService;

    public OrdersController(OrderService orderService)
    {
        _orderService = orderService;
    }

    [HttpGet]
    [Route("api/[controller]/GetOrders")]
    public IActionResult GetOrders()
    {
        var orders = _orderService.GetAllOrders();
        return Ok(orders);
    }

    [HttpGet]
    [Route("api/[controller]/GetOrder/{id}", Name = "GetOrder")]
    public IActionResult GetOrder(int id)
    {
        try
        {
            var order = _orderService.GetOrderById(id);
            return Ok(order);
        }
        catch (ArgumentException ex)
        {
            return NotFound(ex.Message);
        }
    }
    
    [HttpPost]
    [Route("api/[controller]/CreateOrder")]
    public async Task<IActionResult> CreateOrder([FromBody] Order? order)
    {
        try
        {
            if (order == null)
            {
                return BadRequest("Please provide user id, product name and quantity in the request body");
            }
            
            if (order.OrderId != 0)
            {
                return BadRequest("OrderId should not be provided in the request body.");
            }
            var newOrder = await _orderService.CreateOrder(order);
            return CreatedAtRoute("GetOrder", new { id = newOrder.OrderId }, newOrder);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}