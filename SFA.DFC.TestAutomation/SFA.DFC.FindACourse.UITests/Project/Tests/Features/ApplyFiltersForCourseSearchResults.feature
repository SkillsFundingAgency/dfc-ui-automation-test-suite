Feature: ApplyFiltersForCourseSearchResults
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

@Findacourse
Scenario Outline: Search for course and Apply filters
	Given I have navigated to Find a course page
	And I have searched for a valid course '<CourseName>'
	When I click the Find a course button
	Then the results for the course should be listed	
	When I apply the filter hours '<CourseHours>', type '<CourseType>' and start date '<StartDate>'
	And I have clicked the Apply Filter button
	Then the following filters <CourseHours>, <CourseType>, <StartDate> are selected

Examples: 
| CourseName | CourseHours | CourseType | StartDate |
| Maths      | Full time   | Online     | From Today     |
