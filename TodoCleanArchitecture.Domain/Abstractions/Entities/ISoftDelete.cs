namespace TodoCleanArchitecture.Domain.Abstractions.Entities;

public interface ISoftDelete
{
    bool IsDeleted { get; set; }
    DateTimeOffset? DeletedAt { get; set; }
    public void Undo()
    {
        IsDeleted = true;
        DeletedAt = null;
    }
}
