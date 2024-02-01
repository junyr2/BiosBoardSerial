// See https://aka.ms/new-console-template for more information

using System.Management;
using System.IO;


StreamWriter sw = new StreamWriter("ctrlgenb.txt");


ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT Product, SerialNumber FROM Win32_BaseBoard");

ManagementObjectCollection information = searcher.Get();
foreach (ManagementObject obj in information)
{
    foreach (PropertyData data in obj.Properties)
        // Console.WriteLine("{0} = {1}", data.Name, data.Value);
        sw.WriteLine("{0} = {1}", data.Name, data.Value);
}

searcher = new ManagementObjectSearcher("SELECT  SerialNumber FROM Win32_Bios");

information = searcher.Get();
foreach (ManagementObject obj in information)
{
    foreach (PropertyData data in obj.Properties)
        //    Console.WriteLine("{0} = {1}", data.Name, data.Value);
        //Console.WriteLine();
        sw.WriteLine("{0} = {1}", data.Name, data.Value);
}

searcher.Dispose();

sw.Flush();
sw.Close();


