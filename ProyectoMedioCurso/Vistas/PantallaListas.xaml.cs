using ProyectoMedioCurso.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ProyectoMedioCurso.Vistas;

namespace ProyectoMedioCurso.Vistas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PantallaListas : ContentPage
    {
        public PantallaListas()
        {
            
            InitializeComponent();
            LlenarDatos();
        }

        private void BtnVolverMenu_Clicked(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }

        private void BtnAgregarReceta_Clicked(object sender, EventArgs e)
        {
            Receta Obj = new Receta();
            Obj.IdReceta = 0;
            Obj.NombreReceta = "";
            Obj.Ingredientes = "";
            Obj.Preparacion = "";
            Navigation.PushAsync(new HojaAgregarParaReceta(Obj));
        }

        private void listRecetas_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var Obj=(Receta)e.SelectedItem;
            Navigation.PushAsync(new HojaAgregarParaReceta(Obj));    
            
        }
        public async void LlenarDatos()
        {
            var recetaList = await App.CrearBD.MostraListaRecetasAsync();
            if (recetaList != null)
            {
                listRecetas.ItemsSource = recetaList;
            }
        }

        private void BtnActualizar_Clicked(object sender, EventArgs e)
        {
            LlenarDatos();
        }

        
    }
}