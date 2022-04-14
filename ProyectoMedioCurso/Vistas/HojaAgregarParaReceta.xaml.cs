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
    public partial class HojaAgregarParaReceta : ContentPage
    {
        
        public HojaAgregarParaReceta( Receta obj)
        {
            
            InitializeComponent();
            if (obj.IdReceta != 0)
            {
                RellenarDatosExistentes(obj);
                BtnEliminar.IsVisible=true;
                BtnActualizar .IsVisible=true;
                BtnAgregarRecetaParaBD.IsVisible=false;
            }
            
            
        }

        private async void BtnAgregarRecetaParaBD_Clicked(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                Receta receta = new Receta()
                {
                    NombreReceta = txtNombreReceta.Text,
                    Ingredientes = txtIngredientes.Text,
                    Preparacion = txtPreparacion.Text,
                };
                await App.CrearBD.GuardarRecetaAsync(receta);
                await DisplayAlert("Registro", "Se registro de manera exitosa la receta", "OK");
                LimpiarControles();
                
            }
        }
        
        private void BtnVolver_Clicked(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }

        public bool ValidarDatos()
        {
            bool Respuesta;
            if(string.IsNullOrEmpty(txtNombreReceta.Text))
            {
                Respuesta = false;
            }
            else if(string.IsNullOrEmpty(txtIngredientes.Text))
            {
                Respuesta= false;
            }
            else if( string.IsNullOrEmpty(txtPreparacion.Text))
            { 
                Respuesta = false;
            }
            else
            {
                Respuesta = true;
            }
            return Respuesta;

        }

        public async void RellenarDatosExistentes(Receta Obj) 
        { 
            txtIdReceta.Text=Obj.IdReceta.ToString();
            txtNombreReceta.Text = Obj.NombreReceta;
            txtIngredientes.Text = Obj.Ingredientes;
            txtPreparacion.Text = Obj.Preparacion;
            BtnAgregarRecetaParaBD.IsVisible = false;
            BtnActualizar.IsVisible = true;
        }
        public async void ActualizarDatos(Receta obj)
        {

            obj.NombreReceta = txtNombreReceta.Text;
            obj.Ingredientes = txtIngredientes.Text;
            obj.Preparacion = txtPreparacion.Text;
            await DisplayAlert("Registro", "Se Actualizó de manera exitosa la receta", "OK");
            LimpiarControles();
            BtnActualizar.IsVisible = false;
            BtnAgregarRecetaParaBD.IsVisible = true;
        }
        public void LimpiarControles()
        {
            txtNombreReceta.Text = "";
            txtIngredientes.Text = "";
            txtPreparacion.Text = "";
        }

        private  async void BtnActualizar_Clicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtIdReceta.Text))
            {

                Receta obj = new Receta()
                {
                    IdReceta = Convert.ToInt32(txtIdReceta.Text),
                    NombreReceta = txtNombreReceta.Text,
                    Ingredientes = txtIngredientes.Text,
                    Preparacion = txtPreparacion.Text,
                };
                await App.CrearBD.GuardarRecetaAsync(obj);
                await DisplayAlert("Registro", "Se actualizo de manera exitosa la Receta", "OK");
                LimpiarControles();
                BtnActualizar.IsVisible=false;
                BtnAgregarRecetaParaBD.IsVisible = true;
            }   
            
        }

        private async void BtnEliminar_Clicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtIdReceta.Text))
            {
                Receta obj = new Receta()
                {
                    IdReceta = Convert.ToInt32(txtIdReceta.Text),
                    NombreReceta = txtNombreReceta.Text,
                    Ingredientes = txtIngredientes.Text,
                    Preparacion = txtPreparacion.Text,
                };
                await App.CrearBD.EliminarRecetaAsync(obj);
                await DisplayAlert("Registro", "Se actualizo de manera exitosa la Receta", "OK");
                LimpiarControles();
                BtnActualizar.IsVisible = false;
                BtnAgregarRecetaParaBD.IsVisible = true;
            }
        }
    }
}