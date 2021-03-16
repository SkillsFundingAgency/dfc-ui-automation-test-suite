Feature: CheckHealthStatusPage

@ExploreCareers
@Homepage
@Smoke
Scenario: Ensure Service Status page is up and running
	Given I navigate to the service status page
	Then the service status page is displayed