/// <summary>
/// This class should manage requests to the archive including Modulhandbooks, Subjects and Modules.
/// </summary>
    
using ModulManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Data.Linq;
using System.Data.Entity;
using iTextSharp.text;

namespace ModulManagementSystem.Core.DBOperations
{
    public class ArchiveLogic
    {
        private ModulhandbookContext context = new ModulhandbookContext();

        /// <summary>
        /// returns all the modulhandbooks that belong to the given studysubject
        /// </summary>
        /// <param name="name">name from the study subjecz</param>
        /// <returns>empty list if no modulhandbooks were found</returns>
        public List<Modulhandbook> getAllModulHandbooksByStudySubject(String name)
        {
            name = name.ToLower();
            List<Modulhandbook> resultList = new List<Modulhandbook>();
            ModulhandbookContext context = new ModulhandbookContext();
            foreach (Modulhandbook m in context.Modulhandbooks)
            {
                if (m.Name.ToLower().Equals(name))
                {
                    resultList.Add(m);
                }
            }
            return resultList;
        }

        //no longer valid
        /// <summary>
        /// returns the modul that matches with the given name from current semester
        /// </summary>
        /// <param name="name">name from the modul</param>
        /// <returns>null if no module with this name is found</returns>
        public Modul getModuleByName(String name)
        {
            name = name.ToLower();
            DbSet<Modul> subj = context.Modules;
            foreach (Modul m in subj)
            {
                foreach (ModulPartDescription d in m.Descriptions)
                {
                    if (d.Name.Equals(GlobalNames.getModulNameText()) && d.Description.ToLower().Equals(name))
                        return m;
                }
            }
            return null;
        }

        /// <summary>
        /// returns a list of modules which names contain the given string
        /// </summary>
        /// <param name="substr">string to search for</param>
        /// <returns>empty list if nothing is found</returns>
        public List<Modul> getAllModulesThatContainStr(String substr)
        {
            substr = substr.ToLower();
            List<Modul> results = new List<Modul>();
            DbSet<Modul> subj = context.Modules;
            foreach (Modul m in subj)
            {
                foreach (ModulPartDescription d in m.Descriptions)
                {
                    if (d.Name.Equals(GlobalNames.getModulNameText()) && d.Description.ToLower().Contains(substr))
                        results.Add(m);
                }
            }
            return results;
        }
 
        /// <summary>
        /// Returns the Modul that matches with the given name and the highest current version of the editable Semester
        /// </summary>
        /// <param name="name">name of the modul</param>
        /// <returns>null if no modul with this name was found</returns>
        public Modul getModuleByNameAttendVersion(String name)
        {
            name = name.ToLower();
            List<Modul> modules=new List<Modul>();
            List<Modul> mod = getEditableModules();

            Modul newest = new Modul() { Version = 0 };

            for (int i = 0; i < mod.Count; i++)
            {
                bool reverse = false;
                for (int j = 0; j < mod[i].Descriptions.Count; j++)
                {
                    ModulPartDescription mpd = mod[i].Descriptions.ToList()[j];
                    if (mpd.Name.Equals(GlobalNames.getModulNameText()) && mpd.Description.ToLower().Equals(name))
                    {
                        if ((mod[i].Version > newest.Version)||newest.Version==0)
                        {
                            newest = mod[i];
                            reverse = true;
                        }
                    }
                }
                if (reverse)
                {
                    i = -1;
                }
            }
            
            return newest;
        }

        /// <summary>
        /// returns all modules from the given subject specified by the ID
        /// </summary>
        /// <param name="subjectID">the subject id from which the modules should be returned</param>
        /// <returns>empty list if nothing is found</returns>
        public List<Modul> getAllModulesFromSubject(int subjectID)
        {
            List<Modul> resultList = new List<Modul>();
            DbSet<Subject> subj = context.Subjects;
            foreach (Subject s in subj)
            {
                if (s.SubjectID == subjectID)
                {
                    foreach (Modul m in s.Modules)
                    {
                        resultList.Add(m);
                    }
                }
            }
            return resultList;
        }


