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

            PhoneTypeChecker samsung = new PhoneTypeChecker(Manufacturers.SAMSUNG);
            PhoneTypeChecker htc = new PhoneTypeChecker(Manufacturers.HTC);
            PhoneTypeChecker nokia = new PhoneTypeChecker(Manufacturers.NOKIA);

            Console.WriteLine("\nSamsung Products");
            samsung.CheckProducts();

            Console.WriteLine("\nHTC Products");
            htc.CheckProducts();

            Console.WriteLine("\nNokia Products");
            nokia.CheckProducts();

            Console.WriteLine("\n\nPress any key to exit...");
            Console.ReadKey();

        }
    }



    class PhoneTypeChecker : IPhoneFactory
    {
        public IPhoneFactory factory;
        public Manufacturers manu;

        public PhoneTypeChecker(Manufacturers m)
        {
            manu = m;
        }

        public void CheckProducts()
        {
            if (manu == Manufacturers.SAMSUNG)
            {
                factory = new SamsungFactory();
                Console.WriteLine("Smart: " + GetSmart().GetName() + "\nDumb: " + GetDumb().GetName());
            }

            else if (manu == Manufacturers.HTC)
            {
                factory = new HTCFactory();
                Console.WriteLine("Smart: " + GetSmart().GetName() + "\nDumb: " + GetDumb().GetName());
            }

            else if (manu == Manufacturers.NOKIA)
            {
                factory = new NokiaFactory();
                Console.WriteLine("Smart: " + GetSmart().GetName() + "\nDumb: " + GetDumb().GetName());
            }
        }

        public ISmart GetSmart()
        {
            return factory.GetSmart();
        }

        string ISmart.GetName()
        {
            return factory.GetSmart().GetName();
        }

        public IDumb GetDumb()
        {
            return factory.GetDumb();
        }

        string IDumb.GetName()
        {
            return factory.GetDumb().GetName();
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

    class Lumia : ISmart
    {
        string ISmart.GetName()
        {
            return "Lumia";
        }
    }

    class GalaxyS2 : ISmart
    {
        string ISmart.GetName()
        {
            return "GalaxyS2";
        }
    }

    class Titan : ISmart
    {
        string ISmart.GetName()
        {
            return "Titan";
        }
    }

    class Asha : IDumb
    {
        string IDumb.GetName()
        {
            return "Asha";
        }
    }

    class Genie : IDumb
    {
        string IDumb.GetName()
        {
            return "Genie";
        }
    }

    class Primo : IDumb
    {
        string IDumb.GetName()
        {
            return "Primo";
        }
    }

    class SamsungFactory : IPhoneFactory // smart: GalaxyS2 | dumb: Genie
    {
        ISmart IPhoneFactory.GetSmart()
        {
            return new GalaxyS2();
        }

        IDumb IPhoneFactory.GetDumb()
        {
            return new Genie();
        }

        string ISmart.GetName()
        {
            return "GalaxyS2";
        }

        string IDumb.GetName()
        {
            return "Genie";
        }
    }

    class HTCFactory : IPhoneFactory // smart: Titan | dumb: Primo
    {
        ISmart IPhoneFactory.GetSmart()
        {
            return new Titan();
        }

        IDumb IPhoneFactory.GetDumb()
        {
            return new Primo();
        }

        string ISmart.GetName()
        {
            return "Titan";
        }

        string IDumb.GetName()
        {
            return "Primo";
        }
    }

    class NokiaFactory : IPhoneFactory // smart: Lumia | dumb: Asha
    {
        ISmart IPhoneFactory.GetSmart()
        {
            return new Lumia();
        }

        IDumb IPhoneFactory.GetDumb()
        {
            return new Asha();
        }

        string ISmart.GetName()
        {
            return "Lumia";
        }

        string IDumb.GetName()
        {
            return "Asha";
        }
    }
}
