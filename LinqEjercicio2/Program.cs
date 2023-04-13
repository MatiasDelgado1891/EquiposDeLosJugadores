using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqEjercicio2
{
    internal class Program
    {
        static void Main(string[] args)
        {

            ControlEquipoJugadores cej = new ControlEquipoJugadores();

            Console.WriteLine("Promedio por Equipo \n************************ ");
            cej.PromedioSalario();
            Console.WriteLine("");

            Console.WriteLine("Goleadores \n************************ ");
            cej.GetDC("DC");

            Console.WriteLine("");
            Console.WriteLine("Plantilla \n************************ ");
            cej.GetJugadoresOrdenados();
            Console.WriteLine("");
            Console.WriteLine("Plantilla ordenada por salario\n************************ ");
            cej.GetJugadoresOrdenadosSegun();

            Console.WriteLine("\nIngrese el Equipo(entero 1 a 3)\n1 para Peñarol \n2 para Manchester City \n3 para Real Madrid");
            string _id = Console.ReadLine();
            try
            {
                int _Equipo = int.Parse(_id);
                cej.GetJugadorEquipo(_Equipo);
            }
            catch
            {
                Console.WriteLine("ha introducido un id erroneo. Debe ingresar un numero entero");
            }


        }
    }


    internal class Jugador
    {
        public int id { get; set; } 
        public string nombre { get; set; }  
        public string posicion { get; set; }
        public int salario { get; set; }    
        public int EquipoID { get; set; }  


        public void GetDatosJugador()
        {
            Console.WriteLine("Jugador {0} con ID {1}, con posicion {2} con salario {3} y pertenece a" + " el equipo {4}" , nombre,id,posicion, salario, EquipoID);
        }


    }

    internal class Equipo
    {
        public int id { get; set; }
        public string nombre { get; set; }

        public void GetDatoEquipo()
        {
            Console.WriteLine("Equipo {0} con id {1}", nombre,id);
        }
    }

 
    internal class ControlEquipoJugadores
    {
        public List<Equipo> ListaDeEquipos;
        public List<Jugador> ListaDeJugadores;

        public ControlEquipoJugadores()
        {
            ListaDeEquipos = new List<Equipo>();
            ListaDeJugadores = new List<Jugador> ();


            ListaDeEquipos.Add(new Equipo { id = 1, nombre = "Peñarol" });
            ListaDeEquipos.Add(new Equipo { id = 2, nombre = "Manchester City" });
            ListaDeEquipos.Add(new Equipo { id = 3, nombre = "Real Madrid" });


            ListaDeJugadores.Add(new Jugador { id = 1, nombre = "Antonio Pacheco", posicion = "MC", EquipoID = 1, salario = 50000 });
            ListaDeJugadores.Add(new Jugador { id = 2, nombre = "Arezo", posicion = "DC", EquipoID = 1, salario = 40000 });
            ListaDeJugadores.Add(new Jugador { id = 3, nombre = "cohelo", posicion = "DEF", EquipoID = 1, salario = 45000 });
            ListaDeJugadores.Add(new Jugador { id = 4, nombre = "Kevin De Bruyne", posicion = "MC", EquipoID = 2, salario = 6000000 });
            ListaDeJugadores.Add(new Jugador { id = 5, nombre = "Erling Haaland", posicion = "DC", EquipoID = 2, salario = 10000000 });
            ListaDeJugadores.Add(new Jugador { id = 6, nombre = "Ruben Dias", posicion = "DEF", EquipoID = 2, salario = 800000 });
            ListaDeJugadores.Add(new Jugador { id = 7, nombre = "Benzema", posicion = "DC", EquipoID = 3, salario = 9500000 });
            ListaDeJugadores.Add(new Jugador { id = 8, nombre = "Thibaut Courtois", posicion = "GK", EquipoID = 3, salario = 100000 });
            ListaDeJugadores.Add(new Jugador { id = 9, nombre = "Luka Modric", posicion = "MC", EquipoID = 3, salario = 50000000 });
        }
        
    
      public void GetDC(string _posicion)
        {
            IEnumerable<Jugador> jugadores = from jugador in ListaDeJugadores where jugador.posicion == _posicion select jugador;
        
           foreach (Jugador elemento in jugadores)
            {
                elemento.GetDatosJugador();
            }
        }

        public void GetJugadoresOrdenados()
        {
            IEnumerable<Jugador> jugadores = from jugador in ListaDeJugadores orderby jugador.nombre select jugador;

            foreach (Jugador elemento in jugadores)
            {
                elemento.GetDatosJugador();
            }
        }
    
    public void GetJugadoresOrdenadosSegun()
        {
            IEnumerable<Jugador> jugadores = from jugador in ListaDeJugadores orderby jugador.salario  select jugador;

            foreach (Jugador elemento in jugadores)
            {
                elemento.GetDatosJugador();
            }
        }

        public void GetJugadorEquipo(int _Equipo)
        {
            IEnumerable<Jugador> jugadores = from jugador in ListaDeJugadores
                                             join Equipo in ListaDeEquipos on jugador.EquipoID
                                              equals Equipo.id
                                              where Equipo.id == _Equipo
                                              select jugador;

            foreach (Jugador elemento in jugadores)
            {
                elemento.GetDatosJugador();
            }
        }
        public void PromedioSalario()
        {
            var consulta = from e in ListaDeJugadores
                           group e by e.EquipoID into g
                           select new { equipo = g.Key, PromedioSalario = g.Average(e => e.salario) };

            foreach (var resultado in consulta)
            {
                switch (resultado.equipo)
                {
                    case 1:
                        Console.WriteLine($"Equipo Peñarol - promedio de salario: {resultado.PromedioSalario}");
                        break;
                    case 2:
                        Console.WriteLine($"Equipo Manchester City - promedio de salario: {resultado.PromedioSalario}");
                        break;
                    case 3:
                        Console.WriteLine($"EWuipo Real Madrid - promedio de salario: {resultado.PromedioSalario}");
                        break;
                }
            }
        }

    }
}


