Feature: FindJobsByEnteringSkills
	As a citizen 
	I would like to see Jobs suitable for me
	By entering a skill i possess

@MatchSkills
@Smoke
Scenario: Use Match Skills To Find Jobs by Entering Skills
	Given I have navigated to the Match Skills page
	When I select the search jobs by entering skills option
	Then I am taken to the Enter your skills page
	When I enter 'Skill' on Enter skills page
		And I click search button on Enter skills page
	Then I am taken to the Select skills page
	When I select the first skill on Select skills page
		And I click the Add to basket on Select skills page
	Then I am taken to the Your skills list page
