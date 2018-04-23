Imports Microsoft.VisualBasic
Imports System
Imports System.Windows
Imports System.Windows.Controls

Namespace AgDataGrid_SelectRows
	Partial Public Class MainPage
		Inherits UserControl
		Public Sub New()
			InitializeComponent()
			grid.DataSource = ProductList.GetData()
		End Sub
		Private Sub SelectCompanies(ByVal minPrice As Double)
			grid.BeginUpdate()
			grid.ClearSelection()
			For i As Integer = 0 To grid.RowCount - 1
				Dim rowHandle As Integer = grid.GetRowHandleByVisibleIndex(i)
				If (Not grid.IsGroupRow(rowHandle)) Then
					Dim price As Double = CDbl(grid.GetCellValue(rowHandle, grid.Columns("UnitPrice")))
					If price = minPrice Then
						grid.SelectRow(rowHandle)
					End If
				End If
			Next i
			grid.EndUpdate()
		End Sub

		Private Sub Button_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
			Dim criteria As String = tbCriteria.Text
			Try
				Convert.ToDouble(criteria)
			Catch ex As FormatException
				MessageBox.Show("Invalid criteria. Please correct.", "Format Error", MessageBoxButton.OK)
				Return
			End Try
			SelectCompanies(Convert.ToDouble(criteria))
		End Sub
	End Class
End Namespace
