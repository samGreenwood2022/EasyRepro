Feature: MPINewPatientInvalidName

Search by NHS number for patient with long name, so when loaded into new patient screen, an error message occurs. 

@RegressionTest
Scenario: MPINewPatientInvalidName
	Given [An administrator has logged in]
	When the user conducts an MPI search by NHS number '2373254808'
	Then on loading the patient with NHS number '2373254808', an error message occurs informing the user that the patient name is too long for the record fields
