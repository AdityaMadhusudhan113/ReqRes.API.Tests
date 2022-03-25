using BoDi;
using SmokeTests.Utilities;
using System;
using TechTalk.SpecFlow;

namespace SmokeTests.StepDefinitions
{
    [Binding]
    public class DeleteUserStepDefinitions : BaseStepDefinitions
    {
       
        public DeleteUserStepDefinitions(IObjectContainer objectContainer) : base(objectContainer)
        {
            
        }
      
        /// <summary>
        /// The method sends a delete request for the record with id
        /// </summary>
        /// <param name="Id"></param>
        [When(@"Delete Request is performed for the Id ""([^""]*)""")]
        public void WhenDeleteRequestIsPerformedForTheId(string Id)
        {
            var restUtil = this.objectContainer.Resolve<RestUtil>("RestUtil");
            restUtil.DeleteRequest(Id);
        }


    }
}
