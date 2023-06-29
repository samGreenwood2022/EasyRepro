Feature: MPI0011 - MPI

MPI search error message validation
Check error message occurs when user enters DOB, Postcode and Phone Number

@RegressionTest
Scenario: MPI Search when user eneters DOB, postcode and phone number
	Given [An administrator has logged in]
	When the user only enters the DOB, postcode and phone number before clicking Search '20/03/1987' 'CF56 7WE' '05432666777'
	Then an error message contains text 'Fields do not meet search criteria:'
	And an error message contains text '- Hospital Number + Assigning Authority'
	And an error message contains text '- Surname + Postcode'
	And an error message contains text '- Surname + Forename + Date of Birth'
	And an error message contains text '- 3 or more Address Lines'
