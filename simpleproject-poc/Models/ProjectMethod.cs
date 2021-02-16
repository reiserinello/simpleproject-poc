﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using simpleproject_poc.Helper;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Collections.ObjectModel;

namespace simpleproject_poc.Models
{
    class ProjectMethod : INotifyPropertyChanged
    {
        private int id;
        private string methodName;
        public int Id 
        { 
            get
            {
                return id;
            }
            set
            {
                id = value;
                OnPropertyChanged("Id");
            }
        }
        public string MethodName 
        {
            get
            {
                return methodName;
            }
            set
            {
                methodName = value;
                OnPropertyChanged("MethodName");
            }
        }
        /*
        public int Id { get; }
        public string MethodName { get; }
        public ProjectMethod(int t_PK, string t_ProjectMethodName)
        {
            Id = t_PK;
            MethodName = t_ProjectMethodName;
        }
        */
        /*
        public ProjectMethod()
        {
            //nothing
        }*/

        public ObservableCollection<ProjectMethod> Get()
        {
            DBGet dbGet = new DBGet();
            var dbGetProjectMethod = dbGet.ProjectMethodGet();
            return dbGetProjectMethod;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }

    class DbProjectMethod
    {
        //SQL mapping
        [Table(Name = "Project_method")]
        public class MappingProjectMethod
        {
            //Mapper auf Primary Key
            [Column(Name = "Id", IsDbGenerated = true, IsPrimaryKey = true)]
            public int Id
            {
                get;
                set;
            }

            //Mapper auf Feld Name der Gruppe
            [Column]
            public string Method_name;
        }
    }
}