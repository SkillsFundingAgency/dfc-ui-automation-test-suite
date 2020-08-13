Feature: DeletePage

@Pages
@Smoke

Scenario: Delete a published page and view on published environment
	Given I have naviagted to the service taxonomy editor
	And I have created a published page
	And I have navigated to the published environment
	Then the page is found
	When I delete the page
	Given I have navigated to the published environment
	Then the page is not found