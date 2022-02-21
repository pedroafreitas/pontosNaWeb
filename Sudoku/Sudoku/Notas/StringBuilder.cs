using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace Sudoku.Notas
{
    public class StringBuilderNotes
    {
        static public void LeassonStringBuilder()
        {
            //String builder:
            /*
             * String builder is a class witch tries to solve the string object memory allocation problem in c#.
             * Why? Because everytime a string is created in c# or modified, a new place in memory is allocated for
             * this purpose. This is not a problem with stringbuilder since it works dynamically.
             */
            System.Text.StringBuilder string1 = new();
            Console.WriteLine("String1: " + TestSize<StringBuilder>.SizeOf(string1));
            for (int i = 0; i < 10000; i++)
            {
                string1.Append(" texto");

            }
            Console.WriteLine("String1: " + TestSize<StringBuilder>.SizeOf(string1));


            //This is bad and costly
            string string2 = "texto";
            Console.WriteLine("String2: " + TestSize<String>.SizeOf(string2));
            for (int i = 0; i < 10000; i++)
            {
                string2 += " texto";
            }
            Console.WriteLine("String2: " + TestSize<String>.SizeOf(string2));
        }
    }
    
    class TestSize<T>
    {
        static private int SizeOfObj(Type T, object thevalue)
        {
            var type = T;
            int returnval = 0;
            if (type.IsValueType)
            {
                var nulltype = Nullable.GetUnderlyingType(type);
                returnval = System.Runtime.InteropServices.Marshal.SizeOf(nulltype ?? type);
            }
            else if (thevalue == null)
                return 0;
            else if (thevalue is string)
                returnval = Encoding.Default.GetByteCount(thevalue as string);
            else if (type.IsArray && type.GetElementType().IsValueType)
            {
                returnval = ((Array) thevalue).GetLength(0) *
                            System.Runtime.InteropServices.Marshal.SizeOf(type.GetElementType());
            }
            else if (thevalue is Stream)
            {
                Stream thestram = thevalue as Stream;
                returnval = (int) thestram.Length;
            }
            else if (type.IsSerializable)
            {
                try
                {
                    using (Stream s = new MemoryStream())
                    {
                        BinaryFormatter formatter = new BinaryFormatter();
                        formatter.Serialize(s, thevalue);
                        returnval = (int) s.Length;
                    }
                }
                catch
                {
                }
            }
            else
            {
                var fields = type.GetFields(System.Reflection.BindingFlags.NonPublic |
                                            System.Reflection.BindingFlags.Instance);
                for (int i = 0; i < fields.Length; i++)
                {
                    Type t = fields[i].FieldType;
                    Object v = fields[i].GetValue(thevalue);
                    returnval += 4 + SizeOfObj(t, v);
                }
            }

            if (returnval == 0)
                try
                {
                    returnval = System.Runtime.InteropServices.Marshal.SizeOf(thevalue);
                }
                catch
                {
                }

            return returnval;
        }

        static public int SizeOf(T value)
        {
            return SizeOfObj(typeof(T), value);
        }
    }
}