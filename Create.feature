Scenario Outline: Add a single user
	Given I Set POST for a single user
	When I Set request HEADER
	And Send a POST HTTP request
	Then the single user detail is created

Scenario Outline: Get details of a single user
	Given I Set GET for a single user
	When I Set request HEADER
	And Send a GET HTTP request
	Then I receive a valid HTTP response code

Scenario Outline: Get details of the list of users
	Given I Set GET for a list of users
	When I Set request HEADER
	And Send a GET HTTP request
	Then I receive a valid HTTP response code

Scenario Outline: Update a single user detail
	Given I Set PUT for a single user detail
	When I Set Update HEADER
	And Send a GET HTTP request
	Then I receive a valid HTTP response code

Scenario Outline: Return a single user not found
	Given I Set GET for a single user not found
	When I Set request HEADER
	And Send a GET HTTP request
	Then I receive an invalid HTTP response code 400