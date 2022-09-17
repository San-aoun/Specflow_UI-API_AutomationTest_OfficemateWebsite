Feature: Purchase Product 

########################################################
# Functional API Invalidation
########################################################
Scenario: The user order item should be submitted.
	When the user seraches "Plus Pen-3000 Green (04) A"
	And the user add the item "Search Results/Plus Pen-3000 Green (04) A"
	And the user go to cart for view cart with the item "Plus Pen-3000 Green (04) A"
	And the user proceed to checkout
	And the user chooses standard home delivery
	And the user Specify Delivery Information with data
		| First Name | Last Name | Phone       | Email                       | Address     | Zip Code | Region  | District    | Sub District |
		| Jane       | Doe       | 0999999999  | Automation_test01@gmail.com | 2/3 Bangkok | 10520    | Bangkok | Lat Krabang | Lam Pla Thio |	
	And the user selects tax invoice same address as the delivery
	And the user proceed to payment 
	And the user selects you payment option Credit Card/Debit Card and updated infomation
		| Card Number             | Full Name on card | Expired date | CVV/CVC |
		| 0000 0000 0000 0000 000 | Jane Doe          | 12/22        | 225     |

