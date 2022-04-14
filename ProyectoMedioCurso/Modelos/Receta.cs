using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
namespace ProyectoMedioCurso.Modelos
{
    public class Receta
    {
        [PrimaryKey,AutoIncrement]
        public int IdReceta { get; set; }
        [MaxLength (50)]
        public string NombreReceta { get; set; }
        [MaxLength(200)]
        public string Ingredientes { get; set; }
        [MaxLength (500)]
        public string Preparacion { get; set;}

    }
}
