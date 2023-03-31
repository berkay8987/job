using System;

/* Shallow Copy
 * -> Var olan bir nesnenin, degerin, referansin kopyalanmasidir
 * -> Shallow copy neticesinde eldeki deger cogalmaz. Sadece birden
 *    fazla referansla isaretlenmis olur.
 */

namespace ShallowVSDeepCopy
{
    class Program
    {
        static void Main(string[] args)
        {
            // Deep Copy, veri cogalir. (memory'de 2 tane 5 oldu)
            // Birini degistirmek digerini etkilemez.
            int a = 5;
            int b = a;

            // Shallow copy, veri cogalmadi. Ayni referansa sahip oldular
            // Birini degistirmek hepsini degistirir.
            // Bir nesneyi birden fazla referans isaretliyosa shallow copy
            Student s = new Student();
            Student s1 = s;
            Student s2 = s1;

            // Nesnelerde deep copy
            Student s3 = new Student();
            Student s4 = s3; // shallow copy
            Student s5 = s3.Clone(); // deep copy
        }
    }
    class Student
    {
        public Student Clone()
        {
            return (Student)this.MemberwiseClone();
        }

    }
}