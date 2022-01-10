using Dapper;
using FinalOrderSystem.DataClass.DataModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalOrderSystem.Adapter
{   
    /// <summary>
    /// 
    /// </summary>
    public interface IMenuRepository
    {
        IEnumerable<Menu> GetMenus();
        IEnumerable<Menu> GetMenuByID(string SID);
        IEnumerable<Menu> GetMenuByName(string Name);
        bool CreateMenu(Menu Menu);
        bool EditMenu(Menu Menu);
        bool DeleteMenu(string SID);
    }
    public class MenuRepository : IMenuRepository
    {
        private readonly IDbConnection _conn;
       // private readonly string _conn;
        public MenuRepository(/*string dbConnectionString*/IDbConnection _conn)
        {
            // this._conn = dbConnectionString;
            this._conn = _conn;
        }
   
        public IEnumerable<Menu> GetMenus()
        {
            try
            {
                using (/*var conn = new SqlConnection(_conn)*/_conn)
                {
                    string Query = "usp_SelectMenu";
                    var results = _conn.Query<Menu>(Query, commandType: System.Data.CommandType.StoredProcedure).ToList();
                    return results;
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.StackTrace.ToString());
                throw;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="SID"></param>
        /// <returns></returns>
        public IEnumerable<Menu> GetMenuByID(String SID)
        {
            try
            {
                using (_conn)
                {
                    string Query = "usp_SelectByIDMenu";
                    DynamicParameters param = new DynamicParameters();
                    param.Add("@SID", SID);
                    var results = _conn.Query<Menu>(Query, param, commandType: System.Data.CommandType.StoredProcedure).ToList();
                    return results;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace.ToString());               
                throw;
            }
        }
        public IEnumerable<Menu> GetMenuByName(String Name)
        {
            try
            {
                using (_conn)
                {
                    string query = "usp_SelectByNameMenu";
                    DynamicParameters param = new DynamicParameters();
                    param.Add("@Name", Name);
                    var results = _conn.Query<Menu>(query, param, commandType: System.Data.CommandType.StoredProcedure).ToList();
                    return results;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace.ToString());
                throw;
            }
        }
        public bool CreateMenu(Menu Menu)
        {
            try
            {
                using (_conn)
                {
                    string query = "usp_CreateMenu";
                    DynamicParameters param = new DynamicParameters();
                    param.Add("@SID", Menu.SID);
                    param.Add("@Name", Menu.Name);
                    param.Add("@Image", Menu.Image);
                    param.Add("@Price", Menu.Price);
                    param.Add("@Category", Menu.Category);
                    param.Add("@Description", Menu.Description);
                    var results = _conn.Execute(query, param, commandType: System.Data.CommandType.StoredProcedure);
                    return results > 0;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace.ToString());
                throw;
            }
        }

        public bool EditMenu(Menu Menu)
        {
            try
            {
                using (_conn)
                {
                    string Query = "usp_UpdateMenu";
                    DynamicParameters param = new DynamicParameters();
                    param.Add("@SID", Menu.SID);
                    param.Add("@Name", Menu.Name);
                    param.Add("@Image", Menu.Image);
                    param.Add("@Price", Menu.Price);
                    param.Add("@Category", Menu.Category);
                    param.Add("@Description", Menu.Description);
                    var results = _conn.Execute(Query, param, commandType: System.Data.CommandType.StoredProcedure);
                    return results > 0;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace.ToString());
                throw;
            }
        }

        public bool DeleteMenu(string SID)
        {
            try
            {
                using (_conn)
                {
                    string Query = "usp_DeleteMenu";
                    DynamicParameters param = new DynamicParameters();
                    param.Add("@SID", SID);
                    var results = _conn.Execute(Query, param, commandType: System.Data.CommandType.StoredProcedure);
                    return results > 0;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace.ToString());
                throw;
            }
        }
    }
}