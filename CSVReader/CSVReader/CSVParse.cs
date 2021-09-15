using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSVReader
{
    struct InsuranceFields
    {
        public string UserId;
        public string firstName;
        public string lastName;
        public int version;
        public string company;
    }
    class CSVParse
    {
        // Private variables
        private string _filename;
        private Dictionary<string, List<InsuranceFields>> _companies = new Dictionary<string, List<InsuranceFields>>();


        public CSVParse(string filename)
        {
            _filename = filename;
        }


        /// <summary>
        /// Sorts lists according to last then first name
        /// </summary>
        void SortData()
        {
            foreach (string key in _companies.Keys)
            {
                _companies[key].Sort(delegate (InsuranceFields item1, InsuranceFields item2)
                {
                    var res = item1.lastName.CompareTo(item2.lastName);
                    if (res == 0)
                        res = item1.firstName.CompareTo(item2.firstName);
                    return res;

                });
            }
        }

        /// <summary>
        /// Checks for Duplicates and adds the item to the list
        /// </summary>
        /// <param name="itemToAdd"></param>
        /// <param name="items"></param>
        /// <returns></returns>
        void AddToList(InsuranceFields itemToAdd)
        {
            bool addOK = true;
            for (var i = 0; i < _companies[itemToAdd.company].Count; ++i)
            {
                InsuranceFields listItem = _companies[itemToAdd.company][i];
                if (listItem.UserId == itemToAdd.UserId )
                {
                    if (itemToAdd.version > listItem.version)
                        _companies[itemToAdd.company].RemoveAt(i);
                    else
                        addOK = false;
                }
            }
            if (addOK)
            {
                _companies[itemToAdd.company].Add(itemToAdd);
            }
        }

        /// <summary>
        /// Writes the separate insurance company files
        /// </summary>
        public void WriteOut()
        {
            foreach (string key in _companies.Keys)
            {
                // A new file for each company based on the original filename
                string newFile = Path.Combine(Path.GetDirectoryName(_filename),Path.GetFileNameWithoutExtension(_filename) + "_" + key + ".csv");
                StreamWriter theStream = File.CreateText(newFile);
                theStream.WriteLine("UserID,First Name,Last Name,Version,Insurance Company");

                // Get all the lines
                foreach (InsuranceFields fields in _companies[key])
                {
                    string line = string.Format("{0},{1},{2},{3},{4}", fields.UserId, fields.firstName, fields.lastName, fields.version, fields.company);
                    theStream.WriteLine(line);
                    
                }
                theStream.Close();
            }
        }

        public void ParseCSV()
        {

            //var isHeader = false;
            string[] CSVtext = File.ReadAllLines(_filename);
            if (CSVtext.Length > 1)
            {
                // Skip the header row
                for (var i = 1; i < CSVtext.Length; ++i)
                {
                    var CSVRow = CSVtext[i].Split(',');
                    InsuranceFields theFields = new InsuranceFields();
                    theFields.UserId = CSVRow[0];
                    theFields.firstName = CSVRow[1];
                    theFields.lastName = CSVRow[2];
                    if (!int.TryParse(CSVRow[3], out theFields.version))
                        theFields.version = 0;
                    theFields.company = CSVRow[4];

                    // If the company isn't in the dictionary add it
                    if (!_companies.ContainsKey(theFields.company))
                    {
                        _companies.Add(theFields.company, new List<InsuranceFields>());
                    }
                    AddToList(theFields);
                }
                SortData();
                
            }

        }
    }
}
