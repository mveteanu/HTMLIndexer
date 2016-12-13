// --------------------------------------------------------------------------
// Description : CDiese Toolkit library
// Author	   : Serge Weinstock
//
//	You are free to use, distribute or modify this code
//	as long as this header is not removed or modified.
// --------------------------------------------------------------------------
using System;
using System.ComponentModel;
using System.Collections;
using System.Diagnostics;
using System.Drawing;

namespace CDiese.DirBrowser
{
	/// <summary>
	/// A component which wraps the FolderForm dialog
	/// </summary>
	[ToolboxBitmap(typeof(FolderDialog))]
	public class FolderDialog : System.ComponentModel.Component
	{
		#region member variables
		/// <summary>
		/// The current path
		/// </summary>
		private	string _path;
		/// <summary>
		/// The title of the dialog
		/// </summary>
		private	string _text;
		/// <summary>
		/// The starting position of the dialog
		/// </summary>
		private System.Windows.Forms.FormStartPosition _startPosition = System.Windows.Forms.FormStartPosition.WindowsDefaultLocation;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		#endregion
		#region public interface
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="container"></param>
		public FolderDialog(System.ComponentModel.IContainer container)
		{
			/// <summary>
			/// Required for Windows.Forms Class Composition Designer support
			/// </summary>
			container.Add(this);
			InitializeComponent();
			System.Resources.ResourceManager	resman = new System.Resources.ResourceManager("CDiese.CDiese", typeof(FolderTree).Assembly);
			_text = resman.GetString("Browse for folder");
		}

		/// <summary>
		/// Constructor
		/// </summary>
		public FolderDialog()
		{
			/// <summary>
			/// Required for Windows.Forms Class Composition Designer support
			/// </summary>
			InitializeComponent();
			System.Resources.ResourceManager	resman = new System.Resources.ResourceManager("CDiese.CDiese", typeof(FolderTree).Assembly);
			_text = resman.GetString("Browse for folder");
		}
		/// <summary>
		/// Returns or sets the current path
		/// </summary>
		[Description("The current path"), Browsable(false)]
		public string Path
		{
			get
			{
				return _path;
			}
			set
			{
				_path = value;
			}
		}
		[
			Description("The title of the dialog"),
			Localizable(true)
		]
		public string Text
		{
			get
			{
				return _text;
			}
			set
			{
				_text = value;
			}
		}
		[Description("The starting position of the dialog")]
		public System.Windows.Forms.FormStartPosition StartPosition 
		{
			get
			{
				return _startPosition;
			}
			set
			{
				_startPosition = value;
			}
		}
		/// <summary>
		/// Shows the form as a modal dialog box with no owner window
		/// </summary>
		/// <returns>the result of the dialog</returns>
		public System.Windows.Forms.DialogResult ShowDialog()
		{
			return ShowDialog(null);
		}
		/// <summary>
		/// Shows the form as a modal dialog with the specified owner
		/// </summary>
		/// <returns>the result of the dialog</returns>
		public System.Windows.Forms.DialogResult ShowDialog(System.Windows.Forms.IWin32Window owner)
		{
			FolderForm							dlg = new FolderForm();

			dlg.Path = Path;
			dlg.Text = Text;
			dlg.StartPosition = StartPosition;
			System.Windows.Forms.DialogResult res = dlg.ShowDialog(owner);
			Path = dlg.Path;
			dlg.Dispose();
			return res;
		}
		#endregion
		#region Component Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			components = new System.ComponentModel.Container();
		}
		#endregion
	}
}
