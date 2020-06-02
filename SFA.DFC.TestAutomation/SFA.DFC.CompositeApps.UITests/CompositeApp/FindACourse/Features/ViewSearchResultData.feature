Feature: ViewSearchResultData
	In order to find a course
	As a website user
	I want to see the accurate information being displayed

Background: 
	Given I make a request to the course search API with the keyword parameter 'a'
	And I am on the find a course page

@Fac @Search @Data @API
Scenario: The total count of results is displayed correctly
	Given I search for 'a'
	Then I am presented with search results
	And the showing courses label displays the correct number of results

@Fac @Search @Data @API
Scenario: The total count of results is displayed correjwdnidnwdiwnctly
	Given I search for 'a'
	Then I am presented with search results
	And the showing courses label displays the correct number of results