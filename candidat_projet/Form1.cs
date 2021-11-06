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
    public partial class Form1 : Form
    {
        int test = 0;
        String msg = "";
        public Form1()
        {
            InitializeComponent();
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void metroRadioButton3_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void candidatBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.candidatBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.database1DataSet);

        }

        private void suivantBtn_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@" Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename =C:\Users\khali\Desktop\S8\GI S8\DotNet\candidat_projet\candidat_projet\Database1.mdf; Integrated Security = True");
            string query = "INSERT INTO Candidat (nom,prenom, departement,date_recrutement,grade_actuel,tel,fax,email,date_depot_dossier,type_passage,grade_souhaite) VALUES(@nom, @prenom, @departement, @date_recrutement, @grade_actuel, @tel, @fax ,@email ,@date_depot_dossier, @type_passage, @grade_souhaite) ";
            SqlCommand cmd = new SqlCommand(query, con);

            cmd.Parameters.AddWithValue("@nom", textNom.Text);
            Console.WriteLine(textNom.Text);
            cmd.Parameters.AddWithValue("@prenom", textPrenom.Text);

            Console.WriteLine(textPrenom.Text.Trim());
            cmd.Parameters.AddWithValue("@departement", departementText.Text);
            Console.WriteLine(textNom.Text);
            cmd.Parameters.Add("@date_recrutement", SqlDbType.Date).Value = date_recrutement_text.Value.Date.ToString();
            cmd.Parameters.AddWithValue("@grade_actuel", grade_actuelText.Text);
            Console.WriteLine(textNom.Text);
            cmd.Parameters.AddWithValue("@tel", textTel.Text);
            Console.WriteLine(textNom.Text);
            cmd.Parameters.AddWithValue("@fax", faxText.Text);
            Console.WriteLine(textNom.Text);



            if (textNom.Text == "")
            {
                msg += "Champ nom est obligatoire\n";
            }
            else
            {
                test += 1;
                Console.WriteLine(test);
            }

            if (textPrenom.Text == "")
            {
                msg += "Champ prenom est obligatoire\n";
            }
            else
            {
                test += 1;
                Console.WriteLine(test);
            }
            
            if (departementText.Text == "")
            {
                msg += "Champ departement est obligatoire\n";
            }
            else
            {
                test += 1;
                Console.WriteLine(test);
            }
            if (grade_actuelText.Text == "")
            {
                msg += "Champ grade est obligatoire\n";
            }
            else
            {
                test += 1;
                Console.WriteLine(test);
            }
            if (textTel.Text == "")
            {
                msg += "Champ tel est obligatoire\n";
                
            }
            else if(!Regex.IsMatch(textTel.Text, "\\A[0-9]{10}\\z"))
            {

                
                msg += "Champ tel doit etre compose de 10 nombres sans caracteres\n";
            }
            else
            {
                test += 1;
                Console.WriteLine(test);
            }
            try
            {
                string query3 = "select email from Candidat where email = @mail";

                SqlCommand cmd3 = new SqlCommand(query3, con);
                cmd3.Parameters.AddWithValue("@mail", emailText.Text);
                con.Open();
                var reader = cmd3.ExecuteReader();
                
                if (reader.Read())
                {
                    msg += "adress email deja existant\n";
                    emailText.Text = "";
                }
                else
                {
                    var addr = new System.Net.Mail.MailAddress(emailText.Text);
                    cmd.Parameters.AddWithValue("@email", addr.Address);
                    test += 1;
                    Console.WriteLine(test);
                }
                con.Close();
            }
            catch
            {
                msg += "adress email n'est pas correcte\n";
                emailText.Text = "";
            }

            Console.WriteLine(textNom.Text);
            cmd.Parameters.Add("@date_depot_dossier", SqlDbType.Date).Value = DateTime.Now.ToString("yyyy-MM-dd");
            if (pExceptionel.Checked)
            {
                cmd.Parameters.AddWithValue("@type_passage", pExceptionel.Text);
                Console.WriteLine(textNom.Text);
            }
            else if (pRapid.Checked)
            {
                cmd.Parameters.AddWithValue("@type_passage", pRapid.Text);
                Console.WriteLine(textNom.Text);
            }
            else if (pNormal.Checked)
            {
                cmd.Parameters.AddWithValue("@type_passage", pNormal.Text);
                
            }

            ///////////////////////////////////
            ///

            if (PESAB.Checked)
            {
                cmd.Parameters.AddWithValue("@grade_souhaite", PESAB.Text);
               
            }
            else if (PESBC.Checked)
            {
                cmd.Parameters.AddWithValue("@grade_souhaite", PESBC.Text);
                
            }
            else if (PHAB.Checked)
            {
                cmd.Parameters.AddWithValue("@grade_souhaite", PHAB.Text);
               
            }
            else if (PHBC.Checked)
            {
                cmd.Parameters.AddWithValue("@grade_souhaite", PHBC.Text);
                
            }
            else if (PAAB.Checked)
            {
                cmd.Parameters.AddWithValue("@grade_souhaite", PAAB.Text);
            
            }
            else if (PABC.Checked)
            {
                cmd.Parameters.AddWithValue("@grade_souhaite", PABC.Text);
                
            }
            else if (PACD.Checked)
            {
                cmd.Parameters.AddWithValue("@grade_souhaite", PACD.Text);
                
            }
            
            
            if(test == 6)
            {
                con.Open();
                int a = cmd.ExecuteNonQuery();
                con.Close();
                if (a == 0)
                {
                    Console.WriteLine("nop");
                }
                else
                {
                    Console.WriteLine("done");
                    MessageBox.Show("Utilisateur ajoute", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    string query2 = "select Top 1 Id_condidat from Candidat order by Id_condidat desc";
                    
                    SqlCommand cmd2 = new SqlCommand(query2, con);
                    con.Open();
                    var reader = cmd2.ExecuteReader();
                    if (reader.Read())
                    {
                        var id_sess = reader["Id_condidat"].ToString();
                        Console.WriteLine(id_sess);
                        Form2 frm = new Form2(id_sess);
                        frm.Show();
                        this.Hide();
                    }
                    con.Close();
                    
                    
                }
            }
            else
            {
                Console.WriteLine("nopppp");
                MessageBox.Show(msg, "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
                msg = "";
                test = 0;
                

            }
        }

        private void grade_actuelLabel1_Click(object sender, EventArgs e)
        {

        }

        private void grade_actuelComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void PACD_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void emailText_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
