Feature: Get Color

Scenario: Get All Colors
	Given API is "/api/unknown"
	When Get Request is Performed
	Then Response has "6" records
	And Response code is 200


Scenario: Get Single Color
	Given API is "/api/unknown/"
	When Get Request is performed for the details 
		| Id |
		| 2  |
	Then Response code is 200
	And Response contains the valid color details
	| Name         | Year      | Code       | Pantone_Value |
	| fuchsia rose | 2001      | #C74375    | 17-2031       |

Scenario: Get Single Colour Not Found

	Given API is "/api/unknown/"
	When Get Request is performed for the details
		| Id |
		| 23 |
	Then Response code is 404

