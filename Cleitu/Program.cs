using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        int opcao = Menu();
        double resultado = 0;

        while (opcao != 11)
        {
            switch (opcao)
            {
                case 1:
                    resultado = Somar();
                    break;
                case 2:
                    resultado = Dividir();
                    break;
                case 3:
                    resultado = Fatorial();
                    break;
                case 4:
                    resultado = Aceleracao();
                    break;
                case 5:
                    resultado = Media();
                    break;
                case 6:
                    Console.WriteLine(Primo() ? "O número é primo." : "O número não é primo.");
                    break;
                case 7:
                    resultado = Temperatura();
                    break;
                case 8:
                    resultado = Vogais();
                    break;
                case 9:
                    Tabuada();
                    break;
                case 10:
                    Equacao();
                    break;
                default:
                    Console.WriteLine("Opção inválida.");
                    break;
            }

            if (opcao != 6 && opcao != 9 && opcao != 10)
            {
                Console.WriteLine("O Resultado é " + resultado);
            }

            opcao = Menu();
        }

        Console.WriteLine("Saindo do programa.");
    }

    static int Menu()
    {
        Console.WriteLine("Escolha uma opção:");
        Console.WriteLine("1 - Somar");
        Console.WriteLine("2 - Dividir");
        Console.WriteLine("3 - Fatorial");
        Console.WriteLine("4 - Cálculo de Aceleração");
        Console.WriteLine("5 - Média");
        Console.WriteLine("6 - Verificar se é Primo");
        Console.WriteLine("7 - Converter Temperatura (Celsius para Fahrenheit ou vice-versa)");
        Console.WriteLine("8 - Contar Vogais");
        Console.WriteLine("9 - Tabuada de um número");
        Console.WriteLine("10 - Resolver Equação do Segundo Grau");
        Console.WriteLine("11 - Sair");

        if (int.TryParse(Console.ReadLine(), out int opcao))
        {
            return opcao;
        }
        else
        {
            Console.WriteLine("Entrada inválida. Por favor, insira um número.");
            return -1; // Força a repetição do menu
        }
    }

    static double Somar()
    {
        Console.Write("Digite o primeiro número: ");
        double n1 = double.Parse(Console.ReadLine());
        Console.Write("Digite o segundo número: ");
        double n2 = double.Parse(Console.ReadLine());
        return n1 + n2;
    }

    static double Dividir()
    {
        Console.Write("Digite o numerador: ");
        double n1 = double.Parse(Console.ReadLine());
        Console.Write("Digite o denominador: ");
        double n2 = double.Parse(Console.ReadLine());
        if (n2 == 0)
        {
            Console.WriteLine("Divisão por zero não é permitida.");
            return 0;
        }
        return n1 / n2;
    }

    static double Fatorial()
    {
        Console.Write("Digite um número para calcular o fatorial: ");
        int numero = int.Parse(Console.ReadLine());
        if (numero < 0)
        {
            Console.WriteLine("Número negativo não é permitido.");
            return 0;
        }
        double resultado = 1;
        for (int i = 1; i <= numero; i++)
        {
            resultado *= i;
        }
        return resultado;
    }

    static double Aceleracao()
    {
        Console.Write("Digite a velocidade inicial (v0): ");
        double velocidadeI = double.Parse(Console.ReadLine());
        Console.Write("Digite a velocidade final (vf): ");
        double velocidadeF = double.Parse(Console.ReadLine());
        Console.Write("Digite o tempo (t): ");
        double tempo = double.Parse(Console.ReadLine());

        if (tempo == 0)
        {
            Console.WriteLine("O tempo não pode ser zero.");
            return 0;
        }

        return (velocidadeF - velocidadeI) / tempo;
    }

    static double Media()
    {
        List<double> valores = new List<double>();
        string entrada;

        Console.WriteLine("Digite os valores para calcular a média (digite 'fim' para terminar):");

        while ((entrada = Console.ReadLine()) != "fim")
        {
            if (double.TryParse(entrada, out double valor))
            {
                valores.Add(valor);
            }
            else
            {
                Console.WriteLine("Entrada inválida. Por favor, digite um número ou 'fim' para terminar.");
            }
        }

        if (valores.Count == 0)
        {
            Console.WriteLine("Nenhum valor foi inserido.");
            return 0;
        }

        double soma = 0;
        foreach (var valor in valores)
        {
            soma += valor;
        }

        return soma / valores.Count;
    }

    static bool Primo()
    {
        Console.Write("Digite um número para ver se é primo: ");
        int num = int.Parse(Console.ReadLine());

        if (num <= 1)
        {
            return false;
        }

        for (int i = 2; i <= Math.Sqrt(num); i++)
        {
            if (num % i == 0)
            {
                return false;
            }
        }

        return true;
    }

    static double Temperatura()
    {
        Console.Write("Digite a temperatura: ");
        double temperatura = double.Parse(Console.ReadLine());
        Console.Write("Digite 1 para Celsius para Fahrenheit ou 2 para Fahrenheit para Celsius: ");
        int escolha = int.Parse(Console.ReadLine());

        if (escolha == 1)
        {
            return (temperatura * 9 / 5) + 32;
        }
        else if (escolha == 2)
        {
            return (temperatura - 32) * 5 / 9;
        }
        else
        {
            Console.WriteLine("Escolha inválida.");
            return 0;
        }
    }

    static int Vogais()
    {
        Console.Write("Digite uma frase: ");
        string frase = Console.ReadLine();
        int letras = 0;
        foreach (char c in frase.ToLower())
        {
            if ("aeiou".Contains(c))
            {
                letras++;
            }
        }
        return letras;
    }

    static void Tabuada()
    {
        Console.Write("Digite um número para calcular a tabuada: ");
        int numero = int.Parse(Console.ReadLine());
        Console.WriteLine("Tabuada do " + numero + ":");
        for (int i = 1; i <= 10; i++)
        {
            Console.WriteLine($"{numero} x {i} = {numero * i}");
        }
    }

    static void Equacao()
    {
        Console.Write("Digite o coeficiente a: ");
        double a = double.Parse(Console.ReadLine());
        Console.Write("Digite o coeficiente b: ");
        double b = double.Parse(Console.ReadLine());
        Console.Write("Digite o coeficiente c: ");
        double c = double.Parse(Console.ReadLine());

        double delta = (b * b) - (4 * a * c);

        if (delta < 0)
        {
            Console.WriteLine("A equação não possui raízes reais.");
            return;
        }

        double raiz = Math.Sqrt(delta);
        double x1 = ((-b) + raiz) / (2 * a);
        double x2 = ((-b) - raiz) / (2 * a);

        Console.WriteLine("Valor de X1: {0}", x1);
        Console.WriteLine("Valor de X2: {0}", x2);
    }
}