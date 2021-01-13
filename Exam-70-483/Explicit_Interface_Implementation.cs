using System;
using System.Collections.Generic;
using System.Text;

namespace Exam_70_483
{
    public interface IFirst
    {
        void DoSomething();
    }

    public interface ISecond
    {
        void DoSomething();
    }

    public class Explicit_Interface_Implementation : IFirst, ISecond
    {
        public void DoSomething()
        {

        }

        void ISecond.DoSomething()
        {

        }
    }

    public class Use_Explicit_Interface_Implementation
    {
        public void Test()
        {
            var test = new Explicit_Interface_Implementation();
            test.DoSomething(); //chamada do método publico
            ((ISecond)test).DoSomething(); //chamada do método explicitamente implementado
        }
    }

    public interface DropShipV1
    {
        bool DropShip(string nome, object[] podutos);
    }

    public interface DropShipV2
    {
        bool DropShip(string nome, object[] podutos);
    }

    public class DopShipImplementation :
        DropShipV1, DropShipV2
    {
        bool DropShipV1.DropShip(string nome, object[] podutos)
        {
            throw new NotImplementedException();
        }

        bool DropShipV2.DropShip(string nome, object[] podutos)
        {
            throw new NotImplementedException();
        }
    }

    public class DopShipImplementation_ :
    DropShipV1, DropShipV2
    {
       public bool DropShip(string nome, object[] podutos)
        {
            throw new NotImplementedException();
        }

        bool DropShipV2.DropShip(string nome, object[] podutos)
        {
            throw new NotImplementedException();
        }

        //[Documentation("teste", Modified = "teste1")];
        //[Documentation(Modified = "teste1", "teste")];

        //[Documentation("teste", Modified = "teste1")]
        public Documentation MyProperty { get; set; }
    }

    [System.AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct)]
    public class Documentation : System.Attribute
    {
        private string Autor { get; set; }
        public string Modified { get; set; }
        public Documentation(string author)
        {
            this.Autor = author;
            Modified = DateTime.Now.ToString();
        }
    }
}
