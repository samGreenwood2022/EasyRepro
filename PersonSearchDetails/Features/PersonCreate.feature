Feature: Person Create

Allows the user to create a new Person
The newly created person can then be returned from a person search

@tag1
Scenario Outline: Create a new person by completing mandatory fields only
	Given that i've logged in as an administrator
	When a person is created by completing mandatory fields only <firstname> and <dob> and <dateMovedIn> and <Ethnicity> and <Gender>
	Then new person can be returned in a search <firstname> and <dob> and <lastname>
	Examples: 
	| firstname  | dob        | dateMovedIn | Ethnicity | Gender   |
	| John       | 12/08/1976 | 01/01/2000  | African   | Male     |
	| Alice      | 11/02/1980 | 10/05/2005  | Chinese   | Female   |
