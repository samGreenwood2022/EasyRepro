Feature: MPISearchRetryAfterCriteriaMessage

A short summary of the feature

@RegressionTest
Scenario: MPISearchRetryAfterCriteriaMessage
	Given [An administrator has logged in]
	When [an MPI search is attempted with NHS Number = No and user presses search without entering any fields]
	And an error message contains text 'Fields do not meet search criteria:'
	And an error message contains text '- Hospital Number + Assigning Authority'
	And an error message contains text '- Surname + Postcode'
	And an error message contains text '- Surname + Forename + Date of Birth'
	And an error message contains text '- 3 or more Address Lines'
	And the user retries the MPI Search with Surname 'Honey' and Postcode 'SA78 5FF'
	Then the user is able to open the record with NHS number '5283627144'
