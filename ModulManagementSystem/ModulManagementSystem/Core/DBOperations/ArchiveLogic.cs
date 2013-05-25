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

        public List<Modul> getAllModulesFromYear(int year)
        {
            return null;
        }

        public List<Modulhandbook> getAllModulHandbooksFromYear(int yeah)
        {
            return null;
        }
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
        /// returns the modul that matches with the given name and the highest current version. Muss noch bearbeitet werden
        /// </summary>
        /// <param name="name">name of the modul</param>
        /// <returns>null if no modul with this name was found</returns>
        public Modul getModuleByNameAttendVersion(String name)
        {
            name = name.ToLower();
            List<Modul> modules=new List<Modul>();
            DbSet<Modul> mod = context.Modules;
            Modul newest = new Modul() { Version = 0 };
            
            foreach (Modul m in mod)
            {
                foreach (ModulPartDescription d in m.Descriptions)
                {
                    if (d.Name.Equals(GlobalNames.getModulNameText()) && d.Description.ToLower().Equals(name))
                    {
                        if (newest != null && m.Version >= newest.Version)
                        {
                            newest = m;
                        }                        
                    }                        
                }
            }
           
            return newest;
        }

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
                Year = 0
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
                    results.AddRange(GetAllIntResults(s));
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

        private List<String> GetAllIntResults(String s)
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
        }

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

        internal List<Semester> getAllSemester()
        {
            return context.Semesters.ToList();
        }
    }
}