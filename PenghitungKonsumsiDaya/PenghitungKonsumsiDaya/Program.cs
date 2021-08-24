using System;
using System.Collections.Generic;

namespace PenghitungKonsumsiDaya
{
    class Program
    {
        
        static void Main(string[] args)
        {
            int gender,input ;
            bool isCheckFormat = true;
            //bool isCheckNameNull = false;
            bool isCondition = true;

            List<string> items = new List<string>();
            List<double> powers = new List<double>();
            List<double> times = new List<double>();
            char ans;

            Console.WriteLine("===========================");
            Console.WriteLine("Welcome to Penghitung Daya ");
            Console.WriteLine("===========================");
            string name;

            do
            {
                Console.Write("\nNama Anda: ");
                name = Console.ReadLine();
                Console.SetCursorPosition(0, Console.CursorTop-2);
                ClearCurrentConsoleLine();
            } while (name == "");

            Console.SetCursorPosition(0, Console.CursorTop +2);


            do
            {
                isCheckFormat = true;
                try
                    {   
       
                        do
                        {
                            //Console.SetCursorPosition(0, Console.CursorTop);
                            Console.WriteLine("Jenis Kelamin : 1. Laki-laki\t2. Perempuan");
                            Console.Write("\nJenis Kelamin Anda: ");
                            gender = int.Parse(Console.ReadLine());


                        } while ((gender < 1) || gender > 2);
                        while (isCondition == true)
                        {


                            input = Tampilan(name, gender);

                            switch (input)
                            {
                                case 1:

                                    do
                                    {
                                        items.Add(TambahItem(name, gender));
                                        powers.Add(TambahPower());
                                        times.Add(TambahTime());
                                        Console.Write("Do you want Add Item? [Y/N] ");
                                        ans = Console.ReadLine()[0];
                                    } while ((ans == 'y') || (ans) == 'Y');

                                    break;

                                case 2:
                                    int id = 1;

                                    Console.WriteLine("===================================================================");
                                    Console.WriteLine("id \tItem \t\t\tDaya \t\tTime Use");
                                    Console.WriteLine("===================================================================");
                                    
                                    foreach (string item in items)
                                    {
                                    int lenghtItem = item.Length;
                                        if (lenghtItem >= 8) { 
                                            Console.WriteLine($"{id} \t{item} \t\t{powers[id - 1]} KWh\t\t{times[id - 1]} Jam\t");
                                            
                                        }
                                    else
                                    {
                                        Console.WriteLine($"{id} \t{item} \t\t\t{powers[id - 1]} KWh\t\t{times[id - 1]} Jam\t");
                                        
                                    }
                                    id++;
                                    }
                                    Console.WriteLine("===================================================================");

                                    double totalPower = 0;
                                    double totalTime = 0;
                                    foreach (double power in powers)
                                    {
                                        totalPower += power;
                                    }
                                    foreach (double time in times)
                                    {
                                        totalTime += time;
                                    }
                                    double result = totalPower * totalTime;

                                    Console.WriteLine($"\n   \t     \t\tTotal Penggunaan \t\t {result}");
                                    Console.WriteLine("Press Enter to Continue");
                                    Console.ReadLine();

                                    break;
                                case 3:
                                    int delete;
                                    Console.Write("ID Data yang ini di hapus : ");
                                    delete = Convert.ToInt32(Console.ReadLine());
                                    items.RemoveAt(delete - 1);
                                    powers.RemoveAt(delete - 1);
                                    times.RemoveAt(delete - 1);
                                    break;
                                case 4:
                                    Console.Clear();
                                    Console.WriteLine("Terima Kasih telah menggunakan Aplikasi kami");
                                    isCondition = false;
                                    break;
                                default:
                                    break;

                            }
                        }

                    }
                    catch (FormatException e)
                    {
                        // Console.SetCursorPosition(0, Console.CursorTop - 1);
                        Console.WriteLine("\nERROR : " + e.Message);
                        isCheckFormat = false;
                        Console.WriteLine("Press Enter to Continue");
                        Console.ReadLine();
                        Console.SetCursorPosition(0, Console.CursorTop - 7);
                        ClearCurrentConsoleLine();
                    }

                //    catch(NullReferenceException formatGender)
                //{
                //    Console.WriteLine("\nERROR : " + formatGender.Message);
                //}

                   

            } while ((isCheckFormat == false)||(isCondition==true));

            
            
            
            

        }


        public static void ClearCurrentConsoleLine()
        {
            int currentLineCursor = Console.CursorTop;
            Console.SetCursorPosition(0, Console.CursorTop);
            Console.Write(new string(' ', Console.WindowWidth));
            Console.SetCursorPosition(0, currentLineCursor);
        }
        static bool Gender(int gender)
        {
            if (gender==1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        
     
        static int Tampilan(string name, int g)
        {
            int input;
            Console.Clear();
            bool checkGender = Gender(g);
            if (checkGender == true)
            {
                Console.WriteLine("Hello Mr. " + name);
            }
            else
            {
                Console.WriteLine("Hello Mrs. " + name);
            }
            
            Console.WriteLine("Silahkan Pilih Menu di bawah ini");
            Console.Write("1. Tambahkan Peralatan \t 2. Tampilkan Detail \t 3. Hapus Peralatan \t4. Keluar ");
            Console.Write("\nPilihan Anda : ");

            do
            {
                input = Convert.ToInt32(Console.ReadLine());
            } while (input < 0 || input > 4);
            return input;
        }

        static string TambahItem(string name, int gender)
        {
            Console.Write("\nMasukkan item : ");
            string item = Console.ReadLine();
            return item;
        }

        static double TambahPower()
        {
            Console.Write("Besar Dayanya (KWh) : ");
            double power = Convert.ToDouble(Console.ReadLine());
            return power;
        }

        static double TambahTime()
        {
            Console.Write("Lama Penggunaan setiap bulan (Jam) : ");
            double time = Convert.ToDouble(Console.ReadLine());
            return time;
        }





    }

    ////public class item
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //    public double Power { get; set; }
    //    public double TIme { get; set; }

  
}