        /// <summary>
        /// returns all modules from the given subject specified by the name
        /// </summary>
        /// <param name="subjectID">the subject id from which the modules should be returned</param>
        /// <returns>empty list if nothing is found</returns>
        public List<Modul> getAllModulesFromSubject(String subjectName)
        {
            subjectName = subjectName.ToLower();
            List<Modul> resultList = new List<Modul>();
            DbSet<Subject> subj = context.Subjects;
            foreach (Subject s in subj)
            {
                if (s.Name.ToLower().Equals(subjectName))
                {
                    foreach (Modul m in s.Modules)
                    {
                        resultList.Add(m);
                    }
                }
            }
            return resultList;
        }
        /// <summary>
        /// searches for a subject with the given name
        /// </summary>
        /// <param name="name">the subject name</param>
        /// <returns>null if no subject with specified name was found</returns>
        public Subject getSubjectByName(String name)
        {
            name = name.ToLower();
            DbSet<Subject> subj = context.Subjects;
            foreach (Subject s in subj)
            {
                if (s.Name.ToLower().Equals(name))
                {
                    return s;
                }
            }
            return null;
        }

        /// <summary>
        /// returns all subjects containing the given string in the name
        /// </summary>
        /// <param name="substr">string to search for</param>
        /// <returns>empty list if nothing is found</returns>
        public List<Subject> getAllSubjectsWithNameContainsStr(String substr)
        {
            substr = substr.ToLower();
            List<Subject> results = new List<Subject>();
            DbSet<Subject> subj = context.Subjects;
            foreach (Subject s in subj)
            {
                if (s.Name.ToLower().Contains(substr))
                {
                    results.Add(s);
                }
            }
            return results;
        }

        /// <summary>
        /// returns all subjects from a modulhandbook which is specified by the name
        /// </summary>
        /// <param name="name">the name from the modulhandbook</param>
        /// <returns>null if no modulhandbook with the name is found</returns>
        public List<Subject> getAllSubjectsFromModulhandbook(String name)
        {
            name = name.ToLower();
            Modulhandbook mhb = getModulhandbookByName(name);
            if (mhb == null)
                return null;
            return getAllSubjectsFromModulhandbook(mhb.ModulhandbookID);
        }
        /// <summary>
        /// searches and returns all subjects from the modulhandbook that matches with the given ID
        /// </summary>
        /// <param name="modulhandbookId">if from the modulhandbook</param>
        /// <returns>empty list if no subject is found</returns>
        public List<Subject> getAllSubjectsFromModulhandbook(int modulhandbookId)
        {
            List<Subject> resultList = new List<Subject>();
            DbSet<Subject> subjects = context.Subjects;
            foreach (Subject s in subjects)
            {
                if (s.ModulhandbookID == modulhandbookId)
                    resultList.Add(s);
            }
            return resultList;
        }

        /// <summary>
        /// returns a modulhandbook that matches with the given name
        /// </summary>
        /// <param name="name">name to search for</param>
        /// <returns>null if no modulhandbook with the given name found</returns>
        public Modulhandbook getModulhandbookByName (String name)
        {
            DbSet<Modulhandbook> subj = context.Modulhandbooks;
            foreach (Modulhandbook m in subj)
            {
                if (m.Name.ToLower().Equals(name))
                {
                    return m;
                }
            }
            return null;
        }

        /// <summary>
        /// returns a modulhandbook that matches with the given name
        /// </summary>
        /// <param name="name">name to search for</param>
        /// <returns>null if no modulhandbook with the given name found</returns>
        public Modulhandbook getModulhandbookByNameAndSemester(String name, String semester)
        {
            DbSet<Modulhandbook> subj = context.Modulhandbooks;
            DbSet<Semester> semesters = context.Semesters;
            foreach(Semester s in semesters)
            {
                if (s.Name.Equals(semester))
                {
                    foreach (Modulhandbook m in s.ModulHandbooks)
                    {
                        if (m.Name.ToLower().Equals(name))
                        {
                            return m;
                        }
                    }
                }
            }
            
            return null;
        }

