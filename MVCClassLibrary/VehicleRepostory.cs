using Microsoft.Extensions.Configuration;
using System;
using System.Data.SqlClient;
using Crud_MVC;
using Dapper;
using System.Collections.Generic;
using Crud_MVC.Models;

namespace MVCClassLibrary
{
    public class VehicleRepostory
    {
       
        SqlConnection con;
        IConfiguration _configuretion;

       

        public VehicleRepostory(IConfiguration configuretion)
        {
            _configuretion = configuretion;
            var a = _configuretion.GetConnectionString("DbConnection");
            con = new SqlConnection(a);
        }
        public void Insert(VehicleModel vehicle)
        {
            try
            {
                var Insertsql = ($"exec InsertVehicle'{vehicle.Name}','{vehicle.VehicleNumber}','{vehicle.OwnerName}','{vehicle.DriverName}',{vehicle.ContactNumber}");
                con.Open();
                con.Execute(Insertsql);
                con.Close();

            }
            catch (SqlException ex)
            {
                throw ex;
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
                con.Open();
                con.Execute(update);
                con.Close();
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
                con.Open();
                var result = con.Query<VehicleModel>(query);
                con.Close();
                return (result);

            }
            catch
            {
                throw;
            }
            finally
            {
               con.Close();
            }
            
        }
        public void Remove(string VehicleNumber)
        {
            try
            {
                if (VehicleNumber != null && VehicleNumber.Length != 0)
                {
                    var Remove = ($" exec RemoveVehicle'{VehicleNumber}'");
                    con.Open();
                    con.Execute(Remove);
                    con.Close();
                }
            }
            catch (SqlException ex)
            {
                throw;
            }
        }
        }
}
