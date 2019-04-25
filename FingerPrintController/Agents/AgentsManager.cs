using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Suprema.SFM_SDK_NET;

namespace FingerPrintController.Agents
{
    public class AgentsManager
    {
        #region Enum
        /// <summary>
        /// Enum Commands
        /// </summary>
        public enum EnumCommands
        {
            Enroll,
            EnrollTemplate,

            Identify,
            IdentifyTemplate,

            ReadTemplate,

            Start,
            Finish
        }
        #endregion


        #region Variables
        private List<Agents.FingerPrintAgent> agents = new List<Agents.FingerPrintAgent> ();
        #endregion


        #region Methods
        /// <summary>
        /// Prepare agents
        /// </summary>
        public void
        prepareAgents ()
        {
            List<Model.FingerPrintDevice> fingerPrintDevices = Model.FingerPrintDevice.all ();


            foreach (Model.FingerPrintDevice fingerPrint
                     in fingerPrintDevices)
            {
                FingerPrintAgent agent = new FingerPrintAgent (fingerPrint);


                UF_RET_CODE result = agent.connect (agent.deviceModel.ip,
                                                    agent.deviceModel.port);


                // Add to agents
                agents.Add (agent);
            }
        }


        /// <summary>
        /// Get agents
        /// </summary>
        /// <returns></returns>
        public List<FingerPrintAgent>
        getAgetns ()
        {
            return agents;
        }


        /// <summary>
        /// Run Command on agent
        /// </summary>
        public void
        runCommand (EnumCommands command, 
                    int agentId,
                    object[] data = null)
        {
            FingerPrintAgent agent = agents.Where (x => x.deviceModel?.id == agentId)
                                           .FirstOrDefault ();

            if (null == agent)
            {
                return;
            }


            agent.runCommand (command,
                              data);
        }


        /// <summary>
        /// finish all agents
        /// </summary>
        public void
        finishAll ()
        {
            foreach (FingerPrintAgent agent
                     in agents)
            {
                agent.disconnect ();
            }
        }
        #endregion
    }
}
