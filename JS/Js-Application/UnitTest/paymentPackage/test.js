const PaymentPackage = require('./paymentPackage.js');
const { assert } = require('chai');

describe('PaymentPackage', () => {
    describe('Test name', () => {
        it('Number => Error', () => {
            assert.throw(() => {
                new PaymentPackage(1, 1);
            }, 'Name must be a non-empty string');
        })

        it('EmptyString => Error', () => {
            assert.throw(() => {
                new PaymentPackage('', 1);
            }, 'Name must be a non-empty string');
        })

        it('Test => Work', () => {
            let actual = new PaymentPackage('test', 1);
            let expectedName = 'test';
            assert.equal(actual.name, expectedName);
        })

        it("newName => newName", () => {
            let newObj = new PaymentPackage('test', 1);
            let expectedName = 'newName';
            assert.exists(newObj.name = "newName", expectedName);
        });
    })

    describe("Test value", () => {
        it('StringForValue => Error', () => {
            assert.throw(() => {
                new PaymentPackage('a', 'a');
            }, 'Value must be a non-negative number');
        })

        it('NegativeValue => Error', () => {
            assert.throw(() => {
                new PaymentPackage('a', -1);
            }, 'Value must be a non-negative number');
        })

        it('Value => Work', () => {
            let actualValue = new PaymentPackage('name', 1);
            let expectedValue = 1;
            assert.equal(actualValue.value, expectedValue);
        })

        it("newValue => newValue", () => {
            let actualValue = new PaymentPackage('test', 1);
            let expectedValue = 2;
            assert.equal(actualValue.value = 2, expectedValue);
        });
    })

    describe("Test VAT", () => {
        it("vatSetCorrectly => 20", () => {
            let newObj = new PaymentPackage('a', 1);
            let expectedlVat = 20;
            assert.equal(newObj.VAT, expectedlVat);
        });
        it("StringForVAT => Error", () => {
            let newObj = new PaymentPackage('a', 1);
            assert.throw(() => {
                newObj.VAT = 'a';
            }, 'VAT must be a non-negative number')
        })
        it("negativeNumberAsVAT => Error", () => {
            let newObj = new PaymentPackage('a', 1);
            assert.throw(() => {
                newObj.VAT = -1;
            }, 'VAT must be a non-negative number')
        });
        it("newVAT => Work", () => {
            let actualValue = new PaymentPackage('test', 1);
            let expectedValue = 2;
            assert.equal(actualValue.VAT = 2, expectedValue);
        });
    });

    describe("Test active", () => {
        it("activeWorkCorrectly => true", () => {
            let newObj = new PaymentPackage('a', 1);
            let expectedActive = true;
            assert.equal(newObj.active, expectedActive);
        });

        it("activeThrow => Error", () => {
            let newObj = new PaymentPackage('a', 1);
            assert.throw(() => {
                newObj.active = 'activeThrow';
            }, 'Active status must be a boolean')
        });

        it("setActiveTofalse => false", () => {
            let newObj = new PaymentPackage('a', 1);
            let actual = newObj.active = false;
            let expectedActive = false;
            assert.equal(actual, expectedActive);
        });
    });

    describe("Test toString", () => {
        it("test toString", () => {
            let newObj = new PaymentPackage('HR Services', 1500);
            let actual = newObj.toString();
            let expected = 'Package: HR Services\n- Value (excl. VAT): 1500\n- Value (VAT 20%): 1800';
            assert.equal(actual, expected);
        });
        it("test toString", () => {
            let newObj = new PaymentPackage('HR Services', 1500);
            newObj.active = false;
            let actual = newObj.toString();
            let expected = 'Package: HR Services (inactive)\n- Value (excl. VAT): 1500\n- Value (VAT 20%): 1800';
            assert.equal(actual, expected);
        });
        it("test toString", () => {
            let newObj = new PaymentPackage('HR Services', 1500);
            newObj.VAT = 0;
            let actual = newObj.toString();
            let expected = 'Package: HR Services\n- Value (excl. VAT): 1500\n- Value (VAT 0%): 1500';
            assert.equal(actual, expected);
        });
        it("test toString", () => {
            let newObj = new PaymentPackage('HR Services', 0);
            newObj.VAT = 0;
            let actual = newObj.toString();
            let expected = 'Package: HR Services\n- Value (excl. VAT): 0\n- Value (VAT 0%): 0';
            assert.equal(actual, expected);
        });
    });
})