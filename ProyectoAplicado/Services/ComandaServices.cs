using ProyectoAplicado.Models;
using System;
using System.Collections.Generic;
using System.Linq;
namespace ProyectoAplicado.Services;

public class ComandaServices
{
    private readonly List<Comanda> _comandas = new List<Comanda>();

    public List<Comanda> ListarComandas()
    {
        return _comandas;
    }

    public Comanda? BuscarComandaPorId(int comandaId)
    {
        return _comandas.FirstOrDefault(c => c.ComandaId == comandaId);
    }

    public void InsertarComanda(Comanda comanda)
    {
        comanda.ComandaId = _comandas.Any() ? _comandas.Max(c => c.ComandaId) + 1 : 1;
        comanda.FechaHora = DateTime.Now;
        _comandas.Add(comanda);
    }

    public void ModificarComanda(Comanda comanda)
    {
        var comandaExistente = BuscarComandaPorId(comanda.ComandaId);
        if (comandaExistente != null)
        {
            comandaExistente.Estado = comanda.Estado;
            comandaExistente.MeseraId = comanda.MeseraId;
            comandaExistente.CocineroId = comanda.CocineroId;
            comandaExistente.MesaId = comanda.MesaId;
        }
    }

    public void EliminarComanda(int comandaId)
    {
        var comanda = BuscarComandaPorId(comandaId);
        if (comanda != null)
        {
            _comandas.Remove(comanda);
        }
    }
}
