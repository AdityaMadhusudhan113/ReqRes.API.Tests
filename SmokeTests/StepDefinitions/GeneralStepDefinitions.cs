using BoDi;
using NUnit.Framework;
using RestSharp;
using SmokeTests.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmokeTests.StepDefinitions
{
    [Binding]
    public class GeneralStepDefinitions :BaseStepDefinitions
    {
        
        public GeneralStepDefinitions(IObjectContainer objectContainer) : base(objectContainer)
        {
           
        }
        [Given(@"API is ""(.*)""")]
        public void GivenAPIIs(string Url)
        {
            var config = objectContainer.Resolve<Config.Settings>();
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
            Assert.AreEqual(restUtil.response.Content,"{}", "Response content is not empty");
        }

        [When(@"Post Request is performed")]
        public void WhenPostRequestIsPerformed()
        {
            var restUtil = this.objectContainer.Resolve<RestUtil>("RestUtil");
            restUtil.PostRequest();
        }

    }
}
