
public class Solution {

    private static final int NOT_POSSIBLE_TO_CREATE_TARGET_SUBARRAY = -1;

    public int[] getAverages(int[] nums, int radius) {
        if (radius == 0) {
            return nums;
        }

        int head = 0;
        int tail = 0;
        long sumTargetSubarray = 0;
        int[] subarraysAverages = new int[nums.length];

        while (head < nums.length) {

            sumTargetSubarray += nums[head];
            if (head - radius < 0 || head + radius > nums.length - 1) {
                subarraysAverages[head] = NOT_POSSIBLE_TO_CREATE_TARGET_SUBARRAY;
            }
            if ((head - tail) == 2 * radius) {
                subarraysAverages[tail + radius] = (int) (sumTargetSubarray / (2 * radius + 1));
                sumTargetSubarray -= nums[tail];
                ++tail;
            }
            ++head;
        }
        return subarraysAverages;
    }
}
