using Microsoft.EntityFrameworkCore;
using ProyectoAplicado.DAL;
using ProyectoAplicado.Models;
using System.Linq.Expressions;

namespace ProyectoAplicado.Services;

public class ComidaServices
{
    private readonly Contexto _contexto;
    public ComidaServices(Contexto contexto)
    {
        _contexto = contexto;
    }
    //Metodo Existe 
    public async Task<bool> Existe(int comidaId)
    {
        return await _contexto.Comidas.AnyAsync(c => c.ComidaId == comidaId);
    }

    //Metodo el cual Nos Identifica si esa comida esta registrado en la base de datos
    public async Task<bool> ExisteNombreComida(string nombre, int id)
    {
        return await _contexto.Comidas
            .AnyAsync(c => c.Nombre.ToLower().Equals(nombre.ToLower()) && c.ComidaId != id);
    }

    //Metodo Insertar
    private async Task<bool> Insertar(Comidas comida)
    {
        _contexto.Comidas.Add(comida);
        return await _contexto.SaveChangesAsync() > 0;
    }
    //Metodo Modificar 
    private async Task<bool> Modificar(Comidas comida)
    {
        _contexto.Comidas.Update(comida);
        var modificado = await _contexto.SaveChangesAsync() > 0;
        return modificado;
    }
    //Metodo Guardar
    public async Task<bool> Guardar(Comidas comida)
    {
        if (!await Existe(comida.ComidaId))
            return await Insertar(comida);
        else
            return await Modificar(comida);
    }
    //Metodo Eliminar
    public async Task<bool> Eliminar(int comidaId)
    {
        var eliminado = await _contexto.Comidas
            .Where(c => c.ComidaId == comidaId)
            .ExecuteDeleteAsync();
        return eliminado > 0;
    }
    //Metodo Buscar
    public async Task<Comidas?> Buscar(int comidaId)
    {
        return await _contexto.Comidas
            .AsNoTracking()
            .FirstOrDefaultAsync(c => c.ComidaId == comidaId);
    }
    //Metodo Listar
    public async Task<List<Comidas>> Listar(Expression<Func<Comidas, bool>> criterio)
    {
        return await _contexto.Comidas
            .AsNoTracking()
            .Where(criterio)
            .ToListAsync();
    }

    public async Task<bool> ValidarComidaUnica(int comidaId, string nombre, string descripcion)
    {
        var comidaExistente = await _contexto.Comidas
                .Where(c => c.ComidaId != comidaId)
                .Where(c => c.Nombre == nombre || c.Descripcion == descripcion)
                .FirstOrDefaultAsync();

        return comidaExistente == null;
    }
}