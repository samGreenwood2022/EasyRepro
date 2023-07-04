Feature: MPISearchErrorAllFieldsBlank - MPI

MPI search error message validation
Check error message occurs when NHS Number = No and user presses Search

@RegressionTest @MpiPdq
Scenario: MPI Search Error Message When User Selects NHS Number = No And Presses Search
	Given An administrator has logged in
	When an MPI search is attempted with NHS Number = No and user presses search without entering any fields
	Then an error message contains text 'Fields do not meet search criteria:'
	And an error message contains text '- Hospital Number + Assigning Authority'
	And an error message contains text '- Surname + Postcode'
	And an error message contains text '- Surname + Forename + Date of Birth'
	And an error message contains text '- 3 or more Address Lines'

