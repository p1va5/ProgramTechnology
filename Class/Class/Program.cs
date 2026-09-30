using System.Xml.Linq;

namespace Class
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Выбирай загрузка 1 из InMemoryRepository или 2 из CsvRepository");
            string? input = Console.ReadLine();
            if (!int.TryParse(input, out int choice))
            {
                Console.WriteLine($"Не ну ты тупой, тебе сказали выбири 1 или 2, а ты написал {input}.Выздоравливай, но боюсь тупость не лечится");
                return;
            }
            List<Drink> drinks = null;
            List<Barista> baristas = null;
            List<Shift> shifts = null;
            try
            {
                switch (choice)
                {
                    case 1:
                        {
                            InMemoryRepository repository = new InMemoryRepository();
                            drinks = repository.GetDrinks();
                            baristas = repository.GetBaristas();
                            shifts = repository.GetShifts();
                            break;
                        }
                    case 2:
                        {
                            CsvRepository repository = new CsvRepository("data");
                            drinks = repository.GetDrinks();
                            baristas = repository.GetBaristas();
                            shifts = repository.GetShifts();
                            break;
                        }
                }
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.WriteLine(e.Message);
                return;
            }
            catch (ArgumentNullException e)
            {
                Console.WriteLine(e.Message);
                return;
            }

            Barista barista = FindBarista(drinks, baristas, "Латте");
            Console.WriteLine(barista?.GetInfo() ?? "null");

            Shift shift = FindShift(drinks, shifts, "Латте");
            Console.WriteLine(shift?.GetInfo() ?? "null");

            Console.WriteLine(GetTotalVolume(drinks)+ "мл");

            var rat = GetBaristaRating(baristas); 
            foreach(var name in rat)
            {
                Console.WriteLine($"{name.Key[..^5]} - {name.Value}");
            }

            PrintAllDrinks(baristas, drinks, shifts);

            Barista? barista2 = FindBarista(drinks, baristas, "Неизвестный напиток");
            Console.WriteLine(barista2?.GetInfo() ?? "null");
        }
        /// <summary>
        /// Ищет первого баристу по названию напитка
        /// </summary>
        /// <param name="drinks">Полученный лист напитков</param>
        /// <param name="baristas">Полученный лист барист</param>
        /// <param name="drinkName">Имя напитка</param>
        /// <returns></returns>
        static Barista? FindBarista(List<Drink> drinks, List<Barista> baristas, string drinkName)
        {
            if (drinkName == null) return null;
            for (int i = 0; i < drinks.Count; i++)
            {
                if (drinks[i].Name == drinkName)
                {
                    for (int j = 0; j < baristas.Count; j++)
                    {
                        if (baristas[j].Id == drinks[i].BaristaId) return baristas[j];
                    }
                    return null;
                }
            }
            return null;
        }
        /// <summary>
        /// Ищет первую смену по названию напитка
        /// </summary>
        /// <param name="drinks">Полученный лист напитков</param>
        /// <param name="shifts">Полученный лист смен</param>
        /// <param name="drinkName">Имя напитка</param>
        /// <returns></returns>
        static Shift? FindShift(List<Drink> drinks, List<Shift> shifts, string drinkName)
        {
            if (drinkName == null) return null;
            for (int i = 0; i < drinks.Count; i++)
            {
                if (drinks[i].Name == drinkName)
                {
                    for (int j = 0; j < shifts.Count; j++)
                    {
                        if (shifts[j].Id == drinks[i].ShiftId) return shifts[j];
                    }
                    return null;
                }
            }
            return null;
        }
        /// <summary>
        /// Выдает весь объем напитков
        /// </summary>
        /// <param name="drinks">Полученный лист напитков</param>
        /// <returns></returns>
        static int GetTotalVolume(List<Drink> drinks)
        {
            int totalVolume = 0;
            if(drinks.Count==0) return totalVolume;
            for (int i = 0; i < drinks.Count; i++)
            {
                totalVolume += drinks[i].Volume;
            }
            return totalVolume;
        }
        /// <summary>
        /// Проверяет если ли в Dictionary имя, если такого нет добавляет в сипок его имя и рейтинг 
        /// </summary>
        /// <param name="baristas">Полученный лист барист</param>
        /// <returns></returns>
        static Dictionary<string, double> GetBaristaRating(List<Barista> baristas)
        {
            Dictionary<string, double> result = new Dictionary<string, double>();
            for (int i = 0; i < baristas.Count; i++)
            {
                Barista b = baristas[i];
                if(!result.ContainsKey(b.FullName))
                {
                    result.Add(b.FullName, b.Rating);
                }
            }
            return result;
        }
        /// <summary>
        /// Выводит всю информцию о напитка кто когда продал
        /// </summary>
        /// <param name="baristas">Полученный лист барист</param>
        /// <param name="drinks">Полученный лист напитков</param>
        /// <param name="shifts">Полученный лист смен</param>
        static void PrintAllDrinks(List<Barista> baristas, List<Drink> drinks, List<Shift> shifts)
        {
            for(int i = 0;i < drinks.Count;i++)
            {
                Drink drink = drinks[i];
                string baristaName = "-";
                string shiftTime = "-";
                for (int j = 0; j < shifts.Count; j++)
                {
                    if(shifts[j].Id == drink.ShiftId)
                    {
                        shiftTime = shifts[j].Time;
                    }    
                }
                for (int j = 0; j < baristas.Count; j++)
                {
                    if (baristas[j].Id == drink.BaristaId)
                    {
                        baristaName = baristas[j].FullName;
                    }
                }
                Console.WriteLine($"{drink.GetInfo()} - бариста {baristaName}, смена {shiftTime}");
            }
        }
    }
}
