using Newtonsoft.Json;
using SmokeTests.Utilities;
using System;
using TechTalk.SpecFlow;
using BoDi;

namespace SmokeTests.StepDefinitions
{
    [Binding]
    public class UpdateUserStepDefinitions : BaseStepDefinitions
    {
        
        public UpdateUserStepDefinitions(IObjectContainer objectContainer) : base(objectContainer)
        {
            
        }
        string Id="";

        [When(@"The user data to be updated has")]
        public void WhenTheUserDataToBeUpdatedHas(Table table)
        {
            Id = table.Rows[0]["Id"];
           
        }

        [When(@"The user data to be updated is")]
        public void WhenTheUserDataToBeUpdatedIs(Table table)
        {
            var restUtil = this.objectContainer.Resolve<RestUtil>("RestUtil");
            restUtil.PutRequest(Id,table);
        }

      
    }
}
