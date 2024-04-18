using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace monul8_NIM
{
    public class BankTransferConfig
    {
        public BankConfig config;
        public const string filepath = @"bank_transfer_config.json";
        public BankTransferConfig()
        {
            try { ReadConfigFile(); }
            catch { setdefault(); WriteConfigFile(); }
        }
        public void setdefault()
        {
            config = new BankConfig("en", new Transfer(25000000, 6500, 15000), new List<string> { "RTO(real-time)", "SKN", "RTGS", "BI FAST" }, new Confirmation("yes", "ya"));
        }
        public void ReadConfigFile()
        {
            string file = File.ReadAllText(filepath);
            config = JsonSerializer.Deserialize<BankConfig>(file);
        }
        public void WriteConfigFile()
        {
            JsonSerializerOptions options = new JsonSerializerOptions() { WriteIndented = true };
            string tulis = JsonSerializer.Serialize(config, options);
            File.WriteAllText(filepath, tulis);
        }
    }

    public class Transfer
    {
        public int treshold
        {
            get; set;
        }
        public int low_fee
        {
            get; set;
        }
        public int high_fee
        {
            get; set;
        }
        public Transfer()
        {

        }
        public Transfer(int treshold, int low_fee, int high_fee)
        {
            this.treshold = treshold;
            this.low_fee = low_fee;
            this.high_fee = high_fee;
        }
    }

    public class Confirmation
    {
        public string en
        {
            get;set;
        }
        public string id
        {
            get;set;
        }

        public Confirmation()
        {

        }
        public Confirmation(string en, string id) { 
            this.en = en;
            this.id = id;
        }
    }

    public class BankConfig
    {
        public string lang
        {
            get;set;
        }
        public Transfer transfer
        {
            get;set;
        }
        public List<string> methods
        {
            get;set;
        }
        public Confirmation confirmation
        {
            get;set;
        }
        public BankConfig()
        {

        }
        public BankConfig(string lang, Transfer transfer, List<string> methods, Confirmation confirmation)
        {
            this.lang = lang;
            this.transfer = transfer;
            this.methods = methods;
            this.confirmation = confirmation;
        }
    }

}
