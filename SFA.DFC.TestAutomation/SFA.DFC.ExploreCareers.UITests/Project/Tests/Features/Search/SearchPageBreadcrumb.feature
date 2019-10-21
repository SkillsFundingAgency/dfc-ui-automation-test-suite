Feature: SearchPageBreadcrumb

@mytag
Scenario: Search Page displays the correct breadcrumb and links to the Homepage
	Given I search for 'test'
	When I click the 'search' breadcrumb
	Then I am redirected to the explore careers homepage
