Feature: MPISearchByTooLongName

MPI Search for a name that is longer than permitted, using special characters

@RegressionTest @MpiPdq
Scenario: MPISearchByTooLongName
	Given An administrator has logged in
	When an MPI search is conducted using the first name 'Shirly-Bassett-Ḧeidi-florencê-Jolene-Dorothy-Alice-Jayne' and surname 'BÀRRY-cḦarlês-smith-James-loki-Anderson-Banks-Jefferson'
	Then the MPI search field will allow the special characters but remove excess from first name 'Shirly-Bassett-Ḧeidi-florencê-Jolene-Dorothy-Alice-Jayne' and surname 'BÀRRY-cḦarlês-smith-James-loki-Anderson-Banks-Jefferson'
	And no results will be found
