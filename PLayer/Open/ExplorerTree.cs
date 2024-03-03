/* *************************************************
 * Programmer: Rajesh Lal(connectrajesh@hotmail.com)
 * Date: 06/25/06
 * Company Info: www.irajesh.com
 * See EULA.txt and Copyright.txt for additional information
 * **************************************************/

using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.IO;
using STM.Properties;

//For registry access
    //Used for .dll import

namespace STM.PLayer.Open
{
	/// <summary>
	/// Summary description for ExplorerTree.
	/// </summary>
	/// 
	[ToolboxBitmap(typeof(ExplorerTree), "tree.gif"),DefaultEvent("PathChanged")	]
	public class ExplorerTree : UserControl
    {
		private TreeView tvDirs;
		private IContainer components;

		private bool goflag = false ;



		private bool GoFlag
		{
			get
			{
				return goflag;
			}
			set
			{
				goflag=value;
			}
		}
		
		TreeNode node;
		TreeNode TreeNodeMyComputer ;


	    //ListViewItem comunalItem;
		
		//SHFILEINFO [] iconList = new SHFILEINFO[1];	//used icons
		public delegate void PathChangedEventHandler(object sender, EventArgs e);
		private PathChangedEventHandler PathChangedEvent;
		public event PathChangedEventHandler PathChanged
		{
			add
			{
				PathChangedEvent = (PathChangedEventHandler)Delegate.Combine(PathChangedEvent, value);
			}
			remove
			{
				PathChangedEvent = (PathChangedEventHandler)Delegate.Remove(PathChangedEvent, value);
			}
        }
        private ToolTip toolTip1;
        private ImageList imageList1;
		private string selectedPath ="home";
		

		
		[
		Category("Appearance"),
		Description("Selected Path of Image")
		]
		public string SelectedPath
		{
			get
			{
				return this.selectedPath;
			}
			set
			{
				this.selectedPath = value;
				this.Invalidate();
			}
		}

		
		public ExplorerTree()
		{
			// This call is required by the Windows.Forms Form Designer.
			InitializeComponent();
			// TODO: Add any initialization after the InitializeComponent call
            SetPath(Application.ExecutablePath);
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

		#region Component Designer generated code
		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ExplorerTree));
            this.tvDirs = new System.Windows.Forms.TreeView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.SuspendLayout();
            // 
            // tvDirs
            // 
            this.tvDirs.AllowDrop = true;
            resources.ApplyResources(this.tvDirs, "tvDirs");
            this.tvDirs.BackColor = System.Drawing.Color.White;
            this.tvDirs.ImageList = this.imageList1;
            this.tvDirs.Name = "tvDirs";
            this.tvDirs.ShowLines = false;
            this.tvDirs.ShowRootLines = false;
            this.tvDirs.AfterExpand += new System.Windows.Forms.TreeViewEventHandler(this.tvwMain_AfterExpand);
            this.tvDirs.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvwMain_AfterSelect);
            this.tvDirs.DoubleClick += new System.EventHandler(this.tvwMain_DoubleClick);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "");
            this.imageList1.Images.SetKeyName(1, "");
            this.imageList1.Images.SetKeyName(2, "");
            this.imageList1.Images.SetKeyName(3, "");
            this.imageList1.Images.SetKeyName(4, "");
            this.imageList1.Images.SetKeyName(5, "");
            this.imageList1.Images.SetKeyName(6, "");
            this.imageList1.Images.SetKeyName(7, "");
            this.imageList1.Images.SetKeyName(8, "");
            this.imageList1.Images.SetKeyName(9, "");
            this.imageList1.Images.SetKeyName(10, "");
            this.imageList1.Images.SetKeyName(11, "");
            this.imageList1.Images.SetKeyName(12, "");
            this.imageList1.Images.SetKeyName(13, "");
            this.imageList1.Images.SetKeyName(14, "");
            this.imageList1.Images.SetKeyName(15, "");
            this.imageList1.Images.SetKeyName(16, "");
            this.imageList1.Images.SetKeyName(17, "");
            this.imageList1.Images.SetKeyName(18, "");
            this.imageList1.Images.SetKeyName(19, "");
            this.imageList1.Images.SetKeyName(20, "");
            this.imageList1.Images.SetKeyName(21, "");
            this.imageList1.Images.SetKeyName(22, "");
            this.imageList1.Images.SetKeyName(23, "");
            this.imageList1.Images.SetKeyName(24, "");
            this.imageList1.Images.SetKeyName(25, "");
            this.imageList1.Images.SetKeyName(26, "");
            this.imageList1.Images.SetKeyName(27, "");
            this.imageList1.Images.SetKeyName(28, "");
            // 
            // ExplorerTree
            // 
            this.BackColor = System.Drawing.Color.Black;
            this.Controls.Add(this.tvDirs);
            this.Name = "ExplorerTree";
            resources.ApplyResources(this, "$this");
            this.Load += new System.EventHandler(this.ExplorerTree_Load);
            this.ResumeLayout(false);

		}
		#endregion

		private void ExplorerTree_Load(object sender, System.EventArgs e)
		{
            
			GetDirectory();
			
			if (Directory.Exists(selectedPath))
			{
				SetCurrentPath(selectedPath);
				
			}
			else
			{
				SetCurrentPath("home");
			}
			btnGo_Click(this,e); 

			
		}

	    public void GetDirectory()
		{
			tvDirs.Nodes.Clear();
            	        var nodemyC = new TreeNode {Tag = "My Computer", Text = "My Computer", ImageIndex = 12, SelectedImageIndex = 12};
            tvDirs.Nodes.Add(nodemyC);
			nodemyC.EnsureVisible(); 

			TreeNodeMyComputer = nodemyC ;
			var nodemNc = new TreeNode {Tag = "my Node", Text = "my Node", ImageIndex = 12, SelectedImageIndex = 12};
	        nodemyC.Nodes.Add(nodemNc);


            var nodeD = new TreeNode
            {
                Tag = Environment.GetFolderPath(Environment.SpecialFolder.Desktop),
                Text = "Desktop",
                ImageIndex = 10,
                SelectedImageIndex = 10
            };


            tvDirs.Nodes.Add(nodeD);
            ExploreTreeNode(nodeD);


        }

		private void ExploreTreeNode(TreeNode n)
		{
			Cursor.Current = Cursors.WaitCursor;

			try
			{
				//get dirs
				FillFilesandDirs(n);
				
				//get dirs one more level deep in current dir so user can see there is
				//more dirs underneath current dir
				foreach(TreeNode treeNode in n.Nodes)
				{
					if (String.Compare(n.Text,"Desktop")==0) 
					{
						if(String.Compare(treeNode.Text ,"My Computer")==0)
						{}
						else
						{
							FillFilesandDirs(treeNode);
						}
					}
					else
					{
						FillFilesandDirs(treeNode);
					}
				}
			}
			
			catch
			{}
			finally
			{
				Cursor.Current = Cursors.Default;
			}
		}

		private void GetDirectories(TreeNode parentNode)
		{
		    string[] dirList = Directory.GetDirectories(parentNode.Tag.ToString());
			Array.Sort(dirList);

			//check if dir already exists in case click same dir twice
			if (dirList.Length == parentNode.Nodes.Count)
				return;
			//add each dir in selected dir
			foreach (string t in dirList)
			{
			    node = new TreeNode {Tag = t, Text = t.Substring(t.LastIndexOf(@"\") + 1), ImageIndex = 1};
			    parentNode.Nodes.Add(node);
			}

			
		}

		
		private void FillFilesandDirs(TreeNode comunalNode)
		{
			try 
			{
				GetDirectories(comunalNode);
			}
			catch
			{
				return;
			}
		}

        private void SetPath(string path)
        {
            SelectedPath = path;
            if (PathChangedEvent != null)
                PathChangedEvent(this, EventArgs.Empty);
        }

	    public void SetCurrentPath(string strPath)
		{
			SelectedPath = strPath;
			
			if (String.Compare(strPath,"home")==0)
			{
                SetPath(Application.StartupPath);
			}
			else
			{
				var inf = new DirectoryInfo(strPath);
                if (inf.Exists)
                {
                    SetPath(strPath);

                }
                else
                    SetPath(Application.StartupPath);
			}
			

		}

		private void tvwMain_AfterExpand(object sender, System.Windows.Forms.TreeViewEventArgs e)
		{
			string [] drives = Environment.GetLogicalDrives();

			Cursor.Current = Cursors.WaitCursor;   
			TreeNode n;
			TreeNode nodemyC;
			TreeNode nodeDrive;
			nodemyC = e.Node;   

			n = e.Node;
			
			if (n.Text.IndexOf(":",1)>0)   
			{
				ExploreTreeNode(n);
			}
			else
			{//(String.Compare(n.Text ,"My Documents")==0) || (String.Compare(n.Text,"Desktop")==0) || 

				if ((String.Compare(n.Text,"Desktop" )==0)||(String.Compare(n.Text ,"My Computer")==0) )
				{
					if((String.Compare(n.Text ,"My Computer")==0)&&(nodemyC.GetNodeCount(true) <2))
						///////////
						//add each drive and files and dirs
					{
						nodemyC.FirstNode.Remove();
 
					foreach(string drive in drives)
					{
				
						nodeDrive = new TreeNode();
						nodeDrive.Tag = drive;
					
						nodeDrive.Text = drive ;
					
						//Determine icon to display by drive
						switch(Win32.GetDriveType(drive))
						{
							case 2:
								nodeDrive.ImageIndex = 17;
								nodeDrive.SelectedImageIndex  = 17;
								break;
							case 3:
								nodeDrive.ImageIndex = 0;
								nodeDrive.SelectedImageIndex  = 0;
								break;
							case 4:
								nodeDrive.ImageIndex = 8;
								nodeDrive.SelectedImageIndex = 8;
								break;
							case 5:
								nodeDrive.ImageIndex = 7;
								nodeDrive.SelectedImageIndex = 7;
								break;
							default:
								nodeDrive.ImageIndex = 0;
								nodeDrive.SelectedImageIndex = 0;
								break;
						}
					
						nodemyC.Nodes.Add(nodeDrive);
						nodeDrive.EnsureVisible();
						tvDirs.Refresh(); 
						try
						{
							//add dirs under drive
							if (Directory.Exists (drive))
							{
								foreach(string dir in Directory.GetDirectories(drive))
								{
									node = new TreeNode();
									node.Tag = dir;
									node.Text = dir.Substring(dir.LastIndexOf(@"\") + 1);
									node.ImageIndex = 1;
									nodeDrive.Nodes.Add(node);
								}
							}
				
						}
						catch(Exception)	//error just add blank dir
						{
						}
						nodemyC.Expand(); 
						}
					
					}				
				}
				else
				{	
					ExploreTreeNode(n); 
				}
			}
			Cursor.Current = Cursors.Default;
		}

		private void tvwMain_AfterSelect(object sender, System.Windows.Forms.TreeViewEventArgs e)
		{
			TreeNode n;
			n =  e.Node ;
				
			try
			{
				if ((String.Compare(n.Text ,"My Computer")==0) ||(String.Compare(n.Text ,"My Network Places")==0))
				{
				}
				else
				{
                    SetPath(n.Tag.ToString()); 
				}
			}
			catch{}
		}

		private void tvwMain_DoubleClick(object sender, System.EventArgs e)
		{
            try
            {
                TreeNode n;
                n = tvDirs.SelectedNode;

                if (!tvDirs.SelectedNode.IsExpanded)
                    tvDirs.SelectedNode.Collapse();
                else
                {
                    ExploreTreeNode(n);
                }
            }
            catch
            {
            }
		}

		private void ExploreMyComputer()
		{
			
			string [] drives = Environment.GetLogicalDrives();
            
			string dir2 ="";

			Cursor.Current = Cursors.WaitCursor;   
			TreeNode nodeDrive;

			if(TreeNodeMyComputer.GetNodeCount(true) <2)
			{
				TreeNodeMyComputer.FirstNode.Remove();
 
				foreach(string drive in drives)
				{
					nodeDrive = new TreeNode();
					nodeDrive.Tag = drive;
				
					nodeDrive.Text = drive ;
					
					switch(Win32.GetDriveType(drive))
					{
						case 2:
							nodeDrive.ImageIndex = 17;
							nodeDrive.SelectedImageIndex  = 17;
                            continue;
					    case 3:
							nodeDrive.ImageIndex = 0;
							nodeDrive.SelectedImageIndex  = 0;
							break;
						case 4:
							nodeDrive.ImageIndex = 8;
							nodeDrive.SelectedImageIndex = 8;
							break;
						case 5:
							nodeDrive.ImageIndex = 7;
							nodeDrive.SelectedImageIndex = 7;
							break;
						default:
							nodeDrive.ImageIndex = 0;
							nodeDrive.SelectedImageIndex = 0;
							break;
					}
						
					TreeNodeMyComputer.Nodes.Add(nodeDrive);
					try
					{
						//add dirs under drive
						if (Directory.Exists (drive))
						{
							foreach(string dir in Directory.GetDirectories(drive))
							{
								dir2 = dir;
								node = new TreeNode();
								node.Tag = dir;
								node.Text = dir.Substring(dir.LastIndexOf(@"\") + 1);
								node.ImageIndex = 1;
								nodeDrive.Nodes.Add(node);
							}
						}
					
					
					}
					catch(Exception ex)	//error just add blank dir
					{
						 MessageBox.Show (Resources.ExplorerTree_ExploreMyComputer_Error + ex.Message );
					}
				}
			}
			
			TreeNodeMyComputer.Expand();
		}

		public void btnGo_Click(object sender, System.EventArgs e)
		{
			Cursor.Current = Cursors.WaitCursor;   
			try
			{
				ExploreMyComputer(); 
				string myString ="";
				int h=1;
				//if (String.Compare(myString.Substring(myString.Length-1,1),@"\")==0)
				//{
				//	myString = myString.Substring(0,myString.Length-1);
				//	txtPath.Text = myString	;

				//}
				TreeNode tn = TreeNodeMyComputer  ;

			StartAgain:
			
				do
				{
					//Strom = (tvwMain.GetNodeCount(true)).ToString() ;	
					
					foreach(TreeNode t in tn.Nodes) 
					{
						string mypath =  t.Tag.ToString()  ;
						//mypath =  mypath.Replace("Desktop\\","") ;
						//mypath =  mypath.Replace("My Computer\\","") ;
						//mypath =  mypath.Replace(@"\\",@"\") ;

						//mypath =  mypath.Replace("My Documents\\",Environment.GetFolderPath(Environment.SpecialFolder.Personal) + "\\") ;
						mypath=mypath.ToLower();
						string mypathf =mypath;
						if (!mypath.EndsWith(@"\"))  
						{
						if (myString.Length > mypathf.Length )	mypathf  =mypath + @"\";
						}

						if (myString.StartsWith(mypathf))
						{
							t.TreeView.Focus(); 
							t.TreeView.SelectedNode =  t; 
							t.EnsureVisible(); 
							t.Expand();
							if (t.Nodes.Count>=1)
							{
								t.Expand();
								tn = t;
							}
							else
							{
								if (String.Compare (myString,mypath)==0)
								{
									h = -1;
									break;
								}
								else
								{
									continue;  
								}
							}

							if (mypathf.StartsWith(myString))
							{
								h = -1;
								break;
							}
							else
							{
								goto  StartAgain;
								//return;
							}
						}
					}
				
					try
					{
						tn = tn.NextNode;
					}
					catch(Exception)
					{}
 
				}while(h>=0);

			}
			catch
			{
			}
			finally
			{
				Cursor.Current = Cursors.Default;
			}
		}
		}
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	/// 
	
									
	[StructLayout(LayoutKind.Sequential, Pack=1)]
	public struct SHQUERYRBINFO
	{
		public uint cbSize;     
		public ulong i64Size;
		public ulong i64NumItems;
	};
								
	//Shell functions
	public class Win32
	{
		public const uint SHGFI_ICON = 0x100;
		//public const uint SHGFI_LARGEICON = 0x0;    // 'Large icon
		public const uint SHGFI_SMALLICON = 0x1;    // 'Small icon
								
		[DllImport("shell32.dll")]
		public static extern IntPtr SHGetFileInfo(
			string pszPath,
			uint dwFileAttributes,
			ref SHFILEINFO psfi,
			uint cbSizeFileInfo,
			uint uFlags);
		
		[DllImport("kernel32")]
		public static extern uint GetDriveType(
			string lpRootPathName);

		[DllImport("shell32.dll")]
		public static extern bool SHGetDiskFreeSpaceEx(          
			string pszVolume,
			ref ulong pqwFreeCaller,
			ref ulong pqwTot,
			ref ulong pqwFree);

		[DllImport("shell32.Dll")]
		public static extern int SHQueryRecycleBin(          
			string pszRootPath,
			ref SHQUERYRBINFO pSHQueryRBInfo);

		[StructLayout(LayoutKind.Sequential)]
			public struct SHFILEINFO 
		{
			public IntPtr hIcon;
			public IntPtr iIcon;
			public uint dwAttributes;
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
			public string szDisplayName;
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 80)]
			public string szTypeName;
		};

	

		[StructLayout( LayoutKind.Sequential )]
		public class BITMAPINFO
		{
			public Int32 biSize;
			public Int32 biWidth;
			public Int32 biHeight;
			public Int16 biPlanes;
			public Int16 biBitCount;
			public Int32 biCompression;
			public Int32 biSizeImage;
			public Int32 biXPelsPerMeter;
			public Int32 biYPelsPerMeter;
			public Int32 biClrUsed;
			public Int32 biClrImportant;
			public Int32 colors;
		};
		[DllImport("comctl32.dll")]
		public static extern bool ImageList_Add( IntPtr hImageList, IntPtr hBitmap, IntPtr hMask );
		[DllImport("kernel32.dll")]
		private static extern bool RtlMoveMemory( IntPtr dest, IntPtr source, int dwcount );
		[DllImport("shell32.dll")]
		public static extern IntPtr DestroyIcon( IntPtr hIcon );
		[DllImport("gdi32.dll")]
		public static extern IntPtr CreateDIBSection( IntPtr hdc, [In, MarshalAs(UnmanagedType.LPStruct)]BITMAPINFO pbmi, uint iUsage, out IntPtr ppvBits, IntPtr hSection, uint dwOffset );

		
	}

	public enum ResourceScope
	{
		RESOURCE_CONNECTED = 1,
		RESOURCE_GLOBALNET,
		RESOURCE_REMEMBERED,
		RESOURCE_RECENT,
		RESOURCE_CONTEXT
	};

	public enum ResourceType
	{
		RESOURCETYPE_ANY,
		RESOURCETYPE_DISK,
		RESOURCETYPE_PRINT,
		RESOURCETYPE_RESERVED
	};

	public enum ResourceUsage
	{
		RESOURCEUSAGE_CONNECTABLE   = 0x00000001,
		RESOURCEUSAGE_CONTAINER     = 0x00000002,
		RESOURCEUSAGE_NOLOCALDEVICE = 0x00000004,
		RESOURCEUSAGE_SIBLING       = 0x00000008,
		RESOURCEUSAGE_ATTACHED      = 0x00000010,
		RESOURCEUSAGE_ALL           = (RESOURCEUSAGE_CONNECTABLE | RESOURCEUSAGE_CONTAINER | RESOURCEUSAGE_ATTACHED),
	};
	
	public enum ResourceDisplayType
	{
		RESOURCEDISPLAYTYPE_GENERIC,
		RESOURCEDISPLAYTYPE_DOMAIN,
		RESOURCEDISPLAYTYPE_SERVER,
		RESOURCEDISPLAYTYPE_SHARE,
		RESOURCEDISPLAYTYPE_FILE,
		RESOURCEDISPLAYTYPE_GROUP,
		RESOURCEDISPLAYTYPE_NETWORK,
		RESOURCEDISPLAYTYPE_ROOT,
		RESOURCEDISPLAYTYPE_SHAREADMIN,
		RESOURCEDISPLAYTYPE_DIRECTORY,
		RESOURCEDISPLAYTYPE_TREE,
		RESOURCEDISPLAYTYPE_NDSCONTAINER
	};

	public class ServerEnum : IEnumerable
	{
		enum ErrorCodes
		{
			NO_ERROR = 0,
			ERROR_NO_MORE_ITEMS = 259
		};

		[StructLayout(LayoutKind.Sequential)]
			private class NETRESOURCE 
		{
			public ResourceScope       dwScope = 0;
			public ResourceType        dwType = 0;
			public ResourceDisplayType dwDisplayType = 0;
			public ResourceUsage       dwUsage = 0;
			public string              lpLocalName = null;
			public string              lpRemoteName = null;
			public string              lpComment = null;
			public string              lpProvider = null;
		};
	

		private ArrayList aData = new ArrayList();
		

		public int Count
		{
			get { return aData.Count; }
		}
	
		[DllImport("Mpr.dll", EntryPoint="WNetOpenEnumA", CallingConvention=CallingConvention.Winapi)]
		private static extern ErrorCodes WNetOpenEnum(ResourceScope dwScope, ResourceType dwType, ResourceUsage dwUsage, NETRESOURCE p, out IntPtr lphEnum);

		[DllImport("Mpr.dll", EntryPoint="WNetCloseEnum", CallingConvention=CallingConvention.Winapi)]
		private static extern ErrorCodes WNetCloseEnum(IntPtr hEnum);

		[DllImport("Mpr.dll", EntryPoint="WNetEnumResourceA", CallingConvention=CallingConvention.Winapi)]
		private static extern ErrorCodes WNetEnumResource(IntPtr hEnum, ref uint lpcCount, IntPtr buffer, ref uint lpBufferSize);

	
		private	void EnumerateServers(NETRESOURCE pRsrc, ResourceScope scope, ResourceType type, ResourceUsage usage, ResourceDisplayType displayType,string kPath)
		{
		uint		bufferSize = 16384;
		IntPtr		buffer	= Marshal.AllocHGlobal((int) bufferSize);
		IntPtr		handle = IntPtr.Zero;
		ErrorCodes	result;
		uint		cEntries = 1;
		bool serverenum = false;

		result = WNetOpenEnum(scope, type, usage, pRsrc, out handle);

		if (result == ErrorCodes.NO_ERROR)
		{
			do
			{
				result = WNetEnumResource(handle, ref cEntries,	buffer,	ref	bufferSize);

				if ((result == ErrorCodes.NO_ERROR))
				{
					Marshal.PtrToStructure(buffer, pRsrc);

					if(String.Compare(kPath,"")==0)
					{
						if ((pRsrc.dwDisplayType	== displayType) || (pRsrc.dwDisplayType	== ResourceDisplayType.RESOURCEDISPLAYTYPE_DOMAIN))
							aData.Add(pRsrc.lpRemoteName + "|" + pRsrc.dwDisplayType );

						if ((pRsrc.dwUsage & ResourceUsage.RESOURCEUSAGE_CONTAINER )== ResourceUsage.RESOURCEUSAGE_CONTAINER )
						{	
							if ((pRsrc.dwDisplayType	== displayType))
							{
								EnumerateServers(pRsrc,	scope, type, usage,	displayType,kPath);
								
							}
								
						}
					}
					else
					{
						if (pRsrc.dwDisplayType	== displayType)
						{
							aData.Add(pRsrc.lpRemoteName);
							EnumerateServers(pRsrc,	scope, type, usage,	displayType,kPath);
							//return;
							serverenum = true;
						}
						if (!serverenum)
						{
							if (pRsrc.dwDisplayType	== ResourceDisplayType.RESOURCEDISPLAYTYPE_SHARE)
							{
								aData.Add(pRsrc.lpRemoteName + "-share");
							}
						}
						else
						{
							serverenum =false;
						}
						if((kPath.IndexOf(pRsrc.lpRemoteName)>=0)||(String.Compare(pRsrc.lpRemoteName,"Microsoft Windows Network")==0))
						{
							EnumerateServers(pRsrc,	scope, type, usage,	displayType,kPath);
							//return;
							
						}
						//}
					}
				
				}
				else if	(result	!= ErrorCodes.ERROR_NO_MORE_ITEMS)
					break;
			} while	(result	!= ErrorCodes.ERROR_NO_MORE_ITEMS);

			WNetCloseEnum(handle);
		}

		Marshal.FreeHGlobal((IntPtr) buffer);
		}

		public ServerEnum(ResourceScope scope, ResourceType type, ResourceUsage usage, ResourceDisplayType displayType,string kPath)
		{
			
			NETRESOURCE netRoot = new NETRESOURCE();
			EnumerateServers(netRoot, scope, type, usage, displayType,kPath);
		
		}
		#region IEnumerable Members

		public IEnumerator GetEnumerator()
		{
			return aData.GetEnumerator();
		}

		#endregion
	}
}
