Feature: TMPage
As a normal business user,
I would like to manage functionalities avilable on "Time and Material" page of TurnUp Portal

Background:
Given I navigated to the TurnUp Portal
When I login to the TurnUp Portal
And I click option "Time & Materials" under Administration Drop Down on the Main Page


Scenario: New Time or Material record creation 

Given I am on "Time and Materials" page
When I click on Create New button 
And I click on the drop down option in TypeCode field
And I select "Time" from time and material options
And I enter the valid data (code, description and price per unit) and clicked on save button
Then I verify a new record has created successfully


Scenario: Edit in already existing TM record

Given I am on "Time and Materials" page
When I click on the last page button 
And I search for unique record to "Edit"
And I edit the record "Price" 
And I save the recrod
Then I verify that an existing record has edited successfully


Scenario: Deletion of an existing TM record

Given I am on "Time and Materials" page
When I click on the last page button 
And I search for unique record to "Delete"
And I delete the record
Then I verify that an existing record has deleted successfully