﻿Feature: SD_Products

As a user
I want to be able to see all items in one place
So that I know all my buying options

@Products
Scenario: Social Media Links - Widgets
Given I am on the products page
When I click on the following social media widget <widget>
Then I land on the given social media page <social media page>
Examples: 
| widget   | social media page |
| twitter  | www.twitter.com   |
| facebook | www.facebook.com  |
| linkedin | www.linkedin.com  |

@Products
Scenario: Drop down menu selection
Given I am on the products page
When I select one of the possible sort alphabetically dropdown options <options>
Then The products sort by the given alphabetical option
Examples:
| options       |
| Name (A to Z) |



