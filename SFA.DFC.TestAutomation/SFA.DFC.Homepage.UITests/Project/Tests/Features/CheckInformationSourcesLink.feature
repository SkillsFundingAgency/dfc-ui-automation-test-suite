Feature: CheckInformationSourcesLink

@ExploreCareers
@Homepage
Scenario: Footer - Check Information Sources link
	Given that I am viewing the Home page
	When I click the Information Sources link
	Then I am redirected to the Information Sources page
