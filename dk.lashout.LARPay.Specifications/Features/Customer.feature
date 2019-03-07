Feature: Customer 
	As a player
	I'd like to create a user for my role
	So I can use the system

Scenario: Create a user, using an unoccupied username, makes me able to login
	When I create a user with the username "a", name "a" and pincode "1"
	Then I can login as "a" using the pincode "1"