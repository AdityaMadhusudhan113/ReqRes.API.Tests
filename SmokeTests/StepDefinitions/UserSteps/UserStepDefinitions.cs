using BoDi;
using Newtonsoft.Json;
using NUnit.Framework;
using SmokeTests.Data.User;
using SmokeTests.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow.Assist;

namespace SmokeTests.StepDefinitions
{
    [Binding]
    public  class UserStepDefinitions :BaseStepDefinitions
    {
      
        public UserStepDefinitions(IObjectContainer objectContainer) : base(objectContainer)
        {
           
        }

        /// <summary>
        /// The method validates the response with the user details
        /// </summary>
        /// <param name="table"></param>
        [Then(@"Response contains the valid user details")]
        public void ThenResponseContainsTheValidUserDetails(Table table)
        {
            var dictionary = table.CreateInstance<UserAttribute>();
            var restUtil = this.objectContainer.Resolve<RestUtil>("RestUtil");
            var responseContent = JsonConvert.DeserializeObject<User>(restUtil.response.Content);
            var users = responseContent.Data;

            Console.WriteLine("User Fname: " + users.First_Name);
            Assert.AreEqual(dictionary.First_Name, users.First_Name, "User Fname different : Expected : " + dictionary.First_Name + " Actual :" + users.First_Name);

            Console.WriteLine("User Lname: " + users.Last_Name);
            Assert.AreEqual(dictionary.Last_Name, users.Last_Name, "User LastName different : Expected : " + dictionary.Last_Name+ " Actual :" + users.Last_Name);

            Console.WriteLine("User Email: " + users.Email);
            Assert.AreEqual(dictionary.Email, users.Email, "User Email different : Expected : " + dictionary.Email + " Actual :" + users.Email);

            Console.WriteLine("User Avatar: " + users.Avatar);
            Assert.AreEqual(dictionary.Avatar, users.Avatar.ToString(), "User Email different : Expected : " + dictionary.Avatar + " Actual :" + users.Avatar);

        }

       
        /// <summary>
        /// The method validates the response for "First name and last name"
        /// </summary>
        /// <param name="table"></param>
        [Then(@"Response has the data")]
        public void ThenResponseHasTheData(Table table)
        {
            Boolean recordFound = false;

            var dictionary = table.CreateInstance<UserAttribute>();
            var restUtil = this.objectContainer.Resolve<RestUtil>("RestUtil");
            UserList responseContent = JsonConvert.DeserializeObject<UserList>(restUtil.response.Content);
            var users = responseContent.Data;
            foreach (var user in users)
            {
                if (user.First_Name.Equals(dictionary.First_Name) && user.Last_Name.Equals(dictionary.Last_Name))
                    recordFound = true;
            }

            Assert.IsTrue(recordFound, dictionary.First_Name+ " " + dictionary.Last_Name + " Not Found");
        }

    }
}
