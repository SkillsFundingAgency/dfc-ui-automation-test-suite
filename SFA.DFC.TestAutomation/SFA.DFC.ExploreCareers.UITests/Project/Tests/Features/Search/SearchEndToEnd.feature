Feature: SearchEndToEnd

@mytag
Scenario: Search End To End Test
	Given I navigate to the explore careers homepage
	When I search for 'doctor'
		And I select search result '2'
	Then I am redirected to the profile selected