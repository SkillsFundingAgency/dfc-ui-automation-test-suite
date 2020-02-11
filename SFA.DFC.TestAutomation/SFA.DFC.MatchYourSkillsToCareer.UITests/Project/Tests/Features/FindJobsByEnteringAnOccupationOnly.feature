Feature: FindJobsByEnteringAnOccupationOnly
	As a citizen 
	I would like to see Jobs suitable for me
	By entering a desired occupation as well as skills
	And seleting skills associated with those occupations

@MatchSkills
@Smoke
Scenario Outline: Use Match Skills To Find Jobs by Entering Occupation Only
	Given I have navigated to the Match Skills page and click Start now
	When I select Yes and click continue on employment choice
	Then I am taken to the Skills Entry Choice page
	When I select the Match Skills option and click continue
	Then I am taken to the Enter your occupation page
	When I enter <search term> on the Enter your occupation page
		And I select <occupation> from the drop down list
		And I click search button on the Enter your occupation page
	Then I am taken to the Select skills page
	When I select the first skill on Select skills page
		And I click the Add to basket on Select skills page
	Then I am taken to the Your skills list page
	When I select continue to your career matches
	Then I am on the Results page
	When I click on the first job
	Then I am taken to the new Job profile page

	Examples:
	| search term | occupation          |
	| Headteacher | Headteacher         |
	#| Secretary   | Secretary           |
	#| Chemist     | Chemist             |
	#| manager     | Air traffic manager |

