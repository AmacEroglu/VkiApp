

public class Program
{

    public struct VKI
    {
        public double patientHeight;
        public double patientWeight;
        public double bodyIndex;
        public string diagnosis;
        public string hastaninİsmi;
       

        public  double PatientResult()
        {
            return (patientWeight / (patientHeight/100 * patientHeight/100));
        }
        
        public void WriteScreen()
        {

            Console.WriteLine($"Hastanın İsmi: {hastaninİsmi}");
            Console.WriteLine($"Patient Height: {patientHeight}");
            Console.WriteLine($"Patient Weight: {patientWeight}");
            Console.WriteLine($"Diagnosis: {diagnosis}");
            Console.WriteLine($"Body Index: {PatientResult()}");
        }


        public void BodyIndex()
        {
            bodyIndex = PatientResult();
            if ( bodyIndex < 18)
            {
                diagnosis = "Zayıf";
            }
            if (bodyIndex >18 && bodyIndex < 25)
            {
                diagnosis = "İdeal";
            }
            if (bodyIndex > 25 && bodyIndex < 30)
            {
                diagnosis = "Hafif Kilolu";
            }
            if (bodyIndex > 30 )
            {
                diagnosis = "Obez";
            }

        }

    }


    static List<VKI> VKIlist = new List<VKI>();

    static void Main()
    {
        Menu();
    }

     static void Menu()
    {
        Console.Clear();
        Console.WriteLine("1.Yeni Hasta\n2. Hasta Listesi\n3. Çıkış");
        MenuSelection();
    }

    static void MenuSelection()
    {
        Console.Write("Yapılacak işlemi seçin : ");
        string choose = Console.ReadLine();
        switch (choose)
        {
            case "1":
                NewVKI();
                break;
            case "2":
                ListOfPatient();
                break;
            case "3":
                Environment.Exit(0);
                break;
            default:
                Console.WriteLine("Hatalı seçim yaptınız. Lütfen tekrar değer girin.");
                MenuSelection();
                break;
               
        }
    }

    private static void ListOfPatient()
    {
        Console.Clear();

        foreach (var patient in VKIlist)
        {
            ConsoleColour(patient.diagnosis);
            patient.WriteScreen();
            ChangeColour();
        }
        Again();
    }

    static void NewVKI()
    {
        VKI x = new VKI();
        x.diagnosis = "";

        Console.Write("Hastanın İsmi: ");
        x.hastaninİsmi = Console.ReadLine();
        Console.Write("Hastanın boyu: ");
        x.patientHeight = Convert.ToDouble(Console.ReadLine());
        Console.WriteLine(x.patientHeight);
        Console.Write("Hastanın kilosu: ");
        x.patientWeight = Convert.ToDouble(Console.ReadLine());

        Console.Clear();

        x.BodyIndex();
        ConsoleColour(x.diagnosis);
        x.WriteScreen();
        ChangeColour();

        VKIlist.Add(x);
        Again();
    }

    static void Again()
    {
        Console.WriteLine("Yeni bir işlem yapmak ister misin? (y/n).".ToLower());
        string answer = Console.ReadLine();
        if (answer=="y")
        Menu();
        if (answer=="n")
            Environment.Exit(0);
        else
        {
            Console.WriteLine("Lütfen doğru bir değer giriniz");
            Again();
        }
    }

        
      static void ConsoleColour(string diagnosis)
    {
        switch (diagnosis)
        {
            case "Zayıf":
                Console.ForegroundColor = ConsoleColor.Yellow;
                break;
            case "İdeal":
                Console.ForegroundColor = ConsoleColor.Green;
                break;
            case "Hafif Kilolu":
                Console.ForegroundColor = ConsoleColor.Yellow;
                break;
            case "Obez":
                Console.ForegroundColor = ConsoleColor.Red;
                break;
            default:
                break;

        }
    }

    static void ChangeColour()
    {
        Console.ResetColor();
    }

    static void ReturnToMenu()
    {
        Console.WriteLine("Menüye dönmek için Enter'a basın");
        Console.ReadLine();
        Menu();
    }


}
