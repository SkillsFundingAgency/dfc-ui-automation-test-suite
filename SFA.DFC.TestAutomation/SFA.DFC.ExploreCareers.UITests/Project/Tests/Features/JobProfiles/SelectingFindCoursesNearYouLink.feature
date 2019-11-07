Feature: SelectingFindCoursesNearYouLink

@ExploreCareers
@JobProfile
@Smoke
Scenario: Selecting the Find a Course near you link takes you to the Find a Course product
	Given I navigate to the 'plumber' profile
	When I click the Find courses near you link
	Then I am taken to the Find a Course product