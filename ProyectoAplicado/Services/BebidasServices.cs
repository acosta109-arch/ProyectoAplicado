using Microsoft.EntityFrameworkCore;
using ProyectoAplicado.DAL;
using ProyectoAplicado.Models;
using System.Linq.Expressions;

namespace ProyectoAplicado.Services
{
    public class BebidasServices
    {
        private readonly Contexto _contexto;

        public BebidasServices(Contexto contexto)
        {
            _contexto = contexto;
        }

        public async Task<bool> Existe(int bebidaId)
        {
            return await _contexto.Bebidas.AnyAsync(b => b.BebidaId == bebidaId);
        }

        public async Task<bool> Insertar(Bebidas bebida)
        {
            _contexto.Add(bebida);
            return await _contexto.SaveChangesAsync() > 0;
        }

        public async Task<bool> Modificar(Bebidas bebida)
        {
            _contexto.Update(bebida);
            return await _contexto.SaveChangesAsync() > 0;
        }

        public async Task<bool> Eliminar(int id)
        {
            var eliminar = await _contexto.Bebidas
            .Where(b => b.BebidaId == id).ExecuteDeleteAsync();
            return eliminar > 0;
        }

        public async Task<Bebidas?> Buscar(int bebidaId)
        {
            return await _contexto.Bebidas
                .AsNoTracking()
                .FirstOrDefaultAsync(b => b.BebidaId == bebidaId);
        }

        public async Task<List<Bebidas>> Listar(Expression<Func<Bebidas, bool>> criterio)
        {
            return _contexto.Bebidas
                .AsNoTracking()
                .Where(criterio)
                .ToList();
        }

        public async Task<bool> Guardar(Bebidas bebida)
        {
            if (await Existe(bebida.BebidaId))
            {
                return await Modificar(bebida);
            }
            else
            {
                return await Insertar(bebida);
            }
        }

        public async Task<bool> ValidarBebidaUnica(int bebidaId, string nombre, string descripcion)
        {
            var bebidaExistente = await _contexto.Bebidas
                .Where(b => b.BebidaId != bebidaId)
                .Where(b => b.Nombre == nombre || b.Descripcion == descripcion)
                .FirstOrDefaultAsync();

            return bebidaExistente == null;
        }
    }
}
