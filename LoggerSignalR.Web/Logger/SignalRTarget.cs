using Microsoft.AspNet.SignalR;
using NLog;
using NLog.Targets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LoggerSignalR.Web.Logger
{
    [Target("SignalR")]
    public class SignalRTarget:TargetWithLayout
    {
        protected override void Write(LogEventInfo logEvent)
        {
            var hubContext = GlobalHost.ConnectionManager.GetHubContext<LoggerHub>();

            if (hubContext != null)
                hubContext.Clients.All.write(Layout.Render(logEvent));
        }
    }
}