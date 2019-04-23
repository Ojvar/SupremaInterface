using System;
using System.Collections.Generic;
using System.Data;

using FingerPrintController.Extensions;

namespace FingerPrintController.Model
{
    /// <summary>
    /// Gate Device Model
    /// </summary>
    public class FingerPrint
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

        public uint user_id
        {
            get;
            set;
        }

        public uint fingerprint_user_id
        {
            get;
            set;
        }

        public byte fingerprint_sub_id
        {
            get;
            set;
        }

        public int image_url
        {
            get;
            set;
        }

        public byte[] template
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
        public static List<FingerPrint>
        all ()
        {
            List<FingerPrint> result = new List<FingerPrint> ();


            DataTable table =
                DBase.MySqlDBase.executeTable (SqlCommands.select_fingerPrints_all);

            result = table.toModelList<FingerPrint> ();


            return result;
        }
        #endregion
    }
}
