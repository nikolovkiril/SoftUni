const assert = require('chai').assert;
const isOdOrEv = require('./evenOrOdd.js');

describe('isOdddOrEven', () => {
    it('should return undefined with a number parameter', () => {
        assert.equal(undefined, isOdOrEv.isOddOrEven(5), 'Function did not return the correct result!');
    })

    it('should return undefined with an object parameter', () => {
        assert.equal(undefined, isOdOrEv.isOddOrEven({}), 'Function did not return the correct result!');
    })

    it('should return even', () => {
        assert.equal('even', isOdOrEv.isOddOrEven('word'), 'Function did not return the correct result!');
    })

    it('should return odd', () => {
        assert.equal('odd', isOdOrEv.isOddOrEven('words'), 'Function did not return the correct result!');
    })

    it('should return correct values with multiple consecutive checks', () => {
        assert.equal('odd', isOdOrEv.isOddOrEven('words'), 'Function did not return the correct result!');
        assert.equal('even', isOdOrEv.isOddOrEven('word'), 'Function did not return the correct result!');
        assert.equal('odd', isOdOrEv.isOddOrEven('words'), 'Function did not return the correct result!');
        assert.equal(undefined, isOdOrEv.isOddOrEven({}), 'Function did not return the correct result!');
        assert.equal(undefined, isOdOrEv.isOddOrEven(4), 'Function did not return the correct result!');
    })
})