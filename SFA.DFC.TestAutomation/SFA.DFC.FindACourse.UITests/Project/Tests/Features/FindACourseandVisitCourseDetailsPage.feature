Feature: FindACourseandVisitCourseDetailsPage
	

@Findacourse
Scenario: Find a valid course and check course details page
	Given I have navigated to Find a course page
	When I have entered 'Maths' in the course name
	And I click the Find a course button
	Then the results for the course should be listed
	When I click the course no '3'
	Then I should be taken to the course details page 
	And I should be able to validate the links
	And I should be able to click the links to access the information
