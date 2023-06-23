Feature: PER0008 - Person create - validation

To verify that mandatory fields are active when creating a new person

@tag1
Scenario: Create a new person and ensure all mandatory fields are active
	Given that an adult support worker has logged in
	When  i start the process of creating a new person
	Then  the expected mandatory fields are active
