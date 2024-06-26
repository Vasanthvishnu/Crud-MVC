﻿using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace VehicleLibrary
{ 
        public class VehicleRepository
        {            
            SqlConnection DAL;
            IConfiguration _configuration;
            public VehicleRepository(IConfiguration configuration)
            {
            _configuration = configuration;
            var con = _configuration.GetConnectionString("DbConnection");
                 DAL = new SqlConnection(con);
            }
            public void Insert(VehicleModel Vehicle)
            {
                try
                {

                    var Insertsql = ($"exec InsertVehicle'{Vehicle.Name}','{Vehicle.VehicleNumber}','{Vehicle.OwnerName}','{Vehicle.DriverName}',{Vehicle.ContactNumber},'{Vehicle.LocationId}'");
                    DAL.Open();
                    DAL.Execute(Insertsql);
                    DAL.Close();

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
            public void Update(int Id, long ContactNumber ,string drivername)
            {
                try
                {
                    var update = ($"exec UpdateVehicle {Id},'{drivername}',{ContactNumber}");
                    DAL.Open();
                    DAL.Execute(update);
                    DAL.Close();
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
               // IEnumerable<VehicleModel> result;
                try
                {
                    var query = ($"exec  ShowAll");
                    DAL.Open();
                   var  result = DAL.Query<VehicleModel>(query);
                    DAL.Close();
                    return (result);
            }
                catch(SqlException)
                {
                    throw;
                }
                catch(Exception )
                {
                  throw;
                }
                
            }
            public void Remove(int Id)
            {
                try
                {
                    if (Id != null )
                    {
                        var Remove = ($" exec deleteVehicle {Id}");
                        DAL.Open();
                        DAL.Execute(Remove);
                        DAL.Close();
                    }
                }
                catch (SqlException ex)
                {
                    throw;
                }
            }
            public IEnumerable<VehicleModel> getbyid(int id)
            {
                IEnumerable<VehicleModel> result;
                try
                {
                    var view = ($"select *from Vehicle where Id={id}");
                    DAL.Open();
                    var name = DAL.Query<VehicleModel>(view);
                    DAL.Close();
                    return name;


                }
                catch
                {
                    throw;
                }
                finally
                {
                    DAL.Close();
                }
                return result;
            }
        }
}
