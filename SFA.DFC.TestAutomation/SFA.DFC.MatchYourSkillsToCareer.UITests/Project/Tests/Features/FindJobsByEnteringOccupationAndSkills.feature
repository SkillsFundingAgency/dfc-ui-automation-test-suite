Feature: FindJobsByEnteringOccupationAndSkills
	As a citizen 
	I would like to see Jobs suitable for me
	By entering a desired occupation
	And seleting skills associated with that occupation
	And searching for adding additional skills

@MatchSkills
@Smoke
Scenario Outline: Use Match Skills To Find Jobs by Entering Occupation And Skills
	Given I have navigated to the Match Skills page and click Start now
	When I select Yes and click continue on employment choice
	Then I am taken to the Skills Entry Choice page
	When I select the Match Skills option and click continue
	Then I am taken to the Enter your occupation page
	When I enter <search term> on the Enter your occupation page
		And I select <occupation> from the drop down list
	Then I am taken to the Select skills page
	When I select the first skill on Select skills page
		And I click the Add to basket on Select skills page
	Then I am taken to the Your skills list page
	When I click on search for skills on the Your skills list page
	Then I am taken to the More Skills page
	When I select skills entry option
	Then I am taken to the Enter your skills page
	When I enter 'Skill' on Enter skills page
		And I click search button on Enter skills page
	Then I am taken to the Related skills page
	When I select the first skill on Related skills page
		And I click the Add to basket on Related skills page
	Then I am taken to the Your skills list page
		When I select continue to your career matches
	Then I am on the Results page
	When I click on the first job
	Then I am taken to the new Job profile page

	Examples:
	| search term | occupation          |
	| Headteacher | Headteacher         |