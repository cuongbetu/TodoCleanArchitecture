namespace TodoCleanArchitecture.Domain.Abstractions.Entities;

public interface IEntityBase <Tkey>
{
    public Tkey Id { get; set;}
}
