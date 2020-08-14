Feature: CreateDraftPage
As a content editor
When i create a draft page
Then it is visible on the draft environnment
And it is not visible on published environment

@Pages
@Regression
Scenario: Create a draft page and view on draft environment
	Given I have naviagted to the service taxonomy editor
	Given I have created a draft page
	Given I have navigated to the draft environment
	Then the page is found
	Given I have navigated to the published environment
	Then the page is not found
	Then I delete the page
