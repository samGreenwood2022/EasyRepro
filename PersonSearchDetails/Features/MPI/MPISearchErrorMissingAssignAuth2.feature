Feature: MPISearchErrorMissingAssignAuth2 - MPI

MPI search error message validation
Check error message occurs when user enters Hospital Number, Forename, Surname, 2 Address Lines

@RegressionTest @MpiPdq
Scenario: MPI search when user enters Hospital Number, forename, surname
	Given An administrator has logged in
	When the user enters hospital number, forename, surname and two address lines and attempts to search 'ABC123' 'John' 'Smith' '18 Blue Street' 'Swansea'
	Then an error message contains text 'Assigning Authority must be selected'
