using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace ModulManagementSystem.Models
{
    public class ModulhandbookInitializer : DropCreateDatabaseAlways<ModulhandbookContext>
    {

        protected override void Seed(ModulhandbookContext context)
        {
            GetModulhandbooks().ForEach(e => context.Modulhandbooks.Add(e));
            GetArchives().ForEach(f => context.Archive.Add(f));
            GetModulPartDescriptions().ForEach(a => context.ModulPartDescriptiones.Add(a));
            GetSemesters().ForEach(s => context.Semesters.Add(s));
            GetJobs().ForEach(j => context.Jobs.Add(j));
            
            MembershipUser Modulverantwortlicher1 = Membership.GetUser("Modulverantwortlicher1");
            Guid MV1guid = new Guid(Modulverantwortlicher1.ProviderUserKey.ToString());

            MembershipUser Koordinator = Membership.GetUser("Koordinator");
            Guid KoordGuid = new Guid(Koordinator.ProviderUserKey.ToString());
            
            var modules = new List<Modul>
            {    
            new Modul{
                    ModulID = 1,
                    State =ModulState.created,
                    Version=1,
                    Owner=MV1guid,
                    Autor=MV1guid,
                    LastChange=DateTime.Now,
                    Subjects = new List<Subject>(),
                    Descriptions=new List<ModulPartDescription>(),
                },
                new Modul{
                    ModulID = 8,
                    State =ModulState.created,
                    Version=2,
                    Owner=MV1guid,
                    Autor=MV1guid,
                    LastChange=DateTime.Now,
                    Subjects = new List<Subject>(),
                    Descriptions=new List<ModulPartDescription>(),
                },
                new Modul{
                    ModulID = 2,
                    State = ModulState.waitingForAcceptionFromFreigabeberechtigter,
                    Version=1,
                    Owner=MV1guid,
                    Autor=MV1guid,
                    LastChange=DateTime.Now,
                    Subjects = new List<Subject>(),
                    Descriptions=new List<ModulPartDescription>(),
                },
                new Modul{
                    ModulID = 3,
                    State = ModulState.abgelehnt,
                    Version=1,
                    Owner=MV1guid,
                    Autor=MV1guid,
                    LastChange=DateTime.Now,
                    Subjects = new List<Subject>(),
                    Descriptions=new List<ModulPartDescription>(),
                },
                new Modul{
                    ModulID = 4,
                    State = ModulState.abgelehnt,
                    Version=1,
                    Owner=MV1guid,
                    Autor=MV1guid,
                    LastChange=DateTime.Now,
                    Subjects = new List<Subject>(),
                    Descriptions=new List<ModulPartDescription>(),
                },
                new Modul{
                    ModulID = 5,
                    State = ModulState.abgelehnt,
                    Version=1,
                    Owner=MV1guid,
                    Autor=MV1guid,
                    LastChange=DateTime.Now,
                    Subjects = new List<Subject>(),
                    Descriptions=new List<ModulPartDescription>(),
                },
                new Modul{
                    ModulID = 6,
                    State = ModulState.abgelehnt,
                    Version=1,
                    Owner=MV1guid,
                    Autor=MV1guid,
                    LastChange=DateTime.Now,
                    Subjects = new List<Subject>(),
                    Descriptions=new List<ModulPartDescription>(),
                },
                new Modul{
                    ModulID = 7,
                    State = ModulState.abgelehnt,
                    Version=1,
                    Owner=MV1guid,
                    Autor=MV1guid,
                    LastChange=DateTime.Now,
                    Subjects = new List<Subject>(),
                    Descriptions=new List<ModulPartDescription>(),
                },
            };
            modules.ForEach(s => context.Modules.Add(s));
            context.SaveChanges();

            var subjects = new List<Subject>{
                new Subject{
                    Name = "Mathematik",
                    SubjectID=1,
                    ModulhandbookID = 1
                },
                new Subject{
                    Name = "Seminar",
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
                    Name = "Schwerpunkt BWL",
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


        private static List<Job> GetJobs()
        {
            MembershipUser Modulverantwortlicher1 = Membership.GetUser("Modulverantwortlicher1");
            Guid MV1guid = new Guid(Modulverantwortlicher1.ProviderUserKey.ToString());

            MembershipUser Koordinator = Membership.GetUser("Koordinator");
            Guid KoordGuid = new Guid(Koordinator.ProviderUserKey.ToString());

            MembershipUser Freigabeberechtigter = Membership.GetUser("Freigeber");
            Guid FreigeberGuid = new Guid(Freigabeberechtigter.ProviderUserKey.ToString());

            var jobs = new List<Job>{
                new Job{
                    JobID = 1,
                    Name = "Modulhandbuch SE SS2013 erstellt ",
                    Text = "Modulhandbuch kontrollieren",
                    JobCreated = DateTime.Now,
                    Executer = KoordGuid,
                    JobCreatedBy = MV1guid,
                    ModulID = 1
                },
                new Job{
                    JobID = 2,
                    Name = "Modulhandbuch SE kontrolliert ",
                    Text = "Modulhandbuch freigeben",
                    JobCreated = DateTime.Now,
                    Executer = FreigeberGuid,
                    JobCreatedBy = KoordGuid,
                    ModulID = 2
                },
                new Job{
                    JobID = 3,
                    Name = "Abgelehnt vom Freigeber. Modulhandbuch kontrollieren ",
                    Text = "Name falsch",
                    JobCreated = DateTime.Now,
                    Executer = MV1guid,
                    JobCreatedBy = FreigeberGuid,
                    ModulID = 3
                },
                 new Job{
                    JobID = 4,
                    Name = "Abgelehnt von Koordinator. Modulhandbuch kontrollieren ",
                    Text = "Wer das liest ist doof!",
                    JobCreated = DateTime.Now,
                    Executer = MV1guid,
                    JobCreatedBy = KoordGuid,
                    ModulID = 4
                },
            };
            return jobs;
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
                    Name=GlobalNames.getModulNameText(),
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
                    Name=GlobalNames.getModulNameText(),
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
                    Description="Technische Informatik 1",
                    Name=GlobalNames.getModulNameText(),
                    ModulID = 2                    
                },
                new ModulPartDescription{
                    ModulPartDescriptionID = 7,
                    IsNeeded = true,
                    Description="Technische Informatik 2",
                    Name=GlobalNames.getModulNameText(),
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
                    Description="Analysis 1 für Informatiker und Ingenieure",
                    Name=GlobalNames.getModulNameText(),
                    ModulID = 2                    
                },
                new ModulPartDescription{
                    ModulPartDescriptionID = 16,
                    IsNeeded = true,
                    Description="Einführung in die Informatik",
                    Name=GlobalNames.getModulNameText(),
                    ModulID = 4                    
                },
                new ModulPartDescription{
                    ModulPartDescriptionID = 17,
                    IsNeeded = true,
                    Description="Grundlagen der Rechnernetze",
                    Name=GlobalNames.getModulNameText(),
                    ModulID = 5                    
                },
                new ModulPartDescription{
                    ModulPartDescriptionID = 18,
                    IsNeeded = true,
                    Description="Künstliche Intelligenz",
                    Name=GlobalNames.getModulNameText(),
                    ModulID = 6                    
                },
                new ModulPartDescription{
                    ModulPartDescriptionID = 19,
                    IsNeeded = true,
                    Description="Programmieren von Systemen",
                    Name=GlobalNames.getModulNameText(),
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