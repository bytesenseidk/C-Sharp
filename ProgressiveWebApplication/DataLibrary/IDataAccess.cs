using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataLibrary
{
	public interface IDataAccess
	{
		Task<List<T>> LoadData<T, U>(string sql, U parameters, string connectionstring);
		Task SaveData<T>(string sql, T parameters, string connectionstring);
	}
}