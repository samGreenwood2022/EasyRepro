Feature: PS0003 - Person Search - personId

Regression Pack Scenario - PER0003
To ensure a person search can be performed using a personId
ensure the returned record is correct


@smokeTest
Scenario: A person search using person id
	Given that an adult support worker has logged in
	When i perform a person search using a person id '4074401'
	Then the returned record will show the correct name, id, dob & address