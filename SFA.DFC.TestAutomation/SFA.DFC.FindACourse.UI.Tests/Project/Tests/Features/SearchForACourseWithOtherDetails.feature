Feature: SearchForACourseWithOtherDetails
	

@Findacourse
Scenario: Search for course and other information
	Given I have navigated to Find a course page
	And I have searched for a course 'Maths' for provider 'Leicester College' and location 'Leicester'
	Then the results for the course should be listed	
	When I change the provider 'Skills' and location 'Birmingham'
	And I have clicked the Apply Filter button
	Then the results for the new provider and location should be displayed


