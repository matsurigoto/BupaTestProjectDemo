using BupaWebAPI.Clients;
using BupaWebAPI.Messages;
using NUnit.Framework;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace BupaIntegrationTest.Steps
{
    [Binding, Scope(Tag = "MemberServices")]
    public class MemberServicesSteps
    {
        private CreateMemberRequest request = new CreateMemberRequest();
        private CreateMemberResponse response = new CreateMemberResponse();
        private MemberApiClient client;

        [Given(@"Set Id:""(.*)"" and Name:""(.*)""")]
        public void GivenIdandName(Guid id, string name)
        {
            request.Id = id;
            request.Name = name;
        }

        [When(@"I create Member")]
        public async Task WhenIPressAdd()
        {
            var httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri("https://pfeapim.azure-api.net/");
            client = new MemberApiClient(httpClient);
            response = await client.CreateMemberAsync(request);
        }

        [Then(@"I receive successful response and Id:""(.*)""")]
        public void ThenTheResultShouldBe(Guid result)
        {
            Assert.AreEqual(response.Id, result);
        }
    }
}
