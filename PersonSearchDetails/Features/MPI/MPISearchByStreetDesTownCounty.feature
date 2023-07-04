Feature: MPISearchByStreetDesTownCounty

MPI search is conducted using three lines of address: Street, Other Designation, Town, County

@RegressionTest @MpiPdq
Scenario: MPISearchByStreetDesTownCounty
	Given An administrator has logged in
	When an MPI search is conducted using Street '18 Church Street', Other Designation 'Smalltown', Town 'Hawick' and County 'Pembrokeshire'
	Then a result is returned with Other Designation Street '18 Church Street', 'Smalltown', Town 'Hawick' and County 'Pembrokeshire'
	And the result can be opened with Street '18 Church Street', Other Designation 'Smalltown', Town 'Hawick' and County 'Pembrokeshire'
