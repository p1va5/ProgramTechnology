namespace BankAccounts.Core.AccountNumbers;
//Генерация номеров - отдельная ответственность не должнна быть внутри счета(SRP)
public interface IAccountNumbersGenerator
{
    string Next();
}
