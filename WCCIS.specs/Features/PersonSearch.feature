Feature: Person Search
To ensure a person search can be performed using firstname, surname & dob
ensure the returned record is correct

@mytag
Scenario: A person search using forename, surname & dob
	Given that i login with a username & password
	When i perform a person search using firstname 'firstname', lastname 'lastname' & dob 'dob'
	Then the returned record will show the correct name 'name'
	And the returned record will show the correct address 'address'
	And the returned record will show the correct dob 'dob'


