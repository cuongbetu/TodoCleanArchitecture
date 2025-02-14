namespace TodoCleanArchitecture.Domain.Entities;

public class Member
{
    public int MemberId { get; set; }
    public required string MemberName { get; set; } = string.Empty;
    public int ManagerId { get; set; }
    public Manager Manager { get; set; }
    public List<Ticket>? Tickets { get; set; }
}
