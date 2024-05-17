﻿
using Microsoft.AspNetCore.SignalR;

namespace ECommerceAPI.Application.Abstractions.Hubs
{
    public interface IOrderHubService
    {
         Task OrderAddedMessageAsync(string message);
     
    }
}
