Feature: BreadcrumbDisplayedOnJobProfilePage

@ExploreCareers
@JobProfile
Scenario: Viewing a Job Profile, the Breadcrumb is displayed
	Given I navigate to the 'dental-nurse' profile
	When I click the 'jobprofile' breadcrumb
	Then I am redirected to the explore careers homepage