Feature: GetUser

A short summary of the feature

Scenario: Get All Users
	Given API is "/api/users?page=2"
	When Get Request is Performed
	Then Response has "6" records
	And Response code is 200

#Scenario for the question : Verify that Lindsay Ferguson is a user by querying “List Users”. How do  you design your framework so that we can query for another user with minimal changes to the framework. 
Scenario: Get User Verify Name
	Given API is "/api/users?page=2"
	When Get Request is Performed
	Then Response has "6" records
	And Response has the data
	| Field      | Value    |
	| First_Name | Lindsay  |
	| Last_Name  | Ferguson |

Scenario: Get Single User
	Given API is "/api/users/"
	When Get Request is performed for the details
		| Id |
		| 2  |
	Then Response code is 200
	And Response contains the valid user details
	| Field      | Value                                   |
	| Email      | janet.weaver@reqres.in                  |
	| First_Name | Janet                                   |
	| Last_Name  | Weaver                                  |
	| Avatar     | https://reqres.in/img/faces/2-image.jpg |
	

Scenario: Get Single User Not Found

	Given API is "/api/users/"
	When Get Request is performed for the details
		| Id |
		| 23 |
	Then Response code is 404