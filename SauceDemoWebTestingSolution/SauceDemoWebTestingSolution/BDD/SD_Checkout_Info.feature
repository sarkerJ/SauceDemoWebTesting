Feature: SD_Checkout_Info

In order to receive my items
As a registered user of the SauceDemo website
I want to be able to checkout the items in my basket

@CheckoutInfo
Scenario: Valid Credentials - Checkout Info
Given I am on the checkout info page
And I have filled in valid credentials
When I click the continue button
Then I land on the Checkout: Overview page

@CheckoutInfo
Scenario: Invalid Credentials - Checkout Info
Given I am on the checkout info page
And I have filled in the following invalid credentials <First Name> <Last Name> <Zip>
When I click the continue button
Then I get the following expected error message <error>
Examples:
| First Name | Last Name | Zip | error                             |
|            | lName     | zip | Error: First Name is required     |
| fName      |           | zip | Error: Last Name is required      |
| fName      | lName     |     | Error: Postal Code is required    |
| fName      |           |     | Error: Last Name is required      |
|            | lName     |     | Error: First Name is required     |
|            |           | zip | Error: First Name is required     |

@CheckoutInfo
Scenario: Cancel Button - Checkout Info
Given I am on the checkout info page
And I click the cancel button
Then I land on the Cart landing page


