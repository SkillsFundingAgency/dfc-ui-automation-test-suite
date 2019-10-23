Feature: Report a Technical Issue
Scenario: Report a Technical Issue
	Given I have navigated to the contact us page
	And I have clicked the link to online message
	And I have selected 'Report a technical issue' option to continue onto the first contact form
	Then I am redirected to the first technical contact form
	When I complete the first technical form with 'Unable to access website' query
   	And I complete the feedback form with details 'Automated','Test','automatedtestesfa@mailinator.com','automatedtestesfa@mailinator.com'
	And I select 'Yes' for additional contact
	And I select the terms and conditions
	And I click send
	Then I am directed to the confirmation page

