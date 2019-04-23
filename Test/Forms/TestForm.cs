using System;
using System.Net.Sockets;
using System.Threading;
using System.Windows.Forms;

using FingerPrintController;

namespace Test.Forms
{
    public partial class TestForm : Form
    {
        private TcpClient client = null;

        public TestForm ()
        {
            InitializeComponent ();



            startButton.Click += StartButton_Click;

            stopButton.Click += StopButton_Click;

            clientConnectButton.Click += ClientConnectButton_Click;

            clientDisconnectButton.Click += ClientDisconnectButton_Click;

            enrollButton.Click += EnrollComboBox_Click;

            identityButton.Click += IdentityButton_Click; ;
        }

        private void IdentityButton_Click (object sender, EventArgs e)
        {
            string msg =
               $"{FingerPrinterController.C_IDENTIFY}{FingerPrinterController.C_SEPARATOR}{devicesComboBox.Text}";

            write (client,
                   msg);
        }

        private void EnrollComboBox_Click (object sender, EventArgs e)
        {
            string msg =
                $"{FingerPrinterController.C_ENROLL}{FingerPrinterController.C_SEPARATOR}{devicesComboBox.Text}";

            write (client,
                   msg);
        }


        private void ClientDisconnectButton_Click (object sender, EventArgs e)
        {
            client?.GetStream ()?
                .Close ();

            client?.Close ();
        }

        private void ClientConnectButton_Click (object sender, EventArgs e)
        {
            client = new TcpClient ();
            client.Connect ("127.0.0.1", 10000);

            Thread thread = new Thread (() =>
            {
                while (client?.Connected == true)
                {
                    byte[] data = new byte[1024];

                    int len = client.GetStream ()
                                    .Read (data,
                                           0,
                                           data.Length);

                    if (len == 0)
                    {
                        return;
                    }

                    byte[] pureData = new byte[len];

                    Array.Copy (data,
                                pureData,
                                len);

                    log (System.Text.Encoding.UTF8.GetString (pureData));
                }
            });

            thread.Start ();

            write (client, FingerPrinterController.C_DEVICES_LIST);
        }

        private void log (string msg)
        {
            this.Invoke (new Action (() =>
            {
                logListBox.Items.Insert (0,
                                         msg);

                string[] data = msg.Split (FingerPrinterController.C_SEPARATOR);

                devicesComboBox.Items.Clear ();

                devicesComboBox.Items.AddRange (data);
            }));
        }

        private void write (TcpClient client, string msg)
        {
            byte[] data = System.Text.Encoding.UTF8.GetBytes (msg);

            client.GetStream ()
                .Write (data,
                        0,
                        data.Length);
        }

        private void StopButton_Click (object sender, EventArgs e)
        {
            FingerPrinterController.stop ();
        }

        private void StartButton_Click (object sender, EventArgs e)
        {
            FingerPrinterController.start ();
        }
    }
}
