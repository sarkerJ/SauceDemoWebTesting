Feature: SD_Products

As a user
I want to be able to see all items in one place
So that I know all my buying options

@Products
Scenario: Social Media Links - Widgets
Given I Login as a Standard User
And I am on the products page
When I click on the following social media widget <widget>
Then I land on the given social media page <social media page>
Examples: 
| widget   | social media page |
| twitter  | www.twitter.com   |
| facebook | www.facebook.com  |
| linkedin | www.linkedin.com  |

@Products
Scenario: Drop down menu selection - Sort by A to Z
Given I Login as a Standard User
And I am on the products page
When I select to sort by <option> from the dropdown menue
Then The products sort alphabetically from A to Z
Examples: 
| option        |
| Name (A to Z) |

@Products
Scenario: Drop down menu selection - Sort by Z to A
Given I Login as a Standard User
And I am on the products page
When I select to sort by <option> from the dropdown menue
Then The products sort alphabetically from Z to A
Examples: 
| option        |
| Name (Z to A) |

@Products
Scenario: Drop down menu selection - Sort by Price - Low to High
Given I Login as a Standard User
And I am on the products page
When I select to sort by <option> from the dropdown menue
Then The products sort by price from low to high
Examples: 
| option              |
| Price (low to high) |

@Products
Scenario: Drop down menu selection - Sort by Price - High to Low
Given I Login as a Standard User
And I am on the products page
When I select to sort by <option> from the dropdown menue
Then The products sort by price from high to low
Examples: 
| option              |
| Price (high to low) |

@Product
Scenario: Accessing product specific page
Given I Login as a Standard User
And I am on the products page
When I click on a product name <id>
Then I should see a page with information of that product <productPageName>
Examples: 
| id                | productPageName          |
| item_4_title_link | Sauce Labs Backpack      |
| item_0_title_link | Sauce Labs Bike Light    |
| item_5_title_link | Sauce Labs Fleece Jacket |


@Product
Scenario: Going back to product page
Given I Login as a Standard User
And I am on the products page
When I click on a product name <id>
And I click the back button
Then I should land on the products page again <labelName>
Examples: 
| id                | labelName |
| item_4_title_link | Products  |

@Basket
Scenario: Adding product to cart
Given I Login as a Standard User
And I am on the products page
When I add a product to cart <productindex>
Then the cart count is 1
And the button state <productindex> changes to <state>
Examples: 
| productindex | state  |
| 0            | REMOVE |



@Basket
Scenario: Delete product from cart
Given I Login as a Standard User
And I am on the products page
When I add a product to cart <productindex>
And I click the button again to remove the product <productindex>
Then the cart count is 0
And the button state <productindex> changes to <state>
Examples: 
| productindex | state       |
| 1            | ADD TO CART |