Feature: ApplyFiltersForCourseSearchResults
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

@Findacourse
Scenario: Search for course and Apply filters
	Given I have navigated to Find a course page
	And I have searched for a  course 'Maths'
	When I click the Find a course button
	Then the results for the course should be listed	
	When I apply the filter hours 'Full time', type 'Online' and start date 'From Today'
	And I have clicked the Apply Filter button
	Then the following filters 'Full time', 'Online', 'From today' are selected

