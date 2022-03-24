Feature: Login

Scenario: Valid Login
	Given API is "/api/login"
	And The Login User data is
             | Field    | value              |
             | email    | eve.holt@reqres.in |
             | password | cityslicka         |
	When Post Request is performed
	Then Response code is 200
	And Response contains a token

Scenario: Invalid Login wrong user
	Given API is "/api/login"
	And The Login User data is
             | Field    | value              |
             | email    | eve.holt@reqres.au |
             | password | cityslicka         |   
	When Post Request is performed 
	Then Response code is 400

Scenario: Invalid Login no user
	Given API is "/api/login"
	And The Login User data is
             | Field    | value              |
             | password | cityslicka         |   
	When Post Request is performed 
	Then Response code is 400

Scenario: Invalid Login no password
	Given API is "/api/login"
	And The Login User data is
             | Field    | value              |
             | email    | eve.holt@reqres.in |  
	When Post Request is performed 
	Then Response code is 400