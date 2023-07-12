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
using FluentFTP;
using FluentFTP.Exceptions;

namespace FTPklient_serwer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnPobierz_Click(object sender, RoutedEventArgs e)
        {
            string server = txtServer.Text;
            string username = txtLogin.Text;
            string password = txtHaslo.Text;
            string remoteFilePath = txtSciezkadoserwera.Text;
            string localFilePath = txtSciezkadokompa.Text;

            using (var ftpClient = new FtpClient(server, username, password))
            {
                    
                    try
                    { 
                        ftpClient.Connect();
                        ftpClient.DownloadFile(remoteFilePath, localFilePath);
                        MessageBox.Show("Plik został pobrany.");
                    }
                    catch (FtpCommandException ex)
                    {
                        MessageBox.Show($"Błąd pobierania pliku: {ex.Message}");
                    }
                    finally
                    {
                        ftpClient.Disconnect();
                    }
            }
            MessageBox.Show("Plik został pobrany.");
                    
        }

        private void btnWyslij_Click(object sender, RoutedEventArgs e)
        {
            string server = txtServer.Text;
            string username = txtLogin.Text;
            string password = txtHaslo.Text;
            string remoteFilePath = txtSciezkadoserwera.Text;
            string localFilePath = txtSciezkadokompa.Text;

            using (var ftpClient = new FtpClient(server, username, password))
            {
                try
                {
                    ftpClient.Connect();
                    ftpClient.UploadFile(localFilePath, remoteFilePath);
                    MessageBox.Show("Plik został wysłany.");
                }
                catch (FtpCommandException ex)
                {
                    MessageBox.Show($"Błąd wysyłania pliku: {ex.Message}");
                }
                finally
                {
                    ftpClient.Disconnect();
                }
            }
        }

        private void txtServer_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void btnSzukajserwer_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnSzukajlokalnie_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
