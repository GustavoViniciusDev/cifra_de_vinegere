using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Cifra de Vigenère");

        Console.WriteLine("Escolha uma opção:");
        Console.WriteLine("1. Criptografar");
        Console.WriteLine("2. Descriptografar");
        Console.Write("Opção: ");
        int opcao = int.Parse(Console.ReadLine());

        Console.Write("Digite o texto: ");
        string texto = Console.ReadLine().ToUpper();

        Console.Write("Digite a chave: ");
        string chave = Console.ReadLine().ToUpper();

        string resultado = "";

        if (opcao == 1)
        {
            resultado = Criptografar(texto, chave);
            Console.WriteLine("Texto cifrado: " + resultado);
        }
        else if (opcao == 2)
        {
            if (string.IsNullOrEmpty(chave))
            {
                Console.WriteLine("A chave não pode estar em branco para descriptografar.");
            }
            else
            {
                resultado = Descriptografar(texto, chave);
                Console.WriteLine("Texto decifrado: " + resultado);
            }
        }
        else
        {
            Console.WriteLine("Opção inválida. O programa será encerrado.");
        }
    }

    static string Criptografar(string texto, string chave)
    {
        string textoCifrado = "";
        int tamanhoTexto = texto.Length;
        int tamanhoChave = chave.Length;

        for (int i = 0; i < tamanhoTexto; i++)
        {
            char caractereTexto = texto[i];
            char caractereChave = tamanhoChave > 0 ? chave[i % tamanhoChave] : texto[i];

            if (caractereTexto >= 'A' && caractereTexto <= 'Z')
            {
                int deslocamento = caractereChave - 'A';
                char caractereCifrado = (char)((caractereTexto - 'A' + deslocamento) % 26 + 'A');
                textoCifrado += caractereCifrado;
            }
            else
            {
                textoCifrado += caractereTexto;
            }
        }

        return textoCifrado;
    }

    static string Descriptografar(string texto, string chave)
    {
        string textoDecifrado = "";
        int tamanhoTexto = texto.Length;
        int tamanhoChave = chave.Length;

        for (int i = 0; i < tamanhoTexto; i++)
        {
            char caractereTexto = texto[i];
            char caractereChave = tamanhoChave > 0 ? chave[i % tamanhoChave] : caractereTexto;

            if (caractereTexto >= 'A' && caractereTexto <= 'Z')
            {
                int deslocamento = caractereChave - 'A';
                char caractereDecifrado = (char)((caractereTexto - 'A' - deslocamento + 26) % 26 + 'A');
                textoDecifrado += caractereDecifrado;
            }
            else
            {
                textoDecifrado += caractereTexto;
            }
        }

        return textoDecifrado;
    }
}
