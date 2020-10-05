Feature: TM
	
Background: Navigation to TM Page
	Given I navigate to the TM

@mytag
Scenario: Verify the TM is created
     Given I navigate to create new page


Scenario Outline: Varify  multiple TM creation
When I create entry using code code: '<code>' and desc: '<desc>'
Then I am able to verify with code: '<code>'
Examples: 
| code    |  desc      |
| Sep2021 |  TestTime10|
| Sep2022 |  TestTime11|

Scenario: Varify usage of data table
When I created entries using values from table :
| code    | desc       |
| Sep2023 | TestTime12 |
| Sep2024 | TestTime13 |

Scenario: Verify TM creation, edit and delete
 When I create entry using random code: '<randomcode>' and desc: '<randomdesc>'
 And I am able to verify with '<randomcode>'
 When I create edit entry using random code: '<editCode>' and desc: '<editDesc>'
 And I am able to verify  edit with '<editCode>'
 When I am able to delete code '<randomcode>'
 Then I am able to verify record deleted succesfully
