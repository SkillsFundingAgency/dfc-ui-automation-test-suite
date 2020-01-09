Feature: SearchErrorDisplayedWhenNoSkillsEntered
	As a citizen 
	I would like to system to warn me
	if i dont enter the required information while searching for skills

@MatchSkills
@Smoke
Scenario: Search Error Displayed When No Skills Entered
	Given I have navigated to the Match Skills page
	When I select Yes and click continue on employment choice
	Then I am taken to the Skills Entry Choice page
	When I select the Match Skills option and click continue
	Then I am taken to the Enter your occupation page
	When I enter 'Occupation' on the Enter your occupation page
		And I click search button on the Enter your occupation page
	Then I am taken to the Select skills page
	When I select the first skill on Select skills page
		And I click the Add to basket on Select skills page
	Then I am taken to the Your skills list page
	When I click on search for skills on the Your skills list page
	Then I am taken to the Enter your skills page
	When I enter '' on Enter skills page
		And I click search button on Enter skills page
	Then an Error message is displayed on the Enter skills page