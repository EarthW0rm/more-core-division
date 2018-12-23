using System;
using System.Collections.Generic;
using System.Text;
using log4net.Core;

namespace MCD.Logging.Appenders
{
    public class ConsoleAppenderAsync : log4net.Appender.ConsoleAppender
    {
        protected override void Append(LoggingEvent loggingEvent)
        {
            //System.Threading.Tasks.Task.Run(() => {
                base.Append(loggingEvent);
            //});
        }
    }
}
