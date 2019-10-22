Feature: SearchTermWithNoResults

@ExploreCareers
@Search
@Smoke
Scenario: Perform a search that will return 0 results
	Given I search for 'return0results'
	Then I am redirected to the search results page
		And the search term is displayed in the search field
		And the no results message is displaed
