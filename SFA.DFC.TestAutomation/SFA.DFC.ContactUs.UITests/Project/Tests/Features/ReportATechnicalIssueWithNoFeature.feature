﻿Feature: Report a Technical Issue with No in Additonal Contact
@Contactus
@Smoke
@Ignore
Scenario: Report a Technical Issue wth No for additonal contact
	Given I have selected 'Report a technical issue' option to continue onto the first contact form
	Then I am redirected to the first technical contact form
	When I complete the first technical form with 'Unable to access website' query
   		And I complete the feedback form with details 'Automated Test','automatedtestesfa@mailinator.com','automatedtestesfa@mailinator.com'
		And I select 'No' for additional contact
		And I click send
	Then I am directed to the confirmation page
