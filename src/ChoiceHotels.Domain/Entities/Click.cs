namespace ChoiceHotels.Domain.Entities;

public class Click
{
    public Guid Id { get; set; }
    
    public required string ClickId { get; set; }
    
    public required string Offer { get; set; }
    
    public required string Sub1 { get; set; }
    
    public DateTime Timestamp { get; set; }
    
    public required string Ip { get; set; }
    
    public required string UserAgent { get; set; }
}