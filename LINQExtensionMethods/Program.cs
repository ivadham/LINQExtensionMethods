//Based of Every Single LINQ Extension Method With Examples by Amichai Mantinband: https://www.youtube.com/watch?v=7-P6Mxl5elg
using Dumpify; /* https://github.com/MoaidHathot/Dumpify */

#region Filtering
//Where
IEnumerable<int> col1 = [1, 2, 3, 4, 5];
col1.Where(x => x > 3).Dump("Where");
IEnumerable<object> col2 = [1, "second", 3.33, 4, 5];
//OfType
col2.OfType<int>().Dump("OfType int");
col2.OfType<string>().Dump("OfType string");
col2.OfType<double>().Dump("OfType double");
#endregion


#region Partitioning
//Skip and Take
IEnumerable<int> col3 = [5, 8, 4, 2, 9, 0];
col3.Skip(3).Dump("Skip");
col3.Take(4).Dump("Take");
col3.SkipLast(2).Dump("SkipLast");
col3.TakeLast(4).Dump("TakeLast");
col3.SkipWhile(x => x > 3).Dump("SkipWhile");
col3.TakeWhile(x => x > 4).Dump("TakeWhile");
#endregion


#region Projection
//Select
IEnumerable<int> col4 = [1, 2, 3, 1, 1];
col4.Select(x => x == 2).Dump("Select"); //Compare it with Where
col4.Select(x => x.ToString()).Dump("Select");
col4.Select((x, i) => $"The index {i} has the value of: {x}").Dump("Select");
//SelectMany
IEnumerable<List<int>> col5 = [[1, 2, 3, 1, 1], [3, 6, 5, 8], [0, 4, 8, 9]];
col5.SelectMany(x => x).Dump("SelectMany");
col5.SelectMany((x, i) => x.Select(x => $"The collection index {i} has a value of: {x}")).Dump("SelectMany");
//Cast
IEnumerable<object> col6 = [1, 2, 3, 4, 5];
col6.Cast<int>().Dump("Cast");
//Chunk
IEnumerable<int> col7 = [9, 8, 7, 6, 5, 4];
col7.Chunk(3).Dump("Chunk"); //The opposite of SelectMany
col7.Chunk(3).SelectMany(x => x).Dump("SelectMany after Chunk");
#endregion


#region Existence or Quantity Checks
IEnumerable<int> col8 = [1, 2, 3, 4, 5, 6];
//Any (Immediate Execution)
col8.Any(x => x > 3).Dump("Any");
//All (Immediate Execution)
col8.All(x => x > 3).Dump("All");
//Contains (Immediate Execution)
col8.Contains(7).Dump("Contains");
#endregion


#region Sequence Manipulation
IEnumerable<int> col9 = [1, 2, 3, 4, 5, 6];
//Append
col9.Append(7).Dump("Append");
//Prepend
col9.Prepend(0).Dump("Prepend");
#endregion


#region Aggregation Methods
//Count (Immediate Execution)
IEnumerable<int> col10 = [3, 7, 2, 9, 5];
col10.Count().Dump("Count"); //returns an int
//TryGetNonEnumeratedCount (Immediate Execution)
col10.TryGetNonEnumeratedCount(out var count1).Dump("TryGetNonEnumeratedCount");
count1.Dump("TryGetNonEnumeratedCount result");
col10.Where(x => x > 2).TryGetNonEnumeratedCount(out var count2).Dump("TryGetNonEnumeratedCount");
count2.Dump("TryGetNonEnumeratedCount result");
//Max [Min] (Immediate Execution)
col10.Max().Dump("Max");
col10.Max(x => x * -1).Dump("Max with arg");
//MaxBy [MinBy] (Immediate Execution)
col10.MaxBy(x => x * -1).Dump("MaxBy");
IEnumerable<Person> People = [new("You", 15), new("Me", 21)];
People.Max(x => x.Age).Dump("Max of age");
People.MaxBy(x => x.Age * -1).Dump("Max of negative age");
//Sum (Immediate Execution)
col10.Sum().Dump("Sum");
//Average (Immediate Execution)
col10.Average().Dump("Average");
//LongCount (Immediate Execution)
col10.LongCount().Dump("LongCount"); //returns a long
//Aggregate (Immediate Execution)
col10.Aggregate((x, y) => x + y).Dump("Aggregate"); //rewatch 18:32 to 21:43
#endregion


#region Element Operators
//First [Last] (Immediate Execution)
IEnumerable<int> col11 = [1, 2, 3, 4, 5];
col11.First().Dump("First");
//FirstOrDefault [LastOrDefault] (Immediate Execution)
IEnumerable<int> col12 = [];
col12.FirstOrDefault().Dump("FirstOrDefault");
col12.FirstOrDefault(-1).Dump("FirstOrDefault with default -1"); //Your specific default
//Single and SingleOrDefault (Immediate Execution)
IEnumerable<string> col13 = ["I single value"];
col13.SingleOrDefault().Dump("SingleOrDefault");
//ElementAt and ElementAtOrDefault (Immediate Execution)
IEnumerable<int> col14 = [3, 4, 5];
col14.ElementAt(1).Dump("ElementAt");
//DefaultIfEmpty
col14.DefaultIfEmpty().Dump("DefaultIfEmpty");
col12.DefaultIfEmpty().Dump("DefaultIfEmpty");
#endregion


