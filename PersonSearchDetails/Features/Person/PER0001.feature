Feature: Person Search - Details
To ensure a person search can be performed using most common search criteria, 
forename, surname & dob
ensure the returned record is correct

@smokeTest
Scenario: A person search using forename, surname & dob
	Given that i've logged in as an administrator
	When i perform a person search using firstname 'Billy', lastname 'Test' & dob '12/08/1976'
	Then the returned record will show the correct name, id, dob & address
