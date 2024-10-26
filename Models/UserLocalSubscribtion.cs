using Educational_Medical_platform.Helpers;
using Shoghlana.Core.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace Educational_Medical_platform.Models
{
    public class UserLocalSubscribtion
    {
        public int Id { get; set; }

        [ForeignKey(nameof(User))]
        public string UserId { get; set; }

        public ApplicationUser User { get; set; }

        //--------------------------------------

        public string TransactionImageURL { get; set; }

        public LocalSubscribtionStatus Status { get; set; }
    }
}