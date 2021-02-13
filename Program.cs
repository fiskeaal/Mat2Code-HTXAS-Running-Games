using System;
using System.Collections.Generic;

namespace Mat2Code_HTXAS___Running_Games
{
    public class deltager: IComparable<deltager>
    {
        public double Id { get; set; }
        public string Name { get; set; }
        public double Time { get; set; }
        public double Alder { get; set; }
        public deltager(int id, string name, double time, int alder)
        {
            Id = id;
            Name = name;
            Time = time;
            Alder = alder;
        }

        public int CompareTo(deltager other)
        {
            return Time.CompareTo(other.Time);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            List<deltager> vores_deltagere = new List<deltager> {};

            // i millimeter
            
            double gul_cirkel_ned = Math.Asin((double)(117314 - 77000) / 77000) / (2 * Math.PI) * 77000 * 2 * Math.PI;
            double gul_cirkel_op = (77000 * 2 * Math.PI) / 4;

            //Console.WriteLine(gul_cirkel_ned);
            //Console.WriteLine(gul_cirkel_op);

            double blå_cirkel_ned = 75000 * 2 * Math.PI / 4;
            double blå_cirkel_op = blå_cirkel_ned;
            //Console.WriteLine(blå_cirkel_ned);
            //Console.WriteLine(blå_cirkel_op);

            double rød_cirkel = Math.Asin((double)(30405) / 79000) / (2 * Math.PI) * 79000 * 2 * Math.PI;
            //Console.WriteLine((double)rød_cirkel);
            


            double Dop;
            double Dopkm;
            double Dplan;
            double Dplankm;
            double Dned;
            double Dnedkm;
            double tid;
            string deltagerlinje;
            string[] lines = System.IO.File.ReadAllLines(@"1_G_mat_2020_1_1_tekst_final_1.txt");

            for (int i = 1; i < 34; i++)
            {
                deltagerlinje = lines[i];
                string[] deltager_info = deltagerlinje.Split(";");
                string navn = deltager_info[1];
                int nr = Convert.ToInt32(deltager_info[0]);
                int Vop = Convert.ToInt32(deltager_info[2]);
                int Vned = Convert.ToInt32(deltager_info[3]);
                int Vplan = Convert.ToInt32(deltager_info[4]);
                int alder = Convert.ToInt32(deltager_info[5]);

                if (alder < 20)
                {
                    Dop = (154200 / Math.Cos(0.26)) + ((75000 * Math.PI) / 2);
                    Dopkm = Dop / 1000000;
                    Dplan = 387410 + 66039 + 170538;
                    Dplankm = Dplan / 1000000;
                    Dned = (154200 / Math.Cos(0.26)) + ((75000 * Math.PI) / 2);
                    Dnedkm = Dned / 1000000;
                    Console.WriteLine("blå bane " + (Dopkm) + (Dplankm) + (Dnedkm));


                }
                
                else if (alder < 51)
                {
                    Dned = gul_cirkel_ned + (111743 / Math.Cos(0.26));
                    Dop = (49964 / Math.Cos(0.26)) + ((77000 * Math.PI) / 2);
                    Dplan = 145801 + 264317;
                    Dopkm = Dop / 1000000;
                    Dnedkm = Dned / 1000000;
                    Dplankm = Dplan / 1000000;
                    Console.WriteLine( "gul bane " + (Dopkm) + (Dplankm) + (Dnedkm));
                }

                else
                {
                    Dop = (rød_cirkel * 2) + (8612 * Math.PI) + Math.Sqrt(Math.Pow(26486, 2) + Math.Pow((32777 / Math.Cos(0.26)), 2));
                    Dned = (8612 * Math.PI) + (52256 / Math.Cos(0.26)) + (32777 / Math.Cos(0.26));
                    Dplan = 26111 + 53570 + 137150;
                    Dopkm = Dop / 1000000;
                    Dnedkm = Dned / 1000000;
                    Dplankm = Dplan / 1000000;
                    Console.WriteLine("rød bane " + (Dopkm) + (Dplankm) + (Dnedkm));
                }
                tid = (Vop / Dopkm) + (Vplan / Dplankm) + (Vned / Dnedkm);
                vores_deltagere.Add(new deltager(nr, navn, tid, alder));
            }
            // deltager => Console.WriteLine("Id: {0}; Navn: {1}; Tid: {2:0.00}; Alder: {3} År", deltager.Id, deltager.Name, deltager.Time, deltager.Alder)

            vores_deltagere.Sort();
            foreach (deltager en_deltager in vores_deltagere)
            {
                Console.WriteLine("Id: {0}; Navn: {1}; Tid: {2:0.00}; Alder: {3} År", en_deltager.Id, en_deltager.Name, en_deltager.Time, en_deltager.Alder);
            }
            




        }
    }
}
