﻿Feature: DeleteItem

Background: 
	Given the user seraches "Plus Pen-3000 Green (04) A"
	And the user add the item "Search Results/Plus Pen-3000 Green (04) A"
	And the user go to cart for view cart with the item "Plus Pen-3000 Green (04) A"

########################################################
# Functional API Invalidation
########################################################
Scenario: The user delete Item on the cart should create 
	When the user click remove the item
	Then the screen show the the message "Your shopping cart is currently empty\r\nGO SHOPPING"
