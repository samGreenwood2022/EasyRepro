Feature: PS0002 - Person Search - wildcards

Regression Pack Scenario - PS0002
To ensure a person search can be performed when using wildcards
ensure the returned record is correct


@smokeTest
Scenario: A person search using wildcards
	Given that a childrens support worker has logged in
	When i perform a person search using a wildcards 'J*', 'Z*' & dob '12/08/1976'
	Then the returned record will show the correct name, id, dob & address