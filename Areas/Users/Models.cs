using Microsoft.AspNetCore.Identity;

namespace CongressusCore.Areas.Users.Models {
    public class UserRole : IdentityUserRole<int> {}
    public class Role: IdentityRole<int> {}
    public class  UserClaim : IdentityUserClaim<int> {}
}