using System;

class TarFileArchiver
{
	static void Main(string[] args)
	{
		string sourceDiretory = @"D:\BAFL_Provided_TatFiles";
		string archiveDirectory = @"D:\ArchiveFiles\UnTarFiles";

		try
        {
            if (!Directory.Exists(archiveDirectory))
            {
                Directory.CreateDirectory(archiveDirectory);
            }

            string[] searchTarFiles = Directory.GetFiles(sourceDiretory, "*.tar", SearchOption.AllDirectories);
            //Console.WriteLine(searchTarFiles.Length);

            foreach (string tarFile in searchTarFiles)
            {
                string[] parts = tarFile.Split(Path.DirectorySeparatorChar);
                string fetchYear_Name = parts[Array.IndexOf(parts, new DirectoryInfo(sourceDiretory).Name) + 3];
                //Console.WriteLine($"Fetched Year: {fetchYear_Name}");

                string yearFolder = Path.Combine(archiveDirectory, fetchYear_Name);
                if (!Directory.Exists(yearFolder))
                {
                    Directory.CreateDirectory(yearFolder);
                }

                string fileName = Path.GetFileName(tarFile);
                string destinationFolder = Path.Combine(archiveDirectory, fetchYear_Name, fileName);
                //Console.WriteLine(destinationFolder);

                File.Copy(tarFile, destinationFolder, true);
                Console.WriteLine($"Copied {tarFile} to {destinationFolder}");
            }

            Console.WriteLine("All .tar files copied to Archive Folder Successfully!");
        }
        catch (Exception exp)
		{
			Console.WriteLine(exp);
		}
    }
}
