using System;
using System.Linq;
using DynamicsValue.AzFunctions;
using functions;
using Xunit;
using Microsoft.PowerPlatform.Dataverse.Client;
using Microsoft.Xrm.Sdk.Query;
using Microsoft.Xrm.Sdk;

namespace MyAzureFunctionTests
{
    public class CreateContactTests : FakeXrmEasyTestsBase
    {
        [Fact]
        public async void Should_create_contact()
        {
            var result = await CreateContactFn.CreateContact(_service, "Joe", "joe@satriani.com");
            Assert.True(result.Succeeded);

            var contacts = _context.CreateQuery("contact").ToList();
            Assert.Single(contacts);

            Assert.Equal("Joe", contacts[0]["firstname"]);
            Assert.Equal("joe@satriani.com", contacts[0]["emailaddress1"]);


            var testID = await new CreateContactBG().CreateContactWithID();
            Console.WriteLine("Test BG");
        }
        /*

        [Fact]
        public async void Should_create_contact()
        {
            var result = await CreateContactFn.CreateContact(_service, "Joe", "joe@satriani.com");
            Assert.True(result.Succeeded);
            
            var contacts = _context.CreateQuery("contact").ToList(); 
            Assert.Single(contacts);

            Assert.Equal("Joe", contacts[0]["firstname"]);
            Assert.Equal("joe@satriani.com", contacts[0]["emailaddress1"]);
        }
        */
    }

    public class ClientServiceAdapter : Microsoft.PowerPlatform.Dataverse.Client.ServiceClient
    {
        private readonly IOrganizationService _organizationService;

        public ClientServiceAdapter(IOrganizationService organizationService)
            : base() // Call base if required
        {
            _organizationService = organizationService;
        }

        public override Guid Create(Entity entity) => _organizationService.Create(entity);

        public override Entity Retrieve(string entityName, Guid id, ColumnSet columnSet) =>
            _organizationService.Retrieve(entityName, id, columnSet);

        // Similarly adapt other methods
    }

}
