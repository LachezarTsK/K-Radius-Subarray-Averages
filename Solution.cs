
using System;
using System.Collections.Generic;

public class Solution
{
    const int NOT_POSSIBLE_TO_CREATE_TARGET_SUBARRAY = -1;
    public int[] GetAverages(int[] inputNumbers, int radius)
    {
        if (radius == 0)
        {
            return inputNumbers;
        }

        int head = 0;
        int tail = 0;
        long sumTargetSubarray = 0;
        int[] subarraysAverages = new int[inputNumbers.Length];

        while (head < inputNumbers.Length)
        {

            sumTargetSubarray += inputNumbers[head];
            if (head - radius < 0 || head + radius > inputNumbers.Length - 1)
            {
                subarraysAverages[head] = NOT_POSSIBLE_TO_CREATE_TARGET_SUBARRAY;
            }
            if ((head - tail) == 2 * radius)
            {
                subarraysAverages[tail + radius] = (int)(sumTargetSubarray / (2 * radius + 1));
                sumTargetSubarray -= inputNumbers[tail];
                ++tail;
            }
            ++head;
        }
        return subarraysAverages;
    }
}
