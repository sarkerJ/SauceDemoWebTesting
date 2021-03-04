Feature: SD_Logout
	Logging out functionality

@logout
Scenario: Logout with no item in basket
Given I Login as a Standard User
And I am on the products page
When I click the hamburger menu
And I click the Logout button
Then I land on the sign in page