Feature: MPISearchErrorSurnameDOB - MPI

MPI search error message validation
Check error message occurs when user enters DOB and surname only

@RegressionTest @MpiPdq
Scenario: MPI Search when user enters DOB and surname only
	Given An administrator has logged in
	When the user only enters the surname and DOB before clicking Search 'Trent' '12/09/1990'
	Then an error message contains text 'Fields do not meet search criteria:'
	And an error message contains text '- Hospital Number + Assigning Authority'
	And an error message contains text '- Surname + Postcode'
	And an error message contains text '- Surname + Forename + Date of Birth'
	And an error message contains text '- 3 or more Address Lines'
