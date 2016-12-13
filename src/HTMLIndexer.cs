using System;
using System.IO;
using System.Text;
using System.Collections;

namespace VMA.HTMLIndexer
{
	public class HTMLIndexer
	{
		public HTMLIndexer(){}

		private string _folder = String.Empty;
		private string _filesFilter;
		private string _pageTitle;
		private bool _renameFiles;
		private string _renamedPrefix;
		private bool _generateCHM;

		public string Folder
		{
			get{return _folder;}
			set{_folder = value;}
		}

		public string FilesFilter
		{
			get{return _filesFilter;}
			set{_filesFilter = value;}
		}

		public string PageTitle
		{
			get{return _pageTitle;}
			set{_pageTitle = value;}
		}

		public bool RenameFilesBefore
		{
			get{return _renameFiles;}
			set{_renameFiles = value;}
		}

		public string RenamedPrefix
		{
			get{return _renamedPrefix;}
			set{_renamedPrefix = value;}
		}

		public bool GenerateCHM
		{
			get{return _generateCHM;}
			set{_generateCHM = value;}
		}

		public bool IndexExists()
		{
			return this.FileExists(_folder + "index.htm");
		}

		public bool FolderExists()
		{
			return this.DirectoryExists(_folder);
		}

		public void Generate()
		{
			string ErrMessage = String.Empty;
			
			string[] FileNames = this.GetFiles(_folder, _filesFilter);
			string[] RenamedFileNames;
			if(_renameFiles)
			{
				RenamedFileNames = this.GetRenamedFiles(FileNames, _renamedPrefix);
				if(!this.RenameFiles(FileNames, RenamedFileNames))ErrMessage+="File rename error.\n";
			} else RenamedFileNames = FileNames;
			
			if(!this.StringToFile(_folder + "index.htm", this.GetIndexPage(RenamedFileNames, FileNames, _pageTitle)))
				ErrMessage+="Error generating index.\n";
			if(_generateCHM)
			{
				if(!this.StringToFile(_folder + "index.hhp", this.GetCHMProject(RenamedFileNames)))
					ErrMessage+="Error generating CHM project source.\n";
				if(!this.StringToFile(_folder + "index.hhc", this.GetCHMProjectContents(RenamedFileNames, FileNames)))
					ErrMessage+="Error generating CHM contents.\n";
			}

			if(ErrMessage != String.Empty)throw new Exception(ErrMessage);
		}


		private bool FileExists(string FilePath)
		{
			return File.Exists(FilePath);
		}


		private bool DirectoryExists(string Path)
		{
			return Directory.Exists(Path);
		}


		// Intoarce lista cu fisierele din folder-ul Folder 
		// care respecta criteriile de cautare din SearchPattern
		private string[] GetFiles(string Folder, string SearchPattern)
		{
			ArrayList AllFiles;
			string[] Files;
			string[] SearchTokens;

			SearchTokens = SearchPattern.Split(new char[]{';', ','});
			AllFiles = new ArrayList();

			foreach(string SearchToken in SearchTokens)
			{
				try
				{
					Files = System.IO.Directory.GetFiles(Folder, SearchToken.Trim());
					AllFiles.AddRange(Files);
				}
				catch{}
			}
			
			return (string[])AllFiles.ToArray(typeof(System.String));
		}


		// Intoarce un array cu noile nume ale fiserelor 
		// ce trebuie sa se obtina dupa redenumire
		private string[] GetRenamedFiles(string[] Files, string BaseName)
		{
			int FilesCount = Files.Length;
			string[] re = new string[FilesCount];
			string FileBasePath = String.Empty;
			int MaxPad;

			if(FilesCount < 100)MaxPad = 2;
			else if(FilesCount < 1000)MaxPad = 3;
			else MaxPad = 4;

			if(Files.Length > 0)FileBasePath = Path.GetDirectoryName(Files[0]) + @"\";
			FileBasePath += BaseName;

			for(int i = 0; i < FilesCount; i++)re[i]= FileBasePath + PadNumber(i, '0', MaxPad) + Path.GetExtension(Files[i]);

			return re;
		}


		// Redenumeste fisierele specificate in OldNames folosind numele din NewNames
		private bool RenameFiles(string[] OldNames, string[] NewNames)
		{
			try
			{
				for(int i=0; i < OldNames.Length; i++)File.Move(OldNames[i], NewNames[i]);
				return true;
			}
			catch
			{
				return false;
			}
		}


		// Salveaza intr-un fisier string-ul s
		// Daca exista fisierul anterior va fi suprascris
		private bool StringToFile(string FilePath, string s)
		{
			try
			{
				if(File.Exists(FilePath))File.Delete(FilePath);
				FileStream oFs = new FileStream(FilePath, FileMode.CreateNew, FileAccess.ReadWrite);
				StreamWriter oWriter = new StreamWriter(oFs);
				oWriter.Write(s);
				oWriter.Flush();
				oWriter.Close();
				oFs.Close();
				return true;
			}
			catch
			{
				return false;
			}
		}


