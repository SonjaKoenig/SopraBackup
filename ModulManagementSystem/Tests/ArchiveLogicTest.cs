using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using System.Linq;
using ModulManagementSystem.Models;
using ModulManagementSystem.Core.DBOperations;
using System.Windows.Forms;

namespace Tests
{
    [TestClass()]
    public class ArchiveLogicTest
    {
        ArchiveLogic logic = new ArchiveLogic();
        TestContext context = new TestContext();
        /*[ClassInitialize()]
        public static void Initialize()
        {
            MessageBox.Show("TestInit");
            AppDomain.CurrentDomain.SetData("DataDirectory", AppDomain.CurrentDomain.BaseDirectory);
            TestContext context = new TestContext();
            DbTestInitializier init = new DbTestInitializier(context);
            logic.setContext(context);
        }

        [TestInitialize()]
        public void wtf()
        {
            MessageBox.Show("TestMethodInit");
        }
        */

        [ClassInitialize()]
        public static void ClassInit(Microsoft.VisualStudio.TestTools.UnitTesting.TestContext context)
        {
        }

        [TestInitialize()]
        public void Initialize()
        {
            
            DbTestInitializier init = new DbTestInitializier(context);
           // logic.setContext(context);
        }

        [TestMethod()]
        public void testfirst()
        {
        }

        [TestMethod()]        
        [DataSource("System.Data.SqlClient", @"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Christian\Documents\GitHub\s0pra\ModulManagementSystem\Tests\bin\Debug\MMS.mdf;Integrated Security=True; MultipleActiveResultSets=true", "dbo.Subjects", Microsoft.VisualStudio.TestTools.UnitTesting.DataAccessMethod.Sequential)]
        public void TestGetSubjectByName()
        {
            //happy flow
            Assert.AreEqual(1, logic.getSubjectByName("Mathe").SubjectID);
            Console.WriteLine("Hello whats upppppppppppppp");
            Assert.AreEqual(3, logic.getSubjectByName("Seminar").SubjectID);
            //non happy flow
            Assert.AreEqual(null, logic.getSubjectByName("das Fach gibt es nicht"));
            //null flow
            Assert.AreEqual(null, logic.getSubjectByName(null));
            Assert.IsTrue(true);
        }

        /*[TestMethod]
        [DataSource("ModulsDataSource")]
        public void TestGetModulByName()
        {
            Assert.AreEqual(1, logic.getModuleByName("Technische Informatik").ModulID);
            Assert.AreEqual(2, logic.getModuleByName("Lineare Algebra").ModulID);

            Assert.AreEqual(null, logic.getModuleByName("Das Modul gibt es nicht"));

            Assert.AreEqual(null, logic.getModuleByName(null));
        }

        [TestMethod]
        [DataSource("ModulsDataSource")]
        public void TestGetModulhandbookByName()
        {
            Assert.AreEqual(1, logic.getModulhandbookByName("Software-Engineering").ModulhandbookID);

            Assert.AreEqual(null, logic.getModulhandbookByName("Das Modulhandbuch gibt es nicht"));

            Assert.AreEqual(null, logic.getModulhandbookByName(null));
        }

        [TestMethod]
        [DataSource("ModulsDataSource")]
        public void TestGetAllHandbooks()
        {
            Assert.AreEqual(1, logic.getAllModulhandbooks().Count);
        }

        [TestMethod]
        [DataSource("ModulsDataSource")]
        public void TestGetAllSubjectsFromModulhandbook()
        {
            Assert.AreEqual(3, logic.getAllSubjectsFromModulhandbook(1).Count);
            Assert.AreEqual(3, logic.getAllSubjectsFromModulhandbook("Software-Engineering").Count);

            Assert.AreEqual(0, logic.getAllSubjectsFromModulhandbook(99).Count);
            Assert.AreEqual(null, logic.getAllSubjectsFromModulhandbook(""));
            Assert.AreEqual(null, logic.getAllSubjectsFromModulhandbook("existiert nicht"));

            Assert.AreEqual(null, logic.getAllSubjectsFromModulhandbook(null));
        }

        [TestMethod]
        [DataSource("ModulsDataSource")]
        public void TestGetAllModulesFromSubject()
        {
            Assert.AreEqual(2, logic.getAllModulesFromSubject("Mathe").Count);
            Assert.AreEqual(1, logic.getAllModulesFromSubject("Seminar").Count);

            Assert.AreEqual(null, logic.getAllSubjectsFromModulhandbook("ibts nicht"));

            Assert.AreEqual(null, logic.getAllSubjectsFromModulhandbook(null));
        }*/
    }
}
