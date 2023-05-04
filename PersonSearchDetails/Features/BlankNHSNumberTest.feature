Feature: Feature1

A short summary of the feature

@tag1
Scenario: Determine if NHS Nunber is empty
	Given that i've logged in as an administrator
	When i start the process of creating a new person
	Then check to see if the NHS Number field is blank
