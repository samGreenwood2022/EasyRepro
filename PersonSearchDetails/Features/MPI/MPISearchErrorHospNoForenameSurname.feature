Feature: MPISearchErrorHospNoForenameSurname - MPI

MPI search error message validation
Check error message occurs when user enters Hospital Number, Forename, Surname

@RegressionTest @MpiPdq
Scenario: MPI search when user enters Hospital Number, forename, surname
	Given An administrator has logged in
	When the user enters hospital number, forename and surname and attempts to search 'ABC123' 'John' 'Smith'
	Then an error message contains text 'Assigning Authority must be selected'
