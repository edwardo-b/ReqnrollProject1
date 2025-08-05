Feature: Binary Files API
@API
  Scenario: Get all binary files and validate repository name
    When I send a GET request to "endpoint"
    Then the response status code should be 200
    And the response "value" property should be an array
    And the first item's "repository" property should be "critical-files-api"