using Microsoft.EntityFrameworkCore;
using ProyectoAplicado.DAL;
using ProyectoAplicado.Models;
using System.Linq.Expressions;

namespace ProyectoAplicado.Services
{
    public class BebidasService
    {
       
        
            private readonly Contexto _contexto;

            public BebidasService(Contexto contexto)
            {
                _contexto = contexto;
            }

            public async Task<bool> Existe(int bebidaId)
            {
                return await _contexto.Bebidas!.AnyAsync(b => b.BebidaId == bebidaId);
            }

            public async Task<bool> Insertar(Bebidas bebida)
            {
                _contexto.Add(bebida);
                return await _contexto.SaveChangesAsync() > 0;
            }

            public async Task<bool> Modificar(Bebidas bebida)
            {
                _contexto.Update(bebida);
                var guardado = await _contexto.SaveChangesAsync() > 0;
                _contexto.Bebidas!.Entry(bebida).State = EntityState.Detached;
                return guardado;
            }

            public async Task<bool> Eliminar(Bebidas bebida)
            {
                return await _contexto.Bebidas!.AsNoTracking().Where(b => b.BebidaId == bebida.BebidaId).ExecuteDeleteAsync() > 0;
            }

            public async Task<Bebidas?> Buscar(int bebidaId)
            {
                return await _contexto.Bebidas!.AsNoTracking().FirstOrDefaultAsync(b => b.BebidaId == bebidaId);
            }

            public async Task<List<Bebidas>> Listar(Expression<Func<Bebidas, bool>> criterio)
            {
                return await _contexto.Bebidas!.AsNoTracking().Where(criterio).ToListAsync();
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
        }

    }

