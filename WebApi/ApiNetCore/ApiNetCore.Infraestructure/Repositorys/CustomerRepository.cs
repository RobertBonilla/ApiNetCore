using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using ApiNetCore.Domain.Entities;
using ApiNetCore.Domain.Responses;
using ApiNetCore.Infraestructure.Interfaces;
using Microsoft.Data.SqlClient;

namespace ApiNetCore.Infraestructure.Repositorys
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly string sqlCon = "Server = DESKTOP-82SJ9B4\\SQLEXPRESS; Database = ApiNetCoreTest; Trusted_Connection = True; MultipleActiveResultSets = true; User ID = sa; Password = Duke0568";

        public ResponseStatus CustomerAdd(Customer customer)
        {            
            try
            {
                ResponseStatus result = new ResponseStatus();
                string sql = "INSERT INTO ApiNetCoreTest.dbo.customer ";
                sql += "(ctmName,ctmLastName,ctmDate,ctmDirection,ctmTelephone,ctmEmail) ";
                sql += "VALUES (@ctmName,@ctmLastName,@ctmDate,@ctmDirection,@ctmTelephone,@ctmEmail)";
                using (SqlConnection con = new SqlConnection(sqlCon))
                {
                    con.Open();
                    using (SqlCommand cmd = con.CreateCommand())
                    {
                        cmd.CommandText = sql;
                        SqlCommand myCommand = new SqlCommand(sql, con);
                        myCommand.Parameters.AddWithValue("@ctmName", customer.CtmName);
                        myCommand.Parameters.AddWithValue("@ctmLastName", customer.CtmLastName);
                        myCommand.Parameters.AddWithValue("@ctmDate", customer.CtmDate);
                        myCommand.Parameters.AddWithValue("@ctmDirection", customer.CtmDirection);
                        myCommand.Parameters.AddWithValue("@ctmTelephone", customer.CtmTelephone);
                        myCommand.Parameters.AddWithValue("@ctmEmail", customer.CtmEmail);
                        int num = myCommand.ExecuteNonQuery();
                        ResponseStatus response = new ResponseStatus
                        {
                            Code = HttpStatusCode.OK.ToString(),
                            Description = String.Format("Customer is save {0} registers", num)
                        };
                        return response;
                    }
                }
            }
            catch (Exception ex)
            {
                ResponseStatus response = new ResponseStatus
                {
                    Code = HttpStatusCode.BadRequest.ToString(),
                    Description = "An error has occurred when y tried to save a Customer"
                };
                return response;
            }
        }

        public CustomerResponse CustomerList()
        {
            CustomerResponse result = new CustomerResponse();
            string sql = "SELECT CTM.ctmId,CTM.ctmName,CTM.ctmLastName,CTM.ctmDate,CTM.ctmDirection,CTM.ctmTelephone,CTM.ctmEmail,CTM.createAt FROM ApiNetCoreTest.dbo.customer CTM";
            using (SqlConnection con = new SqlConnection(sqlCon))
            {
                con.Open();
                using (SqlCommand cmd = con.CreateCommand())
                {
                    try
                    {
                        //model.IdProducto = int.Parse(Convert.ToString(dr["IdProducto"]));
                        Customer customer;
                        cmd.CommandText = sql;
                        SqlDataReader dr = cmd.ExecuteReader();
                        while (dr.Read())
                        {
                            customer = new Customer();
                            customer.CtmId = int.Parse(Convert.ToString(dr["ctmId"]));
                            customer.CtmName = Convert.ToString(dr["ctmName"]);
                            customer.CtmLastName = Convert.ToString(dr["ctmLastName"]);
                            customer.CtmDate = Convert.ToString(dr["ctmDate"]);
                            customer.CtmDirection = Convert.ToString(dr["ctmDirection"]);
                            customer.CtmEmail = Convert.ToString(dr["ctmEmail"]);
                            customer.CreatedAt = Convert.ToString(dr["createAt"]);
                            customer.CtmTelephone = Convert.ToString(dr["ctmTelephone"]);
                            result.AllCustomer.Add(customer);
                        }
                        result.ResponseStatus = new ResponseStatus
                        {
                            Code = HttpStatusCode.OK.ToString(),
                            Description = "Ok"
                        };
                    }
                    catch (Exception ex)
                    {
                        result.ResponseStatus = new ResponseStatus
                        {
                            Code = HttpStatusCode.BadRequest.ToString(),
                            Description = "Exception commad query of Customer"
                        };
                    }
                }
            }
            return result;

        }               

        public ResponseStatus CustomerDelete(int ctmId)
        {
            try
            {
                ResponseStatus result = new ResponseStatus();
                string sql = "DELETE FROM ApiNetCoreTest.dbo.customer WHERE ctmId = @ctmId ";
                using (SqlConnection con = new SqlConnection(sqlCon))
                {
                    con.Open();
                    using (SqlCommand cmd = con.CreateCommand())
                    {
                        cmd.CommandText = sql;
                        SqlCommand myCommand = new SqlCommand(sql, con);
                        myCommand.Parameters.AddWithValue("@ctmId", ctmId);
                        int num = myCommand.ExecuteNonQuery();
                        ResponseStatus response = new ResponseStatus
                        {
                            Code = HttpStatusCode.OK.ToString(),
                            Description = String.Format("Customer is delete {0} registers", num)
                        };
                        return response;
                    }
                }
            }
            catch (Exception ex)
            {
                ResponseStatus response = new ResponseStatus
                {
                    Code = HttpStatusCode.BadRequest.ToString(),
                    Description = "An error has occurred when y tried to delete a Customer"
                };
                return response;
            }
        }

        public ResponseStatus CustomerEdit(Customer customer)
        {
            try
            {
                ResponseStatus result = new ResponseStatus();
                string sql = "UPDATE ApiNetCoreTest.dbo.customer ";
                sql += "SET ctmName = @ctmName,ctmLastName = @ctmLastName,ctmDate = @ctmDate, ";
                sql += "ctmDirection = @ctmDirection,ctmTelephone = @ctmTelephone,ctmEmail = @ctmEmail ";
                sql += "WHERE ctmId = @ctmId ";
                using (SqlConnection con = new SqlConnection(sqlCon))
                {
                    con.Open();
                    using (SqlCommand cmd = con.CreateCommand())
                    {
                        cmd.CommandText = sql;
                        SqlCommand myCommand = new SqlCommand(sql, con);
                        myCommand.Parameters.AddWithValue("@ctmName", customer.CtmName);
                        myCommand.Parameters.AddWithValue("@ctmLastName", customer.CtmLastName);
                        myCommand.Parameters.AddWithValue("@ctmDate", customer.CtmDate);
                        myCommand.Parameters.AddWithValue("@ctmDirection", customer.CtmDirection);
                        myCommand.Parameters.AddWithValue("@ctmTelephone", customer.CtmTelephone);
                        myCommand.Parameters.AddWithValue("@ctmEmail", customer.CtmEmail);
                        myCommand.Parameters.AddWithValue("@ctmId", customer.CtmId);
                        int num = myCommand.ExecuteNonQuery();
                        ResponseStatus response = new ResponseStatus
                        {
                            Code = HttpStatusCode.OK.ToString(),
                            Description = String.Format("Customer is Update {0} registers",num)
                        };
                        return response;
                    }
                }
            }
            catch (Exception ex)
            {
                ResponseStatus response = new ResponseStatus
                {
                    Code = HttpStatusCode.BadRequest.ToString(),
                    Description = "An error has occurred when y tried to update a Customer"
                };
                return response;
            }
        }

        public Customer CustomerEditGet(int ctmId)
        {
            Customer customer = new Customer();
            string sql = "SELECT CTM.ctmId,CTM.ctmName,CTM.ctmLastName,CTM.ctmDate,CTM.ctmDirection,CTM.ctmTelephone,CTM.ctmEmail,CTM.createAt FROM ApiNetCoreTest.dbo.customer CTM WHERE CTM.ctmId = "+ctmId;
            using (SqlConnection con = new SqlConnection(sqlCon))
            {
                con.Open();
                using (SqlCommand cmd = con.CreateCommand())
                {
                    try
                    {
                        //model.IdProducto = int.Parse(Convert.ToString(dr["IdProducto"]));
                        cmd.CommandText = sql;
                        SqlDataReader dr = cmd.ExecuteReader();
                        while (dr.Read())
                        {
                            customer = new Customer();
                            customer.CtmId = int.Parse(Convert.ToString(dr["ctmId"]));
                            customer.CtmName = Convert.ToString(dr["ctmName"]);
                            customer.CtmLastName = Convert.ToString(dr["ctmLastName"]);
                            customer.CtmDate = Convert.ToString(dr["ctmDate"]);
                            customer.CtmDirection = Convert.ToString(dr["ctmDirection"]);
                            customer.CtmEmail = Convert.ToString(dr["ctmEmail"]);
                            customer.CreatedAt = Convert.ToString(dr["createAt"]);
                            customer.CtmTelephone = Convert.ToString(dr["ctmTelephone"]);
                        }
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(ex.Message);
                    }
                }
            }
            return customer;

        }
    }
}
