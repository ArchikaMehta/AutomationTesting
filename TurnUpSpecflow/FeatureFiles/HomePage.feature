Feature: HomePage
As a normal business user,
I would like to navigate to "Time and Material" page of TurnUp Portal

Background: 
Given I navigated to the TurnUp Portal
When I login to the TurnUp Portal

Scenario: Navigation to "Time and Material" or "Employee" Page

Given I am on Home page
When I click option "Time & Materials" under Administration Drop Down on the Main Page
Then I verify that I am navigated to TM Page