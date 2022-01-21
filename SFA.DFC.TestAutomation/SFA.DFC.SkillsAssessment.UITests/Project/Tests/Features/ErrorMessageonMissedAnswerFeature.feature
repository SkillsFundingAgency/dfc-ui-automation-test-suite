Feature: SkillsHealthCheckwithError
#These tests require migration to the new CUI skills healthcheck - setting Ignore tag here are they will no longer work with CUI skills health check apps
@Skillshealthcheck
@Smoke
@Ignore
Scenario: Error Message on Unanswered question
	Given I have navigated to the Skills Health check page
		And I select 'Mechanical' assessment type with title 'Solving mechanical problems'
	Then I am redirected to the start page for the assessment
	When I click continue without answering a question
	Then an error message should be displayed
	When I complete all the questions
	Then I'm redirected to Skills health check page
		And I can download my completed assessment as a 'PDF' 
		And I can download my completed assessment as a 'Word'  
