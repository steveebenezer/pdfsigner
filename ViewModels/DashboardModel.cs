using System.Collections.Generic;
using System.Collections.ObjectModel;
using PdfSigner.DataModel;

namespace PdfSigner.ViewModels
{
    public class DashboardViewModel : ViewModelBase
    {
        public void DashboardModel(IEnumerable<DocumentItem> items)
        {
            ListItems = new ObservableCollection<DocumentItem>(items);
        }

        public ObservableCollection<DocumentItem> ListItems { 
            get {return ListItems;} 
            set {ListItems = value;} 
        }
    }
}