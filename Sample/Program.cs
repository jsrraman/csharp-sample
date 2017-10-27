using System;
using System.IO;

namespace Sample
{
    class Program
    {
        static void Main(string[] args)
        {
            CollegeStudent student = new CollegeStudent("Name 1");

            // v1.0
            //student.ValueChanged += new ValueChangedDelegate(OnValueChanged);
            //student.ValueChanged += new ValueChangedDelegate(OnValueChanged1);

            // v2.0
            student.ValueChanged += OnValueChanged;
            student.ValueChanged += OnValueChanged1;

            try
            {
                student.Age = 0;
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }

            student.Age = 37;
            student.Age = 40;

            // v1.0
            //TestWritingToAFileV1();

            // v2.0
            TestWritingToAFileV2();
        }

        private static void TestWritingToAFileV2()
        {
            CollegeStudent student = new CollegeStudent("Name 2");

            // Prefer using "using" block for unmanaged code block which uses IDisposable interface
            using (StreamWriter outputFile = File.CreateText("student.txt"))
            {
                student.WriteName(outputFile);
            }
        }

        private static void TestWritingToAFileV1()
        {
            CollegeStudent student = new CollegeStudent("Name 2");

            StreamWriter outputFile;
            outputFile = File.CreateText("student.txt");

            try
            {
                student.WriteName(outputFile);
            }
            finally
            {

                outputFile.Close();
            }
        }

        static void OnValueChanged(object sender, ValueChangedEventArgs args)
        {
            Console.WriteLine($"Value changing from {args.ExistingValue} to {args.NewValue}");
        }

        static void OnValueChanged1(object sender, ValueChangedEventArgs args)
        {
            Console.WriteLine("OnValueChanged");
        }

    }
}
