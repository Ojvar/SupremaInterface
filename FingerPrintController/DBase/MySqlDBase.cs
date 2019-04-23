using System;
using System.Data;

using MySql.Data.MySqlClient;

namespace FingerPrintController.DBase
{
    /// <summary>
    /// Mysql dbase helper
    /// </summary>
    public class MySqlDBase
    {
        #region Variables
        private static string host;
        private static int port;
        private static string database;
        private static string username;
        private static string password;
        #endregion


        #region Properties
        /// <summary>
        /// Create a new connection
        /// </summary>
        public static MySqlConnection
        connection
        {
            get
            {
                string connectionStr =
                    string.Format ("Server={0}; Port={1};Database={2};Uid={3};Pwd={4};",
                                   host,
                                   port,
                                   database,
                                   username,
                                   password);

                return new MySqlConnection (connectionStr);
            }
        }
        #endregion

    
        #region Methods
        /// <summary>
        /// Setup
        /// </summary>
        /// <param name=""></param>
        public static void
        setup (string host,
               int port,
               string database,
               string username,
               string password)
        {
            MySqlDBase.host = host;
            MySqlDBase.port = port;
            MySqlDBase.database = database;
            MySqlDBase.username = username;
            MySqlDBase.password = password;
        }


        /// <summary>
        /// Execute - Reader
        /// </summary>
        public static MySqlDataReader
        executeReader (string cmd,
                       MySqlParameter[] parameters = null)
        {
            MySqlDataReader result = null;

            MySqlCommand command = null;

            try
            {
                command = new MySqlCommand (cmd,
                                            connection);

                if (parameters != null)
                {
                    command.Parameters.AddRange (parameters);
                }

                command.Connection.Open ();

                result = command.ExecuteReader ();
            }
            catch (Exception)
            {
            }
            finally
            {
                //command?.Connection.Close ();
            }

            return result;
        }


        /// <summary>
        /// Execute - DataTAble
        /// </summary>
        public static DataTable
        executeTable (string cmd,
                      MySqlParameter[] parameters = null)
        {
            DataTable result = null;


            try
            {
                result = new DataTable ();

                MySqlDataReader reader = executeReader (cmd,
                                                        parameters);

                result.Load (reader);

                reader?.Close ();
            }
            catch (Exception)
            {
            }

            return result;
        }


        /// <summary>
        /// Execute - Scaler
        /// </summary>
        public static object
        executeScaler (string cmd,
                      MySqlParameter[] parameters = null)
        {
            object result = null;

            MySqlCommand command = null;


            try
            {
                command = new MySqlCommand (cmd,
                                            connection);

                command.Connection.Open ();

                if (null != parameters)
                {
                    command.Parameters.AddRange (parameters);
                }

                result = command.ExecuteScalar ();
            }
            catch (Exception)
            {
            }
            finally
            {
                command.Connection.Clone ();
            }

            return result;
        }

        
        /// <summary>
        /// Execute - Scaler
        /// </summary>
        public static int
        execute (string cmd,
                 MySqlParameter[] parameters = null)
        {
            int result = -1;

            MySqlCommand command = null;


            try
            {
                command = new MySqlCommand (cmd,
                                            connection);

                command.Connection.Open ();

                if (null != parameters)
                {
                    command.Parameters.AddRange (parameters);
                }

                result = command.ExecuteNonQuery ();
            }
            catch (Exception)
            {
            }
            finally
            {
                command.Connection.Clone ();
            }

            return result;
        }
        #endregion
    }
}
