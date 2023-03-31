Feature: PER0006 - Person amend

Regression Pack Scenario - PER0006
Ensure that a persons core demographic details can be amended by 
using the post code lookup to amend the primary address

@tag1
Scenario Outline: verify that an existing person can have their primary address details successfully amended
	Given that i've logged in as an administrator
	And a known person already exists in the system <firstname> and <dob> and <dateMovedIn> and <ethnicity> and <gender> and <preferredLanguage>
	When i amend a persons primary address details <propertyNo> and <street> and <townCity> and <county> and <postcode>
	Then Then the new address will replace the old address on the persons record <firstname> and <dob>
	Examples: 
	| firstname | dob        | dateMovedIn | ethnicity | gender | propertyNo | street     | townCity | county          | postcode | preferredLanguage |
	| John      | 12/08/1976 | 01/01/2000  | African   | Male   | 36         | May Avenue | BLAYDON  | BLAYDON-ON-TYNE | ne21 6sf | English           |

