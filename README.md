# LFU Cache Implementation

## Overview 

A Least Frequently Used (LFU) Cache implementation in .NET that evicts items based on their usage frequency. Each cached item maintains a usage counter that increments upon access. When the cache reaches its capacity limit, it removes the item with the lowest usage count to free up space.

**Note:** This project has been updated to run on Linux using NUnit for testing and Visual Studio Code as the development environment.

## Installation 

Install via NuGet Package Manager:

```
Install-Package LfuCache -Version 1.0.0
```

## Usage Example

```csharp
ICache<string, string> cache = new LfuCache<string, string>(1000);
cache.Add("name", "Helene");
cache.Add("surname", "Stuart");
var name = cache.Get("name");
```

## Technical Implementation

The `LfuCache` class implements the `ICache` interface:

<img src="https://res.cloudinary.com/dbvcampra/image/upload/v1582909400/diagram_xkbden.png" />

### Data Structure

The implementation uses a hybrid data structure combining:
- A `SortedList` where the key is the usage count
- A `LinkedList` as the value, containing all elements with the same usage count

This structure is organized as a binary tree of linked lists, enabling O(log n) time complexity for both Add and Get operations.

<img width="800px" height="400px" src="https://res.cloudinary.com/dbvcampra/image/upload/v1556623202/binary_tree_linked_list_r9zgzj.jpg" />

## Performance

### Benchmark Results

The cache demonstrates impressive performance:
- 1,000,000 add/get operations
- Cache size: 90,000 items
- Dataset size: 100,000 elements
- Execution time: 466ms

<img src="http://res.cloudinary.com/dbvcampra/image/upload/v1469634935/lfu_syqnac.png" />

Compared to .NET Framework's MemoryCache, this implementation:
- Executes faster
- Uses less memory
- Maintains consistent performance

<img src="http://res.cloudinary.com/dbvcampra/image/upload/v1469634935/mc_ikzrsm.png" />

The benchmarks:
- Use randomly generated Add/Get operation sequences in `BitArray`
- Process elements from a fixed-size list
- Are conducted using [BenchmarkDotNet](https://benchmarkdotnet.org/)

<img src="https://res.cloudinary.com/dbvcampra/image/upload/v1556225816/benchmarks_gqqzru.png" />

## Testing

Unit tests are written using the NUnit framework with comprehensive code coverage tracked through Azure Pipeline.

<img src="https://res.cloudinary.com/dbvcampra/image/upload/v1556279286/code_coverage_lzv2si.png" />




