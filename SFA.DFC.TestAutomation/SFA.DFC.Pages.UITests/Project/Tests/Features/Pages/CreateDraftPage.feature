﻿Feature: CreateDraftPage

@Pages
@Smoke
Scenario: Create a draft page and view on draft environment
	Given I have naviagted to the service taxonomy editor
	Given I have created a draft page
	Given I have navigated to the draft environment
	Then the page is found
	Given I have navigated to the published environment
	Then the page is not found
	Then I delete the page
