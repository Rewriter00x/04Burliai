using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01Burliai.Models
{
    #region Enums
    enum WestZodiac
    {
        Capricorn,
        Aquarius,
        Pisces,
        Aries,
        Taurus,
        Gemini,
        Cancer,
        Leo,
        Virgo,
        Libra,
        Scorpio,
        Sagittarius,
    }

    enum ChineseZodiac
    {
        Monkey,
        Rooster,
        Dog,
        Pig,
        Rat,
        Oxen,
        Tiger,
        Rabbit,
        Dragon,
        Snake,
        Horse,
        Sheep,
    }
    #endregion

    class ZodiacSigns
    {
        #region Fields
        private DateTime? _date;
        private string _westZodiac;
        private string _chineseZodiac;
        #endregion

        #region Properties
        public DateTime? Date
        {
            get { return _date; }
            set { _date = value; }
        }

        public string WestZodiacSign
        {
            get { return _westZodiac; }
        }

        public string ChineseZodiacSign
        {
            get { return _chineseZodiac; }
        }

        public int Age
        {
            get
            {
                TimeSpan span = DateTime.Today - (Date ?? DateTime.Today); // Here Date will never be null
                if (span < TimeSpan.Zero) return 0;
                return (new DateTime(1, 1, 1) + span).Year - 1;
            }
        }
        #endregion

        private string NewWestZodiac()
        {
            switch (_date?.Month)
            {
                case 1:
                    if (_date?.Day < 21) return WestZodiac.Capricorn.ToString();
                    return WestZodiac.Aquarius.ToString();
                case 2:
                    if (_date?.Day < 20) return WestZodiac.Aquarius.ToString();
                    return WestZodiac.Pisces.ToString();
                case 3:
                    if (_date?.Day < 21) return WestZodiac.Pisces.ToString();
                    return WestZodiac.Aries.ToString();
                case 4:
                    if (_date?.Day < 20) return WestZodiac.Aries.ToString();
                    return WestZodiac.Taurus.ToString();
                case 5:
                    if (_date?.Day < 21) return WestZodiac.Taurus.ToString();
                    return WestZodiac.Gemini.ToString();
                case 6:
                    if (_date?.Day < 22) return WestZodiac.Gemini.ToString();
                    return WestZodiac.Cancer.ToString();
                case 7:
                    if (_date?.Day < 24) return WestZodiac.Cancer.ToString();
                    return WestZodiac.Leo.ToString();
                case 8:
                    if (_date?.Day < 24) return WestZodiac.Leo.ToString();
                    return WestZodiac.Virgo.ToString();
                case 9:
                    if (_date?.Day < 23) return WestZodiac.Virgo.ToString();
                    return WestZodiac.Libra.ToString();
                case 10:
                    if (_date?.Day < 23) return WestZodiac.Libra.ToString();
                    return WestZodiac.Scorpio.ToString();
                case 11:
                    if (_date?.Day < 23) return WestZodiac.Scorpio.ToString();
                    return WestZodiac.Sagittarius.ToString();
                case 12:
                    if (_date?.Day < 21) return WestZodiac.Sagittarius.ToString();
                    return WestZodiac.Capricorn.ToString();
                default:
                    return "";
            }
        }
        public void UpdateWestZodiac()
        {
            _westZodiac = NewWestZodiac();
        }

        private string NewChineseZodiac()
        {
            ChineseZodiac enumVar = (ChineseZodiac)(_date?.Year % 12);
            return enumVar.ToString();
        }

        public void UpdateChineseZodiac()
        {
            _chineseZodiac = NewChineseZodiac();
        }
    }

}
