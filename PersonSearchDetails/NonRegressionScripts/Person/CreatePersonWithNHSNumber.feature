Feature: Create new person with an NHS Number

A script to create a new person with a valid NHS Number

@tag1
Scenario: Create new person with an NHS Number
	Given that i've logged in as an administrator
	When i've created a new person with an NHS Number
	#Then the NHS Number will be in the correct format
