Feature: Classify
  Scenario: Classify Dinosaurus
    Given I navigate to the project page
    When I pick task 'classify'
    Then I upload image of dinosaurus with name 'trex' and check results
   
    