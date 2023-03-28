Feature: Audit events - Create person

Test PER0007 has been automated fro the regression pack
This test will ensure that the correct audit events have 
been created when a new person is created

@smokeTest
Scenario: To verify that a newly created person has the correct Audit logs created against them
	Given that i've logged in as an administrator
	When i perform a person search using firstname 'Billy', lastname 'Test' & dob '12/08/1976'
