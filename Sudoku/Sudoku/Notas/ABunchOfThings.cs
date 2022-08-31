using System;

namespace Sudoku.Notas
{
    public class ABunchOfThings
    {
        public delegate void ExemploDelegate();

        public static void FuncaoDelegate()
        {
            Console.WriteLine("Chamado por delegate");
        }


        static public void LessonABunchOfThings()
        {
            /*StringBuilderNotes.LeassonStringBuilder();
        JaggedArrayAndMatrices.JaggedArrayAndMatricesLeasson();
        */
            
            //Dependency injection:

            /*
             * DI is a pattern that allow you to pass the dependencies of the class externally;
             *
             * It allows us to abstract the dependency and specify what type of car we want to pass
             * to the class. The class will not know what is the concrete class.
             *
             * After we created the Interface ICar and its implementations - Ferrari and Lamborghini - we can
             * use the dependency injection pattern to use the layer of abstraction ICar in the person Class.
             */
            Ferrari car = new Ferrari();
            Car car1 = new Lamborghini();
            Person person = new(car);
            person.Drive();

            IBusiness business = new Business();
            business.Initialize();

            Caminhao caminhao = new Caminhao("Mercedez", 10000, "branco");

            //caminhao.cor = "braco";
            //caminhao.marca = "mercedes";
            //caminhao.peso = 1000;
            
            
            caminhao.Info();
            
            
            //Delegate
            //Delegate serve para referenciar um metodo.
            //Deve ser declarado (acima), instanciado e depois invocado.
            ExemploDelegate exemploDelegate = new ExemploDelegate(FuncaoDelegate);
            exemploDelegate();
            Console.ReadKey();
        }
        
        struct Caminhao
        {
            public string marca;
            public decimal peso;
            public string cor;

            public Caminhao(string Marca, decimal Peso, string Cor)
            {
                marca = Marca;
                peso = Peso;
                cor = Cor;

            }
            
            public void Info()
            {
                Console.WriteLine("Marcar: {0}", this.marca);
                Console.WriteLine("Peso: {0}", this.peso);
                Console.WriteLine("Cor: {0}", this.cor);
            }

        }
        class Business : IBusiness
        {
            //Explicit class
            void IBusiness.Initialize()
            {
                Console.WriteLine("Explicit method");
            }
        }

        public interface IBusiness
        {
            void Initialize();
        }
        
        class Person
        {
            // private ICar _car;
            //
            // public Person(ICar car)
            // {
            //     _car = car;
            // }
            //
            // public void Drive()
            // {
            //     _car.TurnOnOff();
            //     _car.Drive();
            // }
            
            private Car _car;
            
            public Person(Car car)
            {
                _car = car;
            }
            
            public void Drive()
            {
                _car.TurnOnOff();
                _car.Drive();
            }
        }
        class Ferrari : Car
        {
            public override void Drive()
            {
                if (On)
                {
                    Console.WriteLine("Allons y Ferrari");
                }
                else
                {
                    Console.WriteLine("Ferrari is off, turn it on");
                }
            }
        }
        
        class Lamborghini : Car
        {
            public override void Drive()
            {
                if (On)
                {
                    Console.WriteLine("Allons y Lamborghini");
                }
                else
                {
                    Console.WriteLine("Lamborghini is off, turn it on");
                }            
            }
        }
    }
}