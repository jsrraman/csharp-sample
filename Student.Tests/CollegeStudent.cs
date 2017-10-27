using System;
using System.IO;

namespace Sample
{
    public class CollegeStudent : Student
    {
        private string _name;
        private int _age;
        public event ValueChangedDelegate ValueChanged;

        public CollegeStudent(string name)
        {
            this._name = name;
        }

        public string Name
        {
            get { return _name; }
        }

        public int Age
        {
            get { return _age; }

            set
            {
                if (value == 0)
                {
                    throw new ArgumentException("age cannot be 0");
                }

                ValueChangedEventArgs args = new ValueChangedEventArgs
                {
                    ExistingValue = _age,
                    NewValue = value
                };

                ValueChanged(this, args);
                _age = value;
            }
        }

        public override void WriteName(TextWriter writer)
        {
            writer.Write(_name);
        }
    }
}
