Feature: SearchForProfileOnExploreCareers

@ExploreCareers
@JobProfile
@Smoke
Scenario: When searching for a profile, the user can see a list of profiles and select one
	Given I navigate to the explore careers homepage
	When I search for 'money'
	Then I am redirected to the search results page
		And the search term is displayed in the search field
	When I select search result '1'
	Then I am redirected to the profile selected