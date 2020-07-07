Feature: CancelOnRemoveSkillsPage
	As a citizen 
	I would like to Click on Cancel Remove skills Page
	So i that i can change my mind on removing skills

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
		And I click the cancel button on remove skills page
	Then I am taken to the Your skills list page

Examples:
	 | search term | occupation  |
	 | Headteacher | Headteacher |
