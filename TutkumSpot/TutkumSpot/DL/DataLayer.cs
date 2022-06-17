using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;

namespace TutkumSpot.DL
{
    public static class DataLayer
    {
        static MySqlConnection conn = new MySqlConnection(
            new MySqlConnectionStringBuilder()
            {
                Server = "127.0.0.1",
                Database = "20015222008_db",
                UserID = "root",
                Password = "",

            }.ConnectionString
         );
        public static int MüşteriEkle(Musteri m)
        {
            try
            {
                if (conn.State != System.Data.ConnectionState.Open)
                    conn.Open();

                MySqlCommand komut = new MySqlCommand("20015222008_db.MusteriEkle", conn);
                komut.CommandType = System.Data.CommandType.StoredProcedure;
                komut.Parameters.AddWithValue("@id", m.ID);
                komut.Parameters.AddWithValue("@ad", m.Ad);
                komut.Parameters.AddWithValue("@soyad", m.Soyad);
                komut.Parameters.AddWithValue("@tel", m.Telefon);
                komut.Parameters.AddWithValue("@mail", m.Mail);
                komut.Parameters.AddWithValue("@adr", m.Adres);

                int res = komut.ExecuteNonQuery();
                return res;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if(conn.State != System.Data.ConnectionState.Closed)
                    conn.Close();
            }
        }
            
        internal static DataSet MüşteriGetir(string filtre)
        {
            try
            {
                if (conn.State != System.Data.ConnectionState.Open)
                    conn.Open();

                MySqlCommand komut;
                if (string.IsNullOrEmpty(filtre))
                {
                    komut = new MySqlCommand("20015222008_db.MusterilerinHepsi", conn);
                    komut.CommandType = System.Data.CommandType.StoredProcedure;
                }
                else
                {
                    komut = new MySqlCommand("20015222008_db.MusterilerBul", conn);
                    komut.CommandType = System.Data.CommandType.StoredProcedure;
                    komut.Parameters.AddWithValue("@filtre", filtre);
                }

                DataSet dataSet = new DataSet();
                MySqlDataAdapter adp = new MySqlDataAdapter(komut);
                adp.Fill(dataSet);

                return dataSet;

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (conn.State != System.Data.ConnectionState.Closed)
                    conn.Close();
            }
        }

        internal static int MüşteriGüncelle(Musteri m)
        {
            try
            {
                if (conn.State != System.Data.ConnectionState.Open)
                    conn.Open();

                MySqlCommand komut = new MySqlCommand("20015222008_db.MusteriGuncelle", conn);
                komut.CommandType = System.Data.CommandType.StoredProcedure;
                komut.Parameters.AddWithValue("@id", m.ID);
                komut.Parameters.AddWithValue("@ad", m.Ad);
                komut.Parameters.AddWithValue("@soy", m.Soyad);
                komut.Parameters.AddWithValue("@tel", m.Telefon);
                komut.Parameters.AddWithValue("@mail", m.Mail);
                komut.Parameters.AddWithValue("@adr", m.Adres);

                int res = komut.ExecuteNonQuery();
                return res;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (conn.State != System.Data.ConnectionState.Closed)
                    conn.Close();
            }
        }
        internal static int MüşteriSil(string id)
        {
            try
            {
                if (conn.State != System.Data.ConnectionState.Open)
                    conn.Open();

                MySqlCommand komut = new MySqlCommand("20015222008_db.MusteriSil", conn);
                komut.CommandType = System.Data.CommandType.StoredProcedure;
                komut.Parameters.AddWithValue("@id", id);

                int res = komut.ExecuteNonQuery();
                return res;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (conn.State != System.Data.ConnectionState.Closed)
                    conn.Close();
            }
        }

        internal static int UrunEkle(Urun u)
        {
            try
            {
                if (conn.State != System.Data.ConnectionState.Open)
                    conn.Open();

                MySqlCommand komut = new MySqlCommand("20015222008_db.Urunekle", conn);
                komut.CommandType = System.Data.CommandType.StoredProcedure;
                komut.Parameters.AddWithValue("@id", u.ID);
                komut.Parameters.AddWithValue("@ad", u.Ad);
                komut.Parameters.AddWithValue("@kategori", u.Kategori);
                komut.Parameters.AddWithValue("@fiyat", u.Fiyat);
                komut.Parameters.AddWithValue("@stok", u.Stok);
                komut.Parameters.AddWithValue("@birim", u.Birim);
                komut.Parameters.AddWithValue("@detay", u.Detay);

                int res = komut.ExecuteNonQuery();
                return res;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (conn.State != System.Data.ConnectionState.Closed)
                    conn.Close();
            }
        }
        
