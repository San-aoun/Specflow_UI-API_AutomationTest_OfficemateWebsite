Feature: Add item to cart

####################################################
# Functional API Validation
####################################################
Scenario: The users adds a product in the cart and should place a product in the cart
	When the user adds the product to the cart with the details
		| SKU        | QTY | CartId   |
		| OFM5010111 | 1   | 94051473 |  
	Then the user gets a response with code "200" message "OK"
	And the user gets CartItemDto with following data:
		| Field        | Value                                         |
		| Sku          | OFM5010111                                    |
		| Qty          | 1                                             |
		| Name         | Double A Copier Paper A4 80 gsm. 5 Reams/Pack |
		| Price        | 518.69                                        |
		| Product_Type | simple                                        |  

####################################################
# Function API Invalidation
####################################################
Scenario: The user adds invalid product data into the cart and should receive an error message "Requested product doesn't exist"
	When the user adds the product to the cart with the details
		| SKU        | QTY | CartId   |
		| 0000000000 | 1   | 94051473 |  
	Then the user gets a response with status "error" and error message "Requested product doesn't exist"
