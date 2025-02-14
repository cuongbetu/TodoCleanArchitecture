namespace TodoCleanArchitecture.Domain.Entities;

public class Manager
{
    public int Id { get; set; }
    public required string ManagerName { get; set; } = string.Empty;
    public List<Member>? Members { get; set; }
}
