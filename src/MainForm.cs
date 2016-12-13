using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Text;


namespace VMA.HTMLIndexer
{
	/// <summary>
	/// Summary description for MainForm.
	/// </summary>
	public class MainForm : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private CDiese.DirBrowser.FolderTree treeFolders;
		private System.Windows.Forms.Button btnGenerate;
		private System.Windows.Forms.TextBox txtPageTitle;
		private System.Windows.Forms.CheckBox chkRenameFiles;
		private System.Windows.Forms.Button btnAbout;
		private System.Windows.Forms.Button btnExit;
		private System.Windows.Forms.CheckBox chkGenerateCHM;
		private System.Windows.Forms.TextBox txtSearchPattern;
		private System.Windows.Forms.TextBox txtRenamePrefix;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox txtSelectedFolder;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public MainForm()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(MainForm));
			this.treeFolders = new CDiese.DirBrowser.FolderTree();
			this.btnGenerate = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.txtRenamePrefix = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.chkGenerateCHM = new System.Windows.Forms.CheckBox();
			this.chkRenameFiles = new System.Windows.Forms.CheckBox();
			this.txtPageTitle = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.btnAbout = new System.Windows.Forms.Button();
			this.btnExit = new System.Windows.Forms.Button();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.txtSelectedFolder = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.txtSearchPattern = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.SuspendLayout();
			// 
			// treeFolders
			// 
			this.treeFolders.Cursor = System.Windows.Forms.Cursors.Default;
			this.treeFolders.Location = new System.Drawing.Point(8, 24);
			this.treeFolders.Name = "treeFolders";
			this.treeFolders.Path = null;
			this.treeFolders.Size = new System.Drawing.Size(200, 368);
			this.treeFolders.TabIndex = 0;
			this.treeFolders.PathChanged += new CDiese.DirBrowser.FolderTreeEventHandler(this.treeFolders_PathChanged);
			// 
			// btnGenerate
			// 
			this.btnGenerate.Location = new System.Drawing.Point(216, 368);
			this.btnGenerate.Name = "btnGenerate";
			this.btnGenerate.Size = new System.Drawing.Size(92, 24);
			this.btnGenerate.TabIndex = 1;
			this.btnGenerate.Text = "&Generate";
			this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(8, 8);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(208, 16);
			this.label1.TabIndex = 2;
			this.label1.Text = "Select folder containing web pages:";
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.AddRange(new System.Windows.Forms.Control[] {
																					this.txtRenamePrefix,
																					this.label4,
																					this.chkGenerateCHM,
																					this.chkRenameFiles,
																					this.txtPageTitle,
																					this.label2});
			this.groupBox1.Location = new System.Drawing.Point(216, 160);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(296, 192);
			this.groupBox1.TabIndex = 3;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Output options";
			// 
			// txtRenamePrefix
			// 
			this.txtRenamePrefix.Enabled = false;
			this.txtRenamePrefix.Location = new System.Drawing.Point(128, 112);
			this.txtRenamePrefix.Name = "txtRenamePrefix";
			this.txtRenamePrefix.Size = new System.Drawing.Size(112, 20);
			this.txtRenamePrefix.TabIndex = 7;
			this.txtRenamePrefix.Text = "page";
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(48, 112);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(72, 16);
			this.label4.TabIndex = 6;
			this.label4.Text = "Name prefix:";
			// 
			// chkGenerateCHM
			// 
			this.chkGenerateCHM.Location = new System.Drawing.Point(8, 152);
			this.chkGenerateCHM.Name = "chkGenerateCHM";
			this.chkGenerateCHM.Size = new System.Drawing.Size(272, 24);
			this.chkGenerateCHM.TabIndex = 5;
			this.chkGenerateCHM.Text = "Generate CHM project files";
			// 
			// chkRenameFiles
			// 
			this.chkRenameFiles.Location = new System.Drawing.Point(8, 80);
			this.chkRenameFiles.Name = "chkRenameFiles";
			this.chkRenameFiles.Size = new System.Drawing.Size(264, 24);
			this.chkRenameFiles.TabIndex = 4;
			this.chkRenameFiles.Text = "Rename files before process";
			this.chkRenameFiles.CheckedChanged += new System.EventHandler(this.chkRenameFiles_CheckedChanged);
			// 
			// txtPageTitle
			// 
			this.txtPageTitle.Location = new System.Drawing.Point(72, 40);
			this.txtPageTitle.Name = "txtPageTitle";
			this.txtPageTitle.Size = new System.Drawing.Size(208, 20);
			this.txtPageTitle.TabIndex = 0;
			this.txtPageTitle.Text = "Index";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(8, 40);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(100, 16);
			this.label2.TabIndex = 1;
			this.label2.Text = "Page title:";
			// 
			// btnAbout
			// 
			this.btnAbout.Location = new System.Drawing.Point(316, 368);
			this.btnAbout.Name = "btnAbout";
			this.btnAbout.Size = new System.Drawing.Size(92, 24);
			this.btnAbout.TabIndex = 4;
			this.btnAbout.Text = "&About";
			this.btnAbout.Click += new System.EventHandler(this.btnAbout_Click);
			// 
			// btnExit
			// 
			this.btnExit.Location = new System.Drawing.Point(416, 368);
			this.btnExit.Name = "btnExit";
			this.btnExit.Size = new System.Drawing.Size(92, 24);
			this.btnExit.TabIndex = 5;
			this.btnExit.Text = "E&xit";
			this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.AddRange(new System.Windows.Forms.Control[] {
																					this.txtSelectedFolder,
																					this.label5,
																					this.txtSearchPattern,
																					this.label3});
			this.groupBox2.Location = new System.Drawing.Point(216, 16);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(296, 136);
			this.groupBox2.TabIndex = 6;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Input options";
			// 
			// txtSelectedFolder
			// 
			this.txtSelectedFolder.Location = new System.Drawing.Point(16, 40);
			this.txtSelectedFolder.Name = "txtSelectedFolder";
			this.txtSelectedFolder.ReadOnly = true;
			this.txtSelectedFolder.Size = new System.Drawing.Size(264, 20);
			this.txtSelectedFolder.TabIndex = 3;
			this.txtSelectedFolder.Text = "";
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(16, 24);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(208, 16);
			this.label5.TabIndex = 2;
			this.label5.Text = "Selected folder:";
			// 
			// txtSearchPattern
			// 
			this.txtSearchPattern.Location = new System.Drawing.Point(16, 96);
			this.txtSearchPattern.Name = "txtSearchPattern";
			this.txtSearchPattern.Size = new System.Drawing.Size(264, 20);
			this.txtSearchPattern.TabIndex = 1;
			this.txtSearchPattern.Text = "*.htm; *.mht; *.txt";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(16, 80);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(248, 16);
			this.label3.TabIndex = 0;
			this.label3.Text = "Files extensions filter:";
			// 
			// MainForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(522, 408);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.groupBox2,
																		  this.btnExit,
																		  this.btnAbout,
																		  this.groupBox1,
																		  this.label1,
																		  this.btnGenerate,
																		  this.treeFolders});
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "MainForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "HTML Indexer v2";
			this.groupBox1.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new MainForm());
		}


		private bool CheckCode()
		{
            EnterCodeForm frm = new EnterCodeForm();
			return frm.IsRegistered;
		}


		private void btnGenerate_Click(object sender, System.EventArgs e)
		{
			if ( !CheckCode() )
				return;

			bool CanGO = true;
			
			HTMLIndexer hi = new HTMLIndexer();
			hi.Folder = treeFolders.Path;
			hi.FilesFilter = txtSearchPattern.Text;
			hi.PageTitle = txtPageTitle.Text;
			hi.RenameFilesBefore = chkRenameFiles.Checked;
			hi.RenamedPrefix = txtRenamePrefix.Text;
			hi.GenerateCHM = chkGenerateCHM.Checked;

			if(!hi.FolderExists())
			{
				CanGO = false;
				MessageBox.Show("Selected folder is invalid", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
			}
			else
			{
				if(hi.IndexExists()) CanGO = (MessageBox.Show("Index file exists.\n\nContinue?", "Confirmation", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) == DialogResult.Yes);
				if(hi.GenerateCHM && (!hi.RenameFilesBefore)) CanGO = (MessageBox.Show("Is recommanded to rename files before generating the CHM project.\n\nDo you want to abort to allow you to change options?", "Confirmation", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) == DialogResult.No);
				if(hi.RenameFilesBefore)CanGO = (MessageBox.Show("Renaming files will change your filenames! Is recommanded to have a backup.\n\nContinue with renaming?", "Confirmation", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) == DialogResult.Yes);
			}
			
			if(CanGO)
			{
				try
				{
					hi.Generate();
					MessageBox.Show("All OK!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
				}
				catch(Exception err)
				{
					MessageBox.Show("Errors!\n\n" + err.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}
		}

		private void btnAbout_Click(object sender, System.EventArgs e)
		{
            StringBuilder sb = new StringBuilder();
			sb.Append(Application.ProductName);
			sb.Append(" v");
			sb.Append(Application.ProductVersion);
			sb.Append("\n\n");
			sb.Append("(c) VMASOFT 2002-2007\n");
			sb.Append("http://itobserver.blogspot.com");

			MessageBox.Show(sb.ToString(), "About", MessageBoxButtons.OK, MessageBoxIcon.Information);
		}

		private void btnExit_Click(object sender, System.EventArgs e)
		{
			Close();
		}

		private void chkRenameFiles_CheckedChanged(object sender, System.EventArgs e)
		{
			txtRenamePrefix.Enabled = (sender as CheckBox).Checked;
		}

		private void treeFolders_PathChanged(object sender, CDiese.DirBrowser.FolderTreeEventArgs e)
		{
			txtSelectedFolder.Text = e._path;
		}
		

	}


}
