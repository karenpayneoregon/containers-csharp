# About

Base class project setup for C#9, .NET Core 5


# Language extensions

</br>

:x:

:heavy_check_mark: 


## DateTimeExtensions.cs

| Method | Description| Immutable |
| :---   | :-- | :-- |
| PossibleTimeZones   | Get possible time zones for a DateTimeOffset | :heavy_check_mark: |
| Age   | Returns age from a date against the current date |  |
| Formatted   | Format a TimeSpan with AM PM |  |


## DictionaryExtensions.cs

| Method | Description| Immutable |
| :---   | :-- | :-- |
| RenameKey   | Rename key | :x: |
| TryAdd   | Method that attempts to add a key value pair in the dictionary for the specified key. |  |
| TryRemove   | Method that attempts to remove a key in the dictionary for the specified key. |  |


## Extensions.cs

*Some will be move to the above class*

| Method | Description| Immutable |
| :---   | :-- | :-- |
| ToYesNoString   | Convert bool to Yes or No |  |
| ContainsDuplicates   | Determine if there are duplicates in source IEnumerable&lt;T> |  |
| AddSafe   | Add KeyValue pair if key does not already exists in Dictionary |  |
|    | Dictionary&lt;string, TType> dictionary, string key, TType value |  |
|    | Dictionary&lt;int, TType> dictionary, string key, TType value |  |
|    | Dictionary&lt;decimal, TType> dictionary, string key, TType value |  |
|    | Dictionary&lt;DateTime, TType> dictionary, string key, TType value |  |
|  GetOrCreate  | Add key if not exists |  |
|  DataTableToList  | Convert DataTable to List of T |  |
|  GetLast  | Get last element in sequence |  |

## NumericArrays.cs

| Method | Description| Immutable |
| :---   | :-- | :-- |