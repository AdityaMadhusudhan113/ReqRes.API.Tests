Feature: UpdateUser

Scenario: Update user
	Given API is "/api/users"
	When The user data to be updated has Id "18"
	And The user data to be updated is
	| name      | job    |
	| Norman Bates| Techie |
	Then Response code is 200
