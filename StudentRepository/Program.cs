using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentRepository
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.WriteLine("Моля, въведете факултетен номер: ");
            int fN = int.Parse(Console.ReadLine());
            string c = StudentData.PrepareCertificate(fN);           
            if(c!=null)
            {
                Console.WriteLine(c);
                Console.WriteLine("Моля, въведете директория, в която да запишете сертификата: ");
                string fL = Console.ReadLine();
                StudentData.WriteCertificate(c, fL);
            }
        }
    }
}
