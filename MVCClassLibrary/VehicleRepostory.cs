using Microsoft.Extensions.Configuration;
using System;
using System.Data.SqlClient;
using Crud_MVC;

namespace MVCClassLibrary
{
    public class VehicleRepostory
    {
        SqlConnection con;
        IConfiguration _configuration;

        public VehicleRepostory(IConfiguration configuration)
        {
            _configuration = configuration;
            var pon = _configuration.GetConnectionString("DbConnection");
            con = new SqlConnection();
        }

    }
}
