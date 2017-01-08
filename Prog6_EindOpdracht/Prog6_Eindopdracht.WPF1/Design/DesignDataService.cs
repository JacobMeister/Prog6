using System;
using Prog6_Eindopdracht.WPF1.Model;

namespace Prog6_Eindopdracht.WPF1.Design
{
    public class DesignDataService : IDataService
    {
        public void GetData(Action<DataItem, Exception> callback)
        {
            // Use this to create design time data

            var item = new DataItem("Welcome to MVVM Light [design]");
            callback(item, null);
        }
    }
}