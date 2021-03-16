Feature: SearchDisplaysTheDidYouMeanOption

@ExploreCareers
@Search
Scenario: Performing incorrectly spelled search suggests a Did You Mean option
	Given I search for 'nusre'
	Then I am shown the did you mean option
	When I click the did you mean suggestion
	Then the search term is displayed in the search field