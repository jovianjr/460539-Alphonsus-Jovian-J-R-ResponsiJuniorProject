using System.Diagnostics;

namespace ResponsiJuniorProject
{
    public partial class Form1 : Form
    {
        DB db = new DB();
        private int currKaryawanID;
        private int currDepID;
        private List<Karyawan> currKaryawanList;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            string nama = tbNamaKaryawan.Text;
            int depID = Int32.Parse(tbDepartemenID.Text);

            db.InsertData(nama, depID);
            LoadData();
        }

        private void LoadData()
        {
            List<Karyawan> karyawanList = db.LoadData();

            foreach (Karyawan karyawan in karyawanList)
            {
                Debug.WriteLine(karyawan.Name);
            }

            currKaryawanList = karyawanList;
            dgKaryawan.DataSource = karyawanList;
        }

        private void dgKaryawan_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            Debug.WriteLine(e.RowIndex);
            Karyawan currKaryawan = currKaryawanList[e.RowIndex];

            tbNamaKaryawan.Text = currKaryawan.Name;
            tbDepartemen.Text = currKaryawan.Departemen;
            tbDepartemenID.Text = currKaryawan.DepartemenID.ToString();
            currKaryawanID = currKaryawan.Id;
            currDepID = currKaryawan.DepartemenID;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            string nama = tbNamaKaryawan.Text;

            db.UpdateData(currKaryawanID, nama, currDepID);
            LoadData();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            db.DeleteData(currKaryawanID);
            LoadData();
        }
    }
}