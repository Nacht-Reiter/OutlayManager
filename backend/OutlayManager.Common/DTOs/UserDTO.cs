using System;

namespace OutlayManager.Common.DTOs
{
    public class UserDTO
    {
        int Id { get; set; }
        String UId { get; set; }
        String FullName { get; set; }

        public AccountDTO Account { get; set; }

    }
}