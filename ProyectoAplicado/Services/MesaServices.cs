using ProyectoAplicado.Models;
using System.Collections.Generic;
using System.Linq;
namespace ProyectoAplicado.Services;

public class MesaServices
{
    private readonly List<Mesa> _mesas = new List<Mesa>();

    public List<Mesa> ListarMesas()
    {
        return _mesas;
    }

    public Mesa? BuscarMesaPorId(int mesaId)
    {
        return _mesas.FirstOrDefault(m => m.MesaId == mesaId);
    }

    public void InsertarMesa(Mesa mesa)
    {
        mesa.MesaId = _mesas.Any() ? _mesas.Max(m => m.MesaId) + 1 : 1;
        _mesas.Add(mesa);
    }

    public void ModificarMesa(Mesa mesa)
    {
        var mesaExistente = BuscarMesaPorId(mesa.MesaId);
        if (mesaExistente != null)
        {
            mesaExistente.Numero = mesa.Numero;
            mesaExistente.Capacidad = mesa.Capacidad;
            mesaExistente.Estado = mesa.Estado;
            mesaExistente.MeseraId = mesa.MeseraId;
        }
    }

    public void EliminarMesa(int mesaId)
    {
        var mesa = BuscarMesaPorId(mesaId);
        if (mesa != null)
        {
            _mesas.Remove(mesa);
        }
    }
}
