Feature: RemoveSkillsFromYourSkillsList
	As a citizen 
	I would like to Remove skills from my Your Skills list
	So i only see jobs for the skills I have selected

@MatchSkills
@Smoke
Scenario Outline: Remove Skills From Your Skills list
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
	When I click remove selected skill
	Then I am taken to the Remove skills page
	When I select the first skill on remove skills page
		And i click the remove selected skill button
	Then I am taken to the Confirm Remove skills page
	When I click confirm remove skills
	Then I am taken to Removed page
	When I click on the add more skills link
	Then I am taken to the More Skills page

Examples:
	 | search term | occupation  |
	 | Headteacher | Headteacher |
