Feature: SearchWithEscapedCharacters

@ExploreCareers
@JobProfile
@Smoke
Scenario: Performing a search with text within escaped characters that will return a result
	Given I navigate to the explore careers homepage
	When I search for '<Police Officer>'
	Then I am redirected to the search results page
		And the search term is displayed in the search field
		And a list of results are displayed
  
