@mobile
Feature: Sample Feature for mobile applications
	In order to demonstrate the value of an open-source automation solution
	As a QA Automation Engineer
	I want to give an example of how to test using a feature file

	Scenario Outline: Mobile Test Scenario
		Given I am a user on the Calculator app
		When I click "<firstValue>" by "id" with selector "digit<firstValue>"
		And I click "x" by "id" with selector "mul"
		And I click "<secondValue>" by "id" with selector "digit<secondValue>"
		And I click "=" by "id" with selector "equal"
		Then I should see "results" with text "<expectedResult>" by "xpath" with selector "//android.widget.EditText[1]"
		Examples: 
			| firstValue | secondValue | expectedResult |
			| 6          | 5           | 30             |
			| 7          | 7           | 49             |