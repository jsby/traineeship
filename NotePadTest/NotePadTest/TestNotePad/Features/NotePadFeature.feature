Feature: Feature
	Check notepad power

Background: 
    Given Notepad is opened

Scenario: Check date by menu
	When I press "Time/Date" from Edit menu
	Then the date on the screen should be equal to today's date

Scenario: Check date by keyboard
	When I press F5 on keyboard
	Then the date on the screen should be equal to today's date

Scenario: Check font properties
	Given I have opened Font modal window
	And I have entered font properties from xml
	When I press OK
	And I open Font modal window
	Then font properties on the screen should be equal to properties from xml
