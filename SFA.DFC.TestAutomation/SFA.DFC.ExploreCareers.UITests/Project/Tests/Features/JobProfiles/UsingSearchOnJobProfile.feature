Feature: UsingSearchOnJobProfile

@ExploreCareers
@JobProfile
@Smoke
@Ignore
Scenario: Valid Search on Job Profile Page
	Given I navigate to the 'Chef' profile
	When I search for 'nurse' under the JP search feature
	Then I am redirected to the search results page