Feature: PC0003 - Person create - audit events

Regression Pack Scenario - PC0003
This test will ensure that the correct audit events have 
been created when a new person is created

@smokeTest
Scenario: To verify that a newly created person has the correct Audit logs created against them
	Given that a childrens support worker has logged in
	When a person is created by completing mandatory fields only <firstname> and <dob> and <dateMovedIn> and <Ethnicity> and <Gender> and <preferredLanguage>
	Then the expected audit events would be created
	Examples: 
	| firstname | dob        | dateMovedIn | Ethnicity						| Gender | preferredLanguage |
	| John      | 12/08/1976 | 01/01/2000  | African						| Male   | Armenian          |
	| Alice     | 11/02/1980 | 10/05/2005  | Any Other Black Background		| Female | Aragonese         |

