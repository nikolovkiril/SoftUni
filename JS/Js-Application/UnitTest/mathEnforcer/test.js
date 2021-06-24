const { assert } = require('chai');
const mathEnforcer = require('./mathEnforcer.js');

describe('mathEnforcer', () => {
    describe('addFive', () => {
        it('should return correct result with a non-number  parameter', () => {
            assert.equal(undefined, mathEnforcer.addFive('asd'), 'Function did not return the correct result!');
        })

        it('should return correct result with a non-number  parameter', () => {
            assert.equal(undefined, mathEnforcer.addFive({}), 'Function did not return the correct result!');
        })

        it('should return correct result with a number  parameter', () => {
            assert.equal(15, mathEnforcer.addFive(10), 'Function did not return the correct result!');
        })
    })
    describe('subtractTen', () => {
        it('should return correct result with a non-number  parameter', () => {
            assert.equal(undefined, mathEnforcer.subtractTen('asd'), 'Function did not return the correct result!');
        })

        it('should return correct result with a non-number  parameter', () => {
            assert.equal(undefined, mathEnforcer.subtractTen({}), 'Function did not return the correct result!');
        })

        it('should return correct result with a number  parameter', () => {
            assert.equal(15, mathEnforcer.subtractTen(25), 'Function did not return the correct result!');
        })
    })

    describe('sum', () => {
        it('should return correct result with a non-number1  parameter', () => {
            assert.equal(undefined, mathEnforcer.sum('asd', 4), 'Function did not return the correct result!');
        })

        it('should return correct result with a non-number2  parameter', () => {
            assert.equal(undefined, mathEnforcer.sum(4 ,'asdaaaa'), 'Function did not return the correct result!');
        })

        it('should return correct result with a non-number1  parameter', () => {
            assert.equal(undefined, mathEnforcer.sum({} , 4), 'Function did not return the correct result!');
        })

        it('should return correct result with a non-number2  parameter', () => {
            assert.equal(undefined, mathEnforcer.sum(4 ,{}), 'Function did not return the correct result!');
        })

        it('should return correct result with a number  parameter', () => {
            assert.equal(50, mathEnforcer.sum(25 , 25), 'Function did not return the correct result!');
        })
    })
})