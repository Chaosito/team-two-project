﻿using KartowkaMarkowkaHub.Core.Domain;

namespace KartowkaMarkowkaHub.Services.OrderStatuses
{
    public class StatusCompleted : IOrderStatus
    {
        public StatusType StatusType => StatusType.Completed;
        public void Handle(IOrderStatusService orderStatusService)
        {
            throw new NotImplementedException();
        }

        public void NextStatus(IOrderStatusService orderStatusService)
        {
            throw new NotImplementedException();
        }
    }
}