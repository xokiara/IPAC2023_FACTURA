﻿using Entidades;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Text;

namespace Datos
{
    public class ClienteDB
    {
        string cadena = "server=localhost; user=root; database=factura; password=valladaresk28";

        //HACER EL  MANTENIMIENTO DE LOS CLIENTES

        //Método devolver cliente
        public Cliente DevolverClientePorIdentidad(string identidad)
        {
            Cliente cliente = null;
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.Append(" SELECT * FROM cliente WHERE Identidad = @Identidad; ");

                using (MySqlConnection _conexion = new MySqlConnection(cadena))
                {
                    _conexion.Open();
                    using (MySqlCommand comando = new MySqlCommand(sql.ToString(), _conexion))
                    {
                        comando.CommandType = CommandType.Text;
                        comando.Parameters.Add("@Identidad", MySqlDbType.VarChar, 25).Value = identidad;
                        MySqlDataReader dr = comando.ExecuteReader();
                        if (dr.Read())
                        {
                            cliente = new Cliente();

                            cliente.Identidad = identidad;
                            cliente.Nombre = dr["Nombre"].ToString();
                            cliente.Telefono = dr["Telefono"].ToString();
                            cliente.Correo = dr["Correo"].ToString();
                            cliente.Direccion = dr["Direccion"].ToString();
                            cliente.FechaNacimiento = Convert.ToDateTime(dr["FechaNacimiento"]);
                            cliente.EstaActivo = Convert.ToBoolean(dr["EstaActivo"]);

                        }
                    }
                }
            }
            catch (System.Exception ex)
            {
            }
            return cliente;
        }

        public DataTable DevolverClientes()
        {
            DataTable dt = new DataTable();
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.Append(" SELECT * FROM cliente ");

                using (MySqlConnection _conexion = new MySqlConnection(cadena))
                {
                    _conexion.Open();
                    using (MySqlCommand comando = new MySqlCommand(sql.ToString(), _conexion))
                    {
                        comando.CommandType = CommandType.Text;
                        MySqlDataReader dr = comando.ExecuteReader();
                        dt.Load(dr);
                    }
                }
            }
            catch (System.Exception ex)
            {
            }
            return dt;
        }

        public DataTable DevolverClientesPorNombre(string nombre)
        {
            DataTable dt = new DataTable();
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.Append(" SELECT * FROM cliente WHERE Nombre LIKE ('%@Nombre%'); ");

                using (MySqlConnection _conexion = new MySqlConnection(cadena))
                {
                    _conexion.Open();
                    using (MySqlCommand comando = new MySqlCommand(sql.ToString(), _conexion))
                    {
                        comando.CommandType = CommandType.Text;
                        comando.Parameters.Add("@Nombre", MySqlDbType.VarChar, 50).Value = nombre;
                        MySqlDataReader dr = comando.ExecuteReader();
                        dt.Load(dr);
                    }
                }
            }
            catch (System.Exception ex)
            {
            }
            return dt;
        }


    }
}
