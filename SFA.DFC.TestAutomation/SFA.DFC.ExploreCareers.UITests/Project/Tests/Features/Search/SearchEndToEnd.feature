Feature: SearchEndToEnd

@ExploreCareers
@Search
@Smoke
Scenario: Search End To End Test
	Given I search for 'doctor'
	When I select search result '2'
	Then I am redirected to the profile selected