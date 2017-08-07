using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Dummy
{
    public class ValueGenerator
    {
        private Random random;


        // set of capital Characters.
        private int[] capitalLetters = new int[] { 65, 66, 67, 68, 69, 70, 71, 72, 73, 74, 75, 76, 77, 78, 79, 80, 81, 82, 83, 84, 85, 86, 87, 88, 89, 90 };

        // set of small characters.
        private int[] smallLetters = new int[] { 97, 98, 99, 100, 101, 102, 103, 104, 105, 106, 107, 108, 109, 110, 111, 112, 113, 114, 115, 116, 117, 118, 119, 120, 121, 122 };

        // 100 samples
        private string[] sampleNames = new string[] {"Sophia","Aiden","Emma","Jackson","Isabella","Mason","Olivia","Liam","Ava","Jacob","Lily","Jayden","Chloe","Ethan","Madison","Noah","Emily","Lucas","Abigail","Logan","Addison","Caleb","Mia","Caden","Madelyn","Jack","Ella","Ryan","Hailey","Connor","Kaylee","Michael","Avery","Elijah","Kaitlyn","Brayden","Riley","Benjamin","Aubrey","Nicholas","Brooklyn","Alexander","Peyton","William","Layla","Matthew","Hannah","James","Charlotte","Landon","Bella","Nathan","Natalie","Dylan","Sarah","Evan","Grace","Luke","Amelia","Andrew","Kylie","Gabriel","Arianna","Gavin","Anna","Joshua","Elizabeth","Owen","Sophie","Daniel","Claire","Carter","Lila","Tyler","Aaliyah","Cameron","Gabriella","Christian","Elise","Wyatt","Lillian","Henry","Samantha","Eli","Makayla","Joseph","Audrey","Max","Alyssa","Isaac","Ellie","Samuel","Alexis","Anthony","Isabelle","Grayson","Savannah","Zachary","Evelyn","David" };

        public ValueGenerator()
        {
            random = new Random();
        }

        public T Generate<T>(T tObject) where T : class
        {
            PropertyInfo[] _propInfoList = tObject.GetType().GetProperties();

            foreach (PropertyInfo _prop in _propInfoList)
            {
                if (!_prop.CanWrite)
                {
                    continue;
                }

                Type _propType = _prop.PropertyType;

                if (typeof(short).IsAssignableFrom(_propType) || typeof(short?).IsAssignableFrom(_propType))
                {
                    short _number = GenerateShortNumber();
                    _prop.SetValue(tObject, _number);
                }
                else if (typeof(int).IsAssignableFrom(_propType) || typeof(int?).IsAssignableFrom(_propType))
                {
                    int _number = GenerateIntNumber();
                    _prop.SetValue(tObject, _number);
                }
                else if (typeof(long).IsAssignableFrom(_propType) || typeof(long?).IsAssignableFrom(_propType))
                {
                    long _number = GenerateLongNumber();
                    _prop.SetValue(tObject, _number);
                }
                else if (typeof(double).IsAssignableFrom(_propType) || typeof(double?).IsAssignableFrom(_propType))
                {
                    double _number = GenerateDoubleNumber();
                    _prop.SetValue(tObject, _number);
                }
                else if (typeof(float).IsAssignableFrom(_propType) || typeof(float?).IsAssignableFrom(_propType))
                {
                    float _number = GenerateFloatNumber();
                    _prop.SetValue(tObject, _number);
                }
                else if (typeof(decimal).IsAssignableFrom(_propType) || typeof(decimal?).IsAssignableFrom(_propType))
                {
                    decimal _number = GenerateDecimalNumber();
                    _prop.SetValue(tObject, _number);
                }
                else if (typeof(string).IsAssignableFrom(_propType))
                {
                    string _stringValue = string.Empty;

                    if (_prop.Name.Contains("Name"))
                    {
                        _stringValue = GenerateRandomNames();
                    }
                    else
                    {
                        _stringValue = GenerateRandomString();
                    }

                    _prop.SetValue(tObject, _stringValue);
                }
                else if (typeof(DateTime).IsAssignableFrom(_propType) || typeof(DateTime?).IsAssignableFrom(_propType))
                {
                    DateTime _dateValue = RandomDate();
                    _prop.SetValue(tObject, _dateValue);
                }
                else if (typeof(Guid).IsAssignableFrom(_propType) || typeof(Guid?).IsAssignableFrom(_propType))
                {
                    Guid _value = Guid.NewGuid();
                    _prop.SetValue(tObject, _value);
                }
                else if (typeof(Enum).IsAssignableFrom(_propType) || typeof(Enum?).IsAssignableFrom(_propType))
                {
                    string[] _value = Enum.GetNames(_propType);

                    int _number = random.Next(0, _value.Length - 1);

                    Enum _enumValue = (Enum)Enum.Parse(_propType, _value[_number]);

                    _prop.SetValue(tObject, _enumValue);
                }

            }

            return tObject;
        }

        public DateTime RandomDate(DateTime? minValue = null, DateTime? maxValue = null)
        {
            DateTime _retVal = DateTime.MinValue;

            if(minValue != null)
            {

            }

            DateTime _minrange = new DateTime();
            DateTime _maxrange = new DateTime();

            int _year = random.Next(_minrange.Year, _maxrange.Year);
            int _month = random.Next(_minrange.Month, 12);
            //int _day = _random.Next(

            return _retVal;
        }

        public string GenerateRandomString(int maxlength = 50)
        {
            string _retVal = string.Empty;

            int _count = capitalLetters.Length + smallLetters.Length;


            for (int i = 0; i < maxlength; i++)
            {
                int _number = random.Next(0, _count - 1);

                if(_number > capitalLetters.Length - 1)
                {
                    _number = _number - capitalLetters.Length;

                     _retVal += Convert.ToChar(Convert.ToByte(smallLetters[_number]));
                }
                else
                {
                     _retVal += Convert.ToChar(Convert.ToByte(capitalLetters[_number]));
                }
            }

            return _retVal;
        }

        public string GenerateRandomNames()
        {
            string _retVal = string.Empty;

            string _guid = Guid.NewGuid().ToString();

            int _countNames = sampleNames.Length;

            int _choosen = random.Next(0, _countNames - 1);

            _retVal = string.Concat(sampleNames[_choosen],_guid);

            return _retVal;
        }

        public short GenerateShortNumber(short minNumber = -32768, short maxNumber = 32767)
        {
            short _retVal = 0;

            _retVal = (short)random.Next(minNumber, maxNumber);

            return _retVal;
        }

        public int GenerateIntNumber(int minNumber = -2147483648, int maxNumber = 2147483647)
        {
            int _retVal = 0;

            _retVal = random.Next(minNumber, maxNumber);

            return _retVal;

        }

        public long GenerateLongNumber()
        {
            long _retVal = 0;

            _retVal = random.Next(int.MinValue , int.MaxValue);

            return _retVal;
        }

        public double GenerateDoubleNumber(double minNumber = 1d, double maxNumber = 10000d)
        {
            double _retVal = 0;

            _retVal = random.Next((int)minNumber, (int)maxNumber);

            _retVal += random.NextDouble();

            return _retVal;
        }

        public float GenerateFloatNumber(float minNumber = 1f, float maxNumber = 10000f)
        {
            float _retVal = 0;

            _retVal = random.Next((int)minNumber, (int)maxNumber);

            _retVal = (float)random.NextDouble();

            return _retVal;
        }


        public decimal GenerateDecimalNumber(decimal minNumber = 1, decimal maxNumber = 10000)
        {
            decimal _retVal = 0;

            _retVal = random.Next((int)minNumber, (int)maxNumber);

            _retVal = (decimal)random.NextDouble();

            return _retVal;
        }

    }
}
