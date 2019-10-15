Feature: AnswerYesToJobProfileFeedbackSurvey

@ExploreCareers
@JobProfile
@Smoke
Scenario: JP Survey - Answering YES to the survey
	Given I navigate to the 'bottler' profile
	When I click yes to job profile feedback
	Then the thank you message is displayed