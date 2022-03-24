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
        [When(@"Delete Request is performed for the details")]
        public void WhenDeleteRequestIsPerformedForTheDetails(Table table)
        {
            var restUtil = this.objectContainer.Resolve<RestUtil>("RestUtil");
            var Id = table.Rows[0]["Id"];
            restUtil.GetRequest(Id);
        }

        
    }
}
