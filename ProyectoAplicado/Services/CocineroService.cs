﻿using Microsoft.EntityFrameworkCore;
using ProyectoAplicado.DAL;
using ProyectoAplicado.Models;
using System.Linq.Expressions;

namespace ProyectoAplicado.Services;

public class CocineroService
{
    private readonly Contexto _contexto;

    public async Task<bool> Existe(int id)
    {
        return await _contexto.Cocineros.AnyAsync(c => c.CocineroId == id);
    }

    public async Task<bool> Insertar(Cocineros cocinero)
    {
        _contexto.Cocineros.Add(cocinero);
        return await _contexto.SaveChangesAsync() > 0;
    }

    public async Task<bool> Modificar(Cocineros cocinero)
    {
        _contexto.Cocineros.Update(cocinero);
        return await _contexto.SaveChangesAsync() > 0;
    }

    public async Task<bool> Guardar(Cocineros cocinero)
    {
        if (!await Existe(cocinero.CocineroId))
            return await Insertar(cocinero);
        else
            return await Modificar(cocinero);
    }

    public async Task<bool> Eliminar(int id)
    {
        var eliminar = await _contexto.Cocineros
            .Where(c => c.CocineroId == id).ExecuteDeleteAsync();
        return eliminar > 0;
    }

    public async Task<Cocineros?> Buscar(int id)
    {
        return await _contexto.Cocineros.AsNoTracking()
            .FirstOrDefaultAsync(c => c.CocineroId == id);
    }
    
    public async Task<List<Cocineros>> Listar(Expression<Func<Cocineros, bool>> criterio)
    {
        return _contexto.Cocineros.AsNoTracking()
            .Where(criterio)
            .ToList();
    }

    public async Task<bool> ValidarNombre(string cocinero)
    {
        return await _contexto.Cocineros.AnyAsync(c => c.NombreCompleto == cocinero);
    }

    public async Task<bool> ValidarNumero(string numero)
    {
        return await _contexto.Cocineros.AnyAsync(c => c.Telefono == numero);
    }
}
