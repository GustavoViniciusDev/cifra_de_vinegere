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
            resultado = Descriptografar(texto, chave);
            Console.WriteLine("Texto decifrado: " + resultado);
        }
        else
        {
            Console.WriteLine("Opção inválida. O programa será encerrado.");
        }
    }

    static string Criptografar(string texto, string chave)
    {
        int tamanhoTexto = texto.Length;
        int tamanhoChave = chave.Length;

        char[,] matrizVigenere = new char[26, 26];
        char letra = 'A';

        // Construir a matriz Vigenère
        for (int i = 0; i < 26; i++)
        {
            for (int j = 0; j < 26; j++)
            {
                matrizVigenere[i, j] = letra;

                letra++;
                if (letra > 'Z')
                    letra = 'A';
            }

            letra++;
            if (letra > 'Z')
                letra = 'A';
        }

        string textoCifrado = "";
        int posicaoChave = 0;

        // Criptografar o texto
        for (int i = 0; i < tamanhoTexto; i++)
        {
            char caractereTexto = texto[i];
            char caractereChave = chave[posicaoChave];

            if (caractereTexto >= 'A' && caractereTexto <= 'Z')
            {
                int linha = caractereChave - 'A';
                int coluna = caractereTexto - 'A';

                textoCifrado += matrizVigenere[linha, coluna];

                posicaoChave++;
                if (posicaoChave == tamanhoChave)
                    posicaoChave = 0;
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
        int tamanhoTexto = texto.Length;
        int tamanhoChave = chave.Length;

        char[,] matrizVigenere = new char[26, 26];
        char letra = 'A';

        // Construir a matriz Vigenère
        for (int i = 0; i < 26; i++)
        {
            for (int j = 0; j < 26; j++)
            {
                matrizVigenere[i, j] = letra;

                letra++;
                if (letra > 'Z')
                    letra = 'A';
            }

            letra++;
            if (letra > 'Z')
                letra = 'A';
        }

        string textoDecifrado = "";
        int posicaoChave = 0;

        // Descriptografar o texto
        for (int i = 0; i < tamanhoTexto; i++)
        {
            char caractereTexto = texto[i];
            char caractereChave = chave[posicaoChave];

            if (caractereTexto >= 'A' && caractereTexto <= 'Z')
            {
                int linha = caractereChave - 'A';
                int coluna = 0;

                // Encontrar a coluna correspondente ao caractere cifrado
                for (int j = 0; j < 26; j++)
                {
                    if (matrizVigenere[linha, j] == caractereTexto)
                    {
                        coluna = j;
                        break;
                    }
                }

                textoDecifrado += (char)('A' + coluna);

                posicaoChave++;
                if (posicaoChave == tamanhoChave)
                    posicaoChave = 0;
            }
            else
            {
                textoDecifrado += caractereTexto;
            }
        }

        return textoDecifrado;
    }
}