		// Intoarce textul HTML al paginii de index
		private string GetIndexPage(string[] FileNames, string[] FileNamesDescriptions, string PageTitle)
		{
			StringBuilder sb = new StringBuilder();

			sb.Append("<head>\n");
			if (PageTitle.Length > 0)sb.Append("<title>" + PageTitle + "</title>\n");
			sb.Append("<style>\n");
			sb.Append("  a {color:#000090; text-decoration:none;}\n");
			sb.Append("  a:hover {color:red; text-decoration:underline;}\n");
			sb.Append("  td { border-left: 1px solid black; border-right: 1px solid black; border-top: 1px solid black;}\n");
			sb.Append("  table {border-bottom: 1px solid black; font-family:Verdana; font-size:10px;}\n");
			sb.Append("</style>\n");
			sb.Append("</head>\n");

			sb.Append("<body bgcolor='#ffffff' style='font-family:Verdana; font-size:10px; color:#000090;'>\n");

			sb.Append("<script language=vbscript>\n");
			sb.Append(" sub coloreaza(a)\n");
			sb.Append("   if a=1 then\n");
			sb.Append("     cul=\"#f0f0f0\"\n");
			sb.Append("   else\n");
			sb.Append("     cul=\"#ffffff\"\n");
			sb.Append("   end if\n");
			sb.Append("   set obj=window.event.srcElement\n");
			sb.Append("   if obj.tagName=\"TD\" then\n");
			sb.Append("       obj.style.backgroundcolor=cul\n");
			sb.Append("   elseif obj.tagName=\"A\" then\n");
			sb.Append("       obj.parentElement.style.backgroundcolor=cul\n");
			sb.Append("   end if\n");
			sb.Append(" end sub\n");
			sb.Append("</script>\n");

			if (PageTitle.Length > 0)sb.Append("<center><h2>" + PageTitle + "</h2></center>\n");
			sb.Append("<table border=0 cellpadding=2 cellspacing=0 width=100% onmouseover=\"coloreaza(1)\" onmouseout=\"coloreaza(2)\">\n");

			for(int i=0; i<FileNames.Length; i++)
			{
				sb.Append("<tr><td valign=center><a href=\"");
				sb.Append(Path.GetFileName(FileNames[i]));
				sb.Append("\">");
				sb.Append((i + 1).ToString());
				sb.Append(". ");
				sb.Append(Path.GetFileNameWithoutExtension(FileNamesDescriptions[i]));
				sb.Append("</a></td></tr>\n");
			}

			sb.Append("</table>\n");
			sb.Append("<br><br><div align=right>Automatically generated by: HTMLIndexer<br><a href=\"http://itobserver.blogspot.com\">(c) VMASOFT</a></div>\n");
			sb.Append("</body>\n");
			
			return sb.ToString();
		}


		// Intoarce textul proiectului CHM
		private string GetCHMProject(string[] FileNames)
		{
			StringBuilder sb = new StringBuilder();

			sb.Append("[OPTIONS]\n");
			sb.Append("Compatibility=1.1 or later\n");
			sb.Append("Compiled file=index.chm\n");
			sb.Append("Contents file=index.hhc\n");
			sb.Append("Default topic=index.htm\n");
			sb.Append("Display compile progress=No\n\n");

			sb.Append("[FILES]\n");
			sb.Append("index.htm\n");
			for(int i=0; i<FileNames.Length; i++)
			{
				sb.Append(Path.GetFileName(FileNames[i]));
				sb.Append('\n');
			}

			return sb.ToString();
		}

		// Intoarce textul cuprinsului proiectului CHM
		private string GetCHMProjectContents(string[] FileNames, string[] FileNamesDescriptions)
		{
			StringBuilder sb = new StringBuilder();

			sb.Append("<!DOCTYPE HTML PUBLIC \"-//IETF//DTD HTML//EN\">\n");
			sb.Append("<HTML>\n");
			sb.Append("<HEAD>\n");
			sb.Append("<meta name=\"GENERATOR\" content=\"HTML Indexer (c) VMASOFT 2002\">\n");
			sb.Append("<!-- Sitemap 1.0 -->\n");
			sb.Append("</HEAD><BODY>\n");
			sb.Append("<OBJECT type=\"text/site properties\">\n");
			sb.Append("	<param name=\"ImageType\" value=\"Folder\">\n");
			sb.Append("</OBJECT>\n");
			sb.Append("<UL>\n");

			sb.Append("	<LI> <OBJECT type=\"text/sitemap\">\n");
			sb.Append("		<param name=\"Name\" value=\"Home\">\n");
			sb.Append("		<param name=\"Local\" value=\"index.htm\">\n");
			sb.Append("		</OBJECT>\n");

			for(int i=0; i<FileNames.Length; i++)
			{
				sb.Append("	<LI> <OBJECT type=\"text/sitemap\">\n");
				sb.Append("		<param name=\"Name\" value=\"");
				sb.Append(Path.GetFileNameWithoutExtension(FileNamesDescriptions[i]));
				sb.Append("\">\n");
				sb.Append("		<param name=\"Local\" value=\"");
				sb.Append(Path.GetFileName(FileNames[i]));
				sb.Append("\">\n");
				sb.Append("		</OBJECT>\n");
			}

			sb.Append("</UL>\n");
			sb.Append("</BODY></HTML>\n");

			return sb.ToString();
		}

		
		// Intoarce un string reprezentand un numar 
		// in format string de dimensiune fixa
		private string PadNumber(int Number, char PadChar, int MaxPad)
		{
			string ret = Number.ToString();
			string pads = String.Empty;

			for(int i=0; i < MaxPad;i++)pads+=PadChar.ToString();
			if(ret.Length < MaxPad) ret = pads.Substring(0,(MaxPad - ret.Length)) + ret;
			return ret;
		}


	}
}
