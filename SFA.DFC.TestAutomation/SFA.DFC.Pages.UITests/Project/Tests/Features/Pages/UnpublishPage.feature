Feature: UnpublishPage
As a content editor
When i unpublish a page
Then it is not visible on the published environnment

@Pages
@Regression
Scenario: Unpublish a published page and view on published environment
	Given I have naviagted to the service taxonomy editor
	And I have created a published page
	And I have navigated to the published environment
	Then the page is found
	When I unpublish the page
	Given I have navigated to the published environment
	Then the page is not found
	Then I delete the page
