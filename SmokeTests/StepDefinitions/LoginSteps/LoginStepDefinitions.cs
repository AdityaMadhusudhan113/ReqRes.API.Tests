using Newtonsoft.Json;
using NUnit.Framework;
using SmokeTests.Data.User;
using SmokeTests.Utilities;
using System;
using TechTalk.SpecFlow;
using BoDi;
using TechTalk.SpecFlow.Assist;

namespace SmokeTests.StepDefinitions 
{
    [Binding]
    public class LoginStepDefinitions :BaseStepDefinitions
    {
        
        public LoginStepDefinitions(IObjectContainer objectContainer) : base(objectContainer)
        {
            
        }

        /// <summary>
        /// The method instantiates the requestbody with the table data defined as login user
        /// </summary>
        /// <param name="table"></param>
        [Given(@"The Login User data is")]
        public void GivenTheLoginDataIs(Table table)
        {
            var restUtil = this.objectContainer.Resolve<RestUtil>("RestUtil");
            var user = table.CreateInstance<LoginUser>();
            restUtil.requestBody =user;
        }

        /// <summary>
        /// The method validates the token is present in response
        /// </summary>
        [Then(@"Response contains a token")]
        public void ThenResponseContainsAToken()
        {
            var restUtil = this.objectContainer.Resolve<RestUtil>("RestUtil");
            Assert.IsTrue(restUtil.response.Content.Contains("token"), "Response content contains token");
        }
    }
}
