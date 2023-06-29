﻿Feature: MPI0013 - MPI

MPI search error message validation
Check error message occurs when user enters street address and designation only

@RegressionTest
Scenario: MPI Search when user enters street and city only
	Given [An administrator has logged in]
	When the user only enters the street address and city before clicking Search 'Blue Road' 'Swansea'
	Then an error message contains text 'Fields do not meet search criteria:'
	And an error message contains text '- Hospital Number + Assigning Authority'
	And an error message contains text '- Surname + Postcode'
	And an error message contains text '- Surname + Forename + Date of Birth'
	And an error message contains text '- 3 or more Address Lines'