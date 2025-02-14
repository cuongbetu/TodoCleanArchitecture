namespace TodoCleanArchitecture.Domain.Abstractions.Entities;

public interface IAuditable : IUserTracking, IDateTracking, ISoftDelete
{
}
