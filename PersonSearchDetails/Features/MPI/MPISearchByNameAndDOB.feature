Feature: MPISearchByDOBAndName

MPI PDQ Regression Testing
Search for patient in MPI by valid NHS number and open the resulting record

@RegressionTest @MpiPdq
Scenario: MPISearchByDOBAndName
    Given An administrator has logged in
    When an MPI search is attempted with Forename 'Jane', Surname 'Honey' and DOB '03/08/1991'
    Then a patient result is returned with value 'Jane'
    And a patient result is returned with value 'Honey'
    And a patient result is returned with value '03/08/1991'
    And the user is able to open the record with Forename 'Jane', Surname 'Honey' and DOB '03/08/1991'
	And the record contains the value Forename 'Jane', Surname 'Honey' and DOB '03/08/1991'
