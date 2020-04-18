Feature: Login
	In order to check loggin in functionality
	As specific Vitoguide user
	I want to be redirected to specific page

@mytag
Scenario: Proper Login
	Given I am opening Vitoguide app
	When I click Login button
	And I put <userId> as user name
	And I put <password> as password
	And I press login button
	Then I land on <startPage> page

	Examples: 
	| userId                      | password   | startPage      |
	| rsa_intsupport              | Test12345! | /search        |
	| vitoguidetest@viessmann.com | Test1234!  | /installations |

