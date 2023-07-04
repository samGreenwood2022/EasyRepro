Feature: PS0005 - Person Search - Address Details

Regression Pack Scenario - PS0005
To ensure a person search can be performed using address details - house nunber & postcode
ensure the returned record is correct

@Regression
Scenario: Perform a person search using house number & postcode and ensure returned record is correct
	Given that a childrens support worker has logged in
	When i perform a search using house number '137' and postcode 'NE6 2EQ'
	Then the returned record will show the correct name, id, dob & address