        /// <summary>
        /// returns a list of modulhandbooks containing the given string in the name
        /// </summary>
        /// <param name="substr">string to search for</param>
        /// <returns>empty list if nothing is found</returns>
        public List<Modulhandbook> getAllModulhandbooksWithNameContainsStr(String substr)
        {
            List<Modulhandbook> results = new List<Modulhandbook>();
            DbSet<Modulhandbook> subj = context.Modulhandbooks;
            foreach (Modulhandbook s in subj)
            {
                if (s.Name.ToLower().Contains(substr))
                {
                    results.Add(s);
                }
            }
            return results;
        }

        /// <summary>
        /// returns a list with all modulhandbooks 
        /// </summary>
        /// <returns>returns empty list if nothing is found</returns>
        public List<Modulhandbook> getAllModulhandbooks()
        {
            List<Modulhandbook> resultList = new List<Modulhandbook>();
            ModulhandbookContext context = new ModulhandbookContext();
            foreach (Modulhandbook m in context.Modulhandbooks)
            {
                resultList.Add(m);
            }
            return resultList;
        }

        /// <summary>
        /// returns a list with all modulhandbooks 
        /// </summary>
        /// <returns>returns empty list if nothing is found</returns>
        public List<Modulhandbook> getAllModulhandbooksFromSemester(int semesterId)
        {
            foreach (Semester s in context.Semesters)
            {
                if (s.SemesterID == semesterId)
                {
                    return s.ModulHandbooks.ToList();
                }
            }
            return null;
        }

        /// <summary>
        /// returns the corresponding Modul
        /// </summary>
        /// <param name="ID">The ModulId, not negative</param>
        /// <returns>returns null if nothing is found</returns>
        public Modul getModulById(int ID)
        {
            Modul toReturn = null;
            ModulhandbookContext context = new ModulhandbookContext();
            foreach (Modul m in context.Modules)
            {
                if (m.ModulID == ID)
                {
                    toReturn = m;
                }
            }
            return toReturn;
        }

        /// <summary>
        /// This Function creates new Moduls. It's also called in order to 'edit' Moduls or change the Modulstate. Due to the Versionisierung 
        /// </summary>
        /// <param name="modulpartdescriptions"></param>
        /// <param name="state"></param>
        /// <param name="owner"></param>
        /// <param name="autor"></param>
        /// <param name="lastChange"></param>
        /// <param name="subjects"></param>
        /// <param name="version"></param>
        /// <returns></returns>
        public Modul CreateModul(List<ModulPartDescription> modulpartdescriptions, ModulState state, Guid owner,
            Guid autor, DateTime lastChange, List<Subject> subjects, int version)
        {
            ModulhandbookContext mhc = new ModulhandbookContext();
            Modul theNewModul = new Modul()
            {
                State = state,
                Owner = owner,
                Autor = autor,
                LastChange = lastChange,
                Subjects = new List<Subject>(),
                Descriptions = modulpartdescriptions,
                Version = version,
                Year = 2012
            };
            foreach (Subject s in mhc.Subjects)
            {
                foreach (Subject s2 in subjects)
                {
                    if (s.SubjectID == s2.SubjectID)
                    {
                    s.Modules.Add(theNewModul);
                    theNewModul.Subjects.Add(s);
                    }
                }
            }
            mhc.SaveChanges();
            return theNewModul;
        }

        public List<Object> getSearchResults(String searchText)
        {
            List<Object> results = new List<Object>();
            char[] seperators = new char[1] { ' ' };
            List<String> searchStrings = searchText.Split(seperators).ToList();
            foreach (String s in searchStrings)
            {
                if (typeof(int).Equals(s))
                {
                    //results.AddRange(GetAllIntResults(s));
                }
                else
                {
                    results.AddRange(getAllStringResults(s));
                }
            }
            return results;
        }

