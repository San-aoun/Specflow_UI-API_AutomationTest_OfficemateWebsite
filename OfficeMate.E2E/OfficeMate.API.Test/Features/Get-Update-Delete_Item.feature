Feature: Get Update and Delete Item 

Background:
	Given set up product to the cast 
		| SKU        | QTY | CartId   |
		| OFM5010111 | 1   | 94051473 |

####################################################
# Get - Functional API Validation
####################################################
Scenario: The users gets product on the cart and should add cart
	When the user review the totals product at the cart with cart identify "94051473"
	Then the user gets a response with code "200" message "OK"
	And the user gets Items with following data:
		| Field       | Value                                         |
		| Name        | Double A Copier Paper A4 80 gsm. 5 Reams/Pack |
		| Base_price  | 518.69                                        |
		| Tax_percent | 7                                             |
  
####################################################
# Delete - Function API Invalidation 
####################################################
Scenario: The users deletes product invalid data on the cart and should return error msg "error"
	When the user delete the product with item id "0000000000" 
	Then the user gets a response with code "500" status message is "error"

####################################################
# Update - Function API Invalidation
####################################################
Scenario: The users updates product with non-exsit item identify should return error with message bad request
	When the user update product at the cart with cart identify "94051473"
		| ItemId   | Qty |
		| 00000000 | 2   |
	Then the user gets a response with status "error" and error message "We apologize for the inconvenience. There are not enough products in the requested quantity that you selected %1. Please select other similar products."
