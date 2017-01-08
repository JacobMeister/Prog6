using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Prog6_Eindopdracht.WPF1.Model
{
    public interface IDataService
    {
        void GetData(Action<DataItem, Exception> callback);
    }
}
