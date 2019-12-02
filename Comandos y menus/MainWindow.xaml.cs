using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Collections.ObjectModel;

namespace Comandos_y_menus
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        ObservableCollection<TextBlock> lista;

        TextBlock itemCopiado;

        public MainWindow()
        {
            lista = new ObservableCollection<TextBlock>();
            InitializeComponent();
            ListaListBox.DataContext = lista;
        }

        private void CommandBinding_Executed_NUEVO(object sender, ExecutedRoutedEventArgs e)
        {
            TextBlock texto = new TextBlock();
            texto.Text = "Item añadido a las " + DateTime.Now.ToLongTimeString();
            lista.Add(texto);
        }

        private void CommandBinding_CanExecute_NUEVO(object sender, CanExecuteRoutedEventArgs e)
        {
            if(lista.Count < 10)
            {
                e.CanExecute = true;
            }
            else
            {
                e.CanExecute = false;
            }
        }

        private void CommandBinding_Executed_SALIR(object sender, ExecutedRoutedEventArgs e)
        {
            this.Close();
        }

        private void CommandBinding_CanExecute_SALIR(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void CommandBinding_Executed_VACIAR(object sender, ExecutedRoutedEventArgs e)
        {
            lista.Clear();
        }

        private void CommandBinding_CanExecute_VACIAR(object sender, CanExecuteRoutedEventArgs e)
        {
            if(lista.Count > 0)
            {
                e.CanExecute = true;
            }
        }

        private void CommandBinding_Executed_COPIAR(object sender, ExecutedRoutedEventArgs e)
        {
            itemCopiado = (TextBlock)ListaListBox.SelectedItem;
        }

        private void CommandBinding_CanExecute_COPIAR(object sender, CanExecuteRoutedEventArgs e)
        {
            if(lista.Count > 0 && ListaListBox.SelectedItem != null)
            {
                e.CanExecute = true;
            }
            else
            {
                e.CanExecute = false;
            }
        }

        private void CommandBinding_Executed_PEGAR(object sender, ExecutedRoutedEventArgs e)
        {
            TextBlock textoACopiar = new TextBlock();
            textoACopiar.Text = itemCopiado.Text;
            lista.Add(textoACopiar);
            itemCopiado = null;
        }

        private void CommandBinding_CanExecute_PEGAR(object sender, CanExecuteRoutedEventArgs e)
        {
            if(itemCopiado != null && lista.Count < 10)
            {
                e.CanExecute = true;
            }
            else
            {
                e.CanExecute = false;
            }
        }

    }
}
