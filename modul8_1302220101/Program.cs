using modul8_1302220101;

public class Program
{
    public static void Main(string[] args)
    {
        BankTransferConfig BTconfig = new BankTransferConfig();
        int nilaiTransfer;
        int trasnferMethod;

        if (BTconfig.config.lang == "en")
        {
            Console.Write("Please insert the amount of money to transfer: ");
        } else if (BTconfig.config.lang == "id")
        {
            Console.Write("Masukkan jumlah uang yang akan di-transfer: ");
        }

        nilaiTransfer = int.Parse(Console.ReadLine());
        
        if (nilaiTransfer <= BTconfig.config.transfer.threshold)
        {
            if (BTconfig.config.lang == "en")
            {
                Console.WriteLine($"Transfer fee = {BTconfig.config.transfer.low_fee}");
                Console.WriteLine($"Total amount = {nilaiTransfer + BTconfig.config.transfer.low_fee}");
            } else if ( BTconfig.config.lang == "id")
            {
                Console.WriteLine($"Biaya transfer = {BTconfig.config.transfer.low_fee}");
                Console.WriteLine($"Total biaya = {nilaiTransfer + BTconfig.config.transfer.low_fee}");
            }
        } else
        {
            if (BTconfig.config.lang == "en")
            {
                Console.WriteLine($"Transfer fee = {BTconfig.config.transfer.high_fee}");
                Console.WriteLine($"Total amount = {nilaiTransfer + BTconfig.config.transfer.low_fee}");
            }
            else if (BTconfig.config.lang == "id")
            {
                Console.WriteLine($"Biaya transfer = {BTconfig.config.transfer.high_fee}");
                Console.WriteLine($"Total biaya = {nilaiTransfer + BTconfig.config.transfer.low_fee}");
            }
        }

        if (BTconfig.config.lang == "en")
        {
            Console.WriteLine("\nSelect transfer method: ");
        } else if (BTconfig.config.lang == "id")
        {
            Console.WriteLine("\nPilih metode transfer: ");
        }

        for (int i = 0; i < BTconfig.config.methods.Length; i++)
        {
            Console.WriteLine($"{i+1}. {BTconfig.config.methods[i]}");
        }
        trasnferMethod = int.Parse(Console.ReadLine());

        if (BTconfig.config.lang == "en")
        {
            Console.WriteLine($"\nPlease type {BTconfig.config.confirmation.en} to confirm the transaction");
            if (Console.ReadLine() == BTconfig.config.confirmation.en)
            {
                Console.WriteLine("The transfer is completed");
            } else
            {
                Console.WriteLine("Transfer is cancelled");
            }
        } else if (BTconfig.config.lang == "id")
        {
            Console.WriteLine($"\nKetik {BTconfig.config.confirmation.en} untuk mengkonfirmasi transaksi");
            if (Console.ReadLine() == BTconfig.config.confirmation.en)
            {
                Console.WriteLine("Proses transfer berhasil");
            }
            else
            {
                Console.WriteLine("Transfer dibatalkan");
            }
        }

    }
}
