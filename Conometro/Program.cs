namespace Calculadora{

    class Program 
    { 
        static void Main(String[] args)
        {
            start(15);
        }

        static void Menu(){

            Console.WriteLine("Insira q quantidade de tempo desejada: (S - Segundos M - Minutos");
            string tempo = Console.ReadLine().ToLower();

        }

        static void start(int time){
            int currentTime = 0;

            while( currentTime != time ){
                currentTime++;
                string a="0";
                Console.Clear();
                if(currentTime>=10)
                    a = "";
                Console.WriteLine($"00:00:{a}{currentTime}");
                Thread.Sleep(1000);
            }

            Console.WriteLine("Tempo Finalizado");

            Thread.Sleep(5000);
        }
    }
}