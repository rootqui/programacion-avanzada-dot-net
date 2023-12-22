using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClasesBases;
using System.Data.SqlClient;
using System.Xml;

namespace DAC
{
    public class DACCategorias
    {
        SqlConnection cn = new SqlConnection("Data Source=.;Initial Catalog=Pachacamac;Integrated Security=True");
        SqlCommand cmd;

        public void insert_categorias(clsCategoria xCate)
        {            
            cmd = new SqlCommand();
            cmd.CommandText = "InsertCategorias";
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Nombre", xCate.Nombre);
            cmd.Parameters.AddWithValue("@Descrip", xCate.Descrip);
            cmd.Parameters.AddWithValue("@ArchivoImagen", xCate.ArchivoImagen);
            cmd.Connection = cn;

            try
            {
                cn.Open();
                cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }
            finally
            {
                cn.Close();
            }
        }

        public void update_categorias(clsCategoria xCate)
        {
            cmd = new SqlCommand();
            cmd.CommandText = "UpdateCategorias";
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id", xCate.id);
            cmd.Parameters.AddWithValue("@Nombre", xCate.Nombre);
            cmd.Parameters.AddWithValue("@Descrip", xCate.Descrip);
            cmd.Parameters.AddWithValue("@ArchivoImagen", xCate.ArchivoImagen);
            cmd.Connection = cn;

            try
            {
                cn.Open();
                cmd.ExecuteNonQuery();               

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }
            finally
            {
                cn.Close();
            }
        }

        public void delete_categorias(int  id)
        {
            cmd = new SqlCommand();
            cmd.CommandText = "DeleteCategorias";
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id", id);
            cmd.Connection = cn;

            try
            {
                cn.Open();
                cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }
            finally
            {
                cn.Close();
            }
        }



        public List<clsCategoria> listarcategorias()
        {
            List<clsCategoria> xlista = new List<clsCategoria>();
            SqlDataReader dr;
            cmd = new SqlCommand();
            cmd.CommandText = "SelectCategorias";
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Connection = cn;

            try
            {
                cn.Open();
                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    clsCategoria categoria = new clsCategoria();
                    categoria.id = dr.GetInt32(0);
                    categoria.Nombre = dr.GetString(1);
                    categoria.Descrip = dr.GetString(2);
                    categoria.ArchivoImagen = dr.GetString(3);
                    xlista.Add(categoria);
                }

                dr.Close();
                cn.Close();
                return xlista;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                cn.Close();
            }
        }


    }

}
