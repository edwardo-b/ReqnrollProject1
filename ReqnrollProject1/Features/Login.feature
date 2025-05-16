Feature: Login

A short summary of the feature

@tag1
Scenario: [Login with username]
	Given I launch the application URL
	When I click login button
	And  I select mobile option and choose region or "United Kingdom" code
	And enter the phone number and password
	Then I click on the login button
	And I should see the home page
