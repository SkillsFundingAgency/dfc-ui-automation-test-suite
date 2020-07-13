Feature: Send us an online message
	In order to get information about careers from an area based adviser
	As a website user
	I have choosen to send an online message


@CUS @smoke
Scenario: On the Contact us homepage the user chooses the option to send an online message
	Given I am on the contact us homepage
	When the user chooses the option Send us an online message
    Then the user is presented with why do you want to contact us page
	And the user chooses the option 'Careers advice'and enters more details
	And the user enters the personal details
	#Then the user should be presented with Thank you for contacting us page
