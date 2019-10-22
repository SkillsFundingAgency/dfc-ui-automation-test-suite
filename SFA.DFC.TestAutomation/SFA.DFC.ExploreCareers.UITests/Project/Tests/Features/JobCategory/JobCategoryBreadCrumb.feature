Feature: JobCategoryBreadCrumb

@ExploreCareers
@Smoke
Scenario: Job Category Breadcrumb should return to the Explore careers homepage
	Given I navigate to the category 'Transport'
	When I click the 'job category' breadcrumb
	Then I am redirected to the explore careers homepage
