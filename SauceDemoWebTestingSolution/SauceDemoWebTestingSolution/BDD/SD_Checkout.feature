Feature: SD_Checkout

In order to receive my items
As a registered user of the SauceDemo website
I want to be able to checkout the items in my basket

@Checkout
Scenario: Items in my basket - Checkout
Given I am on the products page again
And I have the following amount of items in my basket <number of items>
When I go to My Basket page
And I click Checkout
Then I land on the correct page <landing page url>
Examples:
| number of items | landing page url                                 |
| 0               | https://www.saucedemo.com/cart.html              |
| 4               | https://www.saucedemo.com/checkout-step-one.html |

@Checkout
Scenario: Items in my basket - Continue Shopping
Given I am on the products page again
And I have the following amount of items in my basket <number of items>
When I go to My Basket page
And I click continue shopping
Then I land on the correct page <landing page url>
Examples:
| number of items | landing page url                             |
| 1               | https://www.saucedemo.com/inventory.html     |