        private List<Object> getAllStringResults(String s)
        {
            List<Object> results = new List<Object>();
            results.AddRange(getAllModulesThatContainStr(s));
            results.AddRange(getAllSubjectsWithNameContainsStr(s));
            results.AddRange(getAllModulhandbooksWithNameContainsStr(s));

            return results;
        }

        /*private List<String> GetAllIntResults(String s)
        {
            List<String> results = new List<String>();
            
            foreach (Modul m in getAllModulesFromYear(Convert.ToInt32(s)))
            {
                results.Add(getNameFromModule(m));
            }
            foreach (Modulhandbook m in getAllModulHandbooksFromYear(Convert.ToInt32(s)))
            {
                results.Add(m.Name);
            }

            return results;
        }*/

        /// <summary>
        /// Returns the Name of a Modul
        /// </summary>
        /// <param name="m"></param>
        /// <returns></returns>
        public String getNameFromModule(Modul m)
        {
            foreach (ModulPartDescription d in m.Descriptions)
            {
                if (d.Name.Equals(GlobalNames.getModulNameText()))
                {
                    return d.Description;
                }
            }
            return "No name found for requested module.";
        }

        public void WriteDocumentToDataBase(String docPath, Object obj)
        {
            byte[] file = System.IO.File.ReadAllBytes(docPath);


        }

        /// <summary>
        /// Returns a List of all Semesters stored in the Database
        /// </summary>
        /// <returns></returns>
        internal List<Semester> getAllSemester()
        {
            return context.Semesters.ToList();
        }

        /// <summary>
        /// Returns the next Semester. 
        /// For Example: returns Wintersemester 2013 if the current Semester is Sommersemester 2013
        /// </summary>
        /// <returns></returns>
        public Semester getEditableSemester()
        {
            ModulhandbookContext mhc = new ModulhandbookContext();
            Semester next = new Semester();
            DateTime date = DateTime.Now;
            if (DateTime.Now.Month >= 4 && DateTime.Now.Month < 10)
            {
                String compare = "Wintersemester " + DateTime.Now.Year + "/" + (DateTime.Now.Year + 1);
                next = mhc.Semesters.Where(s => s.Name.Equals(compare)).ToList<Semester>().First();               
            }
            else
            {
                String compare = "";
                if (DateTime.Now.Month >= 10)
                {
                   
                    compare = "Sommersemester " + (DateTime.Now.Year + 1);
                }
                else
                {
                    compare = "Sommersemester " + DateTime.Now.Year;
                }
                next = mhc.Semesters.Where(s => s.Name.Equals(compare)).ToList<Semester>().First();
            }
            return next;
        }

        /// <summary>
        /// Returns a List of Handbooks from the next(ie editable) Semester
        /// </summary>
        /// <returns></returns>
        public List<Modulhandbook> getEditableModulhandbooks()
        {
            Semester next=getEditableSemester();
            return getAllModulhandbooksFromSemester(next.SemesterID);
        }

