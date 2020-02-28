Feature: DisplayedRelatedCoursesOnJobProfile

@ExploreCareers
@JobProfile
@Smoke
Scenario: Job Profile displays related courses for citizens
	Given I navigate to the 'Electrician' profile
	Then all the profile segments are displayed
		And related courses are displayed
	When I select course title '1'
	Then I am redirected to the correct course details page