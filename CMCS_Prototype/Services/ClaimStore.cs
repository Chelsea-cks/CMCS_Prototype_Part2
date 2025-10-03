using System.Collections.ObjectModel;
using CMCS_Prototype.Models;
using System.Linq;

namespace CMCS_Prototype.Services
{
    public static class ClaimStore
    {
        public static ObservableCollection<Claim> Claims { get; } = new ObservableCollection<Claim>();

        public static void AddClaim(Claim c) => Claims.Add(c);

        public static Claim? GetById(System.Guid id) => Claims.FirstOrDefault(x => x.Id == id);

        public static void ApproveByCoordinator(System.Guid id)
        {
            var c = GetById(id);
            if (c != null) c.Status = "Coordinator Approved";
        }

        public static void RejectByCoordinator(System.Guid id)
        {
            var c = GetById(id);
            if (c != null) c.Status = "Coordinator Rejected";
        }

        public static void ApproveByManager(System.Guid id)
        {
            var c = GetById(id);
            if (c != null) c.Status = "Manager Approved";
        }

        public static void RejectByManager(System.Guid id)
        {
            var c = GetById(id);
            if (c != null) c.Status = "Manager Rejected";
        }
    }
}
