using System;
using System.Windows;
using System.Windows.Controls;

namespace AgDataGrid_SelectRows {
    public partial class MainPage : UserControl {
        public MainPage() {
            InitializeComponent();
            grid.DataSource = ProductList.GetData();
        }
        private void SelectCompanies(double minPrice) {
            grid.BeginUpdate();
            grid.ClearSelection();
            for (int i = 0; i < grid.RowCount; i++) {
                int rowHandle = grid.GetRowHandleByVisibleIndex(i);
                if (!grid.IsGroupRow(rowHandle)) {
                    double price = (double)grid.GetCellValue(rowHandle, grid.Columns["UnitPrice"]);
                    if (price == minPrice)
                        grid.SelectRow(rowHandle);
                }
            }
            grid.EndUpdate();
        }

        private void Button_Click(object sender, RoutedEventArgs e) {
            string criteria = tbCriteria.Text;
            try {
                Convert.ToDouble(criteria);
            }
            catch (FormatException ex) {
                MessageBox.Show("Invalid criteria. Please correct.", "Format Error", MessageBoxButton.OK);
                return;
            }
            SelectCompanies(Convert.ToDouble(criteria));
        }
    }
}
