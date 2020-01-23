Feature: CheckTermsAndConditionsLink

@ExploreCareers
@Homepage
Scenario: Footer - Check T&C link
	Given that I am viewing the Home page
	When I click the T&C link
	Then I am redirected to the T&C page
