using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Microsoft.PowerPlatform.Dataverse.Client;
using System.Runtime.CompilerServices;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Messages;
using DataverseEntities;
using System;

namespace functions
{
    internal class CreateContactBG
    {
        public Guid CreateContactWithID(ServiceClient client)
            //public Guid CreateContactWithID(IOrganizationService client)
        {
            //var dataverseUrl = System.Environment.GetEnvironmentVariable("DataverseUrl");
            //var clientId = System.Environment.GetEnvironmentVariable("ClientId");
            //var clientSecret = System.Environment.GetEnvironmentVariable("ClientSecret");

            //var client = new ServiceClient(new System.Uri(dataverseUrl), clientId, clientSecret, false);

            var contactRow = new Entity("contact", new Guid("79baf271-1ad9-4e30-a20e-070e694db3eb"));

            return client.Create(contactRow);
            //return contactRow.Id;
        }
    }
}
