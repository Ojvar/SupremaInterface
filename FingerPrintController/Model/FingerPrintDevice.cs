using System;
using System.Collections.Generic;
using System.Data;

using FingerPrintController.Extensions;

namespace FingerPrintController.Model
{
    /// <summary>
    /// Gate Device Model
    /// </summary>
    public class FingerPrintDevice
    {
        #region Properties
        public int id
        {
            get;
            set;
        }

        public DateTime? created_at
        {
            get;
            set;
        }

        public DateTime? updated_at
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

        public string name
        {
            get;
            set;
        }

        public byte net_state
        {
            get;
            set;
        }

        public byte enabled
        {
            get;
            set;
        }

        public int extra
        {
            get;
            set;
        }

        public DateTime? deleted_at
        {
            get;
            set;
        }
        #endregion


        #region Methods
        /// <summary>
        /// Get devices list
        /// </summary>
        /// <returns></returns>
        public static List<FingerPrintDevice>
        all ()
        {
            List<FingerPrintDevice> result = new List<FingerPrintDevice> ();


            DataTable table =
                DBase.MySqlDBase.executeTable (SqlCommands.select_fingerPrintDevices_all);

            result = table.toModelList<FingerPrintDevice> ();


            return result;
        }
        #endregion
    }
}
