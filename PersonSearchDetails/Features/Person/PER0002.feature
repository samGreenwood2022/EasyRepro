Feature: PER0002 - Person Search - wildcards

Regression Pack Scenario - PER0002
To ensure a person search can be performed when using wildcards
ensure the returned record is correct


@smokeTest
Scenario: A person search using wildcards
	Given that i've logged in as an administrator
	When i perform a person search using a wildcards 'B*', 'T*' & dob '12/08/1976'
	Then the returned record will show the correct name, id, dob & address