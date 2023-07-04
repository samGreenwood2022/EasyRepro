Feature: MPISearchBySurnameAndPostcode

Search for a patient by surname and psotcode, return result and open record

@RegressionTest @MpiPdq
Scenario: MPISearchBySurnameAndPostcode
	Given An administrator has logged in
	When An MPI search is attempted with Surname 'Honey' and postcode 'SA78 5FF'
	Then a result is returned with values 'Honey' and 'SA78 5FF'
	And the result can be opened with the values 'Honey' and 'SA78 5FF' to create a new record
