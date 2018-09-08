using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modul4
{
    class Program
    {
        static void Main(string[] args)
        {
            Money money = new Money(1000, 6);

            int choice = 0;
            int denomination = 0;
            int amount = 0;
            int totalAmount = 0;
            int valueOfProduct = 0;
            int amountOfProduct = 0;
            int tempSum = 0;
            int count = 0;
            int cost;
            bool isEnoughToBuy;

            do
            {
                Console.WriteLine("1. Ввести номинал купюры");
                Console.WriteLine("2. Ввести количество купюр");
                Console.WriteLine("3. Вывести номинал и количество купюр");
                Console.WriteLine("4. Купить товар");
                Console.WriteLine("5. Выйти");

                string text = Console.ReadLine();
                bool isParsed = int.TryParse(text, out choice);

                switch (choice)
                {
                    case 1:
                        Console.Write("Введите номинал: ");
                        string input = Console.ReadLine();

                        bool result = int.TryParse(input, out denomination);
                        if (!result)
                            Console.Write("Не корретный ввод! Введите номинал купюры!");
                        else
                            money.SetDenominationOfBanknote(denomination);
                        break;
                    case 2:
                        Console.Write("Введите количество: ");
                        string input1 = Console.ReadLine();

                        bool result1 = int.TryParse(input1, out amount);
                        if (!result1)
                            Console.Write("Не корректный ввод! Введите количество купюр!");
                        else
                            money.SetAmountOfBanknote(amount);
                        break;
                    case 3:
                        Console.Write("Номинал купюр: " + (money.GetDenominationOfBanknote()));
                        Console.Write("\nКоличество купюр: " + (money.GetAmountOfBanknote()));
                        Console.Write("\nОбщая сумма: " + (money.GetCalculateSum(money.GetAmountOfBanknote(), money.GetDenominationOfBanknote())));
                        //totalAmount = money.GetCalculateSum(money.GetAmountOfBanknote(), money.GetDenominationOfBanknote());
                        break;
                    case 4:
                        Console.Write("Введите цену товара: ");
                        string input2 = Console.ReadLine();

                        bool result2 = int.TryParse(input2, out valueOfProduct);
                        if (!result2)
                        {
                            Console.Write("Не корректный ввод! Введите цену товара!");
                            return;
                        }
                            
                        isEnoughToBuy = money.IsMoneyEnoughToBuy(valueOfProduct, totalAmount);
                        if(!isEnoughToBuy)
                        {
                            Console.WriteLine("Сумма ваших средств не достаточна для покупки!");
                        }
                        else
                        {
                            amountOfProduct = money.HowMuchProductCanBuy(valueOfProduct, totalAmount);

                            Console.WriteLine("На вашем счете достаточно средств для покупки");
                            Console.WriteLine("За " + valueOfProduct + " тг вы можете купить этот товар в количестве: " + amountOfProduct);
                            Console.Write("\nКакое количество товара желаете купить?");
                            string input3 = Console.ReadLine();

                            bool result3 = int.TryParse(input3, out count);
                            if (!result3)
                                Console.WriteLine("Не корректный ввод! Введите количество товара");
                            else if (count > amountOfProduct)
                            {
                                Console.WriteLine("Вы превысили доступное количество товара");
                                return;
                            }
                            
                            cost = count * valueOfProduct;
                            tempSum = totalAmount - cost;
                            totalAmount = tempSum;

                            Console.WriteLine("Покупка успешно произведена!");
                        }
                        break;
                    case 5:
                        Console.WriteLine("Вы уверены, что хотите выйти?");
                        break;
                    default:
                        Console.WriteLine("Не корректный ввод");
                        break;
                }
                Console.Write("\n\n\t\tНажмите любую клавишу....");
                Console.ReadLine();
                Console.Clear();
            }
            while (choice != 5);
        }
    }
}
