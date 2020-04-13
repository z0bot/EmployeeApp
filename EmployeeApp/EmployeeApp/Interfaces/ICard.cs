using System;
using System.Collections.Generic;
using System.Text;

using Xamarin.Forms;


namespace EmployeeApp
{
    public interface ICard
    {
        void StartRead();

        bool ReadSuccesful();

        bool IsExpiryValid();
        string GetCardNum();

        string GetCardName();

        string GetCardCvv();
    }
}
