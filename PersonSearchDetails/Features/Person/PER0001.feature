Feature: PER0001 - Person Search - Details

Regression Pack Scenario - PER0001
To ensure a person search can be performed using most common search criteria, 
first name, last name & dob
ensure the returned record is correct

@LiveSmokeTest
Scenario: A person search using first name, last name & dob
	Given that an adult support worker has logged in
	When i perform a person search using first name 'John', last name 'ZJYIGN' & dob '12/08/1976'
	Then the returned record will show the correct name, id, dob & address
