using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace listViewControl
{
    public class VM : ObservableObject
    {
        private ObservableCollection<string> _collection;

        public ObservableCollection<string> Collection 
        { 
            get => _collection;
            set => SetProperty(ref _collection, value);
        }

        public VM()
        {
            Collection = new ObservableCollection<string>();
            for (int i = 0; i < 25; i++) 
            { 
                _collection.Add($"Item {i}");
            }
        }
    }
}
