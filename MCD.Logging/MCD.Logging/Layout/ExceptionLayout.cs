using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using log4net.Core;

namespace MCD.Logging.Layout
{
    public class ExceptionLayout : log4net.Layout.LayoutSkeleton
    {
        public override void ActivateOptions()
        {
        }

        public override void Format(TextWriter writer, LoggingEvent loggingEvent)
        {
            if (loggingEvent.ExceptionObject != null) {
                writer.WriteLine(loggingEvent.ExceptionObject.Message);
                writer.WriteLine(loggingEvent.ExceptionObject.Source);

                foreach (var itemKey in loggingEvent.ExceptionObject.Data.Keys) {
                    writer.WriteLine($"Data {itemKey}:{loggingEvent.ExceptionObject.Data[itemKey]}");
                }

                writer.WriteLine(loggingEvent.ExceptionObject.StackTrace);
                if (loggingEvent.ExceptionObject.InnerException != null) {
                    writer.WriteLine(loggingEvent.ExceptionObject.InnerException.StackTrace);
                }
            }
        }
    }
}
