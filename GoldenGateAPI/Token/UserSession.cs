using System.Security.Claims;

namespace GoldenGateAPI.Token;

public class UserSession : IUserSession
{

    private readonly IHttpContextAccessor _httpContextAccessor;

    public UserSession(IHttpContextAccessor httpContextAccessor) 
    {
        _httpContextAccessor = httpContextAccessor;
    }

    public string GetUserSession()
    {
        var username =  _httpContextAccessor.HttpContext!.User?.Claims?
                            .FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;

        return username!;
    }
}
