Feature: TMPage

Background:
Given I navigate to the TurnUp Portal
When I login to the TurnUp Portal
And I click option "Time & Materials" under Administration Drop Down on the Main Page


Scenario: Verify user navigates to TM or Employee Page

Given I am on "Time and Materials" page
When I clicked on Create New button 
And I clicked on the drop down option in TypeCode field
And I selected "Time" from time and material options
And I entered the valid data (code, description and price per unit) and clicked on save button
Then I varifies a new record has created successfully