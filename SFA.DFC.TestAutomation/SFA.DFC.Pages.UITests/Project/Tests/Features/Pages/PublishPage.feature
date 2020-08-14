﻿Feature: PublishPage
As a content editor
When i create and publish a page
Then it is visible on the draft environnment
And it is visible on the published environnment

@Pages
@Regression
Scenario: Create a published page and view on published environment
	Given I have naviagted to the service taxonomy editor
	Given I have created a published page
	Given I have navigated to the draft environment
	Then the page is found
	Given I have navigated to the published environment
	Then the page is found
	Then I delete the page