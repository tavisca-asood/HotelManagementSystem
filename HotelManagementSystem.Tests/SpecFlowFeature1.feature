Feature: Add hotel
	In order to simulate hotel management system
	As api consumer
	I want to be able to add hotel,get hotel details and book hotel

@AddHotel
Scenario Outline: User adds hotel in database by providing valid inputs
	Given User provided valid Id '<id>'  and '<name>'for hotel 
	And User has added required details for hotel
	When User calls AddHotel api
	Then Hotel with name '<name>' should be present in the response
Examples: 
| id | name   |
| 1  | hotel1 |
| 2  | hotel2 |
| 3  | hotel3 |

Scenario:User wants to see the list of all hotels
	When User wants to see the list of all hotels
	Then User sees the list of all available hotels

Scenario Outline: User wants to see the hotel with the particular Id
	When User wants to see the hotel with a particular Id
	Then User sees the hotel with the given Id'<id>'
Examples: 
| id |
| 1  |
| 2  |
| 3  |