using System;
using System.Collections.Generic;

namespace Try.Net50
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Record types

            NewSection("Record types");
            var record1 = new DummyRecord("ABC");
            var record2 = new DummyRecord("ABC");
            Console.WriteLine("record1.Equals(record2) " + record1.Equals(record2));
            Console.WriteLine("record1.GetHashCode() " + record1.GetHashCode() + " record2.GetHashCode()" + record2.GetHashCode());

            var subRecord = new DummySubRecord("ABC", "D", "E");
            Console.WriteLine("record1.Equals(subRecord) " + record1.Equals(subRecord));

            Console.WriteLine("subRecord.ToString() " + subRecord);

            var wow = new WoW("A", "B");
            var (a, b) = wow;
            Console.WriteLine("var wow = new WoW(\"A\", \"B\");  var (a, b) = wow; a:" + a + " b:" + b);

            var wow2 = wow with { BBB = "New B" };
            Console.WriteLine("vwow.ToString() " + wow.ToString());
            Console.WriteLine("var wow2 = wow with { BBB = \"New B\" }; wow2.ToString() " + wow2.ToString());

            Console.WriteLine("subRecord.GetType().IsAssignableTo(typeof(DummyRecord)) " + subRecord.GetType().IsAssignableTo(typeof(DummyRecord)));

            #endregion Record types

            #region Init only setters

            NewSection("Init only setters");

            var person = new Person
            {
                Name = "ABC"
            };

            Console.WriteLine(person.Name);

            #endregion Init only setters

            #region Pattern matching enhancements

            NewSection("Pattern matching enhancements");

            var isLetter = IsLetter('$');

            Console.WriteLine("IsLetter " + isLetter);

            var e = "ABC";

            if (e is not null)
            {
                Console.WriteLine("e is not null");
            }
            else
            {
                Console.WriteLine("e is null");
            }

            foreach (var item in new object[] { "ABC", 123, new Person { Name = "HAHA" }, new Person { Name = "WOWO" }, new Person { Name = "Somebody else" } })
            {
                switch (item)
                {
                    case string _:
                        Console.WriteLine("e is string");
                        break;

                    case int intE:
                        Console.WriteLine("e is int " + intE);
                        break;

                    case Person personE when personE.Name == "HAHA":
                        Console.WriteLine("e is Person " + personE.Name);
                        break;

                    case Person personD when personD.Name == "WOWO":
                        Console.WriteLine("e is Person " + personD.Name);
                        break;

                    case Person _:
                        Console.WriteLine("e is Person and not named as HAHA or WOWO");
                        break;
                }
            }

            #endregion Pattern matching enhancements

            #region Fit and finish features

            NewSection("Fit and finish features");

            List<int> list = new();

            Console.WriteLine("List<int> list = new(); " + (list is not null));

            HooHooHoo hoo = new("Hoo");

            Console.WriteLine("HooHooHoo hoo = new(\"Hoo\"); " + (hoo is not null));

            hoo.SayHiToPerson(new() { Name = "Mr. Curious" });

            #endregion Fit and finish features
        }

        static bool IsLetter(char c) => c is >= 'a' and <= 'z' or >= 'A' and <= 'Z';

        static void NewSection(string name)
        {
            Console.WriteLine(Environment.NewLine + $"/******************** {name} ********************/");
            Console.WriteLine();
        }
    }

    record DummyRecord
    {
        public string RecordType { get; set; }

        public DummyRecord(string recordType) => RecordType = recordType;
    }

    record DummySubRecord : DummyRecord
    {
        public string SubRecordType1 { get; set; }

        public string SubRecordType2 { get; set; }

        public DummySubRecord(string recordType, string subRecordType1, string subRecordType2)
            : base(recordType) => (SubRecordType1, SubRecordType2) = (subRecordType1, subRecordType2);

        public void SayHi()
        {
            Console.WriteLine(SubRecordType1);
        }
    }

    public record WoW(string AAA, string BBB);

    public struct Person
    {
        public string Name { get; init; }
    }

    class HooHooHoo
    {
        public HooHooHoo(string hoohoo)
        {
            Hoohoo = hoohoo;
        }

        public string Hoohoo { get; }

        public void SayHiToPerson(Person person)
        {
            Console.WriteLine("Hi " + person.Name);
        }
    }
}
