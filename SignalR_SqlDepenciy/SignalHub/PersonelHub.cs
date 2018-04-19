using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;

namespace SignalR_SqlDepenciy.SignalHub
{
    public class PersonelHub : Hub
    {
        public static void Show()
        {
            IHubContext context = GlobalHost.ConnectionManager.GetHubContext<PersonelHub>();
            context.Clients.All.tetikle();
        }
    }
}