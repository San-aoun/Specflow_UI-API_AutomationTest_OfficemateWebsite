Feature: Search Product

########################################################
# Functional API validation
########################################################
Scenario: The user seraches item should return accurate results.
	When the user seraches "Plus Pen-3000 Green (04) A"
	Then Display should show subject with "Search Results/Plus Pen-3000 Green (04) A" 