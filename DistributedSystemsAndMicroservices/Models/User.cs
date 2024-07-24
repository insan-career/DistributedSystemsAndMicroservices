using System.ComponentModel;

namespace DistributedSystemsAndMicroservices.Models;

public class User
{
    [ReadOnly(true)]
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Email { get; set; }
}