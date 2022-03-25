using Newtonsoft.Json;
using SmokeTests.Utilities;
using System;
using TechTalk.SpecFlow;
using BoDi;
using SmokeTests.Data.User;

namespace SmokeTests.StepDefinitions
{
    [Binding]
    public class UpdateUserStepDefinitions : BaseStepDefinitions
    {
        
        public UpdateUserStepDefinitions(IObjectContainer objectContainer) : base(objectContainer)
        {
            
        }
        
        /// <summary>
        /// The method instantiates the createduser object with the id sent in feature file
        /// </summary>
        /// <param name="Id"></param>
        [When(@"The user data to be updated has Id ""([^""]*)""")]
        public void WhenTheUserDataToBeUpdatedHasId(string Id)
        {
            CreatedUser user = new CreatedUser();
            user.Id = long.Parse(Id);
            objectContainer.RegisterInstanceAs<CreatedUser>(user, "Id");
            
        }

        /// <summary>
        /// The method sends the user details in the put request
        /// </summary>
        /// <param name="table"></param>
        [When(@"The user data to be updated is")]
        public void WhenTheUserDataToBeUpdatedIs(Table table)
        {
            var restUtil = this.objectContainer.Resolve<RestUtil>("RestUtil");
            var user = objectContainer.Resolve<CreatedUser>("Id");
         
            restUtil.PutRequest(user.Id.ToString(), table);
        }

      
    }
}
