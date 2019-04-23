using System;
using Suprema.SFM_SDK_NET;

namespace FingerPrintController.Agents
{
    public interface IFingerPrint
    {
        /// <summary>
        /// Start
        /// </summary>
        UF_RET_CODE connect (string host,
                             int port);


        /// <summary>
        /// Connect
        /// </summary>
        UF_RET_CODE connect (string serial,
                             int baudRate,
                             bool asciiMode = false);


        /// <summary>
        /// Stop
        /// </summary>
        UF_RET_CODE disconnect ();


        /// <summary>
        /// Enroll
        /// </summary>
        UF_RET_CODE enroll (uint userId,
                            object options,
                            Action<uint, uint> callback);


        /// <summary>
        /// Enroll by template
        /// </summary>
        UF_RET_CODE enrollByTemplate (uint userId,
                                      object option,
                                      uint templateSize,
                                      byte[] templateData,
                                      Action<uint> callback);


        /// <summary>
        /// Identify 
        /// </summary>
        UF_RET_CODE identify (Action<uint, byte> callback);


        /// <summary>
        /// Identify by template
        /// </summary>
        UF_RET_CODE identifyByTemplate (uint templateSize,
                                        byte[] templateData,
                                        Action<uint, byte> callback);
    }
}
