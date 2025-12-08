using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportovniKlub.Interfaces
{
    public interface INavigationService
    {
        //Treninky:
        void ShowTreninkyWindow();
        void ShowAddTreninkWindow();

        //Tymy:
        void ShowTymyWindow();
        void ShowAddTymyWindow();

        //Osoby:
        void ShowOsobyWindow();
        void ShowAddOsobyWindow();
    }
}
