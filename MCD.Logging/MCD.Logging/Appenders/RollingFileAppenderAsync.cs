using log4net.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace MCD.Logging.Appenders
{
    public class RollingFileAppenderAsync : log4net.Appender.RollingFileAppender
    {
        protected override void Append(LoggingEvent loggingEvent)
        {
            // System.Threading.Tasks.Task.Run(() => {
                base.Append(loggingEvent);
            // });
        }
    }
}
