using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnLinqed
{
    public static class ArrayExtensions
    {
        public static T[] RemoveNulls<T>(this T[] array) where T : class
        {
            T[] temp = new T[array.Length];
            int c = 0;

            for(int i = 0; i < temp.Length; i++)
            {
                if(array[i] != null)
                {
                    temp[c++] = array[i];
                }
            }
            return temp.Left(c);
        }

        public static T[] Left<T>(this T[] array, int length) where T : class
        {
            T[] left = new T[length];

            Array.Copy(array, left, length);
            return left;
        }

        public static T[] Filter<T>(this T[] array, Func<T,bool> predicate) where T : class
        {
            T[] temp = new T[array.Length];
            int c = 0;

            for(int i = 0; i < array.Length; i++)
            {
                if (predicate(array[i]))
                    temp[c++] = array[i];
            }
            return temp.Left(c);
        }

        public static T[] Slice<T>(this T[] array, int start, int end)
        {
            if (start > end)
                throw new ArgumentOutOfRangeException("The start index is larger than the end index. ");
            T[] temp = new T[end - start];
            Array.Copy(array, start, temp, 0, end - start);
            return temp;
        }

        public static T[] SkipAndTake<T>(this T[] array, int skip, int take)
        {
            if (skip + take > array.Length)
                take = array.Length - skip;

            T[] temp = new T[take];
            Array.Copy(array, skip, temp, 0, take);
            return temp;
        }

    }
}
