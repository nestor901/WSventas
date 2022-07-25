using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WSventas.Controllers;
using WSventas.Models;
using WSventas.Models.Response;
using WSventas.Models.ViewModels;

namespace WSventas.Controllers
{
    [Route("[controller]")]
    public class ClienteController : Controller
    {
       [HttpGet]
       public IActionResult Get(){
        Respuesta oRespuesta = new Respuesta();
        oRespuesta.Exito = 0;
        try
        {
            using (VentaRealContext db = new VentaRealContext())
            {
                var lst = db.Clientes.ToList();
                oRespuesta.Exito=1;
                return Ok(lst);
            }
        }
        catch (System.Exception ex)
        {
            oRespuesta.Mensaje = ex.Message;
        }
        return Ok(oRespuesta);
       }

       [HttpPost]
       public IActionResult Add(ClienteRequest oModel){
        Respuesta oRespuesta = new Respuesta();
        try
        {
            using (VentaRealContext db = new VentaRealContext())
            {
                Cliente oCliente = new Cliente();
                oCliente.Nombre = oModel.Nombre;
                db.Add(oCliente);
                db.SaveChanges(); 
                oRespuesta.Exito = 1;
            }
        }
        catch (System.Exception ex)
        {
            oRespuesta.Mensaje = ex.Message;
        }
        return Ok();
       }
       

        [HttpPut]
       public IActionResult Edit(ClienteRequest oModel){
        Respuesta oRespuesta = new Respuesta();
        try
        {
            using (VentaRealContext db = new VentaRealContext())
            {
                Cliente oCliente = db.Clientes.Find(oModel.id);
                oCliente.Nombre = oModel.Nombre;
                db.Entry(oCliente).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                db.SaveChanges(); 
                oRespuesta.Exito = 1;
            }
        }
        catch (System.Exception ex)
        {
            oRespuesta.Mensaje = ex.Message;
        }
        return Ok();
       }
       
        [HttpDelete]
       public IActionResult Delete(ClienteRequest oModel){
        Respuesta oRespuesta = new Respuesta();
        try
        {
            using (VentaRealContext db = new VentaRealContext())
            {
                Cliente oCliente = db.Clientes.Find(oModel.id);
                db.Remove(oCliente);
                db.SaveChanges(); 
                oRespuesta.Exito = 1;
            }
        }
        catch (System.Exception ex)
        {
            oRespuesta.Mensaje = ex.Message;
        }
        return Ok();
       }
    }
}