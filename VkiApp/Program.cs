

public class Program
{

    struct VKI
    {
        public double patientHeight;
        public double patientWeight;
        public double bodyIndex;
        public string diagnosis;

        public  double PatientResult()
        {
            return (patientWeight / (patientHeight/100 * patientHeight/100));
        }
        
        public void WriteScreen()
        {
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
            if (bodyIndex >18 && bodyIndex < 24)
            {
                diagnosis = "İdeal";
            }
            if (bodyIndex > 25 && bodyIndex < 30)
            {
                diagnosis = "Hafif kilolu";
            }
            if (bodyIndex > 30 )
            {
                diagnosis = "Obez";
            }

        }

    }


    static void Main()
    {
        Menu();
    }

     static void Menu()
    {
        Console.Clear();

        Console.WriteLine("Lütfen hasta bilgilerini girin.");
        NewVKI();
    }

    static void NewVKI()
    {
        VKI x = new VKI();

        Console.Write("Hastanın boyu: ");
        x.patientHeight = Convert.ToDouble(Console.ReadLine());
        Console.WriteLine(x.patientHeight);
        Console.Write("Hastanın kilosu: ");
        x.patientWeight = Convert.ToDouble(Console.ReadLine());

        x.BodyIndex();
        x.WriteScreen();
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


}
