Feature: MPISearchErrorWhenNHSNoBlank - MPI

MPI search error message validation
Check error message occurs when no NHS number is entered and user presses search

@RegressionTest @MpiPdq
Scenario: MPI Search Error Message When NHS Number Value Is Blank
	Given An administrator has logged in
	When they attempt an MPI Search with NHS number field blank
	Then an error message contains text 'NHS Number is invalid.'
