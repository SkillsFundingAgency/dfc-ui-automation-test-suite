Feature: SkillsHealthCheck
#These tests require migration to the new CUI skills healthcheck - setting Ignore tag here are they will no longer work with CUI skills health check apps
@Skillshealthcheck
@Smoke
@Ignore
Scenario: Complete and download 'Skills Health Check' 
	Given I have navigated to the Skills Health check page
		And I select 'Spatial' assessment type with title 'Working with shapes'
	Then I am redirected to the start page for the assessment
	When I complete all the questions
	Then I'm redirected to Skills health check page
		And I can download my completed assessment as a 'PDF' 
		And I can download my completed assessment as a 'Word'  
	

