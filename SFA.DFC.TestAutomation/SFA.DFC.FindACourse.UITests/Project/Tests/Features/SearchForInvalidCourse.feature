﻿Feature: SearchForInvalidCourse
	

@Findacourse
@Ignore
Scenario: Search for Invalid Course
	Given I have searched for 'NoCourse'
	Then an error message should be returned
