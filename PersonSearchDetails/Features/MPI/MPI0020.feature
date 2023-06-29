﻿Feature: MPI0020 - MPI

MPI search error message validation
Check error message occurs when user enters County and Postcode only

@RegressionTest
Scenario: MPI Search when user enters County and Postcode only
	Given [An administrator has logged in]
	When the user only enters the County and Postcode before clicking Search 'Swansea' 'SA99 7YY'
	Then an error message contains text 'Fields do not meet search criteria:'
	And an error message contains text '- Hospital Number + Assigning Authority'
	And an error message contains text '- Surname + Postcode'
	And an error message contains text '- Surname + Forename + Date of Birth'
	And an error message contains text '- 3 or more Address Lines'