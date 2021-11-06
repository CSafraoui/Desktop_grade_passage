using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework;
using MetroFramework.Forms;

namespace candidat_projet
{
    public partial class Form2 : Form
    {
        List<Panel> listPanel = new List<Panel>();
        Boolean insererA31 = false;
        Boolean insererA32 = false;
        Boolean insererA331 = false;
        Boolean insererA332 = false;
        Boolean insererA341 = false;
        Boolean insererA342 = false;
        Boolean insererA343 = false;
        Boolean insererA344 = false;
        Boolean insererA35 = false;

        private SqlConnection getConnection()
        {
            return new SqlConnection(@" Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename =C:\Users\khali\Desktop\S8\GI S8\DotNet\candidat_projet\candidat_projet\Database1.mdf; Integrated Security = True");

        }



        int index;
        String id_session;
        public Form2(String id_session)
        {
            InitializeComponent();
            this.id_session = id_session;
            Console.WriteLine(id_session);

        }

        private void Form2_Load(object sender, EventArgs e)
        {
            listPanel.Add(panel1);
            listPanel.Add(panel3);

            listPanel[index].BringToFront();
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void activite_enseignementBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.activite_enseignementBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.database1DataSet1);

        }

        private void metroButton3_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void A12Btn_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        protected void BindDataGridView()
        {
            using (SqlConnection con = new SqlConnection(@" Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename =C:\Users\khali\Desktop\S8\GI S8\DotNet\candidat_projet\candidat_projet\Database1.mdf; Integrated Security = True")
)
            {
                using (SqlCommand cmd = new SqlCommand("SELECT Id_activite_A,ressource_name FROM Activite_enseignement where condidat = @id_session and num_quesstion = @num", con))
                {
                    cmd.Parameters.AddWithValue("@id_session", id_session);
                    cmd.Parameters.AddWithValue("@num", "A11");
                    cmd.CommandType = CommandType.Text;
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        sda.Fill(dt);
                        this.activite_enseignementDataGridView.DataSource = dt;
                    }
                }
            }

        }
        private void A11Btn_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@" Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename =C:\Users\khali\Desktop\S8\GI S8\DotNet\candidat_projet\candidat_projet\Database1.mdf; Integrated Security = True");

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Multiselect = true;
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    foreach (string fileNames in openFileDialog.FileNames)
                    {
                        string contentType = "";
                        switch (Path.GetExtension(fileNames).ToLower())
                        {
                            case ".jpg":
                                contentType = ".jpg";
                                break;
                            case ".png":
                                contentType = ".png";
                                break;
                            case ".gif":
                                contentType = ".gif";
                                break;
                            case ".bmp":
                                contentType = ".bmp";
                                break;
                            case ".doc":
                                contentType = ".msword";
                                break;
                            case ".docx":
                                contentType = "application/vnd.openxmlformats-officedocument.wordprocessingml.document";
                                break;
                            case ".xls":
                                contentType = "application/vnd.ms-excel";
                                break;
                            case ".xlsx":
                                contentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                                break;
                            case ".pdf":
                                contentType = "application/pdf";
                                break;
                            case ".ppt":
                                contentType = "application/vnd.ms-powerpoint";
                                break;
                            case ".pptx":
                                contentType = "application/vnd.openxmlformats-officedocument.presentationml.presentation";
                                break;
                        }
                        byte[] bytes = File.ReadAllBytes(fileNames);

                        var query = "INSERT INTO Activite_enseignement (condidat, num_quesstion, ressource_name, ressource_type, ressource_data) VALUES(@id_session, @num_quesstion, @ressource_name, @ressource_type, @ressource_data) ";


                        SqlCommand cmd = new SqlCommand(query, con);
                        cmd.Parameters.AddWithValue("@ressource_name", Path.GetFileName(fileNames));
                        cmd.Parameters.AddWithValue("@ressource_type", contentType);
                        cmd.Parameters.AddWithValue("@ressource_data", bytes);
                        cmd.Parameters.AddWithValue("@id_session", id_session);
                        cmd.Parameters.AddWithValue("@num_quesstion", "A11");

                        con.Open();
                        
                            int a = cmd.ExecuteNonQuery();
                            if (a == 0)
                            {
                                Console.WriteLine("nop");
                            }
                            else
                            {
                                Console.WriteLine("done");
                                MessageBox.Show("Fichier ajoute", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
                              
                            }
                        

                    }
                }
            }
            this.BindDataGridView();
        }


        private void openFile(int id)
        {
            using (SqlConnection con = new SqlConnection(@" Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename =C:\Users\khali\Desktop\S8\GI S8\DotNet\candidat_projet\candidat_projet\Database1.mdf; Integrated Security = True"))
            {
                string query = "SELECT Id_activite_A,ressource_data,ressource_name,ressource_type from Activite_enseignement where Id_activite_A=@id";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;
                con.Open();

                var reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    var name = reader["ressource_name"].ToString();
                    var data = (byte[])reader["ressource_data"];
                    var extn = reader["ressource_type"].ToString();
                    var newFileName = name.Replace(extn, DateTime.Now.ToString("ddMMyyyyhhmmss")) + extn;
                    File.WriteAllBytes(newFileName, data);
                    System.Diagnostics.Process.Start(newFileName);

                }
            }
        }

        private void openBtn_Click(object sender, EventArgs e)
        {
            var selectedRow = activite_enseignementDataGridView.SelectedRows;
            foreach (var row in selectedRow)
            {
                var id = (int)((DataGridViewRow)row).Cells[0].Value;
                openFile(id);
            }
        }

        private void activite_enseignementDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void quitterBtn_Click(object sender, EventArgs e)
        {

        }

        private void precedentBtn_Click(object sender, EventArgs e)
        {
            if (index > 0)
            {
                listPanel[--index].BringToFront();
            }
        }

        private void suivantBtn_Click(object sender, EventArgs e)
        {
            if (index < listPanel.Count - 1)
            {
                listPanel[++index].BringToFront();
            }
        }

        
        private void supprimerBtn_Click(object sender, EventArgs e)
        {
            
                using (SqlConnection con = new SqlConnection(@" Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename =C:\Users\khali\Desktop\S8\GI S8\DotNet\candidat_projet\candidat_projet\Database1.mdf; Integrated Security = True"))
                {
                    var selectedRow = activite_enseignementDataGridView.SelectedRows;
                    foreach (var row in selectedRow)
                    {
                        var id = (int)((DataGridViewRow)row).Cells[0].Value;
                        var query = "delete from Activite_enseignement where Id_activite_A = @id_activite";


                        SqlCommand cmd = new SqlCommand(query, con);
                        cmd.Parameters.AddWithValue("@id_activite", id);

                        con.Open();
                        int a = cmd.ExecuteNonQuery();
                        if (a == 0)
                        {
                            Console.WriteLine("nop");
                        }
                        else
                        {
                            Console.WriteLine("done");
                            
                            MessageBox.Show("Fichier supprime", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.BindDataGridView();
                        }
                    }
                }
            

        }

        private void metroButton11_Click(object sender, EventArgs e)
        {

        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@" Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename =C:\Users\khali\Desktop\S8\GI S8\DotNet\candidat_projet\candidat_projet\Database1.mdf; Integrated Security = True");

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Multiselect = true;
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    foreach (string fileNames in openFileDialog.FileNames)
                    {
                        string contentType = "";
                        switch (Path.GetExtension(fileNames).ToLower())
                        {
                            case ".jpg":
                                contentType = ".jpg";
                                break;
                            case ".png":
                                contentType = ".png";
                                break;
                            case ".gif":
                                contentType = ".gif";
                                break;
                            case ".bmp":
                                contentType = ".bmp";
                                break;
                            case ".doc":
                                contentType = ".msword";
                                break;
                            case ".docx":
                                contentType = "application/vnd.openxmlformats-officedocument.wordprocessingml.document";
                                break;
                            case ".xls":
                                contentType = "application/vnd.ms-excel";
                                break;
                            case ".xlsx":
                                contentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                                break;
                            case ".pdf":
                                contentType = "application/pdf";
                                break;
                            case ".ppt":
                                contentType = "application/vnd.ms-powerpoint";
                                break;
                            case ".pptx":
                                contentType = "application/vnd.openxmlformats-officedocument.presentationml.presentation";
                                break;
                        }
                        byte[] bytes = File.ReadAllBytes(fileNames);

                        var query = "INSERT INTO Activite_enseignement (condidat, num_quesstion, ressource_name, ressource_type, ressource_data) VALUES(@id_session, @num_quesstion, @ressource_name, @ressource_type, @ressource_data) ";


                        SqlCommand cmd = new SqlCommand(query, con);
                        cmd.Parameters.AddWithValue("@ressource_name", Path.GetFileName(fileNames));
                        cmd.Parameters.AddWithValue("@ressource_type", contentType);
                        cmd.Parameters.AddWithValue("@ressource_data", bytes);
                        cmd.Parameters.AddWithValue("@id_session", id_session);
                        cmd.Parameters.AddWithValue("@num_quesstion", "A11");

                        con.Open();
                        
                            int a = cmd.ExecuteNonQuery();
                            if (a == 0)
                            {
                                Console.WriteLine("nop");
                            }
                            else
                            {
                                Console.WriteLine("done");
                                MessageBox.Show("Fichier ajoute", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
                              
                            }
                       

                    }
                }
            }
            this.BindDataGridView();
        }

        private void afficherBtnA31_Click(object sender, EventArgs e)
        {
            var selectedRow = activite_enseignementDataGridView.SelectedRows;
            foreach (var row in selectedRow)
            {
                var id = (int)((DataGridViewRow)row).Cells[0].Value;
                openFile(id);
            }
        }

        private void supprimerBtnA31_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(@" Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename =C:\Users\khali\Desktop\S8\GI S8\DotNet\candidat_projet\candidat_projet\Database1.mdf; Integrated Security = True"))
            {
                var selectedRow = activite_enseignementDataGridView.SelectedRows;
                foreach (var row in selectedRow)
                {
                    var id = (int)((DataGridViewRow)row).Cells[0].Value;
                    var query = "delete from Activite_enseignement where Id_activite_A = @id_activite";


                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@id_activite", id);

                    con.Open();
                    int a = cmd.ExecuteNonQuery();
                    if (a == 0)
                    {
                        Console.WriteLine("nop");
                    }
                    else
                    {
                        Console.WriteLine("done");
                        
                        MessageBox.Show("Fichier supprime", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.BindDataGridView();
                    }
                }
            }

        }

        private void ajouterBtnA12_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@" Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename =C:\Users\khali\Desktop\S8\GI S8\DotNet\candidat_projet\candidat_projet\Database1.mdf; Integrated Security = True");

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Multiselect = true;
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    foreach (string fileNames in openFileDialog.FileNames)
                    {
                        string contentType = "";
                        switch (Path.GetExtension(fileNames).ToLower())
                        {
                            case ".jpg":
                                contentType = ".jpg";
                                break;
                            case ".png":
                                contentType = ".png";
                                break;
                            case ".gif":
                                contentType = ".gif";
                                break;
                            case ".bmp":
                                contentType = ".bmp";
                                break;
                            case ".doc":
                                contentType = ".msword";
                                break;
                            case ".docx":
                                contentType = "application/vnd.openxmlformats-officedocument.wordprocessingml.document";
                                break;
                            case ".xls":
                                contentType = "application/vnd.ms-excel";
                                break;
                            case ".xlsx":
                                contentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                                break;
                            case ".pdf":
                                contentType = "application/pdf";
                                break;
                            case ".ppt":
                                contentType = "application/vnd.ms-powerpoint";
                                break;
                            case ".pptx":
                                contentType = "application/vnd.openxmlformats-officedocument.presentationml.presentation";
                                break;
                        }
                        byte[] bytes = File.ReadAllBytes(fileNames);

                        var query = "INSERT INTO Activite_enseignement (condidat, num_quesstion, ressource_name, ressource_type, ressource_data) VALUES(@id_session, @num_quesstion, @ressource_name, @ressource_type, @ressource_data) ";


                        SqlCommand cmd = new SqlCommand(query, con);
                        cmd.Parameters.AddWithValue("@ressource_name", Path.GetFileName(fileNames));
                        cmd.Parameters.AddWithValue("@ressource_type", contentType);
                        cmd.Parameters.AddWithValue("@ressource_data", bytes);
                        cmd.Parameters.AddWithValue("@id_session", id_session);
                        cmd.Parameters.AddWithValue("@num_quesstion", "A12");

                        con.Open();

                        int a = cmd.ExecuteNonQuery();
                        if (a == 0)
                        {
                            Console.WriteLine("nop");
                        }
                        else
                        {
                            Console.WriteLine("done");
                            MessageBox.Show("Fichier ajoute", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        }


                    }
                }
            }
            using (SqlCommand cmd = new SqlCommand("SELECT Id_activite_A,ressource_name FROM Activite_enseignement where condidat = @id_session and num_quesstion = @num", con))
            {
                cmd.Parameters.AddWithValue("@id_session", id_session);
                cmd.Parameters.AddWithValue("@num", "A12");
                cmd.CommandType = CommandType.Text;
                using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    this.dataGridView1.DataSource = dt;
                }
            }
        }

        private void supprimerBtnA12_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(@" Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename =C:\Users\khali\Desktop\S8\GI S8\DotNet\candidat_projet\candidat_projet\Database1.mdf; Integrated Security = True"))
            {
                var selectedRow = dataGridView1.SelectedRows;
                foreach (var row in selectedRow)
                {
                    var id = (int)((DataGridViewRow)row).Cells[0].Value;
                    var query = "delete from Activite_enseignement where Id_activite_A = @id_activite";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@id_activite", id);
                    con.Open();
                    int a = cmd.ExecuteNonQuery();
                    if (a == 0)
                    {
                        Console.WriteLine("nop");
                    }
                    else
                    {
                        Console.WriteLine("done");
                        MessageBox.Show("Fichier supprime", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        using (cmd = new SqlCommand("SELECT Id_activite_A,ressource_name FROM Activite_enseignement where condidat = @id_session and num_quesstion = @num", con))
                        {
                            cmd.Parameters.AddWithValue("@id_session", id_session);
                            cmd.Parameters.AddWithValue("@num", "A12");
                            cmd.CommandType = CommandType.Text;
                            using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                            {
                                DataTable dt = new DataTable();
                                sda.Fill(dt);
                                this.dataGridView1.DataSource = dt;
                            }
                        }
                    }
                }
            }
        }

        private void afficherBtnA12_Click(object sender, EventArgs e)
        {
            var selectedRow = dataGridView1.SelectedRows;
            foreach (var row in selectedRow)
            {
                var id = (int)((DataGridViewRow)row).Cells[0].Value;
                openFile(id);
            }
        }

        private void ajouterBtnA13_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@" Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename =C:\Users\khali\Desktop\S8\GI S8\DotNet\candidat_projet\candidat_projet\Database1.mdf; Integrated Security = True");
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Multiselect = true;
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    foreach (string fileNames in openFileDialog.FileNames)
                    {
                        string contentType = "";
                        switch (Path.GetExtension(fileNames).ToLower())
                        {
                            case ".jpg":
                                contentType = ".jpg";
                                break;
                            case ".png":
                                contentType = ".png";
                                break;
                            case ".gif":
                                contentType = ".gif";
                                break;
                            case ".bmp":
                                contentType = ".bmp";
                                break;
                            case ".doc":
                                contentType = ".msword";
                                break;
                            case ".docx":
                                contentType = "application/vnd.openxmlformats-officedocument.wordprocessingml.document";
                                break;
                            case ".xls":
                                contentType = "application/vnd.ms-excel";
                                break;
                            case ".xlsx":
                                contentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                                break;
                            case ".pdf":
                                contentType = "application/pdf";
                                break;
                            case ".ppt":
                                contentType = "application/vnd.ms-powerpoint";
                                break;
                            case ".pptx":
                                contentType = "application/vnd.openxmlformats-officedocument.presentationml.presentation";
                                break;
                        }
                        byte[] bytes = File.ReadAllBytes(fileNames);

                        var query = "INSERT INTO Activite_enseignement (condidat, num_quesstion, ressource_name, ressource_type, ressource_data) VALUES(@id_session, @num_quesstion, @ressource_name, @ressource_type, @ressource_data) ";


                        SqlCommand cmd = new SqlCommand(query, con);
                        cmd.Parameters.AddWithValue("@ressource_name", Path.GetFileName(fileNames));
                        cmd.Parameters.AddWithValue("@ressource_type", contentType);
                        cmd.Parameters.AddWithValue("@ressource_data", bytes);
                        cmd.Parameters.AddWithValue("@id_session", id_session);
                        cmd.Parameters.AddWithValue("@num_quesstion", "A13");
                        con.Open();
                        int a = cmd.ExecuteNonQuery();
                        if (a == 0)
                        {
                            Console.WriteLine("nop");
                        }
                        else
                        {
                            Console.WriteLine("done");
                            MessageBox.Show("Fichier ajoute", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        }
                    }
                }
            }
            using (SqlCommand cmd = new SqlCommand("SELECT Id_activite_A,ressource_name FROM Activite_enseignement where condidat = @id_session and num_quesstion = @num", con))
            {
                cmd.Parameters.AddWithValue("@id_session", id_session);
                cmd.Parameters.AddWithValue("@num", "A13");
                cmd.CommandType = CommandType.Text;
                using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    this.dataGridView2.DataSource = dt;
                }
            }
        }

        private void supprimerBtnA13_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(@" Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename =C:\Users\khali\Desktop\S8\GI S8\DotNet\candidat_projet\candidat_projet\Database1.mdf; Integrated Security = True"))
            {
                var selectedRow = dataGridView2.SelectedRows;
                foreach (var row in selectedRow)
                {
                    var id = (int)((DataGridViewRow)row).Cells[0].Value;
                    var query = "delete from Activite_enseignement where Id_activite_A = @id_activite";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@id_activite", id);
                    con.Open();
                    int a = cmd.ExecuteNonQuery();
                    if (a == 0)
                    {
                        Console.WriteLine("nope");
                    }
                    else
                    {
                        Console.WriteLine("done");
                        MessageBox.Show("Fichier supprime", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        using (cmd = new SqlCommand("SELECT Id_activite_A,ressource_name FROM Activite_enseignement where condidat = @id_session and num_quesstion = @num", con))
                        {
                            cmd.Parameters.AddWithValue("@id_session", id_session);
                            cmd.Parameters.AddWithValue("@num", "A13");
                            cmd.CommandType = CommandType.Text;
                            using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                            {
                                DataTable dt = new DataTable();
                                sda.Fill(dt);
                                this.dataGridView2.DataSource = dt;
                            }
                        }
                    }
                }
            }
        }

        private void afficherBtnA13_Click(object sender, EventArgs e)
        {
            var selectedRow = dataGridView2.SelectedRows;
            foreach (var row in selectedRow)
            {
                var id = (int)((DataGridViewRow)row).Cells[0].Value;
                openFile(id);
            }
        }

        private void ajouterBtnA211_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@" Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename =C:\Users\khali\Desktop\S8\GI S8\DotNet\candidat_projet\candidat_projet\Database1.mdf; Integrated Security = True");
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Multiselect = true;
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    foreach (string fileNames in openFileDialog.FileNames)
                    {
                        string contentType = "";
                        switch (Path.GetExtension(fileNames).ToLower())
                        {
                            case ".jpg":
                                contentType = ".jpg";
                                break;
                            case ".png":
                                contentType = ".png";
                                break;
                            case ".gif":
                                contentType = ".gif";
                                break;
                            case ".bmp":
                                contentType = ".bmp";
                                break;
                            case ".doc":
                                contentType = ".msword";
                                break;
                            case ".docx":
                                contentType = "application/vnd.openxmlformats-officedocument.wordprocessingml.document";
                                break;
                            case ".xls":
                                contentType = "application/vnd.ms-excel";
                                break;
                            case ".xlsx":
                                contentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                                break;
                            case ".pdf":
                                contentType = "application/pdf";
                                break;
                            case ".ppt":
                                contentType = "application/vnd.ms-powerpoint";
                                break;
                            case ".pptx":
                                contentType = "application/vnd.openxmlformats-officedocument.presentationml.presentation";
                                break;
                        }
                        byte[] bytes = File.ReadAllBytes(fileNames);

                        var query = "INSERT INTO Activite_enseignement (condidat, num_quesstion, ressource_name, ressource_type, ressource_data) VALUES(@id_session, @num_quesstion, @ressource_name, @ressource_type, @ressource_data) ";


                        SqlCommand cmd = new SqlCommand(query, con);
                        cmd.Parameters.AddWithValue("@ressource_name", Path.GetFileName(fileNames));
                        cmd.Parameters.AddWithValue("@ressource_type", contentType);
                        cmd.Parameters.AddWithValue("@ressource_data", bytes);
                        cmd.Parameters.AddWithValue("@id_session", id_session);
                        cmd.Parameters.AddWithValue("@num_quesstion", "A211");
                        con.Open();
                        int a = cmd.ExecuteNonQuery();
                        if (a == 0)
                        {
                            Console.WriteLine("nop");
                        }
                        else
                        {
                            Console.WriteLine("done");
                            MessageBox.Show("Fichier ajoute", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        }
                    }
                }
            }
            using (SqlCommand cmd = new SqlCommand("SELECT Id_activite_A,ressource_name FROM Activite_enseignement where condidat = @id_session and num_quesstion = @num", con))
            {
                cmd.Parameters.AddWithValue("@id_session", id_session);
                cmd.Parameters.AddWithValue("@num", "A211");
                cmd.CommandType = CommandType.Text;
                using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    this.dataGridView4.DataSource = dt;
                }
            }
        }

        private void supprimerBtnA211_Click(object sender, EventArgs e)
        {
                using (SqlConnection con = new SqlConnection(@" Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename =C:\Users\khali\Desktop\S8\GI S8\DotNet\candidat_projet\candidat_projet\Database1.mdf; Integrated Security = True"))
                {
                    var selectedRow = dataGridView4.SelectedRows;
                    foreach (var row in selectedRow)
                    {
                        var id = (int)((DataGridViewRow)row).Cells[0].Value;
                        var query = "delete from Activite_enseignement where Id_activite_A = @id_activite";
                        SqlCommand cmd = new SqlCommand(query, con);
                        cmd.Parameters.AddWithValue("@id_activite", id);
                        con.Open();
                        int a = cmd.ExecuteNonQuery();
                        if (a == 0)
                        {
                            Console.WriteLine("nope");
                        }
                        else
                        {
                            Console.WriteLine("done");
                            MessageBox.Show("Fichier supprime", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            using (cmd = new SqlCommand("SELECT Id_activite_A,ressource_name FROM Activite_enseignement where condidat = @id_session and num_quesstion = @num", con))
                            {
                                cmd.Parameters.AddWithValue("@id_session", id_session);
                                cmd.Parameters.AddWithValue("@num", "A211");
                                cmd.CommandType = CommandType.Text;
                                using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                                {
                                    DataTable dt = new DataTable();
                                    sda.Fill(dt);
                                    this.dataGridView4.DataSource = dt;
                                }
                            }
                        }
                    }
                }
            
        }

        private void afficherBtnA211_Click(object sender, EventArgs e)
        {
            var selectedRow = dataGridView4.SelectedRows;
            foreach (var row in selectedRow)
            {
                var id = (int)((DataGridViewRow)row).Cells[0].Value;
                openFile(id);
            }
        }

        private void ajouterBtnA212_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@" Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename =C:\Users\khali\Desktop\S8\GI S8\DotNet\candidat_projet\candidat_projet\Database1.mdf; Integrated Security = True");
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Multiselect = true;
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    foreach (string fileNames in openFileDialog.FileNames)
                    {
                        string contentType = "";
                        switch (Path.GetExtension(fileNames).ToLower())
                        {
                            case ".jpg":
                                contentType = ".jpg";
                                break;
                            case ".png":
                                contentType = ".png";
                                break;
                            case ".gif":
                                contentType = ".gif";
                                break;
                            case ".bmp":
                                contentType = ".bmp";
                                break;
                            case ".doc":
                                contentType = ".msword";
                                break;
                            case ".docx":
                                contentType = "application/vnd.openxmlformats-officedocument.wordprocessingml.document";
                                break;
                            case ".xls":
                                contentType = "application/vnd.ms-excel";
                                break;
                            case ".xlsx":
                                contentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                                break;
                            case ".pdf":
                                contentType = "application/pdf";
                                break;
                            case ".ppt":
                                contentType = "application/vnd.ms-powerpoint";
                                break;
                            case ".pptx":
                                contentType = "application/vnd.openxmlformats-officedocument.presentationml.presentation";
                                break;
                        }
                        byte[] bytes = File.ReadAllBytes(fileNames);

                        var query = "INSERT INTO Activite_enseignement (condidat, num_quesstion, ressource_name, ressource_type, ressource_data) VALUES(@id_session, @num_quesstion, @ressource_name, @ressource_type, @ressource_data) ";

                        SqlCommand cmd = new SqlCommand(query, con);
                        cmd.Parameters.AddWithValue("@ressource_name", Path.GetFileName(fileNames));
                        cmd.Parameters.AddWithValue("@ressource_type", contentType);
                        cmd.Parameters.AddWithValue("@ressource_data", bytes);
                        cmd.Parameters.AddWithValue("@id_session", id_session);
                        cmd.Parameters.AddWithValue("@num_quesstion", "A212");
                        con.Open();
                        int a = cmd.ExecuteNonQuery();
                        if (a == 0)
                        {
                            Console.WriteLine("nop");
                        }
                        else
                        {
                            Console.WriteLine("done");
                            MessageBox.Show("Fichier ajoute", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        }
                    }
                }
            }
            using (SqlCommand cmd = new SqlCommand("SELECT Id_activite_A,ressource_name FROM Activite_enseignement where condidat = @id_session and num_quesstion = @num", con))
            {
                cmd.Parameters.AddWithValue("@id_session", id_session);
                cmd.Parameters.AddWithValue("@num", "A212");
                cmd.CommandType = CommandType.Text;
                using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    this.dataGridView3.DataSource = dt;
                }
            }
        }

        private void supprimerBtnA212_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(@" Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename =C:\Users\khali\Desktop\S8\GI S8\DotNet\candidat_projet\candidat_projet\Database1.mdf; Integrated Security = True"))
            {
                var selectedRow = dataGridView3.SelectedRows;
                foreach (var row in selectedRow)
                {
                    var id = (int)((DataGridViewRow)row).Cells[0].Value;
                    var query = "delete from Activite_enseignement where Id_activite_A = @id_activite";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@id_activite", id);
                    con.Open();
                    int a = cmd.ExecuteNonQuery();
                    if (a == 0)
                    {
                        Console.WriteLine("nope");
                    }
                    else
                    {
                        Console.WriteLine("done");
                        MessageBox.Show("Fichier supprime", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        using (cmd = new SqlCommand("SELECT Id_activite_A,ressource_name FROM Activite_enseignement where condidat = @id_session and num_quesstion = @num", con))
                        {
                            cmd.Parameters.AddWithValue("@id_session", id_session);
                            cmd.Parameters.AddWithValue("@num", "A212");
                            cmd.CommandType = CommandType.Text;
                            using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                            {
                                DataTable dt = new DataTable();
                                sda.Fill(dt);
                                this.dataGridView3.DataSource = dt;
                            }
                        }
                    }
                }
            }
        }

        private void afficherBtnA212_Click(object sender, EventArgs e)
        {
            var selectedRow = dataGridView3.SelectedRows;
            foreach (var row in selectedRow)
            {
                var id = (int)((DataGridViewRow)row).Cells[0].Value;
                openFile(id);
            }
        }

        private void afficherBtnA213_Click(object sender, EventArgs e)
        {
            var selectedRow = dataGridView5.SelectedRows;
            foreach (var row in selectedRow)
            {
                var id = (int)((DataGridViewRow)row).Cells[0].Value;
                openFile(id);
            }
        }

        private void supprimerBtnA213_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(@" Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename =C:\Users\khali\Desktop\S8\GI S8\DotNet\candidat_projet\candidat_projet\Database1.mdf; Integrated Security = True"))
            {
                var selectedRow = dataGridView5.SelectedRows;
                foreach (var row in selectedRow)
                {
                    var id = (int)((DataGridViewRow)row).Cells[0].Value;
                    var query = "delete from Activite_enseignement where Id_activite_A = @id_activite";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@id_activite", id);
                    con.Open();
                    int a = cmd.ExecuteNonQuery();
                    if (a == 0)
                    {
                        Console.WriteLine("nope");
                    }
                    else
                    {
                        Console.WriteLine("done");
                        MessageBox.Show("Fichier supprime", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        using (cmd = new SqlCommand("SELECT Id_activite_A,ressource_name FROM Activite_enseignement where condidat = @id_session and num_quesstion = @num", con))
                        {
                            cmd.Parameters.AddWithValue("@id_session", id_session);
                            cmd.Parameters.AddWithValue("@num", "A213");
                            cmd.CommandType = CommandType.Text;
                            using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                            {
                                DataTable dt = new DataTable();
                                sda.Fill(dt);
                                this.dataGridView5.DataSource = dt;
                            }
                        }
                    }
                }
            }
        }

        private void ajouterBtnA213_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@" Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename =C:\Users\khali\Desktop\S8\GI S8\DotNet\candidat_projet\candidat_projet\Database1.mdf; Integrated Security = True");
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Multiselect = true;
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    foreach (string fileNames in openFileDialog.FileNames)
                    {
                        string contentType = "";
                        switch (Path.GetExtension(fileNames).ToLower())
                        {
                            case ".jpg":
                                contentType = ".jpg";
                                break;
                            case ".png":
                                contentType = ".png";
                                break;
                            case ".gif":
                                contentType = ".gif";
                                break;
                            case ".bmp":
                                contentType = ".bmp";
                                break;
                            case ".doc":
                                contentType = ".msword";
                                break;
                            case ".docx":
                                contentType = "application/vnd.openxmlformats-officedocument.wordprocessingml.document";
                                break;
                            case ".xls":
                                contentType = "application/vnd.ms-excel";
                                break;
                            case ".xlsx":
                                contentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                                break;
                            case ".pdf":
                                contentType = "application/pdf";
                                break;
                            case ".ppt":
                                contentType = "application/vnd.ms-powerpoint";
                                break;
                            case ".pptx":
                                contentType = "application/vnd.openxmlformats-officedocument.presentationml.presentation";
                                break;
                        }
                        byte[] bytes = File.ReadAllBytes(fileNames);

                        var query = "INSERT INTO Activite_enseignement (condidat, num_quesstion, ressource_name, ressource_type, ressource_data) VALUES(@id_session, @num_quesstion, @ressource_name, @ressource_type, @ressource_data) ";

                        SqlCommand cmd = new SqlCommand(query, con);
                        cmd.Parameters.AddWithValue("@ressource_name", Path.GetFileName(fileNames));
                        cmd.Parameters.AddWithValue("@ressource_type", contentType);
                        cmd.Parameters.AddWithValue("@ressource_data", bytes);
                        cmd.Parameters.AddWithValue("@id_session", id_session);
                        cmd.Parameters.AddWithValue("@num_quesstion", "A213");
                        con.Open();
                        int a = cmd.ExecuteNonQuery();
                        if (a == 0)
                        {
                            Console.WriteLine("nop");
                        }
                        else
                        {
                            Console.WriteLine("done");
                            MessageBox.Show("Fichier ajoute", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        }
                    }
                }
            }
            using (SqlCommand cmd = new SqlCommand("SELECT Id_activite_A,ressource_name FROM Activite_enseignement where condidat = @id_session and num_quesstion = @num", con))
            {
                cmd.Parameters.AddWithValue("@id_session", id_session);
                cmd.Parameters.AddWithValue("@num", "A213");
                cmd.CommandType = CommandType.Text;
                using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    this.dataGridView5.DataSource = dt;
                }
            }
        }

        private void bunifuImageButton5_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(@" Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename =C:\Users\khali\Desktop\S8\GI S8\DotNet\candidat_projet\candidat_projet\Database1.mdf; Integrated Security = True"))
            {
                var selectedRow = dataGridView6.SelectedRows;
                foreach (var row in selectedRow)
                {
                    var id = (int)((DataGridViewRow)row).Cells[0].Value;
                    var query = "delete from Activite_enseignement where Id_activite_A = @id_activite";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@id_activite", id);
                    con.Open();
                    int a = cmd.ExecuteNonQuery();
                    if (a == 0)
                    {
                        Console.WriteLine("nope");
                    }
                    else
                    {
                        Console.WriteLine("done");
                        MessageBox.Show("Fichier supprime", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        using (cmd = new SqlCommand("SELECT Id_activite_A,ressource_name FROM Activite_enseignement where condidat = @id_session and num_quesstion = @num", con))
                        {
                            cmd.Parameters.AddWithValue("@id_session", id_session);
                            cmd.Parameters.AddWithValue("@num", "A23");
                            cmd.CommandType = CommandType.Text;
                            using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                            {
                                DataTable dt = new DataTable();
                                sda.Fill(dt);
                                this.dataGridView6.DataSource = dt;
                            }
                        }
                    }
                }
            }
        }

        private void bunifuImageButton6_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@" Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename =C:\Users\khali\Desktop\S8\GI S8\DotNet\candidat_projet\candidat_projet\Database1.mdf; Integrated Security = True");
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Multiselect = true;
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    foreach (string fileNames in openFileDialog.FileNames)
                    {
                        string contentType = "";
                        switch (Path.GetExtension(fileNames).ToLower())
                        {
                            case ".jpg":
                                contentType = ".jpg";
                                break;
                            case ".png":
                                contentType = ".png";
                                break;
                            case ".gif":
                                contentType = ".gif";
                                break;
                            case ".bmp":
                                contentType = ".bmp";
                                break;
                            case ".doc":
                                contentType = ".msword";
                                break;
                            case ".docx":
                                contentType = "application/vnd.openxmlformats-officedocument.wordprocessingml.document";
                                break;
                            case ".xls":
                                contentType = "application/vnd.ms-excel";
                                break;
                            case ".xlsx":
                                contentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                                break;
                            case ".pdf":
                                contentType = "application/pdf";
                                break;
                            case ".ppt":
                                contentType = "application/vnd.ms-powerpoint";
                                break;
                            case ".pptx":
                                contentType = "application/vnd.openxmlformats-officedocument.presentationml.presentation";
                                break;
                        }
                        byte[] bytes = File.ReadAllBytes(fileNames);

                        var query = "INSERT INTO Activite_enseignement (condidat, num_quesstion, ressource_name, ressource_type, ressource_data) VALUES(@id_session, @num_quesstion, @ressource_name, @ressource_type, @ressource_data) ";

                        SqlCommand cmd = new SqlCommand(query, con);
                        cmd.Parameters.AddWithValue("@ressource_name", Path.GetFileName(fileNames));
                        cmd.Parameters.AddWithValue("@ressource_type", contentType);
                        cmd.Parameters.AddWithValue("@ressource_data", bytes);
                        cmd.Parameters.AddWithValue("@id_session", id_session);
                        cmd.Parameters.AddWithValue("@num_quesstion", "A23");
                        con.Open();
                        int a = cmd.ExecuteNonQuery();
                        if (a == 0)
                        {
                            Console.WriteLine("nop");
                        }
                        else
                        {
                            Console.WriteLine("done");
                            MessageBox.Show("Fichier ajoute", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        }
                    }
                }
            }
            using (SqlCommand cmd = new SqlCommand("SELECT Id_activite_A,ressource_name FROM Activite_enseignement where condidat = @id_session and num_quesstion = @num", con))
            {
                cmd.Parameters.AddWithValue("@id_session", id_session);
                cmd.Parameters.AddWithValue("@num", "A23");
                cmd.CommandType = CommandType.Text;
                using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    this.dataGridView6.DataSource = dt;
                }
            }
        }

        private void bunifuImageButton4_Click(object sender, EventArgs e)
        {
            var selectedRow = dataGridView6.SelectedRows;
            foreach (var row in selectedRow)
            {
                var id = (int)((DataGridViewRow)row).Cells[0].Value;
                openFile(id);
            }
        }

        private void afficherBtnA22_Click(object sender, EventArgs e)
        {
            var selectedRow = dataGridView7.SelectedRows;
            foreach (var row in selectedRow)
            {
                var id = (int)((DataGridViewRow)row).Cells[0].Value;
                openFile(id);
            }
        }

        private void supprimerBtnA22_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(@" Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename =C:\Users\khali\Desktop\S8\GI S8\DotNet\candidat_projet\candidat_projet\Database1.mdf; Integrated Security = True"))
            {
                var selectedRow = dataGridView7.SelectedRows;
                foreach (var row in selectedRow)
                {
                    var id = (int)((DataGridViewRow)row).Cells[0].Value;
                    var query = "delete from Activite_enseignement where Id_activite_A = @id_activite";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@id_activite", id);
                    con.Open();
                    int a = cmd.ExecuteNonQuery();
                    if (a == 0)
                    {
                        Console.WriteLine("nope");
                    }
                    else
                    {
                        Console.WriteLine("done");
                        MessageBox.Show("Fichier supprime", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        using (cmd = new SqlCommand("SELECT Id_activite_A,ressource_name FROM Activite_enseignement where condidat = @id_session and num_quesstion = @num", con))
                        {
                            cmd.Parameters.AddWithValue("@id_session", id_session);
                            cmd.Parameters.AddWithValue("@num", "A22");
                            cmd.CommandType = CommandType.Text;
                            using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                            {
                                DataTable dt = new DataTable();
                                sda.Fill(dt);
                                this.dataGridView7.DataSource = dt;
                            }
                        }
                    }
                }
            }
        }

        private void ajouterBtnA22_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@" Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename =C:\Users\khali\Desktop\S8\GI S8\DotNet\candidat_projet\candidat_projet\Database1.mdf; Integrated Security = True");
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Multiselect = true;
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    foreach (string fileNames in openFileDialog.FileNames)
                    {
                        string contentType = "";
                        switch (Path.GetExtension(fileNames).ToLower())
                        {
                            case ".jpg":
                                contentType = ".jpg";
                                break;
                            case ".png":
                                contentType = ".png";
                                break;
                            case ".gif":
                                contentType = ".gif";
                                break;
                            case ".bmp":
                                contentType = ".bmp";
                                break;
                            case ".doc":
                                contentType = ".msword";
                                break;
                            case ".docx":
                                contentType = "application/vnd.openxmlformats-officedocument.wordprocessingml.document";
                                break;
                            case ".xls":
                                contentType = "application/vnd.ms-excel";
                                break;
                            case ".xlsx":
                                contentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                                break;
                            case ".pdf":
                                contentType = "application/pdf";
                                break;
                            case ".ppt":
                                contentType = "application/vnd.ms-powerpoint";
                                break;
                            case ".pptx":
                                contentType = "application/vnd.openxmlformats-officedocument.presentationml.presentation";
                                break;
                        }
                        byte[] bytes = File.ReadAllBytes(fileNames);

                        var query = "INSERT INTO Activite_enseignement (condidat, num_quesstion, ressource_name, ressource_type, ressource_data) VALUES(@id_session, @num_quesstion, @ressource_name, @ressource_type, @ressource_data) ";

                        SqlCommand cmd = new SqlCommand(query, con);
                        cmd.Parameters.AddWithValue("@ressource_name", Path.GetFileName(fileNames));
                        cmd.Parameters.AddWithValue("@ressource_type", contentType);
                        cmd.Parameters.AddWithValue("@ressource_data", bytes);
                        cmd.Parameters.AddWithValue("@id_session", id_session);
                        cmd.Parameters.AddWithValue("@num_quesstion", "A22");
                        con.Open();
                        int a = cmd.ExecuteNonQuery();
                        if (a == 0)
                        {
                            Console.WriteLine("nop");
                        }
                        else
                        {
                            Console.WriteLine("done");
                            MessageBox.Show("Fichier ajoute", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        }
                    }
                }
            }
            using (SqlCommand cmd = new SqlCommand("SELECT Id_activite_A,ressource_name FROM Activite_enseignement where condidat = @id_session and num_quesstion = @num", con))
            {
                cmd.Parameters.AddWithValue("@id_session", id_session);
                cmd.Parameters.AddWithValue("@num", "A22");
                cmd.CommandType = CommandType.Text;
                using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    this.dataGridView7.DataSource = dt;
                }
            }
        }












        /// /////////////////////////////////////////////////////////////////////   A3 ////////////////////////////////////////////////////////



        private void importA31_Click(object sender, EventArgs e)
        {
            if (insererA31 == false)
            {
                SqlConnection con = getConnection();
                using (OpenFileDialog openFileDialog = new OpenFileDialog())
                {
                    openFileDialog.Multiselect = true;
                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        foreach (string fileNames in openFileDialog.FileNames)
                        {
                            string contentType = "";
                            switch (Path.GetExtension(fileNames).ToLower())
                            {
                                case ".jpg":
                                    contentType = ".jpg";
                                    break;
                                case ".png":
                                    contentType = ".png";
                                    break;
                                case ".gif":
                                    contentType = ".gif";
                                    break;
                                case ".bmp":
                                    contentType = ".bmp";
                                    break;
                                case ".doc":
                                    contentType = ".msword";
                                    break;
                                case ".docx":
                                    contentType = "application/vnd.openxmlformats-officedocument.wordprocessingml.document";
                                    break;
                                case ".xls":
                                    contentType = "application/vnd.ms-excel";
                                    break;
                                case ".xlsx":
                                    contentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                                    break;
                                case ".pdf":
                                    contentType = ".pdf";
                                    break;
                                case ".ppt":
                                    contentType = "application/vnd.ms-powerpoint";
                                    break;
                                case ".pptx":
                                    contentType = "application/vnd.openxmlformats-officedocument.presentationml.presentation";
                                    break;
                            }
                            byte[] bytes = File.ReadAllBytes(fileNames);

                            var query = "INSERT INTO Activite_enseignement (condidat, num_quesstion, ressource_name, ressource_type, ressource_data) VALUES(@id_session, @num_quesstion, @ressource_name, @ressource_type, @ressource_data) ";


                            SqlCommand cmd = new SqlCommand(query, con);
                            cmd.Parameters.AddWithValue("@ressource_name", Path.GetFileName(fileNames));
                            cmd.Parameters.AddWithValue("@ressource_type", contentType);
                            cmd.Parameters.AddWithValue("@ressource_data", bytes);
                            cmd.Parameters.AddWithValue("@id_session", id_session);
                            cmd.Parameters.AddWithValue("@num_quesstion", "A31");

                            con.Open();
                            int a = cmd.ExecuteNonQuery();
                            if (a == 0)
                            {
                                Console.WriteLine("nop");
                            }
                            else
                            {
                                Console.WriteLine("done");
                                MessageBox.Show("Fichier ajoute", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                A31.Text = Path.GetFileName(fileNames);
                                insererA31 = true;

                            }

                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("attention !! t'as le droit d'importer qu'un seule fichier", "ATTENTION", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }


        private void importA32_Click(object sender, EventArgs e)
        {
            if (insererA32 == false)
            {
                SqlConnection con = getConnection();
                using (OpenFileDialog openFileDialog = new OpenFileDialog())
                {
                    openFileDialog.Multiselect = true;
                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        foreach (string fileNames in openFileDialog.FileNames)
                        {
                            string contentType = "";
                            switch (Path.GetExtension(fileNames).ToLower())
                            {
                                case ".jpg":
                                    contentType = ".jpg";
                                    break;
                                case ".png":
                                    contentType = ".png";
                                    break;
                                case ".gif":
                                    contentType = ".gif";
                                    break;
                                case ".bmp":
                                    contentType = ".bmp";
                                    break;
                                case ".doc":
                                    contentType = ".msword";
                                    break;
                                case ".docx":
                                    contentType = "application/vnd.openxmlformats-officedocument.wordprocessingml.document";
                                    break;
                                case ".xls":
                                    contentType = "application/vnd.ms-excel";
                                    break;
                                case ".xlsx":
                                    contentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                                    break;
                                case ".pdf":
                                    contentType = ".pdf";
                                    break;
                                case ".ppt":
                                    contentType = "application/vnd.ms-powerpoint";
                                    break;
                                case ".pptx":
                                    contentType = "application/vnd.openxmlformats-officedocument.presentationml.presentation";
                                    break;
                            }
                            byte[] bytes = File.ReadAllBytes(fileNames);

                            var query = "INSERT INTO Activite_enseignement (condidat, num_quesstion, ressource_name, ressource_type, ressource_data) VALUES(@id_session, @num_quesstion, @ressource_name, @ressource_type, @ressource_data) ";


                            SqlCommand cmd = new SqlCommand(query, con);
                            cmd.Parameters.AddWithValue("@ressource_name", Path.GetFileName(fileNames));
                            cmd.Parameters.AddWithValue("@ressource_type", contentType);
                            cmd.Parameters.AddWithValue("@ressource_data", bytes);
                            cmd.Parameters.AddWithValue("@id_session", id_session);
                            cmd.Parameters.AddWithValue("@num_quesstion", "A32");

                            con.Open();
                            int a = cmd.ExecuteNonQuery();
                            if (a == 0)
                            {
                                Console.WriteLine("nop");
                            }
                            else
                            {
                                Console.WriteLine("done");
                                MessageBox.Show("Fichier ajoute", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                A32.Text = Path.GetFileName(fileNames);
                                insererA32 = true;

                            }

                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("attention !! t'as le droit d'importer qu'un seule fichier", "ATTENTION", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }


        private void importA331_Click(object sender, EventArgs e)
        {
            if (insererA331 == false)
            {
                SqlConnection con = getConnection();
                using (OpenFileDialog openFileDialog = new OpenFileDialog())
                {
                    openFileDialog.Multiselect = true;
                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        foreach (string fileNames in openFileDialog.FileNames)
                        {
                            string contentType = "";
                            switch (Path.GetExtension(fileNames).ToLower())
                            {
                                case ".jpg":
                                    contentType = ".jpg";
                                    break;
                                case ".png":
                                    contentType = ".png";
                                    break;
                                case ".gif":
                                    contentType = ".gif";
                                    break;
                                case ".bmp":
                                    contentType = ".bmp";
                                    break;
                                case ".doc":
                                    contentType = ".msword";
                                    break;
                                case ".docx":
                                    contentType = "application/vnd.openxmlformats-officedocument.wordprocessingml.document";
                                    break;
                                case ".xls":
                                    contentType = "application/vnd.ms-excel";
                                    break;
                                case ".xlsx":
                                    contentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                                    break;
                                case ".pdf":
                                    contentType = ".pdf";
                                    break;
                                case ".ppt":
                                    contentType = "application/vnd.ms-powerpoint";
                                    break;
                                case ".pptx":
                                    contentType = "application/vnd.openxmlformats-officedocument.presentationml.presentation";
                                    break;
                            }
                            byte[] bytes = File.ReadAllBytes(fileNames);

                            var query = "INSERT INTO Activite_enseignement (condidat, num_quesstion, ressource_name, ressource_type, ressource_data) VALUES(@id_session, @num_quesstion, @ressource_name, @ressource_type, @ressource_data) ";


                            SqlCommand cmd = new SqlCommand(query, con);
                            cmd.Parameters.AddWithValue("@ressource_name", Path.GetFileName(fileNames));
                            cmd.Parameters.AddWithValue("@ressource_type", contentType);
                            cmd.Parameters.AddWithValue("@ressource_data", bytes);
                            cmd.Parameters.AddWithValue("@id_session", id_session);
                            cmd.Parameters.AddWithValue("@num_quesstion", "A331");

                            con.Open();
                            int a = cmd.ExecuteNonQuery();
                            if (a == 0)
                            {
                                Console.WriteLine("nop");
                            }
                            else
                            {
                                Console.WriteLine("done");
                                MessageBox.Show("Fichier ajoute", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                A331.Text = Path.GetFileName(fileNames);
                                insererA331 = true;

                            }

                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("attention !! t'as le droit d'importer qu'un seule fichier", "ATTENTION", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void importA332_Click(object sender, EventArgs e)
        {
            if (insererA332 == false)
            {
                SqlConnection con = getConnection();
                using (OpenFileDialog openFileDialog = new OpenFileDialog())
                {
                    openFileDialog.Multiselect = true;
                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        foreach (string fileNames in openFileDialog.FileNames)
                        {
                            string contentType = "";
                            switch (Path.GetExtension(fileNames).ToLower())
                            {
                                case ".jpg":
                                    contentType = ".jpg";
                                    break;
                                case ".png":
                                    contentType = ".png";
                                    break;
                                case ".gif":
                                    contentType = ".gif";
                                    break;
                                case ".bmp":
                                    contentType = ".bmp";
                                    break;
                                case ".doc":
                                    contentType = ".msword";
                                    break;
                                case ".docx":
                                    contentType = "application/vnd.openxmlformats-officedocument.wordprocessingml.document";
                                    break;
                                case ".xls":
                                    contentType = "application/vnd.ms-excel";
                                    break;
                                case ".xlsx":
                                    contentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                                    break;
                                case ".pdf":
                                    contentType = ".pdf";
                                    break;
                                case ".ppt":
                                    contentType = "application/vnd.ms-powerpoint";
                                    break;
                                case ".pptx":
                                    contentType = "application/vnd.openxmlformats-officedocument.presentationml.presentation";
                                    break;
                            }
                            byte[] bytes = File.ReadAllBytes(fileNames);

                            var query = "INSERT INTO Activite_enseignement (condidat, num_quesstion, ressource_name, ressource_type, ressource_data) VALUES(@id_session, @num_quesstion, @ressource_name, @ressource_type, @ressource_data) ";


                            SqlCommand cmd = new SqlCommand(query, con);
                            cmd.Parameters.AddWithValue("@ressource_name", Path.GetFileName(fileNames));
                            cmd.Parameters.AddWithValue("@ressource_type", contentType);
                            cmd.Parameters.AddWithValue("@ressource_data", bytes);
                            cmd.Parameters.AddWithValue("@id_session", id_session);
                            cmd.Parameters.AddWithValue("@num_quesstion", "A332");

                            con.Open();
                            int a = cmd.ExecuteNonQuery();
                            if (a == 0)
                            {
                                Console.WriteLine("nop");
                            }
                            else
                            {
                                Console.WriteLine("done");
                                MessageBox.Show("Fichier ajoute", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                A332.Text = Path.GetFileName(fileNames);
                                insererA332 = true;
                            }

                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("attention !! t'as le droit d'importer qu'un seule fichier", "ATTENTION", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void importA341_Click(object sender, EventArgs e)
        {
            if (insererA341 == false)
            {
                SqlConnection con = getConnection();
                using (OpenFileDialog openFileDialog = new OpenFileDialog())
                {
                    openFileDialog.Multiselect = true;
                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        foreach (string fileNames in openFileDialog.FileNames)
                        {
                            string contentType = "";
                            switch (Path.GetExtension(fileNames).ToLower())
                            {
                                case ".jpg":
                                    contentType = ".jpg";
                                    break;
                                case ".png":
                                    contentType = ".png";
                                    break;
                                case ".gif":
                                    contentType = ".gif";
                                    break;
                                case ".bmp":
                                    contentType = ".bmp";
                                    break;
                                case ".doc":
                                    contentType = ".msword";
                                    break;
                                case ".docx":
                                    contentType = "application/vnd.openxmlformats-officedocument.wordprocessingml.document";
                                    break;
                                case ".xls":
                                    contentType = "application/vnd.ms-excel";
                                    break;
                                case ".xlsx":
                                    contentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                                    break;
                                case ".pdf":
                                    contentType = ".pdf";
                                    break;
                                case ".ppt":
                                    contentType = "application/vnd.ms-powerpoint";
                                    break;
                                case ".pptx":
                                    contentType = "application/vnd.openxmlformats-officedocument.presentationml.presentation";
                                    break;
                            }
                            byte[] bytes = File.ReadAllBytes(fileNames);

                            var query = "INSERT INTO Activite_enseignement (condidat, num_quesstion, ressource_name, ressource_type, ressource_data) VALUES(@id_session, @num_quesstion, @ressource_name, @ressource_type, @ressource_data) ";


                            SqlCommand cmd = new SqlCommand(query, con);
                            cmd.Parameters.AddWithValue("@ressource_name", Path.GetFileName(fileNames));
                            cmd.Parameters.AddWithValue("@ressource_type", contentType);
                            cmd.Parameters.AddWithValue("@ressource_data", bytes);
                            cmd.Parameters.AddWithValue("@id_session", id_session);
                            cmd.Parameters.AddWithValue("@num_quesstion", "A341");

                            con.Open();
                            int a = cmd.ExecuteNonQuery();
                            if (a == 0)
                            {
                                Console.WriteLine("nop");
                            }
                            else
                            {
                                Console.WriteLine("done");
                                MessageBox.Show("Fichier ajoute", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                A341.Text = Path.GetFileName(fileNames);
                                insererA341 = true;

                            }

                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("attention !! t'as le droit d'importer qu'un sele fichier", "ATTENTION", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }


        private void importA342_Click(object sender, EventArgs e)
        {
            if (insererA342 == false)
            {
                SqlConnection con = getConnection();
                using (OpenFileDialog openFileDialog = new OpenFileDialog())
                {
                    openFileDialog.Multiselect = true;
                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        foreach (string fileNames in openFileDialog.FileNames)
                        {
                            string contentType = "";
                            switch (Path.GetExtension(fileNames).ToLower())
                            {
                                case ".jpg":
                                    contentType = ".jpg";
                                    break;
                                case ".png":
                                    contentType = ".png";
                                    break;
                                case ".gif":
                                    contentType = ".gif";
                                    break;
                                case ".bmp":
                                    contentType = ".bmp";
                                    break;
                                case ".doc":
                                    contentType = ".msword";
                                    break;
                                case ".docx":
                                    contentType = "application/vnd.openxmlformats-officedocument.wordprocessingml.document";
                                    break;
                                case ".xls":
                                    contentType = "application/vnd.ms-excel";
                                    break;
                                case ".xlsx":
                                    contentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                                    break;
                                case ".pdf":
                                    contentType = ".pdf";
                                    break;
                                case ".ppt":
                                    contentType = "application/vnd.ms-powerpoint";
                                    break;
                                case ".pptx":
                                    contentType = "application/vnd.openxmlformats-officedocument.presentationml.presentation";
                                    break;
                            }
                            byte[] bytes = File.ReadAllBytes(fileNames);

                            var query = "INSERT INTO Activite_enseignement (condidat, num_quesstion, ressource_name, ressource_type, ressource_data) VALUES(@id_session, @num_quesstion, @ressource_name, @ressource_type, @ressource_data) ";


                            SqlCommand cmd = new SqlCommand(query, con);
                            cmd.Parameters.AddWithValue("@ressource_name", Path.GetFileName(fileNames));
                            cmd.Parameters.AddWithValue("@ressource_type", contentType);
                            cmd.Parameters.AddWithValue("@ressource_data", bytes);
                            cmd.Parameters.AddWithValue("@id_session", id_session);
                            cmd.Parameters.AddWithValue("@num_quesstion", "A342");

                            con.Open();
                            int a = cmd.ExecuteNonQuery();
                            if (a == 0)
                            {
                                Console.WriteLine("nop");
                            }
                            else
                            {
                                Console.WriteLine("done");
                                MessageBox.Show("Fichier ajoute", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                A342.Text = Path.GetFileName(fileNames);
                                insererA342 = true;
                            }

                        }
                    }

                }
            }
            else
            {
                MessageBox.Show("attention !! t'as le droit d'importer qu'un sele fichier", "ATTENTION", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void importA343_Click(object sender, EventArgs e)
        {
            if (insererA343 == false)
            {
                SqlConnection con = getConnection();
                using (OpenFileDialog openFileDialog = new OpenFileDialog())
                {
                    openFileDialog.Multiselect = true;
                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        foreach (string fileNames in openFileDialog.FileNames)
                        {
                            string contentType = "";
                            switch (Path.GetExtension(fileNames).ToLower())
                            {
                                case ".jpg":
                                    contentType = ".jpg";
                                    break;
                                case ".png":
                                    contentType = ".png";
                                    break;
                                case ".gif":
                                    contentType = ".gif";
                                    break;
                                case ".bmp":
                                    contentType = ".bmp";
                                    break;
                                case ".doc":
                                    contentType = ".msword";
                                    break;
                                case ".docx":
                                    contentType = "application/vnd.openxmlformats-officedocument.wordprocessingml.document";
                                    break;
                                case ".xls":
                                    contentType = "application/vnd.ms-excel";
                                    break;
                                case ".xlsx":
                                    contentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                                    break;
                                case ".pdf":
                                    contentType = ".pdf";
                                    break;
                                case ".ppt":
                                    contentType = "application/vnd.ms-powerpoint";
                                    break;
                                case ".pptx":
                                    contentType = "application/vnd.openxmlformats-officedocument.presentationml.presentation";
                                    break;
                            }
                            byte[] bytes = File.ReadAllBytes(fileNames);

                            var query = "INSERT INTO Activite_enseignement (condidat, num_quesstion, ressource_name, ressource_type, ressource_data) VALUES(@id_session, @num_quesstion, @ressource_name, @ressource_type, @ressource_data) ";


                            SqlCommand cmd = new SqlCommand(query, con);
                            cmd.Parameters.AddWithValue("@ressource_name", Path.GetFileName(fileNames));
                            cmd.Parameters.AddWithValue("@ressource_type", contentType);
                            cmd.Parameters.AddWithValue("@ressource_data", bytes);
                            cmd.Parameters.AddWithValue("@id_session", id_session);
                            cmd.Parameters.AddWithValue("@num_quesstion", "A343");

                            con.Open();
                            int a = cmd.ExecuteNonQuery();
                            if (a == 0)
                            {
                                Console.WriteLine("nop");
                            }
                            else
                            {
                                Console.WriteLine("done");
                                MessageBox.Show("Fichier ajoute", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                A343.Text = Path.GetFileName(fileNames);
                                insererA343 = true;
                            }

                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("attention !! t'as le droit d'importer qu'un sele fichier", "ATTENTION", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void importA344_Click(object sender, EventArgs e)
        {
            if (insererA344 == false)
            {
                SqlConnection con = getConnection();
                using (OpenFileDialog openFileDialog = new OpenFileDialog())
                {
                    openFileDialog.Multiselect = true;
                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        foreach (string fileNames in openFileDialog.FileNames)
                        {
                            string contentType = "";
                            switch (Path.GetExtension(fileNames).ToLower())
                            {
                                case ".jpg":
                                    contentType = ".jpg";
                                    break;
                                case ".png":
                                    contentType = ".png";
                                    break;
                                case ".gif":
                                    contentType = ".gif";
                                    break;
                                case ".bmp":
                                    contentType = ".bmp";
                                    break;
                                case ".doc":
                                    contentType = ".msword";
                                    break;
                                case ".docx":
                                    contentType = "application/vnd.openxmlformats-officedocument.wordprocessingml.document";
                                    break;
                                case ".xls":
                                    contentType = "application/vnd.ms-excel";
                                    break;
                                case ".xlsx":
                                    contentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                                    break;
                                case ".pdf":
                                    contentType = ".pdf";
                                    break;
                                case ".ppt":
                                    contentType = "application/vnd.ms-powerpoint";
                                    break;
                                case ".pptx":
                                    contentType = "application/vnd.openxmlformats-officedocument.presentationml.presentation";
                                    break;
                            }
                            byte[] bytes = File.ReadAllBytes(fileNames);

                            var query = "INSERT INTO Activite_enseignement (condidat, num_quesstion, ressource_name, ressource_type, ressource_data) VALUES(@id_session, @num_quesstion, @ressource_name, @ressource_type, @ressource_data) ";


                            SqlCommand cmd = new SqlCommand(query, con);
                            cmd.Parameters.AddWithValue("@ressource_name", Path.GetFileName(fileNames));
                            cmd.Parameters.AddWithValue("@ressource_type", contentType);
                            cmd.Parameters.AddWithValue("@ressource_data", bytes);
                            cmd.Parameters.AddWithValue("@id_session", id_session);
                            cmd.Parameters.AddWithValue("@num_quesstion", "A344");

                            con.Open();
                            int a = cmd.ExecuteNonQuery();
                            if (a == 0)
                            {
                                Console.WriteLine("nop");
                            }
                            else
                            {
                                Console.WriteLine("done");
                                MessageBox.Show("Fichier ajoute", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                A344.Text = Path.GetFileName(fileNames);
                                insererA344 = true;
                            }

                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("attention !! t'as le droit d'importer qu'un sele fichier", "ATTENTION", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void importA35_Click(object sender, EventArgs e)
        {
            if (insererA35 == false)
            {
                SqlConnection con = getConnection();
                using (OpenFileDialog openFileDialog = new OpenFileDialog())
                {
                    openFileDialog.Multiselect = true;
                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        foreach (string fileNames in openFileDialog.FileNames)
                        {
                            string contentType = "";
                            switch (Path.GetExtension(fileNames).ToLower())
                            {
                                case ".jpg":
                                    contentType = ".jpg";
                                    break;
                                case ".png":
                                    contentType = ".png";
                                    break;
                                case ".gif":
                                    contentType = ".gif";
                                    break;
                                case ".bmp":
                                    contentType = ".bmp";
                                    break;
                                case ".doc":
                                    contentType = ".msword";
                                    break;
                                case ".docx":
                                    contentType = "application/vnd.openxmlformats-officedocument.wordprocessingml.document";
                                    break;
                                case ".xls":
                                    contentType = "application/vnd.ms-excel";
                                    break;
                                case ".xlsx":
                                    contentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                                    break;
                                case ".pdf":
                                    contentType = ".pdf";
                                    break;
                                case ".ppt":
                                    contentType = "application/vnd.ms-powerpoint";
                                    break;
                                case ".pptx":
                                    contentType = "application/vnd.openxmlformats-officedocument.presentationml.presentation";
                                    break;
                            }
                            byte[] bytes = File.ReadAllBytes(fileNames);

                            var query = "INSERT INTO Activite_enseignement (condidat, num_quesstion, ressource_name, ressource_type, ressource_data) VALUES(@id_session, @num_quesstion, @ressource_name, @ressource_type, @ressource_data) ";


                            SqlCommand cmd = new SqlCommand(query, con);
                            cmd.Parameters.AddWithValue("@ressource_name", Path.GetFileName(fileNames));
                            cmd.Parameters.AddWithValue("@ressource_type", contentType);
                            cmd.Parameters.AddWithValue("@ressource_data", bytes);
                            cmd.Parameters.AddWithValue("@id_session", id_session);
                            cmd.Parameters.AddWithValue("@num_quesstion", "A35");

                            con.Open();
                            int a = cmd.ExecuteNonQuery();
                            if (a == 0)
                            {
                                Console.WriteLine("nop");
                            }
                            else
                            {
                                Console.WriteLine("done");
                                MessageBox.Show("Fichier ajoute", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                A35.Text = Path.GetFileName(fileNames);
                                insererA35 = true;
                            }

                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("attention !! t'as le droit d'importer qu'un sele fichier", "ATTENTION", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void A344_Click(object sender, EventArgs e)
        {

        }

        private void A332_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void BindDataGridView1()
        {
            SqlConnection cn = getConnection();
            using (SqlConnection con = cn)

            {
                using (SqlCommand cmd = new SqlCommand("SELECT Id_activite_A,ressource_name FROM Activite_enseignement where condidat = @id_session and num_quesstion = @num", con))
                {
                    cmd.Parameters.AddWithValue("@id_session", id_session);
                    cmd.Parameters.AddWithValue("@num", "A211");
                    cmd.CommandType = CommandType.Text;
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        sda.Fill(dt);
                        this.dataGridView4.DataSource = dt;
                    }
                }
            }

        }

        private void metroButton2_Click(object sender, EventArgs e)
        {

            SqlConnection con = getConnection();

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Multiselect = true;
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    foreach (string fileNames in openFileDialog.FileNames)
                    {
                        string contentType = "";
                        switch (Path.GetExtension(fileNames).ToLower())
                        {
                            case ".jpg":
                                contentType = ".jpg";
                                break;
                            case ".png":
                                contentType = ".png";
                                break;
                            case ".gif":
                                contentType = ".gif";
                                break;
                            case ".bmp":
                                contentType = ".bmp";
                                break;
                            case ".doc":
                                contentType = ".msword";
                                break;
                            case ".docx":
                                contentType = "application/vnd.openxmlformats-officedocument.wordprocessingml.document";
                                break;
                            case ".xls":
                                contentType = "application/vnd.ms-excel";
                                break;
                            case ".xlsx":
                                contentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                                break;
                            case ".pdf":
                                contentType = ".pdf";
                                break;
                            case ".ppt":
                                contentType = "application/vnd.ms-powerpoint";
                                break;
                            case ".pptx":
                                contentType = "application/vnd.openxmlformats-officedocument.presentationml.presentation";
                                break;
                        }
                        byte[] bytes = File.ReadAllBytes(fileNames);

                        var query = "INSERT INTO Activite_enseignement (condidat, num_quesstion, ressource_name, ressource_type, ressource_data) VALUES(@id_session, @num_quesstion, @ressource_name, @ressource_type, @ressource_data) ";


                        SqlCommand cmd = new SqlCommand(query, con);
                        cmd.Parameters.AddWithValue("@ressource_name", Path.GetFileName(fileNames));
                        cmd.Parameters.AddWithValue("@ressource_type", contentType);
                        cmd.Parameters.AddWithValue("@ressource_data", bytes);
                        cmd.Parameters.AddWithValue("@id_session", id_session);
                        cmd.Parameters.AddWithValue("@num_quesstion", "A211");




                        con.Open();
                        int a = cmd.ExecuteNonQuery();
                        if (a == 0)
                        {
                            Console.WriteLine("nop");
                        }
                        else
                        {
                            Console.WriteLine("done");
                            MessageBox.Show("Fichier ajoute", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        }



                    }
                }
            }
            this.BindDataGridView1();
        }

        private void supprimer(String num)
        {
            SqlConnection cn = getConnection();
            using (SqlConnection con = cn)

            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("delete from Activite_enseignement where condidat = @id_session and num_quesstion = @num", con))
                {
                    cmd.Parameters.AddWithValue("@id_session", id_session);
                    cmd.Parameters.AddWithValue("@num", num);
                    cmd.CommandType = CommandType.Text;
                    try
                    {
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Fichier supprime");

                    }
                    catch (Exception exp)
                    {
                        //MetroMessageBox.Show(this, "Le numero de client deja existe ", "erreur", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        MessageBox.Show(exp.Message);
                    }
                }
            }

        }

     
        private void sA31_Click_1(object sender, EventArgs e)
        {
            supprimer("A31");
            A31.Text = "";
            insererA31 = false;
        }

        private void sA32_Click_1(object sender, EventArgs e)
        {
            supprimer("A32");
            A32.Text = "";
            insererA32 = false;
        }

        private void sA331_Click(object sender, EventArgs e)
        {
            supprimer("A331");
            A331.Text = "";
            insererA331 = false;
        }

        private void sA332_Click(object sender, EventArgs e)
        {
            supprimer("A332");
            A332.Text = "";
            insererA332 = false;
        }

        private void sA341_Click(object sender, EventArgs e)
        {
            supprimer("A341");
            A341.Text = "";
            insererA341 = false;
        }

        private void sA342_Click(object sender, EventArgs e)
        {
            supprimer("A342");
            A342.Text = "";
            insererA342 = false;
        }

        private void sA343_Click(object sender, EventArgs e)
        {
            supprimer("A343");
            A343.Text = "";
            insererA343 = false;
        }

        private void sA344_Click(object sender, EventArgs e)
        {
            supprimer("A344");
            A344.Text = "";
            insererA344 = false;
        }

        private void sA35_Click(object sender, EventArgs e)
        {
            supprimer("A35");
            A35.Text = "";
            insererA35 = false;
        }
    }
}
