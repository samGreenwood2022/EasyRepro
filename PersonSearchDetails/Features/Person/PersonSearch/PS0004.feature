Feature: PS0004 - Person Search - Using NHS Number

As a user with sufficient permissions, when i perform a Person Search using an NHS Number, 
the expected persons details will be returned


@Regression
Scenario: Performing a person search using an NHS Number returns the expected record
	Given a user has navigated to Person Search
	When a search is performed using an NHS Number '620 276 5062'
	Then the returned record will show the correct name, id, dob & address
