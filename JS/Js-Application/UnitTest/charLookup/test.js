const assert = require('chai').assert;

const { lookupChar } = require('./charLookup.js');


describe('lookupChar', () => {
    it('should return undefined with a non-string first parameter', () => {
        assert.equal(undefined, lookupChar(12, 0), 'The function did not return the correct result!')
    })

    it('should return undefined with a non-number second parameter', () => {
        assert.equal(undefined, lookupChar('Goshko  ', 'Pesho'), 'The function did not return the correct result!')
    })
    
    it('should return undefined with a floating-point number as a second parameter', () => {
        assert.equal(undefined, lookupChar('Goshko  ', 12.2), 'The function did not return the correct result!')
    })

    it('should return incorrect index with an index value equal to string length', () => {
        assert.equal('Incorrect index', lookupChar('Goshko', 6), 'The function did not return the correct result!')
    })

    it('should return correct value with correct parameters', () => {
        assert.equal('G', lookupChar('Goshko', 0), 'The function did not return the correct result!')
        assert.equal('o', lookupChar('Goshko', 5), 'The function did not return the correct result!')
    })
})