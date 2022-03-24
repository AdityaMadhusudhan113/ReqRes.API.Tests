using BoDi;
using SmokeTests.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmokeTests.StepDefinitions
{
    public abstract class BaseStepDefinitions
    {
      
        protected IObjectContainer objectContainer;

        protected BaseStepDefinitions(IObjectContainer objectContainer)
        {
            this.objectContainer = objectContainer;
        }

       
    }
}
