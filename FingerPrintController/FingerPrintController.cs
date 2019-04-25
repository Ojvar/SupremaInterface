using System;
using System.IO;
using System.Linq;

using FingerPrintController.Agents;
using FingerPrintController.Extensions;
using FingerPrintController.Network;
using Suprema.SFM_SDK_NET;

namespace FingerPrintController
{
    public class FingerPrintController
    {
        #region Variables
        private static Agents.AgentsManager agentManger = new Agents.AgentsManager ();

        private static Network.NetListener listener = new Network.NetListener ();
        #endregion


        #region Constants
        public const string C_DEVICES_LIST = "GET_DEVICES";

        public const string C_ENROLL = "ENROLL";

        public const string C_IDENTIFY = "IDENTIFY";

        public const string C_IDENTIFY_TEMPLATE = "IDENTIFY_TEMPLATE";

        public const string C_ENROLL_TEMPLATE = "ENROLL_TEMPLATE";

        public const string C_READ_TEMPLATE = "READ_TEMPLATE";


        public const char C_SEPARATOR = '\n';
        #endregion


        #region Methods
        /// <summary>
        /// Start
        /// </summary>
        public static void
        start ()
        {
            #region 1- Config
            //  1-1 Load config
            loadConfig ();

            //  1-2 Setup MySql parametesr
            DBase.MySqlDBase.setup (ConfigHelper.configData.ip,
                                    ConfigHelper.configData.port,
                                    ConfigHelper.configData.database,
                                    ConfigHelper.configData.username,
                                    ConfigHelper.configData.password);

            #endregion


            #region 2- Prepare finger-prints agents
            agentManger.prepareAgents ();
            #endregion


            #region 3- Create a tcp-listener
            listener.start (ConfigHelper.configData.serverPort,
                            onServerDataReceived,
                            onServerClientDisconnected);
            #endregion
        }


        /// <summary>
        /// Stop
        /// </summary>
        public static void
        stop ()
        {
            agentManger.finishAll ();

            listener.stop ();
        }


        /// <summary>
        /// Load config file
        /// </summary>
        public static void
        loadConfig ()
        {
            string configPath = AppDomain.CurrentDomain.BaseDirectory;

            configPath = Path.Combine (configPath,
                                       "controller_config.json");


            ConfigHelper.load (configPath);
        }


        /// <summary>
        /// ON Server Client Disconnected
        /// </summary>
        private static void
        onServerClientDisconnected (NetServerClient sender)
        {
            //throw new NotImplementedException ();
        }


        /// <summary>
        /// On Server Data Received
        /// </summary>
        private static void
        onServerDataReceived (NetServerClient sender,
                              byte[] data,
                              int len)
        {
            string[] dataStr = data.toStringUTF8 ()
                                   .Split (C_SEPARATOR);

            if (dataStr.Length == 0)
            {
                return;
            }


            if (dataStr[0] == C_IDENTIFY_TEMPLATE)
            {
                doCommandIdentifyTemplate (dataStr,
                                           sender);
            }

            else if (dataStr[0] == C_ENROLL_TEMPLATE)
            {
                doCommandEnrollTemplate (dataStr,
                                         sender);
            }

            else if (dataStr[0] == C_READ_TEMPLATE)
            {
                doCommandReadTemplate (dataStr,
                                       sender);
            }

            else if (dataStr[0] == C_DEVICES_LIST)
            {
                doCommandDeviceList (dataStr,
                                     sender);
            }

            else if (dataStr[0] == C_ENROLL)
            {
                doCommandEnroll (dataStr,
                                 sender);
            }

            else if (dataStr[0] == C_IDENTIFY)
            {
                doCommandIdentify (dataStr,
                                   sender);
            }
        }


        #region Commands
        /// <summary>
        /// Do Command - Get Devices list
        /// </summary>
        /// <param name="dataStr"></param>
        private static void
        doCommandDeviceList (string[] dataStr,
                             NetServerClient sender)
        {
            string[] str = agentManger.getAgetns ()
                                      .Select (x => x.deviceModel.name)
                                      .ToArray ();

            string result = string.Join (C_SEPARATOR.ToString (),
                                         str);

            sender.write ($"{C_DEVICES_LIST}\n{result}");
        }


