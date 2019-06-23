@MemberServices
Feature: MemberServices
	Test MemberServices

Scenario: 01 - Admin user can create member
	Given Set Id:"D4960776-3555-4CC9-AE8C-A45DC86C98AA" and Name:"test01"
	When I create Member
	Then I receive successful response and Id:"D4960776-3555-4CC9-AE8C-A45DC86C98AA"


