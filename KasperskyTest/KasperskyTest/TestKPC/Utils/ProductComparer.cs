using System;
using System.Collections;
using KasperskyTest.TestKPC.Models;

namespace KasperskyTest.TestKPC.Utils
{
    public class ProductComparer : IComparer
    {
        public int Compare(object x, object y)
        {
            var xProduct = x as Product;
            var yProduct = y as Product;
            if (xProduct == null || yProduct == null) throw new InvalidOperationException();
            return Compare(xProduct, yProduct);
        }

        public int Compare(Product x, Product y)
        {
            int temp = 0;
            if (x.Name.Equals(y.Name) & x.GetOptionsCount().Equals(y.GetOptionsCount()))
            {
                for (int i = 0; i < x.GetOptionsCount(); i++)
                {
                    if (x.Options[i].Devices.Equals(y.Options[i].Devices) &
                        x.Options[i].Year.Equals(y.Options[i].Year) &
                        x.Options[i].Cost.Equals(y.Options[i].Cost))
                    {
                        temp++;
                    }
                }
                if (temp == x.GetOptionsCount())
                {
                    return 0;
                }
            }
            return 1;
        }
    }
}
