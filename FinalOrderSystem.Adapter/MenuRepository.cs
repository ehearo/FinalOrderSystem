using Dapper;
using FinalOrderSystem.DataClass.DataModels;
using System;
using System.Collections.Generic;
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
        private readonly string _dbconnetionstring = "Data Source = LC105-22163-01\\SQLEXPRESS;Initial Catalog = OrderSystem; Integrated Security = True";

        public IEnumerable<Menu> GetMenus()
        {
            try
            {
                using (var conn = new SqlConnection(_dbconnetionstring))
                {
                    string Query = "usp_SelectMenu";
                    var results = conn.Query<Menu>(Query, commandType: System.Data.CommandType.StoredProcedure).ToList();
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
                using (var conn = new SqlConnection(_dbconnetionstring))
                {
                    string Query = "usp_SelectByIDMenu";
                    DynamicParameters param = new DynamicParameters();
                    param.Add("@SID", SID);
                    var results = conn.Query<Menu>(Query, param, commandType: System.Data.CommandType.StoredProcedure).ToList();
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
                using (var conn = new SqlConnection(_dbconnetionstring))
                {
                    string query = "usp_SelectByNameMenu";
                    DynamicParameters param = new DynamicParameters();
                    param.Add("@Name", Name);
                    var results = conn.Query<Menu>(query, param, commandType: System.Data.CommandType.StoredProcedure).ToList();
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
                using (var conn = new SqlConnection(_dbconnetionstring))
                {
                    string query = "usp_CreateMenu";
                    DynamicParameters param = new DynamicParameters();
                    param.Add("@SID", Menu.SID);
                    param.Add("@Name", Menu.Name);
                    param.Add("@Image", Menu.Image);
                    param.Add("@Price", Menu.Price);
                    param.Add("@Category", Menu.Category);
                    param.Add("@Description", Menu.Description);
                    var results = conn.Execute(query, param, commandType: System.Data.CommandType.StoredProcedure);
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
                using (var conn = new SqlConnection(_dbconnetionstring))
                {
                    string Query = "usp_UpdateMenu";
                    DynamicParameters param = new DynamicParameters();
                    param.Add("@SID", Menu.SID);
                    param.Add("@Name", Menu.Name);
                    param.Add("@Image", Menu.Image);
                    param.Add("@Price", Menu.Price);
                    param.Add("@Category", Menu.Category);
                    param.Add("@Description", Menu.Description);
                    var results = conn.Execute(Query, param, commandType: System.Data.CommandType.StoredProcedure);
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
                using (var conn = new SqlConnection(_dbconnetionstring))
                {
                    string Query = "usp_DeleteMenu";
                    DynamicParameters param = new DynamicParameters();
                    param.Add("@SID", SID);
                    var results = conn.Execute(Query, param, commandType: System.Data.CommandType.StoredProcedure);
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