using System;
using System.IO;
using System.Linq;

using FingerPrintController.Agents;
using FingerPrintController.Network;

namespace FingerPrintController
{
    public class FingerPrinterController
    {
        #region Variables
        private static Agents.AgentsManager agentManger = new Agents.AgentsManager ();

        private static Network.NetListener listener = new Network.NetListener ();
        #endregion


        #region Constants
        public const string C_DEVICES_LIST = "GET_DEVICES";

        public const string C_ENROLL = "ENROLL";

        public const string C_IDENTIFY = "IDENTIFY";

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
            string[] dataStr = System.Text.Encoding.UTF8.GetString (data)
                                                        .Split (C_SEPARATOR);
            if (dataStr.Length == 0)
            {
                return;
            }


            if (dataStr[0] == C_DEVICES_LIST)
            {
                string[] str = agentManger.getAgetns ()
                                          .Select (x => x.deviceModel.name)
                                          .ToArray ();

                string result = string.Join (C_SEPARATOR.ToString (),
                                             str);

                byte[] byteData = System.Text.Encoding.UTF8.GetBytes (result);

                sender.write (byteData);
            }

            else if (dataStr[0] == C_ENROLL)
            {
                string str = dataStr[1];

                FingerPrintAgent agent = agentManger.getAgetns ()
                                                    .Where (x => x.deviceModel.name == str)
                                                    .FirstOrDefault ();

                Action<uint, uint> action = (userId, subId) =>
                {
                    sender.write ($"ENROLLED {userId}, {subId}");
                };

                object[] obj = new object[]
                    {
                        1,
                        0,
                       action
                    };


                agent.runCommand (AgentsManager.EnumCommands.Enroll,
                                  obj);
            }
            else if (dataStr[0] == C_IDENTIFY)
            {
                string str = dataStr[1];

                FingerPrintAgent agent = agentManger.getAgetns ()
                                                    .Where (x => x.deviceModel.name == str)
                                                    .FirstOrDefault ();

                Action<uint, byte> action = (userId, subId) =>
                {
                    sender.write ($"IDENTIFY {userId}, {subId}");
                };

                object[] obj = new object[]
                    {
                       action
                    };

                agent.runCommand (AgentsManager.EnumCommands.Identify,
                                  obj);
            }

            //throw new NotImplementedException ();
        }
        #endregion
    }
}
