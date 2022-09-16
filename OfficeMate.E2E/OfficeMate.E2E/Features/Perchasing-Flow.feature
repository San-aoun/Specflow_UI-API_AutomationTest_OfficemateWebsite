Feature: Perchasing

Scenario: The user adds perchase the pencil item should update success 
	When the user seraches "Plus Pen-3000 Green (04) A"
	And the user add the item "Search Results/Plus Pen-3000 Green (04) A"
	And the user go to cart for view cart with the item "Plus Pen-3000 Green (04) A"
	And the user proceed to checkout
	And the user Specify Delivery Information with data
		| First Name | Last Name | Phone       | Email                       | Address     | Zip Code | Region  | District    | Sub District |
		| Jane       | Doe       | 09-999-9999 | Automation_test01@gmail.com | 2/3 Bangkok | 10520    | Bangkok | Lat Krabang | Lam Pla Thio |	
	And Click Tax invoice same address as the delivery
	And the user proceed to payment 
	And Select you payment option "Credit Card/Debit Card" and updated infomation
		| Key               | Value                   |
		| Card Number       | 0000 0000 0000 0000 000 |
		| Full Name on card | Jane Doe                |
		| Expired date      | 25/62                   |
		| CVV/CVC           | 225                     |  
	And Click "Pay Now" button

