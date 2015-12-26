using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace CycleSerializer
{
    [Serializable]
    public class A
    {
        public double b;
        public C c;

        public A()
        {
            b = 1.0;

        }
    }

    [Serializable]
    public class D
    {
        public C c;
        public double e;

        public D()
        {
            e = 3.0;
        }
    }

    public class C
    {
        public int k = 100;

    }

    class Program
    {


        static void Main(string[] args)
        {
            XmlSerializer binA = new XmlSerializer(typeof(A));
            XmlSerializer binD = new XmlSerializer(typeof(D));
            var ogga = new A();
            var oggd = new D();
            var oggc = new C();

            var pathA = @"c:\users\Iacopo\desktop\a.ser";
            var pathD = @"c:\users\Iacopo\desktop\d.ser";

            ogga.c = oggc;
            oggd.c = oggc;

//            oggc.k = 200;
        

            var fa = File.OpenWrite(pathA);
            binA.Serialize(fa, ogga);
            fa.Flush();
            fa.Close();

            var fd = File.OpenWrite(pathD);
            binD.Serialize(fd, oggd);
            fd.Flush();
            fd.Close();


            fa = File.OpenRead(pathA);
            var desA = binA.Deserialize(fa) as A;
            fa.Flush();
            fa.Close();

            fd = File.OpenRead(pathD);
            var desD = binD.Deserialize(fd) as D;
            fd.Flush();
            fd.Close();

            desD.c.k = 40000;
            

            Console.ReadLine();


        }
    }
}
