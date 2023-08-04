using GoldenGateAPI.Models;

namespace GoldenGateAPI.Token;

interface IJwtGenerator
{
    string CreateToken(User user);
}