using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;


public class MyXmlReader
{
    public static string ReadDataSource(string xmlFilePath)
    {
        string dataSource = null;

        try
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(xmlFilePath);

            XmlNodeList dataSourceNodes = xmlDoc.SelectNodes("/Configuration/connectionString/DataSource");

            if (dataSourceNodes != null && dataSourceNodes.Count > 0)
            {
                dataSource = dataSourceNodes[0].InnerText;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error reading XML: " + ex.Message);
        }

        return dataSource;
    }

    public static int ReadPort(string xmlFilePath)
    {
        int port = 0;

        try
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(xmlFilePath);

            XmlNodeList portNodes = xmlDoc.SelectNodes("/Configuration/connectionString/Port");

            if (portNodes != null && portNodes.Count > 0)
            {
                port = int.Parse(portNodes[0].InnerText);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error reading XML: " + ex.Message);
        }

        return port;
    }

    public static string ReadInitialCatalog(string xmlFilePath)
    {
        string initialCatalog = null;

        try
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(xmlFilePath);

            XmlNodeList initialCatalogNodes = xmlDoc.SelectNodes("/Configuration/connectionString/InitialCatalog");

            if (initialCatalogNodes != null && initialCatalogNodes.Count > 0)
            {
                initialCatalog = initialCatalogNodes[0].InnerText;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error reading XML: " + ex.Message);
        }

        return initialCatalog;
    }

    public static string ReadUserID(string xmlFilePath)
    {
        string userID = null;

        try
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(xmlFilePath);

            XmlNodeList userIDNodes = xmlDoc.SelectNodes("/Configuration/connectionString/UserID");

            if (userIDNodes != null && userIDNodes.Count > 0)
            {
                userID = userIDNodes[0].InnerText;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error reading XML: " + ex.Message);
        }

        return userID;
    }

    public static string ReadPassword(string xmlFilePath)
    {
        string password = null;

        try
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(xmlFilePath);

            XmlNodeList passwordNodes = xmlDoc.SelectNodes("/Configuration/connectionString/Password");

            if (passwordNodes != null && passwordNodes.Count > 0)
            {
                password = passwordNodes[0].InnerText;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error reading XML: " + ex.Message);
        }

        return password;
    }

    public static string GetAddressByComputerName(string xmlFilePath, string computerName)
    {
        string address = null;

        try
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(xmlFilePath);

            // Use XPath to find the CMachine element with the matching ComputerName
            XmlNode machineNode = xmlDoc.SelectSingleNode($"/Configuration/Machines/CMachine[ComputerName='{computerName}']");


            if (machineNode != null)
            {
                // Get the Address element's value
                XmlNode addressNode = machineNode.SelectSingleNode("Address");
                if (addressNode != null)
                {
                    return addressNode.InnerText; // Return the address
                }
                else
                {
                    string msg = $"Address not found for {computerName}.";
                    Console.WriteLine(msg);
                    MessageBox.Show(msg);
                }
            }
            else
            {
                Console.WriteLine($"Computer name {computerName} not found.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error reading XML: " + ex.Message);
        }

        return null; // Return null if not found or an error occurs
    }

    public static string GetMachineNoByComputerName(string xmlFilePath, string computerName)
    {
        string machineNo = null;

        try
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(xmlFilePath);

            // Use XPath to find the CMachine element with the matching ComputerName
            XmlNode machineNode = xmlDoc.SelectSingleNode($"/Configuration/Machines/CMachine[ComputerName='{computerName}']");


            if (machineNode != null)
            {
                // Get the machineNo element's value
                XmlNode machineNoNode = machineNode.SelectSingleNode("Name");
                if (machineNoNode != null)
                {
                    return machineNoNode.InnerText;
                }
                else
                {
                    string msg = $"MachineNo not found for {computerName}.";
                    Console.WriteLine(msg);
                    MessageBox.Show(msg);
                }
            }
            else
            {
                Console.WriteLine($"Computer name {computerName} not found.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error reading XML: " + ex.Message);
        }
        return null; // Return null if not found or an error occurs
    }
    
}
