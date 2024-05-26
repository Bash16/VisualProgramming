using System;

namespace Q1
{
    /* 'a' part of question 
     
    class Telephone
    {
        protected string phoneType;

        public void Ring()
        {
            Console.WriteLine($"\nRinging the {phoneType}");
        }
    }

    class ElectronicPhone : Telephone
    {
        public ElectronicPhone()
        {
            phoneType = "Digital";
        }
        public void Run()
        {
            Ring();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            ElectronicPhone phone = new ElectronicPhone();
            phone.Run();
        }
    }
    */


    // -------------------------------------------------------------------------------------------------------------------------


    /* 'b' part of question
    class Telephone
    {
        protected string phoneType;

        public virtual void Ring()
        {
            Console.WriteLine($"\nRinging the {phoneType}");
        }
    }

    class ElectronicPhone : Telephone
    {
        public ElectronicPhone()
        {
            phoneType = "Digital";
        }
        public override void Ring()
        {
            Console.WriteLine("\nElectronic phone is ringing");
        }
        public void Run()
        {
            Ring();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            ElectronicPhone phone = new ElectronicPhone();
            phone.Run();

            Telephone tphone = new ElectronicPhone();
            tphone.Ring();
        }
    }     
    */

    // ---------------------------------------------------------------------------------------------------------------------------

    // /* 'c' part of question

    abstract class Telephone
    {
        protected string phonetype;

        public Telephone(string type)
        {
            phonetype = type;
        }

        public abstract void Ring();
    }

    class DigitalPhone : Telephone
    {
        public DigitalPhone() : base("Digital")
        {
        }

        public override void Ring()
        {
            Console.WriteLine($"Ringing the {phonetype} phone.");
        }
    }

    class TalkingPhone : Telephone
    {
        public TalkingPhone() : base("Talking")
        {
        }

        public override void Ring()
        {
            Console.WriteLine($"Ringing the {phonetype} phone.");
        }
    }

    class Program
    {
        static void Main()
        {
            Telephone digitalPhone = new DigitalPhone();
            Telephone talkingPhone = new TalkingPhone();

            digitalPhone.Ring();
            talkingPhone.Ring();
        }
    }

    // */
}