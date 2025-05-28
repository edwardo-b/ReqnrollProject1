Feature: HomePage

A short summary of the feature

@UI
Scenario: WRS Homepage
  Given I navigate to WRS
  Then WRS Home page is displayed
  When I click on the Liabilities Report
  Then the Liabilities page is opened
  When I click on the Revenue Report
  Then the Revenue page is opened
  When I click on Significant Events
  Then the Significant Events page is opened
  When I click on Future Events
  Then the Future Events page is opened

@UI
Scenario: Open Liabilities Report
  Given I navigate to WRS
  When I click on the Liabilities Report
  Then the Liabilities page is opened

@UI
Scenario: Open Revenue Report
  Given I navigate to WRS
  When I click on the Revenue Report
  Then the Revenue page is opened

@UI
Scenario: Open Significant Events page
  Given I navigate to WRS
  When I click on Significant Events
  Then the Significant Events page is opened

@UI
Scenario: Open Future Events page
  Given I navigate to WRS
  When I click on Future Events
  Then the Future Events page is opened

