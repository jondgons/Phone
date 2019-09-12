using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phone
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }



    class PhoneTypeChecker : IPhoneFactory
    {
        public IPhoneFactory factory;
        public Manufacturers manu;

        public PhoneTypeChecker(Manufacturers m)
        {

        }

        public void CheckProducts()
        {

        }

        public ISmart GetSmart()
        {

        }

        string ISmart.GetName()
        {

        }

        public IDumb GetDumb()
        {

        }

        string IDumb.GetName()
        {

        }
    }

    enum Manufacturers
    {
        SAMSUNG,
        HTC,
        NOKIA
    }

    interface IPhoneFactory : ISmart , IDumb
    {
        ISmart GetSmart();

        IDumb GetDumb();
    }

    interface ISmart
    {
        string GetName();
    }

    interface IDumb
    {
        string GetName();
    }
}