        /// <summary>
        /// Do Command - Identify by template
        /// </summary>
        /// <param name="dataStr"></param>
        private static void
        doCommandIdentifyTemplate (string[] dataStr,
                                   NetServerClient sender)
        {
            if (dataStr.Length != 3)
            {
                return;
            }


            string str = dataStr[1];
            byte[] data = Convert.FromBase64String (dataStr[2]);

            FingerPrintAgent agent = agentManger.getAgetns ()
                                                .Where (x => x.deviceModel.name == str)
                                                .FirstOrDefault ();

            Action<uint, byte> action = (userId, subId) =>
            {
                sender.write ($"{C_IDENTIFY_TEMPLATE}\n{userId}\n{subId}");
            };

            object[] obj = new object[]
                {
                    data,
                    action
                };

            agent?.runCommand (AgentsManager.EnumCommands.IdentifyTemplate,
                               obj);
        }


        /// <summary>
        /// Do Command - Enroll By Template
        /// </summary>
        /// <param name="dataStr"></param>
        private static void
        doCommandEnrollTemplate (string[] dataStr,
                                 NetServerClient sender)
        {
            if (dataStr.Length != 4)
            {
                return;
            }


            string str = dataStr[1];
            string uId = dataStr[2];
            byte[] data = Convert.FromBase64String (dataStr[3]);

            FingerPrintAgent agent = agentManger.getAgetns ()
                                                .Where (x => x.deviceModel.name == str)
                                                .FirstOrDefault ();

            Action<uint> action = (userId) =>
            {
                sender.write ($"{C_ENROLL_TEMPLATE}\n{userId}");
            };

            UF_ENROLL_OPTION options = UF_ENROLL_OPTION.UF_ENROLL_NONE;

            object[] obj = new object[]
                {
                    Convert.ToUInt32 (uId),
                    options,
                    data,
                    action
                };

            agent?.runCommand (AgentsManager.EnumCommands.EnrollTemplate,
                               obj);
        }


        /// <summary>
        /// Do Command - Read Template
        /// </summary>
        /// <param name="dataStr"></param>
        private static void
        doCommandReadTemplate (string[] dataStr,
                               NetServerClient sender)
        {
            if (dataStr.Length != 3)
            {
                return;
            }


            string str = dataStr[1];
            string uId = dataStr[2];

            FingerPrintAgent agent = agentManger.getAgetns ()
                                                .Where (x => x.deviceModel.name == str)
                                                .FirstOrDefault ();

            Action<uint, byte[]> action = (userId, data) =>
            {
                sender.write ($"{C_READ_TEMPLATE}\n{userId}\n{data.Length}\n{Convert.ToBase64String (data)}");
            };

            object[] obj = new object[]
                {
                    Convert.ToUInt32 (uId),
                    action
                };

            agent?.runCommand (AgentsManager.EnumCommands.ReadTemplate,
                               obj);
        }


        /// <summary>
        /// Do Command - Enroll
        /// </summary>
        /// <param name="dataStr"></param>
        private static void
        doCommandEnroll (string[] dataStr,
                         NetServerClient sender)
        {
            if (dataStr.Length != 4)
            {
                return;
            }


            string str = dataStr[1];
            string uId = dataStr[2];
            string sId = dataStr[3];

            FingerPrintAgent agent = agentManger.getAgetns ()
                                                .Where (x => x.deviceModel.name == str)
                                                .FirstOrDefault ();

            Action<uint, uint> action = (userId, subId) =>
            {
                sender.write ($"{C_ENROLL}\n{userId}\n{subId}");
            };

            object[] obj = new object[]
                {
                    Convert.ToUInt32 (uId),
                    Convert.ToByte (sId),
                    action
                };


            agent.runCommand (AgentsManager.EnumCommands.Enroll,
                              obj);
        }


        /// <summary>
        /// Do Command - Identify
        /// </summary>
        /// <param name="dataStr"></param>
        private static void
        doCommandIdentify (string[] dataStr,
                           NetServerClient sender)
        {
            if (dataStr.Length != 2)
            {
                return;
            }


            string str = dataStr[1];

            FingerPrintAgent agent = agentManger.getAgetns ()
                                                .Where (x => x.deviceModel.name == str)
                                                .FirstOrDefault ();

            Action<uint, byte> action = (userId, subId) =>
            {
                sender.write ($"{C_IDENTIFY}\n{userId}\n{subId}");
            };

            object[] obj = new object[]
                {
                       action
                };

            agent.runCommand (AgentsManager.EnumCommands.Identify,
                              obj);
        }
        #endregion

        #endregion
    }
}
