Feature: SearchForACourse
	In order to find a course
	As a website user
	I want to search for a specific type of course

Background: 
	Given I am on the find a course page

@mytag
Scenario: Search for a course without using the filter options
	Given I search for 'blah'