Feature: RelatedCareersOnJobProfile

@ExploreCareers
@JobProfile
@Smoke
@Ignore
Scenario: Related careers are displayed on job profiles
	Given I navigate to the 'gp' profile
	Then the related careers section should be displayed
		And there should be no more than 5 careers
	When I click on career title '1'
	Then I am redirected to the profile selected