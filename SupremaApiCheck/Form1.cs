using System;
using System.IO;
using System.Windows.Forms;
using Suprema.SFM_SDK_NET;

namespace SupremaApiCheck
{
    public partial class Form1 : Form
    {
        private SupremaInterface.Suprema suprema = new SupremaInterface.Suprema ("DLL\\SFM_SDK.dll");

        private uint C_USER_ID = 1;

        private byte[] savedTemplate = null;



        /// <summary>
        /// Ctr
        /// </summary>
        public
        Form1 ()
        {
            InitializeComponent ();

            init ();
        }


        /// <summary>
        /// Init
        /// </summary>
        private void
        init ()
        {
            connectButton.Click += (s, e) => connect ();
            disconnectButton.Click += (s, e) => disconnect ();
            enrollButton.Click += (s, e) => enroll ();
            identityButton.Click += (s, e) => identify ();
            readTemplateButton.Click += (s, e) => readTemplate ();
            identityTemplateButton.Click += (s, e) => identifyTemplate ();
            deleteButton.Click += (s, e) => deleteUser ();
            deleteAllButton.Click += (s, e) => deleteAll ();
        }


        /// <summary>
        /// Delete user
        /// </summary>
        private void
        deleteAll()
        {
            suprema.deleteAll ();


            string msg = $"Delete all users";

            log (msg);
        }


        /// <summary>
        /// Delete user
        /// </summary>
        private void
        deleteUser ()
        {
            suprema.delete (C_USER_ID);


            string msg = $"Delete user";

            log (msg);
        }


        /// <summary>
        /// Identify Template
        /// </summary>
        private void
        identifyTemplate ()
        {
            uint userId = 0;
            byte subId = 0;

            suprema.identify ((uint)savedTemplate.Length,
                              savedTemplate,
                              ref userId,
                              ref subId);


            string msg = $"Template Identified, UserId: {userId}, SubId: {subId}";

            log (msg);
        }


        /// <summary>
        /// Read user template
        /// </summary>
        private void
        readTemplate ()
        {
            uint tmpSize = suprema.getTemplateSize ();

            byte[] data = new byte[tmpSize];

            uint numOfTemplates = 0;

            suprema.readTemplate (C_USER_ID,
                                  ref numOfTemplates,
                                  data);

            savedTemplate = data;
        }


        /// <summary>
        /// Identify
        /// </summary>
        private void
        identify ()
        {
            uint userId = 0;
            byte subId = 0;


            suprema.identify (ref userId,
                              ref subId);


            string msg = $"Identified as UserId:{userId}, SubId: {subId}";

            log (msg);
        }


        /// <summary>
        /// Enroll
        /// </summary>
        private void
        enroll ()
        {
            uint newUserId = 0;
            uint imageQuality = 0;


            suprema.enroll (C_USER_ID,
                            UF_ENROLL_OPTION.UF_ENROLL_NONE,
                            ref newUserId,
                            ref imageQuality);


            string msg = $"Enroll user 1 & Returned Id: {newUserId}, Image Quality: {imageQuality}";

            log (msg);
        }


        /// <summary>
        /// DisConnect 
        /// </summary>
        private void
        disconnect ()
        {
            suprema.close ();


            string msg = "DisConnect";

            log (msg);
        }


        /// <summary>
        /// Connect 
        /// </summary>
        private void
        connect ()
        {
            string data = File.ReadAllText (@"Config\config.json");

            SupremaInterface.Suprema.DeviceConfigModel model =
                SupremaInterface.Suprema.DeviceConfigModel.loadConfig (data);

            suprema.connect (model.ip,
                             model.port);


            string msg = "Connect";

            log (msg);
        }



        /// <summary>
        /// Log
        /// </summary>
        /// <param name="msg"></param>
        private void
        log (string msg)
        {
            outputListBox.Items.Insert (0,
                                        msg);
        }
    }
}
