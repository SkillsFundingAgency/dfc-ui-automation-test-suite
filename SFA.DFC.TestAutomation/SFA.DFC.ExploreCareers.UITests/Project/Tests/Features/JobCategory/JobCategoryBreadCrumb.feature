Feature: JobCategoryBreadCrumb

@ExploreCareers
@Smoke
Scenario: Add two numbers
	Given I navigate to the explore careers homepage
	When I click the category 'Transport'
	Then I am redirected to the selected Job Category page
	When I click the 'job category' breadcrumb
	Then I am redirected to the explore careers homepage
