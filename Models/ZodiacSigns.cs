using System;

namespace _01Burliai.Models
{
    #region Enums
    enum WestZodiac
    {
        Undefined = -1,
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
        Undefined = -1,
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
        private WestZodiac _westZodiac = WestZodiac.Undefined;
        private ChineseZodiac _chineseZodiac = ChineseZodiac.Undefined;
        #endregion

        #region Properties
        public DateTime? Date
        {
            get { return _date; }
            set { _date = value; }
        }

        public WestZodiac WestZodiacSign
        {
            get { return _westZodiac; }
        }

        public ChineseZodiac ChineseZodiacSign
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

        private WestZodiac NewWestZodiac()
        {
            switch (_date?.Month)
            {
                case 1:
                    return _date?.Day < 21 ? WestZodiac.Capricorn : WestZodiac.Aquarius;
                case 2:
                    return _date?.Day < 20 ? WestZodiac.Aquarius : WestZodiac.Pisces;
                case 3:
                    return _date?.Day < 21 ? WestZodiac.Pisces : WestZodiac.Aries;
                case 4:
                    return _date?.Day < 20 ? WestZodiac.Aries : WestZodiac.Taurus;
                case 5:
                    return _date?.Day < 21 ? WestZodiac.Taurus : WestZodiac.Gemini;
                case 6:
                    return _date?.Day < 22 ? WestZodiac.Gemini : WestZodiac.Cancer;
                case 7:
                    return _date?.Day < 24 ? WestZodiac.Cancer : WestZodiac.Leo;
                case 8:
                    return _date?.Day < 24 ? WestZodiac.Leo : WestZodiac.Virgo;
                case 9:
                    return _date?.Day < 23 ? WestZodiac.Virgo : WestZodiac.Libra;
                case 10:
                    return _date?.Day < 23 ? WestZodiac.Libra : WestZodiac.Scorpio;
                case 11:
                    return _date?.Day < 23 ? WestZodiac.Scorpio : WestZodiac.Sagittarius;
                case 12:
                    return _date?.Day < 21 ? WestZodiac.Sagittarius : WestZodiac.Capricorn;
                default:
                    return WestZodiac.Undefined;
            }
        }
        public void UpdateWestZodiac()
        {
            _westZodiac = NewWestZodiac();
        }

        private ChineseZodiac NewChineseZodiac()
        {
            if (_date == null)
                return ChineseZodiac.Undefined;
            return (ChineseZodiac)(_date?.Year % 12);
        }

        public void UpdateChineseZodiac()
        {
            _chineseZodiac = NewChineseZodiac();
        }
    }

}
