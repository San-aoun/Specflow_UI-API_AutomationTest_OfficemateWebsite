Feature: DeleteItem

Scenario: The user delete Item on the cart should create 
	Given the user add the item with the details
		| item Name                  | number of item | Price |
		| Plus Pen-3000 Green (04) A | 1              | 10    |  
	And the user go to cart for view cart
	When the user click remove the item
	And click confirm Delete this item
	Then the screen show the the message "Your shopping cart is currently empty"
