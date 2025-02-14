namespace TodoCleanArchitecture.Domain.Entities;

public class Ticket
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public List<Member>? Members { get; set; }
}
