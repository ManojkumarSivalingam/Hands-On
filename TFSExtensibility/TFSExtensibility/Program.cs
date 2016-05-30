using Microsoft.TeamFoundation.Client;
using Microsoft.TeamFoundation.Framework.Client;
using Microsoft.TeamFoundation.Framework.Common;
using Microsoft.TeamFoundation.VersionControl.Client;
using Microsoft.TeamFoundation.WorkItemTracking.Client;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TFSExtensibility
{
    class Program
    {
        static void Main(string[] args)
        {

            // Connect to Team Foundation Server
            //     Server is the name of the server that is running the application tier for Team Foundation.
            //     Port is the port that Team Foundation uses. The default port is 8080.
            //     VDir is the virtual path to the Team Foundation application. The default path is tfs.
            Uri tfsUri = (args.Length < 1) ?
                new Uri("http://pro-pggm-manoj:8080/tfs") : new Uri(args[0]);

            TfsConfigurationServer configurationServer =
                TfsConfigurationServerFactory.GetConfigurationServer(tfsUri);

            // Get the catalog of team project collections
            ReadOnlyCollection<CatalogNode> collectionNodes = configurationServer.CatalogNode.QueryChildren(
                new[] { CatalogResourceTypes.ProjectCollection },
                false, CatalogQueryOptions.None);

            // Use the InstanceId property to get the team project collection
            Guid collectionId = new Guid(collectionNodes[0].Resource.Properties["InstanceId"]);
            TfsTeamProjectCollection teamProjectCollection = configurationServer.GetTeamProjectCollection(collectionId);

            ClientObjectModel.UpdateChangeSetComments(teamProjectCollection, "Updated Thru Code");

            ClientObjectModel.DisplayWorkItemsInConsole(teamProjectCollection);
        }

    }
}
