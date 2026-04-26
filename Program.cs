using System;
using TP_MODUL9_103022400138;

namespace TP_MODUL9_103022400138
{
    class Program
    {
        static void Main(string[] args)
        {
            CovidConfig config = new CovidConfig();

            JalankanProgram(config);

            Console.WriteLine("\n--- Mengubah Satuan Suhu ---");
            config.UbahSatuan();
            JalankanProgram(config);
        }

        static void JalankanProgram(CovidConfig config)
        {
            Console.WriteLine($"Berapa suhu badan anda saat ini? Dalam nilai {config.conf.satuan_suhu}");
            double suhu = double.Parse(Console.ReadLine());

            Console.WriteLine("Berapa hari yang lalu (perkiraan) anda terakhir memiliki gejala demam?");
            int hari = int.Parse(Console.ReadLine());

            bool cekSuhu = false;
            if (config.conf.satuan_suhu == "celcius")
            {
                cekSuhu = (suhu >= 36.5 && suhu <= 37.5);
            }
            else if (config.conf.satuan_suhu == "fahrenheit")
            {
                cekSuhu = (suhu >= 97.7 && suhu <= 99.5);
            }

            bool cekHari = (hari < config.conf.batas_hari_deman);

            if (cekSuhu && cekHari)
            {
                Console.WriteLine(config.conf.pesan_diterima);
            }
            else
            {
                Console.WriteLine(config.conf.pesan_ditolak);
            }
        }
    }
}
