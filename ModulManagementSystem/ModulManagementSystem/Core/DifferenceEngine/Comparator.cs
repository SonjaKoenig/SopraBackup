using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Web;
using ModulManagementSystem.Models;
using DifferenceEngine;

namespace ModulManagementSystem.Core.DifferenceEngine
{
    public class Comparator
    {
        /// <summary>
        /// Compares two modules of the same ID but different versions.
        /// </summary>
        /// <param name="oldModule"></param>
        /// <param name="newModule"></param>
        /// <returns>
        /// A changelog of the two modules to compare.
        /// </returns>
        public static String CompareModules(Modul oldModule, Modul newModule)
        {
            DiffEngine engine = new DiffEngine();
            String toReturn = "";
            List<ModulPartDescription> oldDescr, newDescr;
            ArrayList result;

            if (oldModule.ModulID == newModule.ModulID)
            {
                if (oldModule.Version > newModule.Version)
                {
                    newDescr = (List<ModulPartDescription>)oldModule.Descriptions;
                    oldDescr = (List<ModulPartDescription>)newModule.Descriptions;
                }
                else
                {
                    oldDescr = (List<ModulPartDescription>)oldModule.Descriptions;
                    newDescr = (List<ModulPartDescription>)newModule.Descriptions;
                }

                for (int i = 0; i < oldDescr.Count; i++)
                {
                    engine.ProcessDiff(new DiffList_CharData(oldDescr[i].Description), new DiffList_CharData(newDescr[i].Description));
                    result = engine.DiffReport();

                    foreach (DiffResultSpan diff in result)
                    {
                        toReturn = toReturn + diff.ToString();
                    }
                }
            }
            else
            {
                toReturn = "Not the same module!";
            }

            return toReturn;
        }
    }
}