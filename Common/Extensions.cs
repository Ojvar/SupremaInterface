using System;
using System.Threading;
using System.Windows.Forms;

namespace SupremaInterface.Common
{
    public static class Extensions
    {
        #region Methods
        /// <summary>
        /// Run Action as thread
        /// </summary>
        public static void
        runAsThread (this Action action,
                     params object[] data)
        {
            ThreadStart threadStart = new ThreadStart (action);

            Thread runThread = new Thread (threadStart);


            runThread.Start ();
        }


        /// <summary>
        /// Run as invoked
        /// </summary>
        public static void
        runAsInvoked (this Action action,
                      Control parent)
        {
            if ((null == parent) ||
                (null == action))
            {
                return;
            }


            if (parent.InvokeRequired)
            {
                parent.Invoke (action);
            }
            else
            {
                action.Invoke ();
            }
        }
        #endregion
    }
}
