// --------------------------------------------------------------------------
// Description : CDiese Toolkit library
// Author	   : Serge Weinstock
//
//	You are free to use, distribute or modify this code
//	as long as this header is not removed or modified.
// --------------------------------------------------------------------------
using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace CDiese.DirBrowser
{
	/// <summary>
	/// A "browse for folder" dialog
	/// </summary>
	public class FolderForm : System.Windows.Forms.Form
	{
		#region member variables
		private System.Windows.Forms.ImageList _il;
		private System.Windows.Forms.Button _OKButton;
		private System.Windows.Forms.Button _cancelBtn;
		private CDiese.DirBrowser.FolderTree _folderTree;
		private System.Windows.Forms.ToolTip _toolTip;
		private System.Windows.Forms.Button _refresh;
		private System.Windows.Forms.Button _createFolder;
		private System.ComponentModel.IContainer components;
		#endregion
		#region public interface
		/// <summary>
		/// Constructor
		/// </summary>
		public FolderForm()
		{
			InitializeComponent();
		}
		/// <summary>
		/// Returns or sets the current path
		/// </summary>
		[Description("The current path"), Browsable(false)]
		public string Path
		{
			get
			{
				return _folderTree.Path;
			}
			set
			{
				_folderTree.Path = value;
			}
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
		#endregion
		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(FolderForm));
			this._folderTree = new CDiese.DirBrowser.FolderTree();
			this._refresh = new System.Windows.Forms.Button();
			this._il = new System.Windows.Forms.ImageList(this.components);
			this._OKButton = new System.Windows.Forms.Button();
			this._cancelBtn = new System.Windows.Forms.Button();
			this._toolTip = new System.Windows.Forms.ToolTip(this.components);
			this._createFolder = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// _folderTree
			// 
			this._folderTree.AccessibleDescription = ((string)(resources.GetObject("_folderTree.AccessibleDescription")));
			this._folderTree.AccessibleName = ((string)(resources.GetObject("_folderTree.AccessibleName")));
			this._folderTree.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("_folderTree.Anchor")));
			this._folderTree.AutoScroll = ((bool)(resources.GetObject("_folderTree.AutoScroll")));
			this._folderTree.AutoScrollMargin = ((System.Drawing.Size)(resources.GetObject("_folderTree.AutoScrollMargin")));
			this._folderTree.AutoScrollMinSize = ((System.Drawing.Size)(resources.GetObject("_folderTree.AutoScrollMinSize")));
			this._folderTree.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("_folderTree.BackgroundImage")));
			this._folderTree.Cursor = System.Windows.Forms.Cursors.Default;
			this._folderTree.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("_folderTree.Dock")));
			this._folderTree.Enabled = ((bool)(resources.GetObject("_folderTree.Enabled")));
			this._folderTree.Font = ((System.Drawing.Font)(resources.GetObject("_folderTree.Font")));
			this._folderTree.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("_folderTree.ImeMode")));
			this._folderTree.Location = ((System.Drawing.Point)(resources.GetObject("_folderTree.Location")));
			this._folderTree.Name = "_folderTree";
			this._folderTree.Path = null;
			this._folderTree.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("_folderTree.RightToLeft")));
			this._folderTree.Size = ((System.Drawing.Size)(resources.GetObject("_folderTree.Size")));
			this._folderTree.TabIndex = ((int)(resources.GetObject("_folderTree.TabIndex")));
			this._toolTip.SetToolTip(this._folderTree, resources.GetString("_folderTree.ToolTip"));
			this._folderTree.Visible = ((bool)(resources.GetObject("_folderTree.Visible")));
			// 
			// _refresh
			// 
			this._refresh.AccessibleDescription = ((string)(resources.GetObject("_refresh.AccessibleDescription")));
			this._refresh.AccessibleName = ((string)(resources.GetObject("_refresh.AccessibleName")));
			this._refresh.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("_refresh.Anchor")));
			this._refresh.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("_refresh.BackgroundImage")));
			this._refresh.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("_refresh.Dock")));
			this._refresh.Enabled = ((bool)(resources.GetObject("_refresh.Enabled")));
			this._refresh.FlatStyle = ((System.Windows.Forms.FlatStyle)(resources.GetObject("_refresh.FlatStyle")));
			this._refresh.Font = ((System.Drawing.Font)(resources.GetObject("_refresh.Font")));
			this._refresh.Image = ((System.Drawing.Bitmap)(resources.GetObject("_refresh.Image")));
			this._refresh.ImageAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("_refresh.ImageAlign")));
			this._refresh.ImageIndex = ((int)(resources.GetObject("_refresh.ImageIndex")));
			this._refresh.ImageList = this._il;
			this._refresh.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("_refresh.ImeMode")));
			this._refresh.Location = ((System.Drawing.Point)(resources.GetObject("_refresh.Location")));
			this._refresh.Name = "_refresh";
			this._refresh.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("_refresh.RightToLeft")));
			this._refresh.Size = ((System.Drawing.Size)(resources.GetObject("_refresh.Size")));
			this._refresh.TabIndex = ((int)(resources.GetObject("_refresh.TabIndex")));
			this._refresh.Text = resources.GetString("_refresh.Text");
			this._refresh.TextAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("_refresh.TextAlign")));
			this._toolTip.SetToolTip(this._refresh, resources.GetString("_refresh.ToolTip"));
			this._refresh.Visible = ((bool)(resources.GetObject("_refresh.Visible")));
			this._refresh.Click += new System.EventHandler(this.OnRefresh);
			// 
			// _il
			// 
			this._il.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
			this._il.ImageSize = ((System.Drawing.Size)(resources.GetObject("_il.ImageSize")));
			this._il.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("_il.ImageStream")));
			this._il.TransparentColor = System.Drawing.Color.Transparent;
			// 
			// _OKButton
			// 
			this._OKButton.AccessibleDescription = ((string)(resources.GetObject("_OKButton.AccessibleDescription")));
			this._OKButton.AccessibleName = ((string)(resources.GetObject("_OKButton.AccessibleName")));
			this._OKButton.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("_OKButton.Anchor")));
			this._OKButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("_OKButton.BackgroundImage")));
			this._OKButton.DialogResult = System.Windows.Forms.DialogResult.OK;
			this._OKButton.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("_OKButton.Dock")));
			this._OKButton.Enabled = ((bool)(resources.GetObject("_OKButton.Enabled")));
			this._OKButton.FlatStyle = ((System.Windows.Forms.FlatStyle)(resources.GetObject("_OKButton.FlatStyle")));
			this._OKButton.Font = ((System.Drawing.Font)(resources.GetObject("_OKButton.Font")));
			this._OKButton.Image = ((System.Drawing.Image)(resources.GetObject("_OKButton.Image")));
			this._OKButton.ImageAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("_OKButton.ImageAlign")));
			this._OKButton.ImageIndex = ((int)(resources.GetObject("_OKButton.ImageIndex")));
			this._OKButton.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("_OKButton.ImeMode")));
			this._OKButton.Location = ((System.Drawing.Point)(resources.GetObject("_OKButton.Location")));
			this._OKButton.Name = "_OKButton";
			this._OKButton.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("_OKButton.RightToLeft")));
			this._OKButton.Size = ((System.Drawing.Size)(resources.GetObject("_OKButton.Size")));
			this._OKButton.TabIndex = ((int)(resources.GetObject("_OKButton.TabIndex")));
			this._OKButton.Text = resources.GetString("_OKButton.Text");
			this._OKButton.TextAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("_OKButton.TextAlign")));
			this._toolTip.SetToolTip(this._OKButton, resources.GetString("_OKButton.ToolTip"));
			this._OKButton.Visible = ((bool)(resources.GetObject("_OKButton.Visible")));
			// 
			// _cancelBtn
			// 
			this._cancelBtn.AccessibleDescription = ((string)(resources.GetObject("_cancelBtn.AccessibleDescription")));
			this._cancelBtn.AccessibleName = ((string)(resources.GetObject("_cancelBtn.AccessibleName")));
			this._cancelBtn.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("_cancelBtn.Anchor")));
			this._cancelBtn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("_cancelBtn.BackgroundImage")));
			this._cancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this._cancelBtn.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("_cancelBtn.Dock")));
			this._cancelBtn.Enabled = ((bool)(resources.GetObject("_cancelBtn.Enabled")));
			this._cancelBtn.FlatStyle = ((System.Windows.Forms.FlatStyle)(resources.GetObject("_cancelBtn.FlatStyle")));
			this._cancelBtn.Font = ((System.Drawing.Font)(resources.GetObject("_cancelBtn.Font")));
			this._cancelBtn.Image = ((System.Drawing.Image)(resources.GetObject("_cancelBtn.Image")));
			this._cancelBtn.ImageAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("_cancelBtn.ImageAlign")));
			this._cancelBtn.ImageIndex = ((int)(resources.GetObject("_cancelBtn.ImageIndex")));
			this._cancelBtn.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("_cancelBtn.ImeMode")));
			this._cancelBtn.Location = ((System.Drawing.Point)(resources.GetObject("_cancelBtn.Location")));
			this._cancelBtn.Name = "_cancelBtn";
			this._cancelBtn.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("_cancelBtn.RightToLeft")));
			this._cancelBtn.Size = ((System.Drawing.Size)(resources.GetObject("_cancelBtn.Size")));
			this._cancelBtn.TabIndex = ((int)(resources.GetObject("_cancelBtn.TabIndex")));
			this._cancelBtn.Text = resources.GetString("_cancelBtn.Text");
			this._cancelBtn.TextAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("_cancelBtn.TextAlign")));
			this._toolTip.SetToolTip(this._cancelBtn, resources.GetString("_cancelBtn.ToolTip"));
			this._cancelBtn.Visible = ((bool)(resources.GetObject("_cancelBtn.Visible")));
			// 
			// _createFolder
			// 
			this._createFolder.AccessibleDescription = ((string)(resources.GetObject("_createFolder.AccessibleDescription")));
			this._createFolder.AccessibleName = ((string)(resources.GetObject("_createFolder.AccessibleName")));
			this._createFolder.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("_createFolder.Anchor")));
			this._createFolder.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("_createFolder.BackgroundImage")));
			this._createFolder.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("_createFolder.Dock")));
			this._createFolder.Enabled = ((bool)(resources.GetObject("_createFolder.Enabled")));
			this._createFolder.FlatStyle = ((System.Windows.Forms.FlatStyle)(resources.GetObject("_createFolder.FlatStyle")));
			this._createFolder.Font = ((System.Drawing.Font)(resources.GetObject("_createFolder.Font")));
			this._createFolder.Image = ((System.Drawing.Bitmap)(resources.GetObject("_createFolder.Image")));
			this._createFolder.ImageAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("_createFolder.ImageAlign")));
			this._createFolder.ImageIndex = ((int)(resources.GetObject("_createFolder.ImageIndex")));
			this._createFolder.ImageList = this._il;
			this._createFolder.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("_createFolder.ImeMode")));
			this._createFolder.Location = ((System.Drawing.Point)(resources.GetObject("_createFolder.Location")));
			this._createFolder.Name = "_createFolder";
			this._createFolder.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("_createFolder.RightToLeft")));
			this._createFolder.Size = ((System.Drawing.Size)(resources.GetObject("_createFolder.Size")));
			this._createFolder.TabIndex = ((int)(resources.GetObject("_createFolder.TabIndex")));
			this._createFolder.Text = resources.GetString("_createFolder.Text");
			this._createFolder.TextAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("_createFolder.TextAlign")));
			this._toolTip.SetToolTip(this._createFolder, resources.GetString("_createFolder.ToolTip"));
			this._createFolder.Visible = ((bool)(resources.GetObject("_createFolder.Visible")));
			this._createFolder.Click += new System.EventHandler(this.OnCreateFolder);
			// 
			// FolderForm
			// 
			this.AccessibleDescription = ((string)(resources.GetObject("$this.AccessibleDescription")));
			this.AccessibleName = ((string)(resources.GetObject("$this.AccessibleName")));
			this.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("$this.Anchor")));
			this.AutoScaleBaseSize = ((System.Drawing.Size)(resources.GetObject("$this.AutoScaleBaseSize")));
			this.AutoScroll = ((bool)(resources.GetObject("$this.AutoScroll")));
			this.AutoScrollMargin = ((System.Drawing.Size)(resources.GetObject("$this.AutoScrollMargin")));
			this.AutoScrollMinSize = ((System.Drawing.Size)(resources.GetObject("$this.AutoScrollMinSize")));
			this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
			this.ClientSize = ((System.Drawing.Size)(resources.GetObject("$this.ClientSize")));
			this.ControlBox = false;
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this._createFolder,
																		  this._cancelBtn,
																		  this._OKButton,
																		  this._folderTree,
																		  this._refresh});
			this.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("$this.Dock")));
			this.Enabled = ((bool)(resources.GetObject("$this.Enabled")));
			this.Font = ((System.Drawing.Font)(resources.GetObject("$this.Font")));
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("$this.ImeMode")));
			this.Location = ((System.Drawing.Point)(resources.GetObject("$this.Location")));
			this.MaximumSize = ((System.Drawing.Size)(resources.GetObject("$this.MaximumSize")));
			this.MinimumSize = ((System.Drawing.Size)(resources.GetObject("$this.MinimumSize")));
			this.Name = "FolderForm";
			this.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("$this.RightToLeft")));
			this.StartPosition = ((System.Windows.Forms.FormStartPosition)(resources.GetObject("$this.StartPosition")));
			this.Text = resources.GetString("$this.Text");
			this._toolTip.SetToolTip(this, resources.GetString("$this.ToolTip"));
			this.Visible = ((bool)(resources.GetObject("$this.Visible")));
			this.ResumeLayout(false);

		}
		#endregion
		#region internal
		private void OnRefresh(object sender, System.EventArgs e)
		{
			_folderTree.Reload();
		}
		private void OnCreateFolder(object sender, System.EventArgs e)
		{
			_folderTree.CreateFolder();
		}
		#endregion

	}
}
