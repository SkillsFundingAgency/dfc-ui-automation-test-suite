Feature: SearchForInvalidCourse
	

@Findacourse
Scenario: Search for Invalid Course
	Given I have navigated to Find a course page
	And I have searched for a  course 'NoCourse'
	When I click the Find a course button
	Then an error message should be returned 
