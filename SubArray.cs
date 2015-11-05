using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortApp
{
    public class MaxSubArray
    {
        public int lo;
        public int hi;
        public int max;
    }
    public class SubArray
    {
        public static MaxSubArray MaximumSub(int[] A)
        {
            return MaximumSub(A, 0, A.Length - 1);
        }


        private static MaxSubArray MaximumSub(int [] A, int lo, int hi)
        {
            if (hi == lo) return new MaxSubArray() { lo = lo, hi = hi, max= A[hi]};

            int mid = (lo + hi) / 2;
            MaxSubArray maxLeft = MaximumSub(A, lo, mid);
            MaxSubArray maxRight = MaximumSub(A, mid + 1, hi);
            MaxSubArray maxCross = MaximumSub(A, lo, mid, hi);

            if (maxLeft.max >= maxRight.max && maxLeft.max >= maxCross.max) return maxLeft;
            else if (maxRight.max >= maxLeft.max && maxRight.max >= maxCross.max) return maxRight;
            else
                return maxCross;
        }

        private static MaxSubArray MaximumSub(int[] A, int lo, int mid, int hi)
        {
            // Get Max Sub array for the left side
            int leftSum = Int32.MinValue;
            int sum = 0;
            int leftIndexMax = mid;
            for(int i = mid; i >= lo; i--)
            {
                sum += A[i];
                if(sum > leftSum)
                {
                    leftIndexMax = i;
                    leftSum = sum;
                }
            }
            // Get Max Sub array on the right side
            int rightSum = Int32.MinValue;
            sum = 0;
            int rightIndexMax = mid+1;
            for (int j = mid+1; j <= hi; j++)
            {
                sum += A[j];
                if (sum > rightSum)
                {
                    rightIndexMax = j;
                    rightSum = sum;
                }
            }

            // Combine and return
            return new MaxSubArray() { lo = leftIndexMax, hi = rightIndexMax, max = leftSum + rightSum };
        }
        
        public static int KadaneMaximumSub(int[] A)
        {
            int L = A.Length;

            int max_sofar = 0;
            int max_ending_here = 0;

            for(int i = 0; i < L; i++)
            {
                max_ending_here = Math.Max(0, max_ending_here+ A[i]);
                max_sofar = Math.Max(max_sofar, max_ending_here);
            }

            return max_sofar;
        }
        
    }
}
