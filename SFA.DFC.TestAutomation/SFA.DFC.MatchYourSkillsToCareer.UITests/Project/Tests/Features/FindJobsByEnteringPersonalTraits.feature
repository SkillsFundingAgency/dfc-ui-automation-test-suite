Feature: FindJobsByEnteringPersonalTraits
	As a citizen 
	I would like to see Jobs suitable for me
	By selecting my personality based traits


@MatchSkills
@Smoke
Scenario: Use Match Skills To Find Jobs by Entering Personality traits Only
	Given I have navigated to the Match Skills page
	When I select No and click continue on employment choice
	Then I am taken to the DYSAC traits page
	When I complete the DYSAC 40 questions and click to see results
	Then I am taken to the DYSAC results page
