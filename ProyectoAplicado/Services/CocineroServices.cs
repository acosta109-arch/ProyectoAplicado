using Microsoft.EntityFrameworkCore;
using ProyectoAplicado.DAL;
using ProyectoAplicado.Models;
using System.Linq.Expressions;

namespace ProyectoAplicado.Services
{
    public class CocineroServices
    {
        private readonly Contexto _contexto;

        public CocineroServices(Contexto contexto)
        {
            _contexto = contexto ?? throw new ArgumentNullException(nameof(contexto));
        }

        public async Task<bool> Existe(int id)
        {
            return await _contexto.Cocineros.AnyAsync(c => c.CocineroId == id);
        }

        public async Task<bool> Insertar(Cocineros cocinero)
        {
            if (cocinero == null) throw new ArgumentNullException(nameof(cocinero));

            await _contexto.Cocineros.AddAsync(cocinero);
            return await _contexto.SaveChangesAsync() > 0;
        }

        public async Task<bool> Modificar(Cocineros cocinero)
        {
            if (cocinero == null) throw new ArgumentNullException(nameof(cocinero));

            _contexto.Cocineros.Update(cocinero);
            return await _contexto.SaveChangesAsync() > 0;
        }

        public async Task<bool> Guardar(Cocineros cocinero)
        {
            if (cocinero == null) throw new ArgumentNullException(nameof(cocinero));

            if (!await Existe(cocinero.CocineroId))
                return await Insertar(cocinero);
            else
                return await Modificar(cocinero);
        }

        public async Task<bool> Eliminar(int id)
        {
            var cocinero = await Buscar(id);
            if (cocinero == null) return false;

            _contexto.Cocineros.Remove(cocinero);
            return await _contexto.SaveChangesAsync() > 0;
        }

        public async Task<Cocineros?> Buscar(int id)
        {
            return await _contexto.Cocineros.AsNoTracking()
                .FirstOrDefaultAsync(c => c.CocineroId == id);
        }

        public async Task<List<Cocineros>> Listar(Expression<Func<Cocineros, bool>> criterio)
        {
            return await _contexto.Cocineros.AsNoTracking()
                .Where(criterio)
                .ToListAsync(); // Cambié a ToListAsync para evitar problemas de ejecución.
        }

        public async Task<bool> ValidarCocineroUnico(int cocineroId, string nombre, string telefono)
        {
            if (string.IsNullOrWhiteSpace(nombre)) throw new ArgumentException("El nombre no puede estar vacío", nameof(nombre));
            if (string.IsNullOrWhiteSpace(telefono)) throw new ArgumentException("El teléfono no puede estar vacío", nameof(telefono));

            var cocineroExistente = await _contexto.Cocineros
                .Where(c => c.CocineroId != cocineroId)
                .Where(c => c.NombreCompleto == nombre)
                .Where(c => c.Telefono == telefono)
                .FirstOrDefaultAsync();

            return cocineroExistente == null;
        }
    }
}
