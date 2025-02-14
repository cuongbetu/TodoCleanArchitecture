namespace TodoCleanArchitecture.Domain.Abstractions.Entities;

public interface IEntitiyAuditBase <Tkey> : IEntityBase<Tkey>, IAuditable
{
}
