Feature: SearchItem

Scenario: The user seraches item should get data correctly
	When the user seraches "Plus Pen-3000 Green (04) A"
	Then Display should show subject with "Green PencilsPlus Pen-3000 Green (04) A" 
