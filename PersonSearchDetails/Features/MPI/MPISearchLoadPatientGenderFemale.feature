Feature: MPISearchLoadPatientGenderFemale

When loading patient record from MPI Search, the system is able to retrieve and display the correct value in the Gender field. 

@RegressionTest @MpiPdq
Scenario: MPISearchLoadPatientGenderFemale
	Given An administrator has logged in
	And an MPI Search is conducted with NHS number '2736204689'
	When the patient record is loaded with NHS number '2736204689'
	Then the patient Gender field contains value 'Female'
