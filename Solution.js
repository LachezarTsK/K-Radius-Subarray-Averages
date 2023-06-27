
/**
 * @param {number[]} inputNumbers
 * @param {number} radius
 * @return {number[]}
 */
var getAverages = function (inputNumbers, radius) {
    const NOT_POSSIBLE_TO_CREATE_TARGET_SUBARRAY = -1;

    if (radius === 0) {
        return inputNumbers;
    }

    let head = 0;
    let tail = 0;
    let sumTargetSubarray = 0;
    const subarraysAverages = new Array(inputNumbers.length).fill(0);

    while (head < inputNumbers.length) {

        sumTargetSubarray += inputNumbers[head];
        if (head - radius < 0 || head + radius > inputNumbers.length - 1) {
            subarraysAverages[head] = NOT_POSSIBLE_TO_CREATE_TARGET_SUBARRAY;
        }
        if ((head - tail) === 2 * radius) {
            subarraysAverages[tail + radius] = Math.floor((sumTargetSubarray / (2 * radius + 1)));
            sumTargetSubarray -= inputNumbers[tail];
            ++tail;
        }
        ++head;
    }
    return subarraysAverages;
};
