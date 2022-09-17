Feature: Create-AddToCart

A short summary of the feature

####################################################
# Functional API Validation
####################################################
Scenario: The users adds product on the cart and should add cart
	When the user adds the product to the cart with the details
		| SKU        | QTY | CartId   |
		| OFM5010111 | 1   | 94051473 |  
	Then the user gets a response with code "200" message "OK"
	And the user gets CartItemDto with following data:
		| sku        | qty | name                                          | price  | product_Type |
		| OFM5010111 | 1   | Double A Copier Paper A4 80 gsm. 5 Reams/Pack | 518.69 | simple       |  


####################################################
# Function API Invalidation
####################################################
Scenario: The users adds product invalid data on the cart and should return error msg "Requested product doesn't exist"
	When the user adds the product to the cart with the details
		| SKU        | QTY | CartId   |
		| 0000000000 | 1   | 94051473 |  
	Then the user gets a response with code "200" message "Requested product doesn't exist"
