@api
Feature: API
  Scenario: Classify Dinosaurus trex
    Given I have a image of dinosaurus 'trex'
    When I call API 'classify'
    Then I got response 'trex'
    
  Scenario: Classify Dinosaurus velo
    Given I have a image of dinosaurus 'velo'
    When I call API 'classify'
    Then I got response 'velo'

  Scenario: Classify Dinosaurus stego
    Given I have a image of dinosaurus 'stego'
    When I call API 'classify'
    Then I got response 'stego'