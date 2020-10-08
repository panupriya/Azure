Feature: Company

	Background: Navigate to company page 
	 Given I navigate to company page

	 #create, edit and delete company in one page
 Scenario: Verify company page created edited and deleted successfully
 When I create new company using company name 
 And I am able to varify created company with company name
 When I edit created company with another company name and group name
 And I am ableto verify edited company with edited name
 When I detete edited company 
 Then I am able to verify edited company got deleted