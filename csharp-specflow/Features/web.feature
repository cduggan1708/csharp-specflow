@web
Feature: Sample Feature for web applications
	In order to demonstrate the value of an open-source automation solution
	As a QA Automation Engineer
	I want to give an example of how to test using a feature file

	Scenario Outline: Test Scenario
      Given I am a user on Google
	  When I enter text "<searchString>" in the text field "Search" by "id" with selector "lst-ib"
      And I hit Enter by "id" with selector "lst-ib"
      Then I should be directed to "Google Search Results" page by "id" with selector "rcnt"
      And I should see value "this will fail" in "search" field by "id" with selector "lst-ib"
      Examples:
        | searchString                           |
        | how wonderful is the Gherkin language? |

	Scenario: Tooltip scenario
		Given I am a user on Mortgage Calculator site
		When I hover over "icon next to Mortgage Amount" by "cssSelector" with selector "#mortageCalculatorForm > ul.inputFieldList.clearfix.left > li:nth-child(1) > div > a"
		Then I should see "Mortgage Amount info popup" with text "Enter the amount of your new or existing mortgage here." by "cssSelector" with selector "#mortageCalculatorForm > ul.inputFieldList.clearfix.left > li:nth-child(1) > div > a > div"

	Scenario: Calculator scenario
		Given I am a user on Mortgage Calculator site
		When I enter text "250000" in the text field "Mortgage Amount" by "id" with selector "amount"
		And I enter text "30" in the text field "Amortization Period" by "id" with selector "amortizationYears"
		And I enter text "30" in the text field "Interest Terms" by "id" with selector "interestTermYears"
		And I select option "Fixed" from dropdown "Interest Type" by "id" with selector "interestType"
		And I enter text "4.38" in the text field "Interest Rate" by "id" with selector "rate"
		And I select option "10" from dropdown "Start Date" by "id" with selector "startMonth"
		And I select option "2017" from dropdown "Start Date" by "id" with selector "startYear"
		And I select option "Monthly" from dropdown "Payment period" by "id" with selector "paymentMode"
		And I click "Calculate Now button" by "id" with selector "button"
		Then I should see "Payment Amount - 1st row" with text "$1,248.95" by "cssSelector" with selector "#mortgage > div.calcHolder.flexContainer.mortgage > div.mortageTableWrapper > table > tbody > tr.active > td:nth-child(2)"
		And I should see "Term Interest Cost - 1st row" with text "$199,622.19" by "cssSelector" with selector "#mortgage > div.calcHolder.flexContainer.mortgage > div.mortageTableWrapper > table > tbody > tr.active > td:nth-child(4)"

