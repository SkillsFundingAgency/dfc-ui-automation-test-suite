Feature: FindJobsByEnteringPersonalTraitsAndWorkingStyle
	As a citizen 
	I would like to see Jobs suitable for me
	By selecting my personality based traits
	And my working style


@MatchSkills
@Smoke
Scenario: Use Match Skills To Find Jobs by Personality Traits and Working Style
	Given I have navigated to the Match Skills page
	When I select No and click continue on employment choice
	Then I am taken to the DYSAC traits page
	When I complete the DYSAC 40 questions and click to see results
	Then I am taken to the DYSAC results page
	When I choose to answer more questions
	Then I am taken to the DYSAC additional questions page
	When I complete the DYSAC additional questions
	Then I am taken to the DYSAC results page