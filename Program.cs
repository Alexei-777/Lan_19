using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Модель компьютера  характеризуется  кодом  и  названием  марки компьютера, типом  процессора, частотой  работы  процессора,
//объемом оперативной памяти, объемом жесткого диска, объемом памяти видеокарты, стоимостью компьютера в условных единицах и количеством экземпляров, имеющихся в наличии.
//Создать список, содержащий 6-10 записей с различным набором значений характеристик.
//Определить:
//-все компьютеры с указанным процессором. Название процессора запросить у пользователя;
//-все компьютеры с объемом ОЗУ не ниже, чем указано. Объем ОЗУ запросить у пользователя;
//-вывести весь список, отсортированный по увеличению стоимости;
//-вывести весь список, сгруппированный по типу процессора;
//-найти самый дорогой и самый бюджетный компьютер;
//-есть ли хотя бы один компьютер в количестве не менее 30 штук?

namespace Lan_19
{
    class Program
    {
        class Comp
        {
            public int ID { get; set; }
            public string Name { get; set; }
            public string CPU { get; set; }
            public int Frequency { get; set; }
            public int RAM { get; set; }
            public int HDD { get; set; }
            public int VideoCart { get; set; }
            public int Money { get; set; }
            public int Kol { get; set; }
        }
        static void Main(string[] args)
        {
            List<Comp> Comps = new List<Comp>()
            {
                new Comp() {ID=1, Name="Alex2", CPU="Intel", Frequency=1000, RAM=8, HDD=8, VideoCart=2, Money=25000, Kol=100},
                new Comp() {ID=2, Name="Forec", CPU="Intel", Frequency=2000, RAM=4, HDD=2, VideoCart=4, Money=30000, Kol=22},
                new Comp() {ID=3, Name="Figny", CPU="AMD", Frequency=1500, RAM=16, HDD=2 , VideoCart=2, Money=55000, Kol=20},
                new Comp() {ID=4, Name="Gumno", CPU="Intel", Frequency=1300, RAM=8, HDD=6, VideoCart=4, Money=65000, Kol=10},
                new Comp() {ID=5, Name="Klass", CPU="AMD", Frequency=2000, RAM=8, HDD=1, VideoCart=1, Money=20000, Kol=11},
                new Comp() {ID=6, Name="Offic", CPU="AMD", Frequency=2200, RAM=12, HDD=3, VideoCart=2, Money=25000, Kol=60},
                new Comp() {ID=7, Name="Excel", CPU="Intel", Frequency=4000, RAM=6, HDD=1, VideoCart=3, Money=95000, Kol=40},
                new Comp() {ID=8, Name="Word2", CPU="Эльбрус", Frequency=100, RAM=4, HDD=2, VideoCart=2, Money=50000, Kol=50},
                new Comp() {ID=9, Name="Visio", CPU="Intel", Frequency=3000, RAM=8, HDD=8, VideoCart=12, Money=21500, Kol=10},
                new Comp() {ID=10, Name="Googl", CPU="Эльбрус", Frequency=200, RAM=2, HDD=2, VideoCart=16, Money=40000, Kol=13},
            };

            Console.WriteLine("Какой процессор Вас интересует?");       //все компьютеры с указанным процессором. Название процессора запросить у пользователя;
            Console.WriteLine("1 - Intel");
            Console.WriteLine("2 - AMD");
            Console.WriteLine("3 - Эльбрус");
            int a = Convert.ToInt32(Console.ReadLine());
            string Com;
            if (a == 1) { Com = "Intel"; } else { if (a == 2) { Com = "AMD"; } else { Com = "Эльбрус"; } }
            List<Comp> CompsN = Comps. Where(d => d.CPU == Com).ToList();
            foreach (Comp d in CompsN)
                Console.WriteLine($" {d.ID}    |     {d.Name}     |     {d.CPU}     |     {d.Frequency}     |     {d.RAM}     |     {d.HDD}     |     {d.VideoCart}     |     {d.Money}     |     {d.Kol}");
            Console.WriteLine();

            Console.WriteLine("Не меньше какого обьема памяти Вас интересует? (2-16)");       //все компьютеры с объемом ОЗУ не ниже, чем указано. Объем ОЗУ запросить у пользователя;
            a = Convert.ToInt32(Console.ReadLine());
            IEnumerable<Comp> CompsRAM = Comps
                .Where(d => d.RAM >= a)
                .ToList();
            foreach (Comp d in CompsRAM)
                Console.WriteLine($" {d.ID}    |     {d.Name}     |     {d.CPU}     |     {d.Frequency}     |     {d.RAM}     |     {d.HDD}     |     {d.VideoCart}     |     {d.Money}     |     {d.Kol}");
            Console.WriteLine();

            Console.WriteLine("Весь список, отсортированный по увеличению стоимости");       //вывести весь список, отсортированный по увеличению стоимости;
            List<Comp> CompsMoney = Comps
                .OrderBy(d => d.Money)
                .ToList();       
            foreach (Comp d in CompsMoney)
                Console.WriteLine($" {d.ID}    |     {d.Name}     |     {d.CPU}     |     {d.Frequency}     |     {d.RAM}     |     {d.HDD}     |     {d.VideoCart}     |     {d.Money}     |     {d.Kol}");
            Console.WriteLine();
            
            Console.WriteLine("Весь список, отсортированный по типу процессора");       //вывести весь список, сгруппированный по типу процессора;
            var CompsGr = from Comp in Comps
                          group Comp by Comp.CPU;
            foreach (IGrouping<string, Comp> t in CompsGr)
            {
                foreach (var d in t)
                    Console.WriteLine($" {d.ID}    |     {d.Name}     |     {d.CPU}     |     {d.Frequency}     |     {d.RAM}     |     {d.HDD}     |     {d.VideoCart}     |     {d.Money}     |     {d.Kol}");
            }
            Console.WriteLine();

            Console.WriteLine("Самый дорогой и самый дешовый");       //найти самый дорогой и самый бюджетный компьютер;
            var CompsMax = Comps
                .Max(d => d.Money);
            var CMax = Comps
                .Where(d => d.Money == CompsMax)
                .ToList();
            foreach (Comp d in CMax)
                Console.WriteLine($" {d.ID}    |     {d.Name}     |     {d.CPU}     |     {d.Frequency}     |     {d.RAM}     |     {d.HDD}     |     {d.VideoCart}     |     {d.Money}     |     {d.Kol}");
            Console.WriteLine("Самый дорогой и самый дешовый");       //найти самый дорогой и самый бюджетный компьютер;
            var CompsMin = Comps
                .Min(d => d.Money);
            var CMin = Comps
                .Where(d => d.Money == CompsMin)
                .ToList();
            foreach (Comp d in CMin)
                Console.WriteLine($" {d.ID}    |     {d.Name}     |     {d.CPU}     |     {d.Frequency}     |     {d.RAM}     |     {d.HDD}     |     {d.VideoCart}     |     {d.Money}     |     {d.Kol}");
            Console.WriteLine();


            Console.WriteLine("Компьютеров больше 30 штук");       //есть ли хотя бы один компьютер в количестве не менее 30 штук?
            var CompsC = Comps
                .Where(d => d.Kol>30)
                .Count();
                Console.WriteLine(CompsC);
            Console.ReadKey();
        }
    }
}
