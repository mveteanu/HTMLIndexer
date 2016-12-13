// --------------------------------------------------------------------------
// Description : CDiese Toolkit library
// Author	   : Serge Weinstock
//
//	You are free to use, distribute or modify this code
//	as long as this header is not removed or modified.
// --------------------------------------------------------------------------
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using System.Diagnostics;

namespace CDiese.DirBrowser
{
	/// <summary>
	/// The classic tree view of the directories hierarchy.
	/// </summary>
	[ToolboxBitmap(typeof(FolderTree)), DefaultEvent("PathChanged")]
	public class FolderTree : System.Windows.Forms.UserControl
	{
		#region Member variables
		private System.Windows.Forms.TreeView _tree;
		private System.Windows.Forms.ImageList _il;
		private System.ComponentModel.IContainer components;
		private System.Resources.ResourceManager _resman = new System.Resources.ResourceManager("CDiese.CDiese", typeof(FolderTree).Assembly);
		private ArrayList _diskWatchers;
		private System.IO.FileSystemWatcher fileSystemWatcher1;
		private	const string _pathSeparator = @"\";
		private static readonly char[] _pathSepars = new char [] {'/', '\\'};
		#endregion

		#region public interface
		/// <summary>
		/// Constructor
		/// </summary>
		public FolderTree()
		{
			// This call is required by the Windows.Forms Form Designer.
			InitializeComponent();
			Reset();
		}

		/// <summary>
		/// Reinitialises the tree
		/// </summary>
		public void Reset()
		{
			_tree.Nodes.Clear();
			_diskWatchers = new ArrayList();

			TreeNode root = new TreeNode(_resman.GetString("My Computer"));
			root.ImageIndex = 0;
			root.Tag = new NodeTag("", false);
			_tree.Nodes.Add(root);

			FillDrives();
			Path = "";
		}
		/// <summary>
		/// Reinitialises the tree but keeps the selection
		/// </summary>
		public void Reload()
		{
			string sel = "";
			if (_tree.SelectedNode != null)
			{
				GetNodePath(_tree.SelectedNode, ref sel);
			}
			Reset();
			Path = sel;
		}
		
		/// <summary>
		/// Returns or sets the current path
		/// </summary>
		[Description("The path associated to the selected node"), Browsable(false)]
		public string Path
		{
			get
			{
				if ((_tree.SelectedNode == null) || (_tree.SelectedNode.Parent == null))
				{
					return null;
				}
				string path = "";
				GetNodePath(_tree.SelectedNode, ref path);
				return path;
			}
			set
			{
				Cursor = Cursors.WaitCursor;
				TreeNode node = FindNode(value, _tree.Nodes[0], true);
				_tree.SelectedNode = node;
				node.EnsureVisible();
				Cursor = Cursors.Default;
			}
		}
		/// <summary>
		/// This event is triggered when the path changes
		/// </summary>
		[Description("Triggered when the selected path has changed")]
		public event FolderTreeEventHandler PathChanged;

		public bool CanCreateFolder()
		{
			return (_tree.SelectedNode != null && _tree.SelectedNode.Parent != null);
		}

		public void CreateFolder()
		{
			if (!CanCreateFolder())
			{
				return;
			}
			string fstr = _resman.GetString("New Folder ({0})");
			string folderName = _resman.GetString("New Folder");
			int		i = 2;

			while (true)
			{
				foreach(TreeNode node in _tree.SelectedNode.Nodes)
				{
					if (node.Text == folderName)
					{
						folderName = String.Format(fstr, i++);
						continue;
					}
				}
				break;
			}

			TreeNode newFolder = new TreeNode(folderName, 4, 5);
			newFolder.Tag = new NodeTag();
			_tree.SelectedNode.Nodes.Add(newFolder);
			_tree.SelectedNode = newFolder;
			_tree.LabelEdit = true;
			newFolder.BeginEdit();
		}

		#endregion

