using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using System.IO;
using System.Xml.Serialization;
using STM.BLayer.StmTest;
using System.Windows.Forms;

namespace STM.PLayer.Open
{
    public class RecentTests
    {
        public List<string> Tests;

        public void SaveRecentTests(string path)
        {
            StreamWriter xmlWriter = null;
            try
            {
                xmlWriter = new StreamWriter(path) {AutoFlush = true};
                var xmlSerializer = new XmlSerializer(typeof(RecentTests));
                xmlSerializer.Serialize(xmlWriter, this);
            }
            catch
            {
            }
            finally
            {
                if (xmlWriter != null)
                    xmlWriter.Close();
            }
        }
        public void LoadRecentTests(string path)
        {
            StreamReader xmlReader = null;
            try
            {
                xmlReader = new StreamReader(path);

                var xmlSerializer = new XmlSerializer(typeof(RecentTests));
                var defination = (RecentTests)xmlSerializer.Deserialize(xmlReader);
                xmlReader.Close();

                Tests = defination.Tests.ToList();
            }
            catch
            {
                Tests = new List<string>();
            }
            finally
            {
                if (xmlReader != null)
                    xmlReader.Close();
            }
        }
        
    }

    public class FileHistory
    {
        private readonly RecentTests recentTests;
        const string HistoryFile = "RecentTest.xml";
        const string GroupsFile = "Groups.xml";
        XDocument xmlTestGroup;
        readonly string pathHistory;
        readonly string pathGroup;

        public FileHistory()
        {
            recentTests = new RecentTests();
            pathHistory = Application.StartupPath + string.Format("\\Recent\\{0}", HistoryFile);
            pathGroup = Application.StartupPath + string.Format("\\Recent\\{0}", GroupsFile);
            recentTests.LoadRecentTests(pathHistory);
        }

        public void AddNewTestToHistory(string fileName)
        {
            var items = recentTests.Tests.ToList();
            if (items.Contains(fileName)) 
                items.Remove(fileName);
            items.Insert(0, fileName);
            if (items.Count > Options.MaxRecentFiles)
                items.RemoveRange(Options.MaxRecentFiles - 1, items.Count - Options.MaxRecentFiles);
            recentTests.Tests = items.ToList();
            recentTests.SaveRecentTests(pathHistory);
        }

        public void AddOpenedTestToHistory(List<string> fileNames)
        {
            recentTests.LoadRecentTests(pathHistory);
            var items = recentTests.Tests.ToList();
            foreach (string fileName in fileNames)
            {
                if (items.Contains(fileName))
                    items.Remove(fileName);
                items.Insert(0, fileName);
            }

            if (items.Count > Options.MaxRecentFiles)
                items.RemoveRange(Options.MaxRecentFiles - 1, items.Count - Options.MaxRecentFiles);
            recentTests.Tests = items.ToList();
            recentTests.SaveRecentTests(pathHistory);
        }

        public void CreateGroup(string groupName, string[] tests)
        {
            CheckGroupFile();

            var groups = xmlTestGroup.Descendants("groups");

            try
            {
                var count = groups.Descendants("Test").Count(p => p.Attribute("gName").Value.Equals(groupName));
                if (count > 0)
                {
                    foreach (var item in tests)
                        AddToGroup(groupName, item);
                    return;
                }
            }
            catch
            {
            }
            
            groups.First().Add(tests.Select(p => new XElement("Test", new XAttribute("gName", groupName) , new XAttribute("path", p))));
            xmlTestGroup.Save(pathGroup);
        }

        public void AddToGroup(string groupName, string test)
        {
            CheckGroupFile();
            var groups = xmlTestGroup.Descendants("groups");
            try
            {
                groups.First().Add(new XElement("Test", new XAttribute("gName", groupName), new XAttribute("path", test)));
            }
            catch
            {
                CreateGroup(groupName, new[] { test });
            }
            xmlTestGroup.Save(pathGroup);
        }

        public List<string> GetGroupTest(string gName)
        {
            try
            {
                var groupTests =
                    xmlTestGroup.Descendants("groups").Descendants("Test").Where(
                        p => p.Attribute("gName").Value.Equals(gName)).Select(p => p.Attribute("path").Value).ToList();
                return groupTests;
            }
            catch(Exception exception)
            {
                exception.ToString();
            }
            return null;
        }


        public List<string> GetRecentTests()
        {
            if (File.Exists(pathHistory))
                try
                {
                    recentTests.LoadRecentTests(pathHistory);
                    return recentTests.Tests.ToList();
                }
                catch
                {
                }

            return new List<string>();
        }

        public string[] GetGroups()
        {
            CheckGroupFile();
            try
            {
                var groups = xmlTestGroup.Descendants("groups").Descendants("Test").Select(p => p.Attribute("gName").Value).Distinct().ToArray();
                if (groups != null)
                    return groups;
            }
            catch
            {
            }
            return null;
        }

     
        private void CheckGroupFile()
        {
            if (!File.Exists(pathGroup))
                xmlTestGroup = CreateGroupFile(pathGroup);
            else
                xmlTestGroup = XDocument.Load(pathGroup, LoadOptions.None);
        }

        private static XDocument CreateGroupFile(string path)
        {
            var xml = new XDocument(new XElement("root"))
            {
                Declaration = new XDeclaration("1.0", "utf-8", "true")
            };
            xml.Descendants("root").First().Add(new XElement("groups"));
            xml.Save(path);
            return xml;
        }

        public void DeleteGroup(string groupName)
        {
            var groups = xmlTestGroup.Descendants("groups");
            try
            {
                var deleteList = groups.Descendants("Test").Where(xElement => xElement.Attribute("gName").Value.Equals(groupName));
                deleteList.Remove();
            }
            catch(Exception exception)
            {
                exception.ToString();
            }
            xmlTestGroup.Save(pathGroup);
        }

        internal void Remove(string path)
        {
            recentTests.LoadRecentTests(pathHistory);
            var items = recentTests.Tests.ToList();
            if (items.Contains(path))
                items.Remove(path);

            recentTests.Tests = items.ToList();
            recentTests.SaveRecentTests(pathHistory);
        }
    }
}
