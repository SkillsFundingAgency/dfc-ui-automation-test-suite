Feature: NavigateToDifferentJobCategories

@ExploreCareers
@Smoke
Scenario: Navigate Job Categories on Explore careers
	Given I navigate to the explore careers homepage
	When I click the category 'Transport'
	Then I am redirected to the selected Job Category page
		And the category is not listed in the displayed categories
		And the correct breacrumb is displayed
	When I select another category 'Healthcare'
	Then I am redirected to the selected Job Category page
		And the category is not listed in the displayed categories
		And the correct breacrumb is displayed
	When I click the breadcrumb
	Then I am redirected to the explore careers homepage
