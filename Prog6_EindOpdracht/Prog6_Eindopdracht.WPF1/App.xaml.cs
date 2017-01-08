using System.Windows;
using GalaSoft.MvvmLight.Threading;

namespace Prog6_Eindopdracht.WPF1
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        static App()
        {
            DispatcherHelper.Initialize();
        }
    }
}