#region Methods
IEnumerable<int> col15 = [4, 5, 6];
//ToArray (Immediate Execution)
col15.ToArray().Dump("ToArray");
//ToList (Immediate Execution)
col15.ToList().Dump("ToList");
//ToDictionary (Immediate Execution)
col15.ToDictionary(key => key, value => value * 3).Dump("ToDictionary");
//ToHashSet (Immediate Execution) //rewatch
//ToLookUp (Immediate Execution) //rewatch
#endregion


#region Generation Methods
List<Person> col16 = [new("You", 15), new("Me", 16), new("Them", 21)];
col16.Dump("List");
//AsEnumerable
IEnumerable<Person> eoo16 = col16.AsEnumerable();
eoo16.Dump("AsEnumerable");
//AsQueryable
IQueryable<Person> qoo16 = col16.AsQueryable();
qoo16.Dump("AsQueryable");
//Range (Immediate Execution)
IEnumerable<int> col17 = Enumerable.Range(6, 5);
col17.Dump("Range");
//Repeat (Immediate Execution)
IEnumerable<int> col18 = Enumerable.Repeat(4, 10);
col18.Dump("Repeat");
//Empty (Immediate Execution)
IEnumerable<int> col19 = Enumerable.Empty<int>();
col19.Dump("Empty");
#endregion


#region Set Operations
IEnumerable<int> col20 = [3, 1, 2, 4, 2, 1];
//Distinct
col20.Distinct().Dump("Distinct");
//DistinctBy
//col20.DistinctBy(x => x.Id).Dump(); //To distinct properties of classes

//Union
IEnumerable<object> col21 = [1, 2, 3, "dog"];
IEnumerable<object> col22 = ["dog", "cow", 2, 3, 4];
col21.Union(col22).Dump("Union");
//Except
col21.Except(col22).Dump("Except (former | latter)");
col22.Except(col21).Dump("Except (latter | former)");
//Intersect
col21.Intersect(col22).Dump("Intersect");
IEnumerable<Customer> col23 = [new(0, "Barber", 43), new(1, "Nurse", 31)];
IEnumerable<Customer> col24 = [new(0, "Barber", 43), new(1, "Teacher", 16)];
//UnionBy
col23.UnionBy(col24, x => x.Id).Dump("UnionBy Id");
col23.UnionBy(col24, x => x.Name).Dump("UnionBy Name");
//ExceptBy
col23.ExceptBy(col24.Select(x => x.Name), y => y.Name).Dump("ExceptBy Name");
//IntersectBy
col23.IntersectBy(col24.Select(x => x.Name), y => y.Name).Dump("IntersectBy Name");
//SequenceEqual (Immediate Execution)
IEnumerable<int> col25 = [1, 2, 3];
IEnumerable<int> col26 = [1, 2, 3];
IEnumerable<int> col27 = [3, 2, 1];
IEnumerable<int> col28 = [1, 2, 3, 4];
col25.SequenceEqual(col26).Dump("SequenceEqual (equal)");
col26.SequenceEqual(col27).Dump("SequenceEqual (wrong order)");
col27.SequenceEqual(col28).Dump("SequenceEqual (not equal)");
#endregion


#region Joining & Grouping
IEnumerable<int> col29 = [3, 6, 9, 12];
IEnumerable<string> col30 = ["a", "b", "c"];
IEnumerable<string> col31 = ["*", "&"];
//Zip
col29.Zip(col30).Dump("Zip");
col29.Zip(col30, col31).Dump("Zip (two args)");
//Join
IEnumerable<Customer> col32 = [new(0, "You", 15), new(1, "She", 16)];
IEnumerable<Product> col33 = [new(0, "Shoes"), new(0, "Pantes"), new(1, "Glasses")];
col32.Join(col33,
    customer => customer.Id,
    product => product.CustomerId,
    (customer, product) => $"{customer.Name} bought {product.Name}").Dump("Join");
//GroupJoin
col32.GroupJoin(col33,
    customer => customer.Id,
    product => product.CustomerId,
    (customer, products) => $"{customer.Name} bought {string.Join(',', products)}").Dump("GroupJoin");
//Concat
IEnumerable<int> col34 = [1, 2, 3];
IEnumerable<int> col35 = [4, 5, 6, 7];
col34.Concat(col35).Dump("Concat");
//GroupBy
List<Person> col36 = [new("You", 15), new("Me", 16), new("Them", 16)];
col36.GroupBy(x => x.Age).Dump("GroupBy");
#endregion


#region Sorting
IEnumerable<int> col37 = [4, 1, 3, 2];
//Order
col37.Order().Dump("Order");
//OrderDescending
col37.OrderDescending().Dump("OrderDescending");
//Then
IEnumerable<Person> col38 = [new("Marry", 28), new("John", 25), new("Jim", 25)];
col38.OrderBy(x => x.Age).ThenBy(x => x.Name).Dump("OrderBy and Then");
//Reverse
col37.Reverse().Dump("Reverse");
#endregion


#region Classes
record Person(string Name, int Age);
record Customer(int Id, string Name, int Age);
record Product(int CustomerId, string Name);
#endregion