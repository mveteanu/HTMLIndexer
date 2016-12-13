using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

using Microsoft.Win32;

namespace VMA.HTMLIndexer
{
	/// <summary>
	/// Summary description for EnterCode.
	/// </summary>
	public class EnterCodeForm : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.LinkLabel lnkSubscribe;
		private System.Windows.Forms.LinkLabel lnkBlogUrl;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Button btnOK;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.TextBox txtCode;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

        private RegSupport m_reg;

        public EnterCodeForm()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

            m_reg = new RegSupport();
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EnterCodeForm));
            this.label1 = new System.Windows.Forms.Label();
            this.lnkSubscribe = new System.Windows.Forms.LinkLabel();
            this.lnkBlogUrl = new System.Windows.Forms.LinkLabel();
            this.txtCode = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 88);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Activation code";
            // 
            // lnkSubscribe
            // 
            this.lnkSubscribe.AutoSize = true;
            this.lnkSubscribe.Location = new System.Drawing.Point(16, 192);
            this.lnkSubscribe.Name = "lnkSubscribe";
            this.lnkSubscribe.Size = new System.Drawing.Size(148, 13);
            this.lnkSubscribe.TabIndex = 3;
            this.lnkSubscribe.TabStop = true;
            this.lnkSubscribe.Text = "Subscribe now to ITObserver!";
            this.lnkSubscribe.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkSubscribe_LinkClicked);
            // 
            // lnkBlogUrl
            // 
            this.lnkBlogUrl.AutoSize = true;
            this.lnkBlogUrl.Location = new System.Drawing.Point(16, 216);
            this.lnkBlogUrl.Name = "lnkBlogUrl";
            this.lnkBlogUrl.Size = new System.Drawing.Size(150, 13);
            this.lnkBlogUrl.TabIndex = 4;
            this.lnkBlogUrl.TabStop = true;
            this.lnkBlogUrl.Text = "http://itobserver.blogspot.com";
            this.lnkBlogUrl.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkBlogUrl_LinkClicked);
            // 
            // txtCode
            // 
            this.txtCode.Location = new System.Drawing.Point(120, 88);
            this.txtCode.Name = "txtCode";
            this.txtCode.PasswordChar = '*';
            this.txtCode.Size = new System.Drawing.Size(272, 20);
            this.txtCode.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(16, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(416, 40);
            this.label3.TabIndex = 7;
            this.label3.Text = resources.GetString("label3.Text");
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(16, 160);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(408, 32);
            this.label4.TabIndex = 9;
            this.label4.Text = "Click the following link to subscribe now, or visit the blog and chose from there" +
                " the email subscription option.";
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(248, 248);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 1;
            this.btnOK.Text = "&OK";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(336, 248);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // EnterCodeForm
            // 
            this.AcceptButton = this.btnCancel;
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(432, 288);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtCode);
            this.Controls.Add(this.lnkBlogUrl);
            this.Controls.Add(this.lnkSubscribe);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EnterCodeForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Activation code";
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		
        public bool IsRegistered
        {
            get 
            {
                if (m_reg.IsRegistered)
                    return true;

                this.ShowDialog();
                return m_reg.IsRegistered;
            }
        }
 
		private void btnCancel_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void btnOK_Click(object sender, System.EventArgs e)
		{
			if ( txtCode.Text.Trim().ToLower() != "itobserver" )
			{
				MessageBox.Show("Invalid code.\nPlease subscribe to ITObserver in order to receive a valid code");
				return;
			}

            m_reg.Register();
			this.Close();
		}

		private void lnkSubscribe_LinkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
		{
			System.Diagnostics.Process.Start("http://www.feedburner.com/fb/a/emailverifySubmit?feedId=315486");
		}

		private void lnkBlogUrl_LinkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
		{
			System.Diagnostics.Process.Start("http://itobserver.blogspot.com");
		}


        #region Registry support class
        private class RegSupport
        {
            private string keyName = "Software\\VMASOFT\\HTMLIndexer";
            private string dateValueName = "AccessDate";
            private string codeValueName = "AccessCode";
            private string accessCode = "VMA ITObserver - http://itobserver.blogspot.com";

            public bool IsRegistered
            {
                get
                {
                    System.DateTime accessDate = GetFirstAccessDate();
                    System.TimeSpan dateDiff = System.DateTime.Now.Subtract(accessDate);
                    if (dateDiff.Days < 2)
                        return true;

                    string rcode = GetAccessCode();
                    bool b = rcode == accessCode;

                    return GetAccessCode() == accessCode;
                }
            }

            public void Register()
            {
                SetAccessCode(accessCode);
            }

            private System.DateTime GetFirstAccessDate()
            {
                System.DateTime currDate = System.DateTime.Today;
                RegistryKey key = null;

                try
                {
                    key = Registry.CurrentUser.OpenSubKey(keyName, true);
                    if (key == null)
                    {
                        key = Registry.CurrentUser.CreateSubKey(keyName);
                        key.SetValue(dateValueName, currDate.ToShortDateString());
                        return currDate;
                    }

                    string date = key.GetValue(dateValueName) as string;
                    if (date == null)
                    {
                        key.SetValue(dateValueName, currDate.ToShortDateString());
                        return currDate;
                    }

                    return System.DateTime.Parse(date);
                }
                catch
                {
                    return currDate;
                }
                finally
                {
                    if (key != null)
                        key.Close();
                }
            }

            private string GetAccessCode()
            {
                RegistryKey key = null;

                try
                {
                    key = Registry.CurrentUser.OpenSubKey(keyName);
                    if (key == null)
                        return "";

                    string code = key.GetValue(codeValueName) as string;
                    return code != null ? code : "";
                }
                catch
                {
                    return "";
                }
                finally
                {
                    if (key != null)
                        key.Close();
                }
            }

            private void SetAccessCode(string code)
            {
                RegistryKey key = null;

                try
                {
                    key = Registry.CurrentUser.OpenSubKey(keyName, true);
                    if (key == null)
                        key = Registry.CurrentUser.CreateSubKey(keyName);

                    key.SetValue(codeValueName, code);
                }
                catch { }
                finally
                {
                    if (key != null)
                        key.Close();
                }
            }

        }
        #endregion regsupport class


	}
}
