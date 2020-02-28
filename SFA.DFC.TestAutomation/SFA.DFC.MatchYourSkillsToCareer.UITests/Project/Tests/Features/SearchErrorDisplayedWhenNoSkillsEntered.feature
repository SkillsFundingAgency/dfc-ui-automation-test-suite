Feature: SearchErrorDisplayedWhenNoSkillsEntered
	As a citizen 
	I would like to system to warn me
	if i dont enter the required information while searching for skills

@MatchSkills
@Smoke
Scenario Outline: Search Error Displayed When No Skills Entered
	Given I have navigated to the Match Skills page and click Start now
	When I select Yes and click continue on employment choice
	Then I am taken to the Skills Entry Choice page
	When I select the Match Skills option and click continue
	Then I am taken to the Enter your occupation page
	When I enter <search term> on the Enter your occupation page
		#And I select <occupation> from the drop down list
		And I click search button on the Enter your occupation page
	Then I am taken to the Select skills page
	When I select a skill on Select skills page
		And I click the Add to basket on Select skills page
	Then I am taken to the Your skills list page
	When I click on Add More Skills on Your skills list page
	Then I am taken to the More Skills page
	When I select skills entry option
	Then I am taken to the Enter your skills page
	When I click search button on Enter skills page
	Then an Error message is displayed on the Enter skills page

Examples:
	 | search term | occupation  |
	 | Headteacher | Headteacher |