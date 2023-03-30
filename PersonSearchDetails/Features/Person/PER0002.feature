﻿Feature: Person Search - wildcards
To ensure a person search can be performed when using wildcards
ensure the returned record is correct


@smokeTest
Scenario: A person search using wildcards
	Given that i login with a username & password
	When i perform a person search using a wildcards 'B*', 'T*' & dob '12/08/1976'
	Then the returned record will show the correct name, id, dob & address