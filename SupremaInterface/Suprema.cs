using System;
using Newtonsoft.Json;
using Suprema.SFM_SDK_NET;

namespace SupremaInterface
{
    public class Suprema
    {
        #region Variables
        public static uint C_TEMPLATE_SIZE = 384;

        private SFM_SDK_NET supremaEngine = null;
        #endregion


        #region Methods
        #region Base Class Methods
        /// <summary>
        /// Ctr
        /// </summary>
        public
        Suprema (string path = null)
        {
            if (null == path)
            {
                supremaEngine = new SFM_SDK_NET ();
            }
            else
            {
                supremaEngine = new SFM_SDK_NET (path);
            }
        }

        /// <summary>
        /// DCtr
        /// </summary>
        ~Suprema ()
        {
            close ();
        }
        #endregion


        #region Properties Methods
        /// <summary>
        /// Get template size
        /// </summary>
        public uint
        getTemplateSize ()
        {
            uint result = 0;

            supremaEngine.UF_GetSysParameter (UF_SYS_PARAM.UF_SYS_TEMPLATE_SIZE,
                                              ref result);

            return result;
        }
        #endregion


        #region Connection Methods
        /// <summary>
        /// Connect (Over Socket)
        /// </summary>
        /// <returns></returns>
        public UF_RET_CODE
        connect (string commPort,
                 int baudRate,
                 bool asciiMode = false)
        {
            UF_RET_CODE result = supremaEngine.UF_InitCommPort (commPort,
                                                                baudRate,
                                                                asciiMode);

            return result;
        }


        /// <summary>
        /// Connect (Over Network)
        /// </summary>
        /// <returns></returns>
        public UF_RET_CODE
        connect (string ip,
                 int port)
        {
            UF_RET_CODE result = supremaEngine.UF_InitSocket (ip,
                                                              port,
                                                              false);

            return result;
        }


        /// <summary>
        /// Clsoe
        /// </summary>
        public UF_RET_CODE
        close ()
        {
            UF_RET_CODE result;

            try
            {
                result = supremaEngine.UF_CloseCommPort ();

                result = supremaEngine.UF_CloseSocket ();
            }
            catch (Exception)
            {
                result = UF_RET_CODE.UF_ERR_UNKNOWN;
            }


            return result;
        }
        #endregion


        #region Enrolling Methods
        /// <summary>
        /// Enroll a user fingerPrint
        /// </summary>
        public UF_RET_CODE
        enroll (uint userId,
                UF_ENROLL_OPTION option,
                ref uint enrolledUserId,
                ref uint imageQuality)
        {
            UF_RET_CODE result;


            result = supremaEngine.UF_Enroll (userId,
                                              option,
                                              ref enrolledUserId,
                                              ref imageQuality);

            return result;
        }


        /// <summary>
        /// Enroll a user fingerPrint (by template)
        /// </summary>
        public UF_RET_CODE
        enroll (uint userId,
                UF_ENROLL_OPTION option,
                uint templateSize,
                byte[] templateData,
                ref uint enrolledUserId)
        {
            UF_RET_CODE result;


            result = supremaEngine.UF_EnrollTemplate (userId,
                                                      option,
                                                      templateSize,
                                                      templateData,
                                                      ref enrolledUserId);

            return result;
        }
        #endregion


        #region Identification Methods
        /// <summary>
        /// Identify a user fingerPrint
        /// </summary>
        public UF_RET_CODE
        identify (ref uint userId,
                  ref byte userSubId)
        {
            UF_RET_CODE result;


            result = supremaEngine.UF_Identify (ref userId,
                                                ref userSubId);

            return result;
        }


        /// <summary>
        /// Identify a user fingerPrint (by template)
        /// </summary>
        public UF_RET_CODE
        identify (uint templateSize,
                  byte[] templateData,
                  ref uint userId,
                  ref byte userSubId)
        {
            UF_RET_CODE result;


            result = supremaEngine.UF_IdentifyTemplate (templateSize,
                                                        templateData,
                                                        ref userId,
                                                        ref userSubId);

            return result;
        }
        #endregion


        #region Delete Methods
        /// <summary>
        /// Delete a user
        /// </summary>
        public UF_RET_CODE
        delete (uint userId)
        {
            UF_RET_CODE result;


            result = supremaEngine.UF_Delete (userId);


            return result;
        }



        /// <summary>
        /// Delete all users
        /// </summary>
        public UF_RET_CODE
        deleteAll ()
        {
            UF_RET_CODE result;


            result = supremaEngine.UF_DeleteAll ();


            return result;
        }
        #endregion


        #region Template Methods
        /// <summary>
        /// Read user template
        /// </summary>
        public UF_RET_CODE
        readTemplate (uint userId,
                      ref uint numOfTemplate,
                      byte[] data)
        {
            UF_RET_CODE result;


            result = supremaEngine.UF_ReadTemplate (userId,
                                                    ref numOfTemplate,
                                                    data);


            return result;
        }


        /// <summary>
        /// Scan user fingerprint as template
        /// </summary>
        public UF_RET_CODE
        scanTemplate (byte[] data,
                      ref uint templateSize,
                      ref uint imageQuality)
        {
            UF_RET_CODE result;


            result = supremaEngine.UF_ScanTemplate (data,
                                                    ref templateSize,
                                                    ref imageQuality);


            return result;
        }


        /// <summary>
        /// Check if user has template or not
        /// </summary>
        public UF_RET_CODE
        checkTemplate (uint userId,
                       ref uint numOfTemplate)
        {
            UF_RET_CODE result;


            result = supremaEngine.UF_CheckTemplate (userId,
                                                     ref numOfTemplate);


            return result;
        }
        #endregion


        #region Import/Export methods
        /// <summary>
        /// Save database into a file
        /// </summary>
        public UF_RET_CODE
        saveDB (string fileName)
        {
            UF_RET_CODE result;


            result = supremaEngine.UF_SaveDB (fileName);


            return result;
        }


        /// <summary>
        /// Load database from file
        /// </summary>
        public UF_RET_CODE
        loadDB (string fileName)
        {
            UF_RET_CODE result;


            result = supremaEngine.UF_LoadDB (fileName);


            return result;
        }
        #endregion


        #region Configuration Methods
        /// <summary>
        /// Reset the module
        /// </summary>
        /// <returns></returns>
        public UF_RET_CODE
        reset ()
        {
            UF_RET_CODE result;


            result = supremaEngine.UF_Reset ();


            return result;
        }
        #endregion


        // get-num-of-template
        // get-max-num-of-template
        // get-all-user-info
        #endregion


        #region Internal Classes
        /// <summary>
        /// Device Config Model
        /// </summary>
        public class DeviceConfigModel
        {
            #region Properties
            public string ip
            {
                get;
                set;
            }

            public int port
            {
                get;
                set;
            }

            public string commPort
            {
                get;
                set;
            }

            public int baudRate
            {
                get;
                set;
            }

            public bool asciiMode
            {
                get;
                set;
            }
            #endregion


            #region Methods
            /// <summary>
            /// Parse config
            /// </summary>
            public static DeviceConfigModel
            loadConfig (string data)
            {
                DeviceConfigModel result;

                try
                {
                    result = JsonConvert.DeserializeObject<DeviceConfigModel> (data);
                }
                catch (Exception)
                {
                    result = new DeviceConfigModel ();
                }

                return result;
            }


            /// <summary>
            /// Serialize in json format
            /// </summary>
            public string
            toJson (DeviceConfigModel model)
            {
                return JsonConvert.SerializeObject (model);
            }
            #endregion
        }
        #endregion
    }
}
