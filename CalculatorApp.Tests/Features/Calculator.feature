Feature: Calculator
    As a user
    I want to use a calculator
    To avoid making mistakes in arithmetic

@add
Scenario: Add two numbers
    Given the first number is 50
    And the second number is 70
    When the two numbers are added
    Then the result should be 120