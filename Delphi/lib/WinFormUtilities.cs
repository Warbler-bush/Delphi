using System;
using System.Windows.Forms;

namespace WinFormUtilities
{
    public class basicUtilities
    {
            public static Tuple<int, int> resizeTextBox(Control ctr)
            {
                int calculated = ctr.Text.Length / 26 * 19;
                if (calculated > ctr.Height)
                    ctr.Height = calculated;

                return Tuple.Create(ctr.Location.X - 3, ctr.Height + ctr.Location.Y+3);
            }


            
    }

}