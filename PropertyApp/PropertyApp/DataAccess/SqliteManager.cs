using PropertyApp.Abstraction;
using PropertyApp.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Xamarin.Forms;

namespace PropertyApp.DataAccess
{
    public class SqliteManager : SQLiteConnection
    {

        private static SqliteManager instance;
        private static object collitionlock = new object();
        private SqliteManager() : base(new SQLiteConnectionString(DbPath())) { }

        public static SqliteManager GetInstance()
        {
            lock (collitionlock)
            {
                if (instance == null)
                {
                    instance = new SqliteManager();
                    instance.CreateTablesForOrionPrueba();
                }
                return instance;
            }
        }

        public static string DbPath()
        {
            var dbName = "OrionTekPrueba.db3";

            var info = DependencyService.Get<IAppInfo>();

            var path = Path.Combine(System.Environment.
              GetFolderPath(System.Environment.
              SpecialFolder.Personal), dbName);

            if (Device.RuntimePlatform == Device.Android)
            {
                path = Path.Combine(info.DatabasePath() + dbName);
            }

            return path;
        }

        private void CreateTablesForOrionPrueba()
        {
            CreateTable(typeof(Empresas), CreateFlags.None);
            CreateTable(typeof(Clientes), CreateFlags.None);
            CreateTable(typeof(Direcciones), CreateFlags.None);
            CreateTable(typeof(ClientesEmpresas), CreateFlags.None);
        }


    }
}
