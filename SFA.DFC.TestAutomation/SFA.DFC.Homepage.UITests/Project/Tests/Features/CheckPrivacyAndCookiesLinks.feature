Feature: CheckPrivacyAndCookiesLinks


@ExploreCareers
@Homepage
Scenario: Footer - Check Privacy & Cookies link
	Given that I am viewing the Home page
	When I click the Privacy link
	Then I am redirected to the Privacy page
