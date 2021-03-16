Feature: SearchAutoSuggest

@ExploreCareers
@Search
Scenario: Starting a search displays Auto Suggest, and when selected, populates the searchbox
	Given I navigate to the explore careers homepage
	When I enter an incomplete search 'pla'
		And I select result '1' from the auto suggest list
		And click the Search button
	Then I am redirected to the search results page
		And the search term is displayed in the search field