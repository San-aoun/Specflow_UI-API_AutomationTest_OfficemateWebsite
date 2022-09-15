Feature: Perchasing

Scenario: The user adds perchase the pencil item should update success 
	When the user add the item "Plus Pen-3000 Green (04) A"
	And the user go to cart for view cart
	And the user proceed to checkout
	And the user Specify Delivery Information with data
		 | Data         | Value                       |
		 | First Name   | Jane                        |
		 | Last Name    | Doe                         |
		 | Phone        | 09-999-9999                 |
		 | Email        | Automation_test01@gmail.com |
		 | Address      | 2/3 Bangkok                 |
		 | Zip Code     | 10520                       |
		 | Region       | Bangkok                     |
		 | District     | Lat Krabang                 |
		 | Sub District | Lam Pla Thio                |
	And Click Taz invoice same address as the delivery
	And the user proceed to payment 
	And Select you payment option "Credit Card/Debit Card" and updated infomation
		| Data              | Value                   |
		| Card Number       | 0000 0000 0000 0000 000 |
		| Full Name on card | Jane Doe                |
		| Expired date      | 25/62                   |
		| CVV/CVC           | 225                     |  
	And Click "Pay Now" button

