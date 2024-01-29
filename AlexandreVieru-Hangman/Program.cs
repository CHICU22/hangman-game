using System;
using System.Collections.Generic;

namespace AlexandreVieru_Hangman
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Let's play hangman\n");

            //Converter o read para int
            Console.WriteLine("Choose the dificulty: ");
            int mode = Convert.ToInt32(Console.ReadLine());

            Console.Write(mode);

            //Easy Words/Mode
            Random easySecretWords = new Random();
            string[] wordsEasy = { "audi", "bugatti", "peugeot", "volkswagen" };

            //Medium Words/Mode
            Random mediumSecretWords = new Random();
            string[] wordsMedium = { "strawberry", "blueberry", "banana", "avocado" };

            //HardWords/Mode
            Random hardSecretWords = new Random();
            //Criar uma classe de palavras para subistituir o array
            string[] wordsHard = { "therapist", "pediatrician", "surgeon", "dentist" };

            if (mode == 1)
            {
                Console.WriteLine("Easy Mode, Car branding");
                //Fazer um loop que escolha uma palavra random da lista
                int word = easySecretWords.Next(0, 3);//Temos uma variável que irá definir a palavra secreta
                string secretWord = wordsEasy[word];//Definir a palavra secreta que vai buscar ao array
                int wordLength = secretWord.Length;
                char[] guess = new char[secretWord.Length];//letras que serão adicionadas
                char[] printArray = new char[wordLength]; 
                int vidas = 5;
                int contador = -1;
                bool vitoria = false;
                Console.WriteLine("Try to guess the word");

                foreach (char letter in printArray)
                {
                    contador++;
                    printArray[contador] = '-';
                }

                while (vidas > 0)
                {
                    contador = -1;
                    string printProgress = String.Concat(guess);
                    bool letterFound = false;
                    int multiples = 0;

                    if (printProgress == secretWord)
                    {
                        vitoria = true;
                        break;
                    }

                    if (vidas > 1)
                    {
                        Console.WriteLine("You Have {0} lives!", vidas);
                    }
                    else
                    {
                        Console.WriteLine("You only have {0} life left!!", vidas);
                    }

                    for (int i = 0; i < secretWord.Length; i++)//Aqui neste loop é aonde vai acontecer a magia, se o i for menor que o numero de carateres da string, ele adiciona até chegar ao numero de carateres da string
                    {
                        guess[i] = '-';//substitui os carateres por -
                    }

                    while (true)// Este While vai fazer substituir os '-' por carateres que forem acertados
                    {
                        char playerGuess = char.Parse(Console.ReadLine());//Criei outra vez um char mas é dos chars que o player adivinha
                        for (int j = 0; j < secretWord.Length; j++)//Aqui acabar por ser a mesma lógica que o for acima
                        {
                            if (playerGuess == secretWord[j])//Mas se o carater que o player adivinha for igual ao carater da secret word,
                                guess[j] = playerGuess;//o '-' é substituido pelo carater adinhado pelo player

                        }
                        Console.WriteLine(guess);
                    }
                }
            }
            else if (mode == 2)
            {
                Console.WriteLine("Medium Mode, fruits");
                //Fazer um loop que escolha uma palavra random da Lista
                var word = mediumSecretWords.Next(0, 3);
                string secretWord = wordsMedium[word];
                char[] guess = new char[secretWord.Length];
                Console.WriteLine("Try to guess the word");

                //Verificar se a letra já foi adivinhada

                for (int i = 0; i < secretWord.Length; i++)
                {
                    guess[i] = '-';
                }

                while (true)
                {
                    char playerGuess = char.Parse(Console.ReadLine());
                    for (int j = 0; j < secretWord.Length; j++)
                    {
                        if (playerGuess == secretWord[j])
                            guess[j] = playerGuess;
                    }
                    Console.WriteLine(guess);
                }
            }
            else if (mode == 3)
            {
                Console.WriteLine("Hard Mode, medical words");
                //Fazer um loop que escolha uma palavra random da Lista
                var word = hardSecretWords.Next(0, 3);
                string secretWord = wordsHard[word];
                char[] guess = new char[secretWord.Length];

                Console.WriteLine("Try to guess the word!");
                Console.WriteLine("Guess a letter:");

                for (int i = 0; i < secretWord.Length; i++)
                {
                    guess[i] = '-';
                }

                while (true)
                {
                    char playerGuess = char.Parse(Console.ReadLine());
                    for (int j = 0; j < secretWord.Length; j++)
                    {
                        if (playerGuess == secretWord[j])
                            guess[j] = playerGuess;
                    }
                    Console.WriteLine(guess);

                }
            }
        }
        //Fazer verificação se os '-' estão todos completos para saber se o jogador ganhou ou não
        /*static void ConfirmSecretWord()
        {

            foreach (char verificao in guess)
            {
                if (verificao == '-')//Se ainda n\ao adivinhamos esta letra
                {

                }
                else
                {
                    Console.WriteLine("Continua a tentar");
                }
            }
            Console.WriteLine("Parabéns adivinhaste a palavra");
            System.Environment.Exit(1);
        }*/
    }
}