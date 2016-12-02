Feature: Calc
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

Background: 
     Given Calculator is opened

Scenario: Add two numbers
	Given I have entered 12 into the calculator
	And I have pressed add
	And I have entered 999 into the calculator
	When I press equal
	Then the result should be 1011 on the screen

Scenario: Save number to memory and use it to add
    Given I have pressed memPlus
	And I have entered 19 into the calculator
	And I have pressed add
	And I have pressed memRecall
	When I press equal
	Then the result should be 1030 on the screen