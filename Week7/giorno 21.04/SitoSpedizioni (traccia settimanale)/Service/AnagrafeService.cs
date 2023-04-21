using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SitoSpedizioni.Models;
//operazioni crud su anagrafe
namespace SitoSpedizioni.Service
{
    public class AnagrafeService
    {
        private SqlConnection connection= new SqlConnection(@"Data Source=localhost\sqlexpress;Initial Catalog=SitoSpedizioni;Integrated Security=True");
        private const string SELECT_ALL = "SELECT  IDanagrafe,Nome,Cognome,is_privato,indirizzo,codiceFiscale,PartitaIva FROM Anagrafe";
        private const string fisciva = "SELECT IDspedizione from spedizioni as s inner join anagrafe as a on s.AnagrafeID=a.IDanagrafe";
        //.where(a.codiceFiscale==@codicefiscale || a.partitaiva==@partitaiva).orderBy(x=>x.DataSpedizione)discendente;

		private const string INSERT_ANAGRAFE = "INSERT INTO Anagrafe(Nome,Cognome,is_privato,Indirizzo,CodiceFiscale,PartitaIva) VALUES( @nome, @cognome, @privato, @indirizzo, @codicefiscale, @partitaiva)";
        private const string UPDATE_ANAGRAFE = "UPDATE Anagrafe SET Nome = @nome, Cognome = @cognome, is_privato = @privato, indirizzo = @indirizzo, codiceFiscale = @codicefiscale, PartitaIva = @partitaiva WHERE IDanagrafe = @id";
        private const string DELETE_ANAGRAFE = "DELETE  FROM Anagrafe WHERE IDanagrafe = @id";
        //        public IEnumerable<Anagrafe> GetAll()
        //        {
        //            var result = new List<Anagrafe>();
        //            //try
        //            //{
        //                var select = connection.CreateCommand();
        //                select.CommandText = SELECT_ALL;
        //                connection.Open();
        //                using (var reader = select.ExecuteReader())
        //                {
        //                    while (reader.Read())
        //                    {
        //                        var item = new Anagrafe
        //                        {
        //                            IDanagrafe = reader.GetInt32(1),
        //                            Nome = reader.GetString(2),
        //                            Cognome = reader.GetString(3),
        //                            Is_privato = reader.GetBoolean(4),
        //                            Indirizzo = reader.GetString(5),
        //                            CodiceFiscale = reader.GetString(6),
        //                            PartitaIva = reader.GetString(7)

        //                        };
        //                        result.Add(item);
        //                    }
        ////                }
        ////        }
        ////            catch(Exception e) { Console.WriteLine(e); }
        ////            finally
        ////            {
        ////                if (connection.State == System.Data.ConnectionState.Open)
        ////                {
        ////                    connection.Close();
        ////                }
        //                }
        //                return result;
        //        }

        public IEnumerable<Anagrafe> GetAll()
        {
            var result = new List<Anagrafe>();

            var select = connection.CreateCommand();
            select.CommandText = SELECT_ALL;
            connection.Open();
            using (var reader = select.ExecuteReader())
            {
                while (reader.Read())
                {
                    var item = new Anagrafe
                    {
                        IDanagrafe = reader.GetInt32(0),
                        Nome = reader.GetString(1),
                        Cognome = reader.GetString(2),
                        Is_privato = reader.IsDBNull(3) ? false : reader.GetBoolean(3),
                        Indirizzo = reader.IsDBNull(4) ? null : reader.GetString(4),
                        CodiceFiscale = reader.IsDBNull(5) ? null : reader.GetString(5),
                        PartitaIva = reader.IsDBNull(6) ? null : reader.GetString(6)
                    };
                    result.Add(item);
                }
            }
            connection.Close();
            return result;
        }
        public bool CreaAnagrafe(Anagrafe viewModel)
        {
            try
            {
                connection.Open();
                var insert = connection.CreateCommand();
                insert.CommandText = INSERT_ANAGRAFE;
               
                insert.Parameters.AddWithValue("@nome", viewModel.Nome);
                insert.Parameters.AddWithValue("@cognome", viewModel.Cognome);
                insert.Parameters.AddWithValue("@privato", viewModel.Is_privato);
                insert.Parameters.AddWithValue("@indirizzo", viewModel.Indirizzo);
                insert.Parameters.AddWithValue("@codicefiscale", viewModel.CodiceFiscale);
                insert.Parameters.AddWithValue("@partitaiva", viewModel.PartitaIva);
                var result = insert.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                if (connection.State == System.Data.ConnectionState.Open)
                {
                    connection.Close();
                }
            }
        }
      public Anagrafe GetById(int id)
        {
            var result = new Anagrafe();
            try
            {
                var select = connection.CreateCommand();
                select.CommandText = SELECT_ALL + " WHERE IDanagrafe = @id";
                select.Parameters.AddWithValue("@id", id);
                connection.Open();
                using (var reader = select.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        result.IDanagrafe = reader.GetInt32(0);
                        result.Nome = reader.GetString(1);
                        result.Cognome = reader.GetString(2);
                        result.Is_privato = reader.GetBoolean(3);
                        result.Indirizzo = reader.GetString(4);
                        result.CodiceFiscale = reader.GetString(5);
                        result.PartitaIva = reader.GetString(6);
                    }
                }
            }
            catch { }
            finally
            {
                if (connection.State == System.Data.ConnectionState.Open)
                {
                    connection.Close();
                }
            }
            return result;
        }   

        public bool CambiaAnagrafe(Anagrafe viewModel)
        {
            try
            {
                connection.Open();
                var update = connection.CreateCommand();
                update.CommandText = UPDATE_ANAGRAFE;
                update.Parameters.AddWithValue("@id", viewModel.IDanagrafe);
                update.Parameters.AddWithValue("@nome", viewModel.Nome);
                update.Parameters.AddWithValue("@cognome", viewModel.Cognome);
                update.Parameters.AddWithValue("@privato", viewModel.Is_privato);
                update.Parameters.AddWithValue("@indirizzo", viewModel.Indirizzo);
                update.Parameters.AddWithValue("@codicefiscale", viewModel.CodiceFiscale);
                update.Parameters.AddWithValue("@partitaiva", viewModel.PartitaIva);
                var result = update.ExecuteNonQuery();
                return result == 1;
            }
            catch
            {
                return false;
            }
            finally
            {
                if (connection.State == System.Data.ConnectionState.Open)
                {
                    connection.Close();
                }
            }
        }
      
        public bool CancellaAnagrafe(int id)
        {
            try
            {
                connection.Open();
                var delete = connection.CreateCommand();
                delete.CommandText = DELETE_ANAGRAFE ;
                delete.Parameters.AddWithValue("@id", id);
                var result = delete.ExecuteNonQuery();
                return result == 1;
            }
            catch
            {
                return false;
            }
            finally
            {
                if (connection.State == System.Data.ConnectionState.Open)
                {
                    connection.Close();
                }
            }
        }

    }

}