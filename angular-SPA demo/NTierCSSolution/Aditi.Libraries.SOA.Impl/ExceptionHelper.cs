using Aditi.Libraries.SOA.Contracts.Faults;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Aditi.Libraries.SOA.Impl
{
    public static class ExceptionHelper
    {
        public static FaultException<ServiceError> Transform(
            this Exception exceptionObject, int errorId = default(int))
        {
            return new FaultException<ServiceError>(
                new ServiceError
                {
                    ErrorId = errorId,
                    ErrorMessage = exceptionObject.Message,
                    Source = exceptionObject.Source
                },
                new FaultReason( exceptionObject.Message ) );
        }

        public static void Log(this Exception exceptionObject)
        {
            var formattedMessage = string.Format( @"{0} : {1} : {2}",
                DateTime.Now.ToString(), Environment.MachineName, exceptionObject.Message );

            EventLog.WriteEntry( "Application", formattedMessage, EventLogEntryType.Error );
        }
    }
}
