Feature: Person Search - personId
To ensure a person search can be performed using a personId
ensure the returned record is correct


@smokeTest
Scenario: A person search using person id
	Given that i login with a username & password
	When i perform a person search using a person id '4073889'
	Then the returned record will show the correct name, id, dob & address