        internal static DataSet UrunGetir(string filtre)
        {
            try
            {
                if (conn.State != System.Data.ConnectionState.Open)
                    conn.Open();

                MySqlCommand komut;
                if (string.IsNullOrEmpty(filtre))
                {
                    komut = new MySqlCommand("20015222008_db.UrunlerHepsi", conn);
                    komut.CommandType = System.Data.CommandType.StoredProcedure;
                }
                else
                {
                    komut = new MySqlCommand("20015222008_db.UrunBul", conn);
                    komut.CommandType = System.Data.CommandType.StoredProcedure;
                    komut.Parameters.AddWithValue("@filtre", filtre);
                }

                DataSet dataSet = new DataSet();
                MySqlDataAdapter adp = new MySqlDataAdapter(komut);
                adp.Fill(dataSet);

                return dataSet;

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (conn.State != System.Data.ConnectionState.Closed)
                    conn.Close();
            }
        }
        internal static int UrunGüncelle(Urun u)
        {
            try
            {
                if (conn.State != System.Data.ConnectionState.Open)
                    conn.Open();

                MySqlCommand komut = new MySqlCommand("20015222008_db.UrunGuncelle", conn);
                komut.CommandType = System.Data.CommandType.StoredProcedure;
                komut.Parameters.AddWithValue("@id", u.ID);
                komut.Parameters.AddWithValue("@ad", u.Ad);
                komut.Parameters.AddWithValue("@kategori", u.Kategori);
                komut.Parameters.AddWithValue("@fiyat", u.Fiyat);
                komut.Parameters.AddWithValue("@stok", u.Stok);
                komut.Parameters.AddWithValue("@birim", u.Birim);
                komut.Parameters.AddWithValue("@detay", u.Detay);

                int res = komut.ExecuteNonQuery();
                return res;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (conn.State != System.Data.ConnectionState.Closed)
                    conn.Close();
            }
        }
        internal static int UrunSil(string id)
        {
            try
            {
                if (conn.State != System.Data.ConnectionState.Open)
                    conn.Open();

                MySqlCommand komut = new MySqlCommand("20015222008_Urunsil", conn);
                komut.CommandType = System.Data.CommandType.StoredProcedure;
                komut.Parameters.AddWithValue("@id", id);

                int res = komut.ExecuteNonQuery();
                return res;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (conn.State != System.Data.ConnectionState.Closed)
                    conn.Close();
            }
        }
        internal static int SatisSil(string id)
        {
            try
            {
                if (conn.State != System.Data.ConnectionState.Open)
                    conn.Open();

                MySqlCommand komut = new MySqlCommand("20015222008_db.SatisSil", conn);
                komut.CommandType = System.Data.CommandType.StoredProcedure;
                komut.Parameters.AddWithValue("@id", id);

                int res = komut.ExecuteNonQuery();
                return res;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (conn.State != System.Data.ConnectionState.Closed)
                    conn.Close();
            }
        }
        internal static int SatisEkle(Satis s)
        {
            try
            {
                if (conn.State != System.Data.ConnectionState.Open)
                    conn.Open();

                MySqlCommand komut = new MySqlCommand("20015222008_db.SatissEkle", conn);
                komut.CommandType = System.Data.CommandType.StoredProcedure;
                komut.Parameters.AddWithValue("@sid", s.ID);
                komut.Parameters.AddWithValue("@mid", s.MusteriID);
                komut.Parameters.AddWithValue("@uid", s.UrunID);
                komut.Parameters.AddWithValue("@tarih", s.Tarih);
                komut.Parameters.AddWithValue("@fiyat", s.Fiyat);

                int res = komut.ExecuteNonQuery();
                return res;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (conn.State != System.Data.ConnectionState.Closed)
                    conn.Close();
            }

        }
        internal static int OdemeEkle(Odeme o)
        {
            try
            {
                if (conn.State != System.Data.ConnectionState.Open)
                    conn.Open();

                MySqlCommand komut = new MySqlCommand("20015222008_db.OdemeEkle", conn);
                komut.CommandType = System.Data.CommandType.StoredProcedure;
                komut.Parameters.AddWithValue("@oid", o.ID);
                komut.Parameters.AddWithValue("@mid", o.MusteriID);
                komut.Parameters.AddWithValue("@tarih", o.Tarih);
                komut.Parameters.AddWithValue("@tutar", o.Tutar);
                komut.Parameters.AddWithValue("@tur", o.Tur);
                komut.Parameters.AddWithValue("@aciklama", o.Aciklama);

                int res = komut.ExecuteNonQuery();
                return res;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (conn.State != System.Data.ConnectionState.Closed)
                    conn.Close();
            }
        }
        internal static int OdemeGüncelle(Odeme o)
        {
            try
            {
                if (conn.State != System.Data.ConnectionState.Open)
                    conn.Open();

                MySqlCommand komut = new MySqlCommand("20015222008_db.OdemeGuncelle", conn);
                komut.CommandType = System.Data.CommandType.StoredProcedure;
                komut.Parameters.AddWithValue("@oid", o.ID);
                komut.Parameters.AddWithValue("@mid", o.MusteriID);
                komut.Parameters.AddWithValue("@tarih", o.Tarih);
                komut.Parameters.AddWithValue("@tutar", o.Tutar);
                komut.Parameters.AddWithValue("@tur", o.Tur);
                komut.Parameters.AddWithValue("@aciklama", o.Aciklama);

                int res = komut.ExecuteNonQuery();
                return res;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (conn.State != System.Data.ConnectionState.Closed)
                    conn.Close();
            }
        }
        internal static int SatisGüncelle(Satis s)
        {
            try
            {
                if (conn.State != System.Data.ConnectionState.Open)
                    conn.Open();

                MySqlCommand komut = new MySqlCommand("20015222008_db.Satisguncelle", conn);
                komut.CommandType = System.Data.CommandType.StoredProcedure;
                komut.Parameters.AddWithValue("@sid", s.ID);
                komut.Parameters.AddWithValue("@mid", s.MusteriID);
                komut.Parameters.AddWithValue("@uid", s.UrunID);
                komut.Parameters.AddWithValue("@tarih", s.Tarih);
                komut.Parameters.AddWithValue("@fiyat", s.Fiyat);


                int res = komut.ExecuteNonQuery();
                return res;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (conn.State != System.Data.ConnectionState.Closed)
                    conn.Close();
            }
        }

