﻿using System;
using System.Collections;

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

        public static T[] RemoveItem<T>(this T[] array, T item) where T : class
        {
            T[] temp = new T[array.Length];
            int c = 0;

            for(int i = 0; i < temp.Length; i++)
            {
                if(array[i] != item)
                {
                    temp[c++] = array[i];
                }
            }
            return temp.Left(c);
        }

        public static T[] RightTrimNulls<T>(this T[] array) where T : class
        {
            int len = array.Length;
            for(int i = len - 1; i >= 0 && array[i] == null; i-- )
                len--;
            return array.Left(len);
        }


        public static T[] Left<T>(this T[] array, int length) where T : class
        {
            int size = Math.Min(length, array.Length);
            T[] left = new T[size];

            Array.Copy(array, left, size);
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

        //public static T[] Slice<T>(this T[] array, int start, int end)
        //{
        //    if (start > end)
        //        throw new ArgumentOutOfRangeException("The start index is larger than the end index. ");
        //    T[] temp = new T[end - start];
        //    Array.Copy(array, start, temp, 0, end - start);
        //    return temp;
        //}

        public static T[] SkipAndTake<T>(this T[] array, int skip, int take)
        {
            if (skip + take > array.Length)
                take = array.Length - skip;

            T[] temp = new T[take];
            Array.Copy(array, skip, temp, 0, take);
            return temp;
        }

        public static T[] Sort<T>(this T[] array, Comparison<T> comparison)
        {
            T[] sorted = new T[array.Length];

            Array.Copy(array, sorted, array.Length);
            Array.Sort<T>(sorted, comparison);
            return sorted;
        }

        public static int IndexOf<T>(this T[] array, Func<T,bool> predicate)
        {
            int index = -1;
            for(int i = 0; i < array.Length; i++)
            {
                if(predicate(array[i]))
                {
                    index = i;
                    break;
                }
            }
            return index;
        }

        public static int IndexOf<T>(this T[] array, T value)
        {
            int index = -1;
            for(int i = 0; i < array.Length; i++)
            {
                if(value.Equals(array[i]))
                {
                    index = i;
                    break;
                }
            }
            return index;
        }
    }
}
