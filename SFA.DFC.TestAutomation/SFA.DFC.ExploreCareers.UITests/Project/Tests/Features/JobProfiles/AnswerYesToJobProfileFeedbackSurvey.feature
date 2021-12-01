Feature: AnswerYesToJobProfileFeedbackSurvey

@ExploreCareers
@JobProfile
@Ignore
Scenario: JP Survey - Answering YES to the survey
	Given I navigate to the 'careers-adviser' profile
	When I click yes to job profile feedback
	Then the thank you message is displayed