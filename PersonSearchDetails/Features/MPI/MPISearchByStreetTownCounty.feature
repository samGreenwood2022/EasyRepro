Feature: MPISearchByStreetTownCounty

MPI search is conducted using three lines of address: Street, Town, County

@RegressionTest @MpiPdq
Scenario: MPISearchByStreetTownCounty
	Given An administrator has logged in
	When an MPI search is conducted using Street '18 Church Street', Town 'Hawick' and County 'Pembrokeshire'
	Then a result is returned with Street '18 Church Street', Town 'Hawick' and County 'Pembrokeshire'
	And the result can be opened with Street '18 Church Street', Town 'Hawick' and County 'Pembrokeshire'
