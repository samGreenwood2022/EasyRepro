Feature: MPISearchForValidNameAndDOB

MPI PDQ Regression Testing
Search for patient in MPI by valid NHS number and open the resulting record

@RegressionTest
Scenario: MPISearchForValidNameAndDOB
	Given [An administrator has logged in]
	When an MPI search is attempted with Forename 'Jane', Surname 'Honey' and DOB '03/08/1991'
	Then a result is returned with values 'Jane', 'Honey' and '03/08/1991'
	And the result can be opened with the values 'Jane', 'Honey', and '03/08/1991' to create a new record
