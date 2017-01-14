using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task04_LongestSubsequenceOfEquals
{
    public class SubsequenceFinder<T>
    {
        public Dictionary<T, int> CountItemAppearences(IList<T> list)
        {
            var dict = new Dictionary<T, int>();
            for (int i = 0; i < list.Count; i++)
            {
                if (dict.ContainsKey(list[i]))
                {
                    dict[list[i]]++;
                }
                else
                {
                    dict.Add(list[i], 1);
                }
            }
            return dict;
        }

        public IList<T> FindLongestSubsequenceOfEqualElements(IList<T> list)
        {
            IList<T> result = new List<T>();

            for (int index = 1, startPosition = 0; index < list.Count; index++)
            {
                if (list[index].Equals(list[index - 1]))
                {
                    continue;
                }
                else
                {
                    if (result.Count < index - startPosition)
                    {
                        result = GetSubSequence(list, startPosition, index);
                    }

                    startPosition = index;
                }
            }

            return result;
        }

        public IList<T> RemoveElementsThatOccureOddNumberOfTimes(IList<T> list)
        {
            var dict = CountItemAppearences(list);

            foreach (T key in dict.Keys)
            {
                if (dict[key] % 2 == 1)
                {
                    while (list.Contains(key))
                    {
                        list.Remove(key);
                    }
                }
            }

            return list;
        }

        private IList<T> GetSubSequence(IList<T> list, int start, int end)
        {
            IList<T> result = new List<T>();
            start = Math.Max(start, 0);
            end = Math.Min(end, list.Count);

            for (int i = start; i < end; i++)
            {
                result.Add(list[i]);
            }

            return result;
        }
    }
}