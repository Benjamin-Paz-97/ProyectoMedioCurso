using ProyectoMedioCurso.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProyectoMedioCurso.Vistas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PantallaDeOpciones : ContentPage
    {
        public PantallaDeOpciones()
        {
            InitializeComponent();
            
        }

        private void BtnVolver_Clicked(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }

        private void BtnListaRec_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new PantallaListas());
        }

        private void BtnAgregarRecetaNueva_Clicked(object sender, EventArgs e)
        {
            Receta Obj = new Receta();
            Obj.IdReceta = 0;
            Obj.NombreReceta = "";
            Obj.Ingredientes = "";
            Obj.Preparacion = "";
            Navigation.PushAsync(new HojaAgregarParaReceta(Obj));
        }

        private void BtnBuscarReceta_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new PantallaListas());
        }
    }
}