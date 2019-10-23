Feature: SearchForInvalidCourse
	

@Findacourse
Scenario: Search for Invalid Course
	Given I have navigated to Find a course page
	When I have entered 'NoCourse' in the course name
	And I click the Find a course button
	And an error message should be returned "We didn't find any results for 'NoCourse' with the active filters you've applied. Try searching again."