		#region implementation
		/// <summary>
		/// This class contains all the extra information about a node
		/// </summary>
		private class NodeTag
		{
			/// <summary>
			/// Default constructor
			/// </summary>
			public NodeTag()
			{
				_hasBeenExpandedOnce = false;
			}
			/// <summary>
			/// Constructor
			/// </summary>
			/// <param name="name">the real name of the folder</param>
			/// <param name="hasBeenExpandedOnce">true if the node has already been expanded</param>
			public NodeTag(string name, bool hasBeenExpandedOnce)
			{
				_name = name;
				_hasBeenExpandedOnce = hasBeenExpandedOnce;
			}
			/// <summary>
			/// Set to true if the node has already been expanded at least once
			/// </summary>
			public bool		_hasBeenExpandedOnce;
			/// <summary>
			/// The name of the folder (only set if different of the node text)
			/// </summary>
			public string	_name;
		}
		/// <summary>
		/// Used to sort the directory list in alphabetic order.	
		/// </summary>
		private class DirectoryComparer : IComparer 
		{
			public int Compare(Object obj1, Object obj2) 
			{
				System.IO.DirectoryInfo dir1 = (System.IO.DirectoryInfo) obj1;
				System.IO.DirectoryInfo dir2 = (System.IO.DirectoryInfo) obj2;
				return dir1.Name.CompareTo(dir2.Name);
			}
		}
		/// <summary>
		/// Add all the drives to the root node
		/// </summary>
		private void FillDrives()
		{
			String [] drives = System.IO.Directory.GetLogicalDrives();

			_tree.Nodes[0].Nodes.Clear();
			foreach (string drive in drives)
			{
				TreeNode	node = new TreeNode(drive);
				string		name = Utils.Win32.GetVolumeName(drive);

				switch(Utils.Win32.GetDriveType(drive)) 
				{
					case Utils.Win32.DriveType.CdRom:
						if(name == "") name = _resman.GetString("Compact Disk");
						node.SelectedImageIndex = node.ImageIndex = 3;
						break;
					case Utils.Win32.DriveType.Removable:
						if(name == "") name = _resman.GetString("3½ Floppy");
						node.SelectedImageIndex = node.ImageIndex = 1;
						break;
					case Utils.Win32.DriveType.Fixed:
					default:
						if(name == "") name = _resman.GetString("Local Disk");
						node.SelectedImageIndex = node.ImageIndex = 2;
						break;
				}
				node.Text = name + " (" + drive.Substring(0, 2) + ")";
				node.Tag = new NodeTag(drive.Substring(0, 2), false);
				_tree.Nodes[0].Nodes.Add(node);

				try
				{
					System.IO.FileSystemWatcher	dw = new System.IO.FileSystemWatcher(drive);
					dw.IncludeSubdirectories = true;
					dw.NotifyFilter = System.IO.NotifyFilters.DirectoryName;
					dw.Created += new System.IO.FileSystemEventHandler(OnDirCreatedCallback);
					dw.Deleted += new System.IO.FileSystemEventHandler(OnDirDeletedCallback);
					dw.Renamed += new System.IO.RenamedEventHandler(OnDirRenamedCallback);
					_diskWatchers.Add(dw);
				}
				catch 
				{
					// floppy or removable drive not mounted
				}
			}
			// now we are ready for receiving events
			foreach(System.IO.FileSystemWatcher fw in _diskWatchers)
			{
				fw.EnableRaisingEvents = true;
			}
		}
		/// <summary>
		/// Returns the "true" name of a folder
		/// </summary>
		/// <param name="node"The corresponding node></param>
		/// <returns></returns>
		string GetNodeName(TreeNode node)
		{
			NodeTag tag = (NodeTag)node.Tag;
			if (tag._name != null)
			{
				return tag._name;
			}
			return node.Text;
		}
		/// <summary>
		/// returns the path corresponding to a node
		/// </summary>
		/// <param name="node">the node for which the path is computed</param>
		/// <param name="path">the path associated to the node</param>
		void GetNodePath(TreeNode node, ref string path)
		{
			if (node.Parent == null)
			{
				return;
			}

			path = GetNodeName(node) + _pathSeparator + path;
			GetNodePath(node.Parent, ref path);
		}
		/// <summary>
		/// Find the "closest" node corrsponding to the path
		/// </summary>
		TreeNode FindNode(string path, TreeNode from, bool createNodes)
		{
			if (path == null || path == "")
			{
				return from;
			}
			// name of the folder
			int pos = path.IndexOfAny(_pathSepars);
			string folder = (pos >= 0 ? path.Substring(0, pos) : path);
			path = ((pos == path.Length - 1) || (pos == -1) ? "" : path.Substring(pos+1));
			// expand the folder if needed
			if (createNodes)
			{
				ExpandNode(from);
			}
			// look trough the child
			foreach(TreeNode child in from.Nodes)
			{
				if (String.Compare(GetNodeName(child), folder, true) == 0)
				{
					TreeNode res = FindNode(path, child, createNodes);
					if (res == null)
					{
						res = child;
					}
				return res;
				}
			}
			return null;
		}
		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
			// now we are ready for receiving events
			foreach(System.IO.FileSystemWatcher fw in _diskWatchers)
			{
				fw.EnableRaisingEvents = false;
				fw.Created -= new System.IO.FileSystemEventHandler(OnDirCreatedCallback);
				fw.Deleted -= new System.IO.FileSystemEventHandler(OnDirDeletedCallback);
				fw.Renamed -= new System.IO.RenamedEventHandler(OnDirRenamedCallback);
			}
			if( components != null )
					components.Dispose();
			}
			base.Dispose( disposing );
		}
		/// <summary>
		/// Expands a node
		/// </summary>
		/// <param name="node">the node to expand</param>
		void ExpandNode(TreeNode node)
		{
			NodeTag tag = (NodeTag)node.Tag;

			if (tag._hasBeenExpandedOnce)
			{
				return;
			}
		
			DirectoryComparer comparer = new DirectoryComparer();

			foreach(TreeNode childnode in node.Nodes)
			{
				try
				{
					string path = "";

					GetNodePath(childnode, ref path);

					childnode.Nodes.Clear();
					System.IO.DirectoryInfo dirInfo = new System.IO.DirectoryInfo(path);
					// floppy or removable drive not mounted ?
					if (dirInfo.Exists)
					{
						System.IO.DirectoryInfo[] subDirInfos = dirInfo.GetDirectories();

						Array.Sort(subDirInfos,  comparer);
						foreach(System.IO.DirectoryInfo subDirInfo in subDirInfos) 
						{
							if((subDirInfo.Attributes & System.IO.FileAttributes.Hidden) == 0) 
							{
								TreeNode	nnode = new TreeNode(subDirInfo.Name);

								nnode.Tag = new NodeTag();
								nnode.ImageIndex = 4;
								nnode.SelectedImageIndex = 5;
								childnode.Nodes.Add(nnode);
							}
						}
					}
				}
				catch 
				{
					// floppy or removable drive not mounted
				}
			}
			tag._hasBeenExpandedOnce = true;
		}
		#endregion

		#region filesystem monitoring
		private void OnDirCreatedCallback(object source, System.IO.FileSystemEventArgs e)
		{
			BeginInvoke(new System.IO.FileSystemEventHandler(OnDirCreated), new Object[] {source, e} );
		}
		private void OnDirCreated(object source, System.IO.FileSystemEventArgs e)
		{
			int		pos = e.FullPath.LastIndexOfAny(_pathSepars);
			Debug.Assert(pos != -1 && pos != e.FullPath.Length-1);
			string	parentPath = e.FullPath.Substring(0, pos+1);
			// find the closest node
			TreeNode	n = FindNode(parentPath, _tree.Nodes[0], false);
			string		path = "";

			GetNodePath(n, ref path);
			// if associated to a node
			if (String.Compare(parentPath, path, true) == 0)
			{
				TreeNode	nnode = new TreeNode(e.FullPath.Substring(pos+1));
				int			i, N = n.Nodes.Count;

				nnode.Tag = new NodeTag();
				nnode.ImageIndex = 4;
				nnode.SelectedImageIndex = 5;
				for (i = 0; i < N; i++)
				{
					int c = String.Compare(nnode.Text, n.Nodes[i].Text, true);
					if (c == 0)
					{
						// already shown
						return;
					}
					if (c < 0)
					{
						break;
					}
				}
				n.Nodes.Insert(i, nnode);
			}
		}
		private void OnDirDeletedCallback(object source, System.IO.FileSystemEventArgs e)
		{
			BeginInvoke(new System.IO.FileSystemEventHandler(OnDirDeleted), new Object[] {source, e} );
		}
		private void OnDirDeleted(object source, System.IO.FileSystemEventArgs e)
		{
			// find the closest node
			TreeNode	n = FindNode(e.FullPath, _tree.Nodes[0], false);
			string		path = "";

			GetNodePath(n, ref path);
			// if associated to a node
			if (String.Compare(e.FullPath + _pathSeparator, path, true) == 0)
			{
				// if selected
				if (n == _tree.SelectedNode)
				{
					_tree.SelectedNode = n.Parent;
				}
				n.Remove();
			}
		}
		private void OnDirRenamedCallback(object source, System.IO.RenamedEventArgs e)
		{
			BeginInvoke(new System.IO.RenamedEventHandler(OnDirRenamed), new Object[] {source, e} );
		}
		private void OnDirRenamed(object source, System.IO.RenamedEventArgs e)
		{
			// find the closest node
			TreeNode	n = FindNode(e.OldFullPath, _tree.Nodes[0], false);
			string		path = "";

			GetNodePath(n, ref path);
			// if associated to a node
			if (String.Compare(e.OldFullPath + _pathSeparator, path, true) == 0)
			{
				// we must delete it and re-insert at the right place
				TreeNode	p = n.Parent;
				int			pos = e.FullPath.LastIndexOfAny(_pathSepars), N = p.Nodes.Count, i;
				bool		sel = (n == _tree.SelectedNode);

				Debug.Assert(pos != -1 && pos != e.FullPath.Length-1);
				n.Text = e.FullPath.Substring(pos+1);
				n.Remove();
				N--;
				for (i = 0; i < N; i++)
				{
					if (String.Compare(n.Text, p.Nodes[i].Text, true) < 0)
					{
						break;
					}
				}
				p.Nodes.Insert(i, n);
				if (sel)
				{
					_tree.SelectedNode = n;
				}
			}
		}
		#endregion

		#region event handling
		private void OnBeforeExpand(object sender, System.Windows.Forms.TreeViewCancelEventArgs e)
		{
			Cursor = Cursors.WaitCursor;
			Debug.Assert(e.Action == TreeViewAction.Expand);
			ExpandNode(e.Node);
			Cursor = Cursors.Default;
		}
		private void OnSelectFolder(object sender, System.Windows.Forms.TreeViewEventArgs e)
		{
			if (PathChanged != null)
			{
				PathChanged(this, new FolderTreeEventArgs(Path));
			}
		}
		/// <summary>
		/// Called when the user is creating a folder and has finished to enter the name
		/// </summary>
		private void OnEndEdit(object sender, System.Windows.Forms.NodeLabelEditEventArgs e)
		{
			_tree.LabelEdit = false;
			// try to create it
			string path = "";
			GetNodePath(e.Node, ref path);
			// we must delete it and re-insert at the right place
			TreeNode	p = e.Node.Parent;
			int			N = p.Nodes.Count, i;

			e.Node.Remove();
			N--;
			for (i = 0; i < N; i++)
			{
				if (String.Compare(e.Node.Text, p.Nodes[i].Text, true) < 0)
				{
					break;
				}
			}
			p.Nodes.Insert(i, e.Node);
			_tree.SelectedNode = e.Node;
			// now create the directory
			try
			{
				System.IO.Directory.CreateDirectory(path);
			}
			catch
			{
				if (_tree.SelectedNode.Equals(e.Node))
				{
					_tree.SelectedNode = e.Node.Parent;
				}
				e.Node.Remove();
			}
		}
		#endregion

		#region Component Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(FolderTree));
			this._tree = new System.Windows.Forms.TreeView();
			this._il = new System.Windows.Forms.ImageList(this.components);
			this.fileSystemWatcher1 = new System.IO.FileSystemWatcher();
			((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).BeginInit();
			this.SuspendLayout();
			// 
			// _tree
			// 
			this._tree.AccessibleDescription = ((string)(resources.GetObject("_tree.AccessibleDescription")));
			this._tree.AccessibleName = ((string)(resources.GetObject("_tree.AccessibleName")));
			this._tree.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("_tree.Anchor")));
			this._tree.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("_tree.BackgroundImage")));
			this._tree.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("_tree.Dock")));
			this._tree.Enabled = ((bool)(resources.GetObject("_tree.Enabled")));
			this._tree.Font = ((System.Drawing.Font)(resources.GetObject("_tree.Font")));
			this._tree.ImageIndex = ((int)(resources.GetObject("_tree.ImageIndex")));
			this._tree.ImageList = this._il;
			this._tree.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("_tree.ImeMode")));
			this._tree.Indent = ((int)(resources.GetObject("_tree.Indent")));
			this._tree.ItemHeight = ((int)(resources.GetObject("_tree.ItemHeight")));
			this._tree.Location = ((System.Drawing.Point)(resources.GetObject("_tree.Location")));
			this._tree.Name = "_tree";
			this._tree.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("_tree.RightToLeft")));
			this._tree.SelectedImageIndex = ((int)(resources.GetObject("_tree.SelectedImageIndex")));
			this._tree.Size = ((System.Drawing.Size)(resources.GetObject("_tree.Size")));
			this._tree.TabIndex = ((int)(resources.GetObject("_tree.TabIndex")));
			this._tree.Text = resources.GetString("_tree.Text");
			this._tree.Visible = ((bool)(resources.GetObject("_tree.Visible")));
			this._tree.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.OnSelectFolder);
			this._tree.AfterLabelEdit += new System.Windows.Forms.NodeLabelEditEventHandler(this.OnEndEdit);
			this._tree.BeforeExpand += new System.Windows.Forms.TreeViewCancelEventHandler(this.OnBeforeExpand);
			// 
			// _il
			// 
			this._il.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
			this._il.ImageSize = ((System.Drawing.Size)(resources.GetObject("_il.ImageSize")));
			this._il.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("_il.ImageStream")));
			this._il.TransparentColor = System.Drawing.Color.Magenta;
			// 
			// fileSystemWatcher1
			// 
			this.fileSystemWatcher1.EnableRaisingEvents = true;
			this.fileSystemWatcher1.Path = "C:\\";
			this.fileSystemWatcher1.SynchronizingObject = this;
			// 
			// FolderTree
			// 
			this.AccessibleDescription = ((string)(resources.GetObject("$this.AccessibleDescription")));
			this.AccessibleName = ((string)(resources.GetObject("$this.AccessibleName")));
			this.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("$this.Anchor")));
			this.AutoScroll = ((bool)(resources.GetObject("$this.AutoScroll")));
			this.AutoScrollMargin = ((System.Drawing.Size)(resources.GetObject("$this.AutoScrollMargin")));
			this.AutoScrollMinSize = ((System.Drawing.Size)(resources.GetObject("$this.AutoScrollMinSize")));
			this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this._tree});
			this.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("$this.Dock")));
			this.Enabled = ((bool)(resources.GetObject("$this.Enabled")));
			this.Font = ((System.Drawing.Font)(resources.GetObject("$this.Font")));
			this.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("$this.ImeMode")));
			this.Location = ((System.Drawing.Point)(resources.GetObject("$this.Location")));
			this.Name = "FolderTree";
			this.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("$this.RightToLeft")));
			this.Size = ((System.Drawing.Size)(resources.GetObject("$this.Size")));
			this.TabIndex = ((int)(resources.GetObject("$this.TabIndex")));
			this.Visible = ((bool)(resources.GetObject("$this.Visible")));
			((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion
	}
	/// <summary>
	/// The type of events sent by a FolderTree
	/// </summary>
	public class FolderTreeEventArgs : EventArgs
	{
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="path">The path to the selected folder</param>
		public FolderTreeEventArgs(string path)
		{
			_path = path;
		}
		/// <summary>
		/// The path to the selected folder
		/// </summary>
		public string _path;
	}

	/// <summary>
	/// The delegate type used by events sent by a FolderTree
	/// </summary>
	public delegate void FolderTreeEventHandler(object sender, FolderTreeEventArgs e);
}