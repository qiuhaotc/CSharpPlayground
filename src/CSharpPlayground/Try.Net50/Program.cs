using System;

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

            #endregion Pattern matching enhancements

            // To be continue...
        }

        static bool IsLetter(char c) => c is >= 'a' and <= 'z' or >= 'A' and <= 'Z';

        static void NewSection(string name)
        {
            Console.WriteLine();
            Console.WriteLine("/**********************************************************/");
            Console.WriteLine(name);
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
}
