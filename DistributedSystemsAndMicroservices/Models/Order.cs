using System.ComponentModel;

namespace DistributedSystemsAndMicroservices.Models;

public class Order
{
    [ReadOnly(true)]
    public int OrderId { get; set; }
    public int UserId { get; set; }
    public string? Product { get; set; }
    public int Quantity { get; set; }
}