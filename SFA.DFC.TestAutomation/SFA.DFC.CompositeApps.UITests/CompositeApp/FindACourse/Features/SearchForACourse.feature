Feature: SearchForACourse
	In order to find a course
	As a website user
	I want to search for a specific type of course

Background: 
	Given I am on the find a course page

@FaC @Search @NoResults
Scenario: A no results message is displayed when there are no results
	Given I search for 'abcdefghijkl'
	Then I am presented with a no results message

@FaC @Search @Results
Scenario: Search results are displayed when the keyword search returns a match
Given I search for 'a'
Then I am presented with search results