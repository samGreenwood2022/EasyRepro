Feature: MPISearchForValidHospNoAndAssigningAuthority

MPI PDQ Regression Testing
Search for patient in MPI by valid Hospital & Assigning Authority and open the resulting record

@RegressionTest @MpiPdq
Scenario: MPISearchForValidHospNoAndAssigningAuthority
	Given An administrator has logged in
	When an MPI search is attempted with Hospital Number 'X824557 ' and Assigning Authority '129'
	Then a result is returned with values 'Michelle', 'Moana' and '01/01/1970'
	And the result can be opened with the values 'Michelle', 'Moana', and '01/01/1970' to create a new record