        /// <summary>
        /// Returns a List of Moduls from the next(ie editable) Semester
        /// </summary>
        /// <returns></returns>
        public List<Modul> getEditableModules()
        {
            List<Modul> toReturn = new List<Modul>();
            List<Modulhandbook> books = getEditableModulhandbooks();
            foreach (Modulhandbook m in books)
            {
                List<Subject> subjects = m.Subjects.ToList();
                foreach (Subject s in subjects)
                {
                    toReturn.AddRange(s.Modules);
                }
            }
            return RemoveDoubleModules(toReturn);    
        }
        /// <summary>
        /// Returns the Modules from the corresponding owner 
        /// </summary>
        /// <returns></returns>
        public List<Modul> GetModulsModulverantwortlicher(HttpContext context, Guid owner)
        {
            ModulhandbookContext mhc = new ModulhandbookContext();
            List<Modul> alleditableModules = getEditableModules();
            List<Modul> highestVersion = new List<Modul>();
            foreach (Modul m in alleditableModules)
            {
                highestVersion.Add(GetHighestModulVersion(m));
            }
            highestVersion = RemoveDoubleModules(highestVersion);
            List<Modul> correctState = new List<Modul>();
            for (int i = 0; i < highestVersion.Count; i++)
            {
                if (highestVersion[i].State != ModulState.archiviert)
                {
                    correctState.Add(highestVersion[i]);
                }
            }
            if (context.User.IsInRole("Administrator"))
            {
                return correctState;
            }
            else
            {
                List<Modul> correctOwner = new List<Modul>();
                for (int i = 0; i < correctState.Count; i++)
                {
                    if (correctState[i].Owner==owner)
                    {
                        correctOwner.Add(correctState[i]);
                    }
                }
                return correctOwner;
            }

        }

        public List<Subject> getSubjectstoDisplay(String handbookName)
        {
            ModulhandbookContext mhc=new ModulhandbookContext();
            String s = handbookName;
            List<Modulhandbook> list = new List<Modulhandbook>();
            int id;
            bool isNum = Int32.TryParse(s,out id);
            if (isNum)
            {
                list= mhc.Modulhandbooks.Where(m => m.ModulhandbookID == id).ToList<Modulhandbook>();
            }
            else
            {
                return new List<Subject>();
            }
            return getAllSubjectsFromModulhandbook(list.First().ModulhandbookID);
        }


        /// <summary>
        /// Returns the highest version of the Module
        /// </summary>
        /// <param name="modul">The name of the Module</param>
        /// <returns></returns>
        private Modul GetHighestModulVersion(Modul modul)
        {
            ModulhandbookContext mhc = new ModulhandbookContext();
            String Name = getNameFromModule(modul);
            return getModuleByNameAttendVersion(Name);
        }

        //----------------------------Koordinator and Freigeber Logic ---------------------------------///

        public List<Modulhandbook> GetModulhandbooksKooFrei(HttpContext context)
        {
            List<Modulhandbook> result = new List<Modulhandbook>();
            List<Subject> subjects = GetSubjectsKooFrei(context);
            foreach (Subject s in subjects)
            {
                result.Add(s.Modulhandbook);
            }
            return RemoveDoubleHandbooks(result);         
        }
        public List<Subject> GetSubjectsKooFrei(HttpContext context)
        {
            List<Subject> result = new List<Subject>();
            List<Modul> moduls = GetModulsKooFrei(context);
            foreach (Modul m in moduls)
            {
                result.AddRange(m.Subjects.ToList<Subject>());
            }
            return RemoveDoubleSubjects(result);
        }

        /// <summary>
        /// Returns the List of Moduls which have to be controled or released.
        /// The Modulstate of the Moduls depend on the userrole stored in the HttpContext parameter
        /// </summary>
        /// <param name="context"></param>
        /// Necessary to get the Userrole and therefore the right Modules
        /// <param name="subjectId"></param>
        /// <returns></returns>
        public List<Modul> GetModulsKooFrei(HttpContext context)
        {
            List<Modul> editableModules = getEditableModules();
            List<Modul> modules = new List<Modul>();

            foreach (Modul m in editableModules)
            {
                Modul modul = GetHighestModulVersion(m);

                if (HttpContext.Current.User.IsInRole("Freigabeberechtigter"))
                {
                    if (HttpContext.Current.User.IsInRole("Koordinator")
                        && (modul.State == ModulState.waitingForFreigeber || modul.State == ModulState.created))
                    {
                        modules.Add(modul);
                    }
                    else if (modul.State == ModulState.waitingForFreigeber)
                    {
                        modules.Add(modul);
                    }
                }
                else if (HttpContext.Current.User.IsInRole("Koordinator") && modul.State == ModulState.created)
                {
                    modules.Add(modul);
                }
            }

            return RemoveDoubleModules(modules);
        }

