using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace listViewControl
{
    /// <summary>
    /// Логика взаимодействия для CustomListView.xaml
    /// </summary>
    public partial class CustomListView : UserControl
    {


        public IEnumerable<object> ItemsSource
        {
            get { return (IEnumerable<object>)GetValue(ItemsSourceProperty); }
            set { SetValue(ItemsSourceProperty, value); }
        }
        public static readonly DependencyProperty ItemsSourceProperty =
            DependencyProperty.Register(
                nameof(ItemsSource), 
                typeof(IEnumerable<object>), 
                typeof(CustomListView));



        public object SelectedItem
        {
            get { return (object)GetValue(SelectedItemProperty); }
            set { SetValue(SelectedItemProperty, value); }
        }

        public static readonly DependencyProperty SelectedItemProperty =
            DependencyProperty.Register(nameof(SelectedItem), typeof(object), typeof(UserControl));



        public double ItemHeight
        {
            get { return (double)GetValue(ItemHeightProperty); }
            set { SetValue(ItemHeightProperty, value); }
        }

        public static readonly DependencyProperty ItemHeightProperty =
            DependencyProperty.Register(nameof(ItemHeight), typeof(double), typeof(UserControl));

        public double ItemWidth
        {
            get { return (double)GetValue(ItemWidthProperty); }
            set { SetValue(ItemWidthProperty, value); }
        }

        public static readonly DependencyProperty ItemWidthProperty =
            DependencyProperty.Register(nameof(ItemWidth), typeof(double), typeof(UserControl));




        private int selectedIndex;

        public CustomListView()
        {
            InitializeComponent();
        }

        private async void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selectedIndex = ListView.SelectedIndex;
        }

        private void ListView_PreviewMouseWheel(object sender, MouseWheelEventArgs e)
        {
            if (e.Delta > 0)
            {
                if (selectedIndex != 0)
                {
                    selectedIndex--;
                    SelectedItem = ItemsSource.ElementAt(selectedIndex);
                }
            }
            else
            {
                if (selectedIndex < ItemsSource.Count() - 1)
                {
                    selectedIndex++;
                    SelectedItem = ItemsSource.ElementAt(selectedIndex);
                }
            }
            ListView.ScrollIntoView(SelectedItem);
            e.Handled = true;
        }
    }
}
