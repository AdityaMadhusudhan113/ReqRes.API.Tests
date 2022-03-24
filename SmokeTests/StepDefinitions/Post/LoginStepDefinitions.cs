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

        [Given(@"The Login User data is")]
        public void GivenTheLoginDataIs(Table table)
        {
            var restUtil = this.objectContainer.Resolve<RestUtil>("RestUtil");
            var user = table.CreateInstance<LoginUser>();
            restUtil.requestBody =user;
        }
        [Then(@"Response contains a token")]
        public void ThenResponseContainsAToken()
        {
            var restUtil = this.objectContainer.Resolve<RestUtil>("RestUtil");
            Assert.IsTrue(restUtil.response.Content.Contains("token"), "Response content contains token");
        }
    }
}
