using System;
using System.Collections.Generic;
using System.Text;

namespace Exam_70_483
{
    public class MulticastDelegatesExample
    {
        public List<string> Execucoes = new List<string>();
        public int Contador = 0;
        public int DoSomething(int x, int y)
        {
            Contador++;
            Console.WriteLine($"Retorno:{10}. Contador: {Contador} - DoSomething");
            Execucoes.Add("DoSomething");
            return 10;
        }

        public int DoAnotherThing(int a, int b)
        {
            Contador++;
            Console.WriteLine($"Retorno:{5}.  Contador: {Contador} - DoAnotherThing");
            Execucoes.Add("DoAnotherThing");
            return 5;
        }

        public int DoThat(int a, int b)
        {
            Contador++;
            Console.WriteLine($"Retorno:{1}.  Contador: {Contador}  - DoThat");
            Execucoes.Add("DoThat");
            return 1;
        }
    }

    public class MulticastDelegatesExample_Use
    {
        public delegate int TipoDelegate(int var1, int var2);
        public void Test()
        {
            var example = new MulticastDelegatesExample();
            TipoDelegate del = example.DoSomething;
            //adicionando uma chamada de método ao delegate
            del += example.DoAnotherThing;
            //um método pode ser adicionado mais de uma vez
            del += example.DoAnotherThing;
            del += example.DoSomething;
            del += example.DoSomething;
            del += example.DoThat;
            //removendo uma chamada de método do delegate
            del -= example.DoThat;
            del -= example.DoSomething;

            //resultado será do último método executado (DoSomething) que é 10
            int resultado = del(3, 4);
            Console.WriteLine();
            Console.WriteLine($"Resultado: {resultado}");
            Console.ReadKey();
            //Contador será igual a 4, pois:
            //- "DoSomething" foi executado 2 vezes
            //- "DoAnotherThing" foi executado 2 vezes
            //- "DoThat" não foi executado nenhuma vez
        }
    }
}
