using System;
using System.Drawing;
using System.Drawing.Imaging;

namespace GeradorDeImagem
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Digite o seu Primeiro nome: ");
            string firstName = Console.ReadLine();

            Console.Write("Digite o seu sobrenome: ");
            string lastName = Console.ReadLine();

            int width = 512;
            int height = 512;

            using (var bitmap = new Bitmap(width, height))
            {
                using (var graphics = Graphics.FromImage(bitmap))
                {
                    // Definir o fundo preto
                    graphics.Clear(System.Drawing.Color.Black); // Especificando o namespace completo

                    // Definir as iniciais em branco no centro da imagem
                    string initials = GetInitials(firstName) + GetInitials(lastName);
                    using (var font = new Font("Arial", 80, FontStyle.Bold))
                    {
                        using (var brush = new SolidBrush(System.Drawing.Color.White)) // Especificando o namespace completo
                        {
                            var textSize = graphics.MeasureString(initials, font);
                            var textX = (width - textSize.Width) / 2;
                            var textY = (height - textSize.Height) / 2;
                            graphics.DrawString(initials, font, brush, textX, textY);
                        }
                    }
                }

                string filePath = "imagem.png";
                bitmap.Save(filePath, ImageFormat.Png);
            }

            Console.WriteLine("Imagem criada com sucesso! Pressione qualquer tecla para sair...");
            Console.ReadKey();
        }

        static string GetInitials(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                return string.Empty;

            string[] words = name.Trim().Split(' ');
            string initials = "";
            foreach (string word in words)
            {
                if (!string.IsNullOrWhiteSpace(word))
                    initials += word[0];
            }
            return initials.ToUpper();
        }
    }
}

