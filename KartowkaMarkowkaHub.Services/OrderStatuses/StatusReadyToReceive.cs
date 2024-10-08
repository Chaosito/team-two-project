﻿using KartowkaMarkowkaHub.Core.Domain;
using System.Security.Principal;

namespace KartowkaMarkowkaHub.Services.OrderStatuses
{
    public class StatusReadyToReceive : IOrderStatus
    {
        public StatusType StatusType => StatusType.ReadyToReceive;

        public void Handle(IOrderStatusService orderStatusService)
        {
            throw new NotImplementedException();
        }

        public void NextStatus(IOrderStatusService orderStatusService)
        {
            if (true)
            {
                orderStatusService.Status = new StatusCompleted();
            }
        }
    }
}