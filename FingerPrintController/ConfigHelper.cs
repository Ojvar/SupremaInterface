using System;
using System.IO;
using Newtonsoft.Json;

namespace FingerPrintController
{
    /// <summary>
    /// Config Helper class
    /// </summary>
    class ConfigHelper
    {
        #region Variables
        public static ConfigModel configData = new ConfigModel ();
        #endregion


        #region Methods
        /// <summary>
        /// Load config file
        /// </summary>
        public static void
        load (string filename)
        {
            string data = File.ReadAllText (filename);

            configData = ConfigModel.parse (data);
        } 
        #endregion
    }


    /// <summary>
    /// Config model class
    /// </summary>
    public class ConfigModel
    {
        #region Properties
        /// <summary>
        /// Server port
        /// </summary>
        public int serverPort
        {
            get;
            set;
        }


        public string database
        {
            get;
            set;
        }

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

        public string username
        {
            get;
            set;
        }

        public string password
        {
            get;
            set;
        }
        #endregion


        #region Methods
        /// <summary>
        /// To String
        /// </summary>
        public override string
        ToString ()
        {
            return JsonConvert.SerializeObject (this);
        }


        /// <summary>
        /// Parse
        /// </summary>
        public static ConfigModel
        parse (string jsonData)
        {
            ConfigModel result;

            try
            {
                result = JsonConvert.DeserializeObject<ConfigModel> (jsonData);
            }
            catch (Exception)
            {
                result = new ConfigModel ();
            }


            return result;
        }
        #endregion
    }
}
