Feature: PER0004 - Person Create

Regression Pack Scenario - PER0004
Allows the user to create a new Person using mandatory fields only
The newly created person can then be returned from a person search

@tag1
Scenario Outline: Ensure a new person can be created by completing mandatory fields only
	Given that an adult support worker has logged in
	When a person is created by completing mandatory fields only <firstname> and <dob> and <dateMovedIn> and <Ethnicity> and <Gender> and <preferredLanguage>
	Then new person can be returned in a search <firstname> and <dob>
	Examples: 
	| firstname | dob        | dateMovedIn | Ethnicity | Gender | preferredLanguage |
	| John      | 12/08/1976 | 01/01/2000  | African   | Male   | Welsh             |
	| Alice     | 11/02/1980 | 10/05/2005  | Chinese   | Female | English           |
