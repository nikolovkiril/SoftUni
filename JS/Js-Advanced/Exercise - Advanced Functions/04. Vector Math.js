function solve() {

    return vectorMathObj = {
        add: ([xa, ya], [xb, yb]) => [xa + xb, ya + yb],
        multiply: (arr, multi) => arr = arr.map(x => x * multi),
        length: (vec1) => Math.sqrt((vec1[0] * vec1[0]) + (vec1[1] * vec1[1])),
        dot: ([xa, ya], [xb, yb]) => (xa * xb) + (yb * ya),
        cross: ([xa, xb], [ya, yb]) => (xa * yb) - (xb * ya),
    }
}
