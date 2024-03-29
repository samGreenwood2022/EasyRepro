﻿Feature: PC0002 - Person create - duplicate detection rules

Regression Pack Scenario - PER0002
To verify that the duplicate detection rules are in place when creating a new Person
Detection rule tested - matching Surname, Forename & DOB

@tag1
Scenario Outline: duplicate detection rules are in place when creating a new Person
	Given that an adult support worker has logged in
	When i create two people using the same details <firstname> and <dob> and <dateMovedIn> and <Ethnicity> and <Gender> and <preferredLanguage>
	Then the duplicate detection rules will trigger
	Examples: 
	| firstname | dob        | dateMovedIn | Ethnicity | Gender | preferredLanguage |
	| John      | 12/08/1976 | 01/01/2000  | African   | Male   | Welsh             |