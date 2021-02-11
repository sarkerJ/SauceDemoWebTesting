Feature: SD_Login

In order to be able to buy items
As a registered user of the SauceDemo website
I want to be able to log in to my account

@Login
Scenario: Valid Credentials - Login
Given I am on the login page
And I have supplied a valid username and password
When I click the login button
Then I should land on the products page

@Login
Scenario: Invalid credentials - Login
Given I am on the login page
And I have supplied the following invalid credentials
| Username | Password |
| username | password |
When I click the login button
Then I get the following error message "Epic sadface: Username and password do not match any user in this service"
