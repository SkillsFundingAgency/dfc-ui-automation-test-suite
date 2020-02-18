Feature: SearchErrorDisplayedWhenNoOccupationEntered
	As a citizen 
	I would like to system to warn me
	When i dont enter the required information while searching for skills

@MatchSkills
@Smoke
Scenario: Search Error Displayed When No Occupation Entered
	Given I have navigated to the Match Skills page and click Start now
	When I select Yes and click continue on employment choice
	Then I am taken to the Skills Entry Choice page
	When I select the Match Skills option and click continue
	Then I am taken to the Enter your occupation page
	When I enter 'Occupation' on the Enter your occupation page
		And I click search button on Enter skills page
	Then an Error message is displayed on the Enter your occupation page