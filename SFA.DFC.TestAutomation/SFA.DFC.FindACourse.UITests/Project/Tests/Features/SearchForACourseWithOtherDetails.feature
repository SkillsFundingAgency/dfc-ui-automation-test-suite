Feature: SearchForACourseWithOtherDetails	

@Findacourse
@ignore
Scenario: Search for course and other information
	Given I have searched for Maths and applied filters for provider Leicester College and location Leicester
	Then the results for the course should be listed
	When I change the provider 'Skills' and location 'Birmingham'
		And I have clicked the Apply Filter button
	Then the results for the new provider and location should be displayed


