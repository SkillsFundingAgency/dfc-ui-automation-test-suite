Feature: AnswerNoToJobProfileFeedbackSurvey

@ExploreCareers
@JobProfile
@Smoke
Scenario: JP Survey - Answering NO to the survey
	Given I navigate to the 'cricketer' profile
	When I click no to job profile feedback
	Then the additional survey message is displayed
	When I click to go to additional survey
	Then I am redirected to the SurveyMonkey survey
	When I enter the feedback 'National Careers Service Test Feedback'
	Then I am redirected to the thank you page
