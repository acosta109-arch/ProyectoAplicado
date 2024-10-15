using ProyectoAplicado.Models;
using System.Collections.Generic;
using System.Linq;
namespace ProyectoAplicado.Services;

public class MeseraServices
{
    private readonly List<Mesera> _meseras = new List<Mesera>();

    public List<Mesera> ListarMeseras()
    {
        return _meseras;
    }

    public Mesera? BuscarMeseraPorId(int meseraId)
    {
        return _meseras.FirstOrDefault(m => m.MeseraId == meseraId);
    }

    public void InsertarMesera(Mesera mesera)
    {
        mesera.MeseraId = _meseras.Any() ? _meseras.Max(m => m.MeseraId) + 1 : 1;
        _meseras.Add(mesera);
    }

    public void ModificarMesera(Mesera mesera)
    {
        var meseraExistente = BuscarMeseraPorId(mesera.MeseraId);
        if (meseraExistente != null)
        {
            meseraExistente.Nombre = mesera.Nombre;
            meseraExistente.Apellido = mesera.Apellido;
            meseraExistente.Telefono = mesera.Telefono;
        }
    }

    public void EliminarMesera(int meseraId)
    {
        var mesera = BuscarMeseraPorId(meseraId);
        if (mesera != null)
        {
            _meseras.Remove(mesera);
        }
    }
}
