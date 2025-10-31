using System.Net.Sockets;
using System.Reflection;
using System.Threading.Channels;

namespace VERİ_YAPILARI//saaaa
{
    #region DERSE DAIR NOTLAR
    /*
     * Hazır fonksiyonlar kullanılmamalı.
     * Her veri yapısını manuel olarak oluşturmalı.
     * Her veri yapısının recursive alternatifi bilinmeli.
     */
    #endregion 
    internal class Program
    {
        static int[] mainArr = new int[10];
        static int[] mainStack = new int[10];
        static int top;
        static int memX;
        static int memY;
        static int memZ;
        static int memW;
        static int memV;
        static int memU;
        static int memT;
        static Random rnd = new Random(100);
        class Block
        {
            public int data;
            public Block next;
        }
        #region HAFTA 3 - MEMORY LAYOUT - ARRAYS
        static void ders3()
        {
            int[] arrOneDim = { 1, 2, 3, 4, 5 };
            int[,] arrTwoDim = { { 1, 2, 3 }, { 4, 5, 6 } };
            int[,,] arrThreeDim = { { { 1, 2 }, { 3, 4 } }, { { 5, 6 }, { 7, 8 } } };

            Console.WriteLine(arrOneDimLengthFinder(arrOneDim));
            arrIndexOneDim(arrOneDim, 3);
            Console.WriteLine("addres: {0}", arrIndexAdressFinderWithArithmetic(arrThreeDim, new int[] { 1, 0, 1 }, 1000));

            int arrOneDimLengthFinder(int[] arr)
            {
                int count = 0;
                foreach (var i in arr)
                {
                    count++;
                }
                return count;
            }
            unsafe ulong arrIndexAdressFinder(int[] arr, int index) // unsafe keyword'ü, pointer kullanımı için gereklidir.
            {
                fixed (int* pointer = &arr[index])
                {
                    Console.WriteLine($"Dizinin {index}. indeksinin değeri: {*pointer}");
                    Console.WriteLine($"Dizinin {index}. indeksinin adresi (hexadecimal) : {(ulong)pointer:X}");
                    Console.WriteLine($"Dizinin {index}. indeksinin adresi (decimal): {(ulong)pointer}");
                    ulong address = (ulong)pointer;
                    return address;
                }
            }
            unsafe void arrIndexOneDim(int[] arr, int index)
            {
                ulong baseAddress = arrIndexAdressFinder(arr, 0);
                ulong indexAddress = baseAddress + (ulong)(index * sizeof(int)); // INDEX ADDRESS = BASE ADDRESS + (INDEX * SIZE OF ELEMENT)
                Console.WriteLine(indexAddress);
            }
            int getArrDimensionCount(Array arr)
            {
                return arr.Rank;
            }
            int arrIndexAdressFinderWithArithmetic(Array arr, int[] indicies, int baseAddress) //array layout - indexin bellekteki adresinin bulunması
            {
                int offset = 0;
                int N = getArrDimensionCount(arr);
                for (int k = 0; k < N; k++)
                {
                    int product = 1;
                    for (int l = k + 1; l < N; l++)
                    {
                        product *= arr.GetLength(l);
                    }
                    offset += indicies[k] * product;
                }
                int address = baseAddress + sizeof(int) * offset;
                return address;

            }

        }// Arraylar memory layout
        #endregion
        #region HAFTA 4 - ARRAYS
        static void ders4() // Arraylar ile ilgili örnek fakülte bölümler
        {
            // Mühendislik Fakültesi, Bilgisayar Mühendisliği Bölümü, normal öğretim 0,0,0
            int[,,] fakülteler = new int[5, 15, 2];
            Random rnd = new Random();



            // Diğer fakülteler ve bölümler için rastgele öğrenci sayıları atama
            for (int i = 0; i < fakülteler.GetLength(0); i++)
                for (int j = 0; j < fakülteler.GetLength(1); j++)
                    for (int k = 0; k < fakülteler.GetLength(2); k++)
                        fakülteler[i, j, k] = rnd.Next(1, 501);




            // Tüm fakülteler, bölümler ve öğretim türleri için öğrenci sayılarını yazdırma
            for (int i = 0; i < fakülteler.GetLength(0); i++)
            {
                for (int j = 0; j < fakülteler.GetLength(1); j++)
                {
                    for (int k = 0; k < fakülteler.GetLength(2); k++)
                    {
                        Console.WriteLine($"Fakülte: {i}, Bölüm: {j}, Öğretim Türü: {k}, Öğrenci Sayısı: {fakülteler[i, j, k]}");
                    }
                }
            }

            // Her fakülte ve bölüm için toplam öğrenci sayısı TOPLAM 
            for (int i = 0; i < fakülteler.GetLength(0); i++)
            {
                for (int j = 0; j < fakülteler.GetLength(1); j++)
                {
                    int toplam = 0;
                    for (int k = 0; k < fakülteler.GetLength(2); k++)
                    {
                        toplam += fakülteler[i, j, k];
                    }
                    Console.WriteLine($"Fakülte: {i}, Bölüm: {j}, Toplam Öğrenci Sayısı: {toplam}");
                }
            }


            // Tüm fakültelerdeki normal öğretimdeki öğrenci sayısını hesaplayıp yazdırma
            memX = 0; // memX = toplam öğr say
            for (int i = 0; i < fakülteler.GetLength(0); i++)
            {

                for (int j = 0; j < fakülteler.GetLength(1); j++)
                {

                    memX += fakülteler[i, j, 0];
                }
            }
            Console.WriteLine("Toplam Normal Öğretimdeki Öğrenci Sayısı = {0}", memX);

            //en çok öğrencisi olan fakülte
            memX = 0; // memX = en çok öğrenci sayısı atanacak
            memY = 0; // memY = en çok öğrenci sayısına sahip fakülte numarası atanacak
            for (int i = 0; i < fakülteler.GetLength(0); i++)
            {
                for (int j = 0; j < fakülteler.GetLength(1); j++)
                {

                    for (int k = 0; k < fakülteler.GetLength(2); k++)
                    {
                        if (fakülteler[i, j, k] > memX) //en büyük değeri bulma . eğer mevcut değerden büyükse 
                        {
                            memX = fakülteler[i, j, k]; // memX'e ata
                            memY = i; // memY'ye fakülte numarasını ata
                        }
                    }

                }
            }
            Console.WriteLine("{1} nolu fakülte {0} öğrenci sayısıyla en kalabalık fakülte ", memX, memY);

            //en çok öğrencisi olan bölüm
            memX = 0; // memX = en çok öğrenci sayısı atanacak
            memY = 0; // memY = en çok öğrenci sayısına sahip fakülte numarası atanacak
            for (int i = 0; i < fakülteler.GetLength(0); i++)
            {
                for (int j = 0; j < fakülteler.GetLength(1); j++)
                {

                    for (int k = 0; k < fakülteler.GetLength(2); k++)
                    {
                        if (fakülteler[i, j, k] > memX) //en büyük değeri bulma . eğer mevcut değerden büyükse 
                        {
                            memX = fakülteler[i, j, k]; // memX'e ata
                            memY = i; // memY'ye fakülte numarasını ata
                        }
                    }

                }
            }
            Console.WriteLine("{1} nolu fakülte {0} öğrenci sayısıyla en kalabalık fakülte ", memX, memY);


        }
        static void ders44() // Arraylar ile ilgili örnek bölgeler ve köyler -ÖNEMLİ-
        {
            // bölge , il, ilçe, bucak ,köy
            int[,,,,] köyler = new int[7, 20, 25, 15, 55];

            // random sayıların ATANMASI
            Random random = new Random();
            for (int i0 = 0; i0 < köyler.GetLength(0); i0++)
                for (int i1 = 0; i1 < köyler.GetLength(1); i1++)
                    for (int i2 = 0; i2 < köyler.GetLength(2); i2++)
                        for (int i3 = 0; i3 < köyler.GetLength(3); i3++)
                            for (int i4 = 0; i4 < köyler.GetLength(4); i4++)
                                köyler[i0, i1, i2, i3, i4] = random.Next(0, 6886);

            #region TOPLAM köy ve nüfus sayısı
            memX = 0; // memX = toplam köy sayısı
            memY = 0; // memY = toplam nüfus sayısı
            for (int i0 = 0; i0 < köyler.GetLength(0); i0++)
                for (int i1 = 0; i1 < köyler.GetLength(1); i1++)
                    for (int i2 = 0; i2 < köyler.GetLength(2); i2++)
                        for (int i3 = 0; i3 < köyler.GetLength(3); i3++)
                            for (int i4 = 0; i4 < köyler.GetLength(4); i4++)
                            {
                                memX += 1; // her köy için 1 ekle
                                memY += köyler[i0, i1, i2, i3, i4]; // nüfus sayısını ekle
                            }
            Console.WriteLine("* Toplam Köy Sayısı = {0} , Toplam Nüfus Sayısı = {1}", memX, memY);

            #endregion
            #region en KALABALIK köyün bulunması

            memX = 0; // memX = en çok nüfus sayısı atanacak
            memY = 0; // memY = en çok nüfus sayısına sahip il numarası atanacak
            for (int i0 = 0; i0 < köyler.GetLength(0); i0++)
                for (int i1 = 0; i1 < köyler.GetLength(1); i1++)
                    for (int i2 = 0; i2 < köyler.GetLength(2); i2++)
                        for (int i3 = 0; i3 < köyler.GetLength(3); i3++)
                            for (int i4 = 0; i4 < köyler.GetLength(4); i4++)
                                if (köyler[i0, i1, i2, i3, i4] > memX) //en büyük değeri bulma . eğer mevcut değerden büyükse 
                                {
                                    memX = köyler[i0, i1, i2, i3, i4]; // memX'e ata
                                    memY = i4; // memY'ye bölge numarasını ata
                                    memZ = i1; // memZ'ye il numarasını ata
                                }
            Console.WriteLine("* {2} nolu şehrin {1} nolu köyü {0} nüfus sayısıyla en kalabalık köy ", memX, memY, memZ);

            #endregion
            #region boş olan boş olmayan köyler - 0dan farklı kaç köy var

            memX = 0; // memX = boş köy sayısı
            memY = 0; // memY = boş olmayan köy sayısı
            memZ = 0; // memZ = boş olmayan köylerin nüfus sayısı
            for (int i0 = 0; i0 < köyler.GetLength(0); i0++)
                for (int i1 = 0; i1 < köyler.GetLength(1); i1++)
                    for (int i2 = 0; i2 < köyler.GetLength(2); i2++)
                        for (int i3 = 0; i3 < köyler.GetLength(3); i3++)
                            for (int i4 = 0; i4 < köyler.GetLength(4); i4++)
                                if (köyler[i0, i1, i2, i3, i4] == 0) // boş olan
                                {
                                    memX = memX + 1; // boş olan köy sayısı                                    
                                }
                                else
                                {
                                    memY += 1; // boş olmayan köy sayısı
                                    memZ += köyler[i0, i1, i2, i3, i4]; // nüfus sayısını ekle
                                }
            Console.WriteLine("* Tüm Dizideki:\n Boş olan köy sayısı = {0}\n boş olmayan köy sayısı = {1}\n toplam köy sayısı = {3}\n boş olmayan köylerin nüfusu = {2}\n \n", memX, memY, memZ, memY + memX);

            #endregion
            #region index 1 numaralı bölgenin index 2 numaralı şehrindeki boş köyler

            memX = 0; // memX = boş köy sayısı
            memY = 0; // memY = boş olmayan köy sayısı
            memZ = 0; // memZ = boş olmayan köylerin nüfus sayısı
            for (int i2 = 0; i2 < köyler.GetLength(2); i2++)
                for (int i3 = 0; i3 < köyler.GetLength(3); i3++)
                    for (int i4 = 0; i4 < köyler.GetLength(4); i4++)
                        if (köyler[1, 2, i2, i3, i4] == 0) // boş olan
                        {
                            memX = memX + 1; // boş olan köy sayısı                                    
                        }
                        else
                        {
                            memY += 1; // boş olmayan köy sayısı
                            memZ += köyler[1, 2, i2, i3, i4]; // nüfus sayısını ekle
                        }

            Console.WriteLine("* 1 numaralı bölgenin 2 numaralı ilindeki:\n -Boş olan köy sayısı = {0}\n -boş olmayan köy sayısı = {1}\n -toplam köy sayısı = {3}\n -boş olmayan köylerin nüfusu = {2}\n \n", memX, memY, memZ, memY + memX);

            #endregion
            #region en FAZLA nüfusa sahip köyün bağlı olduğu ilin id sini ekrana yazdırma      

            memX = 0; // memX = en çok nüfus sayısı atanacak
            memY = 0; // memY = en çok nüfus sayısına sahip il numarası atanacak
            memZ = 0;
            for (int i0 = 0; i0 < köyler.GetLength(0); i0++)
                for (int i1 = 0; i1 < köyler.GetLength(1); i1++)
                    for (int i2 = 0; i2 < köyler.GetLength(2); i2++)
                        for (int i3 = 0; i3 < köyler.GetLength(3); i3++)
                            for (int i4 = 0; i4 < köyler.GetLength(4); i4++)
                                if (memX < köyler[i0, i1, i2, i3, i4])
                                {
                                    memX = köyler[i0, i1, i2, i3, i4];
                                    memY = i1; // il numarası
                                }
            Console.WriteLine("* {0} nüfus ile en FAZLA kalabalık köyün bağlı olduğu ilin id'si = {1}\n", memX, memY);


            #endregion
            #region en FAZLA nüfusa sahip ilçenin bağlı olduğu bölgenin nüfusu -ÖNEMLİ-
            memX = 0; // memX = en büyük ilçe nüfusu
            memY = 0; // toplam nüfus ilçe sınırlı
            memZ = 0; // bağlı olduğu bölge idisi
            memU = 0; // bağlı olduğu bölgenin toplam nüfusu

            for (int i0 = 0; i0 < köyler.GetLength(0); i0++)
                for (int i1 = 0; i1 < köyler.GetLength(1); i1++)
                    for (int i2 = 0; i2 < köyler.GetLength(2); i2++)
                    {
                        memY = 0;// her ilçe için nüfus sıfırlanır ÖNEMLİ !
                        for (int i3 = 0; i3 < köyler.GetLength(3); i3++)
                        {
                            for (int i4 = 0; i4 < köyler.GetLength(4); i4++)
                            {
                                memY += köyler[i0, i1, i2, i3, i4];
                            }
                        }
                        if (memX < memY)
                        {
                            memX = memY; // en fazla nüfus
                            memZ = i0; // bağlı olduğu bölgeidisi

                        }
                    }

            for (int i0 = 0; i0 < köyler.GetLength(0); i0++)
                for (int i1 = 0; i1 < köyler.GetLength(1); i1++)
                    for (int i2 = 0; i2 < köyler.GetLength(2); i2++)
                        for (int i3 = 0; i3 < köyler.GetLength(3); i3++)
                            for (int i4 = 0; i4 < köyler.GetLength(4); i4++)
                                memU += köyler[memZ, i1, i2, i3, i4]; // en kalabalık ilçenin bağlı olduğu bölgenin nüfusu

            Console.WriteLine("* {0} nüfus ile en FAZLA kalabalık ilçenin bağlı olduğu bölgenin id'si = {1}\n\n" +
                "* en FAZLA nüfusa sahip ilçenin bağlı olduğu bölgenin nüfusu = {2}", memX, memZ, memU);
            #endregion
            #region 7 bölgenin nüfuslarını tek tek TOPLAYARAK int[] bölgeNüfusları  DİZİSİNE ATMA
            int[] bölgeNüfusları = new int[7]; // 7 bölge için
            memX = 0; // memX = bölge nüfusu
            memY = 0; // memY = bölge sayacı
            for (int i0 = 0; i0 < köyler.GetLength(0); i0++)
            {
                memX = 0; // her bölge için nüfus sıfırlanır
                for (int i1 = 0; i1 < köyler.GetLength(1); i1++)
                {
                    for (int i2 = 0; i2 < köyler.GetLength(2); i2++)
                        for (int i3 = 0; i3 < köyler.GetLength(3); i3++)
                            for (int i4 = 0; i4 < köyler.GetLength(4); i4++)
                            {
                                memX += köyler[i0, i1, i2, i3, i4];
                            }
                }
                bölgeNüfusları[i0] = memX; // bölge nüfusları dizisine atama
            }
            for (int i = 0; i < bölgeNüfusları.Length; i++)
            {
                Console.WriteLine("* {0} nolu bölgenin nüfusu = {1}", i, bölgeNüfusları[i]);
            }

            // 7 bölgenin nüfuslarını il bazında tek tek TOPLAYARAK int[,] bölgeNüfuslarıİlBazında  DİZİSİNE ATMA
            int[,] bölgeNüfuslarıİlBazında = new int[7, 20]; // 7 bölge için 20 il
            memX = 0; // memX = bölge nüfusu
            memY = 0; // memY = bölge sayacı
            for (int i0 = 0; i0 < köyler.GetLength(0); i0++)
            {
                for (int i1 = 0; i1 < köyler.GetLength(1); i1++)
                {
                    memX = 0; // her bölge için nüfus sıfırlanır
                    for (int i2 = 0; i2 < köyler.GetLength(2); i2++)
                    {
                        for (int i3 = 0; i3 < köyler.GetLength(3); i3++)
                        {
                            for (int i4 = 0; i4 < köyler.GetLength(4); i4++)
                            {
                                memX += köyler[i0, i1, i2, i3, i4];
                            }
                        }
                    }
                    bölgeNüfuslarıİlBazında[i0, i1] = memX; // bölge nüfusları dizisine atama
                }
            }
            for (int i = 0; i < bölgeNüfuslarıİlBazında.GetLength(0); i++)
            {
                for (int j = 0; j < bölgeNüfuslarıİlBazında.GetLength(1); j++)
                {
                    Console.WriteLine("* {0} nolu bölgenin {1} nolu ilinin nüfusu = {2}", i, j, bölgeNüfuslarıİlBazında[i, j]);
                }
            }
            #endregion
            #region en BÜYÜK nüfusa sahip 2. bölge

            #endregion

        }
        #endregion
        #region HAFTA 5 - SINGLY LINKED LISTS
        static void hafta5()
        {
            #region SLL NOTES
            /*Linked list bellekte ardışık değildir.
            liste gezmek için genelde while(bl != null) kalıbı kullanılır

            - Özellik -        - Dizi (Array) -	  - Linked List -
            Hafıza	        Ardışık (sıralı)	   Dağınık (rastgele)
            Erişim	        İndeks ile	           Bağlantı (next pointer) ile
            Boyut       	Sabit	               Dinamik
            Ekleme/Silme	Zor, kaydırma gerekir  Kolay, bağlantı değiştirirsin
            Bellek Yönetimi	Sabit	               Dinamik (heap)
            */
            #endregion
            #region Sınavda yapılan hatalar DIKKAT!
            /*
            -Sınavda yapılan hatalar: 

            *head'i kaybetmek. head değişkenini güncellerken yeni bir blok oluşturup head=head.next yazarsan listeye erişimi kaybedersin. çözüm: tmp = head klonuyla çalışmaktır.(head kaybı sınavda en sık tuzak sorudur.

            *boş liste kontrolu: head == null kontrolü yapılmalı 

            *sonsuz döngü: while(bl != null) yerine yanlışlıkla (bl.next != null) yazarsan son eleman atlanır.
            *atilla sorularında hep bir varyasyon olur: “data = 7’den sonra ekle, 5. elemanı sil, çiftleri say” gibi.
            */
            #endregion
            Block head = LinkedListOlustur();
            Block head2 = LinkedListOlusturRecursive(25);
            Block linkedListHead = SLLolustur();
            Block newLinkedListHead = LinkedListOlusturRecursive(25);
            ValuedenSonraArayaNodeEkle(head, 2);
            LinkedListOku(head);
            LinkedListOkuRecursive(head);
            LinkedListOkuRecursiveTersten(head);
            CiftElemanlarıYazdır(head);
            LinkedListOkuRecursive(linkedListHead);
            LinkedListOkuRecursive(newLinkedListHead);
            linkedListHead = BaşaEkle(linkedListHead, -1);
            LinkedListOkuRecursive(linkedListHead);
            linkedListHead = SonaEkle(linkedListHead, -1);
            LinkedListOkuRecursive(linkedListHead);
            linkedListHead = ValueElemanıSil(linkedListHead, -1);
            LinkedListOkuRecursive(linkedListHead);
            ValueInciElemanıBul(linkedListHead, 4);
            LinkedListeyiTerstenOkuStackIle(head);
            LinkedListtekiEnBuyukElemanBul(head);
            CiftElemanlarıYazdırRecursive(linkedListHead);
            LinkedListOkuRecursive(linkedListHead);
            soru1();
            soru2();
            soru3();
            soru4(linkedListHead);
            hocadanDerste();
            Block headx = null;
            linkAl(ref headx,1);
            linkYazRec(headx);

        
            // SLL ÖRNEKLERİ METHOD OLARAK
            static Block LinkedListOlustur()
            {
                Block tmp;
                Block head = null;
                for (int i = 0; i < 10; i++)
                {
                    tmp = new Block();
                    tmp.data = i;
                    tmp.next = head;
                    head = tmp;
                }
                return head;
            }
            static Block LinkedListOlusturRecursive(int n)
            {
                if (n == 0) return null;
                Block node = new Block();
                node.data = rnd.Next(0,100);
                node.next = LinkedListOlusturRecursive(n - 1);
                return node;
            }
            static void LinkedListOku(Block tmp)
            {
                while (tmp != null)
                {
                    Console.Write("[ data = {0} | * ] --> ",tmp.data);
                    tmp = tmp.next;
                }
                if (tmp == null)
                {
                    Console.WriteLine("[ NULL ]");
                }
            }
            static void LinkedListOkuRecursive(Block node,int sayac =1)
            {
                if (node == null) return;
                Console.WriteLine("{0}. Data = {1}", sayac, node.data);
                LinkedListOkuRecursive(node.next,sayac+1);
            }
            static void LinkedListOkuRecursiveTersten(Block node)
            {
                if (node == null) return;
                LinkedListOkuRecursiveTersten(node.next);
                Console.Write(node.data + " ");
            }
            static Block ValuedenSonraArayaNodeEkle(Block head , int value)
            {
                Block temp = head;
                while (temp != null)
                {
                    if(temp.data == value)
                    {
                        Block newBlock = new Block();
                        newBlock.data = 31;
                        newBlock.next = temp.next;
                        temp.next = newBlock;
                        break;
                    }
                    temp = temp.next;
                }
                return head;
            }
            static Block SLLolustur()
            {
                Block tmp;
                Block bas = new Block();
                tmp = bas;
                for(int i = 0; i < 10; i++)
                {
                    tmp.data = i*99;
                    if (i < 9)
                    {
                        tmp.next = new Block();
                        tmp = tmp.next;
                    }
                }
                return bas;
            }
            static Block BaşaEkle(Block head ,int value)
            {
                Block newNode = new Block();
                newNode.data = value;
                newNode.next = head;
                head = newNode;
                return head;
            }
            static Block SonaEkle(Block head ,int value)
            {
                Block newNode = new Block();
                newNode.data = value;
                newNode.next = null;

                if (head == null) 
                    return newNode;

                Block tmp = head;
                while (tmp.next != null)
                {
                    tmp = tmp.next;
                }
                tmp.next = newNode;
                return head;
            }
            static Block ValueElemanıSil(Block head ,int value)
            {
                Block temp;
                temp = head;
                if (head == null) return null;
                if (head != null && head.data == value)
                {
                    head = head.next;
                }
                while (temp.next != null && temp !=null)
                {
                    if (temp.next.data == value)
                    {
                        temp.next = temp.next.next; //node silme işlemi
                    }
                    else temp = temp.next; //ilerle
                }
                return head;
            }
            static void CiftElemanlarıYazdır(Block head)
            {
                if (head == null) return;
                Block temp = head;
                while ( temp!= null)
                {
                    if(temp.data %2 == 0)
                    {
                        Console.Write(temp.data + " | ");
                    }
                    temp = temp.next;
                }
            }
            static void CiftElemanlarıYazdırRecursive(Block node)
            {
                if (node == null) return;
                if (node.data % 2 == 0)
                {
                    Console.Write(node.data + " ");
                }
                CiftElemanlarıYazdırRecursive(node.next);
            }
            static void ValueInciElemanıBul(Block head,int value,int sayac = 1)
            {
                Block temp = head;
                Block temp2 = head;
                if (temp == null) return;
                for (int i = sayac; i < value; i++)
                {
                    temp = temp.next;
                }
                Console.WriteLine("{0}. elemanın datası = {1} ",value,temp.data);

                //alternatif while ile 
                while(temp2 != null && sayac<value)
                {
                    temp2=temp2.next;
                    sayac = sayac+1;//sayac++
                }
                if (temp != null)
                {
                    Console.WriteLine("{0}. elemanın datası = {1} ", value, temp2.data);
                }
            }
            static void LinkedListeyiTerstenOkuStackIle(Block head)
            {
                Block temp = head;
                int[] stack = new int[100];
                int top = -1;

                while (temp != null)
                {
                    stack[++top] = temp.data;
                    temp = temp.next;
                }
                while (top >= 0) Console.Write(stack[top--]+" | ");
            }// stack usage
            static void LinkedListtekiEnBuyukElemanBul(Block head)
            {
                Block temp = head;
                int enBuy = 0;
                while (temp != null)
                {
                    if(temp.data > enBuy) enBuy = temp.data;
                    temp = temp.next;
                }
                Console.WriteLine("En büyük eleman: "+enBuy);
            }
            static void soru1()//Bir tekli linked list’te hem başa hem de sona eleman ekleyen bir kod yazınız. Liste başlangıçta 0–4 arası değerleri içermektedir. Başına -1, sonuna 99 ekleyiniz. Son olarak listeyi ekrana yazdırınız.
            {
                Block head = null;
                Block temp;
                // 0-4 arasında başlangıç listesi
                for(int i = 0; i < 5; i++)
                {
                    temp = new Block();
                    temp.data = i;
                    temp.next = head;
                    head = temp;
                }

                // başa -1 ekle
                Block newNode = new Block();
                newNode.data = -1;
                newNode.next = head;
                head = newNode;// ÖNEMLİ KAÇIRMA HEADİ KAYBETME

                // sonra 99 ekle
                temp = head;
                while(temp.next != null)
                {
                    temp = temp.next;
                }
                Block newNode2 = new Block();
                newNode2.data = 99;
                newNode2.next = null;
                temp.next = newNode2;

                // yazdır
                Console.Write("liste: ");
                temp = head;
                while (temp != null)
                {
                    Console.Write(temp.data + " ");
                    temp = temp.next;
                }

                Console.WriteLine();
            }
            static void soru2()//Aşağıdaki tekli linked list üzerinde data değeri 3 olan bloğun ardından data=1453 olan bir blok ekleyen kodu yazınız. İşlemden sonra oluşan listeyi ekrana yazdırınız.
            {
                Block head = null;

                // 0-6 arasında linked list olustur
                for (int i = 0;i < 6; i++)
                {
                    Block tmpp = new Block();
                    tmpp.data = i;
                    tmpp.next = head;
                    head = tmpp;
                }

                //araya data==3ten sonra data==1453 node ekle
                Block temp = head;
                while(temp != null)
                {
                    if (temp.data == 3)
                    {
                        Block newNode = new Block();
                        newNode.data = 1453;
                        newNode.next = temp.next;
                        temp.next = newNode;    
                    }
                    temp= temp.next;
                }

                //listeyi yazdır
                temp = head;
                while (temp != null)
                {
                    Console.Write(temp.data + " ");
                    temp = temp.next;   
                }
                Console.WriteLine();
            }
            static void soru3()//0–6 arası değerlerden oluşan bir tekli linked list içinde data değeri 2 olan bloğu silen kodu yazınız. Ardından listeyi yazdırınız.
            {
                Block head = null;
                
                // 0-6 arasında linked list olustur
                for(int i = 0; i < 6; i++)
                {
                    Block tmpp = new Block();
                    tmpp.data = i;
                    tmpp.next = head;
                    head = tmpp;
                }

                //ilk halini yazdır
                Block temp = head;
                Console.WriteLine("Silme öncesi liste:");
                while (temp != null)
                {
                    Console.Write(temp.data + " ");
                    temp = temp.next;
                }
                Console.WriteLine();

                // data değeri == 2 olan elemanı silme
                temp= head;
                while (temp.next != null && temp != null)
                {
                    if (temp.next.data == 2)
                    {
                        temp.next = temp.next.next; //node silme işlemi
                    }
                    else temp = temp.next; //ilerle
                }

                // öceki listeyi yazdır
                temp = head;
                Console.WriteLine("Silme sonrası liste:");
                while (temp != null)
                {
                    Console.Write(temp.data + " ");
                    temp = temp.next;
                }
                Console.WriteLine();
            }
            static void soru4(Block head)//Listeyi tersine çeviren algoritmayı elle yaz (reverse linked list).”
            {
                Block prev = null;     // gerideki blok
                Block current = head;  // o anki blok
                Block next = null;     // sonraki blok

                while (current != null)
                {
                    next = current.next;   // 1️⃣ sıradakini kaydet
                    current.next = prev;   // 2️⃣ bağlantıyı ters çevir
                    prev = current;        // 3️⃣ bir adım ilerle
                    current = next;        // 4️⃣ sıradakine geç
                }

                head = prev;  // 5️⃣ yeni head artık son elemandır

                // listeyi yazdır
                Block temp = head;
                while (temp != null)
                {
                    Console.Write(temp.data + " ");
                    temp = temp.next;
                }
            }
            static void hocadanDerste()
            {
                Block head = null;
                Block temp = null;
                Block last = null;

                // bağlı liste oluşturma ilk gösterdiği yöntem
                for (int i = 0; i < 10; i++)
                {
                    Block newNode = new Block();
                    newNode.data = i;

                    if (head == null)
                    {
                        head = newNode;

                    }
                    else
                    {
                        last.next = newNode;

                    }
                    last = newNode;
                }
                temp = head;
                //yazdır
                while (temp != null)
                {
                    Console.Write(temp.data + " ");
                    temp = temp.next;
                }
                Console.WriteLine();

                // bağlı liste oluşturma ikinci gösterdiği yöntem bu yöntemi daha cok seviyormuş beyfendi
                for (int i = 10; i < 10; i++)
                {
                    Block newNode = new Block();
                    newNode.data = i;
                    newNode.next = last;
                    last = newNode;
                }
                temp = head;
                //yazdır
                while (temp != null)
                {
                    Console.Write(temp.data + " ");
                    temp = temp.next;
                }
                Console.WriteLine();
            }
            static void linkAl(ref Block bl,int data)
            {
                if (data == 20) return;
                if (bl == null)
                {
                    bl = new Block();
                    bl.data = data;
                }
                else
                {
                    bl.next = new Block();
                    bl.next.data = data;
                }
                linkAl(ref bl.next, data+1);
            }
            static void linkYazRec(Block temp)
            {
                if(temp == null) return;
                Console.WriteLine(temp.data + " ");
                linkYazRec(temp.next);
            }
        }
        #endregion
        #region HAFTA 7 - DOUBLE LINKED LIST - STACKS
        class block // LINKED VERI YAPILARI CLASS CFG
        {
            public int data;
            public block next;
            public block prev;
        }
        static void hafta7()// Double linked lists
        {
            #region - DOUBLE LINKED LIST NOTES -
            /*  Tekli linked listlerde headi kaybedersek veya değişikliğe uğratırsak tekrar ulaşım mümkün değildir.SLL(singly linked list) sadece tek yönü point ederken DLL(double linked list) iki pointer ile tutulur sonucunda ram kullanımı artar. head kaybolsa bile last üzerinden listeye ulaşmak mümkündür.    */
            #endregion
            #region - ATILLANIN DOUBLE LINKED LIST ORNEKLERI -
            /*
             * listenin başında data değeri -1 olan bloğu ekleyiniz.
             * baştan 3. bloktansonra data değeri 123 olan bloğu ekleyiniz.
             * sondan 3. bloğa data değeri 3131 olan bloğu ekleyiniz.
             * data değeri 7 olan bloktan sonra data değeri 77 olan bloğu ekleyiniz
             */
            #endregion

            #region * 10 elemanlı DLL *
            block head = null;
            block last = null;
            
            
            for (int i = 0; i < 10; i++)
            {
                block tmp = new block();
                tmp.data = -1;
                tmp.next = head;
                tmp.prev = null;

                if (head != null) head.prev = tmp;
                else last = tmp;
                head = tmp;

            }

            block ptr = new block();
            while (ptr != null)// ileri yönde yazdırma 
            {
                Console.Write(ptr.data + " ");
                ptr = ptr.next;
            }

            while (ptr != null)// geri yönde yazdırma
            {
                Console.Write(ptr.data + " ");
                ptr = ptr.prev;
            }

            #endregion
        }
 
