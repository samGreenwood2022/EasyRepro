Feature: MPISearchErrorMissingAssignAuth - MPI

MPI search error message validation
Check error message occurs when user enters Hospital Number without Assigning Authority

@RegressionTest @MpiPdq
Scenario: MPI Search error when user enters Hospital Number without Assigning Authority
	Given An administrator has logged in
	When the user enters a Hospital Number only and then tries to search '123'
	Then an error message contains text 'Assigning Authority must be selected'
