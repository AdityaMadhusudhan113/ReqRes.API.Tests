using Newtonsoft.Json;
using NUnit.Framework;
using SmokeTests.Config;
using SmokeTests.Data.Color;
using SmokeTests.Data.User;
using SmokeTests.Utilities;
using System;
using TechTalk.SpecFlow;
using BoDi;

namespace SmokeTests.StepDefinitions
{
    [Binding]
    public class GetStepDefinitions :BaseStepDefinitions
    {

        
        public GetStepDefinitions(IObjectContainer objectContainer) : base(objectContainer)
        {
            
        }
        [When(@"Get Request is Performed")]
        public void WhenGetRequestPerformed()
        {
            var restUtil = this.objectContainer.Resolve<RestUtil>("RestUtil");
            restUtil.GetRequest();
        }

        [Then(@"Response has ""([^""]*)"" records")]
        public void ThenResponseHasRecords(string NumberOfUsers)
        {
            var restUtil = this.objectContainer.Resolve<RestUtil>("RestUtil");
            UserList responseContent = JsonConvert.DeserializeObject<UserList>(restUtil.response.Content);
            var users = responseContent.Data;
            Console.WriteLine("Number of Records : " + users.Count);
            Assert.AreEqual(Convert.ToInt32(NumberOfUsers), users.Count, "Number of Records are not as expected : " + NumberOfUsers);

        }

        [When(@"Get Request is performed for the details")]
        public void WhenGetRequestIsPerformedForTheDetails(Table table)
        {
            var restUtil = this.objectContainer.Resolve<RestUtil>("RestUtil");
            var Id = table.Rows[0]["Id"];
            restUtil.GetRequest(Id);
        }
    }
}
