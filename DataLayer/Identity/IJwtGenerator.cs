using Safe_Development.DataLayer.Identity;

namespace Safe_Development.Identity
{
    public interface IJwtGenerator
    {
        string CreateToken(User user);
    }
}
