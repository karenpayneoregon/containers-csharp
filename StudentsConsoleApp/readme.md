Sometimes wrong choices (see this [post](https://stackoverflow.com/questions/70244889/how-to-sort-list-by-containing-text-using-linq)) are made, for example a developer wants to sort on surname and has

```csharp
List<Student> students = new List<Student>()
            {
               new Student("John Doe"),
               new Student("Lucy Novak")
            };
```

What happens with a last name like `Atkinson Lloyd`?

One must a) consider requirements b) perform roboust unit testing.

Perhaps we need the following and even have a middle name too.

```csharp
class Student
{
    public string Name { get; set; }
    public string SurName { get; set; }
    public override string ToString() => $"{Name} {SurName}";
}
```
