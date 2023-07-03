Feature: MPISearchLessThan10DigitNHSNo - MPI 

MPI Search error message validation
Check that error message occurs when user tries to search with an invalid NHS number (less than 10 digits)

@RegressionTest @MpiPdq
Scenario: MPISearchErrorMessageWhenTheNHSNumberIsLessThan10Digits
	Given An administrator has logged in
	When an MPI search is attempted with NHS Number '25'
	Then an error message contains text 'NHS Number is invalid.'