        class MyStack// OOP ARRAY STACK YAPISI
        {
            private int[] stack;
            private int sPtr;

            public MyStack(int size)
            {
                stack = new int[size];
                sPtr = -1;
            }

            public void Push(int data)
            {
                if (sPtr == stack.Length - 1)
                {
                    Console.WriteLine("Stack dolu!");
                    return;
                }
                stack[++sPtr] = data;
            }
            public int Pop()
            {
                /*
                    int data = stack[sPtr];
                    sPtr--;
                    return data;
                */
                if (sPtr == -1)
                {
                    Console.WriteLine("Stack boş!");
                    return -1;
                }
                return stack[sPtr--];
                
            }
            public int Peek()
            {
                /*
                    int data = stack[sPtr];
                    return data
                */

                if (sPtr == -1)
                {
                    Console.WriteLine("Stack boş!");
                    return -1;
                }
                return stack[sPtr];
            }
            public int Length()
            {
                //  return sPtr+1;
                return stack.Length;
            }
            public void Clear()
            {
                sPtr = -1;
                Console.WriteLine("Stack temizlendi !");
            }
        }
        static void hafta77()// STACKS
        {
            #region - STACKS NOTES -
            /*  stacklar konusu veri yapılarının diziyle düşünme becerisini pointer mantığına dönüştürme noktasıdır. gelişmiş veri yapısıdır SON GELEN İLK ÇIKAR yani LAST İN FİRS OUT (LİFO) prensibiyle çalışır. PUSH POP PEEK temel işlemleri içerir. matematiksel ifadeler stack ile çözülür.  */
            #endregion
            #region - STACKS ATİLLA ÖRNEKLER -
            /*
             * Stack kullanarak bilgisayar dizinlerini terminalde yazdıran kod
             * stack kullanarak 0 ve 1 lerden oluşan bir matristeki 1 lerin sayısını bulma. en çok 1 bulundurak grubu bulma
             */
            #endregion 

            MyStack stackcık = new MyStack(10);
            stackcık.Clear();
            stackcık.Push(0);
            stackcık.Push(1);
            stackcık.Push(2);
            stackcık.Push(3);
            stackcık.Push(4);

            Console.WriteLine("pop : " + stackcık.Peek());

            for (int i = 0;i<stackcık.Length(); i++)
            {
                Console.WriteLine(stackcık.Pop() + " ");
            }


           

        }
        #endregion
        static void Main(string[] args) // MAIN METHOD
        {
            Console.WriteLine("ALLAH KURTARSIN!");
            hafta5();
            
        }
    }
}
