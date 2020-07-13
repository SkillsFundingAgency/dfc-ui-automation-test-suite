Feature: ContactUsHomePage
	In order to get information about careers
	As a website user
	I want to choose a specific option to get through to an adviser


@CUS
Scenario: On the Contact us homepage the user is presented with options to get through to an adviser
	Given I am on the contact us homepage
	Then I am presented with the four options

@CUS
Scenario: Error messages on Contact-us homepage
	Given I am on the contact us homepage
	When I click continue with nothing selected
	Then an error message is displayed on the homepage