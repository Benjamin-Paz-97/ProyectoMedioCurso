using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ProyectoMedioCurso.Vistas;
using ProyectoMedioCurso.Data;
using System.IO;

namespace ProyectoMedioCurso
{
    public partial class App : Application
    {
        static BaseDeDatos db;
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage( new MenuPrincipal());
        }
        public static BaseDeDatos CrearBD
        { 
            get
            {
                if(db == null)
                {
                    db = new BaseDeDatos(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Escuela.BD3"));
                }
                return db;
            }
        }
        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
