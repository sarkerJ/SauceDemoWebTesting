Feature: SD_Logout
	Logging out functionality

@logout
Scenario: Logout with no item in basket
	Given I am logged in
	When I click the hamburger menu
	And I click the Logout button
	Then I land on the sign in page