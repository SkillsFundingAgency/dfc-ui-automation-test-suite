Feature: DisplayRelatedApprenticeshipsOnJobProfile

@ExploreCareers
@JobProfile
@Smoke
Scenario: Related aprenticeships are displayed on job profiles
	Given I navigate to the 'care-worker' profile
	Then the related apprenticeship section is displayed
	When I select apprenticeship title '2'
	Then I am redirected to the correct apprenticeships page
