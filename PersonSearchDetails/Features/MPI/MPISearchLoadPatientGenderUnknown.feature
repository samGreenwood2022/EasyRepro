Feature: MPISearchLoadPatientGenderUnknown

When loading patient record from MPI Search, the system is able to retrieve and display the correct value in the Gender field. 

@RegressionTest
Scenario: MPISearchLoadPatientGenderUnknown
	Given [An administrator has logged in]
	And an MPI Search is conducted with NHS number '3668617155'
	And a result is returned with Gender as 'Unknown'
	When the patient record is loaded with NHS number '3668617155'
	Then the patient Gender field contains value 'Unknown'
