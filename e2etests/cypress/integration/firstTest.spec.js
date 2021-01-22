describe('My test suite', () => {

	before(() => {
		cy.intercept('GET', 'http://localhost:5300/api/Inventory').as('getInventory')
	})

	beforeEach(() => {
		cy.visit('http://localhost:5100/Inventory')
		cy.get(':nth-child(1) > :nth-child(3) > form > #ingredient_Amount').clear().type('10');
		cy.get(':nth-child(1) > :nth-child(3) > form > .btn').click();

		cy.get(':nth-child(14) > :nth-child(3) > form > #ingredient_Amount').clear().type('10');
		cy.get(':nth-child(14) > :nth-child(3) > form > .btn').click();

		cy.get(':nth-child(15) > :nth-child(3) > form > #ingredient_Amount').clear().type('10');
		cy.get(':nth-child(15) > :nth-child(3) > form > .btn').click();
    })
	
	after(() => {
		cy.visit('http://localhost:5100/Inventory')
		cy.get(':nth-child(1) > :nth-child(3) > form > #ingredient_Amount').clear().type('10');
		cy.get(':nth-child(1) > :nth-child(3) > form > .btn').click();

		cy.get(':nth-child(14) > :nth-child(3) > form > #ingredient_Amount').clear().type('10');
		cy.get(':nth-child(14) > :nth-child(3) > form > .btn').click();

		cy.get(':nth-child(15) > :nth-child(3) > form > #ingredient_Amount').clear().type('10');
		cy.get(':nth-child(15) > :nth-child(3) > form > .btn').click();
	})

	it('Order Margarita, check inventory values', () => {
		cy.visit("http://localhost:5100/Home/Menu");

		cy.get('#addButton').click();

		cy.visit("http://localhost:5100/Cart");

		cy.get('#editButton').click();

		cy.get('#addExtra').click();

		cy.visit("http://localhost:5100/Cart");

		cy.get('#orderButton').click();

		cy.visit('http://localhost:5100/Inventory')

		cy.get(':nth-child(1) > #ingredientAmount').contains('9');
		cy.get(':nth-child(14) > #ingredientAmount').contains('9');
		cy.get(':nth-child(15) > #ingredientAmount').contains('9');
	})

})