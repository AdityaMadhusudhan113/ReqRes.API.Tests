using Newtonsoft.Json;
using NUnit.Framework;
using SmokeTests.Data.User;
using SmokeTests.Utilities;

using TechTalk.SpecFlow;
using BoDi;

namespace SmokeTests.StepDefinitions
{
    [Binding]
    public class PostStepDefinitions  : BaseStepDefinitions
    {
   
        public PostStepDefinitions(IObjectContainer objectContainer) : base(objectContainer)
        {
          
        }
        protected string requestUrl = "";


        [Given(@"The user data is")]
        public void GivenTheUserDataIs(Table table)
        {
            var restUtil = this.objectContainer.Resolve<RestUtil>("RestUtil");
            restUtil.requestBody = table;
        }


        [Then(@"The user is created")]
        public void ThenTheUserIsCreated()
        {
            var restUtil = this.objectContainer.Resolve<RestUtil>("RestUtil");
            var CreatedUser= JsonConvert.DeserializeObject<CreatedUserResponse>(restUtil.response.Content);
            Console.WriteLine("Created User Id : "+ CreatedUser.Id);
            Assert.AreNotEqual(CreatedUser.Id, 0,"User not created");
            Console.WriteLine("Created User Created Date : " + CreatedUser.CreatedAt);
            Assert.AreEqual(CreatedUser.CreatedAt.Date, DateTime.Now.Date, "User not created on : "+ CreatedUser.CreatedAt.Date);

        }

       
    }
}
