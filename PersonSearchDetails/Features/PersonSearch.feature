Feature: Person Search
To ensure a person search can be performed
ensure the returned record is correct

@mytag1
Scenario: A person search using forename, surname & dob
	Given that i login with a username & password
	When i perform a person search using firstname 'Billy', lastname 'Test' & dob '12/08/1976'
	Then the returned record will show the correct name and id 'TEST, Billy (WCCIS ID: 4073889)'
	And the returned record will show the correct house number & street '11 GRANGE STREET'
	And the returned record will show the correct town 'PORT TALBOT'
	And the returned record will show the correct dob 'SA13 1EN'

@mytag2
Scenario: A person search using wildcards
	Given that i login with a username & password
	When i perform a person search using a wildcards 'B*', 'T*' & dob '12/08/1976'
	Then the returned record will show the correct name and id 'TEST, Billy (WCCIS ID: 4073889)'
	And the returned record will show the correct house number & street '11 GRANGE STREET'
	And the returned record will show the correct town 'PORT TALBOT'
	And the returned record will show the correct dob 'SA13 1EN'

	@mytag3
Scenario: A person search using person id
	Given that i login with a username & password
	When i perform a person search using a person id '4073889'
	Then the returned record will show the correct name and id 'TEST, Billy (WCCIS ID: 4073889)'
	And the returned record will show the correct house number & street '11 GRANGE STREET'
	And the returned record will show the correct town 'PORT TALBOT'
	And the returned record will show the correct dob 'SA13 1EN'