using System;


namespace Doroshenko01
{
    internal class User
    {
        private DateTime _birth;
        private readonly int _age;
        private string _chineZ;
        private string _westZ;

        internal int Age
        {
            get
            {
                return _age;
            }
        }

        internal string ChineseZodiac
        {
            get
            {
                return _chineZ;
            }
        }

        internal string WesternZodiac
        {
            get
            {
                return _westZ;
            }
        }

        internal User(DateTime date)
        {
            int d = (DateTime.Today - date).Days;
            int y = d / 365;
            if (y <= 110 && d >= 0)
            {
                _birth = date;
                _age = CalculateAge();
                CalcZodiacs();
            }
            else
                throw new Exception("Incorrect date of birth!");
        }
        

        private int CalculateAge()
        {
            DateTime today = DateTime.Today;
            return today.Year - _birth.Year - (today.DayOfYear < _birth.DayOfYear ? 1 : 0);
        }

        private void CalcZodiacs()
        {

            switch (_birth.Year % 12)
            {
                case 0:
                    _chineZ = "Monkey";
                    break;
                case 1:
                    _chineZ = "Rooster";
                    break;
                case 2:
                    _chineZ = "Dog";
                    break;
                case 3:
                    _chineZ = "Pig";
                    break;
                case 4:
                    _chineZ = "Rat";
                    break;
                case 5:
                    _chineZ = "Xx";
                    break;
                case 6:
                    _chineZ = "Tiger";
                    break;
                case 7:
                    _chineZ = "Rabbit";
                    break;
                case 8:
                    _chineZ = "Dragon";
                    break;
                case 9:
                    _chineZ = "Snake";
                    break;
                case 10:
                    _chineZ = "Horse";
                    break;
                case 11:
                    _chineZ = "Sheep";
                    break;
                default:
                    throw new ArgumentException();
            }

            switch (_birth.Month)
            {
                case 1:
                    _westZ = _birth.Day <= 19 ? "Capricorn" : "Aquarius";
                    break;
                case 2:
                    _westZ = _birth.Day <= 17 ? "Aquarius" : "Pisces";
                    break;
                case 3:
                    _westZ = _birth.Day <= 19 ? "Pisces" : "Aries";
                    break;
                case 4:
                    _westZ = _birth.Day <= 19 ? "Aries" : "Taurus";
                    break;
                case 5:
                    _westZ = _birth.Day <= 20 ? "Taurus" : "Gemini";
                    break;
                case 6:
                    _westZ = _birth.Day <= 20 ? "Gemini" : "Cancer";
                    break;
                case 7:
                    _westZ = _birth.Day <= 22 ? "Cancer" : "Leo";
                    break;
                case 8:
                    _westZ = _birth.Day <= 22 ? "Leo" : "Virgo";
                    break;
                case 9:
                    _westZ = _birth.Day <= 22 ? "Virgo" : "Libra";
                    break;
                case 10:
                    _westZ = _birth.Day <= 22 ? "Libra" : "Scorpio";
                    break;
                case 11:
                    _westZ = _birth.Day <= 21 ? "Scorpio" : "Sagittarius";
                    break;
                case 12:
                    _westZ = _birth.Day <= 21 ? "Sagittarius" : "Capricorn";
                    break;
                default:
                    throw new ArgumentException();
            }

           
        }
    }
}
