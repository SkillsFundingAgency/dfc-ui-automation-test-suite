Feature: JobCategoryEndToEnd

@ExploreCareers
@Smoke
Scenario: End to End Job Category to Job Profile
Given I navigate to the explore careers homepage
	When I click the category 'Retail and sales'
	Then I am redirected to the selected Job Category page
	When I select profile no '2' in the list
	Then I am redirected to the profile selected