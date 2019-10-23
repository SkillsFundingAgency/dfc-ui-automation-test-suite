Feature: ApplyFiltersForCourseSearchResults
	

@Findacourse
Scenario: Search for course and Apply filters
	Given I have navigated to Find a course page
	And I have searched for 'Maths'
	When I apply the filter 'Full time'
	And I apply the filter 'Online'
	And I apply the filter 'From Today'
	And I have clicked the Apply Filter button
	Then the filter 'Full time' is selected
	And the filter 'Online' is selected
	And the filter 'From Today' is selected
	
	

