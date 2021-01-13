using Exam_70_483.Value_and_Reference_Type;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Security.Permissions;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace Exam_70_483
{
    class Program
    {
        static void Main(string[] args)
        {
            var teste = new Livro(10);
            teste.Teste();

            var teste22 = new Livro2(10);
            teste.Teste();

            string[] vendedores = { "a", "b", "c" };
            for (int i = 0; i < vendedores.Rank; i++)
            {
                Console.WriteLine(vendedores[i]);
            }

            for (int i = 0; i < vendedores.Length; i++)
            {
                Console.WriteLine(vendedores[i]);
            }

            var teste1 = new Pessoa();
            //teste.TesteProperty;
            teste1.GetPessoas();

            var teste3 = new ClienteHerdado();
            Console.WriteLine(teste3.VerificaTipoCliente(new ClienteHerdado()));
            Console.WriteLine(teste3.VerificaTipoCliente(new Pessoa()));
            Console.ReadKey();

            var carro = new Carro();
            var testes = carro.GetVehicles().Where(v => v.Make == "Honda").Select(x => x.Make);

            var testes1 = from v in carro.GetVehicles() where v.Make == "Honda" select v;
            var testes2 = testes1.ToList();

            Point3d p = (Point3d)new Point2d(3d, 5d);

            //Point2d p1 = new Point3d(1d, 1d, 1d) as Point2d;//errado

            //Point2d p2 = new Point3d(1d, 1d, 1d);//errado

            Point2d p2 = (Point2d)new Point3d(1d, 1d, 1d);

            Point3d p3 = new Point2d(3d, 2d);


            var listaNomes = new List<string>() {
                "Don Brenn",
                "Jim Frankin",
                "Liz Putnam",
                "Pat Chunning",
                "Abe Felix",
                "Huan Seth",
                "Kim Frend",
                "Max Wen",
                "Ron Case"
            };

            var result = listaNomes.Skip(3).OrderBy(c => c).Take(5).ToList();
            result.ForEach(x => Console.WriteLine(x));
            Console.ReadKey();

            //teste = new Pessoa();
            //teste.test
            //teste.TesteAcion(x =>
            //{
            //    x.Nome = "Fulano";
            //    x.Idade = 3;
            //});

            //var test = new Caso2("asuhduas");
            //test.Teste2();

            var sw = new Stopwatch();

            var nList = new List<string>();
            nList.Add("aieuhaiuehiuaheiuaehiua");
            nList.Add("aieuhaiuehiuaheiuaehiua");
            nList.Add("aieuhaiuehiuaheiuaehiua");
            nList.Add("aieuhaiuehiuaheiuaehiua");
            nList.Add("aieuhaiuehiuaheiuaehiua");
            nList.Add("aieuhaiuehiuaheiuaehiua");
            nList.Add("aieuhaiuehiuaheiuaehiua");
            nList.Add("aieuhaiuehiuaheiuaehiua");
            nList.Add("aieuhaiuehiuaheiuaehiua");
            nList.Add("aieuhaiuehiuaheiuaehiua");

            var nList_local = new List<string>();
            Console.Clear();
            sw.Reset();
            sw.Start();
            Parallel.ForEach(nList, file =>
            {
                nList_local.Add(file);
            });
            sw.Stop();
            Console.WriteLine(string.Format("Parallel Tempo: {0}, Milessegundos: {1}", sw.Elapsed, sw.ElapsedMilliseconds));

            sw.Reset();
            sw.Start();
            nList.ForEach(l => nList_local.Add(l));
            sw.Stop();
            Console.WriteLine(string.Format("ForEach Tempo: {0}. Milessegundos: {1}", sw.Elapsed, sw.ElapsedMilliseconds));

            Console.ReadKey();

            try
            {

            }
            catch (IOException ex)
            {

                throw;
            }
        }
    }

    public class Window
    {

    }

    public class MainWindows
        <T>
        : Window
        where T : INotifyPropertyChanged, new()
    { }

    public interface IRepository<TEntity> : IDisposable where TEntity : class, new()
    {
        void Adicionar(TEntity entity);
        void Atualizar(TEntity entity);
        void Excluir(TEntity entity);
        void SalvarAlteracoes();
        TEntity ObterPorId(string id);
    }

    public class MultiThreadingExampleTest
    {
        public void Test()
        {

            //WriteDot executará em uma Thread separada de WriteO, portanto, paralelamente.
            Thread thread1 = new Thread(WriteRedDot)
            {
                Name = "WriteRedDot",
                Priority = ThreadPriority.Lowest
            };
            Thread thread2 = new Thread(WriteBlueO)
            {
                Name = "WriteBlueO",
                Priority = ThreadPriority.Highest
            };

            Console.WriteLine($"Thread {thread1.Name} iniciando");
            Console.WriteLine($"Prioridade {thread1.Priority}");
            Console.WriteLine();
            thread1.Start();
            Console.WriteLine($"Thread {thread2.Name} iniciando");
            Console.WriteLine($"Prioridade {thread2.Priority}");
            Console.WriteLine();
            thread2.Start();

            Console.ReadKey();
        }

        public void WriteRedDot()
        {
            for (int i = 0; i < 1000; i++)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(".");
            }
        }

        public void WriteBlueO()
        {
            for (int i = 0; i < 500; i++)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write("O");
            }
        }
    }

    public class AsyncAwaitDemo
    {
        public async Task DoStuff()
        {

            await Task.Run(() => ContarAte50());

            Console.WriteLine("Contagem até 50 finalizada.");
        }

        public async Task<string> ContarAte50()
        {
            int cont;
            for (cont = 0; cont < 51; cont++)
                Console.WriteLine($"BG thread: {cont}");

            return $"Contador: {cont}";
        }
    }

    public class SecurityDataExample
    {
        private readonly string FILE_PATH = @"C:\Users\Diego\Documents\Diego\Dev\GitHub\exam-70-483\TESTE.txt";
        public void ReadFile()
        {
            var lines = File.ReadAllLines(FILE_PATH);
            foreach (var line in lines)
                Console.WriteLine(line);

            //Console.WriteLine("Encriptar o arqivo");
            //Encrypt(FILE_PATH);
            //
            //Console.WriteLine("Decriptar o arqivo");
            //Decrypt(FILE_PATH);
        }

        public void Encrypt(string filePath)
        {
            File.Encrypt(filePath);
        }

        public void Decrypt(string filePath)
        {
            File.Decrypt(filePath);
        }
    }

    public class Caso1
    {
        protected string Nome { get; set; }

        protected Caso1()
        {
            Nome = string.Empty;
        }

        public Caso1(string nome)
        {
            Nome = nome;
        }


    }

    public class Caso2 : Caso1
    {
        private Caso2()
        {

        }

        public Caso2(string nome) : base(nome)
        {

            try
            {

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void Teste1()
        {
            try
            {
                throw new ArgumentException("teste12234234");
            }
            catch (Exception ex)
            {
                Teste3(ex);
                throw;
            }
        }

        public void Teste2()
        {
            try
            {
                Teste1();
            }
            catch (Exception ex)
            {
                //if(!EventLog.SourceExists("sourceTeste"))
                //{
                //    EventLog.CreateEventSource("sourceTeste","log123");
                //}

                EventLog eventLog = new EventLog("log123");
                eventLog.Source = "sourceTeste";
                eventLog.WriteEntry("log de teste");
            }
        }

        public void Teste3(Exception ex)
        {

        }
    }

    public class Produto
    {
        public string ID { get; set; }
        public string Nome { get; set; }

        public void Teste()
        {
            List<int> numeros = GetRandonNumbers();
            IEnumerable<IGrouping<int, int>> query = from numero in numeros group numero by numero % 2;



            //var teste2 = (x,y) => x.ID < y.ID ? -1 : 
        }

        private List<int> GetRandonNumbers()
        {

            var rand = new Random();
            var rtnlist = new List<int>();

            for (int i = 0; i < 100000; i++)
                rtnlist.Add(rand.Next(1000));

            return rtnlist;
        }
    }

    public class ProdutoList : List<Produto>
    {
        public static ProdutoList GetProdutos()
        {

            return null;
            //var query = from p in ProdutoList.GetProdutos() select p.Nome;
            //return query;
        }

        public interface Teste
        {
            int MyProperty { get; }
            int MyProperty1 { get; set; }
        }

    }

    public struct Point2d
    {
        public double X { get; set; }
        public double Y { get; set; }
        public Point2d(double x, double y) : this()
        { X = x; Y = y; }
    }
    public struct Point3d
    {
        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }
        public static explicit operator Point2d(Point3d value)
        { return new Point2d(value.X, value.Y); }

        public static implicit operator Point3d(Point2d value)
        { return new Point3d(value.X, value.Y, 0d); }

        public Point3d(double x, double y, double z) : this()
        { X = x; Y = y; Z = z; }
    }

    public class Livro2 : Livro
    {
        public readonly int Teste2;
        protected Livro2() { }
        public Livro2(int teste) : base(teste)
        {
            Teste2 = teste;
        }
    }

    public class Livro
    {
        public string Titulo { get; set; }
        public string ISBN { get; set; }
        public Autor Autor { get; set; }
        public List<Autor> Autores { get; set; }
        public int TesteProperty { get; internal set; }

        protected Livro() : this(0) { }
        public Livro(int teste)
        {
            TesteProperty = teste;
        }

        public void Teste()
        {
            var livros = new List<Livro>() {
            new Livro(){Titulo = null , ISBN = "465as4d55", Autor = new Autor() { Nome = "NOME_AUTOR_ATIVO1", Active = "Enviado"} },
            new Livro(){Titulo = null , ISBN = "465as4d57", Autor = new Autor() { Nome = "NOME_AUTOR_INATIVO1", Active = "Pendente"} },
            new Livro(){Titulo = null , ISBN = "465as4d58", Autor = new Autor() { Nome = "NOME_AUTOR_ATIVO2", Active ="Enviado"} },
            new Livro(){Titulo = null , ISBN = "465as4d59", Autor = new Autor() { Nome = "NOME_AUTOR_INATIVO2", Active ="Pendente"} },
            new Livro(){Titulo = null , ISBN = "465as4d60", Autor = new Autor() { Nome = "NOME_AUTOR_INATIVO3", Active ="Pendente"} }
            };

            var livros_ComLista = new List<Livro>()
            {
                new Livro()
                {
                    Titulo = null ,
                    ISBN = "465as4d55",
                    Autores = new List<Autor>(){
                        new Autor() { Nome = "NOME_AUTOR_ATIVO1", Active = "Ativo", Status = Status.PossuiStatus},
                        new Autor() { Nome = "NOME_AUTOR_INATIVO1", Active = "Pendente", Status = Status.NaoPossuiStatus},
                        new Autor() { Nome = "NOME_AUTOR_ATIVO2", Active ="Ativo",Status = Status.PossuiStatus},
                        new Autor() { Nome = "NOME_AUTOR_INATIVO2", Active ="Pendente", Status = Status.NaoPossuiStatus},
                        new Autor() { Nome = "NOME_AUTOR_INATIVO3", Active ="Pendente", Status = Status.NaoPossuiStatus}
                    }
                },

                new Livro()
                {
                    Titulo = null ,
                    ISBN = "465as4d56",
                    Autores = new List<Autor>(){
                        new Autor() { Nome = "NOME_AUTOR_ATIVO1", Active = "Enviado", Status = Status.PossuiStatus},
                        new Autor() { Nome = "NOME_AUTOR_INATIVO1", Active = "Pendente", Status = Status.NaoPossuiStatus},
                        new Autor() { Nome = "NOME_AUTOR_ATIVO2", Active ="Enviado", Status = Status.PossuiStatus},
                        new Autor() { Nome = "NOME_AUTOR_INATIVO2", Active ="Pendente", Status = Status.NaoPossuiStatus},
                        new Autor() { Nome = "NOME_AUTOR_INATIVO3", Active ="Pendente", Status = Status.NaoPossuiStatus}
                    }
                }
            };


            var pessoa = new Pessoa();
            pessoa.CalcArea(with: 30, lenght: 20);
            pessoa.CalcArea(lenght: 30, with: 20);

            pessoa.CalcArea(30, with: 20);
            pessoa.CalcArea(lenght: 20, 30);

            var query = from b in livros select new { b.Titulo, b.ISBN, NomeAutor = b.Autor.Nome };


            var query1 = from b in livros
                         select new
                         {
                             Nome = b.Titulo ?? "VIZINHO",
                             b.ISBN,
                             NomeAutor = b.Autor.Nome
                         };

            TcpClient client = new TcpClient("www.google.com", 80);
            using (NetworkStream networkStream = client.GetStream())
            {
                StreamWriter writer = new StreamWriter(networkStream);
                writer.Write("Sending Network Data");
                writer.Flush();
            }

            try
            {
                var teste243 = livros_ComLista.Where(x => x.Autores.Any(an => an.Active.Contains("Pendente"))).ToList();
                var teste2452 = livros_ComLista.Where(x => x.Autores.Any(an => an.Active.Contains("Enviado"))).ToList();
                var teste2456 = livros_ComLista.Where(x => x.Autores.Any(an => an.Active.Contains("ativo"))).ToList();

                var teste24567 = livros_ComLista.Where(x => x.Autores.Any(an => an.Status == Status.PossuiStatus)).ToList();

                //throw new Exception("abc");
            }
            finally
            {
                //switch (Status)
                //{
                //    case Status.PossuiStatus:
                //        break;
                //    case Status.NaoPossuiStatus:
                //        break;
                //    default:
                //        break;
                //}
            }

            //TcpListener listener = new TcpListener(IPAddress.Any, 500);
            //listener.Start();
            //TcpClient client1 = listener.AcceptTcpClient();
            //NetworkStream stream = client1.GetStream();
            //using (StreamReader reader = new StreamReader(stream))
            //{
            //    string message = reader.ReadToEnd();
            //}

            try
            {
                checked
                {
                    try
                    {
                        var a = int.MaxValue;
                        var b = int.MaxValue;

                        var res = a + b;
                    }
                    catch (Exception ex)
                    {


                    }
                }
            }
            catch (Exception ex)
            {


            }

            var teste244 = "abc";
            Monitor.Enter(teste244);
            //envia um email
            Monitor.Exit(teste244);

            lock (teste244)
            {
                //envia um email

            }

            string[] vendedores = { "a", "b", "c" };
            for (int i = 0; i < vendedores.Length; i++)
            {
                Teste2(vendedores[i]);
            }


            try
            {
                var dicionario = new Dictionary<int, string>() {
                    { 1, "a" },
                    { 2, "b" }
                };
            }
            catch (TaskCanceledException ex)
            {

                throw;
            }

            StarTrace(29.33, message: "Catch me if you can");
            StarTrace(message: "Catch me if you can", aceleration: 29.33);

            var fileContests = from livro in livros.AsParallel()
                               let extension = Path.GetExtension(livro.ToString())
                               where extension == ".txt"
                               let text = File.ReadAllText(livro.ToString())
                               select new { Text = text, FileName = livro.ToString() };


            var listaPlanetas = (IEnumerable<Planeta>)typeof(Planeta).GetEnumValues();
        }

        [PrincipalPermission(SecurityAction.Demand, Role = "BUILTIN\\Users")]
        private void StarTrace(double aceleration, bool musicOn = true, string message = "")
        {
            //Exhibit exhibit = new Exhibit();

            SourceSwitch sourceSwitch = new SourceSwitch("MeuSwitch");
            var teste = sourceSwitch.Attributes.Values;
            TraceSwitch traceSwitch = new TraceSwitch("MeuSwitch", "APENAS UM TESTE");
            var teste1 = traceSwitch.Attributes.Values;
        }

        //unsafe private void SomeMethod()
        //{
        //    var arraysOfInts = new int[20073600];
        //    fixed (int* firstElement = &arraysOfInts[0])
        //    {
        //        InitializeArrayOfInts(firstElement, arraysOfInts.Length);
        //    }
        //}

        [Conditional("Debug")]
        public void Teste2(string parametro1)
        {
            Console.WriteLine(parametro1);
        }
#if (RELEASE)
        enum Categorias
        {
            Desconhecido = -1,
            Planta,
            Animal,
            Mineral,
            Count
        }
#endif


    }

    public enum Planeta
    {
        Mercurio,
        Venus,
        Terra,
        Marte,

    }
    public class Carro
    {
        public string Make { get; set; }

        public List<Carro> GetVehicles()
        {
            return new List<Carro>() {
            new Carro(){Make = "Honda"},
            new Carro(){Make = "Chevy"}

            };
        }
    }
    public enum Status
    {
        PossuiStatus,
        NaoPossuiStatus
    }
    public class Autor
    {
        public string Nome { get; set; }
        public string Active { get; set; }
        public Status Status { get; set; }
    }

    public class Pessoa
    {
        public string Nome { get; set; }
        public int Idade { get; set; }
        private Livro livro = new Livro(10);

        //[Conditional("DEBUG")]
        public int MyProperty { get; set; }

        public List<Pessoa> GetPessoas()
        {
            var pessoa = new List<Pessoa>() {
            new Pessoa(){Nome = "abc" , Idade = 10 },
            new Pessoa() { Nome = "bruna", Idade = 28 },
            new Pessoa() { Nome = "diego", Idade = 27 },
            new Pessoa() { Nome = "pipoca", Idade = 4 },
            new Pessoa() { Nome = "bruna", Idade = 25 },
            };

            var result = pessoa.OrderBy(x => x.Nome).ThenBy(x => x.Idade);

            lock (livro)
            {
                if (Idade == 0)
                {
                    Console.WriteLine($"{DateTime.Now,6:HH:mm}");
                    Console.ReadKey();
                }
            }



            return result.ToList();
        }

        public void CalcArea(int lenght, int with)
        {

        }

        public void TesteAcion(Action<PessoaDTO> action)
        {
            Func<PessoaDTO, Pessoa> func = (action) => { return new Pessoa(); };
        }
    }

    public class Encriptar
    {
        public void Teste()
        {
            string original = "abc";
            byte[] key = new byte[] { 1 };
            byte[] iv = new byte[] { 2 };
            byte[] encryptedData = null;

            using (Rijndael r = Rijndael.Create())
            {
                r.Key = key;
                r.IV = iv;

                ICryptoTransform encryptor = r.CreateDecryptor(key, iv);
                using (MemoryStream ms = new MemoryStream(encryptedData))
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter writer = new StreamWriter(cs))
                        {
                            writer.Write(original);
                        }

                        encryptedData = ms.ToArray();
                    }
                }
            }

            string encryptedString = "";
            using (Rijndael r = Rijndael.Create())
            {
                ICryptoTransform decryptor = r.CreateDecryptor(r.Key, r.IV);
                using (MemoryStream ms = new MemoryStream(encryptedData))
                {
                    using (CryptoStream cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader reader = new StreamReader(cs))
                        {
                            encryptedString = reader.ReadToEnd();
                        }
                    }
                }
            }

            Console.WriteLine($"Original: {original} - Encryptada: {encryptedData} - Decriptada: {encryptedString}");
            Console.ReadKey();
        }
    }

    public abstract class Cliente
    {
        public virtual void Draw()
        {

        }

        public void Teste()
        {
            string pattern = @"\b(\w+)\s\1\b";
            Regex rgx = new Regex(pattern, RegexOptions.IgnoreCase);


        }
    }

    public class ClienteHerdado : Cliente
    {
        public ClienteHerdado()
        {

        }

        public override void Draw()
        {
            base.Draw();
        }

        public bool VerificaTipoCliente(object obj)
        {
            return obj is Cliente || obj is ClienteHerdado;
        }
    }

    [Documentation("Teste", Modified = "06/01/2021")]
    public class PessoaDTO
    {
        //[Compare(descending = true)]
        public string Nome { get; set; }
        public int Idade { get; set; }
    }

    [AttributeUsage(AttributeTargets.Property)]
    public class CompareAttribute : Attribute
    {
        public CompareAttribute(int order)
        {
            this.order = order;
        }

        public CompareAttribute(bool desc)
        {
            descending = desc;
        }

        public bool descending { get; set; }
        private int order;
    }

}
