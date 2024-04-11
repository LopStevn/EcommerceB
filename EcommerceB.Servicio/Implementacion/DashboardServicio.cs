using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using EcommerceB.Modelo;
using EcommerceB.DTO;
using EcommerceB.Repositorio.Contrato;
using EcommerceB.Servicio.Contrato;
using AutoMapper;

namespace EcommerceB.Servicio.Implementacion
{
    public class DashboardServicio : IDashboardServicio
    {
        private readonly IVentaRepositorio _ventaRepositorio;
        private readonly IGenericoRepositorio<Producto> _productoRepositorio;
        private readonly IGenericoRepositorio<Usuario> _usuarioRepositorio;

        public DashboardServicio(IVentaRepositorio ventaRepositorio, IGenericoRepositorio<Producto> productoRepositorio,
            IGenericoRepositorio<Usuario> usuarioRepositorio)
        {
            _ventaRepositorio = ventaRepositorio;
            _productoRepositorio = productoRepositorio;
            _usuarioRepositorio = usuarioRepositorio;
        }

        private string Ingresos()
        {
            var consulta = _ventaRepositorio.Consulta();
            decimal? ingresos = consulta.Sum(x => x.Total);
            return Convert.ToString(ingresos);
        }

        private int Ventas()
        {
            var consulta = _ventaRepositorio.Consulta();
            int total = consulta.Count();
            return total;
        }

        private int Clientes()
        {
            var consulta = _usuarioRepositorio.Consulta(u => u.Rol.ToLower() == "cliente");
            int total = consulta.Count();
            return total;
        }

        private int Productos()
        {
            var consulta = _productoRepositorio.Consulta();
            int total = consulta.Count();
            return total;
        }

        public DashboardDTO Resumen()
        {
            try
            {
                DashboardDTO dto = new DashboardDTO()
                {
                    TotalIngresos = Ingresos(),
                    TotalVentas = Ventas(),
                    TotalCliente = Clientes(),
                    TotalProductos = Productos()
                };

                return dto;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }

}


