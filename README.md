# FowleyList
## Remove() Method - C#
Removes the first occurrence of a specified object from the FowleyList<T> and returns a bool.

### Syntax
`public bool Remove(T item)`
For assignment to a variable:
`bool myVar = listName.Remove(T item)`

### Parameters
- `T item` - A single object of type T to remove from the FowleyList<T>.

### Return type

**Boolean**

Returns `true` if the item exists and is removed from the FowleyList<T>.
  
Returns `false` if the item does not exist or is not removed from the FowleyList<T>.

### Examples

1. Removing an item from a FowleyList<int>:
  
`FowleyList<int> myList = new FowleyList<int> {1, 2, 3};`

`myList.Remove(2);`

`foreach (int item in myList) {`

`  Console.WriteLine(item);`

`}`


`// Expected output:`

`// 1`

`// 3`


2. Assigning return type to a boolean variable:

`FowleyList<int> myList = new FowleyList<int> {1, 2, 3};`

`bool isRemoved = myList.Remove(4);`

`Console.WriteLine(isRemoved);`


`// Expected output:`

`// false`
