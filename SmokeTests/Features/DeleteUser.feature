Feature: DeleteUser

Scenario: Delete user
	Given API is "/api/users/"
	When Delete Request is performed for the Id "23"
	Then Response code is 204
	And Response is Empty
