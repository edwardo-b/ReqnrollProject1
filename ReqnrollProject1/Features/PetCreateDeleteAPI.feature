Feature: PetCreateDeleteAPI

@API
 Scenario: Create and delete a pet
    When I create a pet using the API
    Then the pet should be created successfully
  
