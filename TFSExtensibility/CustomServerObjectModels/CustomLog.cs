using Microsoft.TeamFoundation.Framework.Server;
using Microsoft.TeamFoundation.Common;
using Microsoft.TeamFoundation.VersionControl.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace CustomServerObjectModels
{
    class CustomLog : ISubscriber
    {
        public string Name
        {
            get
            {
                return "Custom Logger";
            }
        }

        public SubscriberPriority Priority
        {
            get
            {
                return SubscriberPriority.Low;
            }
        }

        public EventNotificationStatus ProcessEvent(IVssRequestContext requestContext,
                                                    NotificationType notificationType, object notificationEventArgs,
                                                    out int statusCode, out string statusMessage, out ExceptionPropertyCollection properties)
        {
            statusCode = 0;
            statusMessage = string.Empty;
            properties = null;

            if (notificationType == NotificationType.Notification)
            {
                try
                {
                    if (notificationEventArgs is CheckinNotification)
                    {
                        var notification = notificationEventArgs as CheckinNotification;
                        StringBuilder logMessage = new StringBuilder();
                        logMessage.Append("\n***************************************\r\n");
                        logMessage.Append("New Check-in Done, Change set Details:-\r\n");
                        logMessage.AppendFormat("ChangeSet Id:{0}\r\n", notification.Changeset);
                        logMessage.AppendFormat("ChangeSet Description:{0}\r\n", notification.Comment);
                        logMessage.AppendFormat("Checked-in User:{0}\r\n", notification.ChangesetOwner.DistinctDisplayName);
                        logMessage.AppendFormat("Machine Name:{0}\r\n", notification.ComputerName);
                        logMessage.AppendFormat("Associated Work Items:{0}\r\n", notification.NotificationInfo.WorkItemInfo.Length);
                        StringBuilder workitems = new StringBuilder();
                        if (notification.NotificationInfo.WorkItemInfo.Length > 0)
                            for (int workitemindex = 0; workitemindex < notification.NotificationInfo.WorkItemInfo.Length; workitemindex++)
                            {
                                workitems.AppendFormat("{0},", notification.NotificationInfo.WorkItemInfo[0].Id);
                            }
                        logMessage.Append("\n***************************************");
                        VersionControlLogger.LogToFile(logMessage.ToString());
                    }

                }
                catch (Exception e)
                {
                    TeamFoundationApplicationCore.LogException("logger failed", e);
                }

            }
            return EventNotificationStatus.ActionPermitted;
        }

        public Type[] SubscribedTypes()
        {
            return new[] { typeof(CheckinNotification) };
        }
    }

    class VersionControlLogger
    {
        public static void LogToFile(string logMessage)
        {
            try
            {
                FileStream stream = new FileStream("D:\\TFS_Log.txt", FileMode.OpenOrCreate);
                StreamWriter fileWriter = new StreamWriter(stream);
                fileWriter.WriteLine(logMessage);
                fileWriter.Close();
                stream.Close();
            }
            catch (Exception ex)
            {
                TeamFoundationApplicationCore.LogException("Logging to text file failed", ex);
            }
        }
    }
}
