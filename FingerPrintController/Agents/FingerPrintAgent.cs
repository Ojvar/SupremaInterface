using System;

using Suprema.SFM_SDK_NET;

namespace FingerPrintController.Agents
{
    public class FingerPrintAgent : IFingerPrint
    {
        #region Properties
        public Model.FingerPrintDevice deviceModel;

        public SupremaInterface.Suprema deviceAgent;
        #endregion


        #region Methods
        /// <summary>
        /// Ctr
        /// </summary>
        /// <param name="model"></param>
        public
        FingerPrintAgent (Model.FingerPrintDevice model)
        {
            this.deviceModel = model;

            this.deviceAgent = new SupremaInterface.Suprema ("DLL\\SFM_SDK.dll");
        }


        /// <summary>
        /// Connect
        /// </summary>
        public UF_RET_CODE
        connect (string host,
                 int port)
        {
            UF_RET_CODE result = deviceAgent.connect (host,
                                                      port);

            return result;
        }


        /// <summary>
        /// Connect
        /// </summary>
        public UF_RET_CODE
        connect (string serial,
                 int baudRate,
                 bool asciiMode = false)
        {
            UF_RET_CODE code = deviceAgent.connect (serial,
                                                    baudRate,
                                                    asciiMode);

            return code;
        }


        /// <summary>
        /// DisConnect
        /// </summary>
        public UF_RET_CODE
        disconnect ()
        {
            UF_RET_CODE result = deviceAgent.close ();

            return result;
        }


        /// <summary>
        /// Read a Template
        /// </summary>
        public UF_RET_CODE
        readTemplate (uint userId,
                      Action<uint, byte[]> callback)
        {
            uint tSize = deviceAgent.getTemplateSize ();

            uint numOfTemplate = 0;

            byte[] data = new byte[tSize];


            UF_RET_CODE result = deviceAgent.readTemplate (userId,
                                                           ref numOfTemplate,
                                                           data);

            callback?.Invoke (numOfTemplate,
                              data);

            return result;
        }


        /// <summary>
        /// Enroll
        /// </summary>
        public UF_RET_CODE
        enroll (uint userId,
                object options,
                Action<uint, uint> callback)
        {
            uint regUserId = 0;
            uint imageQuality = 0;

            UF_RET_CODE result = deviceAgent.enroll (userId,
                                                     (UF_ENROLL_OPTION)options,
                                                     ref regUserId,
                                                     ref imageQuality);

            callback?.Invoke (regUserId,
                              imageQuality);

            return result;
        }


        /// <summary>
        /// Enroll by template
        /// </summary>
        /// <param name="template"></param>
        public UF_RET_CODE
        enrollByTemplate (uint userId,
                          object option,
                          uint templateSize,
                          byte[] templateData,
                          Action<uint> callback)
        {
            uint enrolledUserId = 0;

            UF_ENROLL_OPTION options = (UF_ENROLL_OPTION)option;


            UF_RET_CODE result = deviceAgent.enroll (userId,
                                                     options,
                                                     templateSize,
                                                     templateData,
                                                     ref enrolledUserId);

            callback?.Invoke (enrolledUserId);

            return result;
        }


        /// <summary>
        /// Identify 
        /// </summary>
        public UF_RET_CODE
        identify (Action<uint, byte> callback)
        {
            uint userId = 0;

            byte subId = 0;

            UF_RET_CODE result = deviceAgent.identify (ref userId,
                                                       ref subId);


            callback?.Invoke (userId,
                              subId);


            return result;
        }


        /// <summary>
        /// Identify by template
        /// </summary>
        public UF_RET_CODE
        identifyByTemplate (uint templateSize,
                            byte[] templateData,
                            Action<uint, byte> callback)
        {
            uint userId = 0;

            byte subId = 0;

            UF_RET_CODE result = deviceAgent.identify (templateSize,
                                                       templateData,
                                                       ref userId,
                                                       ref subId);

            callback?.Invoke (userId,
                              subId);

            return result;
        }


        /// <summary>
        /// Run Command
        /// </summary>
        public object
        runCommand (AgentsManager.EnumCommands command,
                    object[] data)
        {
            switch (command)
            {
                case AgentsManager.EnumCommands.ReadTemplate:
                    if (data.Length == 2)
                    {
                        return readTemplate (Convert.ToUInt32 (data[0]),
                                             (Action<uint, byte[]>)data[1]);
                    }

                    return -1;


                case AgentsManager.EnumCommands.Enroll:
                    if (data.Length == 3)
                    {
                        UF_ENROLL_OPTION options = UF_ENROLL_OPTION.UF_ENROLL_NONE;

                        return enroll (Convert.ToUInt32 (data[0]),
                                       options,
                                       (Action<uint, uint>)data[2]);
                    }

                    return -1;


                case AgentsManager.EnumCommands.EnrollTemplate:
                    if (data.Length == 4)
                    {
                        byte[] template = (byte[])data[2];

                        return enrollByTemplate (Convert.ToUInt32 (data[0]),
                                                 data[1],
                                                 (uint)template.Length,
                                                 template,
                                                 (Action<uint>)data[3]);
                    }

                    return -1;


                case AgentsManager.EnumCommands.Identify:
                    if (data.Length == 1)
                    {
                        return identify ((Action<uint, byte>)data[0]);
                    }

                    return -1;


                case AgentsManager.EnumCommands.IdentifyTemplate:
                    if (data.Length == 2)
                    {
                        byte[] template = (byte[])data[0];

                        return identifyByTemplate ((uint)template.Length,
                                                   template,
                                                   (Action<uint, byte>)data[1]);
                    }

                    return -1;


                case AgentsManager.EnumCommands.Start:
                    if (data.Length == 2)
                    {
                        return connect (data[0].ToString (),
                                        Convert.ToInt32 (data[1]));
                    }
                    else if (data.Length == 3)
                    {
                        return connect (data[0].ToString (),
                                        Convert.ToInt32 (data[1]),
                                        Convert.ToBoolean (data[2]));
                    }

                    return -1;


                case AgentsManager.EnumCommands.Finish:
                    return disconnect ();
            }


            return null;
        }
        #endregion
    }
}
