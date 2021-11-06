
namespace candidat_projet
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.Label nomLabel;
            System.Windows.Forms.Label prenomLabel;
            System.Windows.Forms.Label departementLabel;
            System.Windows.Forms.Label date_recrutementLabel;
            System.Windows.Forms.Label telLabel;
            System.Windows.Forms.Label faxLabel;
            System.Windows.Forms.Label emailLabel;
            System.Windows.Forms.Label grade_actuelLabel1;
            this.panel1 = new System.Windows.Forms.Panel();
            this.grade_actuelText = new System.Windows.Forms.ComboBox();
            this.candidatBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.database1DataSet = new candidat_projet.Database1DataSet();
            this.quitterBtn = new MetroFramework.Controls.MetroButton();
            this.suivantBtn = new MetroFramework.Controls.MetroButton();
            this.textNom = new System.Windows.Forms.TextBox();
            this.textPrenom = new System.Windows.Forms.TextBox();
            this.departementText = new System.Windows.Forms.TextBox();
            this.date_recrutement_text = new System.Windows.Forms.DateTimePicker();
            this.textTel = new System.Windows.Forms.TextBox();
            this.faxText = new System.Windows.Forms.TextBox();
            this.emailText = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.PAAB = new MetroFramework.Controls.MetroRadioButton();
            this.PHAB = new MetroFramework.Controls.MetroRadioButton();
            this.PABC = new MetroFramework.Controls.MetroRadioButton();
            this.PHBC = new MetroFramework.Controls.MetroRadioButton();
            this.PESAB = new MetroFramework.Controls.MetroRadioButton();
            this.PACD = new MetroFramework.Controls.MetroRadioButton();
            this.PESBC = new MetroFramework.Controls.MetroRadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.pExceptionel = new MetroFramework.Controls.MetroRadioButton();
            this.pNormal = new MetroFramework.Controls.MetroRadioButton();
            this.pRapid = new MetroFramework.Controls.MetroRadioButton();
            this.candidatTableAdapter = new candidat_projet.Database1DataSetTableAdapters.CandidatTableAdapter();
            this.tableAdapterManager = new candidat_projet.Database1DataSetTableAdapters.TableAdapterManager();
            nomLabel = new System.Windows.Forms.Label();
            prenomLabel = new System.Windows.Forms.Label();
            departementLabel = new System.Windows.Forms.Label();
            date_recrutementLabel = new System.Windows.Forms.Label();
            telLabel = new System.Windows.Forms.Label();
            faxLabel = new System.Windows.Forms.Label();
            emailLabel = new System.Windows.Forms.Label();
            grade_actuelLabel1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.candidatBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.database1DataSet)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // nomLabel
            // 
            nomLabel.AutoSize = true;
            nomLabel.Font = new System.Drawing.Font("Candara", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            nomLabel.Location = new System.Drawing.Point(131, 281);
            nomLabel.Name = "nomLabel";
            nomLabel.Size = new System.Drawing.Size(52, 23);
            nomLabel.TabIndex = 7;
            nomLabel.Text = "nom:";
            // 
            // prenomLabel
            // 
            prenomLabel.AutoSize = true;
            prenomLabel.Font = new System.Drawing.Font("Candara", 14.25F, System.Drawing.FontStyle.Bold);
            prenomLabel.Location = new System.Drawing.Point(131, 318);
            prenomLabel.Name = "prenomLabel";
            prenomLabel.Size = new System.Drawing.Size(80, 23);
            prenomLabel.TabIndex = 9;
            prenomLabel.Text = "prenom:";
            // 
            // departementLabel
            // 
            departementLabel.AutoSize = true;
            departementLabel.Font = new System.Drawing.Font("Candara", 14.25F, System.Drawing.FontStyle.Bold);
            departementLabel.Location = new System.Drawing.Point(131, 357);
            departementLabel.Name = "departementLabel";
            departementLabel.Size = new System.Drawing.Size(122, 23);
            departementLabel.TabIndex = 11;
            departementLabel.Text = "departement:";
            // 
            // date_recrutementLabel
            // 
            date_recrutementLabel.AutoSize = true;
            date_recrutementLabel.Font = new System.Drawing.Font("Candara", 14.25F, System.Drawing.FontStyle.Bold);
            date_recrutementLabel.Location = new System.Drawing.Point(131, 400);
            date_recrutementLabel.Name = "date_recrutementLabel";
            date_recrutementLabel.Size = new System.Drawing.Size(157, 23);
            date_recrutementLabel.TabIndex = 13;
            date_recrutementLabel.Text = "date recrutement:";
            // 
            // telLabel
            // 
            telLabel.AutoSize = true;
            telLabel.Font = new System.Drawing.Font("Candara", 14.25F, System.Drawing.FontStyle.Bold);
            telLabel.Location = new System.Drawing.Point(131, 473);
            telLabel.Name = "telLabel";
            telLabel.Size = new System.Drawing.Size(37, 23);
            telLabel.TabIndex = 17;
            telLabel.Text = "tel:";
            // 
            // faxLabel
            // 
            faxLabel.AutoSize = true;
            faxLabel.Font = new System.Drawing.Font("Candara", 14.25F, System.Drawing.FontStyle.Bold);
            faxLabel.Location = new System.Drawing.Point(131, 513);
            faxLabel.Name = "faxLabel";
            faxLabel.Size = new System.Drawing.Size(41, 23);
            faxLabel.TabIndex = 19;
            faxLabel.Text = "fax:";
            // 
            // emailLabel
            // 
            emailLabel.AutoSize = true;
            emailLabel.Font = new System.Drawing.Font("Candara", 14.25F, System.Drawing.FontStyle.Bold);
            emailLabel.Location = new System.Drawing.Point(131, 550);
            emailLabel.Name = "emailLabel";
            emailLabel.Size = new System.Drawing.Size(60, 23);
            emailLabel.TabIndex = 21;
            emailLabel.Text = "email:";
            // 
            // grade_actuelLabel1
            // 
            grade_actuelLabel1.AutoSize = true;
            grade_actuelLabel1.Font = new System.Drawing.Font("Candara", 14.25F, System.Drawing.FontStyle.Bold);
            grade_actuelLabel1.Location = new System.Drawing.Point(131, 434);
            grade_actuelLabel1.Name = "grade_actuelLabel1";
            grade_actuelLabel1.Size = new System.Drawing.Size(114, 23);
            grade_actuelLabel1.TabIndex = 24;
            grade_actuelLabel1.Text = "grade actuel:";
            grade_actuelLabel1.Click += new System.EventHandler(this.grade_actuelLabel1_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(grade_actuelLabel1);
            this.panel1.Controls.Add(this.grade_actuelText);
            this.panel1.Controls.Add(this.quitterBtn);
            this.panel1.Controls.Add(this.suivantBtn);
            this.panel1.Controls.Add(nomLabel);
            this.panel1.Controls.Add(this.textNom);
            this.panel1.Controls.Add(prenomLabel);
            this.panel1.Controls.Add(this.textPrenom);
            this.panel1.Controls.Add(departementLabel);
            this.panel1.Controls.Add(this.departementText);
            this.panel1.Controls.Add(date_recrutementLabel);
            this.panel1.Controls.Add(this.date_recrutement_text);
            this.panel1.Controls.Add(telLabel);
            this.panel1.Controls.Add(this.textTel);
            this.panel1.Controls.Add(faxLabel);
            this.panel1.Controls.Add(this.faxText);
            this.panel1.Controls.Add(emailLabel);
            this.panel1.Controls.Add(this.emailText);
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Location = new System.Drawing.Point(-10, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1169, 637);
            this.panel1.TabIndex = 0;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // grade_actuelText
            // 
            this.grade_actuelText.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.candidatBindingSource, "grade_actuel", true));
            this.grade_actuelText.FormattingEnabled = true;
            this.grade_actuelText.Items.AddRange(new object[] {
            "PES-A",
            "PES-B",
            "PES-C",
            "PH-A",
            "PH-B",
            "PH-C",
            "PA-A",
            "PA-B",
            "PA-C",
            "PA-D"});
            this.grade_actuelText.Location = new System.Drawing.Point(336, 438);
            this.grade_actuelText.Name = "grade_actuelText";
            this.grade_actuelText.Size = new System.Drawing.Size(200, 21);
            this.grade_actuelText.TabIndex = 25;
            this.grade_actuelText.SelectedIndexChanged += new System.EventHandler(this.grade_actuelComboBox_SelectedIndexChanged);
            // 
            // candidatBindingSource
            // 
            this.candidatBindingSource.DataMember = "Candidat";
            this.candidatBindingSource.DataSource = this.database1DataSet;
            // 
            // database1DataSet
            // 
            this.database1DataSet.DataSetName = "Database1DataSet";
            this.database1DataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // quitterBtn
            // 
            this.quitterBtn.Location = new System.Drawing.Point(1001, 573);
            this.quitterBtn.Name = "quitterBtn";
            this.quitterBtn.Size = new System.Drawing.Size(114, 31);
            this.quitterBtn.TabIndex = 24;
            this.quitterBtn.Text = "Quitter";
            // 
            // suivantBtn
            // 
            this.suivantBtn.Location = new System.Drawing.Point(734, 573);
            this.suivantBtn.Name = "suivantBtn";
            this.suivantBtn.Size = new System.Drawing.Size(114, 31);
            this.suivantBtn.TabIndex = 23;
            this.suivantBtn.Text = "Suivant";
            this.suivantBtn.Click += new System.EventHandler(this.suivantBtn_Click);
            // 
            // textNom
            // 
            this.textNom.BackColor = System.Drawing.Color.White;
            this.textNom.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.candidatBindingSource, "nom", true));
            this.textNom.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.textNom.Location = new System.Drawing.Point(336, 282);
            this.textNom.Name = "textNom";
            this.textNom.Size = new System.Drawing.Size(200, 20);
            this.textNom.TabIndex = 8;
            // 
            // textPrenom
            // 
            this.textPrenom.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.candidatBindingSource, "prenom", true));
            this.textPrenom.Location = new System.Drawing.Point(336, 320);
            this.textPrenom.Name = "textPrenom";
            this.textPrenom.Size = new System.Drawing.Size(200, 20);
            this.textPrenom.TabIndex = 10;
            // 
            // departementText
            // 
            this.departementText.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.candidatBindingSource, "departement", true));
            this.departementText.Location = new System.Drawing.Point(336, 358);
            this.departementText.Name = "departementText";
            this.departementText.Size = new System.Drawing.Size(200, 20);
            this.departementText.TabIndex = 12;
            // 
            // date_recrutement_text
            // 
            this.date_recrutement_text.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.candidatBindingSource, "date_recrutement", true));
            this.date_recrutement_text.Location = new System.Drawing.Point(336, 401);
            this.date_recrutement_text.Name = "date_recrutement_text";
            this.date_recrutement_text.Size = new System.Drawing.Size(200, 20);
            this.date_recrutement_text.TabIndex = 14;
            // 
            // textTel
            // 
            this.textTel.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.candidatBindingSource, "tel", true));
            this.textTel.Location = new System.Drawing.Point(336, 477);
            this.textTel.Name = "textTel";
            this.textTel.Size = new System.Drawing.Size(200, 20);
            this.textTel.TabIndex = 18;
            // 
            // faxText
            // 
            this.faxText.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.candidatBindingSource, "fax", true));
            this.faxText.Location = new System.Drawing.Point(336, 517);
            this.faxText.Name = "faxText";
            this.faxText.Size = new System.Drawing.Size(200, 20);
            this.faxText.TabIndex = 20;
            // 
            // emailText
            // 
            this.emailText.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.candidatBindingSource, "email", true));
            this.emailText.Location = new System.Drawing.Point(336, 553);
            this.emailText.Name = "emailText";
            this.emailText.Size = new System.Drawing.Size(200, 20);
            this.emailText.TabIndex = 22;
            this.emailText.TextChanged += new System.EventHandler(this.emailText_TextChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.PAAB);
            this.groupBox2.Controls.Add(this.PHAB);
            this.groupBox2.Controls.Add(this.PABC);
            this.groupBox2.Controls.Add(this.PHBC);
            this.groupBox2.Controls.Add(this.PESAB);
            this.groupBox2.Controls.Add(this.PACD);
            this.groupBox2.Controls.Add(this.PESBC);
            this.groupBox2.Font = new System.Drawing.Font("Candara", 14.25F, System.Drawing.FontStyle.Bold);
            this.groupBox2.Location = new System.Drawing.Point(702, 217);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(314, 265);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Cadre et grade";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(31, 185);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(33, 23);
            this.label3.TabIndex = 10;
            this.label3.Text = "PA";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(31, 102);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 23);
            this.label2.TabIndex = 9;
            this.label2.Text = "PH";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(31, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 23);
            this.label1.TabIndex = 8;
            this.label1.Text = "PES";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // PAAB
            // 
            this.PAAB.AutoSize = true;
            this.PAAB.Location = new System.Drawing.Point(150, 193);
            this.PAAB.Name = "PAAB";
            this.PAAB.Size = new System.Drawing.Size(116, 15);
            this.PAAB.TabIndex = 7;
            this.PAAB.TabStop = true;
            this.PAAB.Text = "grade A a grade B";
            this.PAAB.UseVisualStyleBackColor = true;
            // 
            // PHAB
            // 
            this.PHAB.AutoSize = true;
            this.PHAB.Location = new System.Drawing.Point(150, 108);
            this.PHAB.Name = "PHAB";
            this.PHAB.Size = new System.Drawing.Size(116, 15);
            this.PHAB.TabIndex = 4;
            this.PHAB.TabStop = true;
            this.PHAB.Text = "grade A a grade B";
            this.PHAB.UseVisualStyleBackColor = true;
            // 
            // PABC
            // 
            this.PABC.AutoSize = true;
            this.PABC.Location = new System.Drawing.Point(150, 214);
            this.PABC.Name = "PABC";
            this.PABC.Size = new System.Drawing.Size(116, 15);
            this.PABC.TabIndex = 6;
            this.PABC.TabStop = true;
            this.PABC.Text = "grade B a grade C";
            this.PABC.UseVisualStyleBackColor = true;
            // 
            // PHBC
            // 
            this.PHBC.AutoSize = true;
            this.PHBC.Location = new System.Drawing.Point(150, 129);
            this.PHBC.Name = "PHBC";
            this.PHBC.Size = new System.Drawing.Size(116, 15);
            this.PHBC.TabIndex = 5;
            this.PHBC.TabStop = true;
            this.PHBC.Text = "grade B a grade C";
            this.PHBC.UseVisualStyleBackColor = true;
            // 
            // PESAB
            // 
            this.PESAB.AutoSize = true;
            this.PESAB.Location = new System.Drawing.Point(150, 36);
            this.PESAB.Name = "PESAB";
            this.PESAB.Size = new System.Drawing.Size(116, 15);
            this.PESAB.TabIndex = 1;
            this.PESAB.TabStop = true;
            this.PESAB.Text = "grade A a grade B";
            this.PESAB.UseVisualStyleBackColor = true;
            // 
            // PACD
            // 
            this.PACD.AutoSize = true;
            this.PACD.Location = new System.Drawing.Point(150, 235);
            this.PACD.Name = "PACD";
            this.PACD.Size = new System.Drawing.Size(117, 15);
            this.PACD.TabIndex = 3;
            this.PACD.TabStop = true;
            this.PACD.Text = "grade C a grade D";
            this.PACD.UseVisualStyleBackColor = true;
            this.PACD.CheckedChanged += new System.EventHandler(this.PACD_CheckedChanged);
            // 
            // PESBC
            // 
            this.PESBC.AutoSize = true;
            this.PESBC.Location = new System.Drawing.Point(150, 57);
            this.PESBC.Name = "PESBC";
            this.PESBC.Size = new System.Drawing.Size(116, 15);
            this.PESBC.TabIndex = 2;
            this.PESBC.TabStop = true;
            this.PESBC.Text = "grade B a grade C";
            this.PESBC.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.pExceptionel);
            this.groupBox1.Controls.Add(this.pNormal);
            this.groupBox1.Controls.Add(this.pRapid);
            this.groupBox1.Font = new System.Drawing.Font("Candara", 14.25F, System.Drawing.FontStyle.Bold);
            this.groupBox1.Location = new System.Drawing.Point(702, 82);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(314, 101);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Type de passage";
            // 
            // pExceptionel
            // 
            this.pExceptionel.AutoSize = true;
            this.pExceptionel.FontSize = MetroFramework.MetroLinkSize.Medium;
            this.pExceptionel.Location = new System.Drawing.Point(32, 28);
            this.pExceptionel.Name = "pExceptionel";
            this.pExceptionel.Size = new System.Drawing.Size(154, 19);
            this.pExceptionel.TabIndex = 1;
            this.pExceptionel.TabStop = true;
            this.pExceptionel.Text = "Passage Exceptionnel";
            this.pExceptionel.UseVisualStyleBackColor = true;
            // 
            // pNormal
            // 
            this.pNormal.AutoSize = true;
            this.pNormal.FontSize = MetroFramework.MetroLinkSize.Medium;
            this.pNormal.Location = new System.Drawing.Point(32, 70);
            this.pNormal.Name = "pNormal";
            this.pNormal.Size = new System.Drawing.Size(121, 19);
            this.pNormal.TabIndex = 3;
            this.pNormal.TabStop = true;
            this.pNormal.Text = "Passage normal";
            this.pNormal.UseVisualStyleBackColor = true;
            this.pNormal.CheckedChanged += new System.EventHandler(this.metroRadioButton3_CheckedChanged);
            // 
            // pRapid
            // 
            this.pRapid.AutoSize = true;
            this.pRapid.FontSize = MetroFramework.MetroLinkSize.Medium;
            this.pRapid.Location = new System.Drawing.Point(32, 49);
            this.pRapid.Name = "pRapid";
            this.pRapid.Size = new System.Drawing.Size(119, 19);
            this.pRapid.TabIndex = 2;
            this.pRapid.TabStop = true;
            this.pRapid.Text = "Passage Rapide";
            this.pRapid.UseVisualStyleBackColor = true;
            // 
            // candidatTableAdapter
            // 
            this.candidatTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.Activite_enseignementTableAdapter = null;
            this.tableAdapterManager.Activite_rechercheTableAdapter = null;
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.CandidatTableAdapter = this.candidatTableAdapter;
            this.tableAdapterManager.CorrecteurTableAdapter = null;
            this.tableAdapterManager.UpdateOrder = candidat_projet.Database1DataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::candidat_projet.Properties.Resources.Purple;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1184, 661);
            this.Controls.Add(this.panel1);
            this.DoubleBuffered = true;
            this.Name = "Form1";
            this.Text = "Form1";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.candidatBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.database1DataSet)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private MetroFramework.Controls.MetroRadioButton pExceptionel;
        private System.Windows.Forms.GroupBox groupBox1;
        private MetroFramework.Controls.MetroRadioButton pRapid;
        private System.Windows.Forms.GroupBox groupBox2;
        private MetroFramework.Controls.MetroRadioButton PESAB;
        private MetroFramework.Controls.MetroRadioButton PESBC;
        private MetroFramework.Controls.MetroRadioButton pNormal;
        private System.Windows.Forms.Label label1;
        private MetroFramework.Controls.MetroRadioButton PAAB;
        private MetroFramework.Controls.MetroRadioButton PHAB;
        private MetroFramework.Controls.MetroRadioButton PABC;
        private MetroFramework.Controls.MetroRadioButton PHBC;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private Database1DataSet database1DataSet;
        private System.Windows.Forms.BindingSource candidatBindingSource;
        private Database1DataSetTableAdapters.CandidatTableAdapter candidatTableAdapter;
        private Database1DataSetTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.TextBox textNom;
        private System.Windows.Forms.TextBox textPrenom;
        private System.Windows.Forms.TextBox departementText;
        private System.Windows.Forms.DateTimePicker date_recrutement_text;
        private System.Windows.Forms.TextBox textTel;
        private System.Windows.Forms.TextBox faxText;
        private System.Windows.Forms.TextBox emailText;
        private MetroFramework.Controls.MetroButton quitterBtn;
        private MetroFramework.Controls.MetroButton suivantBtn;
        private MetroFramework.Controls.MetroRadioButton PACD;
        private System.Windows.Forms.ComboBox grade_actuelText;
    }
}

