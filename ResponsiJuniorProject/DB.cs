using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResponsiJuniorProject
{
    internal class DB
    {
        private NpgsqlConnection conn;
        string connString = "Host=localhost;Port=2022;Username=postgres;Password=informatika;Database=responsi_junpro";
        public static NpgsqlCommand cmd;

        public DB()
        {
            conn = new NpgsqlConnection(connString);
        }

        public List<Karyawan> LoadData()
        {
            List<Karyawan> returnList = new List<Karyawan>();

            conn.Open();
            string sql = "select * from karyawan_select()";
            cmd = new NpgsqlCommand(sql, conn);
            NpgsqlDataReader reader = cmd.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    int karyawanId = (int)reader["_id"];
                    string karyawanName = (string)reader["_nama"];
                    string karyawanDep = (string)reader["_kode_dep"];
                    int karyawanIdDep = (int)reader["_id_dep"];
                    Karyawan karyawan = new Karyawan(karyawanId, karyawanName, karyawanDep, karyawanIdDep);
                    returnList.Add(karyawan);
                }
            }

            conn.Close();
            return returnList;
        }

        public void InsertData(string nama, int depID)
        {
            conn.Open();
            string sql = "select * from karyawan_insert(:_nama, :_dep)";
            cmd = new NpgsqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("_nama", nama);
            cmd.Parameters.AddWithValue("_dep", depID);

            if ((int)cmd.ExecuteScalar() > 0)
            {
                MessageBox.Show("data berhasil ditambahkan", "SUCCESS NGAB", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("data GAGAL ditambahkan", "ERROR!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            conn.Close();
        }

        public void UpdateData(int karyawanID, string nama, int depID)
        {
            conn.Open();
            string sql = "select * from karyawan_update(:_id, :_nama, :_dep)";
            cmd = new NpgsqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("_id", karyawanID);
            cmd.Parameters.AddWithValue("_nama", nama);
            cmd.Parameters.AddWithValue("_dep", depID);

            if ((int)cmd.ExecuteScalar() > 0)
            {
                MessageBox.Show("data berhasil diupdate", "SUCCESS NGAB", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("data GAGAL diupdate", "ERROR!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            conn.Close();
        }

        public void DeleteData(int karyawanID)
        {
            conn.Open();
            string sql = "select * from karyawan_delete(:_id)";
            cmd = new NpgsqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("_id", karyawanID);

            if ((int)cmd.ExecuteScalar() > 0)
            {
                MessageBox.Show("data berhasil dihapus", "SUCCESS NGAB", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("data GAGAL dihapus", "ERROR!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            conn.Close();
        }
    }
}
