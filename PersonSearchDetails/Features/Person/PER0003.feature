Feature: PER0003 - Person Search - personId

Regression Pack Scenario - PER0001
To ensure a person search can be performed using a personId
ensure the returned record is correct


@smokeTest
Scenario: A person search using person id
	Given that i've logged in as an administrator
	When i perform a person search using a person id '4073889'
	Then the returned record will show the correct name, id, dob & address