Feature: MPISearchBy5LineAddress

Search for a patient by 5 lines of address, retrieve result and open new record

@RegressionTest
Scenario: MPISearchBy5LineAddress
	Given [An administrator has logged in]
	When an MPI search is attempted using address fields '18 Church Street', 'Smalltown', 'Hawick', 'Pembrokeshire', 'SA78 5FF'
	Then a result is returned with values '18 Church Street', 'Smalltown', 'Hawick', 'Pembrokeshire', 'SA78 5FF'
	And the result can be opened with values '18 Church Street', 'Smalltown', 'Hawick', 'Pembrokeshire', 'SA78 5FF' to create a new record
