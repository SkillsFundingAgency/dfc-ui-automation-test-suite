Feature: FindJobsByEnteringOccupation
	As a citizen 
	I would like to see Jobs suitable for me
	By entering a desired occupation
	And seleting skills associated with that occupation

@MatchSkills
@Smoke
Scenario: Use Match Skills To Find Jobs by Entering Occupation
	Given I have navigated to the Match Skills page
	When I select the search jobs by entering your job title option
	Then I am taken to the Enter your occupation page
	When I enter 'Occupation' on the Enter your occupation page
		And I click search button on the Enter your occupation page
	Then I am taken to the Select skills page
	When I select the first skill on Select skills page
		And I click the Add to basket on Select skills page
	Then I am taken to the Your skills list page