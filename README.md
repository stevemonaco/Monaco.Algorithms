# Monaco.Algorithms
Collection of Reference Algorithms implemented in C#. Most implemented with generics where possible. Not intended for production use.

## Sorting Algorithms
* [Bubble Sort](Monaco.Algorithms/Sorting/BubbleSorter.cs)
* [Selection Sort](Monaco.Algorithms/Sorting/SelectionSorter.cs)
* [Merge Sort](Monaco.Algorithms/Sorting/MergeSorter.cs)
* [Quick Sort](Monaco.Algorithms/Sorting/QuickSorter.cs)

## Linear Algebra Algorithms
* [Principal Component Analysis](Monaco.Algorithms/LinearAlgebra/PrincipalComponentAnalyzer.cs)
* [Covariance Matrix](Monaco.Algorithms/Extensions/MatrixExtensions.cs)
* [Matrix Mean+Variance Standardization](Monaco.Algorithms/Extensions/MatrixExtensions.cs)

## Search Algorithms
* [Linear String Search](Monaco.Algorithms/Searching/LinearStringMatcher.cs)
* [Knuth-Morris-Pratt String Search](Monaco.Algorithms/Searching/KmpStringMatcher.cs)
* [Linear Search](Monaco.Algorithms/Searching/LinearSearch.cs)

## Sequence Algorithms
* [Longest Common Subsequence](Monaco.Algorithms/Sequences/LongestCommonSubsequence.cs) (Recursive, Bottom-Up, Top-Down implementations)
* [Longest Increasing Subsequence](Monaco.Algorithms/Sequences/LongestIncreasingSubsequence.cs)
* [Fisher-Yates Shuffle](Monaco.Algorithms/Extensions/ListExtensions.cs)

## Data Structures
* [Doubly Linked List](Monaco.Algorithms/Structures/DoublyLinkedList.cs)

## Miscellaneous
* [Internet Checksum](Monaco.Algorithms/Checksum/InternetChecksum.cs) (RFC1071)

## Dependencies
* Unit tests with NUnit
* Matrix operations supported by MathNET.Numerics
* Integration test data loading with CsvHelper
