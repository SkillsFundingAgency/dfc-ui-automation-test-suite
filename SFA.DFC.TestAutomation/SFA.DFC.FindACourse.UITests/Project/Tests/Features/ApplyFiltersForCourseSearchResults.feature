Feature: ApplyFiltersForCourseSearchResults
	

@Findacourse
Scenario: Search for course and Apply filters
	Given I have searched for 'Maths'
	Then I should be able to view the results
	When I apply the filter 'Full time'
		And I apply the filter 'Online'
		And I apply the filter 'From today'
		And I have clicked the Apply Filter button
	Then the filter 'Full time' is selected
		And the filter 'Online' is selected
		And the filter 'From today' is selected
	
	

