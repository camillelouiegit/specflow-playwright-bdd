Feature: Login

Jupiter site 2.0

@Login @ValidLogin
Scenario: Valid username and password
	Given the user is in the homepage
	When the user navigates to "Login" page
	And the user tries to login with username "cams" and password "letmein"
	Then the user "cams" has successfully login

@Login @InvalidLogin
Scenario: Invalid username and password
	Given the user is in the homepage
	When the user navigates to "Login" page
	And the user tries to login with username "invalid" and password "admin"
	Then the error message is displayed