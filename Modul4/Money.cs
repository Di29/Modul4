using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modul4
{
    public class Money
    {
        public int denominationOfBanknote;
        public int amountOfBanknote;
        public int valueOfProduct;

        public Money(int denomination, int amount)
        {
            SetDenominationOfBanknote(denomination);
            SetAmountOfBanknote(amount);
        }

        public void SetDenominationOfBanknote(int denominationOfBanknote)
        {
            this.denominationOfBanknote = denominationOfBanknote;
        }

        public int GetDenominationOfBanknote()
        {
            return denominationOfBanknote;
        }

        public void SetAmountOfBanknote(int amountOfBanknote)
        {
            this.amountOfBanknote = amountOfBanknote;
        }

        public int GetAmountOfBanknote()
        {
            return amountOfBanknote;
        }

        public int GetCalculateSum (int denominationOfBanknote, int amountOfBanknote)
        {
            return this.denominationOfBanknote * this.amountOfBanknote;
        }

        public  bool IsMoneyEnoughToBuy (int valueOfProduct, int remainingMoney)
        {
            remainingMoney =  GetCalculateSum(denominationOfBanknote, amountOfBanknote);

            if (valueOfProduct < remainingMoney)
            {
                return true;
            }
            else return false;
        }

        public int HowProductCanBuy (int valueOfProduct, int availableMoney)
        {
            availableMoney = GetCalculateSum(denominationOfBanknote, amountOfBanknote);

            return availableMoney / valueOfProduct;
        }

    }
}
