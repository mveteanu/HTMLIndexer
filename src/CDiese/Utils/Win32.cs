using System;
using System.Runtime.InteropServices;

namespace CDiese.Utils
{
	/// <summary>
	/// Wrapper for Win32 API calls
	/// </summary>
	public class Win32
	{
		public enum DriveType
		{
			Unknown = 0,
			NoRootDirectory = 1,
			Removable = 2,
			Fixed = 3,
			Remote = 4,
			CdRom = 5,
			RamDisk = 6
		}

		/// <summary>
		/// Returns the name of a logical drive
		/// </summary>
		/// <param name="driveLetter"></param>
		/// <returns>the name of the drive in the format "a:\"</returns>
		public static String GetVolumeName(String driveLetter) 
		{
			const 	int namelen = 1025;
			int		serial, maxCompLen, flags;
			byte[]	namebuf = new byte[namelen];
			byte[]	sysname = new byte[namelen];
			Win32GetVolumeInformation(driveLetter, namebuf, namelen, out serial, out maxCompLen, out flags, sysname, namelen);
			String	name = System.Text.Encoding.ASCII.GetString(namebuf);
			name = name.Substring(0, name.IndexOf('\0'));
			return name;
		}

		/// <summary>
		/// Returns the type of the logical drive
		/// </summary>
		/// <param name="driveLetter"></param>
		/// <returns>the name of the drive in the format "a:\"</returns>
		public static DriveType GetDriveType(String driveLetter) 
		{
			return (DriveType) Win32GetDriveType(driveLetter);
		}
		#region Win32 imports
		[DllImport("KERNEL32.DLL", EntryPoint="GetDriveType")]
		private static extern uint Win32GetDriveType(String driveLetter);

		[DllImport("kernel32.dll", EntryPoint="GetVolumeInformation")]
		private static extern bool Win32GetVolumeInformation(String root, byte[] name, int nameLen, out int serial, out int maxCompLen, out int flags, byte[] fileSysName, int fileSysNameLen);
		#endregion
	}
}
