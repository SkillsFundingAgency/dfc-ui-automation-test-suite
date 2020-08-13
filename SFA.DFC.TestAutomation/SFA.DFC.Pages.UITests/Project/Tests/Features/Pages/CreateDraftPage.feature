Feature: CreateDraftPage

@ExploreCareers
@Smoke
Scenario: Create a draft page and view on draft environment
	Given I have naviagted to the service taxonomy editor
	Given I have created a draft page
	Given I have navigated to the draft environment
	Then the page is found
	Given I have navigated to the published environment
	Then the page is not found

Scenario: Create a published page and view on published environment
	Given I have naviagted to the service taxonomy editor
	Given I have created a published page
	Given I have navigated to the draft environment
	Then the page is found
	Given I have navigated to the published environment
	Then the page is found

Scenario: Unpublish a published page and view on published environment
	Given I have naviagted to the service taxonomy editor
	And I have created a published page
	And I have navigated to the published environment
	Then the page is found
	When I unpublish the page
	Given I have navigated to the published environment
	Then the page is not found

Scenario: Delete a published page and view on published environment
	Given I have naviagted to the service taxonomy editor
	And I have created a published page
	And I have navigated to the published environment
	Then the page is found
	When I unpublish the page
	Given I have navigated to the published environment
	Then the page is not found