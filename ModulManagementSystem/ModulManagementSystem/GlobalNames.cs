using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ModulManagementSystem.Models;

namespace ModulManagementSystem
{
    public class GlobalNames
    {
        public static String getModulNameNum() { return "Kürzel"; }
        public static String getModulNameNumDesc() { return "Kürzel des Moduls"; }

        public static String getModulNameText() { return "Name"; }
        public static String getModulNameTextDesc() { return "Name des Moduls"; }

        public static String getModulNameECTS() { return "ECTS-Punkte"; }
        public static String getModulNameECTSDesc() { return "Numerische Wert der Leistungspunkte"; }

        public static String getModulNameWeekHours() { return "Semesterwochenstunden"; }
        public static String getModulNameWeekHoursDesc() { return "Anzahl der Wochenstunden"; }

        public static String getModulNameLanguage() { return "Sprache"; }
        public static String getModulNameLanguageDesc() { return "Sprache der Veranstaltung"; }

        public static String getModulNameTurnus() { return "Turnus/Dauer"; }
        public static String getModulNameTurnusDesc() { return "Turnus der Veranstaltung"; }

        public static String getModulNameLecturer() { return "Dozenten"; }
        public static String getModulNameLecturerDesc() { return "Name des/der Dozenten"; }

        public static String getModulNameFitsInStudy() { return "Einordnung in Studiengänge"; }
        public static String getModulNameFitsInStudyDesc() { return "Einordnung des Moduls"; }

        public static String getModulNameReqContent() { return "Voraussetzungen(inhaltich)"; }
        public static String getModulNameReqContentDesc() { return "Inhaltliche Voraussetzungen"; }

        public static String getModulNameEducation() { return "Lernziele"; }
        public static String getModulNameEducationDesc() { return "Angestrebte Ziele"; }

        public static String getModulNameContent() { return "Inhalt"; }
        public static String getModulNameContentDesc() { return "Inhalt der Veranstaltung"; }

        public static String getModulNameLiterature() { return "Literatur"; }
        public static String getModulNameLiteratureDesc() { return "Literatur der Veranstaltung"; }

        public static String getModulNameTeaching() { return "Lehr- und Lernformen"; }
        public static String getModulNameTeachingDesc() { return "Lehr- und Lernformen der Veranstaltung"; }

        public static String getModulNameEffort() { return "Arbeitsaufwand"; }
        public static String getModulNameEffortDesc() { return "Arbeitsaufwand in Stunden"; }

        public static String getModulNameMark() { return "Bewertungsmethode"; }
        public static String getModulNameMarkDesc() { return "Bewertungsmethode"; }

        public static String getModulNameReqFormal() { return "Vorraussetzung(Formal)"; }
        public static String getModulNameReqFormalDesc() { return "Notwendige Vorraussetzung"; }

        public static String getModulNameGrade() { return "Notenbildung"; }
        public static String getModulNameGradeDesc() { return "Art der Notenbildung"; }

        public static List<ModulPartDescription> getDefaultDescriptions()
        {
            return new List<ModulPartDescription>(){
            new ModulPartDescription() { Name = GlobalNames.getModulNameNum(), Description = GlobalNames.getModulNameNumDesc(), IsNeeded = true },
            new ModulPartDescription() { Name = GlobalNames.getModulNameText(), Description = GlobalNames.getModulNameTextDesc(), IsNeeded = true },
            new ModulPartDescription() { Name = GlobalNames.getModulNameECTS(), Description = GlobalNames.getModulNameECTSDesc(), IsNeeded = true },
            new ModulPartDescription() { Name = GlobalNames.getModulNameWeekHours(), Description = GlobalNames.getModulNameWeekHoursDesc(), IsNeeded = true },
            new ModulPartDescription() { Name = GlobalNames.getModulNameLanguage(), Description = GlobalNames.getModulNameLanguageDesc(), IsNeeded = true },
            new ModulPartDescription() { Name = GlobalNames.getModulNameTurnus(), Description = GlobalNames.getModulNameTurnusDesc(), IsNeeded = true },
            new ModulPartDescription() { Name = GlobalNames.getModulNameLecturer(), Description = GlobalNames.getModulNameLecturerDesc(), IsNeeded = true },
            new ModulPartDescription() { Name = GlobalNames.getModulNameFitsInStudy(), Description = GlobalNames.getModulNameFitsInStudyDesc(), IsNeeded = true },
            new ModulPartDescription() { Name = GlobalNames.getModulNameReqContent(), Description = GlobalNames.getModulNameReqContentDesc(), IsNeeded = true },
            new ModulPartDescription() { Name = GlobalNames.getModulNameEducation(), Description = GlobalNames.getModulNameEducationDesc(), IsNeeded = true },
            new ModulPartDescription() { Name = GlobalNames.getModulNameContent(), Description = GlobalNames.getModulNameContentDesc(), IsNeeded = true },
            new ModulPartDescription() { Name = GlobalNames.getModulNameLiterature(), Description = GlobalNames.getModulNameLiteratureDesc(), IsNeeded = true },
            new ModulPartDescription() { Name = GlobalNames.getModulNameTeaching(), Description = GlobalNames.getModulNameTeachingDesc(), IsNeeded = true },
            new ModulPartDescription() { Name = GlobalNames.getModulNameEffort(), Description = GlobalNames.getModulNameEffortDesc(), IsNeeded = true },
            new ModulPartDescription() { Name = GlobalNames.getModulNameMark(), Description = GlobalNames.getModulNameMarkDesc(), IsNeeded = true },
            new ModulPartDescription() { Name = GlobalNames.getModulNameReqFormal(), Description = GlobalNames.getModulNameReqFormalDesc(), IsNeeded = true },
            new ModulPartDescription() { Name = GlobalNames.getModulNameGrade(), Description = GlobalNames.getModulNameGradeDesc(), IsNeeded = true }};
        }
    }
}