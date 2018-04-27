using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using System.Text;

public struct FileVersionStruct
{
	public static char SplitSign = '\t';
	public static char[] SplitSigns = new char[] { SplitSign };

	public static bool NewVersion(FileVersionStruct left, FileVersionStruct right)
	{
		if (left.MD5 == right.MD5)
		{
			return false;
		}
		if (left.Version >= right.Version)
		{
			return false;
		}
		//
		return true;
	}

	public bool ReadFrom(string value)
	{
		string[] fragmentList = value.Split(FileVersionStruct.SplitSigns, StringSplitOptions.RemoveEmptyEntries);
		if (fragmentList.Length == 4)
		{
			Name = fragmentList[0];
			MD5 = fragmentList[1];
			Version = Int32.Parse(fragmentList[2]);
			Size = Int32.Parse(fragmentList[3]);
			return true;
		}
		else
		{
			return false;
		}
	}

	public void WriteTo(StringBuilder strBuilder)
	{
		strBuilder.Append(Name);
		strBuilder.Append(FileVersionStruct.SplitSign);
		strBuilder.Append(MD5);
		strBuilder.Append(FileVersionStruct.SplitSign);
		strBuilder.Append(Version);
		strBuilder.Append(FileVersionStruct.SplitSign);
		strBuilder.Append(Size.ToString());
	}

	public string Name;
	public string MD5;
	public Int32 Version;
	public Int32 Size;
}

public static class IOAssisstant
{
	public static string DataVersionHeadFile = "DataVersionHead.ini";
	public static string DataVersionFullFile = "DataVersionFull.ini";
	public static string APKVersionFile = "APK/Version.ini";
	public static string APKFile = "APK/WarX.apk";
	public static string RunTimeLog = "RunTimeLog.log";

	public static string LocalVersion()
	{
		return LocalVersion("0.0.0");
	}

	public static string LocalVersion(string defaltValue)
	{
		if (File.Exists(ApplicationPlatform.PersistentDataPath + APKVersionFile) && File.Exists(ApplicationPlatform.PersistentDataPath + APKFile))
		{
			return File.ReadAllText(ApplicationPlatform.PersistentDataPath + APKVersionFile);
		}
		else
		{
			return defaltValue;
		}
	}

	static string GetFileName(string pathFile)
	{
		int splitIdx = pathFile.LastIndexOf('/');
		if (splitIdx == pathFile.Length - 1)
		{
			return string.Empty;
		}
		else if (splitIdx != -1)
		{
			return pathFile.Substring(splitIdx + 1);
		}
		else
		{
			return pathFile;
		}
	}

	public static string ReadFromPresistent(string pathFile, string defaultValue)
	{
		if (File.Exists(ApplicationPlatform.PersistentDataPath + pathFile))
		{
			return File.ReadAllText(ApplicationPlatform.PersistentDataPath + pathFile);
		}
		else
		{
			return defaultValue;
		}
	}

	public static void WriteToPresistent(string pathFile, Byte[] buffer, bool log)
	{
		string globalPathFile = ApplicationPlatform.PersistentDataPath + pathFile;
		CreateParentPath(globalPathFile);
		if (log)
		{
			Debug.Log("WriteToPresistent(" + pathFile + ")");
		}
		File.WriteAllBytes(globalPathFile, buffer);
	}

	public static void WriteToPresistent(string pathFile, string buffer, bool log)
	{
		string globalPathFile = ApplicationPlatform.PersistentDataPath + pathFile;
		CreateParentPath(globalPathFile);
		if (log)
		{
			Debug.Log("WriteToPresistent(" + pathFile + ")");
		}
		File.WriteAllText(globalPathFile, buffer);
	}

	public static void WriteAppendPresistent(string pathFile, string buffer, bool log)
	{
		WriteToPresistent(pathFile, ReadFromPresistent(pathFile, "") + "\n" + buffer, log);
	}

	public static void DelPresistentPath(string path)
	{
		string globalPath = ApplicationPlatform.PersistentDataPath + path;
		if (Directory.Exists(globalPath))
		{
			string[] fileList = Directory.GetFiles(globalPath, "*", SearchOption.AllDirectories);
			Debug.Log("DelPresistentPath(" + path + ").FileCount=" + fileList.Length);
			Directory.Delete(globalPath, true);
		}
		else
		{
			Debug.Log("DelPresistentPath(" + globalPath + ").Directory Not Exist");
		}
	}

	public static void DelPresistentFile(string path)
	{
		string globalPath = ApplicationPlatform.PersistentDataPath + path;
		if (File.Exists(globalPath))
		{
			Debug.Log("DelPresistentFile(" + path + ")");
			File.Delete(globalPath);
		}
		else
		{
			Debug.Log("DelPresistentFile(" + globalPath + ") Not Exist");
		}
	}

	public static void CreateParentPath(string path)
	{
		DirectoryInfo parentPath = Directory.GetParent(path);
		if (!Directory.Exists(parentPath.FullName))
		{
			Directory.CreateDirectory(parentPath.FullName);
		}
	}

	public static void SelectPresistentFiles(string path, string searchPattern, SearchOption searchOption, List<string> fileList)
	{
		string globalPath = ApplicationPlatform.PersistentDataPath + path;
		if (!Directory.Exists(globalPath))
		{
			return;
		}
		fileList.AddRange(Directory.GetFiles(globalPath, searchPattern, searchOption));
	}

