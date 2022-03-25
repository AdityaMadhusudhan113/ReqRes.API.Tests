using BoDi;
using Newtonsoft.Json;
using NUnit.Framework;
using RestSharp;
using SmokeTests.Data.Color;
using SmokeTests.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmokeTests.StepDefinitions
{
    [Binding]
    public class ColorStepDefinition : BaseStepDefinitions
    {
       
        public ColorStepDefinition(IObjectContainer objectContainer) : base(objectContainer)
        {
            
        }
        /// <summary>
        /// The method validates the response based on the expected color data passed in the feature file
        /// </summary>
        /// <param name="table"></param>
        [Then(@"Response contains the valid color details")]
        public void ThenResponseContainsTheValidColorDetails(Table table)
        {
            var dictionary = table.Rows[0];

            var restUtil = this.objectContainer.Resolve<RestUtil>("RestUtil");
            var responseContent = JsonConvert.DeserializeObject<Color>(restUtil.response.Content);
            var color = responseContent.Data;

            Console.WriteLine("color Name: " + color.Name);
            Assert.AreEqual(dictionary["Name"], color.Name, "Color Name different : Expected : " + dictionary["Name"] + " Actual :" + color.Name);
            Console.WriteLine("color year: " + color.Year);
            Assert.AreEqual(dictionary["Year"], color.Year.ToString(), "Color Year different : Expected : " + dictionary["Year"] + " Actual :" + color.Year);
            Console.WriteLine("color code: " + color.Color);
            Assert.AreEqual(dictionary["Code"], color.Color, "Color Code different : Expected : " + dictionary["Code"] + " Actual :" + color.Color);
            Console.WriteLine("color pantone value: " + color.Pantone_Value);
            Assert.AreEqual(dictionary["Pantone_Value"], color.Pantone_Value.ToString(), "Color pantone value different : Expected : " + dictionary["Pantone_Value"] + " Actual :" + color.Pantone_Value);

        }
    }
}
