namespace Notices.Domain.Entities;

public class Offer
{
    public Guid Id { get; set; }
    public EducationLevel EducationLevel { get; set; }
    public decimal Price { get; set; }
}