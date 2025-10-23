using System.Collections.Generic;

namespace CMCS_Prototype.Models
{
    public static class ClaimManager
    {
        public static List<Claim> Claims { get; } = new List<Claim>();

        public static void AddClaim(Claim claim)
        {
            Claims.Add(claim);
        }
    }
}
