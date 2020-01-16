Feature: ApprenticeshipNotDisplayedOnJobProfile

@ExploreCareers
@JobProfile
@Smoke
Scenario: Apprenticeship are not displayed on Job Profile Page and correct message shown
	Given I navigate to the 'surgeon' profile
	Then all the profile segments are displayed
		And the related apprenticeship section is not displayed