	public static string FileMD5(byte[] buffer)
	{
		System.Security.Cryptography.MD5 md5 = new System.Security.Cryptography.MD5CryptoServiceProvider();
		byte[] retVal = md5.ComputeHash(buffer);
		//
		System.Text.StringBuilder sb = new System.Text.StringBuilder();
		for (int iter = 0; iter < retVal.Length; ++iter)
		{
			sb.Append(retVal[iter].ToString("x2"));
		}
		return sb.ToString();
	}

	public static void FileMD5(string path, string group, string searchPattern, SearchOption searchOption, Dictionary<string, FileVersionStruct> oldVersionList, Int32 newVersion, Dictionary<string, FileVersionStruct> newVersionList, ref Int32 newVersionCount)
	{
		string globalPath = path + group;
		if (!Directory.Exists(globalPath))
		{
			return;
		}
		FileVersionStruct fileVersion = new FileVersionStruct();
		string[] fileList = Directory.GetFiles(globalPath, searchPattern, searchOption);
		for (int iter = 0; iter < fileList.Length; ++iter)
		{
			string iterFile = fileList[iter];
			if (iterFile.Contains(".meta") || iterFile.Contains(".manifest") || iterFile.Contains(".svn"))
			{
				continue;
			}
			iterFile = iterFile.Replace('\\', '/');
			//
			Byte[] iterFileBuffer = File.ReadAllBytes(iterFile);
			string iterFileMD5 = FileMD5(iterFileBuffer);
			string iterFileName = iterFile.Substring(path.Length);
			if (oldVersionList.TryGetValue(iterFileName, out fileVersion) && fileVersion.MD5 == iterFileMD5)
			{

			}
			else
			{
				fileVersion.Name = iterFileName;
				fileVersion.MD5 = iterFileMD5;
				fileVersion.Version = newVersion;
				fileVersion.Size = iterFileBuffer.Length;
				++newVersionCount;
			}
			newVersionList.Add(iterFileName, fileVersion);
		}
	}

	public static void FileMD5(string path, string group, string searchPattern, SearchOption searchOption, Dictionary<string, FileVersionStruct> newVersionList)
	{
		string globalPath = path + group;
		if (!Directory.Exists(globalPath))
		{
			return;
		}
		FileVersionStruct fileVersion = new FileVersionStruct();
		string[] fileList = Directory.GetFiles(globalPath, searchPattern, searchOption);
		for (int iter = 0; iter < fileList.Length; ++iter)
		{
			string iterFile = fileList[iter];
			if (iterFile.Contains(".meta") || iterFile.Contains(".manifest") || iterFile.Contains(".svn"))
			{
				continue;
			}
			iterFile = iterFile.Replace('\\', '/');
			//
			Byte[] iterFileBuffer = File.ReadAllBytes(iterFile);
			string iterFileMD5 = FileMD5(iterFileBuffer);
			string iterFileName = iterFile.Substring(path.Length);
			fileVersion.Name = iterFileName;
			fileVersion.MD5 = iterFileMD5;
			fileVersion.Version = 0;
			fileVersion.Size = iterFileBuffer.Length;
			newVersionList.Add(iterFileName, fileVersion);
		}
	}

	public static string PrintVersionList(Int32 version, List<FileVersionStruct> list)
	{
		StringBuilder strBuilder = new StringBuilder();
		strBuilder.Append(version.ToString()).Append('\n');
		for (int iter = 0; iter < list.Count; ++iter)
		{
			list[iter].WriteTo(strBuilder);
			strBuilder.Append('\n');
		}
		return strBuilder.ToString();
	}

	public static string PrintVersionList(Int32 version, Dictionary<string, FileVersionStruct> list)
	{
		StringBuilder strBuilder = new StringBuilder();
		strBuilder.Append(version.ToString()).Append('\n');
		foreach (KeyValuePair<string, FileVersionStruct> iter in list)
		{
			iter.Value.WriteTo(strBuilder);
			strBuilder.Append('\n');
		}
		return strBuilder.ToString();
	}

	public static void ReadVersionList(string stream, out Int32 version, Dictionary<string, FileVersionStruct> list)
	{
		FileVersionStruct fileVersion = new FileVersionStruct();
		string[] lineList = stream.Split(new char[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);
		version = Int32.Parse(lineList[0]);
		for (int iter = 1; iter < lineList.Length; ++iter)
		{
			string iterLine = lineList[iter];
			if (fileVersion.ReadFrom(iterLine))
			{
				list.Add(fileVersion.Name, fileVersion);
			}
		}
	}

	public static void ReadVersionList(string stream, out Int32 version, List<FileVersionStruct> list)
	{
		FileVersionStruct fileVersion = new FileVersionStruct();
		string[] lineList = stream.Split(new char[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);
		version = Int32.Parse(lineList[0]);
		list.Capacity = lineList.Length;
		for (int iter = 1; iter < lineList.Length; ++iter)
		{
			string iterLine = lineList[iter];
			if (fileVersion.ReadFrom(iterLine))
			{
				list.Add(fileVersion);
			}
		}
	}

	public static void EraseNotExist(string path, Dictionary<string, FileVersionStruct> list)
	{
		List<string> removeList = new List<string>();
		foreach (KeyValuePair<string, FileVersionStruct> iter in list)
		{
			if (!File.Exists(path + iter.Key))
			{
				removeList.Add(iter.Key);
			}
		}
		for (int iter = 0; iter < removeList.Count; ++iter)
		{
			list.Remove(removeList[iter]);
		}
	}

}