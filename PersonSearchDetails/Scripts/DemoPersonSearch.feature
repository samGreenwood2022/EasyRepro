Feature: Person Search & Verify Record

Perform a person search and verify the record

@tag1
Scenario: Perform a person search
	Given that i've logged in as a Test Administrator
	When when i search for a person
	Then the expected record will be displayed on screen
