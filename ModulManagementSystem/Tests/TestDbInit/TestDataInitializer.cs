using ModulManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Windows.Forms;


namespace Tests
{
    public class TestDataInitializer : DropCreateDatabaseIfModelChanges<TestContext>
    {

        protected override void Seed(TestContext context)
        {
            MessageBox.Show("Init Test data");
            GetModulhandbooks().ForEach(e => context.Modulhandbooks.Add(e));
            GetArchives().ForEach(f => context.Archive.Add(f));
            GetModulPartDescriptions().ForEach(a => context.ModulPartDescriptiones.Add(a));
            GetSemesters().ForEach(s => context.Semesters.Add(s));
            
            
            var modules = new List<Modul>
            {

                
            new Modul{
                    ModulID = 1,
                    State =ModulState.created,
                    Version=1,
                   
                    LastChange=DateTime.Now,
                    Subjects = new List<Subject>(),
                    Descriptions=new List<ModulPartDescription>(),
                },
                new Modul{
                    ModulID = 8,
                    State =ModulState.created,
                    Version=2,
     
                    LastChange=DateTime.Now,
                    Subjects = new List<Subject>(),
                    Descriptions=new List<ModulPartDescription>(),
                },
                new Modul{
                    ModulID = 2,
                    State = ModulState.waitingForAcceptionFromFreigabeberechtigter,
                    Version=1,
           
                    LastChange=DateTime.Now,
                    Subjects = new List<Subject>(),
                    Descriptions=new List<ModulPartDescription>(),
                },
                new Modul{
                    ModulID = 3,
                    State = ModulState.abgelehnt,
                    Version=1,
        
                    LastChange=DateTime.Now,
                    Subjects = new List<Subject>(),
                    Descriptions=new List<ModulPartDescription>(),
                },
                new Modul{
                    ModulID = 4,
                    State = ModulState.abgelehnt,
                    Version=1,
           
                    LastChange=DateTime.Now,
                    Subjects = new List<Subject>(),
                    Descriptions=new List<ModulPartDescription>(),
                },
                new Modul{
                    ModulID = 5,
                    State = ModulState.abgelehnt,
                    Version=1,
          
                    LastChange=DateTime.Now,
                    Subjects = new List<Subject>(),
                    Descriptions=new List<ModulPartDescription>(),
                },
                new Modul{
                    ModulID = 6,
                    State = ModulState.abgelehnt,
                    Version=1,
            
                    LastChange=DateTime.Now,
                    Subjects = new List<Subject>(),
                    Descriptions=new List<ModulPartDescription>(),
                },
                new Modul{
                    ModulID = 7,
                    State = ModulState.abgelehnt,
                    Version=1,
              
                    LastChange=DateTime.Now,
                    Subjects = new List<Subject>(),
                    Descriptions=new List<ModulPartDescription>(),
                },
            };
            modules.ForEach(s => context.Modules.Add(s));
            context.SaveChanges();

            var subjects = new List<Subject>{
                new Subject{
                    Name = "Mathe",
                    SubjectID=1,
                    ModulhandbookID = 1
                },
                new Subject{
                    Name = "Semiar",
                    SubjectID=4,
                    ModulhandbookID = 2
                },
                new Subject{
                    Name = "Praktische und Angewandte Informatik",
                    SubjectID=5,
                    ModulhandbookID = 3
                },
                new Subject{
                    Name = "Technische und Systemnahe Informatik",
                    SubjectID=2,
                    ModulhandbookID = 1
                },
                new Subject{
                    Name = "Schwerpunkt SoftwareEngineering",
                    SubjectID=6,
                    ModulhandbookID = 1
                },
                new Subject{
                    Name = "Schwerpunkt Bwl",
                    SubjectID=7,
                    ModulhandbookID = 1
                },
                new Subject{
                    Name = "Abschlussarbeit",
                    SubjectID = 3,
                    ModulhandbookID = 1
                }
            };
            subjects.ForEach(s => context.Subjects.Add(s));
            context.SaveChanges();

            modules[0].Subjects.Add(subjects[0]);
            modules[0].Subjects.Add(subjects[1]);
            modules[1].Subjects.Add(subjects[2]);
            modules[2].Subjects.Add(subjects[3]);
            modules[3].Subjects.Add(subjects[4]);
            modules[4].Subjects.Add(subjects[5]);
            modules[5].Subjects.Add(subjects[6]);
            modules[6].Subjects.Add(subjects[6]);
            modules[6].Subjects.Add(subjects[5]);
            modules[6].Subjects.Add(subjects[3]);
            modules[6].Subjects.Add(subjects[4]);
            modules[6].Subjects.Add(subjects[1]);
            modules[7].Subjects.Add(subjects[0]);

            context.SaveChanges();
        }

