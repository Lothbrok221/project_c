namespace ConsoleApp24
{
    using System;

    internal class Program
    {
        static string[,] hall1 = new string[10, 8];
        static string[,] hall2 = new string[10, 8];
        static string[,] hall3 = new string[10, 8];

        static void Main(string[] args)
        {
            bool exit = false;

            while (!exit)
            {
                Console.WriteLine("Çıxış etmek üçün 0 düymesine basın.");
                Console.WriteLine("Bilet sifarişi vererek rezervasiya etmek üçün 3 düymesine basın.");

                int input = Convert.ToInt32(Console.ReadLine());

                switch (input)
                {
                    case 0:
                        exit = true;
                        break;
                    case 3:
                        MakeReservation();
                        break;
                    default:
                        Console.WriteLine("Yanlış seçim.");
                        break;
                }
            }
        }

        static void MakeReservation()
        {
            Console.WriteLine("Adınızı daxil edin:");
            string firstName = Console.ReadLine();

            Console.WriteLine("Soyadınızı daxil edin:");
            string lastName = Console.ReadLine();

            Console.WriteLine("Zal nömresini daxil edin (1-3):");
            int hallNumber = Convert.ToInt32(Console.ReadLine());

            string hall = GetHallName(hallNumber);

            if (hall == null)
            {
                Console.WriteLine("Yanlış zal seçimi.");
                return;
            }

            DisplayMovies(hall);

            Console.WriteLine("Film seçiminizi edin (1-3):");
            int movieIndex = Convert.ToInt32(Console.ReadLine());

            string movie = GetMovie(hall, movieIndex);

            if (movie == "Yanlış film seçimi.")
            {
                Console.WriteLine(movie);
                return;
            }

            DateTime startTime = DateTime.Now;
            DateTime endTime = startTime.AddHours(2);

            Console.WriteLine("Başlama vaxtı: " + startTime.ToShortTimeString());
            Console.WriteLine("Bitiş vaxtı: " + endTime.ToShortTimeString());

            Console.WriteLine("Oturacağınız yeri seçin:");
            DisplaySeats(hall);

            ReserveSeat(hall, firstName, lastName, movie, startTime, endTime);

            Console.WriteLine("Rezervasiya tamamlandı. Yeni zal durumu:");
            DisplaySeats(hall);
        }

        static void DisplayMovies(string hall)
        {
            switch (hall)
            {
                case "hall-1":
                    Console.WriteLine("1. Film: Fight Club (IMDb Reytingi: 8.8)");
                    Console.WriteLine("2. Film: Inception (IMDb Reytingi: 8.7)");
                    Console.WriteLine("3. Film: The Dark Knight (IMDb Reytingi: 9.0)");
                    break;
                case "hall-2":
                    Console.WriteLine("1. Film: Pulp Fiction (IMDb Reytingi: 8.9)");
                    Console.WriteLine("2. Film: The Shawshank Redemption (IMDb Reytingi: 9.3)");
                    Console.WriteLine("3. Film: The Godfather (IMDb Reytingi: 9.2)");
                    break;
                case "hall-3":
                    Console.WriteLine("1. Film: Forrest Gump (IMDb Reytingi: 8.8)");
                    Console.WriteLine("2. Film: The Matrix (IMDb Reytingi: 8.7)");
                    Console.WriteLine("3. Film: Interstellar (IMDb Reytingi: 8.6)");
                    break;
                default:
                    Console.WriteLine("Yanlış zal seçimi.");
                    break;
            }
        }

        static string GetHallName(int hallNumber)
        {
            switch (hallNumber)
            {
                case 1:
                    return "hall-1";
                case 2:
                    return "hall-2";
                case 3:
                    return "hall-3";
                default:
                    return null;
            }
        }

        static string GetMovie(string hall, int movieIndex)
        {
            switch (hall)
            {
                case "hall-1":
                    switch (movieIndex)
                    {
                        case 1:
                            return "Fight Club";
                        case 2:
                            return "Inception";
                        case 3:
                            return "The Dark Knight";
                        default:
                            return "Yanlış film seçimi.";
                    }
                case "hall-2":
                    switch (movieIndex)
                    {
                        case 1:
                            return "Pulp Fiction";
                        case 2:
                            return "The Shawshank Redemption";
                        case 3:
                            return "The Godfather";
                        default:
                            return "Yanlış film seçimi.";
                    }
                case "hall-3":
                    switch (movieIndex)
                    {
                        case 1:
                            return "Forrest Gump";
                        case 2:
                            return "The Matrix";
                        case 3:
                            return "Interstellar";
                        default:
                            return "Yanlış film seçimi.";
                    }
                default:
                    return "Yanlış zal seçimi.";
            }
        }

        static void DisplaySeats(string hall)
        {
            switch (hall)
            {
                case "hall-1":
                    DisplayHall(hall1);
                    break;
                case "hall-2":
                    DisplayHall(hall2);
                    break;
                case "hall-3":
                    DisplayHall(hall3);
                    break;
                default:
                    Console.WriteLine("Yanlış zal seçimi.");
                    break;
            }
        }

        static void DisplayHall(string[,] hall)
        {
            Console.WriteLine("Zal görünümü:");
            Console.WriteLine("    1 2 3 4 5 6 7 8");

            for (int i = 0; i < 10; i++)
            {
                Console.Write((i + 1).ToString().PadLeft(2) + "  ");

                for (int j = 0; j < 8; j++)
                {
                    if (hall[i, j] == null)
                    {
                        Console.Write("empty ");
                    }
                    else if (hall[i, j] == "Reserved")
                    {
                        Console.Write("Reserved ");
                    }
                }

                Console.WriteLine();
            }
        }

        static void ReserveSeat(string hall, string firstName, string lastName, string movie, DateTime startTime, DateTime endTime)
        {
            Console.WriteLine("Rezerv etmek istediyiniz yerin sırasını daxil edin (1-10):");
            int row = Convert.ToInt32(Console.ReadLine()) - 1;

            Console.WriteLine("Rezerv etmek istediyiniz yerin sütununu daxil edin (1-8):");
            int column = Convert.ToInt32(Console.ReadLine()) - 1;

            switch (hall)
            {
                case "hall-1":
                    if (hall1[row, column] == null)
                    {
                        hall1[row, column] = "Reserved";
                        Console.WriteLine("Rezervasiya uğurla tamamlandı.");
                        Console.WriteLine("Ad: " + firstName);
                        Console.WriteLine("Soyad: " + lastName);
                        Console.WriteLine("Film: " + movie);
                        Console.WriteLine("Başlama vaxtı: " + startTime.ToShortTimeString());
                        Console.WriteLine("Bitiş vaxtı: " + endTime.ToShortTimeString());
                    }
                    else
                    {
                        Console.WriteLine("Seçdiyiniz yer artıq rezerv edilib.");
                    }
                    break;
                case "hall-2":
                    if (hall2[row, column] == null)
                    {
                        hall2[row, column] = "Reserved";
                        Console.WriteLine("Rezervasiya uğurla tamamlandı.");
                        Console.WriteLine("Ad: " + firstName);
                        Console.WriteLine("Soyad: " + lastName);
                        Console.WriteLine("Film: " + movie);
                        Console.WriteLine("Başlama vaxtı: " + startTime.ToShortTimeString());
                        Console.WriteLine("Bitiş vaxtı: " + endTime.ToShortTimeString());
                    }
                    else
                    {
                        Console.WriteLine("Seçdiyiniz yer artıq rezerv edilib.");
                    }
                    break;
                case "hall-3":
                    if (hall3[row, column] == null)
                    {
                        hall3[row, column] = "Reserved";
                        Console.WriteLine("Rezervasiya uğurla tamamlandı.");
                        Console.WriteLine("Ad: " + firstName);
                        Console.WriteLine("Soyad: " + lastName);
                        Console.WriteLine("Film: " + movie);
                        Console.WriteLine("Başlama vaxtı: " + startTime.ToShortTimeString());
                        Console.WriteLine("Bitiş vaxtı: " + endTime.ToShortTimeString());
                    }
                    else
                    {
                        Console.WriteLine("Seçdiyiniz yer artıq rezerv edilib.");
                    }
                    break;
                default:
                    Console.WriteLine("Yanlış zal seçimi.");
                    break;
            }
        }
    }
}