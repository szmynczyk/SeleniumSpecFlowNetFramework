Feature: FirstFeature
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

@mytag
Scenario: As User I enter to blog and I’m contacting by contact form.
 Given I enter to "home" page
 And I Accept cookies
 And I click on "Contact" in menu
 When I fill contact form
 Then I expect to see message as "Message Sent (go back)"