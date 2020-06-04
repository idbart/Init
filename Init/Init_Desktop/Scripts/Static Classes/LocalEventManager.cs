using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Init_Desktop.Scripts.Static_Classes
{
    public static class LocalEventManager
    {
        public static event Action TemplatesChanged;
        public static void OnTemplatesChanged()
        {
            TemplatesChanged?.Invoke();
        }

        public static event Action Loading;
        public static void OnLoading()
        {
            Loading?.Invoke();
        }
        public static event Action DoneLoading;
        public static void OnDoneLoading()
        {
            DoneLoading?.Invoke();
        }
    }
}
