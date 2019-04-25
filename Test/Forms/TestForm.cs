using System;
using System.Net.Sockets;
using System.Threading;
using System.Windows.Forms;

using FP = FingerPrintController;

namespace Test.Forms
{
    public partial class TestForm : Form
    {
        private TcpClient client = null;

        private uint userId
        {
            get
            {
                return (uint)userIdUpDown.Value;
            }
        }

        private byte subId = 0;

        private string tData = "";


        public TestForm ()
        {
            InitializeComponent ();



            startButton.Click += StartButton_Click;

            stopButton.Click += StopButton_Click;

            clientConnectButton.Click += ClientConnectButton_Click;

            clientDisconnectButton.Click += ClientDisconnectButton_Click;

            enrollButton.Click += EnrollComboBox_Click;

            identityButton.Click += IdentityButton_Click; ;

            readTemplateButton.Click += ReadTemplateButton_Click;

            enrollTemplateButton.Click += EnrollTemplateButton_Click;

            identifyTemplateButton.Click += IdentifyTemplateButton_Click; ;
        }

        private void IdentifyTemplateButton_Click (object sender, EventArgs e)
        {
            string msg =
                $"{FP.FingerPrintController.C_IDENTIFY_TEMPLATE}" +
                   $"{FP.FingerPrintController.C_SEPARATOR}{devicesComboBox.Text}" +
                   $"{FP.FingerPrintController.C_SEPARATOR}{tData}";

            write (client,
                   msg);
        }

        private void EnrollTemplateButton_Click (object sender, EventArgs e)
        {
            string msg =
                $"{FP.FingerPrintController.C_ENROLL_TEMPLATE}" +
                   $"{FP.FingerPrintController.C_SEPARATOR}{devicesComboBox.Text}" +
                   $"{FP.FingerPrintController.C_SEPARATOR}{userId}" +
                   $"{FP.FingerPrintController.C_SEPARATOR}{tData}";


            write (client,
                   msg);
        }

        private void ReadTemplateButton_Click (object sender, EventArgs e)
        {
            string msg =
                $"{FP.FingerPrintController.C_READ_TEMPLATE}" +
                   $"{FP.FingerPrintController.C_SEPARATOR}{devicesComboBox.Text}" +
                   $"{FP.FingerPrintController.C_SEPARATOR}{userId}";


            write (client,
                   msg);
        }

        private void IdentityButton_Click (object sender, EventArgs e)
        {
            string msg =
               $"{FP.FingerPrintController.C_IDENTIFY}{FP.FingerPrintController.C_SEPARATOR}{devicesComboBox.Text}";

            write (client,
                   msg);
        }

        private void EnrollComboBox_Click (object sender, EventArgs e)
        {
            string msg =
                $"{FP.FingerPrintController.C_ENROLL}" +
                    $"{FP.FingerPrintController.C_SEPARATOR}{devicesComboBox.Text}" +
                    $"{FP.FingerPrintController.C_SEPARATOR}{userId}" +
                    $"{FP.FingerPrintController.C_SEPARATOR}{subId}";

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

            write (client, FP.FingerPrintController.C_DEVICES_LIST);
        }

        private void log (string msg)
        {
            this.Invoke (new Action (() =>
            {
                logListBox.Items.Insert (0,
                                         msg);

                string[] data = msg.Split (FP.FingerPrintController.C_SEPARATOR);

                if (data[0] == FingerPrintController.FingerPrintController.C_DEVICES_LIST)
                {
                    devicesComboBox.Items.Clear ();

                    devicesComboBox.Items.AddRange (data);
                }
                else if (data[0] == FingerPrintController.FingerPrintController.C_READ_TEMPLATE)
                {
                    tData = data[3];
                }
                else if (data[0] == FingerPrintController.FingerPrintController.C_IDENTIFY_TEMPLATE)
                {
                }
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
            FP.FingerPrintController.stop ();
        }

        private void StartButton_Click (object sender, EventArgs e)
        {
            FP.FingerPrintController.start ();
        }
    }
}