        private static List<ModulPartDescription> GetModulPartDescriptions()
        {
            var descriptions = new List<ModulPartDescription>{
                new ModulPartDescription{
                    ModulPartDescriptionID = 1,
                    IsNeeded = true,
                    Description="12",
                    Name="Leistungspunkte",
                    ModulID = 1                    
                },
                new ModulPartDescription{
                    ModulPartDescriptionID = 2,
                    IsNeeded = true,
                    Description="20",
                    Name="Wochenstunden",
                    ModulID = 1                    
                },
                new ModulPartDescription{
                    ModulPartDescriptionID = 3,
                    IsNeeded = true,
                    Description="Max Mustermann",
                    Name="Dozent",
                    ModulID = 1                    
                },
                new ModulPartDescription{
                    ModulPartDescriptionID = 4,
                    IsNeeded = true,
                    Description="Lineare Algebra",
                    Name="Name",
                    ModulID = 1                    
                },
                new ModulPartDescription{
                    ModulPartDescriptionID = 3,
                    IsNeeded = true,
                    Description="Max Mustermann",
                    Name="Dozent",
                    ModulID = 8                    
                },
                new ModulPartDescription{
                    ModulPartDescriptionID = 4,
                    IsNeeded = true,
                    Description="Lineare Algebra",
                    Name="Name",
                    ModulID = 8                    
                },
                new ModulPartDescription{
                    ModulPartDescriptionID = 5,
                    IsNeeded = true,
                    Description="Max Mustermann",
                    Name="Dozent",
                    ModulID = 2                    
                },
                new ModulPartDescription{
                    ModulPartDescriptionID = 6,
                    IsNeeded = true,
                    Description="Ti1",
                    Name="Name",
                    ModulID = 2                    
                },
                new ModulPartDescription{
                    ModulPartDescriptionID = 7,
                    IsNeeded = true,
                    Description="TI2",
                    Name="Name",
                    ModulID = 3                    
                },
                new ModulPartDescription{
                    ModulPartDescriptionID = 8,
                    IsNeeded = true,
                    Description="12",
                    Name="Leistungspunkte",
                    ModulID = 2                    
                },
                new ModulPartDescription{
                    ModulPartDescriptionID = 9,
                    IsNeeded = true,
                    Description="12",
                    Name="Leistungspunkte",
                    ModulID = 3                    
                },
                new ModulPartDescription{
                    ModulPartDescriptionID = 10,
                    IsNeeded = true,
                    Description="12",
                    Name="Leistungspunkte",
                    ModulID = 4                    
                },
                new ModulPartDescription{
                    ModulPartDescriptionID = 11,
                    IsNeeded = true,
                    Description="12",
                    Name="Leistungspunkte",
                    ModulID = 5                    
                },
                 new ModulPartDescription{
                    ModulPartDescriptionID = 12,
                    IsNeeded = true,
                    Description="12",
                    Name="Leistungspunkte",
                    ModulID = 6                    
                },
                new ModulPartDescription{
                    ModulPartDescriptionID = 13,
                    IsNeeded = true,
                    Description="12",
                    Name="Leistungspunkte",
                    ModulID = 7                    
                },
                new ModulPartDescription{
                    ModulPartDescriptionID = 14,
                    IsNeeded = true,
                    Description="Ana1",
                    Name="Name",
                    ModulID = 2                    
                },
                new ModulPartDescription{
                    ModulPartDescriptionID = 16,
                    IsNeeded = true,
                    Description="Einführung in die Informatik",
                    Name="Name",
                    ModulID = 4                    
                },
                new ModulPartDescription{
                    ModulPartDescriptionID = 17,
                    IsNeeded = true,
                    Description="Rechnernetze",
                    Name="Name",
                    ModulID = 5                    
                },
                new ModulPartDescription{
                    ModulPartDescriptionID = 18,
                    IsNeeded = true,
                    Description="Ki",
                    Name="Name",
                    ModulID = 6                    
                },
                new ModulPartDescription{
                    ModulPartDescriptionID = 19,
                    IsNeeded = true,
                    Description="Pvs",
                    Name="Name",
                    ModulID = 7                    
                },
            };
            return descriptions;
        }

        private static List<Modulhandbook> GetModulhandbooks()
        {
            var modulHandbooks = new List<Modulhandbook>{

                new Modulhandbook{
                    ModulhandbookID = 1,
                    SemesterID=1,
                    Name = "Bachelor Software-Engineering",
                    Abschluss = "Bachelor",
                    FspoYear = 2012,
                    ValidSemester = "Sommersemester 2013",
                },
                new Modulhandbook{
                    ModulhandbookID = 4,
                    SemesterID=1,
                    Name = "Master Software-Engineering",
                    Abschluss = "Master",
                    FspoYear = 2012,
                    ValidSemester = "Sommersemester 2013",
                },
                new Modulhandbook{
                    ModulhandbookID = 5,
                    SemesterID=1,
                    Name = "Bachelor Medieninformatik",
                    Abschluss = "Bachelor",
                    FspoYear = 2013,
                    ValidSemester = "Sommersemester 2013",
                },
                new Modulhandbook{
                    ModulhandbookID = 2,
                    SemesterID=1,
                    Name = "Master Medieninformatik",
                    Abschluss = "Master",
                    FspoYear = 2013,
                    ValidSemester = "Sommersemester 2013",
                },
                new Modulhandbook{
                    ModulhandbookID = 3,
                    SemesterID=1,
                    Name = "Bachelor Informatik",
                    Abschluss = "Bachelor",
                    FspoYear = 2012,
                    ValidSemester = "Sommersemester 2013",
                },
                new Modulhandbook{
                    ModulhandbookID = 6,
                    SemesterID=1,
                    Name = "Master Informatik",
                    Abschluss = "Master",
                    FspoYear = 2012,
                    ValidSemester = "Sommersemester 2013",
                },
                new Modulhandbook{
                    ModulhandbookID = 7,
                    SemesterID=2,
                    Name = "Bachelor Software-Engineering",
                    Abschluss = "Bachelor",
                    FspoYear = 2012,
                    ValidSemester = "Wintersemester 2012/13",
                }
            };


            return modulHandbooks;
        }

        private static List<Semester> GetSemesters()
        {
            var archives = new List<Semester>{
                    new Semester{
                    SemesterID = 1,
                    Name="Sommersemester 2013",
                    ArchiveID = 1
                },
                   new Semester{
                    SemesterID =  2,
                    Name="Wintersemester 2012/13",
                    ArchiveID = 1
                }
            };
            return archives;
        }

        private static List<Archive> GetArchives()
        {
            var archives = new List<Archive>{
                    new Archive{
                    ArchiveID = 1 
                }
            };
            return archives;
        }
    }
}