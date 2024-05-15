

Solution solution = new Solution();
int[] nums1 = new int[] { 1, 2, 3, 0, 0, 0 };
int[] nums2 = new int[] { 2, 5, 6 };
solution.Merge(nums1, 3, nums2, 3);

// int[] nums1 = new int[] { 1 };
// int[] nums2 = new int[] { };
// solution.Merge(nums1, 1, nums2, 0);

// int[] nums1 = new int[] { 0 };
// int[] nums2 = new int[] { 1 };
// solution.Merge(nums1, 0, nums2, 1);


public class Solution
{
    public void Merge(int[] nums1, int m, int[] nums2, int n)
    {
        int arraySize = m + n;
        int num1pos = 0;
        int num2pos = 0;

        if (nums2.Length != 0)
        {

            int[] tempArray = new int[arraySize];
            for (int i = 0; i < arraySize; i++)
            {
                if ((nums1[num1pos] <= nums2[num2pos]) && num1pos < m)
                {
                    tempArray[i] = nums1[num1pos];
                    num1pos++;
                }
                else
                {
                    tempArray[i] = nums2[num2pos];
                    num2pos++;
                }
            }
            for (int i = 0; i < arraySize; i++)
            {
                nums1[i] = tempArray[i];
            }
        }
        Console.WriteLine(nums1.ToString());
        Array.ForEach(nums1, Console.WriteLine);
    }
}

