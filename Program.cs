using System;

public class Solution
{
    public void Merge<T>(T[] nums1, int m, T[] nums2, int n) where T : IComparable<T>
    {
        int i = m - 1;
        int j = n - 1;
        int k = m + n - 1;

        while (i >= 0 && j >= 0)
        {
            if (nums1[i].CompareTo(nums2[j]) >= 0)
            {
                nums1[k] = nums1[i];
                i--;
            }
            else
            {
                nums1[k] = nums2[j];
                j--;
            }
            k--;
        }

        while (j >= 0)
        {
            nums1[k] = nums2[j];
            j--;
            k--;
        }

        Console.WriteLine(string.Join(", ", nums1));
    }
}

class Program
{
    static void Main(string[] args)
    {
        Solution solution = new Solution();

        int[] nums1 = new int[] { 1, 2, 3, 0, 0, 0 };
        int[] nums2 = new int[] { 2, 5, 6 };
        solution.Merge(nums1, 3, nums2, 3);

        // Example with empty nums2 array
        int[] nums3 = new int[] { 1 };
        int[] nums4 = new int[] { };
        solution.Merge(nums3, 1, nums4, 0);

        // Example with empty nums1 array
        int[] nums5 = new int[] { 0 };
        int[] nums6 = new int[] { 1 };
        solution.Merge(nums5, 0, nums6, 1);
    }
}
