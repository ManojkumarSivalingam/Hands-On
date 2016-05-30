using Microsoft.TeamFoundation.Client;
using Microsoft.TeamFoundation.VersionControl.Client;
using Microsoft.TeamFoundation.WorkItemTracking.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TFSExtensibility
{
    internal static class ClientObjectModel
    {

        public static void DisplayWorkItemsInConsole(TfsTeamProjectCollection teamProjectCollection)
        {
            var wis = teamProjectCollection.GetService<WorkItemStore>();
            WorkItemCollection completeList = wis.Query(
                                                   "Select [State], [Title] " +
                                                   "From WorkItems " +
                                                   "Order By [State] Asc, [Changed Date] Desc");

            Console.WriteLine("Work Items Available in the Server for {0}", teamProjectCollection.DisplayName);
            for (int workitemindex = 0; workitemindex < completeList.Count; workitemindex++)
            {
                Console.WriteLine("Work Item Name :{0}", completeList[workitemindex].Title);
            }
            Console.ReadKey();
        }

        public static void UpdateChangeSetComments(TfsTeamProjectCollection teamProjectCollection, string commentsToAdd)
        {
            var VCS = teamProjectCollection.GetService<VersionControlServer>();
            var ChangesetId = VCS.GetLatestChangesetId();
            var ChangeSet = VCS.GetChangeset(ChangesetId);

            ChangeSet.Comment = commentsToAdd;

            ChangeSet.Update();
        }
    }
}
