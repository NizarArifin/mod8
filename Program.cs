using monul8_NIM;
using System.Collections.Generic;
using System.Numerics;
using System.Security.Cryptography.X509Certificates;

internal class Program
{
    private static void Main(string[] args)
    {
        BankTransferConfig config = new BankTransferConfig();
        if (config.config.lang.Equals("en"))
        {
            Console.WriteLine("Please insert the amount of money to transfer:");
        }
        else if (config.config.lang.Equals("id"))
        {
            Console.WriteLine("Masukkan jumlah uang yang akan di-transfer:");
        }
        string transfer = Console.ReadLine();
        int angka = (int)Convert.ToInt32(transfer);
        int biaya = 0;
        if (angka <= config.config.transfer.treshold)
        {
            biaya = config.config.transfer.low_fee;
        }
        else if (angka > config.config.transfer.treshold)
        {
            biaya = config.config.transfer.high_fee;
        }
        if (config.config.lang.Equals("en"))
        {
            Console.WriteLine("Transfer fee = " + biaya + "Total amount = " + (angka + biaya));
        }
        else if (config.config.lang.Equals("id"))
        {
            Console.WriteLine("Biaya transfer = " + biaya + "Total biaya = " + (angka + biaya));
        }
        if (config.config.lang.Equals("en"))
        {
            Console.WriteLine("Select tranfer method:");
        }
        else if (config.config.lang.Equals("id"))
        {
            Console.WriteLine("Pilih metode transfer:");
        }
        for (int i = 0; i < config.config.methods.Count; i++)
        {
            Console.WriteLine((i + 1) + "." + config.config.methods[i]);
        }
        string inputan = Console.ReadLine();
        int nomer = (int)Convert.ToInt32(transfer);
        if (config.config.lang.Equals("en"))
        {
            Console.WriteLine("Please type " + config.config.confirmation.en + "to confirm the transaction");
        } else if (config.config.lang.Equals("id"))
        {
            Console.WriteLine("Ketik " + config.config.confirmation.id + "untuk mengkonfirmasi transaksi");
        }
        string konfirmasi = Console.ReadLine();
        if (config.config.lang.Equals("en"))
        {
            if (konfirmasi.Equals(config.config.confirmation.en))
            {
                Console.WriteLine("the transfer is completed");
            } else
            {
                Console.WriteLine("the transfer is cancelled");
            }
        } else if (config.config.lang.Equals("id"))
        {
            if (konfirmasi.Equals(config.config.confirmation.id))
            {
                Console.WriteLine("Proses transfer berhasil");
            } else
            {
                Console.WriteLine("Transfer dibatalkan");
            }
        }
    }
}