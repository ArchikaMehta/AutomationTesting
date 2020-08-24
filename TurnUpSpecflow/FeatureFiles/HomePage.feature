Feature: HomePage

Background:
Given I navigate to the TurnUp Portal
When I login to the TurnUp Portal

Scenario: Verify user navigates to TM or Employee Page

Given User is on Home page
When I click option "Time & Materials" under Administration Drop Down on the Main Page
Then I verify I navigated to TM Page