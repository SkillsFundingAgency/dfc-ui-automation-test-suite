Feature: Give Feedback with Yes in addtional contact
Scenario: Submit a Give Feedback form with Yes in additional contact 
	Given I have navigated to the contact us page
	And I have clicked the link to online message
	And I have selected 'Give feedback' option to continue onto the first contact form
	Then I am directed to the first contact form
	When I complete the first form with 'Customer service' option and 'Contact for feedback' query
	And I complete the feedback form with details 'Automated','Test','automatedtestesfa@mailinator.com','automatedtestesfa@mailinator.com'
	And I select 'Yes' for additional contact
	And I select the terms and conditions
	And I click send
	Then I am directed to the confirmation page