        public List<Subject> GetSubjectsKooFrei(HttpContext context, int handbookId)
        {
            List<Subject> All = GetSubjectsKooFrei(context);
            List<Subject> result = new List<Subject>();
            for (int i = 0; i < All.Count; i++)
            {
                if (All[i].ModulhandbookID == handbookId)
                {
                    result.Add(All[i]);
                }
            }
            return result;
        }

        /// <summary>
        /// Returns the List of Moduls which have to be controled or released.
        /// The Modulstate of the Moduls depend on the userrole stored in the HttpContext parameter
        /// </summary>
        /// <param name="context"></param>
        /// Necessary to get the Userrole and therefore the right Modules
        /// <param name="subjectId"></param>
        /// <returns></returns>
        public List<Modul> GetModulsKooFrei(HttpContext context, int subjectId)
        {
            List<Modul> all=GetModulsKooFrei(context);
            List<Modul> toReturn = new List<Modul>();
            foreach (Modul m in all)
            {
                bool toAdd = false;
                foreach (Subject s in m.Subjects)
                {
                    if (s.SubjectID == subjectId)
                    {
                        toAdd = true;
                    }
                }
                if (toAdd)
                {
                    toReturn.Add(m);
                }
            }
            return toReturn;
        }
        //----------------------------Koordinator and Freigeber Logic end-----------------------------///

        /// <summary>
        /// Returns a List of Moduls, which have the ModulState state
        /// </summary>
        /// <param name="state"></param>
        /// <returns></returns>
        public List<Modul> GetModulsByState(ModulState state)
        {
            ModulhandbookContext mhc = new ModulhandbookContext();
            return mhc.Modules.Where(m => m.State == state).ToList<Modul>();
        }

        /// <summary>
        /// Remove Moduls from a List if they occure more the once
        /// </summary>
        /// <param name="modules"></param>
        /// <returns>The List without double Moduls</returns>
        public List<Modul> RemoveDoubleModules(List<Modul> modules)
        {
            if (modules.Count >= 2)
            {
                for (int i = 0; i < modules.Count-1; i++)
                {
                    bool reset = false;
                    for (int j = i + 1; j < modules.Count; j++)
                    {
                        if (modules[i].ModulID == modules[j].ModulID)
                        {
                            modules.RemoveAt(j);
                            reset = true;
                        }
                    }
                    if (reset)
                    {
                        i = -1;
                    }
                }
            }
            return modules;
        }
        /// <summary>
        /// Returns a List of Subjects without double elements
        /// </summary>
        /// <param name="subjects"></param>
        /// <returns></returns>
        public List<Subject> RemoveDoubleSubjects(List<Subject> subjects)
        {
            if (subjects.Count >= 2)
            {
                for (int i = 0; i < subjects.Count - 1; i++)
                {
                    bool reset = false;
                    for (int j = i + 1; j < subjects.Count; j++)
                    {
                        if (subjects[i].SubjectID == subjects[j].SubjectID)
                        {
                            subjects.RemoveAt(j);
                            reset = true;
                        }
                    }
                    if (reset)
                    {
                        i = -1;
                    }
                }
            }
            return subjects;
        }
        /// <summary>
        /// Returns a List of Modulhandbooks without double elements
        /// </summary>
        /// <param name="books"></param>
        /// <returns></returns>
        public List<Modulhandbook> RemoveDoubleHandbooks(List<Modulhandbook> books)
        {
            if (books.Count >= 2)
            {
                for (int i = 0; i < books.Count - 1; i++)
                {
                    bool reset = false;
                    for (int j = i + 1; j < books.Count; j++)
                    {
                        if (books[i].ModulhandbookID == books[j].ModulhandbookID)
                        {
                            books.RemoveAt(j);
                            reset = true;
                        }
                    }
                    if (reset)
                    {
                        i = -1;
                    }
                }
            }
            return books;
        }
    }
}