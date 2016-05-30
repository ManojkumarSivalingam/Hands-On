using Microsoft.TeamFoundation.Common;
using Microsoft.TeamFoundation.Framework.Server;
using Microsoft.TeamFoundation.VersionControl.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomServerObjectModels
{
    class CheckinValidator:ISubscriber
    {
        public string Name
        {
            get
            {
                return "Check-In  validator";
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

            if (notificationType == NotificationType.DecisionPoint)
            {
                try
                {
                    if (notificationEventArgs is CheckinNotification)
                    {
                        var notification = notificationEventArgs as CheckinNotification;
                        bool IsCheckInValid = true;
                        if(String.IsNullOrEmpty(notification.Comment))
                        {
                            statusMessage = " Check in Comments Cannot Be empty";
                            IsCheckInValid = IsCheckInValid && false;
                        }
                        if (notification.NotificationInfo.WorkItemInfo.Length<=0)
                        {
                            statusMessage = "Associate Change set With a Work Item To Check In";
                            IsCheckInValid = IsCheckInValid && false;
                        }
                        if(!IsCheckInValid)
                        return EventNotificationStatus.ActionDenied;
                    }

                }
                catch (Exception e)
                {
                    TeamFoundationApplicationCore.LogException("Check In Validation failed", e);
                }

            }
            return EventNotificationStatus.ActionPermitted;
        }

        public Type[] SubscribedTypes()
        {
            return new[] { typeof(CheckinNotification) };
        }
    }
}
