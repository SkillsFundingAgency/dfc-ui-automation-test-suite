Feature: UsingSearchOnJobProfile

@ExploreCareers
@JobProfile
@Smoke
Scenario: Valid Search on Job Profile Page
	Given I navigate to the 'acupuncturist' profile
	When I search for 'firefighter' under the JP search feature
	Then I am redirected to the search results page