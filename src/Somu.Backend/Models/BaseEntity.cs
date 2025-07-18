namespace Somu.Backend.Models;

public class BaseEntity
{
    public string Id { get; set; } = Guid.NewGuid().ToString();
    
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    
}