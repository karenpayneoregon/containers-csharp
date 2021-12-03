# About

`SortedList` Represents a collection of key/value pairs that are sorted by the keys and are accessible by key and by index.

Not something to use with a lot of data as per below, better to consider an array and use [Array.Sort](https://docs.microsoft.com/en-us/dotnet/api/system.array.sort?view=net-6.0) which has many overloads  including one that uses [IComparer Interface](https://docs.microsoft.com/en-us/dotnet/api/system.collections.icomparer?view=net-6.0).

---

Every time you insert an element, it first check if the array has enough capacity, if not, a bigger array is recreated and old elements are copied into it (like List<T>)

After that, it searches where to insert the element, using a binary search (this is possible since the array is indexable and already sorted).

That explains why performance of SortedList is so `bad` when you insert unsorted elements. It has to re-copy some elements almost every insertion. The only case it has not to be done is when the element has to be inserted at the end of the array.