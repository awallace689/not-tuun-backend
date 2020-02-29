﻿using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace tuuncs.Hubs
{
    public class RoomsHub : Hub
    {
        //
        // Summary:
        //     Called when a new connection is established with the hub.
        public async override Task OnConnectedAsync()
        {
            await Clients.Caller.SendAsync("YouConnected", Context.ConnectionId);
            await Clients.All.SendAsync("NewConnection", Context.ConnectionId);
        }
        //
        // Summary:
        //     Called when a connection with the hub is terminated.
        public async override Task OnDisconnectedAsync(Exception exception)
        {
            await Clients.All.SendAsync("EndConnection", Context.ConnectionId);
        }
    }
}
