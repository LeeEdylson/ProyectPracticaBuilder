using System;
using System.Collections.Generic;

namespace BuilderPatterns
{
    class Program
    {
        /// Iniciar aplicacion
        public static void Main()
        {
            VehiculoBuilder builder;

            // CREACION DE LA TIENDA DE CARROS UWU / instanciamos
            Shop shop = new Shop();

            // CONTRUIR Y MOSTRAR CARROS RUN
            builder = new PatinetaBuilder();
            shop.Construct(builder);
            builder.Vehiculo.Show();

            builder = new CarroBuilder();
            shop.Construct(builder);
            builder.Vehiculo.Show();

            builder = new MototaxiBuilder();
            shop.Construct(builder);
            builder.Vehiculo.Show();

            // Wait for user
            Console.ReadKey();
        }
    }

    class Shop
    {
        // Contruccion de la serie de procesos complejos
        public void Construct(VehiculoBuilder vehiculoBuilder)
        {
            vehiculoBuilder.BuilderForma();
            vehiculoBuilder.BuilerCilindro();
            vehiculoBuilder.BuilderRuedas();
            vehiculoBuilder.BuilderPuertas();
        }
    }


    /// Clase abstracta del constructor
    abstract class VehiculoBuilder
    {
        protected Vehiculo vehiculo;

        // Consigue la instancia
        public Vehiculo Vehiculo
        {
            get { return vehiculo; }
        }

        // Metodos abstractos
        public abstract void BuilderForma();
        public abstract void BuilerCilindro();
        public abstract void BuilderRuedas();
        public abstract void BuilderPuertas();
    }

    /// La clase concreta del constructor
    class MototaxiBuilder : VehiculoBuilder
    {
        public MototaxiBuilder()
        {
            vehiculo = new Vehiculo("Mototaxi");
        }

        public override void BuilderForma()
        {
            vehiculo["forma"] = "Mototaxi";
        }

        public override void BuilerCilindro()
        {
            vehiculo["cilindro"] = "500 cc";
        }

        public override void BuilderRuedas()
        {
            vehiculo["ruedas"] = "3";
        }

        public override void BuilderPuertas()
        {
            vehiculo["puertas"] = "2";
        }
    }


    /// La clase concreta del constructor
    class CarroBuilder : VehiculoBuilder
    {
        public CarroBuilder()
        {
            vehiculo = new Vehiculo("Carro");
        }

        public override void BuilderForma()
        {
            vehiculo["forma"] = "Carro";
        }

        public override void BuilerCilindro()
        {
            vehiculo["cilindro"] = "2500 cc";
        }

        public override void BuilderRuedas()
        {
            vehiculo["ruedas"] = "4";
        }

        public override void BuilderPuertas()
        {
            vehiculo["puertas"] = "4";
        }
    }

    /// La clase concreta del constructor
    class PatinetaBuilder : VehiculoBuilder
    {
        public PatinetaBuilder()
        {
            vehiculo = new Vehiculo("Patineta");
        }

        public override void BuilderForma()
        {
            vehiculo["forma"] = "Patineta";
        }

        public override void BuilerCilindro()
        {
            vehiculo["cilindro"] = "50 cc";
        }

        public override void BuilderRuedas()
        {
            vehiculo["ruedas"] = "2";
        }

        public override void BuilderPuertas()
        {
            vehiculo["puertas"] = "0";
        }
    }

 
    /// Clase vehiculos
    
    class Vehiculo
    {
        private string _tipovehiculo;
        private Dictionary<string, string> _partes =
          new Dictionary<string, string>();

        // Constructor
        public Vehiculo(string tipovehiculo)
        {
            this._tipovehiculo = tipovehiculo;
        }

        // Indexar los valores
        public string this[string key]
        {
            get { return _partes[key]; }
            set { _partes[key] = value; }
        }

        public void Show()
        {
            Console.WriteLine("\n---------------------------");
            Console.WriteLine("Tipo de Vehículo: {0}", _tipovehiculo);
            Console.WriteLine(" Forma : {0}", _partes["forma"]);
            Console.WriteLine(" Cilindrada : {0}", _partes["cilindro"]);
            Console.WriteLine(" N. de ruedas: {0}", _partes["ruedas"]);
            Console.WriteLine(" N. de puertas : {0}", _partes["puertas"]);
        }
    }
}
