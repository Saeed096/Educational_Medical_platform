using Educational_Medical_platform.Helpers;

namespace Educational_Medical_platform.DTO.User
{
    public class GetUserLocalSubscribtionDTO
    {
        public int Id { get; set; }

        public string UserId { get; set; }

        public string UserFullName { get; set; }

        //--------------------------------------

        public string TransactionImageURL { get; set; }

        public LocalSubscribtionStatus Status { get; set; }

        public string StatusName { get; set; }
    }
}