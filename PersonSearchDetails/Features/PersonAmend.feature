Feature: Person amend

Ensure that a persons core demographic details can be amended by 
using the post code lookup to amend the primary address

@tag1
Scenario Outline: To verify that an existing person can have their primary address details successfully amended
	Given that i've logged in as an administrator
	And a known person already exists in the system <firstname> and <dob> and <dateMovedIn> and <ethnicity> and <gender>
	When i amend a persons primary address details <propertyNo> and <street> and <townCity> and <county> and <postcode>
	Then Then the new address will replace the old address on the persons record <firstname> and <dob>
	Examples: 
	| firstname | dob        | dateMovedIn | ethnicity | gender | propertyNo | street     | townCity | county          | postcode |
	| John      | 12/08/1976 | 01/01/2000  | African   | Male   | 36         | May Avenue | BLAYDON  | BLAYDON-ON-TYNE | ne21 6sf |

