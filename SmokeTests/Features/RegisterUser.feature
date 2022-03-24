Feature: RegisterUser

Scenario: Valid Register
	Given API is "/api/register"
    And   The Login User data is
             | Field    | value              |
             | email    | eve.holt@reqres.in |
             | password | abcd         | 
    When Post Request is performed
	Then Response code is 200
	And Response contains a token

Scenario: Invalid Register user not defined
	Given API is "/api/register"
    And   The Login User data is
             | Field    | value              |
             | email    | adi.holt@reqres.in |
             | password | abcd         | 
    When Post Request is performed
	Then Response code is 400

Scenario: Invalid Register user not sent
	Given API is "/api/register"
    And   The Login User data is
             | Field    | value              |
             
             | password | abcd         | 
    When Post Request is performed
	Then Response code is 400

Scenario: Invalid Register password not sent
	Given API is "/api/register"
    And   The Login User data is
             | Field    | value              |
             | email    | eve.holt@reqres.in |
    When Post Request is performed
	Then Response code is 400