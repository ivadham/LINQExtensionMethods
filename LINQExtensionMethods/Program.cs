//Based of Every Single LINQ Extension Method With Examples by Amichai Mantinband: https://www.youtube.com/watch?v=7-P6Mxl5elg
using Dumpify; /* https://github.com/MoaidHathot/Dumpify */

#region Filtering
//Where
IEnumerable<int> col1 = [1, 2, 3, 4, 5];
col1.Where(x => x > 3).Dump();
IEnumerable<object> col2 = [1, "second", 3.33, 4, 5];
//OfType
col2.OfType<int>().Dump();
col2.OfType<string>().Dump();
col2.OfType<double>().Dump();
#endregion


#region Partitioning
//Skip and Take
IEnumerable<int> col3 = [5, 8, 4, 2, 9, 0];
col3.Skip(3).Dump();
col3.Take(4).Dump();
col3.SkipLast(2).Dump();
col3.TakeLast(4).Dump();
col3.SkipWhile(x => x > 3).Dump();
col3.TakeWhile(x => x > 4).Dump();
#endregion


#region Projection
//Select
IEnumerable<int> col4 = [1, 2, 3, 1, 1];
col4.Select(x => x == 2).Dump(); //Compare it with Where
col4.Select(x => x.ToString()).Dump();
col4.Select((x, i) => $"The index {i} has the value of: {x}").Dump();
//SelectMany
IEnumerable<List<int>> col5 = [[1, 2, 3, 1, 1], [3, 6, 5, 8], [0, 4, 8, 9]];
col5.SelectMany(x => x).Dump();
col5.SelectMany((x, i) => x.Select(x => $"The collection index {i} has a value of: {x}")).Dump();
//Cast
IEnumerable<object> col6 = [1, 2, 3, 4, 5];
col6.Cast<int>().Dump();
//Chunk
IEnumerable<int> col7 = [9, 8, 7, 6, 5, 4];
col7.Chunk(3).Dump(); //The opposite of SelectMany
col7.Chunk(3).SelectMany(x => x).Dump();
#endregion


#region Existence or Quantity Checks
IEnumerable<int> col8 = [1, 2, 3, 4, 5, 6];
//Any (Immediate Execution)
col8.Any(x => x > 3).Dump();
//All (Immediate Execution)
col8.All(x => x > 3).Dump();
//Contains (Immediate Execution)
col8.Contains(7).Dump();
#endregion


#region Sequence Manipulation
IEnumerable<int> col9 = [1, 2, 3, 4, 5, 6];
//Append
col9.Append(7).Dump();
//Prepend
col9.Prepend(0).Dump();
#endregion


#region Aggregation Methods
//Count (Immediate Execution)
IEnumerable<int> col10 = [3, 7, 2, 9, 5];
col10.Count().Dump(); //returns an int
//TryGetNonEnumeratedCount (Immediate Execution)
col10.TryGetNonEnumeratedCount(out var count1).Dump();
count1.Dump();
col10.Where(x => x > 2).TryGetNonEnumeratedCount(out var count2).Dump();
count2.Dump();
//Max [Min] (Immediate Execution)
col10.Max().Dump();
col10.Max(x => x * -1).Dump();
//MaxBy [MinBy] (Immediate Execution)
col10.MaxBy(x => x * -1).Dump();
/*  IEnumerable<Person> People = [new("You", 15), new("Me", 21)];
    People.Max(x => x.Age).Dump();
    People.MaxBy(x => x.Age).Dump();
    record Person(string Name, int Age); */
//Sum (Immediate Execution)
col10.Sum().Dump();
//Average (Immediate Execution)
col10.Average().Dump();
//LongCount (Immediate Execution)
col10.LongCount().Dump(); //returns a long
//Aggregate (Immediate Execution)
col10.Aggregate((x, y) => x + y).Dump(); //rewatch 18:32 to 21:43
#endregion


#region Element Operators
//First [Last] (Immediate Execution)
IEnumerable<int> col11 = [1, 2, 3, 4, 5];
col11.First().Dump();
//FirstOrDefault [LastOrDefault] (Immediate Execution)
IEnumerable<int> col12 = [];
col12.FirstOrDefault().Dump();
col12.FirstOrDefault(-1).Dump(); //Your specific default
//Single and SingleOrDefault (Immediate Execution)
IEnumerable<string> col13 = ["I single value"];
col13.SingleOrDefault().Dump();
//ElementAt and ElementAtOrDefault (Immediate Execution)
IEnumerable<int> col14 = [3, 4, 5];
col14.ElementAt(1).Dump();
//DefaultIfEmpty
col14.DefaultIfEmpty().Dump();
col12.DefaultIfEmpty().Dump();
#endregion


#region Methods
IEnumerable<int> col15 = [4, 5, 6];
//ToArray (Immediate Execution)
col15.ToArray().Dump();
//ToList (Immediate Execution)
col15.ToList().Dump();
//ToDictionary (Immediate Execution)
col15.ToDictionary(key => key, value => value * 3).Dump();
//ToHashSet (Immediate Execution) //rewatch
//ToLookUp (Immediate Execution) //rewatch
#endregion