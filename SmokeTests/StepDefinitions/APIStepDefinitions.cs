using BoDi;
using Newtonsoft.Json;
using NUnit.Framework;
using RestSharp;
using SmokeTests.Config;
using SmokeTests.Data.User;
using SmokeTests.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmokeTests.StepDefinitions
{
    [Binding]
    public class APIStepDefinitions :BaseStepDefinitions
    {
        
        public APIStepDefinitions(IObjectContainer objectContainer) : base(objectContainer)
        {
           
        }
        [Given(@"API is ""(.*)""")]
        public void GivenAPIIs(string Url)
        {
            var config = objectContainer.Resolve<EnvConfig>();
            RestUtil restUtil = new RestUtil();
            var client=restUtil.SetUrl (config.BASE_URL, Url);
            objectContainer.RegisterInstanceAs<RestClient>(client, "RestClient");
            objectContainer.RegisterInstanceAs<RestUtil>(restUtil, "RestUtil");
        }

        [Then(@"Response code is (.*)")]
        public void ThenResponseCodeIs(int code)
        {
            var restUtil= this.objectContainer.Resolve<RestUtil>("RestUtil");
            
            switch (code)
            {
                case 200: Assert.AreEqual(System.Net.HttpStatusCode.OK, restUtil.response.StatusCode, "Request Failed " + restUtil.response.StatusCode); return;
                case 404: Assert.AreEqual(System.Net.HttpStatusCode.NotFound, restUtil.response.StatusCode, "Request Passed " + restUtil.response.StatusCode); return;
                case 201: Assert.AreEqual(System.Net.HttpStatusCode.Created, restUtil.response.StatusCode, "Request Failed " + restUtil.response.StatusCode); return;
            }
        }

        [Then(@"Response is Empty")]
        public void ThenResponseIsEmpty()
        {
            var restUtil = this.objectContainer.Resolve<RestUtil>("RestUtil");
            Assert.IsTrue((restUtil.response.Content.Equals("{}") ||  String.IsNullOrEmpty(restUtil.response.Content)), "Response content is not empty");
        }

        [When(@"Post Request is performed")]
        public void WhenPostRequestIsPerformed()
        {
            var restUtil = this.objectContainer.Resolve<RestUtil>("RestUtil");
            restUtil.PostRequest();
        }

        [When(@"Get Request is Performed")]
        public void WhenGetRequestPerformed()
        {
        
            var restUtil = this.objectContainer.Resolve<RestUtil>("RestUtil");
            var user =objectContainer.Resolve<CreatedUser>( "Id");
            if(user.Id == 0)
            restUtil.GetRequest();
            else
            restUtil.GetRequest(user.Id.ToString());
        }

        [Given(@"Record Id is ""([^""]*)""")]
        public void GivenRecordIdIs(string Id)
        {
            CreatedUser user = new CreatedUser();
            user.Id = long.Parse(Id);
            objectContainer.RegisterInstanceAs<CreatedUser>(user, "Id");
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


    }
}
