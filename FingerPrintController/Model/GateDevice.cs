using System;
using System.Collections.Generic;
using System.Data;
using FingerPrintController.Extensions;

namespace FingerPrintController.Model
{
    /// <summary>
    /// Gate Device Model
    /// </summary>
    public class GateDevice
    {
        #region Properties
        [DBaseField]
        public string id
        {
            get;
            set;
        }

        [DBaseField]
        public DateTime created_at
        {
            get;
            set;
        }

        [DBaseField]
        public DateTime updated_at
        {
            get;
            set;
        }

        [DBaseField]
        public string name
        {
            get;
            set;
        }

        [DBaseField]
        public string ip
        {
            get;
            set;
        }

        [DBaseField]
        public string number
        {
            get;
            set;
        }

        [DBaseField]
        public int type
        {
            get;
            set;
        }

        [DBaseField]
        public int gate
        {
            get;
            set;
        }

        [DBaseField]
        public byte? state
        {
            get;
            set;
        }

        [DBaseField]
        public uint gategender_id
        {
            get;
            set;
        }

        [DBaseField]
        public uint gatepass_id
        {
            get;
            set;
        }

        [DBaseField]
        public uint zone_id
        {
            get;
            set;
        }

        [DBaseField]
        public uint gatedirect_id
        {
            get;
            set;
        }

        [DBaseField]
        public byte? netState
        {
            get;
            set;
        }

        [DBaseField]
        public int? timepass
        {
            get;
            set;
        }

        [DBaseField]
        public int? timeserver
        {
            get;
            set;
        }

        [DBaseField]
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
        public static List<GateDevice>
        all ()
        {
            List<GateDevice> result = new List<GateDevice> ();


            DataTable table =
                DBase.MySqlDBase.executeTable (SqlCommands.select_gate_devices_all);

            result = table.toModelList<GateDevice> ();


            return result;
        }
        #endregion
    }
}
