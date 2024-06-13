using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleLibrary
{
     public class LocationRepository:ILocationRepository  
    {
        SqlConnection DAL;
        IConfiguration _configuration;
        public LocationRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            var con = _configuration.GetConnectionString("DbConnection");
            DAL = new SqlConnection(con);
        }
        public IEnumerable<LocationModel> ShowAll()
        {
            IEnumerable<LocationModel> result = Enumerable.Empty<LocationModel>();
            try
            {
                var selectquery = ($"exec ShowallLocation");
                DAL.Open();
                result = DAL.Query<LocationModel>(selectquery);
                
               
            }
            catch
            {

            }
            finally
            {
                DAL.Close();
            }
            return (result);
        }

    }
}
