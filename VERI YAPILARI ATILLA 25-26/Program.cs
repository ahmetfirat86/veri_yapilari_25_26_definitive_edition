namespace VERİ_YAPILARI//listenin eleman sayısını bulunuz recursive
{
    #region Euzu billahi mineşşeytanirracim ve Bismillahirrahmanirrahim
    /* Allah’ım, veri yapıları dersinde ilmi doğru anlamayı ve emeğimin karşılığını almayı nasip eyle. Çalışmamı bereketli kıl, zihnimi açık ve muhakememi sağlam eyle. Attilla Ergüzen hocamızın verdiği ilmi hakkıyla kavrayıp adil bir şekilde değerlendirilmemi sağla. Hakkımla bu dersi geçmeyi ve hayırlı bir başarı elde etmeyi bana lütfet.Amin.
     */
    #endregion
    #region DERSE DAIR NOTLAR
    /* Hazır fonksiyonlar kullanılmamalı.
     * Her veri yapısını manuel olarak oluşturmalı.
     * Her veri yapısının recursive alternatifi bilinmeli.
     * Hocanızın en belirgin özelliği, C#'ın sunduğu hazır kütüphaneleri ve yöntemleri kullanmak yerine, her şeyi "sıfırdan" (manual) ve bellek adresleme mantığıyla yaptırmasıdır.
    • Düşük Seviyeli Düşünme: Değişkenleri sadece birer isim olarak değil, RAM üzerindeki adresler ve kapladıkları byte'lar üzerinden değerlendirir
    • Hazır Metot Yasağı: Sınavlarda List, Dictionary, Array.Sort, IndexOf, Substring gibi hazır yapıların ve hatta foreach döngüsünün kullanılmasını kesinlikle istemez; puan kıracağını veya sıfır vereceğini açıkça belirtir
    • Rekürsif (Özyinelemeli) Yaklaşım: Hocanız için rekürsif çözümler "puan anahtarıdır". Bir problemi hem döngüyle hem rekürsif çözmenizi bekler ve rekürsif çözüme genellikle daha yüksek puan verir
    • Performans Odaklılık: Kodun sadece çalışması yetmez; hangi döngünün daha az işlem yapacağı veya bellekte nasıl daha hızlı hareket edileceği (örneğin matrisleri satır bazlı okumak) onun için kritiktir
    • Veri Yapılarını Manuel İnşa Etme: Stack, Queue ve Linked List gibi yapıları C#'ın kendi sınıflarıyla değil, kendi oluşturduğu Block veya MyBlock gibi sınıflarla kurar
.
     */
    #endregion
    internal class Program
    {
        static int[] mainArr = new int[10];
        static int top, memX,memY,memZ,memW,memV,memU,memT;
        static Random rnd = new Random(100);
        class Block //blok yapısı
        {
            public int data;
            public Block next;
            public Block prev;
        }
        static Block spll = null; //stackin headi

        static string[] stackStringArray = new string[10000];
        static int sp = -1;
        static int stackStringPointer = -1;
        static int[] mainStack = new int[5];

        static int front = 0;
        static int rear = -1;
        static int[] mainQueue = new int[5];

        static Block frontll = null;
        static Block rearll = null;

        static int[] mainIntHashTable = new int[100];
        static string[] mainStringHashTable = new string[100];

        static int[] binary_tree = new int[100];
        static void bosluk() {Console.WriteLine();}
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
        #region HAFTA 6 - SINGLY LINKED LISTS and DOUBLE LINKED LISTS
        static void HAFTA6()
        {
            hafta6_1(); hafta6_2();
            static void hafta6_1() //SLL
            {
                static void calıstırH6_1()
                {
                    Console.WriteLine();
                    READ_LIST(CREATE_LIST());
                    Console.WriteLine();
                    READ_LIST_RECURSIVE(CREATE_LIST());
                    Console.WriteLine();
                    READ_LIST_RECURSIVE(ADD_RECORD_BEFORE_HEAD(CREATE_LIST(), 31));
                    Console.WriteLine();
                    READ_LIST_RECURSIVE(DELETE_HEAD(CREATE_LIST()));
                    Console.WriteLine();
                    READ_LIST_RECURSIVE(ADD_TO_LIST_1(CREATE_LIST(), 99));
                    Console.WriteLine();
                    READ_LIST_RECURSIVE(DELETE_LAST_ITEM_1(CREATE_LIST()));
                    Console.WriteLine();
                    READ_LIST_RECURSIVE(ODEV_1(CREATE_LIST()));
                    Console.WriteLine();
                    READ_LIST_RECURSIVE(ODEV_1_HOCANIN_COZUMU(CREATE_LIST()));
                    Console.WriteLine();
                    READ_LIST_RECURSIVE(ODEV_1_RECURSIVE(CREATE_LIST(), 1));
                    Console.WriteLine();
                    READ_LIST_RECURSIVE(ODEV_3(CREATE_LIST()));
                    Console.WriteLine();
                    READ_LIST_RECURSIVE(ODEV_4(CREATE_LIST()));
                    Console.WriteLine();
                    READ_LIST_RECURSIVE(ODEV_4_RECURSIVE(CREATE_LIST()));
                    Console.WriteLine();
                    READ_LIST(CREATE_DLL());
                    Console.WriteLine();
                    READ_LIST_REVERSE(CREATE_DLL());
                    Console.WriteLine();

                } //AŞAĞIDA YAZILAN METHODLARI ÇAĞIRAN ANA METHOD

                static Block CREATE_LIST()
                {
                    Block head = new Block();
                    head.data = 1;
                    Block tmp = head;

                    for (int i = 2; i <= 10; i++)
                    {
                        Block newNode = new Block(); // [newnode]  [head.data=1]
                        newNode.data = i;            // [newnode.data = i(2)]
                        tmp.next = newNode;         // [head.data=1] -> [newnode.data =2]
                        tmp = newNode;              // [1] -> [head.data=2]  // [2] -> [head.data=3] 
                    }
                    return head;
                }
                //listenin eleman sayısını bul + recursive
                //bu listenin içerisindeki 7 olanları delete ediniz

                static void READ_LIST(Block head)
                {
                    Block temp = head;
                    if (temp == null) return;
                    Console.WriteLine("head'in datası = " + temp.data);
                    while (temp != null)
                    {
                        Console.Write(temp.data + " ");
                        temp = temp.next;
                    }
                }
                static Block READ_LIST_RECURSIVE(Block node)
                {
                    if (node == null) return null;
                    Console.Write(node.data + " ");
                    return READ_LIST_RECURSIVE(node.next);
                }
                static Block ADD_RECORD_BEFORE_HEAD(Block head, int data)
                {
                    Block newNode = new Block();
                    newNode.data = data;
                    if (head == null) return newNode; //eğer gelen head boşsa newNode head olur
                    newNode.next = head; // newNode nexti head olur
                    head = newNode; // yeni head newNode olur
                    return head;
                }
                static Block ADD_TO_LIST_1(Block head, int data)
                {
                    Block newNode = new Block();
                    newNode.data = data;//                  [ 7 ]->[ 8 ]->[ 9 ]->[ 10 ]->[null]
                    if (head == null) return newNode;//                           temp
                    Block temp = head;
                    while (temp.next != null)//temp.next kontrol edilir
                    {
                        temp = temp.next;
                    }
                    temp.next = newNode;
                    return head;
                }
                static Block DELETE_HEAD(Block head)
                {
                    if (head == null) return null;
                    head = head.next; // head bir sonraki elemana kayar
                    return head;
                }
                static Block DELETE_LAST_ITEM_1(Block head)
                {   //eğer liste boşsa veya tek elemanlıysa çalışır ama sıkıntı
                    if (head == null) return null;//   [7]->[8]->[9]->[10]->[null]
                    if (head.next == null) return null;//       temp 
                    Block temp = head;//                  
                    while (temp.next.next != null)
                    {
                        temp = temp.next;
                    }
                    temp.next = null;
                    return head;
                }
                static Block ODEV_1(Block head)//baştan itibaren 4.bloktan sonra değeri 999 olan block ekle
                {
                    if (head == null) return null;//      [newNode]  
                    Block newNode = new Block();//      [7]->[8]->[9]->[10]->[null]
                    newNode.data = 999;//              temp
                    Block temp = head;
                    int sayac = 1;
                    while (temp != null)
                    {
                        if (sayac == 4)
                        {
                            newNode.next = temp.next;
                            temp.next = newNode;
                            break;
                        }
                        temp = temp.next;
                        sayac++;
                    }
                    return head;
                }
                static Block ODEV_1_HOCANIN_COZUMU(Block head)//baştan itibaren 4.bloktan sonra değeri 999 olan block ekle
                {
                    Block temp = head;
                    int sayac = 0;
                    while (sayac < 4)
                    {
                        temp = temp.next;
                        sayac++;
                    }
                    Block newNode = new Block();
                    newNode.data = 999;
                    newNode.next = temp.next;
                    temp.next = newNode;
                    return head;
                }
                static Block ODEV_1_RECURSIVE(Block head, int sayac)
                {
                    if (head == null) return null;
                    if (sayac == 4)
                    {
                        Block newNode = new Block();
                        newNode.data = 999;
                        newNode.next = head.next;
                        head.next = newNode;
                        return head;//bu olmasa da çalışır ama işlev yerine getirilince erkenden cıkmak için lazım
                    }
                    ODEV_1_RECURSIVE(head.next, sayac + 1);
                    return head;
                }
                static Block ODEV_2(Block head)// sondan 4.bloğu sil
                {
                    //sondan 4 demek aslında baştan n-4+1 demektir
                    //list uzunlugu n ise baştan n-3.düğüm silinir
                    if (head == null) return null;  //   [5]->[6]->[7]->[8]->[9]->[10]->[null]
                    int length = 0;
                    Block temp = head;
                    while (temp != null)
                    {
                        length++;
                        temp = temp.next;
                    }
                    if (length < 4) return head; //length 4ten küçükse silinecek birşey yok
                    int targetIndex = length - 4;
                    temp = head;
                    for (int i = 0; i < targetIndex - 1; i++)
                    {
                        temp = temp.next;
                    }
                    temp.next = temp.next.next;
                    return head;
                }
                static Block ODEV_3(Block head)//data değeri 7 olan bloktan sonra data değeri -1 olan blok ekle
                {
                    if (head == null) return null;//   [5]->[6]->[7]->[8]->[9]->[10]->[null]
                    Block temp = head;
                    while (temp != null)
                    {
                        if (temp.data == 7)
                        {
                            Block newNode = new Block();
                            newNode.data = -1;
                            newNode.next = temp.next;
                            temp.next = newNode;
                            //break; -> denirse ilk 7de bu işi yapar diğer data değeri 7 olanlarda yapmaz direk döngüdençıkar
                        }
                        temp = temp.next;
                    }
                    return head;
                }
                static Block ODEV_4(Block head)//data değeri 7 olan bloktan önce data değeri 99 olan blok ekle
                {
                    if (head == null) return null;
                    if (head.data == 7)
                    {
                        Block newNode = new Block();
                        newNode.data = 99;
                        newNode.next = head;
                        head = newNode;
                        return head;
                    }//                                          temp
                    Block temp = head;//                     [5]->[6]->[7]->[8]->[9]->[10]->[null]

                    while (temp != null && temp.next != null) //dikkat önemli ikinci şart olmazsa NullReferenceException veriyor
                    {
                        if (temp.next.data == 7)
                        {
                            Block newNode = new Block();
                            newNode.data = 99;
                            newNode.next = temp.next;
                            temp.next = newNode;
                            break; // !sadece ilk 7den önce ekler! diğer datası 7 olan bloklara bakmaz
                        }
                        temp = temp.next;
                    }
                    return head;
                }
                static Block ODEV_4_RECURSIVE(Block head)
                {
                    if (head == null) return null;
                    if (head.data == 7)
                    {
                        Block newNode = new Block();
                        newNode.data = 99;
                        newNode.next = head;
                        head = newNode;
                    }
                    if (head.next.data == 7 && head.next != null)
                    {
                        Block newNode = new Block();
                        newNode.data = 99;
                        newNode.next = head.next;
                        head.next = newNode;
                        return head;
                    }
                    head.next = ODEV_4_RECURSIVE(head.next);
                    return head;
                }
                static Block CREATE_DLL()
                {
                    Block head = null;
                    Block last = null;

                    for (int i = 0; i < 10; i++)
                    {
                        Block newNode = new Block();
                        newNode.data = i;
                        if (head == null)
                        {
                            head = newNode;
                            last = newNode;
                        }
                        else
                        {
                            last.next = newNode;
                            newNode.prev = last;
                            last = newNode;
                        }
                    }

                    return head;
                }
                static void READ_LIST_REVERSE(Block head)
                {
                    if (head == null) return;
                    Block temp = head;//                                   temp
                    while (temp.next != null)//   [5]->[6]->[7]->[8]->[9]->[10]->[null]
                    {
                        temp = temp.next;
                    }
                    while (temp != null)
                    {
                        Console.Write(temp.data + " ");
                        temp = temp.prev;
                    }
                }


                calıstırH6_1();
            }
            static void hafta6_2() //DLL circular
            {
                READ_DLL(CREATE_DLL());                      bosluk();
                READ_DLL_RECURSIVE(CREATE_DLL());            bosluk();
                READ_DLL_REVERSE_RECURSIVE(CREATE_DLL());    bosluk();

                static void READ_DLL(Block head)
                {
                    if (head == null) return;
                    Block temp = head;//                                   temp
                    while (temp != null)//   [5]->[6]->[7]->[8]->[9]->[10]->[null]
                    {
                        Console.Write(temp.data + " ");
                        temp = temp.next;
                    }
                }
                static Block READ_DLL_RECURSIVE(Block node)
                {
                    if (node == null) return null;
                    Console.Write(node.data + " ");
                    return READ_DLL_RECURSIVE(node.next);
                }
                static void READ_DLL_REVERSE_RECURSIVE(Block temp)
                {
                    if (temp == null) return;
                    READ_DLL_REVERSE_RECURSIVE(temp.next);
                    Console.Write(temp.data);
                }
                static Block CREATE_DLL()
                {
                    Block head = null;
                    Block last = null;

                    for (int i = 0; i < 15; i++)
                    {
                        Block newNode = new Block();
                        newNode.data = i;
                        if (head == null)
                        {
                            head = newNode;
                            last = newNode;
                        }
                        else
                        {
                            newNode.prev = last;
                            last.next = newNode;//    [5]->[6]->[7]->[8]->[9]->[10]->[newNode]
                            last = newNode;
                        }
                    }
                    return head;
                }
            }
        }

        #endregion
        #region HAFTA 7 - DOUBLE LINKED LIST - STACKS
        static void HAFTA7_1()// Double linked lists
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

            READ_DLL(CREATE_DLL());                                     bosluk();
            READ_DLL_RECURSIVE(CREATE_DLL());                                bosluk();
            READ_DLL_REVERSE_RECURSIVE(CREATE_DLL());                        bosluk();
            READ_DLL_RECURSIVE(ADD_BLOCK_BEFORE_HEAD(CREATE_DLL(),31));           bosluk();
            READ_DLL_RECURSIVE(ADD_BLOCK_AFTER_LAST(CREATE_DLL(),31));          bosluk();
            READ_DLL(ADD_BLOCK_AFTER_3rd(CREATE_DLL(),99 ));                    bosluk();
            READ_DLL(ADD_BLOCK_AFTER_3rd_FROM_THE_END(CREATE_DLL(), 99));        bosluk();
            READ_DLL(ADD_BLOCK_AFTER_BLOCK_VALUE_EQUAL(CREATE_DLL(), 2,99)); bosluk();
            READ_DLL(ADD_BLOCK_BEFORE_BLOCK_VALUE_EQUAL(CREATE_DLL(), 2, 99)); bosluk();

            static void READ_DLL(Block head)
            {
                if (head == null) return;
                Block temp = head;//                                   temp
                while (temp != null)//   [5]->[6]->[7]->[8]->[9]->[10]->[null]
                {
                    Console.Write(temp.data + " ");
                    temp = temp.next;
                }
            }
            static Block READ_DLL_RECURSIVE(Block node)
            {
                if (node == null) return null;
                Console.Write(node.data + " ");
                return READ_DLL_RECURSIVE(node.next);
            }
            static void READ_DLL_REVERSE_RECURSIVE(Block temp)
            {
                if (temp == null) return;
                READ_DLL_REVERSE_RECURSIVE(temp.next);
                Console.Write(temp.data);
            }
            static Block CREATE_DLL()
            {
                Block head = null;
                Block last = null;

                for (int i = 0; i < 15; i++)
                {
                    Block newNode = new Block();
                    newNode.data = i;
                    newNode.next = null;
                    newNode.prev = null;
                    if (head == null)
                    {
                        head = last =newNode; // head=newNode last=newNode
                    }
                    else
                    {
                        last.next= newNode;
                        newNode.prev = last;//    [5]->[6]->[7]->[8]->[9]->[10]->[newNode]
                        last = newNode;
                    }
                }
                Console.Write("CREATED_DLL ");
                return head;
            }
            static Block ADD_BLOCK_BEFORE_HEAD(Block head,int data)
            {
                Block newNode =new Block();
                newNode.data = data;
                newNode.prev = null;

                if(head == null)
                {
                    newNode .next = null;
                    head = newNode;
                }
                newNode.next = head;
                head.prev=newNode;
                head=newNode; Console.Write("ADDED_BLOCK_BEFORE_HEAD -> ");
                return head;
            }
            static Block ADD_BLOCK_AFTER_LAST(Block head,int data)
            {
                Block newNode = new Block();
                newNode.data = data;
                newNode.next = null;
                if (head == null)
                {
                    newNode.prev = null;
                    head = newNode;
                    return head;
                }
                Block temp = head;//                                 temp
                while (temp.next != null)//   [5]->[6]->[7]->[8]->[9]->[10]->[null]
                { 
                    temp = temp.next;
                }
                newNode.prev= temp;
                temp.next= newNode;
                temp = newNode; Console.Write("ADDED_BLOCK_AFTER_LAST -> ");
                return head;
            }
            static Block ADD_BLOCK_AFTER_3rd(Block head,int data)
            {
                if (head == null) return null;
                 
                Block temp = head;//                    temp
                for(int i = 1; i < 3; i++)//   [1]->[2]->[3]->[4]->[5]->[6]->[null]
                {
                    if (temp.next == null) return head;
                    temp=temp.next;
                }

                Block newNode = new Block();
                newNode.data = data;

                newNode.prev= temp;
                newNode.next = temp.next;
                temp.next = newNode;
                if (temp.next != null)
                {
                    temp.next.prev = newNode;
                }
                return head;

            }
            static Block ADD_BLOCK_AFTER_3rd_FROM_THE_END(Block head,int data)
            {
                // 1 2 3 4 5 6 7 sondan 3 demek "5" demek eleman sayısı n = 7
                // 7-3 = 4 + 1 istenen index yani n - 3 +1 = n -2 . indexi isitoyruz
                if(head==null) return null;
                Block temp = head;
                int length = 0;
                while (temp != null)
                {
                    length++; temp = temp.next;
                }
                int hedefIndex = length - 2;
                temp = head;
                for(int i = 1; i < hedefIndex; i++)
                {
                    temp = temp.next;
                }
                Block newNode = new Block();
                newNode.data = data;

                newNode.prev = temp;
                newNode.next = temp.next;
                temp.next = newNode;
                if (temp.next != null)
                {
                    temp.next.prev = newNode;

                }
                return head;
            }
            static Block ADD_BLOCK_AFTER_BLOCK_VALUE_EQUAL(Block head,int value,int data)
            {
                if (head == null) return null;
                Block temp = head;//                temp
                while (temp!=null && temp.data != value)//   [1]->[2]->[3]->[4]->[5]->[6]->[null]
                {
                    temp = temp.next;
                }
                if(temp==null) return head; // value bulunamadıysa headi döndür
                Block newNode = new Block();
                newNode.data = data;

                newNode.next= temp.next;
                newNode.prev = temp;
                temp.next = newNode;
                if (temp.next != null) temp.next.prev = newNode;

                return head;
            }
            static Block ADD_BLOCK_BEFORE_BLOCK_VALUE_EQUAL(Block head, int value, int data)
            {
                if(head==null) return null; 
                Block temp = head;//                          temp
                while(temp!=null && temp.data != value)//     [1]->[2]->[3]->[4]->[5]->[6]->[null] 
                {
                    temp = temp.next;
                }
                if(temp==null) return head; // value bulunamadı 

                Block newNode =new Block();
                newNode.data = data;

                newNode.next = temp;
                newNode.prev = temp.prev;
                if (temp.prev == null)
                {
                    head = newNode;
                }
                else
                {
                    temp.prev.next = newNode;
                }
                temp.prev = newNode;

                return head;
            }
        }
        #endregion
        #region HAFTA 8 - STACKS and INFIX
        static void HAFTA8_1()//DLL OPERATIONS
        {
            #region - DLL ATİLLA ÖRNEKLER -
            /*
            first listede herhangi bir elemana bakmaktadır listenin sizeını bul
             */
            #endregion
            bosluk();
            
            READ_DLL_RECURSIVE(CREATE_DLL(20));                  bosluk();
            Console.WriteLine("size = "+
                GET_DLL_SIZE_RECURSIVE(CREATE_DLL(20))
                );                                         
            Console.WriteLine("size = "+
                GET_DLL_SIZE_ITERATIVE(CREATE_DLL(20))
                );
            Console.WriteLine(
                IS_IN_DLL(CREATE_DLL(20),1)
               );
            Console.WriteLine(
                "dll içinde 2 -> "+
                COUNT_ON_OCCURRENCES_IN_DLL_ITERATIVE(CREATE_DLL(21),2)
                +"  kere geçmiştir");
            Console.WriteLine(
                "dll içinde 2 -> " +
                COUNT_ON_OCCURRENCES_IN_DLL_RECURSIVE(CREATE_DLL(21), 2)
                + "  kere geçmiştir");

            Block head = CREATE_DLL(10);
            ders4_iterative(head.next.next.next);
            Console.WriteLine(
                ders4_recursive(head.next.next.next, 0)
                );


            static Block CREATE_DLL(int size)
            {
                Block head = null;
                Block last = null;

                for (int i = 0; i < size; i++)
                {
                    Block newNode = new Block();
                    newNode.data = i;
                    newNode.next = null;
                    newNode.prev = null;
                    if (head == null)
                    {
                        head = last = newNode; // head=newNode last=newNode
                    }
                    else
                    {
                        last.next = newNode;
                        newNode.prev = last;//    [5]->[6]->[7]->[8]->[9]->[10]->[newNode]
                        last = newNode;
                    }
                }
                Console.Write("CREATED_DLL ");
                return head;
            }
            static Block CREATE_DLL_RECURSIVE(int size)
            {
                if (size <= 0) return null;
                Block newNode = new Block();
                newNode.data = rnd.Next(0, 100);
                newNode.next = CREATE_DLL_RECURSIVE(size - 1);
                if (newNode.next != null)
                {
                    newNode.next.prev = newNode;
                }
                return newNode;

            }
            static void READ_DLL_RECURSIVE(Block head)
            {
                if (head == null) return;
                Console.Write(head.data+" ");
                READ_DLL_RECURSIVE(head.next);
            }
            static int GET_DLL_SIZE_ITERATIVE(Block head)
            {
                if (head == null) return 0;
                Block temp = head;
                int count = 0;
                while (temp != null)
                {
                    count++;
                    temp = temp.next;
                }
                return count;
            }
            static int GET_DLL_SIZE_RECURSIVE(Block head) //geri dönüş veri tipi integer !
            {
                if(head == null) return 0;
                if(head.next == head) return 1; // circular LL ise 1 döner
                return 1+ GET_DLL_SIZE_RECURSIVE(head.next);
            }
            static bool IS_IN_DLL(Block head,int value)
            {
                if (head == null) return false;
                Block temp = head;
                while (temp != null)
                {
                    if(temp.data == value)
                    {
                        return true;
                    }
                    temp = temp.next;
                }
                return false;
            }
            static bool IS_IN_DLL_RECURSIVE(Block head, int value)
            {
                if(head == null) return false;
                if(head.data == value) return true;
                return IS_IN_DLL_RECURSIVE(head.next, value);
            }
            static int COUNT_ON_OCCURRENCES_IN_DLL_ITERATIVE(Block head, int value)
            {
                if(head ==null) return 0;
                Block temp = head; int count = 0;
                while (temp != null)
                {
                    if (temp.data == value) //daha optimize
                        count++;
                    temp=temp.next;
                    /*
                    if (temp.data == value)  fena değil çalışır
                    {
                        count++;
                        temp = temp.next;
                    }
                    else
                    {
                        temp=temp.next;
                    }
                     */
                }
                return count;
            }// !ÇIKAR!
            static int COUNT_ON_OCCURRENCES_IN_DLL_RECURSIVE(Block head, int value)
            {
                if(head == null) return 0;
                if (head.data == value)
                    return 1 + COUNT_ON_OCCURRENCES_IN_DLL_RECURSIVE(head.next, value);
                else
                    return COUNT_ON_OCCURRENCES_IN_DLL_RECURSIVE(head.next, value);
            }// !ÇIKAR!
            static void ders4_iterative(Block temp)
            {
                int yon = 0; //                                             temp
                while (temp.prev != null)//  dll        [1]-[2]-[3]-[4]-[5]-[6]
                {
                    temp = temp.prev;
                }
                yon = 1;   // !
                while (temp.next != null)
                {
                    yon++;
                    temp = temp.next;
                }
                Console.WriteLine(yon);
            }
            static int ders4_recursive(Block temp,int yon)
            {
                if(temp == null) return 0;//  dll     [1]-[2]-[3]-[4]-[5]-[6]
                if (yon == 0)//                       temp
                {
                    if (temp.prev == null)
                    {
                        yon = 1;
                    }
                    else
                    {
                        temp = temp.prev;
                    }
                }
                else
                {
                    temp = temp.next; 
                }//                             en sola gitti soldan sağa saydı 
                return yon+ ders4_recursive(temp, yon); //0 + 0 + 0 + 1 + 1 + 1 + 1 + 1 + 1 + 1 = 7
            }// !ÇIKAR!
        }
        static void HAFTA8_2()//STACK METOTLARI
        {

            #region - STACKS NOTES -
            /*  stacklar konusu veri yapılarının diziyle düşünme becerisini pointer mantığına dönüştürme noktasıdır. gelişmiş veri yapısıdır SON GELEN İLK ÇIKAR yani LAST İN FİRS OUT (LİFO) prensibiyle çalışır. PUSH POP PEEK temel işlemleri içerir. matematiksel ifadeler stack ile çözülür. 
             *  push -> yığına eleman ekler
             *  pop -> yığından en üstteki elemanı cıkarır
             *  peek -> yığının en üstteki elemanını döndürür ama yığından çıkarmaz
             *  isEmpty -> yığının boş olup olmadığını kontrol eder
             *  isFull -> yığının dolu olup olmadığını kontrol eder
             *  
             *  hafızanın bir bölümünde 4 bytelık bir bölüm olusur
             */
            #endregion
            #region - STACKS ATİLLA ÖRNEKLER -
            /*
             * Stack kullanarak bilgisayar dizinlerini terminalde yazdıran kod
             * stack kullanarak 0 ve 1 lerden oluşan bir matristeki 1 lerin sayısını bulma. en çok 1 bulundurak grubu bulma
             */
            #endregion
            #region - STACK METOTLARI arr -
            static void push(int value)
            {
                if (sp == mainStack.Length - 1)
                {
                    Console.WriteLine("Stack overflow");
                    return;
                }
                mainStack[++sp] = value;
            }
            static int pop()
            {
                if (sp == -1)
                {
                    Console.WriteLine("Stack underflow");
                    return -1;
                }
                return mainStack[sp--];
            }
            static int peek()
            {
                return mainStack[sp];
            }
            #endregion
            #region - STACK METOTLARI linked -
            static void pushll(int data)
            {
                Block newBlock = new Block();
                newBlock.data = data;
                newBlock.next = spll;
                spll=newBlock;
            }
            static int popll()
            {
                if (spll == null){Console.WriteLine("StaSck underflow"); return -1;}
                int returnData = spll.data;
                spll = spll.next;
                return returnData;
            }
            static int peekll()
            {
                return spll.data;
            }
            #endregion
            /*
               A-B+C+D+F*H
               infix = ((A-B)+C+D+(F*H))
               postfix = AB-CD+FH*+
               prefix = -AB+CD+*FH -> -++*ABCDFH

               A+B*C
               postfix = ABC*+
               prefix = *+ABC

               (A+B)*C
               postfix = AB+C*
               prefix =  *+ABC

               (A+B)*(C-D)
               postfix = (AB+)*(CD-) -> AB+CD-*
               prefix = (+AB)*(-CD) -> *(+AB)(-CD)
            */
            static void örn1()//Verilen stringin palindromik olup olmadığını stacklar yardımı ile bulunuz
            {
                string str = "abba";
                int hata = 0;
                for (int i = 0; i < str.Length; i++)
                {
                    push(str[i]);
                }
                for (int i = 0; i < str.Length; i++)
                {
                    if (pop() != str[i])
                    {
                        hata = 1; break;
                    }
                }
                if (hata == 0) { Console.WriteLine("palindromik"); }
                else { Console.WriteLine("Palindromik değil"); }
            }örn1();
            static void örn2()//Açık parantezi kapatma sorusunu stack yardımı ile çözünüz
            {
                string st = "{g{[s(((f))h)d]}}";
                int hata = 0;
                string sol = "([{";
                string sağ = ")]}";
                for (int i = 0; i < st.Length; i++)
                {
                    int ind = sol.IndexOf(st[i]);
                    if (ind != -1)
                    {
                        push(sağ[ind]);
                    }
                    else
                    {
                        ind = sağ.IndexOf(st[i]);
                        if (ind != -1)
                        {
                            if (pop() != st[i])
                            {
                                hata = 1;
                                break;
                            }
                        }
                    }
                }
                if (hata == 0) { Console.WriteLine("Hatasız"); }
                else { Console.WriteLine("Hatalı"); }
            }örn2();
            static void örn3()//Infix'ten Postfix'e dönüşüm ve Postfix ifadenin sayısal değeri 
            {
                string infix = "a+b*c/d-e";
                string postfix = "";
                string op = "$-+/*()";
                int[] once = { 0, 1, 1, 2, 2 };
                push((byte)'$');
                for (int i = 0; i < infix.Length; i++)
                {
                    if (op.IndexOf(infix[i]) == -1)
                    {
                        while (op.IndexOf(infix[i]) == -1)
                        {
                            postfix += infix[i++];
                        }
                        continue;
                    }
                    if (infix[i] == '(')
                    {
                        while (peek() != (byte)'(')
                        {
                            postfix += (char)pop();
                        }
                        pop();
                        continue;
                    }
                    int a = peek();
                    if (once[op.IndexOf(infix[i])] > once[op.IndexOf((char)a)])
                    {
                        push(infix[i]);
                    }
                    else
                    {
                        postfix += (char)pop();
                    }
                }
                while (peek() != (byte)'$')
                {
                    postfix += (char)pop();
                }
                Console.WriteLine(postfix);
            }
        }
        #endregion
        #region -VİZE ÖRNEKLERİ-
        static void VİZE_ÖRNEKLER_ÇIKMIŞLAR()
        {
            static void orn1()
            {
                /*İnt[,,,] x= new int[2,4,5,6] , int[] y = new int[240]; x dizisinin elemanlarını y dizisine aktarınız.Ram’de nasıl saklanıyorsa o şekilde aktarmalısınız. X dizisinin ramdeki dizilişi ile Y’nin dizilişi aynı olmalıdır. (diziler)
                2023-2024 mazeret*/
                int[,,,] xArr = new int[2, 4, 5, 6];
                filluparr(xArr);
                int[] yArr = new int[240];
                int indexY = 0;
                for (int i =0;i<2;i++)
                    for(int j=0;j<4;j++)
                        for(int k=0;k<5;k++)
                            for(int l = 0; l < 6; l++)
                            {
                                yArr[indexY] = xArr[i, j, k, l];
                                indexY++;
                            }
                /*istenen kod buraya kadar aşağısı kodun calıstıgını göstermek için yazıldı*/
                foreach (var item in yArr)
                {
                    Console.Write(item + " ");
                }
                static void filluparr(int[,,,] arr)
                {
                    for (int i = 0; i < 2; i++)
                        for (int j = 0; j < 4; j++)
                            for (int k = 0; k < 5; k++)
                                for (int l = 0; l < 6; l++)
                                    arr[i, j, k, l] = rnd.Next(0, 100);
                }
                Console.WriteLine();
            }orn1();

            static void orn2()
            {
                /*Xx*y+ab-/xy*+a-b+; postfix notasyonunda int x = 2; int y =3; int a =2;,int b = 1; değerleri içinsonucu hesaplaynıız. İşlem adımlarını detaylı gsöteriniz kod yazılmayacaktır.(postfix)
                 2023-2024 mazeret*/
                // XX*Y+AB-/XY*+A-B+ = ((X*X)+Y)/(A-B)+(X*Y)-A+B  !! dikkatli çözülmesi gerekiyor
                int x = 2; int y = 3; int a = 2; int b = 1;
                int cevap = (((x * x) + y) / (a - b)) + (x * y) - a + b;
                Console.WriteLine(cevap); //12
            }orn2();
            static void orn3()
            {
                /*C sürücüsünün dersler dizininn içerisinde bulunan tüm alt dizinleri ekrana yazdıran kodu yazınız işlem için Directory.GetDirectories(@path); metodunu kullanınız. (stack kod)
                 2023-2024 mazeret
                 */
                Stack<string> st = new Stack<string>();
                st.Push(@"C:\");
                while (st.Count > 0)
                {
                    string path = st.Pop();
                    string[] dirs = Directory.GetDirectories(path);
                    for (int i = 0; i < dirs.Length; i++)
                    {
                        Console.WriteLine(dirs[i]);
                        st.Push(dirs[i]);
                    }
                }
            }
            static void orn4()
            {
                /*Önceden oluşturulmuş 2 adet çiftli linked list yapısının data olarak integer kullanılmaktadır. Bu
                listelerin ilk elemanları head ve first bloklarıdır. Bu 2 bağlı listede ortak sayılar mevcuttur .
                Ortak sayılar her 2 listede de birden fazla olabilir . Sayının ortak olması için diğer 2
                listede de olması şarttır. Aynı listede birden fazla olup diğer listede olmazsa ortak
                sayılmayacaktır. Bu listelerde ortak olarak 2 defa bulunan sayıların adedini
                bulunuz.(linkedlist) 2021 final*/
                Block list1 = DLL_CREATE();
                Block list2 = DLL_CREATE();
                DLL_READ(list1); DLL_READ(list2);
                orn4_code(list1,list2);
                /*istenen kod burdan başlar*/
                static void orn4_code(Block list1,Block list2)
                {
                    Block temp = list2;
                    int defa;
                    int count = 0;
                    if (list1 == null || list2 == null) Console.WriteLine("listeboş! ");
                    while (list1 != null)
                    {
                        temp = list2;
                        defa = 0;
                        while (temp != null)
                        {
                            if (list1.data == temp.data)
                            {
                                defa++;
                                if (defa == 2)
                                {
                                    count++;
                                }
                            }
                            temp = temp.next;
                        }
                        list1 = list1.next;
                    }
                    Console.WriteLine("cevap -> " + count);
                }
                /*istenen kod buraya kadar*/
                
                static Block DLL_CREATE()
                {
                    Block head = new Block();
                    Block temp = head;
                    for (int i = 0; i < 15; i++)
                    {
                        Block newNode = new Block();
                        newNode.data = rnd.Next(0, 5);
                        temp.next = newNode;
                        newNode.prev = temp;
                        temp= newNode;
                    }
                    return head;
                }
                static void DLL_READ(Block temp)
                {
                    while (temp != null) { Console.Write(temp.data); temp = temp.next;}
                    Console.WriteLine();
                }

            }orn4();
            static void orn5()
            {
                /*Data ve link 100er elemanlı int tipinde 2 dizidir. Data dizsinde sayılar vardır. Link dizisinde data
                dizisinin indisleri mevcuttur . Bu sayede lnik dizisi ile data dizisi üzerinde bağlı liste yapısı
                oluşturulmuştur. Bağlı listenin ilk elemanı data dizisniin 70. Elemanıdır . Bu listenin tüm
                elemanlarını sırayla ekrana recuersive olarak yazdırınız. 70ten sonra gelen eleman link[70] ile
                alınacak ve bu şekilde devam edecektir. (linkedlist)*/
                int[] data = new int[100];
                int[] link = new int[100];
                fill_arrays(data,link);
                orn5_code_itterative(data, link); bosluk();
                //istenen kod burdan başlars
                static void orn5_code_recursive(int[] Data, int[] Link, int index)
                {
                    if (index == -1) return;            // liste bitti

                    Console.Write(Data[index] + " ");   // o indexteki datayı yaz

                    orn5_code_recursive(Data, Link, Link[index]); // sıradaki index'i çağır
                }
                static void orn5_code_itterative(int[] data, int[] link)
                {
                    int index = 70; // listenin ilk elemanı
                    while(index != -1)
                    {
                        Console.WriteLine(data[index] + " ");
                        index = link[index];
                    }
                }
                //istenen kod buraya kadar
                static void fill_arrays(int[] data, int[] link)
                {
                    for (int i = 0; i < 100; i++)
                    {
                        data[i] = rnd.Next(0, 100);
                        link[i] = rnd.Next(-1, 100);
                    }
                    link[99] = -1; // son eleman -1 yapıldı
                }
            }
            static void orn6()
            {
                //  ABACD/+/C*+BD*-  a=1 b=12 c=4 s=2
                // A+((B/A)+(C/D)*C)-(B*D)
                int A = 1; int B = 12; int C = 4; int D = 2;
                int cevap = A + ((B / A) + (C / D) * C) - (B * D);
                Console.WriteLine(cevap);
            }orn6();
            static void orn7()
            {
                //int[,,,,,,,,,] x = [10,10,10,10,10,10,10,10,10,10] recursive toplamı
                int[,,,,,,,,,] x = new int[10, 10, 10, 10, 10, 10, 10, 10, 10, 10];
                fillarray(x);
                int[] idx = new int[10];    
                Console.WriteLine(SumRecursive(x,idx,0));
                static long SumRecursive(int[,,,,,,,,,] arr, int[] idx, int depth)
                {
                    // depth son boyut indexine ulaştıysa
                    if (depth == 10)
                    {
                        return arr[idx[0], idx[1], idx[2], idx[3],
                                    idx[4], idx[5], idx[6], idx[7],
                                    idx[8], idx[9]];
                    }

                    long sum = 0;
                    for (int i = 0; i < 10; i++)
                    {
                        idx[depth] = i;
                        sum += SumRecursive(arr, idx, depth + 1);
                    }
                    return sum;
                }
                static void fillarray(int[,,,,,,,,,] arr) 
                {
                    for(int i0=0;i0<10;i0++)
                        for(int i1=0;i1<10;i1++)
                            for(int i2=0;i2<10;i2++)
                                for(int i3=0;i3<10;i3++)
                                    for(int i4=0;i4<10;i4++)
                                        for(int i5=0;i5<10;i5++)
                                            for(int i6=0;i6<10;i6++)
                                                for(int i7=0;i7<10;i7++)
                                                    for(int i8=0;i8<10;i8++)
                                                        for(int i9=0;i9<10;i9++)
                                                            arr[i0,i1,i2,i3,i4,i5,i6,i7,i8,i9]= rnd.Next(0,10);
                }
            }
            static void orn8()
            {
                // 5 boyutlu dizi summ recursive
                int[,,,,] x = new int[4, 6, 5, 3, 2];
                int[] dimension = new int[5];

                fillarray(x);
                Console.WriteLine(sumRec(x, dimension,0));
                static int sumRec(int[,,,,] arr,int[] dimension,int depth)
                {
                    if (depth == 5)
                    {
                        return arr[dimension[0], dimension[1], dimension[2], dimension[3], dimension[4]];
                    }
                    int sum = 0;
                    for(int i = 0; i < arr.GetLength(depth); i++)
                    {
                        dimension[depth] = i;
                        sum += sumRec(arr, dimension, depth + 1);
                    }
                    return sum;
                }

                static void fillarray(int[,,,,]arr)
                {
                    for(int i0=0;i0<4;i0++)
                        for(int i1=0;i1<6;i1++)
                            for(int i2=0;i2<5;i2++)
                                for(int i3=0;i3<3;i3++)
                                    for(int i4=0;i4<2;i4++)
                                        arr[i0,i1,i2,i3,i4]= rnd.Next(0,10);
                }
            }orn8();
            static void orn9()
            {
                // tüm elemanlarını recursvie topla yan metod
                int[,]x = new int[10, 100];
                static int sumRec(int[,]arr,int column , int row)
                {
                    if (column == arr.GetLength(0)) // satır sonu
                    {
                        return 0;
                    }
                    if (row == arr.GetLength(1)) // sütun sonu
                    {
                        return sumRec(arr, column + 1, 0);
                    }
                    return arr[column, row] + sumRec(arr, column, row + 1);
                }
                static void fillarray(int[,] arr)
                {
                    for (int i0 = 0; i0 < 10; i0++)
                        for (int i1 = 0; i1 < 100; i1++)
                            arr[i0, i1] = rnd.Next(0, 10);
                }
            }
        }
        #endregion
        #region HAFTA 10 - STACKS and INFIX-POSTFIX-PREFIX
        static void H10()
        {
            //infix → postfix dönüşümü - çözüm 0 ÖNEMLİ KAVRAMAK LAZIM
            static void inf_to_postf_0()
            {
                Console.WriteLine("beklenen: ababc*-d+*+fg/-   ");
                Stack<char> st = new Stack<char>();
                string infix = "a+b*(a-b*c+d)-f/g";
                string postfix = "";

                int Priority(char op)
                {
                    if (op == '+' || op == '-') return 1;
                    if (op == '*' || op == '/') return 2;
                    return 0;
                }

                foreach (char c in infix)
                {
                    // Operand
                    if (char.IsLetterOrDigit(c))
                    {
                        postfix += c;
                    }
                    // Açık parantez
                    else if (c == '(')
                    {
                        st.Push(c);
                    }
                    // Kapalı parantez
                    else if (c == ')')
                    {
                        while (st.Peek() != '(')
                            postfix += st.Pop();
                        st.Pop(); // '(' çıkar
                    }
                    // Operatör
                    else
                    {
                        while (st.Count > 0 && Priority(st.Peek()) >= Priority(c))
                            postfix += st.Pop();
                        st.Push(c);
                    }
                }

                // Stack’te kalan operatörler
                while (st.Count > 0)
                    postfix += st.Pop();

                Console.WriteLine("cevap:   "+postfix);
            }inf_to_postf_0();

            // infix → postfix dönüşümü -çözüm 1  ÖNEMLİ KAVRAMAK LAZIM
            static void inf_to_postf_1()
            {
                Stack<string> st = new Stack<string>();
                string infix = "a+b*(a-b*c+d)-f/g"; Console.WriteLine("beklenen: ababc*-d+*+fg/-");
                string postfix = "";
                string chars = "$(+-*/)";
                string priority = "001122";

                for (int i = 0; i < infix.Length; i++)
                {
                    int index = chars.IndexOf(infix[i]);

                    if (index == -1)// operand
                    {
                        postfix = postfix + infix[i];
                        continue;
                    }
                    if (index == 1)// " ( "
                    {
                        st.Push("(");
                        continue;
                    }
                    if (index == 6)// " ) "
                    {
                        while(st.Peek() !="(")
                        {
                            postfix = postfix + st.Pop();
                        }
                        st.Pop();
                        continue;
                    }
                    while (st.Count > 0 &&
                        st.Peek()!="(" &&
                        priority[chars.IndexOf(st.Peek())] >= priority[index]
                        )// operatör
                    {
                        postfix = postfix + st.Pop();
                    }
                    st.Push(infix[i].ToString());
                }
                while (st.Count > 0)// stackte kalan operatörler
                {
                    postfix = postfix + st.Pop();
                }
                Console.WriteLine("cevap:  "+postfix);
            }inf_to_postf_1();

            //postix → infix dönüşümü - çözüm 0 ÖNEMLİ KAVRAMAK LAZIM
            static void postf_to_inf_0()
            {
                Stack<string> st = new Stack<string>();
                string postfix = "ababc*-d+*+fg/-"; Console.WriteLine("beklenen: a+b*(a-b*c+d)-f/g");
                string infix = "";
                string chars = "+-*/";
                for (int i = 0; i < postfix.Length; i++)
                {
                    int index = chars.IndexOf(postfix[i]);
                    if (index == -1)// operand
                    {
                        st.Push(postfix[i].ToString());
                        continue;
                    }
                    // operatör
                    string op2 = st.Pop();
                    string op1 = st.Pop();
                    string expr = "(" + op1 + postfix[i] + op2 + ")";
                    st.Push(expr);
                }
                infix = st.Pop();
                Console.WriteLine("cevap:  "+infix);
            }

            //postix → infix dönüşümü - çözüm 0 ÖNEMLİ KAVRAMAK LAZIM
            static void inf_to_postf_2()
            {
                int topla(int a, int b) => a + b;
                int cikar(int a, int b) => a - b;
                int carp(int a, int b) => a * b;
                int bol(int a, int b) => a / b;

                string postfix = "abcd/-*e+";
                string operands = "abcde";
                int[] degerler = { 1, 2, 3, 3, 4 };

                Stack<int> stack = new Stack<int>();

                for (int i = 0; i < postfix.Length; i++)
                {
                    int index = operands.IndexOf(postfix[i]);

                    if (index != -1) // operand
                    {
                        stack.Push(degerler[index]);
                    }
                    else // operator
                    {
                        int sagOperand = stack.Pop();
                        int solOperand = stack.Pop();
                        int sonuc = 0;

                        if (postfix[i] == '+') sonuc = topla(solOperand, sagOperand);
                        if (postfix[i] == '-') sonuc = cikar(solOperand, sagOperand);
                        if (postfix[i] == '*') sonuc = carp(solOperand, sagOperand);
                        if (postfix[i] == '/') sonuc = bol(solOperand, sagOperand);
                        stack.Push(sonuc);
                    }
                }

                Console.WriteLine("Sonuç: " + stack.Pop());
            }
        }
        #endregion
        #region HAFTA 11 - QUEUES and CIRCULAR LINKED LISTS
        static void H11()
        {
            // FIRST IN FIRST OUT - LAST IN LAST OUT
            // Kuyruğa eleman almak -> enqueue
            // Kuyruktan eleman çıkarmak -> dequeue
            // front ve rear pointerları kullanılır
            // kuyruklar aynı stacklardaki gibi iki şekilde inceleyeceğiz 1-)diziler 2-)linked listler

            #region - QUEUES ARRAY BASED METOTLARI -
            static int elemansayisi()
            {
                return rear - front + 1;
            }
            static void enqueue(int data)
            {
                if(rear == mainQueue.Length - 1)
                {
                    Console.WriteLine("Queue overflow");
                    return;
                }
                mainQueue[++rear] = data;
            }
            static int dequeue()
            {
                return mainQueue[front++];
            }
            static int peekqueue()
            {
                return mainQueue[front];
            }
            #endregion
            #region - QUEUES LINKED LIST BASED METOTLARI -
            
            static void enqueue_ll(int data)
            {
                Block newBlock = new Block();
                newBlock.data = data;
                newBlock.next = null;
                newBlock.prev = null;
                if (rearll == null)
                {
                    frontll = newBlock;
                    rearll = newBlock;
                    return;
                }
                rearll.next = newBlock;
                newBlock.prev = rearll;
                rearll = newBlock;
            }
            static int dequeue_ll()
            {
                if(frontll == null)
                {
                    Console.WriteLine("Queue underflow");
                    return -1;
                }
                int returnData = frontll.data;
                frontll = frontll.next;
                return returnData;
            }
            static int count_ll()
            {
                Block temp = frontll;
                int count = 0;
                while (temp != null)
                {
                    count++;
                    temp = temp.next;
                }
                return count;
            }
            static int count_ll_recursive(Block head)// queue linked list eleman sayısı recursive!
            {
                if (head == null) return 0;
                return 1 + count_ll_recursive(head.next);
            }
            #endregion
        }
        #endregion
        #region HAFTA 12 - SEARCHING and TREES 
        static void H12()
        {
            /*
             * linear search -> sort edilmiş verilerde kullanılır baştan sona tek tek karşılaştırılır - O(n)
             * binary search -> sort edilmiş verilerde kullanılır ortadaki elemanla karşılaştırılır -> O(log n)
             * b+ tree search -> veritabanlarında kullanılır - O(log n)
             */

        }
        #endregion
        #region HAFTA 13 - TREES
        static void H13()
        {
            /*
             * binary tree -> her düğümün en fazla iki çocuğu olabilir
             * binary search tree -> sol alt ağaçtaki tüm düğümler, kök düğümden küçük, sağ alt ağaçtaki tüm düğümler kök düğümden büyük olmalıdır
             * AVL tree -> her düğüm için sol ve sağ alt ağaçların yükseklik farkı en fazla 1 olmalıdır
             * red-black tree -> her düğüm kırmızı veya siyah renkte olabilir, kök düğüm siyah olmalıdır, kırmızı düğümün çocukları siyah olmalıdır, her yapraktan köke giden tüm yollar aynı sayıda siyah düğüm içermelidir
             */
        }
        #endregion
        #region HAFTA 14 - HASHING
        static void h14() // key-value
        {
            #region hashing n0tlar
            /*
             * hashing -> verileri hızlı bir şekilde erişmek için kullanılan bir tekniktir.Şimdiye kadar gördüğümüz veri yapılarından farklı olarak sadece dizilerle implemente edilebilir. Yani linked list ile kullanımı yoktur.
             * bir veri depolama çeşidi olan dictionary yapısına benzer. -key ve -value. yani bir anahtar ve o anahtara karşılık gelen bir değer vardır.
             * hash function -> veriyi alır ve bir hash kodu üretir. genel olarak amacımız veriyi mümkün olduğunca eşit-dengeli- dağıtmaktır.
             * collision -> iki farklı veri aynı hash kodunu ürettiğinde oluşur
             * open addressing -> çarpışma durumunda boş bir yer bulunana kadar lineer olarak arama yapılır
             * chaining -> her hash tablosu girişinde bir bağlı liste kullanılır, çarpışma durumunda yeni veri bu listeye eklenir
            
            int[] hash = new int[100];
            hash[55] = 10; 

            key = 55 , value = 10

             Index : Value
            ----------------
              0   : 0
              1   : 0
              2   : 0
              .
              .
             54   : 0
             55   : 10   <-- key = 55, value = 10
             56   : 0
              .
              .
             99   : 0

             */
            #endregion
            //static int[] mainHashTable = new int[100]; (yukarda tanımlı)
            //statinc string[] mainStringHashTable = new string[100]; (yukarda tanımlı)

            //hocanın derste yazdığı hashing -----------------------------
            string stringValue = "ABC";
            //  [ hash = Σ (i + 1) * ASCII(character_i) % 100 ]
            static int hashKeyFunction(string value) //string st = 'ABC' olsun
            {
                int toplam = 0;
                for (int i = 0; i < value.Length; i++) // A-> 65x1 B->66x2 C->67x3 
                {
                    toplam = toplam + (i + 1) * (byte)value[i]; // toplam = 398
                }
                toplam = toplam % 100; // 398 % 10 = 98
                
                return toplam;
            }
            int key_1 = hashKeyFunction(stringValue);
            mainStringHashTable[key_1] = stringValue; // mainStringHashTable[98] = 'ABC' oldu

            Console.WriteLine("{0}'nin hash functiondan çıkan key karşılığı = {1}'dir. yani hash[{1}]={0} ", stringValue, key_1);

            //moduler keying -----------------------------
            int intValue = 7355608;
            //  [ index = hash(key) % tableSize ]
            static int hashKeying(int[] hash,int value)
            {
                return value % hash.Length;// hash tablosu uzunluguna göre modu 7355608%100=8
            }
            int key_2 = hashKeying(mainIntHashTable, intValue);
            mainIntHashTable[key_2] = intValue;

            Console.WriteLine("{0}'nin hash functiondan çıkan key karşılığı = {1}'dir. yani hash[{1}]={0} ", intValue, key_2);
        }
        static void h14_1()// COLLISION
        {
            #region collision n0tlar
            /*
            Collision, farklı anahtarların aynı hash değerini üretmesidir. 

            [00] :
            [01] :
            [02] :
            [03] :
            [04] :
            [05] :
            [06] :
            [07] :
            [08] : 7355608 ← ilk gelen
            [09] :
            [10] :
            ...
            [99] :

            1234508 eklenmek isteniyor. 1234508 % 100 = 8 fakat [08] dolu COLLISION
            9808 eklenmek isteniyor. 9808 % 100 = 8 fakat [08] dolu COLLISION

            colisionu önlemek için kullanılan yöntemlere probing denir.boş yer arama stratejisidir.
            -linear probing -> index = (hash(key) + 1) % tableSize
            -quadratic probing -> index = (hash(key) + i^2) % tableSize
            -double hashing -> index = (hash1(key) + i * hash2(key)) % tableSize
             */
            #endregion
            // index = (hash(key) + 1) % tableSize --------------------------------
            int intValue = 7355602;
            static void hashLinearProbing(int[] hash, int value) //LINEAR PROBING
            {
                int key = value % hash.Length;
                int index = key;
                int startIndex = index;
                while (hash[key] != 0)// boş slot bulunana kadar devam et
                {
                    index = (index+1)%hash.Length;// index = (index+1)%hash.size , index = (index+1)%100
                    if (index == startIndex)
                    {
                        Console.WriteLine("* hashLinearProbing fonksiyonunda {0} value.  Hash tablosu dolu , eklenemedi!", value);
                        return;
                    }
                }
                hash[index] = value;
            }
            //deneme ve yazdırma işlemleri
            hashLinearProbing(mainIntHashTable, intValue);
            hashLinearProbing(mainIntHashTable, intValue + 100);
            hashLinearProbing(mainIntHashTable, intValue + 1);
            hashLinearProbing(mainIntHashTable, intValue + 2);
            hashLinearProbing(mainIntHashTable, intValue + 3);
            hashLinearProbing(mainIntHashTable, intValue + 4);
            hashLinearProbing(mainIntHashTable, intValue + 104);

            for (int i = 0; i < mainIntHashTable.Length; i++)
            {
                Console.Write(mainIntHashTable[i] + "-");
            }
            Console.WriteLine("\n");

            //hocanın HASH --------------------------------
            string stringValue = "ABC";
            static int hashKeyFunction(string value) //string st = 'ABC' olsun
            {
                int toplam = 0;
                for (int i = 0; i < value.Length; i++) // A-> 65x1 B->66x2 C->67x3 
                {
                    toplam = toplam + (i + 1) * (byte)value[i]; // toplam = 398
                }
                toplam = toplam % 100; // 398 % 10 = 98

                return toplam;
            }
            //hash = Σ (i + 1) * ASCII(character_i) % 100 
            static void hashStringLinearProbing(string[] hash,string value)
            {
                int tableSize = hash.Length;
                int key = hashKeyFunction(value);

                if (hash[key] == null) // eğer başlangıç boşsa ekle
                {
                    hash[key] = value;
                    return;
                }
                for(int i = 0;i < tableSize; i++)
                {
                    int newIndex = (key + i) % tableSize; // döngüsel kontrol

                    if (hash[newIndex] == null)
                    {
                        hash[newIndex] = value;
                        return;
                    }
                }
            }
            //deneme ve yazdırma işlemleri
            for (int i = 0; i < mainStringHashTable.Length; i++)
            {
                Console.Write(mainStringHashTable[i] + "-");
            }
            Console.WriteLine("\n");
            hashStringLinearProbing(mainStringHashTable, "ABC");
            hashStringLinearProbing(mainStringHashTable, "stringValue");
            hashStringLinearProbing(mainStringHashTable, "BAA");
            hashStringLinearProbing(mainStringHashTable, "FIRO");
            for (int i = 0; i < mainStringHashTable.Length; i++)
            {
                Console.Write(mainStringHashTable[i] + "-");
            }
            Console.WriteLine("\n");
        }
        #endregion
        #region HAFTA 15 - TREES and BINARY TREE
        static void h15()
        {
            #region sınavla alakalı n0tlar
            //binary tree sorusu test dengeli dengesiz bak 
            //b+ tree çıkmayacak
            //linked list tarafı çıkmayacak
            //örnek bt sorusu 35 childden parentlerini yaza yaza roota çıkan
            //bt btsearch farkı
            //test sorusu da var dengeli agaclarda 
            //3.dersteki örneğe benzer klasik soru var 
            #endregion
            #region trees n0tes
            /*
             * doğrusal olmayan hiyerarşik bir düzende saklandığı veri yapısıdır
             * root-kök- level-seviye/katman- leaf-yaprak- parent/child-anne/cocuk- yapısındadır.
                 
                1-)Sıkıştırma algoritmalarında
                2-)Sıralama algoritmalarında
                3-)Search algoritmalarında
                4-)Veritabanı sistemlerinde vb. sistemlerde kullanılır.
             
             
                    A   -> root level
                   / \
                  B   C   -> 1.level
                 / \   \
                D   E   F   -> 2.level

                A
                ├─ B
                │  ├─ D
                │  └─ E
                └─ C
                   └─ F
                
                diziler veya linked listler ile gerçekleştirebiliriz.

             */
            #endregion
            #region - TREES ARRAY BASED METOTLARI -
            /*
            Diziler ile: Matematiksel bir formül üzerinden yönetilir.
            Bir düğümün indisi n ise, 
            sol çocuğu -> 2n+1, 
            sağ çocuğu -> 2n+2 
            indisinde bulunur.
            -1 yerine sınavda genellikle NULL / ∅ varsayımı yapılır.
            */
            /*
                    binary tree max child is 2 (0 1 veya 2 çocuk) 

                           (15)
                          /   \
                         /     \
                      (11)     (26)
                     /   \     /   \
                    /     \   /     \
                   (8)  (12) (20)  (30)
                  /  \   \           \
                 /    \   \           \
                (6)  (9)  (14)        (35)   

            Index :  0   1   2   3   4   5   6   7   8   9   10  11  12  13  14
            Data  : 15  11  26   8  12  20  30   6   9   -   14   -   -   -   35
            
            örn: 14ü aratmak -> ziyaret sırası: 15-11-12-14
            index 0 -> 14<15 git sol ( 2 * 0 + 1 = [1] )
            index 1 -> 14>11 git sağ ( 2 * 1 + 2 = [4] )
            index 4 -> 14>12 git sağ ( 2 * 4 + 2 = [10] )
            index 10 -> 14=14 BULUNDU

            static int[] binary_tree = new int[100]; yukarıda tanımlı


            */
            binary_tree[0]=15; binary_tree[1]=11; binary_tree[2]=26; binary_tree[3]=8; binary_tree[4]=12; binary_tree[5]=20; binary_tree[6]=30; binary_tree[7]=6; binary_tree[8]=9; binary_tree[9]=-1; binary_tree[10]=14; binary_tree[11]=-1; binary_tree[12]=-1; binary_tree[13]=-1; binary_tree[14]=35; 

            static void BinaryTreeYaz(int[] binary_tree, int indis)
            {
                if (indis >= binary_tree.Length) return;
                if (binary_tree[indis] != 0) Console.WriteLine(binary_tree[indis]);
                BinaryTreeYaz(binary_tree, indis * 2 + 1);
                //treenin sol tarafındaki elemanları bastırmamıza yarar
                BinaryTreeYaz(binary_tree, indis * 2 + 2);
                //treenin sağ tarafındaki elemanları bastırmamıza yarar
            }
            BinaryTreeYaz(binary_tree, 0);

            static void PreOrder(int[] binary_tree, int indis)
            {
                if (indis >= binary_tree.Length || binary_tree[indis] == -1)
                    return;
                Console.Write(binary_tree[indis] + " ");      // Root
                PreOrder(binary_tree, 2 * indis + 1);          // Left
                PreOrder(binary_tree, 2 * indis + 2);          // Right
            }
            static void PostOrder(int[] binary_tree , int indis)
            {
                if (indis >= binary_tree.Length || binary_tree[indis] == -1)
                    return;
                PostOrder(binary_tree , indis * 2 + 1); // Left
                PostOrder(binary_tree,indis * 2 + 2); // Right
                Console.WriteLine(binary_tree+" "); // Root
            }
            static void LevelOrder(int[] binart_tree) // level-order zaten dizinin kendisidir
            {
                for(int i = 0; i < binart_tree.Length; i++)
                {
                    if(binary_tree[i]!=-1)
                        Console.WriteLine(binary_tree[i] + " ");
                }
            }
            static int TreeCount(int[] binart_tree,int indis)
            {
                if (indis >= binary_tree.Length)
                    return 0;
                return 
                    1 
                    + TreeCount(binart_tree, indis * 2 + 1)
                    + TreeCount(binart_tree,indis * 2 + 2);
            }
            static int BinarySearchTree(int[] binary_tree , int indis,int searching_value) //binary search tree
            {
                if (indis >= binary_tree.Length)
                    return 0;
                if (binary_tree[indis] == searching_value)
                    return 1;
                if (binary_tree[indis] > searching_value)
                    return BinarySearchTree(binary_tree,indis * 2 + 1 ,searching_value);
                else 
                    return BinarySearchTree(binary_tree,indis * 2 + 2 ,searching_value);
            }
            static int BinarySearchTreee(int[] binary_tree, int indis, int searching_value) //binary search tree
            {
                if (indis >= binary_tree.Length)
                    return 0;
                if (binary_tree[indis] == searching_value)
                    return 1;
                if (binary_tree[indis] > searching_value)
                    return BinarySearchTree(binary_tree, indis * 2 + 1, searching_value);
                else
                    return BinarySearchTree(binary_tree, indis * 2 + 2, searching_value);
            }

            #endregion
            #region - TREES LINKED LIST BASED METOTLARI -
            //çıkmayacak yok dendi
            #endregion
        }
        #endregion
        #region -FİNAL ÖRNEKLERİ-
        #endregion
        static void Main(string[] args) // MAIN METHOD
        {
            Console.WriteLine("ALLAH KURTARSIN!");
            HAFTA8_2();
            H10();
            H11();
        }
    }
}