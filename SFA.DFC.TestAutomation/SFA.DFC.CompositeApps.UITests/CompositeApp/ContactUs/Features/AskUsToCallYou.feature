Feature: Ask us to call you back
	In order to get information about careers from an area based adviser
	As a website user
	I have choosen to call me back


@CUS @smoke
Scenario: On the Contact us homepage the user chooses the option "Ask us to call you back"
	Given I am on the contact us homepage
	When the user chooses the option ask us to call you back
	Then the user is presented with why do you want to contact us page
	And the user enters the personal details with the preferred call back time
	Then the user should be presented with Thank you for contacting us page
