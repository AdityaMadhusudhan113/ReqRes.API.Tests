## Description
An Automation Framework which can test all the methods provided in https://reqres.in/

**Verify that Lindsay Ferguson is a user by querying “List Users”. **
This quesntion is answered in GetUser.feature
## Tools used
-C#
-Specflow
-RestSharp
-Nunit
## Setup
- The above mentioned URl is present in a json file  config.json at the root of the project folder. 
For example:{ "BASE_URL":"http://localhost:8080" }
- The feature files contain data table which can be easily modified

## Future improvements
- Data sourced externally data source such as csv, excel etc. 
- Adding reports like extent report etc.
- Can add more negative scenarios
- Database verification 

# Ted Cinemas Test cases 
- These cases are added in an excel sheet in the solution folder

**For Third Party Payment Service Agreement**: 
The responses exepected from the third party payment can be passed in Stubs. 
The stubs would then simulate the responses and we will be able to test the payment. 

