Feature: Send us a letter
	In order to get information about careers from an area based adviser
	As a website user
	I have choosen to send us a letter option

@CUS @smoke
Scenario: On the Contact us homepage the user chooses the option to send us a letter
	Given I am on the contact us homepage
	When the user chooses the option Send us a letter
    Then the user is presented with Send us a letter page