        internal static DataSet SatisDeyat()
        {
            try
            {
                if (conn.State != System.Data.ConnectionState.Open)
                    conn.Open();

                MySqlCommand komut = new MySqlCommand("20015222008_db.SatisDetayi", conn);
                komut.CommandType = System.Data.CommandType.StoredProcedure;


                DataSet dataSet = new DataSet();
                MySqlDataAdapter adp = new MySqlDataAdapter(komut);
                adp.Fill(dataSet);

                return dataSet;

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (conn.State != System.Data.ConnectionState.Closed)
                    conn.Close();
            }
        }

        internal static DataSet OdemeDetay()
        {
            try
            {
                if (conn.State != System.Data.ConnectionState.Open)
                    conn.Open();

                MySqlCommand komut = new MySqlCommand("20015222008_db.OdemeDetay", conn);
                komut.CommandType = System.Data.CommandType.StoredProcedure;


                DataSet dataSet = new DataSet();
                MySqlDataAdapter adp = new MySqlDataAdapter(komut);
                adp.Fill(dataSet);

                return dataSet;

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (conn.State != System.Data.ConnectionState.Closed)
                    conn.Close();
            }
        }

        internal static int OdemeSil(string id)
        {
            try
            {
                if (conn.State != System.Data.ConnectionState.Open)
                    conn.Open();

                MySqlCommand komut = new MySqlCommand("20015222008_db.Odemesil", conn);
                komut.CommandType = System.Data.CommandType.StoredProcedure;
                komut.Parameters.AddWithValue("@oid", id);


                int res = komut.ExecuteNonQuery();
                return res;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (conn.State != System.Data.ConnectionState.Closed)
                    conn.Close();
            }
        }
    }
}
