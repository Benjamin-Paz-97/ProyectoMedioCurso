using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ProyectoMedioCurso.Modelos;
using SQLite;

namespace ProyectoMedioCurso.Data
{
    public class BaseDeDatos
    {
        SQLiteAsyncConnection db;
        public BaseDeDatos(string dbPath)
        {
            db = new SQLiteAsyncConnection(dbPath);
            db.CreateTableAsync<Receta>().Wait();
        }

        public Task<int> GuardarRecetaAsync(Receta receta)
        {
            if(receta.IdReceta != 0)
            {
                return db.UpdateAsync(receta);
            }
            else
            {
                return db.InsertAsync(receta);
            }
        }
        public Task<int> EliminarRecetaAsync(Receta receta)
        {
            return db.DeleteAsync(receta);
        }
        public Task<List<Receta>> MostraListaRecetasAsync()
        {
            return db.Table<Receta>().ToListAsync();
        }
        public Task<Receta> MostrarRecetaPorIDAsync(int idReceta)
        {
            return db.Table<Receta>().Where(a => a.IdReceta == idReceta).FirstOrDefaultAsync();

        }
    }
}
