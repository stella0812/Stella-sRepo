/// <reference types="cypress" />

/* 
Add this snippet to support/index.js to prevent the newrelic script error

cypress.on('uncaught:exception', (err, runnable) => {
    // returning false here prevents Cypress from 
    // failing the test
    return false
})
*/

context('Interview Test', () => {
    beforeEach(() =>{
        cy.visit('https://www.johnlewis.com/')
    })
    afterEach(() => {
    cy.clearCookies()
})

it('Interview Test', () => {
    //wait for the site to load. Could wait for visibility of cookie banner
    cy.wait(2000)

    //click the allow cookies button
    cy.get('[data-test="allow-all"]').click({force:true})

    //Search for something genereic that should always return some results
    //It should be an item that doesn't require customisation, unlike a dress size
    cy.get('[id="desktopSearch"]').type('tv{enter}')

    //hide the out of stock items so that we know we can add product to basket
    cy.contains('Hide out of stock items').click()

    //get all the product cards and click on the first one
    cy.get('[data-test="product-card"]').first().click()

    //get 2 of them
    cy.get('[class="quantity-increase-button"]').click()

    //add to the basket then wait for page to update
    cy.contains('Add to your basket').click()
    cy.wait(2000) 

    cy.contains('Go to basket').click()
    //should assert something here

    cy.contains('Remove item').click()

    //check that the items have been removed
    cy.contains('Your basket is empty.').should('be.visible')

    //go back to homepage to stop their screenshot scripts from polling
    cy.visit('https://www.johnlewis.com/')

})
})