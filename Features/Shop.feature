Feature: Shop

Jupiter site 2.0

@Shop @price
Scenario: Validate that the cart menu displays 1 with specific price
	Given the user is in the homepage
	When the user navigates to "Shop" page
	And the user selects a product <PRODUCT> with specific price <PRICE>
	Then the user is able to view Cart (1)
	
	Examples: 
	| PRODUCT      | PRICE |
	| Fluffy Bunny | 8.99  |
	| Stuffed Frog | 10.99 |

@Shop @rating
Scenario: Validate that the cart menu displays 1 with 5 star rating
	Given the user is in the homepage
	When the user navigates to "Shop" page
	And the user selects a product <PRODUCT> with star rating <RATING>
	Then the user is able to view Cart (1)

	Examples: 
	| PRODUCT      | RATING |
	| Stuffed Frog | 5      |
	| Smiley Face  | 5      |