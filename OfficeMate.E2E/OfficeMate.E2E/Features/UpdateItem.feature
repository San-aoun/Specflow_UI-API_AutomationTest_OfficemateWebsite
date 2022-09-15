Feature: UpdateItem

Scenario: The user updates Item on the cart should create 
	Given the user add the item with the details
		| item Name                  | number of item | Price |
		| Plus Pen-3000 Green (04) A | 1              | 10    |  
	And the user go to cart for view cart
	When the user update the item with number "2"
	Then the screen show the price with details
		| Total price VAT excluded | Grand total |
		| 18.70                    | 1.31        |  
