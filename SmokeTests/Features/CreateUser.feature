Feature: Post

Scenario: Create new user
	Given API is "/api/users"
	And The user data is
	| Field | value       |
	| name  | John Watson |
	| job   | engineer    |
	When Post Request is performed
	Then The user is created
	And Response code is 201
