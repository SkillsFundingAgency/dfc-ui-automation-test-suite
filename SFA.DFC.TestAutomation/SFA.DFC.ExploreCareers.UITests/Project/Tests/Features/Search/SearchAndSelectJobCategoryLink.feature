Feature: SearchAndSelectJobCategoryLink

@ExploreCareers
@Search
@Smoke
Scenario:  Performing a search displays Job categories and clicking one takes you to the categories page
	Given I search for 'plumber'
	Then I can see job categories under the search results
	When I select search category '1'
	Then I am redirected to the selected Job Category page