using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TorneodeArtesMarciales.Models;
using System.Globalization;
using System.Text.RegularExpressions;

namespace TorneodeArtesMarciales.CRUD
{
    public class TorneoCRUD
    {
        TorneoContext contenedor = new TorneoContext();
        public void Create(Artesmarciales a)
        {
            a.Nombre = new CultureInfo("en").TextInfo.ToTitleCase(a.Nombre.ToLower());
            a.Valores = new CultureInfo("en").TextInfo.ToTitleCase(a.Valores.ToLower());

            a.LugarOrigen = new CultureInfo("en").TextInfo.ToTitleCase(a.LugarOrigen.ToLower());

            a.LugarOrigen = string.Concat(Regex.Replace(a.LugarOrigen, @"(?i)[\p{L}-[ña-z]]+", m => m.Value.Normalize(NormalizationForm.FormD))
                .Where(c => CharUnicodeInfo.GetUnicodeCategory(c) != UnicodeCategory.NonSpacingMark));
            contenedor.Artesmarciales.Add(a);
            contenedor.SaveChanges();
        }
        public Artesmarciales GetArteMarcial(Artesmarciales a)
        {
            Artesmarciales? existe = contenedor.Artesmarciales.Find(a.Id);
            if (existe != null)
                return existe;
            else
                return null;
        }
        public void Delete(Artesmarciales a)
        {
            contenedor.Artesmarciales.Remove(a);
            contenedor.SaveChanges();
        }
        public void Update(Artesmarciales a)
        {
            
            a.Nombre  = new CultureInfo("en").TextInfo.ToTitleCase(a.Nombre.ToLower());
             a.Valores = new CultureInfo("en").TextInfo.ToTitleCase(a.Valores.ToLower());
            
            a.LugarOrigen = new CultureInfo("en").TextInfo.ToTitleCase(a.LugarOrigen.ToLower());
            
            a.LugarOrigen = string.Concat(Regex.Replace(a.LugarOrigen, @"(?i)[\p{L}-[ña-z]]+", 
                m => m.Value.Normalize(NormalizationForm.FormD))
                .Where(c => CharUnicodeInfo.GetUnicodeCategory(c) != 
                UnicodeCategory.NonSpacingMark));
            
            contenedor.Artesmarciales.Update(a);
            contenedor.SaveChanges();
        }
        public IEnumerable<Artesmarciales> GetArteMarcialXAño(Artesmarciales a)
        {
            return from x in contenedor.Artesmarciales orderby x.Nombre where x.AñoOrigen == a.AñoOrigen select x;
        }
        public IEnumerable<Artesmarciales> GetArtesMarciales()
        {
            //return contenedor.Amigos.OrderBy(x=>x.Nombre);
            return from x in contenedor.Artesmarciales
                   orderby x.Nombre
                   select x;
        }

        public bool Validar(Artesmarciales a, out List<string> errores)
        {
            errores = new List<string>();
            if (a != null)
            {
                if (a.AñoOrigen >= (short)DateTime.Now.Year)
                {
                    errores.Add("El año de origen tiene que ser distinto al actual.");
                }
                if (string.IsNullOrWhiteSpace(a.Nombre))
                {
                    errores.Add("Debe ingresar un nombre.");
                }
                if (a.Nombre != null && a.Nombre.Length > 100)
                {
                    errores.Add("El maximo de caracteres para el nombre es de 100.");
                }
                if (a.LugarOrigen != null && a.LugarOrigen.Length > 100)
                {
                    errores.Add("El maximo de caracteres para el lugar de origen es de 100.");
                }
                if (a.Valores != null && a.Valores.Length > 50)
                {
                    errores.Add("El maximo de caracteres para los valores es de 100.");
                }
                if (contenedor.Artesmarciales.Any(x => x.Nombre == a.Nombre && x.Id != a.Id))
                {
                    errores.Add("El arte marcial ya esta registrado.");
                }
            }
            return errores.Count == 0;
        }
    }
}
