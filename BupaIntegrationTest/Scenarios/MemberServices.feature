@MemberServices
Feature: MemberServices
	Test MemberServices

Scenario: 01 - Admin user can create member
	Given Set Id:"D4960776-3555-4CC9-AE8C-A45DC86C98AA" and Name:"test01"
	When I create Member
	Then I receive successful response and Id:"D4960776-3555-4CC9-AE8C-A45DC86C98AA"

#Scenario: 02 - Admin user can query member
#	Given set username:"test04" and password:"test04"
#	When I request to login
#	Then I will receive successful response
#
#Scenario: 03 - Admin user can validate member
#	Given set username:"test01" and password:"error"
#	When I request to login
#	Then I will receive error response "The password you entered is incorrect"
