Feature: MPISearchByStreetDesTown

MPI search is conducted using three lines of address: Street, Other Designation, Town/City

@RegressionTest @MpiPdq
Scenario: MPISearchByStreetDesTown
	Given An administrator has logged in
	When an MPI search is conducted using Street '18 Church Street', Other Designation 'Smalltown' and Town 'Hawick'
	Then a result is returned with Street '18 Church Street', Other Designation 'Smalltown' and Town 'Hawick'
	And the result can be opened with Street '18 Church Street', Other Designation 'Smalltown' and Town 'Hawick'
