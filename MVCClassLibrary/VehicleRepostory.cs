using Microsoft.Extensions.Configuration;
using System;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.Collections.Generic;
using System.Linq;
using MVCClassLibrary;



namespace MVCClassLibrary
{
    public class VehicleRepostory
    {
        SqlConnection obj;
        IConfiguration _configurestion;
        public VehicleRepostory(IConfiguration configurestion)
        {
            _configurestion = configurestion;
            var veh = _configurestion.GetConnectionString("DbConnection");
            obj = new SqlConnection(veh);
        }
        public void Insert(VehicleModel vehicle)
        {
            try
            {
                var Insertsql = ($"exec InsertVehicle'{vehicle.Name}','{vehicle.VehicleNumber}','{vehicle.OwnerName}','{vehicle.DriverName}',{vehicle.ContactNumber}");
                obj.Open();
                obj.Execute(Insertsql);
                obj.Close();

            }
            catch (SqlException ex)
            {
                throw ;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void Update(string DriverName, long ContactNumber, string VehicleNumber)
        {
            try
            {
                var update = ($"exec UpdateVehicle'{DriverName}',{ContactNumber},'{VehicleNumber}'");
                obj.Open();
                obj.Execute(update);
                obj.Close();
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public IEnumerable<VehicleModel> ShowAll()
        {
            //IEnumerable<VehicleModel> result;
            try
            {
                var query = ($"exec  ShowAll");
                obj.Open();
                var result = obj.Query<VehicleModel>(query);
                obj.Close();
                return (result);

            }
            catch
            {
                throw;
            }
            finally
            {
                obj.Close();
            }
            
        }
        public void Remove(string VehicleNumber)
        {
            try
            {
                if (VehicleNumber != null && VehicleNumber.Length != 0)
                {
                    var Remove = ($" exec RemoveVehicle'{VehicleNumber}'");
                    obj.Open();
                    obj.Execute(Remove);
                    obj.Close();
                }
            }
            catch (SqlException ex)
            {
                throw;
            }
        }
        }
}
