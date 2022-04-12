namespace Calculadora{

    class Program 
    { 
        static void Main(String[] args)
        {
            inicie:
            Console.Clear();

            Console.WriteLine("Primeiro valor: ");
            float v1 = float.Parse(Console.ReadLine());
            
            Console.WriteLine("Operação:");
            string operacao = Console.ReadLine();

            Console.WriteLine("Segundo Valor: ");
            float v2 = float.Parse(Console.ReadLine());


          switch(operacao){
              case "+": Soma(v1,v2); break;
              case "-": Sub(v1,v2); break;
              case "*": Mult(v1,v2); break;
              case "0": break;
          }
            string cont = Console.ReadLine();
            if(cont.Equals(string.Empty))
                goto inicie;
        }
        static void Mult(float valor1, float valor2){

            Console.WriteLine("");

            float resultado = valor1*valor2;
            
            Console.WriteLine($"Resultado: {resultado}");

        }
        static void Sub(float valor1, float valor2){

            Console.WriteLine("");

            float resultado = valor1-valor2;
            
            Console.WriteLine($"Resultado: {resultado}");

        }
        static void Soma(float valor1, float valor2){

            Console.WriteLine("");

            float resultado = valor1+valor2;
            
            Console.WriteLine($"Resultado: {resultado}");

        }

    }
}