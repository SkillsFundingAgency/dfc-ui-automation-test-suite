Feature: CheckHelpLink

@ExploreCareers
@Homepage
Scenario: Footer - Check Help link
	Given that I am viewing the Home page
	When I click the Help link
	Then I am redirected to the Help page
