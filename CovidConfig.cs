using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace TP_MODUL9_103022400138
{
    public class Config
    {
        public string satuan_suhu { get; set; }
        public int batas_hari_deman { get; set; }
        public string pesan_ditolak { get; set; }
        public string pesan_diterima { get; set; }

        public Config() { }

        public Config(string satuan, int batas, string ditolak, string diterima)
        {
            satuan_suhu = satuan;
            batas_hari_deman = batas;
            pesan_ditolak = ditolak;
            pesan_diterima = diterima;
        }
    }

    public class CovidConfig
    {
        public Config conf;
        public string filePath = "covid_config.json";

        public CovidConfig()
        {
            try
            {
                ReadConfigFile();
            }
            catch (Exception)
            {
                SetDefault();
                WriteConfigFile();
            }
        }

        private void SetDefault()
        {
            conf = new Config("celcius", 14,
                "Anda tidak diperbolehkan masuk ke dalam gedung ini",
                "Anda dipersilahkan untuk masuk ke dalam gedung ini");
        }

        private void ReadConfigFile()
        {
            string configJsonData = File.ReadAllText(filePath);
            conf = JsonSerializer.Deserialize<Config>(configJsonData);
        }

        private void WriteConfigFile()
        {
            JsonSerializerOptions options = new JsonSerializerOptions { WriteIndented = true };
            string fullJson = JsonSerializer.Serialize(conf, options);
            File.WriteAllText(filePath, fullJson);
        }

        public void UbahSatuan()
        {
            conf.satuan_suhu = (conf.satuan_suhu == "celcius") ? "fahrenheit" : "celcius";
            WriteConfigFile();
        }
    }
}
