﻿using InsuraNex.Enums;

namespace InsuraNex.Models.ViewModels
{
    public class Notification
    {
        public string Message { get; set; }

        public NotificationType Type { get; set; }
    }
}
