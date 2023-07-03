Feature: MPISearchByValidNHSNo - MPI 

MPI PDQ Regression Testing
Search for patient in MPI by valid NHS number and open the resulting record

@RegressionTest @MpiPdq
Scenario: MPISearchByValidNHSNo
	Given An administrator has logged in
	When an MPI search is attempted with NHS Number '5283627144'
	Then a patient result is returned with NHS number '5283627144'
	And the user is able to open the record with NHS number '5283627144'