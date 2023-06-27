
#include <vector>
using namespace std;

class Solution {
    
    inline static const int NOT_POSSIBLE_TO_CREATE_TARGET_SUBARRAY = -1;

public:

    vector<int> getAverages(const vector<int>& inputNumbers, int radius) const {
        if (radius == 0) {
            return inputNumbers;
        }

        int head = 0;
        int tail = 0;
        long sumTargetSubarray = 0;
        vector<int> subarraysAverages(inputNumbers.size());

        while (head < inputNumbers.size()) {

            sumTargetSubarray += inputNumbers[head];
            if (head - radius < 0 || head + radius > inputNumbers.size() - 1) {
                subarraysAverages[head] = NOT_POSSIBLE_TO_CREATE_TARGET_SUBARRAY;
            }
            if ((head - tail) == 2 * radius) {
                subarraysAverages[tail + radius] = (sumTargetSubarray / (2 * radius + 1));
                sumTargetSubarray -= inputNumbers[tail];
                ++tail;
            }
            ++head;
        }
        return subarraysAverages;
    }
};
