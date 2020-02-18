Feature: FindJobsByEnteringSkillsAndOccupations
	As a citizen 
	I would like to see Jobs suitable for me
	By entering a skill i possess and an occupation

@MatchSkills
@Smoke
Scenario: Use Match Skills To Find Jobs by Entering Skill and Occupation
	Given I have navigated to the Match Skills page
	When I select the search jobs by entering skills option
	Then I am taken to the Enter your skills page
	When I enter 'Skill' on Enter skills page
		And I click search button on Enter skills page
	Then I am taken to the Select skills page
	When I select the first skill on Select skills page
		And I click the Add to basket on Select skills page
	Then I am taken to the Your skills list page
	When I click on search for occupations on the Your skills list page
	Then I am taken to the Enter your occupation page
	When I enter 'Occupation' on the Enter your occupation page
		And I click search button on the Enter your occupation page
	Then I am taken to the Select skills page
	When I select the first skill on Select skills page
		And I click the Add to basket on Select skills page
	Then I am taken to the Your skills list page


