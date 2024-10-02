namespace HRIS.Infrastructure.Authentication;

public interface ICurrentUserService
{
    string UserId { get; }
}
