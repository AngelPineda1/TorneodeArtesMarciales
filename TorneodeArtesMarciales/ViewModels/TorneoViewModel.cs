using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Input;
using TorneodeArtesMarciales.CRUD;
using TorneodeArtesMarciales.Models;
using static System.Net.Mime.MediaTypeNames;

namespace TorneodeArtesMarciales.ViewModels
{
    public class TorneoViewModel: INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        public ObservableCollection<Artesmarciales> ListaArtesMarciales { get; set; } = new ObservableCollection<Artesmarciales>();
        TorneoCRUD catalogo { get; set; } = new TorneoCRUD();
        public Artesmarciales? artesmarciales { get; set; } = new Artesmarciales();
        public string Vista { get; set; } = "vertodos";

        //Definir los comandos

        public ICommand VerArteMarcialCommand { get; set; }
        public ICommand VerEliminarCommand { get; set; }
        public ICommand VerEditarCommand { get; set; }
        public ICommand VerAgregarCommand { get; set; }
        public ICommand RegresarCommand { get; set; }
        public ICommand AgregarCommand { get; set; }
        public ICommand VerEliminarArteMarcialCommand { get; set; }
        public ICommand EliminarArteMarcialCommand { get; set; }
        public ICommand CancelarCommand { get; set; }
        public ICommand EditarCommand { get; set; }
        public ICommand ArteMarcialXLugarCommand { get; set; }
        public string error { get; set; } = "";
        private void Actualizar(string? property = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }
        public TorneoViewModel()
        {
            //Cargar info y depositarla
            CargarDatos();
            //Navegación
            //Que cargue los amigos en la vista principal

            //Ver un amigo

            VerArteMarcialCommand = new RelayCommand(VerArteMarcial);
            VerEliminarCommand = new RelayCommand(VerEliminar);
            VerEditarCommand = new RelayCommand(VerEditar);
            VerAgregarCommand = new RelayCommand(VerAgregar);
            AgregarCommand = new RelayCommand(Agregar);
            EliminarArteMarcialCommand = new RelayCommand(Eliminar);
            RegresarCommand = new RelayCommand(Regresar);
            CancelarCommand = new RelayCommand(Cancelar);
            EditarCommand = new RelayCommand(Editar);
            ArteMarcialXLugarCommand = new RelayCommand<string>(ArteMarcialXLugar);
        }

        private void ArteMarcialXLugar(string a)
        {
            if (a != "")
            {
                CargarDatos();
                a = new CultureInfo("en").TextInfo.ToTitleCase(a.ToLower());
               a= string.Concat(Regex.Replace(a, @"(?i)[\p{L}-[ña-z]]+", m => 
               m.Value.Normalize(NormalizationForm.FormD))
                .Where(c => CharUnicodeInfo.GetUnicodeCategory(c) != 
                UnicodeCategory.NonSpacingMark));
                var consulta = ListaArtesMarciales.Where(x => x.LugarOrigen == a).ToList();
                ListaArtesMarciales.Clear();
                foreach (var item in consulta)
                {
                    ListaArtesMarciales.Add(item);
                }
                Actualizar();
            }
            else
            {
                CargarDatos();
                Actualizar();
            }
            
        }

        private void Editar()
        {

            if (artesmarciales != null)
            {
                if (catalogo.Validar(artesmarciales, out List<string> errores))
                {
                   var existe= catalogo.GetArteMarcial(artesmarciales);
                    if (existe != null)
                    {
                        existe.Id = artesmarciales.Id;
                        existe.AñoOrigen = artesmarciales.AñoOrigen;
                        existe.Nombre = artesmarciales.Nombre;
                        existe.Valores = artesmarciales.Valores;
                        existe.Variantes = artesmarciales.Variantes;
                        existe.LugarOrigen = artesmarciales.LugarOrigen;
                        catalogo.Update(existe);
                        Regresar();
                    }
                }
                else
                {
                    foreach (var item in errores)
                    {
                        error = $"{error}{item}{Environment.NewLine}";
                        Actualizar();
                    }
                }
                error = "";
            }
        }

        private void Cancelar()
        {
            artesmarciales = null;
            Regresar();
        }

        private void Eliminar()
        {
            if (artesmarciales != null)
            {
                catalogo.Delete(artesmarciales);
                Regresar();
                Actualizar();
            }
        }

        private void Agregar()
        {
            if (artesmarciales != null)
            {
                if (catalogo.Validar(artesmarciales, out List<string> errores))
                {
                    catalogo.Create(artesmarciales);
                    Regresar();
                }
                else
                {
                    foreach (var item in errores)
                    {
                        error = $"{error}{item}{Environment.NewLine}";
                        Actualizar();
                    }
                }
                error = "";
            }
        }

        private void CargarDatos()
        {
            var datos = catalogo.GetArtesMarciales();
            ListaArtesMarciales.Clear();
            foreach (var item in datos)
            {
                ListaArtesMarciales.Add(item);
            }
            Actualizar();
        }

        private void Regresar()
        {
            Vista = "vertodos";
            CargarDatos();
            Actualizar();
        }


        private void VerAgregar()
        {
            artesmarciales = new Artesmarciales();
            
            Vista = "Agregar";
            Actualizar();
        }

        private void VerEditar()
        {
            if (artesmarciales != null)
            {
                Artesmarciales clon = new Artesmarciales()
                {
                   AñoOrigen=artesmarciales.AñoOrigen,
                   Id=artesmarciales.Id,
                   Nombre=artesmarciales.Nombre,
                   Valores=artesmarciales.Valores,
                   Variantes=(artesmarciales.Variantes==null)? 0:artesmarciales.Variantes,
                   LugarOrigen=artesmarciales.LugarOrigen
                };
                artesmarciales = clon;
                Vista = "VerEditar";
                Actualizar();
            }
        }

        private void VerEliminar()
        {
            if (artesmarciales != null)
            {
                Vista = "Eliminar";
                Actualizar();
            }
        }

        private void VerArteMarcial()
        {
            if(artesmarciales != null)
            {
                Vista = "ver";
                Actualizar();
            }
            
        }
    }
}
