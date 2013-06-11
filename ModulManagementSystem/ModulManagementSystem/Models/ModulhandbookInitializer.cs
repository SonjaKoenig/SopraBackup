using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace ModulManagementSystem.Models
{
    /// <summary>
    /// initialized the database with data
    /// </summary>
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

            MembershipUser Modulverantwortlicher2 = Membership.GetUser("Modulverantwortlicher2");
            Guid MV2guid = new Guid(Modulverantwortlicher2.ProviderUserKey.ToString());

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
                    ModulID = 2,
                    State = ModulState.created,
                    Version=1,
                    Owner=MV2guid,
                    Autor=MV2guid,
                    LastChange=DateTime.Now,
                    Subjects = new List<Subject>(),
                    Descriptions=new List<ModulPartDescription>(),
                },
                new Modul{
                    ModulID = 3,
                    State = ModulState.created,
                    Version=1,
                    Owner=MV1guid,
                    Autor=MV1guid,
                    LastChange=DateTime.Now,
                    Subjects = new List<Subject>(),
                    Descriptions=new List<ModulPartDescription>(),
                },
                new Modul{
                    ModulID = 4,
                    State = ModulState.created,
                    Version=1,
                    Owner=MV1guid,
                    Autor=MV1guid,
                    LastChange=DateTime.Now,
                    Subjects = new List<Subject>(),
                    Descriptions=new List<ModulPartDescription>(),
                },
                new Modul{
                    ModulID = 5,
                    State = ModulState.archiviert,
                    Version=1,
                    Owner=MV1guid,
                    Autor=MV1guid,
                    LastChange=DateTime.Now,
                    Subjects = new List<Subject>(),
                    Descriptions=new List<ModulPartDescription>(),
                },
                new Modul{
                    ModulID = 6,
                    State = ModulState.archiviert,
                    Version=1,
                    Owner=MV2guid,
                    Autor=MV2guid,
                    LastChange=DateTime.Now,
                    Subjects = new List<Subject>(),
                    Descriptions=new List<ModulPartDescription>(),
                },
                new Modul{
                    ModulID = 7,
                    State = ModulState.archiviert,
                    Version=1,
                    Owner=MV1guid,
                    Autor=MV1guid,
                    LastChange=DateTime.Now,
                    Subjects = new List<Subject>(),
                    Descriptions=new List<ModulPartDescription>(),
                },
				new Modul{
                    ModulID = 8,
                    State =ModulState.waitingForFreigeber,
                    Version=1,
                    Owner=MV1guid,
                    Autor=MV1guid,
                    LastChange=DateTime.Now,
                    Subjects = new List<Subject>(),
                    Descriptions=new List<ModulPartDescription>(),
                },
                new Modul{
                    ModulID = 9,
                    State = ModulState.waitingForFreigeber,
                    Version=1,
                    Owner=MV1guid,
                    Autor=MV1guid,
                    LastChange=DateTime.Now,
                    Subjects = new List<Subject>(),
                    Descriptions=new List<ModulPartDescription>(),
                },
                new Modul{
                    ModulID = 10,
                    State = ModulState.waitingForFreigeber,
                    Version=1,
                    Owner=MV1guid,
                    Autor=MV1guid,
                    LastChange=DateTime.Now,
                    Subjects = new List<Subject>(),
                    Descriptions=new List<ModulPartDescription>(),
                },
				new Modul{
                    ModulID = 11,
                    State =ModulState.abgelehnt,
                    Version=1,
                    Owner=MV2guid,
                    Autor=MV2guid,
                    LastChange=DateTime.Now,
                    Subjects = new List<Subject>(),
                    Descriptions=new List<ModulPartDescription>(),
                },               
                new Modul{
                    ModulID = 12,
                    State = ModulState.abgelehnt,
                    Version=1,
                    Owner=MV1guid,
                    Autor=MV1guid,
                    LastChange=DateTime.Now,
                    Subjects = new List<Subject>(),
                    Descriptions=new List<ModulPartDescription>(),
                },
                new Modul{
                    ModulID = 13,
                    State = ModulState.abgelehnt,
                    Version=1,
                    Owner=MV1guid,
                    Autor=MV1guid,
                    LastChange=DateTime.Now,
                    Subjects = new List<Subject>(),
                    Descriptions=new List<ModulPartDescription>(),
                },
                new Modul{
                    ModulID = 14,
                    State = ModulState.created,
                    Version=1,
                    Owner=MV1guid,
                    Autor=MV1guid,
                    LastChange=DateTime.Now,
                    Subjects = new List<Subject>(),
                    Descriptions=new List<ModulPartDescription>(),
                },
                new Modul{
                    ModulID = 15,
                    State = ModulState.created,
                    Version=1,
                    Owner=MV1guid,
                    Autor=MV1guid,
                    LastChange=DateTime.Now,
                    Subjects = new List<Subject>(),
                    Descriptions=new List<ModulPartDescription>(),
                },
                new Modul{
                    ModulID = 16,
                    State = ModulState.created,
                    Version=1,
                    Owner=MV1guid,
                    Autor=MV1guid,
                    LastChange=DateTime.Now,
                    Subjects = new List<Subject>(),
                    Descriptions=new List<ModulPartDescription>(),
                },
                new Modul{
                    ModulID = 17,
                    State = ModulState.waitingForFreigeber,
                    Version=1,
                    Owner=MV2guid,
                    Autor=MV2guid,
                    LastChange=DateTime.Now,
                    Subjects = new List<Subject>(),
                    Descriptions=new List<ModulPartDescription>(),
                },
				new Modul{
                    ModulID = 18,
                    State =ModulState.waitingForFreigeber,
                    Version=1,
                    Owner=MV1guid,
                    Autor=MV1guid,
                    LastChange=DateTime.Now,
                    Subjects = new List<Subject>(),
                    Descriptions=new List<ModulPartDescription>(),
                },
                new Modul{
                    ModulID = 19,
                    State = ModulState.waitingForFreigeber,
                    Version=1,
                    Owner=MV1guid,
                    Autor=MV1guid,
                    LastChange=DateTime.Now,
                    Subjects = new List<Subject>(),
                    Descriptions=new List<ModulPartDescription>(),
                },
                new Modul{
                    ModulID = 20,
                    State = ModulState.archiviert,
                    Version=1,
                    Owner=MV1guid,
                    Autor=MV1guid,
                    LastChange=DateTime.Now,
                    Subjects = new List<Subject>(),
                    Descriptions=new List<ModulPartDescription>(),
                }
            };
            modules.ForEach(s => context.Modules.Add(s));
            context.SaveChanges();

            var subjects = new List<Subject>{
                new Subject{
                    Name = "Mathe",
                    SubjectID=1,
                    ModulhandbookID = 3
                },
				new Subject{
                    Name = "Praktische und Angewandte Informatik",
                    SubjectID=2,
                    ModulhandbookID = 3
                },
				new Subject{
                    Name = "Theoretische Informatik",
                    SubjectID = 3,
                    ModulhandbookID = 5
                },
                new Subject{
                    Name = "Technische und Systemnahe Informatik",
                    SubjectID=4,
                    ModulhandbookID = 5
                },								
				new Subject{
                    Name = "Proseminar",
                    SubjectID=5,
                    ModulhandbookID = 8
                },
				new Subject{
                    Name = "Seminar",
                    SubjectID=6,
                    ModulhandbookID = 8
                },
				new Subject{
                    Name = "Abschlussarbeit",
                    SubjectID =7,
                    ModulhandbookID = 4
                },
                new Subject{
                    Name = "Anwendungsfach",
                    SubjectID=8,
                    ModulhandbookID = 4
                },								
				new Subject{
                    Name = "Schwerpunktmodul",
                    SubjectID=9,
                    ModulhandbookID = 6
                },
				new Subject{
                    Name = "Vertiefungsmodul SWE",
                    SubjectID=10,
                    ModulhandbookID = 6
                },
				new Subject{
                    Name = "Vertiefungsmodul Medieninformatik",
                    SubjectID =11,
                    ModulhandbookID = 1
                },
                new Subject{
                    Name = "Anwendungsfach",
                    SubjectID=12,
                    ModulhandbookID = 2
                },								
				new Subject{
                    Name = "Schwerpunktmodul",
                    SubjectID=13,
                    ModulhandbookID = 7
                },
				new Subject{
                    Name = "Vertiefungsmodul SWE",
                    SubjectID=14,
                    ModulhandbookID = 1
                },
				new Subject{
                    Name = "Vertiefungsmodul Medieninformatik",
                    SubjectID =15,
                    ModulhandbookID = 2
                }
            };
            subjects.ForEach(s => context.Subjects.Add(s));
            context.SaveChanges();


            modules[0].Subjects.Add(subjects[2]);
            modules[0].Subjects.Add(subjects[4]);
            modules[0].Subjects.Add(subjects[7]);

            modules[1].Subjects.Add(subjects[7]);
            modules[1].Subjects.Add(subjects[2]);

            modules[2].Subjects.Add(subjects[2]);
            modules[2].Subjects.Add(subjects[3]);
            modules[2].Subjects.Add(subjects[4]);
            modules[2].Subjects.Add(subjects[5]);

            modules[3].Subjects.Add(subjects[4]);
            modules[3].Subjects.Add(subjects[5]);

            modules[4].Subjects.Add(subjects[7]);
            modules[4].Subjects.Add(subjects[8]);
            modules[4].Subjects.Add(subjects[9]);

            modules[5].Subjects.Add(subjects[0]);
            modules[5].Subjects.Add(subjects[1]);


            modules[6].Subjects.Add(subjects[0]);
            modules[6].Subjects.Add(subjects[3]);
            modules[6].Subjects.Add(subjects[6]);

            modules[7].Subjects.Add(subjects[2]);
            modules[7].Subjects.Add(subjects[3]);

            modules[8].Subjects.Add(subjects[2]);
            modules[8].Subjects.Add(subjects[3]);
            modules[8].Subjects.Add(subjects[4]);
            modules[8].Subjects.Add(subjects[7]);

            modules[9].Subjects.Add(subjects[7]);
            modules[9].Subjects.Add(subjects[3]);

            modules[10].Subjects.Add(subjects[7]);
            modules[10].Subjects.Add(subjects[2]);

            modules[11].Subjects.Add(subjects[4]);
            modules[11].Subjects.Add(subjects[5]);
            modules[11].Subjects.Add(subjects[7]);

            modules[12].Subjects.Add(subjects[0]);
            modules[12].Subjects.Add(subjects[6]);

            modules[13].Subjects.Add(subjects[4]);
            modules[13].Subjects.Add(subjects[5]);

            modules[14].Subjects.Add(subjects[5]);
            modules[14].Subjects.Add(subjects[7]);

            modules[15].Subjects.Add(subjects[3]);
            modules[15].Subjects.Add(subjects[4]);
            modules[15].Subjects.Add(subjects[5]);

            modules[16].Subjects.Add(subjects[7]);
            modules[16].Subjects.Add(subjects[2]);

            modules[17].Subjects.Add(subjects[2]);
            modules[17].Subjects.Add(subjects[3]);

            modules[18].Subjects.Add(subjects[4]);
            modules[18].Subjects.Add(subjects[5]);
            modules[18].Subjects.Add(subjects[7]);

            modules[19].Subjects.Add(subjects[0]);
            modules[19].Subjects.Add(subjects[1]);
            modules[19].Subjects.Add(subjects[6]);

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
                    Name = "Abgelehnt von Freigeber. Modulhandbuch kontrollieren ",
                    Text = "Name falsch",
                    JobCreated = DateTime.Now,
                    Executer = MV1guid,
                    JobCreatedBy = FreigeberGuid,
                    ModulID = 3
                },
                 new Job{
                    JobID = 4,
                    Name = "Abgelehnt von Koordinator. Modulhandbuch kontrollieren ",
                    Text = "Sonja soll die Adminseite endlich machen!",
                    JobCreated = DateTime.Now,
                    Executer = MV1guid,
                    JobCreatedBy = KoordGuid,
                    ModulID = 4
                },
                 new Job{
                    JobID = 4,
                    Name = "asdf ",
                    Text = "Felix bitte schau dir die Testdaten nochmal an. Subjects sollten nicht über mehrer Semester verlaufen",
                    JobCreated = DateTime.Now,
                    Executer = MV1guid,
                    JobCreatedBy = KoordGuid,
                    ModulID = 5
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
                    Description="LAInfIng",
                    Name="Kürzel",
                    ModulID = 1                    
                },
                new ModulPartDescription{
                    ModulPartDescriptionID = 2,
                    IsNeeded = true,
                    Description="Lineare Algebra",
                    Name="Name",
                    ModulID = 1                    
                },
                new ModulPartDescription{
                    ModulPartDescriptionID = 3,
                    IsNeeded = true,
                    Description="8",
                    Name="Leistungspunkte",
                    ModulID = 1                    
                },
                new ModulPartDescription{
                    ModulPartDescriptionID = 4,
                    IsNeeded = true,
                    Description="4",
                    Name="Wochenstunden",
                    ModulID = 1                    
                },
                new ModulPartDescription{
                    ModulPartDescriptionID = 5,
                    IsNeeded = true,
                    Description="Deutsch",
                    Name="Sprache",
                    ModulID = 1                    
                },
                new ModulPartDescription{
                    ModulPartDescriptionID = 6,
                    IsNeeded = true,
                    Description="jedes 2. Semester",
                    Name="Turnus",
                    ModulID = 1                    
                },
                new ModulPartDescription{
                    ModulPartDescriptionID = 7,
                    IsNeeded = true,
                    Description="Max Mustermann",
                    Name="Dozent",
                    ModulID = 1                    
                },
                new ModulPartDescription{
                    ModulPartDescriptionID = 9,
                    IsNeeded = true,
                    Description="Informatik, Medieninformatik, Software Engeneering",
                    Name="Einordnung in Studiengänge",
                    ModulID = 1                    
                },
                new ModulPartDescription{
                    ModulPartDescriptionID = 10,
                    IsNeeded = true,
                    Description="Grundkenntnisse der Höheren Mathematik",
                    Name="Voraussetzungen(inhaltich)",
                    ModulID = 1                    
                },
                new ModulPartDescription{
                    ModulPartDescriptionID = 11,
                    IsNeeded = true,
                    Description="Basiskenntnisse in Linearer Algebra, Standartvorgehensweisen ect. pp.",
                    Name="Lernziele",
                    ModulID = 1                    
                },
                new ModulPartDescription{
                    ModulPartDescriptionID = 12,
                    IsNeeded = true,
                    Description="Die Studierenden bekommen Einblick in die aufregende Welt der Linearen Algebra",
                    Name="Inhalt",
                    ModulID = 1                    
                },
                new ModulPartDescription{
                    ModulPartDescriptionID = 13,
                    IsNeeded = true,
                    Description="Vorlesungsscript (ist im SLC verfügbar)",
                    Name="Literatur",
                    ModulID = 1                    
                },
                new ModulPartDescription{
                    ModulPartDescriptionID = 14,
                    IsNeeded = true,
                    Description="Vorlesung",
                    Name="Lehr- und Lernformen",
                    ModulID = 1                    
                },
                new ModulPartDescription{
                    ModulPartDescriptionID = 15,
                    IsNeeded = true,
                    Description="10",
                    Name="Arbeitsaufwand",
                    ModulID = 1                    
                },
                new ModulPartDescription{
                    ModulPartDescriptionID = 16,
                    IsNeeded = true,
                    Description="Klausur",
                    Name="Bewertungsmethode",
                    ModulID = 1                    
                },
                new ModulPartDescription{
                    ModulPartDescriptionID = 17,
                    IsNeeded = true,
                    Description="keine",
                    Name="Vorraussetzungen(Formal)",
                    ModulID = 1                    
                },
                new ModulPartDescription{
                    ModulPartDescriptionID = 18,
                    IsNeeded = true,
                    Description="Notenbildung",
                    Name="6pkt Klausur 2pkt Übung",
                    ModulID = 1                    
                },
                
                


                new ModulPartDescription{
                    ModulPartDescriptionID = 19,
                    IsNeeded = true,
                    Description="A1aInf",
                    Name="Kürzel",
                    ModulID = 2                    
                },
                new ModulPartDescription{
                    ModulPartDescriptionID = 20,
                    IsNeeded = true,
                    Description="Analysis 1a für Informatiker",
                    Name="Name",
                    ModulID = 2                    
                },
                new ModulPartDescription{
                    ModulPartDescriptionID = 21,
                    IsNeeded = true,
                    Description="6",
                    Name="Leistungspunkte",
                    ModulID = 2                    
                },
                new ModulPartDescription{
                    ModulPartDescriptionID = 22,
                    IsNeeded = true,
                    Description="2",
                    Name="Wochenstunden",
                    ModulID = 2                    
                },
                new ModulPartDescription{
                    ModulPartDescriptionID = 23,
                    IsNeeded = true,
                    Description="Deutsch",
                    Name="Sprache",
                    ModulID = 2                    
                },
                new ModulPartDescription{
                    ModulPartDescriptionID = 24,
                    IsNeeded = true,
                    Description="jedes 2. Semester",
                    Name="Turnus",
                    ModulID = 2                    
                },
                new ModulPartDescription{
                    ModulPartDescriptionID = 26,
                    IsNeeded = true,
                    Description="Gerhard Bauer",
                    Name="Dozent",
                    ModulID = 2                    
                },
                new ModulPartDescription{
                    ModulPartDescriptionID = 27,
                    IsNeeded = true,
                    Description="Informatik, Medieninformatik, Software Engeneering",
                    Name="Einordnung in Studiengänge",
                    ModulID = 2                    
                },
                new ModulPartDescription{
                    ModulPartDescriptionID = 28,
                    IsNeeded = true,
                    Description="Grundkenntnisse der Höheren Mathematik",
                    Name="Voraussetzungen(inhaltich)",
                    ModulID = 2                    
                },
                new ModulPartDescription{
                    ModulPartDescriptionID = 29,
                    IsNeeded = true,
                    Description="Basiskenntnisse in Analysis, Standartvorgehensweisen ect. pp.",
                    Name="Lernziele",
                    ModulID = 2                    
                },
                new ModulPartDescription{
                    ModulPartDescriptionID = 30,
                    IsNeeded = true,
                    Description="Die Studierenden bekommen Einblick in die aufregende Welt der Analysis",
                    Name="Inhalt",
                    ModulID = 2                    
                },
                new ModulPartDescription{
                    ModulPartDescriptionID = 31,
                    IsNeeded = true,
                    Description="Vorlesungsscript (ist im SLC verfügbar)",
                    Name="Literatur",
                    ModulID = 2                    
                },
                new ModulPartDescription{
                    ModulPartDescriptionID = 32,
                    IsNeeded = true,
                    Description="Vorlesung",
                    Name="Lehr- und Lernformen",
                    ModulID = 2                    
                },
                new ModulPartDescription{
                    ModulPartDescriptionID = 33,
                    IsNeeded = true,
                    Description="8",
                    Name="Arbeitsaufwand",
                    ModulID = 2                    
                },
                new ModulPartDescription{
                    ModulPartDescriptionID = 34,
                    IsNeeded = true,
                    Description="Klausur",
                    Name="Bewertungsmethode",
                    ModulID = 2                    
                },
                new ModulPartDescription{
                    ModulPartDescriptionID = 35,
                    IsNeeded = true,
                    Description="keine",
                    Name="Vorraussetzungen(Formal)",
                    ModulID = 2                    
                },
                new ModulPartDescription{
                    ModulPartDescriptionID = 36,
                    IsNeeded = true,
                    Description="Notenbildung",
                    Name="4pkt Klausur 2pkt Übung",
                    ModulID = 2                    
                },
                
                


                new ModulPartDescription{
                    ModulPartDescriptionID = 37,
                    IsNeeded = true,
                    Description="A2aInf",
                    Name="Kürzel",
                    ModulID = 3                    
                },
                new ModulPartDescription{
                    ModulPartDescriptionID = 38,
                    IsNeeded = true,
                    Description="Analysis 2a für Informatiker",
                    Name="Name",
                    ModulID = 3                    
                },
                new ModulPartDescription{
                    ModulPartDescriptionID = 39,
                    IsNeeded = true,
                    Description="6",
                    Name="Leistungspunkte",
                    ModulID = 3                    
                },
                new ModulPartDescription{
                    ModulPartDescriptionID = 40,
                    IsNeeded = true,
                    Description="2",
                    Name="Wochenstunden",
                    ModulID = 3                    
                },
                new ModulPartDescription{
                    ModulPartDescriptionID = 41,
                    IsNeeded = true,
                    Description="Deutsch",
                    Name="Sprache",
                    ModulID = 3                    
                },
                new ModulPartDescription{
                    ModulPartDescriptionID = 42,
                    IsNeeded = true,
                    Description="jedes 2. Semester",
                    Name="Turnus",
                    ModulID = 3                    
                },
                new ModulPartDescription{
                    ModulPartDescriptionID = 44,
                    IsNeeded = true,
                    Description="Gerhard Bauer",
                    Name="Dozent",
                    ModulID = 3                    
                },
                new ModulPartDescription{
                    ModulPartDescriptionID = 45,
                    IsNeeded = true,
                    Description="Informatik, Medieninformatik, Software Engeneering",
                    Name="Einordnung in Studiengänge",
                    ModulID = 3                    
                },
                new ModulPartDescription{
                    ModulPartDescriptionID = 46,
                    IsNeeded = true,
                    Description="Kenntnisse der Höheren Mathematik sowie Analysis I",
                    Name="Voraussetzungen(inhaltich)",
                    ModulID = 3                    
                },
                new ModulPartDescription{
                    ModulPartDescriptionID = 47,
                    IsNeeded = true,
                    Description="Weiterführende Kenntnisse in Analysis, Standartvorgehensweisen ect. pp.",
                    Name="Lernziele",
                    ModulID = 3                    
                },
                new ModulPartDescription{
                    ModulPartDescriptionID = 48,
                    IsNeeded = true,
                    Description="Die Studierenden bekommen einen tieferen Einblick in die aufregende Welt der Analysis",
                    Name="Inhalt",
                    ModulID = 3                    
                },
                new ModulPartDescription{
                    ModulPartDescriptionID = 49,
                    IsNeeded = true,
                    Description="Vorlesungsscript (ist im SLC verfügbar)",
                    Name="Literatur",
                    ModulID = 3                    
                },
                new ModulPartDescription{
                    ModulPartDescriptionID = 50,
                    IsNeeded = true,
                    Description="Vorlesung",
                    Name="Lehr- und Lernformen",
                    ModulID = 3                    
                },
                new ModulPartDescription{
                    ModulPartDescriptionID = 51,
                    IsNeeded = true,
                    Description="8",
                    Name="Arbeitsaufwand",
                    ModulID = 3                    
                },
                new ModulPartDescription{
                    ModulPartDescriptionID = 52,
                    IsNeeded = true,
                    Description="Klausur",
                    Name="Bewertungsmethode",
                    ModulID = 3                    
                },
                new ModulPartDescription{
                    ModulPartDescriptionID = 53,
                    IsNeeded = true,
                    Description="keine",
                    Name="Vorraussetzungen(Formal)",
                    ModulID = 3                    
                },
                new ModulPartDescription{
                    ModulPartDescriptionID = 54,
                    IsNeeded = true,
                    Description="4pkt Klausur 2pkt Übung",
                    Name="Notenbildung",
                    ModulID = 3                    
                },
                
                
				
				
				
                new ModulPartDescription{
                    ModulPartDescriptionID = 55,
                    IsNeeded = true,
                    Description="AgNu1",
                    Name="Kürzel",
                    ModulID = 4                    
                },
                new ModulPartDescription{
                    ModulPartDescriptionID = 56,
                    IsNeeded = true,
                    Description="Angewandte Numerik I ",
                    Name="Name",
                    ModulID = 4                    
                },
                new ModulPartDescription{
                    ModulPartDescriptionID = 57,
                    IsNeeded = true,
                    Description="6",
                    Name="Leistungspunkte",
                    ModulID = 4                    
                },
                new ModulPartDescription{
                    ModulPartDescriptionID = 58,
                    IsNeeded = true,
                    Description="2",
                    Name="Wochenstunden",
                    ModulID = 4                    
                },
                new ModulPartDescription{
                    ModulPartDescriptionID = 59,
                    IsNeeded = true,
                    Description="Deutsch",
                    Name="Sprache",
                    ModulID = 4                    
                },
                new ModulPartDescription{
                    ModulPartDescriptionID = 60,
                    IsNeeded = true,
                    Description="jedes 2. Semester",
                    Name="Turnus",
                    ModulID = 4                    
                },
                new ModulPartDescription{
                    ModulPartDescriptionID = 62,
                    IsNeeded = true,
                    Description="Prof. Funken",
                    Name="Dozent",
                    ModulID = 4                    
                },
                new ModulPartDescription{
                    ModulPartDescriptionID = 63,
                    IsNeeded = true,
                    Description="Informatik, Medieninformatik, Software Engeneering",
                    Name="Einordnung in Studiengänge",
                    ModulID = 4                    
                },
                new ModulPartDescription{
                    ModulPartDescriptionID = 64,
                    IsNeeded = true,
                    Description="Kenntnisse der elementaren Linearen Algebra",
                    Name="Voraussetzungen(inhaltich)",
                    ModulID = 4                    
                },
                new ModulPartDescription{
                    ModulPartDescriptionID = 65,
                    IsNeeded = true,
                    Description="Grundkenntnisse der angewandten Numerik",
                    Name="Lernziele",
                    ModulID = 4                    
                },
                new ModulPartDescription{
                    ModulPartDescriptionID = 66,
                    IsNeeded = true,
                    Description="Einblicke in die Computergestützte Numerik",
                    Name="Inhalt",
                    ModulID = 4                    
                },
                new ModulPartDescription{
                    ModulPartDescriptionID = 67,
                    IsNeeded = true,
                    Description="Vorlesungsscript (verfügbar auf der Numerik Homepage)",
                    Name="Literatur",
                    ModulID = 4                    
                },
                new ModulPartDescription{
                    ModulPartDescriptionID = 68,
                    IsNeeded = true,
                    Description="Vorlesung",
                    Name="Lehr- und Lernformen",
                    ModulID = 4                    
                },
                new ModulPartDescription{
                    ModulPartDescriptionID = 69,
                    IsNeeded = true,
                    Description="8",
                    Name="Arbeitsaufwand",
                    ModulID = 4                    
                },
                new ModulPartDescription{
                    ModulPartDescriptionID = 70,
                    IsNeeded = true,
                    Description="Klausur",
                    Name="Bewertungsmethode",
                    ModulID = 4                    
                },
                new ModulPartDescription{
                    ModulPartDescriptionID = 71,
                    IsNeeded = true,
                    Description="keine",
                    Name="Vorraussetzungen(Formal)",
                    ModulID = 4                    
                },
                new ModulPartDescription{
                    ModulPartDescriptionID = 72,
                    IsNeeded = true,
                    Description="4pkt Klausur 2pkt Übung",
                    Name="Notenbildung",
                    ModulID = 4                    
                },
                
                
				
				
				
                new ModulPartDescription{
                    ModulPartDescriptionID = 73,
                    IsNeeded = true,
                    Description="GrTh1",
                    Name="Kürzel",
                    ModulID = 5                    
                },
                new ModulPartDescription{
                    ModulPartDescriptionID = 74,
                    IsNeeded = true,
                    Description="Graphentheorie I ",
                    Name="Name",
                    ModulID = 5                    
                },
                new ModulPartDescription{
                    ModulPartDescriptionID = 75,
                    IsNeeded = true,
                    Description="6",
                    Name="Leistungspunkte",
                    ModulID = 5                    
                },
                new ModulPartDescription{
                    ModulPartDescriptionID = 76,
                    IsNeeded = true,
                    Description="2",
                    Name="Wochenstunden",
                    ModulID = 5                    
                },
                new ModulPartDescription{
                    ModulPartDescriptionID = 77,
                    IsNeeded = true,
                    Description="Deutsch",
                    Name="Sprache",
                    ModulID = 5                    
                },
                new ModulPartDescription{
                    ModulPartDescriptionID = 78,
                    IsNeeded = true,
                    Description="jedes 2. Semester",
                    Name="Turnus",
                    ModulID = 5                    
                },
                new ModulPartDescription{
                    ModulPartDescriptionID = 80,
                    IsNeeded = true,
                    Description="Dieter Rautenbach",
                    Name="Dozent",
                    ModulID = 5                    
                },
                new ModulPartDescription{
                    ModulPartDescriptionID = 81,
                    IsNeeded = true,
                    Description="Informatik, Medieninformatik, Software Engeneering",
                    Name="Einordnung in Studiengänge",
                    ModulID = 5                    
                },
                new ModulPartDescription{
                    ModulPartDescriptionID = 82,
                    IsNeeded = true,
                    Description="keine",
                    Name="Voraussetzungen(inhaltich)",
                    ModulID = 5                    
                },
                new ModulPartDescription{
                    ModulPartDescriptionID = 83,
                    IsNeeded = true,
                    Description="Grundkenntnisse der Graphentheorie",
                    Name="Lernziele",
                    ModulID = 5                    
                },
                new ModulPartDescription{
                    ModulPartDescriptionID = 84,
                    IsNeeded = true,
                    Description="Grundlagen der Graphentheorie",
                    Name="Inhalt",
                    ModulID = 5                    
                },
                new ModulPartDescription{
                    ModulPartDescriptionID = 85,
                    IsNeeded = true,
                    Description="Vorlesungsscript (verfügbar auf der Homepage)",
                    Name="Literatur",
                    ModulID = 5                    
                },
                new ModulPartDescription{
                    ModulPartDescriptionID = 86,
                    IsNeeded = true,
                    Description="Vorlesung",
                    Name="Lehr- und Lernformen",
                    ModulID = 5                    
                },
                new ModulPartDescription{
                    ModulPartDescriptionID = 87,
                    IsNeeded = true,
                    Description="8",
                    Name="Arbeitsaufwand",
                    ModulID = 5                    
                },
                new ModulPartDescription{
                    ModulPartDescriptionID = 88,
                    IsNeeded = true,
                    Description="Klausur",
                    Name="Bewertungsmethode",
                    ModulID = 5                    
                },
                new ModulPartDescription{
                    ModulPartDescriptionID = 89,
                    IsNeeded = true,
                    Description="keine",
                    Name="Vorraussetzungen(Formal)",
                    ModulID = 5                    
                },
                new ModulPartDescription{
                    ModulPartDescriptionID = 90,
                    IsNeeded = true,
                    Description="4pkt Klausur 2pkt Übung",
                    Name="Notenbildung",
                    ModulID = 5                    
                },
                
                
                
                
				
				
				
                new ModulPartDescription{
                    ModulPartDescriptionID = 91,
                    IsNeeded = true,
                    Description="AgSto1",
                    Name="Kürzel",
                    ModulID = 6                    
                },
                new ModulPartDescription{
                    ModulPartDescriptionID = 92,
                    IsNeeded = true,
                    Description="Angewandte Stochastik I ",
                    Name="Name",
                    ModulID = 6                    
                },
                new ModulPartDescription{
                    ModulPartDescriptionID = 93,
                    IsNeeded = true,
                    Description="6",
                    Name="Leistungspunkte",
                    ModulID = 6                    
                },
                new ModulPartDescription{
                    ModulPartDescriptionID = 94,
                    IsNeeded = true,
                    Description="2",
                    Name="Wochenstunden",
                    ModulID = 6                    
                },
                new ModulPartDescription{
                    ModulPartDescriptionID = 95,
                    IsNeeded = true,
                    Description="Deutsch",
                    Name="Sprache",
                    ModulID = 6                    
                },
                new ModulPartDescription{
                    ModulPartDescriptionID = 96,
                    IsNeeded = true,
                    Description="jedes 2. Semester",
                    Name="Turnus",
                    ModulID = 6                    
                },
                new ModulPartDescription{
                    ModulPartDescriptionID = 98,
                    IsNeeded = true,
                    Description="Laplace",
                    Name="Dozent",
                    ModulID = 6                    
                },
                new ModulPartDescription{
                    ModulPartDescriptionID = 99,
                    IsNeeded = true,
                    Description="Informatik, Medieninformatik, Software Engeneering",
                    Name="Einordnung in Studiengänge",
                    ModulID = 6                    
                },
                new ModulPartDescription{
                    ModulPartDescriptionID = 100,
                    IsNeeded = true,
                    Description="Höhere Mathematik",
                    Name="Voraussetzungen(inhaltich)",
                    ModulID = 6                    
                },
                new ModulPartDescription{
                    ModulPartDescriptionID = 101,
                    IsNeeded = true,
                    Description="Grundkenntnisse der angewandten Stochastik",
                    Name="Lernziele",
                    ModulID = 6                    
                },
                new ModulPartDescription{
                    ModulPartDescriptionID = 102,
                    IsNeeded = true,
                    Description="Einblicke in stochastische Vorgänge und Modelle in der Realität.",
                    Name="Inhalt",
                    ModulID = 6                    
                },
                new ModulPartDescription{
                    ModulPartDescriptionID = 103,
                    IsNeeded = true,
                    Description="Vorlesungsscript (verfügbar auf der Stochastik Homepage)",
                    Name="Literatur",
                    ModulID = 6                    
                },
                new ModulPartDescription{
                    ModulPartDescriptionID = 104,
                    IsNeeded = true,
                    Description="Vorlesung",
                    Name="Lehr- und Lernformen",
                    ModulID = 6                    
                },
                new ModulPartDescription{
                    ModulPartDescriptionID = 105,
                    IsNeeded = true,
                    Description="8",
                    Name="Arbeitsaufwand",
                    ModulID = 6                    
                },
                new ModulPartDescription{
                    ModulPartDescriptionID = 106,
                    IsNeeded = true,
                    Description="Klausur",
                    Name="Bewertungsmethode",
                    ModulID = 6                    
                },
                new ModulPartDescription{
                    ModulPartDescriptionID = 107,
                    IsNeeded = true,
                    Description="keine",
                    Name="Vorraussetzungen(Formal)",
                    ModulID = 6                    
                },
                new ModulPartDescription{
                    ModulPartDescriptionID = 108,
                    IsNeeded = true,
                    Description="4pkt Klausur 2pkt Übung",
                    Name="Notenbildung",
                    ModulID = 6                    
                },
                
                
                
                
				
				
				
                new ModulPartDescription{
                    ModulPartDescriptionID = 109,
                    IsNeeded = true,
                    Description="DskSt",
                    Name="Kürzel",
                    ModulID = 7                    
                },
                new ModulPartDescription{
                    ModulPartDescriptionID = 110,
                    IsNeeded = true,
                    Description="Deskriptive Statistik",
                    Name="Name",
                    ModulID = 7                    
                },
                new ModulPartDescription{
                    ModulPartDescriptionID = 111,
                    IsNeeded = true,
                    Description="8",
                    Name="Leistungspunkte",
                    ModulID = 7                    
                },
                new ModulPartDescription{
                    ModulPartDescriptionID = 112,
                    IsNeeded = true,
                    Description="4",
                    Name="Wochenstunden",
                    ModulID = 7                    
                },
                new ModulPartDescription{
                    ModulPartDescriptionID = 113,
                    IsNeeded = true,
                    Description="Deutsch",
                    Name="Sprache",
                    ModulID = 7                    
                },
                new ModulPartDescription{
                    ModulPartDescriptionID = 114,
                    IsNeeded = true,
                    Description="jedes 2. Semester",
                    Name="Turnus",
                    ModulID = 7                    
                },
                new ModulPartDescription{
                    ModulPartDescriptionID = 116,
                    IsNeeded = true,
                    Description="Rainer Muche",
                    Name="Dozent",
                    ModulID = 7                    
                },
                new ModulPartDescription{
                    ModulPartDescriptionID = 117,
                    IsNeeded = true,
                    Description="Informatik, Medieninformatik, Software Engeneering",
                    Name="Einordnung in Studiengänge",
                    ModulID = 7                    
                },
                new ModulPartDescription{
                    ModulPartDescriptionID = 118,
                    IsNeeded = true,
                    Description="Kenntnisse über stochastische Standardverfahren und Methoden",
                    Name="Voraussetzungen(inhaltich)",
                    ModulID = 7                    
                },
                new ModulPartDescription{
                    ModulPartDescriptionID = 119,
                    IsNeeded = true,
                    Description="Aufstellen, Analysieren und Auswerten von Statistiken",
                    Name="Lernziele",
                    ModulID = 7                    
                },
                new ModulPartDescription{
                    ModulPartDescriptionID = 120,
                    IsNeeded = true,
                    Description="Wiederholung: Elementare Statistik, Weiterführende Statistik",
                    Name="Inhalt",
                    ModulID = 7                    
                },
                new ModulPartDescription{
                    ModulPartDescriptionID = 121,
                    IsNeeded = true,
                    Description="Vorlesungsscript (verfügbar auf der Homepage für Deskriptive Statistik)",
                    Name="Literatur",
                    ModulID = 7                    
                },
                new ModulPartDescription{
                    ModulPartDescriptionID = 122,
                    IsNeeded = true,
                    Description="Vorlesung",
                    Name="Lehr- und Lernformen",
                    ModulID = 7                    
                },
                new ModulPartDescription{
                    ModulPartDescriptionID = 123,
                    IsNeeded = true,
                    Description="10",
                    Name="Arbeitsaufwand",
                    ModulID = 7                    
                },
                new ModulPartDescription{
                    ModulPartDescriptionID = 124,
                    IsNeeded = true,
                    Description="Klausur",
                    Name="Bewertungsmethode",
                    ModulID = 7                    
                },
                new ModulPartDescription{
                    ModulPartDescriptionID = 125,
                    IsNeeded = true,
                    Description="keine",
                    Name="Vorraussetzungen(Formal)",
                    ModulID = 7                    
                },
                new ModulPartDescription{
                    ModulPartDescriptionID = 126,
                    IsNeeded = true,
                    Description="6pkt Klausur 2pkt Übung",
                    Name="Notenbildung",
                    ModulID = 7                    
                },
                
                
                
				
				
				
                new ModulPartDescription{
                    ModulPartDescriptionID = 127,
                    IsNeeded = true,
                    Description="EiddG",
                    Name="Kürzel",
                    ModulID = 8                    
                },
                new ModulPartDescription{
                    ModulPartDescriptionID = 128,
                    IsNeeded = true,
                    Description="Einführung in die diskrete Geometrie",
                    Name="Name",
                    ModulID = 8                    
                },
                new ModulPartDescription{
                    ModulPartDescriptionID = 129,
                    IsNeeded = true,
                    Description="8",
                    Name="Leistungspunkte",
                    ModulID = 8                    
                },
                new ModulPartDescription{
                    ModulPartDescriptionID = 130,
                    IsNeeded = true,
                    Description="4",
                    Name="Wochenstunden",
                    ModulID = 8                    
                },
                new ModulPartDescription{
                    ModulPartDescriptionID = 131,
                    IsNeeded = true,
                    Description="Deutsch",
                    Name="Sprache",
                    ModulID = 8                    
                },
                new ModulPartDescription{
                    ModulPartDescriptionID = 132,
                    IsNeeded = true,
                    Description="jedes 2. Semester",
                    Name="Turnus",
                    ModulID = 8                    
                },
                new ModulPartDescription{
                    ModulPartDescriptionID = 134,
                    IsNeeded = true,
                    Description="Jan-Willem Liebezeit",
                    Name="Dozent",
                    ModulID = 8                    
                },
                new ModulPartDescription{
                    ModulPartDescriptionID = 135,
                    IsNeeded = true,
                    Description="Informatik, Medieninformatik, Software Engeneering",
                    Name="Einordnung in Studiengänge",
                    ModulID = 8                    
                },
                new ModulPartDescription{
                    ModulPartDescriptionID = 136,
                    IsNeeded = true,
                    Description="keine",
                    Name="Voraussetzungen(inhaltich)",
                    ModulID = 8                    
                },
                new ModulPartDescription{
                    ModulPartDescriptionID = 137,
                    IsNeeded = true,
                    Description="Grundkenntnisse der diskreten Geometrie",
                    Name="Lernziele",
                    ModulID = 8                    
                },
                new ModulPartDescription{
                    ModulPartDescriptionID = 138,
                    IsNeeded = true,
                    Description="Standardverfahren und Vorgehensweisen im Feld der diskreten Geometrie",
                    Name="Inhalt",
                    ModulID = 8                    
                },
                new ModulPartDescription{
                    ModulPartDescriptionID = 139,
                    IsNeeded = true,
                    Description="Vorlesungsscript (verfügbar auf der Homepage)",
                    Name="Literatur",
                    ModulID = 8                    
                },
                new ModulPartDescription{
                    ModulPartDescriptionID = 140,
                    IsNeeded = true,
                    Description="Vorlesung",
                    Name="Lehr- und Lernformen",
                    ModulID = 8                    
                },
                new ModulPartDescription{
                    ModulPartDescriptionID = 141,
                    IsNeeded = true,
                    Description="10",
                    Name="Arbeitsaufwand",
                    ModulID = 8                    
                },
                new ModulPartDescription{
                    ModulPartDescriptionID = 142,
                    IsNeeded = true,
                    Description="Klausur",
                    Name="Bewertungsmethode",
                    ModulID = 8                    
                },
                new ModulPartDescription{
                    ModulPartDescriptionID = 143,
                    IsNeeded = true,
                    Description="keine",
                    Name="Vorraussetzungen(Formal)",
                    ModulID = 8                    
                },
                new ModulPartDescription{
                    ModulPartDescriptionID = 144,
                    IsNeeded = true,
                    Description="6pkt Klausur 2pkt Übung",
                    Name="Notenbildung",
                    ModulID = 8                    
                },
                
                
                
				
				
				
                new ModulPartDescription{
                    ModulPartDescriptionID = 145,
                    IsNeeded = true,
                    Description="EZT",
                    Name="Kürzel",
                    ModulID = 9                    
                },
                new ModulPartDescription{
                    ModulPartDescriptionID = 146,
                    IsNeeded = true,
                    Description="Elementare Zahlentheorie",
                    Name="Name",
                    ModulID = 9                    
                },
                new ModulPartDescription{
                    ModulPartDescriptionID = 147,
                    IsNeeded = true,
                    Description="4",
                    Name="Leistungspunkte",
                    ModulID = 9                    
                },
                new ModulPartDescription{
                    ModulPartDescriptionID = 148,
                    IsNeeded = true,
                    Description="2",
                    Name="Wochenstunden",
                    ModulID = 9                    
                },
                new ModulPartDescription{
                    ModulPartDescriptionID = 149,
                    IsNeeded = true,
                    Description="Deutsch",
                    Name="Sprache",
                    ModulID = 9                    
                },
                new ModulPartDescription{
                    ModulPartDescriptionID = 150,
                    IsNeeded = true,
                    Description="jedes 2. Semester",
                    Name="Turnus",
                    ModulID = 9                    
                },
                new ModulPartDescription{
                    ModulPartDescriptionID = 152,
                    IsNeeded = true,
                    Description="Stefan Wewers",
                    Name="Dozent",
                    ModulID = 9                    
                },
                new ModulPartDescription{
                    ModulPartDescriptionID = 153,
                    IsNeeded = true,
                    Description="Informatik, Medieninformatik, Software Engeneering",
                    Name="Einordnung in Studiengänge",
                    ModulID = 9                    
                },
                new ModulPartDescription{
                    ModulPartDescriptionID = 154,
                    IsNeeded = true,
                    Description="Grundkenntnisse über Lineare Algebra und Analysis",
                    Name="Voraussetzungen(inhaltich)",
                    ModulID = 9                    
                },
                new ModulPartDescription{
                    ModulPartDescriptionID = 155,
                    IsNeeded = true,
                    Description="Theorie verschiedener Zahlen und Zahlensysteme",
                    Name="Lernziele",
                    ModulID = 9                    
                },
                new ModulPartDescription{
                    ModulPartDescriptionID = 156,
                    IsNeeded = true,
                    Description="gar manigfaltiger Natur",
                    Name="Inhalt",
                    ModulID = 9                    
                },
                new ModulPartDescription{
                    ModulPartDescriptionID = 157,
                    IsNeeded = true,
                    Description="Vorlesungsscript (verfügbar auf der Homepage)",
                    Name="Literatur",
                    ModulID = 9                    
                },
                new ModulPartDescription{
                    ModulPartDescriptionID = 158,
                    IsNeeded = true,
                    Description="Vorlesung",
                    Name="Lehr- und Lernformen",
                    ModulID = 9                    
                },
                new ModulPartDescription{
                    ModulPartDescriptionID = 159,
                    IsNeeded = true,
                    Description="6",
                    Name="Arbeitsaufwand",
                    ModulID = 9                    
                },
                new ModulPartDescription{
                    ModulPartDescriptionID = 160,
                    IsNeeded = true,
                    Description="Klausur",
                    Name="Bewertungsmethode",
                    ModulID = 9                    
                },
                new ModulPartDescription{
                    ModulPartDescriptionID = 161,
                    IsNeeded = true,
                    Description="keine",
                    Name="Vorraussetzungen(Formal)",
                    ModulID = 9                    
                },
                new ModulPartDescription{
                    ModulPartDescriptionID = 162,
                    IsNeeded = true,
                    Description="4pkt Klausur",
                    Name="Notenbildung",
                    ModulID = 9                    
                },
                
                
                
				
				
				
                new ModulPartDescription{
                    ModulPartDescriptionID = 163,
                    IsNeeded = true,
                    Description="EdDG",
                    Name="Kürzel",
                    ModulID = 10                    
                },
                new ModulPartDescription{
                    ModulPartDescriptionID = 164,
                    IsNeeded = true,
                    Description="Elemente der Differenzialgleichungen",
                    Name="Name",
                    ModulID = 10                  
                },
                new ModulPartDescription{
                    ModulPartDescriptionID = 165,
                    IsNeeded = true,
                    Description="4",
                    Name="Leistungspunkte",
                    ModulID = 10                
                },
                new ModulPartDescription{
                    ModulPartDescriptionID = 166,
                    IsNeeded = true,
                    Description="2",
                    Name="Wochenstunden",
                    ModulID = 10                    
                },
                new ModulPartDescription{
                    ModulPartDescriptionID = 167,
                    IsNeeded = true,
                    Description="Deutsch",
                    Name="Sprache",
                    ModulID = 10                    
                },
                new ModulPartDescription{
                    ModulPartDescriptionID = 168,
                    IsNeeded = true,
                    Description="jedes 2. Semester",
                    Name="Turnus",
                    ModulID = 10                    
                },
                new ModulPartDescription{
                    ModulPartDescriptionID = 170,
                    IsNeeded = true,
                    Description="Wolfgang Arendt",
                    Name="Dozent",
                    ModulID = 10                    
                },
                new ModulPartDescription{
                    ModulPartDescriptionID = 171,
                    IsNeeded = true,
                    Description="Informatik, Medieninformatik, Software Engeneering",
                    Name="Einordnung in Studiengänge",
                    ModulID = 10                    
                },
                new ModulPartDescription{
                    ModulPartDescriptionID = 172,
                    IsNeeded = true,
                    Description="Höhere Mathematik, Grundkenntnisse über Differenzialgleichungen",
                    Name="Voraussetzungen(inhaltich)",
                    ModulID = 10                    
                },
                new ModulPartDescription{
                    ModulPartDescriptionID = 173,
                    IsNeeded = true,
                    Description="Verständnis ausgewählter Elemente der Differenzialgleichungen",
                    Name="Lernziele",
                    ModulID = 10                    
                },
                new ModulPartDescription{
                    ModulPartDescriptionID = 174,
                    IsNeeded = true,
                    Description="Studierende lernen besser mit Differenzialgleichungen umzugehen",
                    Name="Inhalt",
                    ModulID = 10                    
                },
                new ModulPartDescription{
                    ModulPartDescriptionID = 175,
                    IsNeeded = true,
                    Description="Vorlesungsscript (verfügbar auf der Homepage)",
                    Name="Literatur",
                    ModulID = 10                    
                },
                new ModulPartDescription{
                    ModulPartDescriptionID = 176,
                    IsNeeded = true,
                    Description="Vorlesung",
                    Name="Lehr- und Lernformen",
                    ModulID = 10                    
                },
                new ModulPartDescription{
                    ModulPartDescriptionID = 177,
                    IsNeeded = true,
                    Description="6",
                    Name="Arbeitsaufwand",
                    ModulID = 10                    
                },
                new ModulPartDescription{
                    ModulPartDescriptionID = 178,
                    IsNeeded = true,
                    Description="Klausur",
                    Name="Bewertungsmethode",
                    ModulID = 10                    
                },
                new ModulPartDescription{
                    ModulPartDescriptionID = 179,
                    IsNeeded = true,
                    Description="keine",
                    Name="Vorraussetzungen(Formal)",
                    ModulID = 10                    
                },
                new ModulPartDescription{
                    ModulPartDescriptionID = 180,
                    IsNeeded = true,
                    Description="2pkt Klausur / 2pkt Übung",
                    Name="Notenbildung",
                    ModulID = 10                   
                },
                
                
                new ModulPartDescription{
                    ModulPartDescriptionID = 181,
                    IsNeeded = true,
                    Description="EdI",
                    Name="Kürzel",
                    ModulID = 11                    
                },
                new ModulPartDescription{
                    ModulPartDescriptionID = 182,
                    IsNeeded = true,
                    Description="Einführung in die Informatik",
                    Name="Name",
                    ModulID = 11                    
                },
                new ModulPartDescription{
                    ModulPartDescriptionID = 183,
                    IsNeeded = true,
                    Description="8",
                    Name="Leistungspunkte",
                    ModulID = 11                    
                },
                new ModulPartDescription{
                    ModulPartDescriptionID = 184,
                    IsNeeded = true,
                    Description="4",
                    Name="Wochenstunden",
                    ModulID = 11                    
                },
                new ModulPartDescription{
                    ModulPartDescriptionID = 185,
                    IsNeeded = true,
                    Description="Deutsch",
                    Name="Sprache",
                    ModulID = 11                    
                },
                new ModulPartDescription{
                    ModulPartDescriptionID = 186,
                    IsNeeded = true,
                    Description="jedes Semester",
                    Name="Turnus",
                    ModulID = 11                    
                },
                new ModulPartDescription{
                    ModulPartDescriptionID = 188,
                    IsNeeded = true,
                    Description="Peter Dadam",
                    Name="Dozent",
                    ModulID = 11                    
                },
                new ModulPartDescription{
                    ModulPartDescriptionID = 189,
                    IsNeeded = true,
                    Description="Informatik, Medieninformatik, Software Engeneering",
                    Name="Einordnung in Studiengänge",
                    ModulID = 11                    
                },
                new ModulPartDescription{
                    ModulPartDescriptionID = 190,
                    IsNeeded = true,
                    Description="Fähigkeit einen Computer einzuschalten",
                    Name="Voraussetzungen(inhaltich)",
                    ModulID = 11                    
                },
                new ModulPartDescription{
                    ModulPartDescriptionID = 191,
                    IsNeeded = true,
                    Description="Basiskenntnisse in der objektorientierten Programmierung am Beispiel von Java",
                    Name="Lernziele",
                    ModulID = 11                    
                },
                new ModulPartDescription{
                    ModulPartDescriptionID = 192,
                    IsNeeded = true,
                    Description="Die Studierenden lernen den Umgang mit Java und Objekt Orientierten Programmiersprachen im Allgemeinen",
                    Name="Inhalt",
                    ModulID = 11                    
                },
                new ModulPartDescription{
                    ModulPartDescriptionID = 193,
                    IsNeeded = true,
                    Description="Vorlesungsscript (ist im SLC verfügbar)",
                    Name="Literatur",
                    ModulID = 11                    
                },
                new ModulPartDescription{
                    ModulPartDescriptionID = 194,
                    IsNeeded = true,
                    Description="Vorlesung",
                    Name="Lehr- und Lernformen",
                    ModulID = 11                    
                },
                new ModulPartDescription{
                    ModulPartDescriptionID = 195,
                    IsNeeded = true,
                    Description="8",
                    Name="Arbeitsaufwand",
                    ModulID = 11                    
                },
                new ModulPartDescription{
                    ModulPartDescriptionID = 196,
                    IsNeeded = true,
                    Description="Klausur",
                    Name="Bewertungsmethode",
                    ModulID = 11                    
                },
                new ModulPartDescription{
                    ModulPartDescriptionID = 197,
                    IsNeeded = true,
                    Description="keine",
                    Name="Vorraussetzungen(Formal)",
                    ModulID = 11                    
                },
                new ModulPartDescription{
                    ModulPartDescriptionID = 198,
                    IsNeeded = true,
                    Description="Notenbildung",
                    Name="6pkt Klausur 2pkt Übung",
                    ModulID = 11                   
                },
                
                


                new ModulPartDescription{
                    ModulPartDescriptionID = 199,
                    IsNeeded = true,
                    Description="PvS",
                    Name="Kürzel",
                    ModulID = 12                    
                },
                new ModulPartDescription{
                    ModulPartDescriptionID = 200,
                    IsNeeded = true,
                    Description="Programmierung von Systemen",
                    Name="Name",
                    ModulID = 12                    
                },
                new ModulPartDescription{
                    ModulPartDescriptionID = 201,
                    IsNeeded = true,
                    Description="8",
                    Name="Leistungspunkte",
                    ModulID = 12                    
                },
                new ModulPartDescription{
                    ModulPartDescriptionID = 202,
                    IsNeeded = true,
                    Description="4",
                    Name="Wochenstunden",
                    ModulID = 12                    
                },
                new ModulPartDescription{
                    ModulPartDescriptionID = 203,
                    IsNeeded = true,
                    Description="Deutsch",
                    Name="Sprache",
                    ModulID = 12                    
                },
                new ModulPartDescription{
                    ModulPartDescriptionID = 204,
                    IsNeeded = true,
                    Description="jedes 2. Semester",
                    Name="Turnus",
                    ModulID = 12                    
                },
                new ModulPartDescription{
                    ModulPartDescriptionID = 206,
                    IsNeeded = true,
                    Description="Hauck",
                    Name="Dozent",
                    ModulID = 12                    
                },
                new ModulPartDescription{
                    ModulPartDescriptionID = 207,
                    IsNeeded = true,
                    Description="Informatik, Medieninformatik, Software Engeneering",
                    Name="Einordnung in Studiengänge",
                    ModulID = 12                    
                },
                new ModulPartDescription{
                    ModulPartDescriptionID = 208,
                    IsNeeded = true,
                    Description="Einführung in die Informatik",
                    Name="Voraussetzungen(inhaltich)",
                    ModulID = 12                    
                },
                new ModulPartDescription{
                    ModulPartDescriptionID = 209,
                    IsNeeded = true,
                    Description="Weiterführende Kenntnisse der OO Programmierung.",
                    Name="Lernziele",
                    ModulID = 12                    
                },
                new ModulPartDescription{
                    ModulPartDescriptionID = 210,
                    IsNeeded = true,
                    Description="Die Studierenden bekommen Einblick in weiterführende, objektorientierte Konzepte sowie Oberflächenprogrammierung in Java",
                    Name="Inhalt",
                    ModulID = 12                    
                },
                new ModulPartDescription{
                    ModulPartDescriptionID = 211,
                    IsNeeded = true,
                    Description="Vorlesungsscript (ist im SLC verfügbar)",
                    Name="Literatur",
                    ModulID = 12                    
                },
                new ModulPartDescription{
                    ModulPartDescriptionID = 212,
                    IsNeeded = true,
                    Description="Vorlesung",
                    Name="Lehr- und Lernformen",
                    ModulID = 12                    
                },
                new ModulPartDescription{
                    ModulPartDescriptionID = 213,
                    IsNeeded = true,
                    Description="8",
                    Name="Arbeitsaufwand",
                    ModulID = 12                    
                },
                new ModulPartDescription{
                    ModulPartDescriptionID = 214,
                    IsNeeded = true,
                    Description="Klausur",
                    Name="Bewertungsmethode",
                    ModulID = 12                    
                },
                new ModulPartDescription{
                    ModulPartDescriptionID = 215,
                    IsNeeded = true,
                    Description="keine",
                    Name="Vorraussetzungen(Formal)",
                    ModulID = 12                    
                },
                new ModulPartDescription{
                    ModulPartDescriptionID = 216,
                    IsNeeded = true,
                    Description="Notenbildung",
                    Name="4pkt Klausur 2pkt Übung",
                    ModulID = 12                 
                },
                
                


                new ModulPartDescription{
                    ModulPartDescriptionID = 217,
                    IsNeeded = true,
                    Description="IS",
                    Name="Kürzel",
                    ModulID = 13                    
                },
                new ModulPartDescription{
                    ModulPartDescriptionID = 218,
                    IsNeeded = true,
                    Description="Informationssysteme",
                    Name="Name",
                    ModulID = 13                    
                },
                new ModulPartDescription{
                    ModulPartDescriptionID = 219,
                    IsNeeded = true,
                    Description="4",
                    Name="Leistungspunkte",
                    ModulID = 13                    
                },
                new ModulPartDescription{
                    ModulPartDescriptionID = 220,
                    IsNeeded = true,
                    Description="2",
                    Name="Wochenstunden",
                    ModulID = 13                    
                },
                new ModulPartDescription{
                    ModulPartDescriptionID = 221,
                    IsNeeded = true,
                    Description="Deutsch",
                    Name="Sprache",
                    ModulID = 13                    
                },
                new ModulPartDescription{
                    ModulPartDescriptionID = 222,
                    IsNeeded = true,
                    Description="jedes 2. Semester",
                    Name="Turnus",
                    ModulID = 13                    
                },
                new ModulPartDescription{
                    ModulPartDescriptionID = 224,
                    IsNeeded = true,
                    Description="Peter Dadam",
                    Name="Dozent",
                    ModulID = 13                    
                },
                new ModulPartDescription{
                    ModulPartDescriptionID = 225,
                    IsNeeded = true,
                    Description="Informatik, Medieninformatik, Software Engeneering",
                    Name="Einordnung in Studiengänge",
                    ModulID = 13                    
                },
                new ModulPartDescription{
                    ModulPartDescriptionID = 226,
                    IsNeeded = true,
                    Description="Programmierung von Systemen",
                    Name="Voraussetzungen(inhaltich)",
                    ModulID = 13                    
                },
                new ModulPartDescription{
                    ModulPartDescriptionID = 227,
                    IsNeeded = true,
                    Description="Kenntnisse in Relationalen Datenbanken und Prozessmodellierung",
                    Name="Lernziele",
                    ModulID = 13                    
                },
                new ModulPartDescription{
                    ModulPartDescriptionID = 228,
                    IsNeeded = true,
                    Description="Die Studierenden lernen weiterführende Konzepte zu relationalen Datenbanken sowie die modellierung von Prozessen mittels AristaFlow",
                    Name="Inhalt",
                    ModulID = 13                    
                },
                new ModulPartDescription{
                    ModulPartDescriptionID = 229,
                    IsNeeded = true,
                    Description="Vorlesungsscript (ist im SLC verfügbar)",
                    Name="Literatur",
                    ModulID = 13                    
                },
                new ModulPartDescription{
                    ModulPartDescriptionID = 230,
                    IsNeeded = true,
                    Description="Vorlesung",
                    Name="Lehr- und Lernformen",
                    ModulID = 13                    
                },
                new ModulPartDescription{
                    ModulPartDescriptionID = 231,
                    IsNeeded = true,
                    Description="80",
                    Name="Arbeitsaufwand",
                    ModulID = 13                    
                },
                new ModulPartDescription{
                    ModulPartDescriptionID = 232,
                    IsNeeded = true,
                    Description="Klausur",
                    Name="Bewertungsmethode",
                    ModulID = 13                    
                },
                new ModulPartDescription{
                    ModulPartDescriptionID = 233,
                    IsNeeded = true,
                    Description="keine",
                    Name="Vorraussetzungen(Formal)",
                    ModulID = 13                    
                },
                new ModulPartDescription{
                    ModulPartDescriptionID = 234,
                    IsNeeded = true,
                    Description="2pkt Klausur 2pkt Übung",
                    Name="Notenbildung",
                    ModulID = 13                    
                },
                
                
				
				
				
                new ModulPartDescription{
                    ModulPartDescriptionID = 235,
                    IsNeeded = true,
                    Description="PdP",
                    Name="Kürzel",
                    ModulID = 14                    
                },
                new ModulPartDescription{
                    ModulPartDescriptionID = 236,
                    IsNeeded = true,
                    Description="Paradigmen der Programmierung.",
                    Name="Name",
                    ModulID = 14                    
                },
                new ModulPartDescription{
                    ModulPartDescriptionID = 237,
                    IsNeeded = true,
                    Description="4",
                    Name="Leistungspunkte",
                    ModulID = 14                    
                },
                new ModulPartDescription{
                    ModulPartDescriptionID = 238,
                    IsNeeded = true,
                    Description="2",
                    Name="Wochenstunden",
                    ModulID = 14                    
                },
                new ModulPartDescription{
                    ModulPartDescriptionID = 239,
                    IsNeeded = true,
                    Description="Deutsch",
                    Name="Sprache",
                    ModulID = 14                    
                },
                new ModulPartDescription{
                    ModulPartDescriptionID = 240,
                    IsNeeded = true,
                    Description="jedes 2. Semester",
                    Name="Turnus",
                    ModulID = 14                    
                },
                new ModulPartDescription{
                    ModulPartDescriptionID = 242,
                    IsNeeded = true,
                    Description="Thom Frühwirth, Alexander Raschke",
                    Name="Dozent",
                    ModulID = 14                    
                },
                new ModulPartDescription{
                    ModulPartDescriptionID = 243,
                    IsNeeded = true,
                    Description="Informatik, Medieninformatik, Software Engeneering",
                    Name="Einordnung in Studiengänge",
                    ModulID = 14                    
                },
                new ModulPartDescription{
                    ModulPartDescriptionID = 244,
                    IsNeeded = true,
                    Description="keine",
                    Name="Voraussetzungen(inhaltich)",
                    ModulID = 14                    
                },
                new ModulPartDescription{
                    ModulPartDescriptionID = 245,
                    IsNeeded = true,
                    Description="Basiskenntnise in Funktionaler- und Logikbasierter Programmierung, vorallem CHR by Thom Frühwirth",
                    Name="Lernziele",
                    ModulID = 14                    
                },
                new ModulPartDescription{
                    ModulPartDescriptionID = 246,
                    IsNeeded = true,
                    Description="Funktionale Programmierung am Beispiel Haskell, Logikbasierte Programmierung am Beispiel von Prolog und CHR by Thom Frühwirth",
                    Name="Inhalt",
                    ModulID = 14                    
                },
                new ModulPartDescription{
                    ModulPartDescriptionID = 247,
                    IsNeeded = true,
                    Description="Vorlesungsscript (verfügbar auf der Numerik Homepage) sowie sämmtliche Bücher by Thom Frühwirth",
                    Name="Literatur",
                    ModulID = 14                    
                },
                new ModulPartDescription{
                    ModulPartDescriptionID = 248,
                    IsNeeded = true,
                    Description="Vorlesung",
                    Name="Lehr- und Lernformen",
                    ModulID = 14                    
                },
                new ModulPartDescription{
                    ModulPartDescriptionID = 249,
                    IsNeeded = true,
                    Description="8",
                    Name="Arbeitsaufwand",
                    ModulID = 14                    
                },
                new ModulPartDescription{
                    ModulPartDescriptionID = 250,
                    IsNeeded = true,
                    Description="Klausur",
                    Name="Bewertungsmethode",
                    ModulID = 14                    
                },
                new ModulPartDescription{
                    ModulPartDescriptionID = 251,
                    IsNeeded = true,
                    Description="keine",
                    Name="Vorraussetzungen(Formal)",
                    ModulID = 14                    
                },
                new ModulPartDescription{
                    ModulPartDescriptionID = 252,
                    IsNeeded = true,
                    Description="4pkt Klausur 2pkt Übung",
                    Name="Notenbildung",
                    ModulID = 14                    
                },
                
                
				
				
				
                new ModulPartDescription{
                    ModulPartDescriptionID = 253,
                    IsNeeded = true,
                    Description="FGdI",
                    Name="Kürzel",
                    ModulID = 15                    
                },
                new ModulPartDescription{
                    ModulPartDescriptionID = 254,
                    IsNeeded = true,
                    Description="Formale Grundlagen der Informatik",
                    Name="Name",
                    ModulID = 15                    
                },
                new ModulPartDescription{
                    ModulPartDescriptionID = 255,
                    IsNeeded = true,
                    Description="8",
                    Name="Leistungspunkte",
                    ModulID = 15                    
                },
                new ModulPartDescription{
                    ModulPartDescriptionID = 256,
                    IsNeeded = true,
                    Description="4",
                    Name="Wochenstunden",
                    ModulID = 15                    
                },
                new ModulPartDescription{
                    ModulPartDescriptionID = 257,
                    IsNeeded = true,
                    Description="Deutsch",
                    Name="Sprache",
                    ModulID = 15                    
                },
                new ModulPartDescription{
                    ModulPartDescriptionID = 258,
                    IsNeeded = true,
                    Description="jedes 2. Semester",
                    Name="Turnus",
                    ModulID = 15                    
                },
                new ModulPartDescription{
                    ModulPartDescriptionID = 260,
                    IsNeeded = true,
                    Description="Uwe Schöning",
                    Name="Dozent",
                    ModulID = 15                    
                },
                new ModulPartDescription{
                    ModulPartDescriptionID = 261,
                    IsNeeded = true,
                    Description="Informatik, Medieninformatik, Software Engeneering",
                    Name="Einordnung in Studiengänge",
                    ModulID = 15                    
                },
                new ModulPartDescription{
                    ModulPartDescriptionID = 262,
                    IsNeeded = true,
                    Description="keine",
                    Name="Voraussetzungen(inhaltich)",
                    ModulID = 15                    
                },
                new ModulPartDescription{
                    ModulPartDescriptionID = 263,
                    IsNeeded = true,
                    Description="Formale Sprachen, Grammatiken, Automaten, Turing Maschinen",
                    Name="Lernziele",
                    ModulID = 15                    
                },
                new ModulPartDescription{
                    ModulPartDescriptionID = 264,
                    IsNeeded = true,
                    Description="Studierende bekommen einen kurzen einblick in die wichtigsten Konzepte der Theoretischen Informatik.",
                    Name="Inhalt",
                    ModulID = 15                    
                },
                new ModulPartDescription{
                    ModulPartDescriptionID = 265,
                    IsNeeded = true,
                    Description="Vorlesungsscript (wird in der Vorlesung ausgeteilt)",
                    Name="Literatur",
                    ModulID = 15                    
                },
                new ModulPartDescription{
                    ModulPartDescriptionID = 266,
                    IsNeeded = true,
                    Description="Vorlesung",
                    Name="Lehr- und Lernformen",
                    ModulID = 15                    
                },
                new ModulPartDescription{
                    ModulPartDescriptionID = 267,
                    IsNeeded = true,
                    Description="8",
                    Name="Arbeitsaufwand",
                    ModulID = 15                    
                },
                new ModulPartDescription{
                    ModulPartDescriptionID = 268,
                    IsNeeded = true,
                    Description="Klausur",
                    Name="Bewertungsmethode",
                    ModulID = 15                    
                },
                new ModulPartDescription{
                    ModulPartDescriptionID = 269,
                    IsNeeded = true,
                    Description="keine",
                    Name="Vorraussetzungen(Formal)",
                    ModulID = 15                    
                },
                new ModulPartDescription{
                    ModulPartDescriptionID = 270,
                    IsNeeded = true,
                    Description="4pkt Klausur 2pkt Übung",
                    Name="Notenbildung",
                    ModulID = 15                    
                },
                
                
                
                
				
				
				
                new ModulPartDescription{
                    ModulPartDescriptionID = 271,
                    IsNeeded = true,
                    Description="Lgk",
                    Name="Kürzel",
                    ModulID = 16                    
                },
                new ModulPartDescription{
                    ModulPartDescriptionID = 272,
                    IsNeeded = true,
                    Description="Logik",
                    Name="Name",
                    ModulID = 16                    
                },
                new ModulPartDescription{
                    ModulPartDescriptionID = 273,
                    IsNeeded = true,
                    Description="4",
                    Name="Leistungspunkte",
                    ModulID = 16                    
                },
                new ModulPartDescription{
                    ModulPartDescriptionID = 274,
                    IsNeeded = true,
                    Description="2",
                    Name="Wochenstunden",
                    ModulID = 16                    
                },
                new ModulPartDescription{
                    ModulPartDescriptionID = 275,
                    IsNeeded = true,
                    Description="Deutsch",
                    Name="Sprache",
                    ModulID = 16                    
                },
                new ModulPartDescription{
                    ModulPartDescriptionID = 276,
                    IsNeeded = true,
                    Description="jedes 2. Semester",
                    Name="Turnus",
                    ModulID = 16                    
                },
                new ModulPartDescription{
                    ModulPartDescriptionID = 278,
                    IsNeeded = true,
                    Description="Uwe Schöning",
                    Name="Dozent",
                    ModulID = 16                    
                },
                new ModulPartDescription{
                    ModulPartDescriptionID = 279,
                    IsNeeded = true,
                    Description="Informatik",
                    Name="Einordnung in Studiengänge",
                    ModulID = 16                    
                },
                new ModulPartDescription{
                    ModulPartDescriptionID = 280,
                    IsNeeded = true,
                    Description="Formale Grundlagen der Informatik",
                    Name="Voraussetzungen(inhaltich)",
                    ModulID = 16                    
                },
                new ModulPartDescription{
                    ModulPartDescriptionID = 281,
                    IsNeeded = true,
                    Description="Boolsche Logik, Quantorenlogik erster Ordnung, Logikbasierte Programmierung",
                    Name="Lernziele",
                    ModulID = 16                    
                },
                new ModulPartDescription{
                    ModulPartDescriptionID = 282,
                    IsNeeded = true,
                    Description="Studierende lernen verschiedene Konzepte der Logik in der Informatik kennen.",
                    Name="Inhalt",
                    ModulID = 16                    
                },
                new ModulPartDescription{
                    ModulPartDescriptionID = 283,
                    IsNeeded = true,
                    Description="Vorlesungsscript (wird in der Vorlesung ausgeteilt)",
                    Name="Literatur",
                    ModulID = 16                    
                },
                new ModulPartDescription{
                    ModulPartDescriptionID = 284,
                    IsNeeded = true,
                    Description="Vorlesung",
                    Name="Lehr- und Lernformen",
                    ModulID = 16                    
                },
                new ModulPartDescription{
                    ModulPartDescriptionID = 285,
                    IsNeeded = true,
                    Description="8",
                    Name="Arbeitsaufwand",
                    ModulID = 16                    
                },
                new ModulPartDescription{
                    ModulPartDescriptionID = 286,
                    IsNeeded = true,
                    Description="Klausur",
                    Name="Bewertungsmethode",
                    ModulID = 16                    
                },
                new ModulPartDescription{
                    ModulPartDescriptionID = 287,
                    IsNeeded = true,
                    Description="keine",
                    Name="Vorraussetzungen(Formal)",
                    ModulID = 16                    
                },
                new ModulPartDescription{
                    ModulPartDescriptionID = 288,
                    IsNeeded = true,
                    Description="2pkt Klausur 2pkt Übung",
                    Name="Notenbildung",
                    ModulID = 16                    
                },
                
                
                
                
				
				
				
                new ModulPartDescription{
                    ModulPartDescriptionID = 289,
                    IsNeeded = true,
                    Description="BuK",
                    Name="Kürzel",
                    ModulID = 17                    
                },
                new ModulPartDescription{
                    ModulPartDescriptionID = 290,
                    IsNeeded = true,
                    Description="Berechenbarkeit und Komplexität",
                    Name="Name",
                    ModulID = 17                    
                },
                new ModulPartDescription{
                    ModulPartDescriptionID = 291,
                    IsNeeded = true,
                    Description="4",
                    Name="Leistungspunkte",
                    ModulID = 17                    
                },
                new ModulPartDescription{
                    ModulPartDescriptionID = 292,
                    IsNeeded = true,
                    Description="2",
                    Name="Wochenstunden",
                    ModulID = 17                    
                },
                new ModulPartDescription{
                    ModulPartDescriptionID = 293,
                    IsNeeded = true,
                    Description="Deutsch",
                    Name="Sprache",
                    ModulID = 17                    
                },
                new ModulPartDescription{
                    ModulPartDescriptionID = 294,
                    IsNeeded = true,
                    Description="jedes 2. Semester",
                    Name="Turnus",
                    ModulID = 17                    
                },
                new ModulPartDescription{
                    ModulPartDescriptionID = 296,
                    IsNeeded = true,
                    Description="Jacobo Torán",
                    Name="Dozent",
                    ModulID = 17                    
                },
                new ModulPartDescription{
                    ModulPartDescriptionID = 297,
                    IsNeeded = true,
                    Description="Informatik",
                    Name="Einordnung in Studiengänge",
                    ModulID = 17                    
                },
                new ModulPartDescription{
                    ModulPartDescriptionID = 298,
                    IsNeeded = true,
                    Description="Algorithmen und Datenstrukturen, Logik",
                    Name="Voraussetzungen(inhaltich)",
                    ModulID = 17                    
                },
                new ModulPartDescription{
                    ModulPartDescriptionID = 299,
                    IsNeeded = true,
                    Description="Entscheidbarkeit von Problemen, Berechenbarkeit, Komplexitätstheorie",
                    Name="Lernziele",
                    ModulID = 17                    
                },
                new ModulPartDescription{
                    ModulPartDescriptionID = 300,
                    IsNeeded = true,
                    Description="LOOP/GOTO/WHILE-Programmierung, Turing Maschinen, Primitive- und µ-Rekursion, Ackermann-Funktion, Komplexitätstheorie",
                    Name="Inhalt",
                    ModulID = 17                    
                },
                new ModulPartDescription{
                    ModulPartDescriptionID = 301,
                    IsNeeded = true,
                    Description="Vorlesungsscript (wird in der Vorlesung ausgeteilt)",
                    Name="Literatur",
                    ModulID = 17                    
                },
                new ModulPartDescription{
                    ModulPartDescriptionID = 302,
                    IsNeeded = true,
                    Description="Vorlesung",
                    Name="Lehr- und Lernformen",
                    ModulID = 17                    
                },
                new ModulPartDescription{
                    ModulPartDescriptionID = 303,
                    IsNeeded = true,
                    Description="8",
                    Name="Arbeitsaufwand",
                    ModulID = 17                    
                },
                new ModulPartDescription{
                    ModulPartDescriptionID = 304,
                    IsNeeded = true,
                    Description="Klausur",
                    Name="Bewertungsmethode",
                    ModulID = 17                    
                },
                new ModulPartDescription{
                    ModulPartDescriptionID = 305,
                    IsNeeded = true,
                    Description="keine",
                    Name="Vorraussetzungen(Formal)",
                    ModulID = 17                    
                },
                new ModulPartDescription{
                    ModulPartDescriptionID = 306,
                    IsNeeded = true,
                    Description="2pkt Klausur 2pkt Übung",
                    Name="Notenbildung",
                    ModulID = 17                    
                },
                
                
                
				
				
				
                new ModulPartDescription{
                    ModulPartDescriptionID = 307,
                    IsNeeded = true,
                    Description="Algo",
                    Name="Kürzel",
                    ModulID = 18                    
                },
                new ModulPartDescription{
                    ModulPartDescriptionID = 308,
                    IsNeeded = true,
                    Description="Algorithmen und Datenstrukturen",
                    Name="Name",
                    ModulID = 18                    
                },
                new ModulPartDescription{
                    ModulPartDescriptionID = 309,
                    IsNeeded = true,
                    Description="8",
                    Name="Leistungspunkte",
                    ModulID = 18                    
                },
                new ModulPartDescription{
                    ModulPartDescriptionID = 310,
                    IsNeeded = true,
                    Description="4",
                    Name="Wochenstunden",
                    ModulID = 18                    
                },
                new ModulPartDescription{
                    ModulPartDescriptionID = 311,
                    IsNeeded = true,
                    Description="Deutsch",
                    Name="Sprache",
                    ModulID = 18                    
                },
                new ModulPartDescription{
                    ModulPartDescriptionID = 312,
                    IsNeeded = true,
                    Description="jedes 2. Semester",
                    Name="Turnus",
                    ModulID = 18                    
                },
                new ModulPartDescription{
                    ModulPartDescriptionID = 314,
                    IsNeeded = true,
                    Description="Uwe Schöning",
                    Name="Dozent",
                    ModulID = 18                    
                },
                new ModulPartDescription{
                    ModulPartDescriptionID = 315,
                    IsNeeded = true,
                    Description="Informatik, Medieninformatik, Software Engeneering",
                    Name="Einordnung in Studiengänge",
                    ModulID = 18                    
                },
                new ModulPartDescription{
                    ModulPartDescriptionID = 316,
                    IsNeeded = true,
                    Description="Logik",
                    Name="Voraussetzungen(inhaltich)",
                    ModulID = 18                    
                },
                new ModulPartDescription{
                    ModulPartDescriptionID = 317,
                    IsNeeded = true,
                    Description="Analyieren und Aufstellen bekannter standard-Algorithmen",
                    Name="Lernziele",
                    ModulID = 18                    
                },
                new ModulPartDescription{
                    ModulPartDescriptionID = 318,
                    IsNeeded = true,
                    Description="Studierende lernen grundlegende Algorithmen, sowie deren Funktionsprinzip kennen.",
                    Name="Inhalt",
                    ModulID = 18                    
                },
                new ModulPartDescription{
                    ModulPartDescriptionID = 319,
                    IsNeeded = true,
                    Description="Vorlesungsscript (wird in der Vorlesung verteilt)",
                    Name="Literatur",
                    ModulID = 18                    
                },
                new ModulPartDescription{
                    ModulPartDescriptionID = 320,
                    IsNeeded = true,
                    Description="Vorlesung",
                    Name="Lehr- und Lernformen",
                    ModulID = 18                    
                },
                new ModulPartDescription{
                    ModulPartDescriptionID = 321,
                    IsNeeded = true,
                    Description="10",
                    Name="Arbeitsaufwand",
                    ModulID = 18                    
                },
                new ModulPartDescription{
                    ModulPartDescriptionID = 322,
                    IsNeeded = true,
                    Description="Klausur",
                    Name="Bewertungsmethode",
                    ModulID = 18                    
                },
                new ModulPartDescription{
                    ModulPartDescriptionID = 323,
                    IsNeeded = true,
                    Description="keine",
                    Name="Vorraussetzungen(Formal)",
                    ModulID = 18                    
                },
                new ModulPartDescription{
                    ModulPartDescriptionID = 324,
                    IsNeeded = true,
                    Description="6pkt Klausur 2pkt Übung",
                    Name="Notenbildung",
                    ModulID = 18                    
                },
                
                
                
				
				
				
                new ModulPartDescription{
                    ModulPartDescriptionID = 325,
                    IsNeeded = true,
                    Description="GdBS",
                    Name="Kürzel",
                    ModulID = 19                    
                },
                new ModulPartDescription{
                    ModulPartDescriptionID = 326,
                    IsNeeded = true,
                    Description="Grundlagen der Betriebssysteme",
                    Name="Name",
                    ModulID = 19                    
                },
                new ModulPartDescription{
                    ModulPartDescriptionID = 327,
                    IsNeeded = true,
                    Description="8",
                    Name="Leistungspunkte",
                    ModulID = 19                    
                },
                new ModulPartDescription{
                    ModulPartDescriptionID = 328,
                    IsNeeded = true,
                    Description="4",
                    Name="Wochenstunden",
                    ModulID = 19                    
                },
                new ModulPartDescription{
                    ModulPartDescriptionID = 329,
                    IsNeeded = true,
                    Description="Deutsch",
                    Name="Sprache",
                    ModulID = 19                    
                },
                new ModulPartDescription{
                    ModulPartDescriptionID = 330,
                    IsNeeded = true,
                    Description="jedes 2. Semester",
                    Name="Turnus",
                    ModulID = 19                    
                },
                new ModulPartDescription{
                    ModulPartDescriptionID = 332,
                    IsNeeded = true,
                    Description="Heiko Falk",
                    Name="Dozent",
                    ModulID = 19                    
                },
                new ModulPartDescription{
                    ModulPartDescriptionID = 333,
                    IsNeeded = true,
                    Description="Informatik, Medieninformatik, Software Engeneering",
                    Name="Einordnung in Studiengänge",
                    ModulID = 19                    
                },
                new ModulPartDescription{
                    ModulPartDescriptionID = 334,
                    IsNeeded = true,
                    Description="keine",
                    Name="Voraussetzungen(inhaltich)",
                    ModulID = 19                    
                },
                new ModulPartDescription{
                    ModulPartDescriptionID = 335,
                    IsNeeded = true,
                    Description="Grundlegendes Verständnis über Funktionsweise und Aufbau von Betriebssystemen aller Art.",
                    Name="Lernziele",
                    ModulID = 19                    
                },
                new ModulPartDescription{
                    ModulPartDescriptionID = 336,
                    IsNeeded = true,
                    Description="Studierende lernen Aufbau und Funktionsweise von Windows und Linux kennen.",
                    Name="Inhalt",
                    ModulID = 19                    
                },
                new ModulPartDescription{
                    ModulPartDescriptionID = 337,
                    IsNeeded = true,
                    Description="Vorlesungsscript (verfügbar auf der Homepage)",
                    Name="Literatur",
                    ModulID = 19                    
                },
                new ModulPartDescription{
                    ModulPartDescriptionID = 338,
                    IsNeeded = true,
                    Description="Vorlesung",
                    Name="Lehr- und Lernformen",
                    ModulID = 19                    
                },
                new ModulPartDescription{
                    ModulPartDescriptionID = 339,
                    IsNeeded = true,
                    Description="60",
                    Name="Arbeitsaufwand",
                    ModulID = 19                    
                },
                new ModulPartDescription{
                    ModulPartDescriptionID = 340,
                    IsNeeded = true,
                    Description="Klausur",
                    Name="Bewertungsmethode",
                    ModulID = 19                    
                },
                new ModulPartDescription{
                    ModulPartDescriptionID = 341,
                    IsNeeded = true,
                    Description="keine",
                    Name="Vorraussetzungen(Formal)",
                    ModulID = 19                    
                },
                new ModulPartDescription{
                    ModulPartDescriptionID = 342,
                    IsNeeded = true,
                    Description="4pkt Klausur/2pkt Übung/2pkt Praktikum",
                    Name="Notenbildung",
                    ModulID = 19                    
                },
                
                
                
				
				
				
                new ModulPartDescription{
                    ModulPartDescriptionID = 343,
                    IsNeeded = true,
                    Description="GdRA",
                    Name="Kürzel",
                    ModulID = 20                    
                },
                new ModulPartDescription{
                    ModulPartDescriptionID = 344,
                    IsNeeded = true,
                    Description="Grundlagen der Rechnerarchitektur",
                    Name="Name",
                    ModulID = 20                    
                },
                new ModulPartDescription{
                    ModulPartDescriptionID = 345,
                    IsNeeded = true,
                    Description="8",
                    Name="Leistungspunkte",
                    ModulID = 20                    
                },
                new ModulPartDescription{
                    ModulPartDescriptionID = 346,
                    IsNeeded = true,
                    Description="4",
                    Name="Wochenstunden",
                    ModulID = 20                    
                },
                new ModulPartDescription{
                    ModulPartDescriptionID = 347,
                    IsNeeded = true,
                    Description="Deutsch",
                    Name="Sprache",
                    ModulID = 20                    
                },
                new ModulPartDescription{
                    ModulPartDescriptionID = 348,
                    IsNeeded = true,
                    Description="jedes 2. Semester",
                    Name="Turnus",
                    ModulID = 20                    
                },
                new ModulPartDescription{
                    ModulPartDescriptionID = 350,
                    IsNeeded = true,
                    Description="Heiko Falk",
                    Name="Dozent",
                    ModulID = 20                    
                },
                new ModulPartDescription{
                    ModulPartDescriptionID = 351,
                    IsNeeded = true,
                    Description="Informatik",
                    Name="Einordnung in Studiengänge",
                    ModulID = 20                    
                },
                new ModulPartDescription{
                    ModulPartDescriptionID = 352,
                    IsNeeded = true,
                    Description="keine",
                    Name="Voraussetzungen(inhaltich)",
                    ModulID = 20                    
                },
                new ModulPartDescription{
                    ModulPartDescriptionID = 353,
                    IsNeeded = true,
                    Description="Interner Aufbau von Rechnern und deren Elemente.",
                    Name="Lernziele",
                    ModulID = 20                    
                },
                new ModulPartDescription{
                    ModulPartDescriptionID = 354,
                    IsNeeded = true,
                    Description="Studierende lernen den Aufbau aktueller Rechner sowie deren wichtigsten Komponenten kennen.",
                    Name="Inhalt",
                    ModulID = 20                    
                },
                new ModulPartDescription{
                    ModulPartDescriptionID = 355,
                    IsNeeded = true,
                    Description="Vorlesungsscript (verfügbar auf der Homepage)",
                    Name="Literatur",
                    ModulID = 20                    
                },
                new ModulPartDescription{
                    ModulPartDescriptionID = 356,
                    IsNeeded = true,
                    Description="Vorlesung",
                    Name="Lehr- und Lernformen",
                    ModulID = 20                    
                },
                new ModulPartDescription{
                    ModulPartDescriptionID = 357,
                    IsNeeded = true,
                    Description="60",
                    Name="Arbeitsaufwand",
                    ModulID = 20                    
                },
                new ModulPartDescription{
                    ModulPartDescriptionID = 358,
                    IsNeeded = true,
                    Description="Klausur",
                    Name="Bewertungsmethode",
                    ModulID = 20                    
                },
                new ModulPartDescription{
                    ModulPartDescriptionID = 359,
                    IsNeeded = true,
                    Description="keine",
                    Name="Vorraussetzungen(Formal)",
                    ModulID = 20                    
                },
                new ModulPartDescription{
                    ModulPartDescriptionID = 360,
                    IsNeeded = true,
                    Description="2pkt Klausur / 2pkt Übung / 2pkt Labor",
                    Name="Notenbildung",
                    ModulID = 20                   
                }
                
                
                
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
                    ValidSemester = "Wintersemester 2012/2013",
                },
				new Modulhandbook{
                    ModulhandbookID = 2,
                    SemesterID=2,
                    Name = "Master Medieninformatik",
                    Abschluss = "Master",
                    FspoYear = 2012,
                    ValidSemester = "Sommersemester 2013",
                },
				new Modulhandbook{
                    ModulhandbookID = 3,
                    SemesterID=3,
                    Name = "Bachelor Informatik",
                    Abschluss = "Bachelor",
                    FspoYear = 2012,
                    ValidSemester = "Wintersemester 2013/2014",
                },
                new Modulhandbook{
                    ModulhandbookID = 4,
                    SemesterID=3,
                    Name = "Master Software-Engineering",
                    Abschluss = "Master",
                    FspoYear = 2012,
                    ValidSemester = "Wintersemester 2013/2014",
                },
                new Modulhandbook{
                    ModulhandbookID = 5,
                    SemesterID=3,
                    Name = "Bachelor Medieninformatik",
                    Abschluss = "Bachelor",
                    FspoYear = 2013,
                    ValidSemester = "Wintersemester 2013/2014",
                },            
                new Modulhandbook{
                    ModulhandbookID = 6,
                    SemesterID=3,
                    Name = "Master Informatik",
                    Abschluss = "Master",
                    FspoYear = 2012,
                    ValidSemester = "Wintersemester 2013/2014",
                },
                new Modulhandbook{
                    ModulhandbookID = 7,
                    SemesterID=2,
                    Name = "Bachelor Software-Engineering",
                    Abschluss = "Bachelor",
                    FspoYear = 2012,
                    ValidSemester = "Sommersemester 2013",
                },
                new Modulhandbook{
                    ModulhandbookID = 8,
                    SemesterID=3,
                    Name = "Bachelor Software-Engineering",
                    Abschluss = "Bachelor",
                    FspoYear = 2012,
                    ValidSemester = "Wintersemester 2013/2014",
                }
            };


            return modulHandbooks;
        }

        private static List<Semester> GetSemesters()
        {
            var archives = new List<Semester>{
                 new Semester{
                    SemesterID = 3,
                    Name="Wintersemester 2013/2014",
                    ArchiveID = 1
                },
                   new Semester{
                    SemesterID = 2,
                    Name="Sommersemester 2013",
                    ArchiveID = 1
                },
                   new Semester{
                    SemesterID = 1,
                    Name="Wintersemester 2012/2013",
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