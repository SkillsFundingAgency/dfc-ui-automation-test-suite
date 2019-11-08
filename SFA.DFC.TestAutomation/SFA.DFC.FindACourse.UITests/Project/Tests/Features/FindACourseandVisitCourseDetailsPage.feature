Feature: FindACourseandVisitCourseDetailsPage
	

@Findacourse
Scenario: Find a valid course and check course details page
	Given I have searched for 'Maths' 
	#with provider as '' and location as ''
	#Given I have searched for Maths for provider "" and location ""
	Then the results for the course should be listed
	When I click the course no '1'
	Then I should be taken to the course details page 
		And I should be able to validate the links
		And I should be able to click the links to access the information
