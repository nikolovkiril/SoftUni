const StringBuilder = require('./stringBuilder');
const { assert } = require('chai');


describe('StringBuilder', () => {

    let sb;

    beforeEach(() => {
        sb = new StringBuilder();
    });

    describe('VeryfyParams', () => {
        it('should throw exception when parameter is not a string', () => {
            assert.throw(() => {
                new StringBuilder({});
            }, 'Argument must be string')
        })
    })

    describe('constructor', () => {
        it('should work with arg', () => {
            sb = 'pesho';
            assert.equal('pesho', sb.toString());
        })

        it('should work without arg', () => {
            assert.equal('', sb.toString());
        })
    })

    describe('append', () => {
        it('should work correctly', () => {
            sb.append('pesho')
            assert.equal('pesho', sb.toString());
        })
    })

    describe('prepend', () => {
        it('should work correctly', () => {
            sb.append('esho')
            sb.prepend('p')
            assert.equal('pesho', sb.toString());
        })
    })

    describe('insertAt', () => {
        it('should work correctly', () => {
            sb.append('peho')
            sb.insertAt('s', 2)
            assert.equal('pesho', sb.toString());
        })
    })

    describe('remove', () => {
        it('should work correctly', () => {
            sb.append('pesho123')
            sb.remove(5, 3)
            assert.equal('pesho', sb.toString());
        })
    })
})