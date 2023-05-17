Feature: MPISearchByStreetDesCounty

MPI search is conducted using three lines of address: Street, Other Designation, County

@RegressionTest
Scenario: MPISearchByStreetDesCounty
	Given [An administrator has logged in]
	When an MPI search is conducted using Street '18 Church Street', Other Designation 'Smalltown' and County 'Pembrokeshire'
	Then a result is returned with Street '18 Church Street', Other Designation 'Smalltown' and County 'Pembrokeshire'
	And the result can be opened with Street '18 Church Street', Other Designation 'Smalltown' and County 'Pembrokeshire'
