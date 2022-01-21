Feature: 404PageDisplayedCorrectly

@ExploreCareers
@Homepage
@Ignore
Scenario: Ensure 404 pages are displayed correctly when navigating to a page that doesn't exist
	Given I navigate to the 'profile-does-not-exist' profile
	Then I am redirected to the 404 page

	When I click the 'jobprofile' breadcrumb
	Then I am redirected to the national careers service homepage