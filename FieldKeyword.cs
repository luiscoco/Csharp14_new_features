using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsharpVersion14Samples
{
    //----------------------------------------------------------------------------------------------------
    // 1. The 'field' keyword
    //
    //The token 'field' enables you to write a property accessor body without declaring an explicit backing field.
    //The token 'field' is replaced with a compiler synthesized backing field.
    //
    //Legacy code:
    //
    //private string _msg;
    //public string Message
    //{
    //    get => _msg;
    //    set => _msg = value ?? throw new ArgumentNullException(nameof(value));
    //}
    //
    //New code:
    //
    //public string Message
    //{
    //    get;
    //    set => field = value ?? throw new ArgumentNullException(nameof(value));
    //}
    //----------------------------------------------------------------------------------------------------

    public class Sensor
    {
        public double Temperature
        {
            get;
            set => field = (value < -273.15)
                ? throw new ArgumentOutOfRangeException(nameof(value), "Temperature cannot be below absolute zero.")
                : value;
        }
    }
}
