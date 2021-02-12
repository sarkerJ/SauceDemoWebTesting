# SauceDemoWebTesting
## Introduction
The purpose of this project is to make a web testing framework for the Swag Labs Sauce Demo website. The website under test can be found [here](https://www.saucedemo.com/).

## Testing Framework
The testing framework takes a BDD approach which makes use of Specflow and Gherkin syntax. The class diagram of the framework is shown below:

Each feature of the website has multiple scenarios which are broken down into a Given/When/Then statement.
For example:

**Given** I am on the basket page

**And** I have 1 item in the basket

**When** I click "Checkout"

**Then** I land on the "Checkout - Your Information" page

These feature steps are then converted into snippets of code like so:



## Sprint Review

At the beginning of the sprint, the team planned out the project which included writing user stories to cover each feature and the Gherkin syntax for each scenario/test case.
Throughout the project, the team split these user stories between themselves and gradually completed them. By the end of the project, all user stories had been completed with all of them meeting their definition of done.

One possible area for improvement would be to produce tests for the state of the basket after logging out. It should be verified that the state is saved for individual users.

## Sprint Retrospective

Overall, the sprint was a success. The team worked together cohesively with an emphasis on collaboration and communication. Regular pushing of code to the Github repository whilst updating each other on changes contributed towards this success and made for a smoothly running project. The use of version control assisted in cutting down on risk during the process as it meant changes could be safely implemented without the risk of losing large chunks of work. Using and regularly updating the project board meant that all team members were kept informed about the current state of the project and could easily track what had been done and therefore what they must do. 