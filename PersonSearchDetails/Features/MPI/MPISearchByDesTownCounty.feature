Feature: MPISearchByDesTownCounty

MPI search is conducted using three lines of address: Other Designation, Town, County

@RegressionTest @MpiPdq
Scenario: MPISearchByDesTownCounty
	Given An administrator has logged in
	When an MPI search is conducted using Other Designation 'Smalltown', Town 'Hawick' and County 'Pembrokeshire'
	Then a result is returned with Other Designation 'Smalltown', Town 'Hawick' and County 'Pembrokeshire'
	And the result can be opened with Other Designation 'Smalltown', Town 'Hawick' and County 'Pembrokeshire'