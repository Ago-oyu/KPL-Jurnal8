using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace modul8_1302220101
{
    class Config
    {
        public String lang { get; set; }
        public Transfer transfer { get; set; }
        public String[] methods { get; set; }
        public Confirmation confirmation { get; set; }

        public Config() { }
        
        public Config(String lang, int transferThreshold, int transferLowFee, int transferHighFee, String[] methods, String confirmationEn, String confirmationId)
        {
            transfer = new Transfer(transferThreshold, transferLowFee, transferHighFee);
            confirmation = new Confirmation(confirmationEn, confirmationId);
            this.lang = lang;
            //transfer.threshold = transferThreshold;
            //transfer.low_fee = transferLowFee;
            //transfer.high_fee = transferHighFee;
            this.methods = methods;
            //confirmation.en = confirmationEn;
            //confirmation.id = confirmationId;
        }
        
        public class Transfer
        {
            public int threshold { get; set; }
            public int low_fee { get; set; }
            public int high_fee { get; set; }

            public Transfer(int threshold, int low_fee, int high_fee)
            {
                this.threshold = threshold;
                this.low_fee = low_fee;
                this.high_fee = high_fee;
            }
        }

        public class Confirmation
        {
            public String en { get; set; }
            public String id {  get; set; }

            public Confirmation(String en, String id)
            {
                this.en = en;
                this.id = id;
            }
        }
    }

    internal class BankTransferConfig
    {
        public Config config { get; set; }
        public String filepath = "../../../bank_transfer_config.json";

        public BankTransferConfig()
        {
            try
            {
                ReadConfig();
            }
            catch
            {
                setDefault();
                WriteConfig();
            }
        }

        private Config ReadConfig()
        {
            String configJsonData = File.ReadAllText(filepath);
            config = JsonSerializer.Deserialize<Config>(configJsonData);
            return config;
        }

        private void WriteConfig()
        {
            JsonSerializerOptions options = new JsonSerializerOptions()
            {
                WriteIndented = true
            };

            String jsonString = JsonSerializer.Serialize(config, options);
            File.WriteAllText(filepath, jsonString);
        }

        private void setDefault()
        {
            
            config = new Config("en", 25000000, 6500, 1500, ["RTO(real - time)", "SKN", "RTGS", "BI FAST" ], "yes", "ya");
        }
        
    }
}
