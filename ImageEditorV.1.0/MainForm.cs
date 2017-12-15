// Kocaeli Üniversitesi Bilgisayar Mühendisliği Yazılım Laboratuvarı - 1 Proje - 1
// 150202041    Berkay Ezdemir
// 150201216    İbrahim Burak Ezdemir    

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace ImageEditorV._1._0
{
    public partial class IE_MainScene : Form
    {
#region Private Variables
        private Bitmap main_image;          // Açılan resmin ilk halini tutan değişken
        private Bitmap buffer_image;        // Üzerinde değişiklikler yapılan değişken
        private Bitmap buffer_image2;       // Geçici olarak kullanılan değişken
        private Bitmap buffer_image3;       // Geçici olarak kullanılan değişken
        private Bitmap channelRed;          // buffer_image'de bulunan resmin kırmızı renk kanalını içerisinde bulundurur
        private Bitmap channelGreen;        // buffer_image'de bulunan resmin yeşil renk kanalını içerisinde bulundurur
        private Bitmap channelBlue;         // buffer_image'de bulunan resmin mavi renk kanalını içerisinde bulundurur
        private Bitmap histRed;             // buffer_image'de bulunan resmin kırmızı renk histogramını içerisinde bulundurur
        private Bitmap histGreen;           // buffer_image'de bulunan resmin yeşil renk histogramını içerisinde bulundurur
        private Bitmap histBlue;            // buffer_image'de bulunan resmin mavi renk histogramını içerisinde bulundurur
        private Bitmap histRGB;             // buffer_image'de bulunan resmin parlaklık histogramını içerisinde bulundurur
        private bool opened = false;        // Dosyanın açılıp açılmadığını saklayan değişken
        private int imageHeight;            // main_image'in yükseklik değerini saklar
        private int imageWidth;             // main_image'in genişlik değerini saklar
#endregion

#region Constructor
        public IE_MainScene()
        {
            InitializeComponent();
        }
        #endregion

#region Image Editing Functions
        // Resim açma işlemlerinin yapıldığı fonksiyon
        private void OpenImage()
        {
            // Mouse imlecini loading imleci ile değiştir
            Cursor.Current = Cursors.WaitCursor;
            // ofd adında yeni bir Open File Dialog nesnesi oluşturuluyor ve bu nesneye diyalog ekranında 
            // sadece resim formatlarının görünmesi için filtre uygulanıyor
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Images|*.png;*.bmp;*.jpg;*.gif;*.exif;*.tiff";

            // Diyalog ekranın sonucu olumluysa
            if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                try { 
                    // Açılan dosya Bitmap türüne dönüştürülüp main_image değişkenine atılıyor
                    main_image = (Bitmap)Image.FromFile(ofd.FileName);
                }
                catch (Exception e)
                {
                    MessageBox.Show("Please open a file in image format!");
                    OpenImage();
                }
                // Açtığımız resmi mainCanvas isimli PictureBox'a yerleştiriyor
                mainCanvas.Image = main_image;
                // main_image değişkenini buffer_image isimli değişkene kopyalıyor
                buffer_image = new Bitmap(main_image);
                // Açılan resmi mainCanvas'a sığması için kullanılan PictureBox özelliği
                mainCanvas.SizeMode = PictureBoxSizeMode.Zoom;
                // Açılan resmin yüksekliği imageHeight değişkenine atanıyor
                imageHeight = main_image.Height;
                // Açılan resmin genişliği imageWidth değişkenine atanıyor
                imageWidth = main_image.Width;
                // Exception handling mekanizması için(Dosya açıkken birkez daha dosya açmaya çalıştığımızda bunun kontrolünü yapmak için)
                opened = true;
                tb_X.Text = imageWidth.ToString();
                tb_Y.Text = imageHeight.ToString();
                Reflesh();               
                // Dosya açma işlemi bittiğinde mouse imlecini normale döndürür
                Cursor.Current = Cursors.Arrow;
            }            
        }

        // Resim kaydetme işlemlerinin yapıldığı fonksiyon
        private void SaveImage()
        {
            // Dosyanın açılıp açılmadığının kontrolü yapılıyor (Açılmamış bir resmi kaydetmemek için)
            if (opened)
            {
                // Bir Save File Dialog nesnesi oluşturuluyor ve bu nesneye sadece resim formatlarını 
                // kabul etmesi için filtre uygulanıyor
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "Images|*.png;*.bmp;*.jpg;*.gif;*.exif;*.tiff";
                // Eğer herhangi bir uzantı girilmezse varsayılan olarak PNG formatı kabul ediliyor
                ImageFormat format = ImageFormat.Png;

                // Diyalog ekranın sonucu olumlu ise
                if (sfd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    // Dosya uzantısının belirlenmesi için yapılan işlem
                    string ext = Path.GetExtension(sfd.FileName);
                    // Diyalog ekranında uzantı belirtilmişse o uzantının format değişkenine atılması için yapılan işlem
                    switch (ext)
                    {
                        case ".jpg":
                            format = ImageFormat.Jpeg;
                            break;

                        case ".bmp":
                            format = ImageFormat.Bmp;
                            break;
                        case ".gif":
                            format = ImageFormat.Gif;
                            break;
                        case ".exif":
                            format = ImageFormat.Exif;
                            break;
                        case ".tiff":
                            format = ImageFormat.Tiff;
                            break;
                    }
                    try
                    {
                        // mainCanvas'ta bulunan resmi seçtiğimiz formatta belirlenen adrese kaydeder
                        mainCanvas.Image.Save(sfd.FileName, format);
                    }
                    catch (Exception e) { MessageBox.Show("Image not saved!\nHata Kodu:\n{0}", e.Message); }
                    // Hata olsa da olmasa da çalıştırılacak bölüm
                    finally { MessageBox.Show("Image saved successfully!"); }
                }
                // Save File Dialog'un sonucu olumsuz ise hata mesajı göster
                else { MessageBox.Show("Image saving is canceled!"); } 
            }
            else { MessageBox.Show("Image could not be saved! Please select the image first!"); }
        }

        // Programın açılan resmin üzerinde işlem yapılmamış haline geri dönmesini gerçekleştiren fonksiyon
        private void Reset()
        {
            Cursor.Current = Cursors.WaitCursor;

            if (!opened)
            {
                MessageBox.Show("Please select the image first!");
            }
            else
            {
                buffer_image = new Bitmap(main_image);
                GC.Collect(); // Garbage Collector mekanizmasını manuel olarak çağırır.
                cb_ColorChannel.Text = "RGB";
                cb_Hisogram.Text = "RGB";
                tb_X.Text = buffer_image.Width.ToString();
                tb_Y.Text = buffer_image.Height.ToString();
                Reflesh();
                mainCanvas.Image = buffer_image;
                opened = true;
            }
            Cursor.Current = Cursors.Arrow;
        }

        // Yenileme işlemlerinin yapıldığı fonksiyon
        // Bu fonksiyonun görevi resim üzerinde işlemler gerçekleştirildikten sonra histogram, 
        private void Reflesh()
        {
            ColorChannel();
            Histogram();
            GC.Collect();
            cb_ColorChannel.Text = "RGB";
            cb_Hisogram.Text = "RGB";
            histogramCanvas.Image = histRGB;
        }

        // Resmi gri ton dönüşümünü yapan fonksiyon
        private void GrayScale()
        {                       
            if (!opened)
            {
                MessageBox.Show("Please select the image first!");
            }
            else
            {
                Cursor.Current = Cursors.WaitCursor;
                Color p;
                int avg, r, g, b;

                for (int y = 0; y < buffer_image.Height; y++)
                {
                    for (int x = 0; x < buffer_image.Width; x++)
                    {
                        // x,y koordinatlarında bulunan pixelin değerini p değişkenine atar.
                        p = buffer_image.GetPixel(x, y);
                        // p değişkeninin RGB değerlerini r,g,b değişkenlerine atar.
                        r = p.R;
                        g = p.G;
                        b = p.B;
                        // Gray scale formülü
                        // avg = (int) (0.3f * r + 0.59f * g + 0.11f * b) / 3;
                        avg = (r + g + b) / 3;
                        // x,y koordinatlarına RGB(avg,avg,avg) şeklinde oluşturmuş olan renk değerini yapıştırır.
                        buffer_image.SetPixel(x, y, Color.FromArgb(avg, avg, avg));
                    }
                }
                Reflesh();
                mainCanvas.Image = buffer_image;
                
                Cursor.Current = Cursors.Arrow;
            }
        }

        // Resmin negatif dönüşümünü yapan fonskiyon
        private void NegativeInvert()
        {          
            if (!opened)
            {
                MessageBox.Show("Please select the image first!");
            }
            else
            {
                Cursor.Current = Cursors.WaitCursor;
                Color p;
                int r, g, b;

                for (int y = 0; y < buffer_image.Height; y++)
                {
                    for (int x = 0; x < buffer_image.Width; x++)
                    {
                        // x,y koordinatlarında bulunan pixelin değerini p değişkenine atar.
                        p = buffer_image.GetPixel(x, y);
                        // p değişkenininARGB değerlerini r,g,b değişkenlerine atar.
                        r = p.R;
                        g = p.G;
                        b = p.B;
                        // x,y koordinatlarına RGB değerlerinin 255 ile farkının oluşturmuş olduğu renk değerini yapıştırır.
                        buffer_image.SetPixel(x, y, Color.FromArgb(255 - r, 255 - g, 255 - b));
                    }
                }
                Reflesh();
                mainCanvas.Image = buffer_image;                
                Cursor.Current = Cursors.Arrow;
            }
        }

        // Resmi sola döndüren fonksiyon
        private void LeftRotation()
        {
            if (!opened)
            {
                MessageBox.Show("Please select the image first!");
            }
            else
            {
                Cursor.Current = Cursors.WaitCursor;
                // Canvastaki resimin yükseklik ve genişlik değerlerini kullanarak yeni geçici değişkenler yaratılıyor.
                // Bu değişkenleri oluşturma amacımız resim üzerinde yaptığımız değişiklerin resmi etkilemeden değişkenler vasıtasıyla gerçekleştirmek
                buffer_image2 = new Bitmap(buffer_image.Height, buffer_image.Width);    // Bitmap(Width, Height)
                buffer_image3 = new Bitmap(buffer_image.Height, buffer_image.Width);    // Bitmap(Width, Height)

                // Time: O(n^2) Space: O(3n)
                for (int x = 0; x < buffer_image.Width; ++x)
                {
                    for (int y = 0; y < buffer_image.Height; ++y)
                    {
                        // Resmi bir matris gibi düşünüp matrisin transpozunu alıyoruz. Böylelikle x ve y değerleri yer değiştirmiş oluyor.
                        buffer_image2.SetPixel(y, x, buffer_image.GetPixel(x, y));
                        // Transpozu alınan matrisin yukarıdan aşağıya yansıması işlemini yapar. Böylelikle resim sola döndürülmüş olur.
                        buffer_image3.SetPixel(y, buffer_image.Width - x - 1, buffer_image2.GetPixel(y, x));
                    }
                }

                buffer_image = new Bitmap(buffer_image3);
                buffer_image2 = null;
                buffer_image3 = null;
                Reflesh();
                mainCanvas.Image = buffer_image;
                
                Cursor.Current = Cursors.Arrow;
            }
        }

        // Resmi sağa döndüren fonksiyon
        private void RightRotation()
        {
            if (!opened)
            {
                MessageBox.Show("Please select the image first!");
            }
            else
            {
                Cursor.Current = Cursors.WaitCursor;
                // Canvastaki resimin yükseklik ve genişlik değerlerini kullanarak yeni geçici değişkenler yaratılıyor.
                // Bu değişkenleri oluşturma amacımız resim üzerinde yaptığımız değişiklerin resmi etkilemeden değişkenler vasıtasıyla gerçekleştirmek
                buffer_image2 = new Bitmap(buffer_image.Height, buffer_image.Width);    // Bitmap(Width, Height)
                buffer_image3 = new Bitmap(buffer_image.Height, buffer_image.Width);    // Bitmap(Width, Height)

                for (int x = 0; x < buffer_image.Width; ++x)
                {
                    for (int y = 0; y < buffer_image.Height; ++y)
                    {
                        // Resmi bir matris gibi düşünüp matrisin transpozunu alıyoruz. Böylelikle x ve y değerleri yer değiştirmiş oluyor.
                        buffer_image2.SetPixel(y, x, buffer_image.GetPixel(x, y));
                        // Transpozu alınan matrisin soldan sağa yansıması işlemini yapar. Böylelikle resim sağa döndürülmüş olur.
                        buffer_image3.SetPixel(buffer_image.Height - y - 1, x, buffer_image2.GetPixel(y, x));
                    }
                }
                                
                buffer_image = new Bitmap(buffer_image3);
                buffer_image2 = null;
                buffer_image3 = null;
                Reflesh();
                mainCanvas.Image = buffer_image;
                
                Cursor.Current = Cursors.Arrow;
            }
        }

        // Resmi aynalama işlemine tabi tutan fonksiyon
        private void MirroringL2R()
        {
            if (!opened)
            {
                MessageBox.Show("Please select the image first!");
            }
            else
            {
                Cursor.Current = Cursors.WaitCursor; // İşlem yapılırken imlecin bekleme durumuna geçmesi için
                buffer_image2 = new Bitmap(buffer_image);
                for (int y = 0; y < buffer_image.Height; y++)
                {
                    for (int x = 0; x < buffer_image.Width; x++)
                    {
                        buffer_image2.SetPixel(buffer_image.Width - x - 1, y, buffer_image.GetPixel(x, y));
                    }
                }
                buffer_image = new Bitmap(buffer_image2);
                buffer_image2 = null;
                Reflesh();
                mainCanvas.Image = buffer_image;
                
                Cursor.Current = Cursors.Arrow;
            }
        }

        // Resmin histogram işlemlerini yürüten fonksiyon
        private void Histogram()
        {          
            if (!opened)
            {
                MessageBox.Show("Please select the image first!");
            }
            else
            {                
                SortedDictionary<int, int> hsDataRed = new SortedDictionary<int, int>();
                SortedDictionary<int, int> hsDataGreen = new SortedDictionary<int, int>();
                SortedDictionary<int, int> hsDataBlue = new SortedDictionary<int, int>();
                SortedDictionary<int, int> hsDataRGB = new SortedDictionary<int, int>();
                histRed = new Bitmap(256, 256);
                histGreen = new Bitmap(256, 256);
                histBlue = new Bitmap(256, 256);
                histRGB = new Bitmap(256, 256);
                Color p;

                int colorData;
                int tempNum = 0;
                double scaleFactorY;

                histogramCanvas.SizeMode = PictureBoxSizeMode.Zoom;
                // Veri setlerinin anahtar kısımlarını 0-255'e kadar doldurur
                // Bunun sebebi: SortedDictionary tipinde key kısmının 0-255'e kadar tonları göstermesini istiyoruz.
                // Sonrasında value kısmına keylere göre kolayca değer atabilmemizi sağlayacak.
                for (int i=0; i<256; i++) {
                    hsDataRed.Add(i, 0);
                    hsDataGreen.Add(i, 0);
                    hsDataBlue.Add(i, 0);
                    hsDataRGB.Add(i, 0);
                }

                for (int y = 0; y < buffer_image.Height; y++)
                {
                    for (int x = 0; x < buffer_image.Width; x++)
                    {
                        // buffer_image'in pixel değerini alır
                        p = buffer_image.GetPixel(x, y);

                        // pixelin kırmızı değerini colorData değişkenine atar ve bu tonun hsRed veri setindeki değerini arttırır
                        colorData = (int)p.R;
                        hsDataRed[colorData] = hsDataRed[colorData] + 1;
                        // pixelin yeşil değerini colorData değişkenine atar ve bu tonun hsGreen veri setindeki değerini arttırır
                        colorData = (int)p.G;
                        hsDataGreen[colorData] = hsDataGreen[colorData] + 1;
                        // pixelin mavi değerini colorData değişkenine atar ve bu tonun hsBlue veri setindeki değerini arttırır
                        colorData = (int)p.B;
                        hsDataBlue[colorData] = hsDataBlue[colorData] + 1;
                    }
                }
                
                // RGB histogram değerlerinin hesaplanması
                for(int i=0; i<hsDataRed.Values.Count; i++) {
                    // For Adobe RGB (1998)
                    // Y′ = 0.2974⋅Red′ + 0.6273⋅Green′ + 0.0753⋅Blue′
                    hsDataRGB[i] = (int)(0.2974 * hsDataRed[i] + 0.6273 * hsDataGreen[i] + 0.0753 * hsDataBlue[i]);                              
                }

                // Histogram verilerinden en büyük olanı 255 ile oranlayıp bu oranı scaleFaktorY değişkenine atar.
                scaleFactorY = 255.0f / hsDataRGB.Values.Max();
                // Histogram verilerini bu oran ile çarparsak histogram verileri 0-255 arasında değerler almış olur.
                // Bunu yapmamızın sebebi histogramı pixel pixel yazdırırken herhangi bir array out of bound exception almamak.
                for (int i = 0; i < hsDataRGB.Values.Count; i++)
                {
                    hsDataRGB[i] = (int)(hsDataRGB[i] * scaleFactorY);
                }
                // Histogram verilerinden en büyük olanı 255 ile oranlayıp bu oranı scaleFaktorY değişkenine atar.
                scaleFactorY = 255.0f / hsDataRed.Values.Max();
                // Histogram verilerini bu oran ile çarparsak histogram verileri 0-255 arasında değerler almış olur.
                // Bunu yapmamızın sebebi histogramı pixel pixel yazdırırken herhangi bir array out of bound exception almamak.
                for (int i = 0; i < hsDataRed.Values.Count; i++)
                {
                    hsDataRed[i] = (int)(hsDataRed[i] * scaleFactorY);
                }
                // Histogram verilerinden en büyük olanı 255 ile oranlayıp bu oranı scaleFaktorY değişkenine atar.
                scaleFactorY = 255.0f / hsDataGreen.Values.Max();
                // Histogram verilerini bu oran ile çarparsak histogram verileri 0-255 arasında değerler almış olur.
                // Bunu yapmamızın sebebi histogramı pixel pixel yazdırırken herhangi bir array out of bound exception almamak.
                for (int i = 0; i < hsDataGreen.Values.Count; i++)
                {
                    hsDataGreen[i] = (int)(hsDataGreen[i] * scaleFactorY);
                }
                // Histogram verilerinden en büyük olanı 255 ile oranlayıp bu oranı scaleFaktorY değişkenine atar.
                scaleFactorY = 255.0f / hsDataBlue.Values.Max();
                // Histogram verilerini bu oran ile çarparsak histogram verileri 0-255 arasında değerler almış olur.
                // Bunu yapmamızın sebebi histogramı pixel pixel yazdırırken herhangi bir array out of bound exception almamak.
                for (int i = 0; i < hsDataBlue.Values.Count; i++)
                {
                    hsDataBlue[i] = (int)(hsDataBlue[i] * scaleFactorY);
                }

                p = Color.Black;
                // RGB histogramının Bitmap'e yazdırılma işlemi, sol alt köşeden başlayarak x eksenini 0-255'e kadar
                // renk tonu olarak belirleyip, tonun miktarına göre y ekseninde artış yapılması sağlanır.
                for (int x=0; x <= 255; x++)
                {
                    tempNum = hsDataRGB[x];
                    for(int y=255; y >= 0; y--)
                    {
                        if (tempNum > 0)
                        {
                            histRGB.SetPixel(x, y, p);
                            tempNum--;
                        }
                        else { break; }
                    }
                }

                p = Color.Red;
                // Kırmızı renk histogramının Bitmap'e yazdırılma işlemi, sol alt köşeden başlayarak x eksenini 0-255'e kadar
                // renk tonu olarak belirleyip, tonun miktarına göre y ekseninde artış yapılması sağlanır.
                for (int x = 0; x <= 255; x++)
                {
                    tempNum = hsDataRed[x];
                    for (int y = 255; y >= 0; y--)
                    {
                        if (tempNum > 0)
                        {
                            histRed.SetPixel(x, y, p);
                            tempNum--;
                        }
                        else { break; }
                    }
                }

                p = Color.Green;
                // Yeşil renk histogramının Bitmap'e yazdırılma işlemi, sol alt köşeden başlayarak x eksenini 0-255'e kadar
                // renk tonu olarak belirleyip, tonun miktarına göre y ekseninde artış yapılması sağlanır.
                for (int x = 0; x <= 255; x++)
                {
                    tempNum = hsDataGreen[x];
                    for (int y = 255; y >= 0; y--)
                    {
                        if (tempNum > 0)
                        {
                            histGreen.SetPixel(x, y, p);
                            tempNum--;
                        }
                        else { break; }
                    }
                }

                p = Color.Blue;
                // Mavi renk histogramının Bitmap'e yazdırılma işlemi, sol alt köşeden başlayarak x eksenini 0-255'e kadar
                // renk tonu olarak belirleyip, tonun miktarına göre y ekseninde artış yapılması sağlanır.
                for (int x = 0; x <= 255; x++)
                {
                    tempNum = hsDataBlue[x];
                    for (int y = 255; y >= 0; y--)
                    {
                        if (tempNum > 0)
                        {
                            histBlue.SetPixel(x, y, p);
                            tempNum--;
                        }
                        else { break; }
                    }
                }
            }
        }

        // Resmin renk kanalları işlemlerini yürüten fonksiyon
        private void ColorChannel()
        {
            Color p, tempColor;
            int colorData;
            channelRed = new Bitmap(buffer_image);
            channelGreen = new Bitmap(buffer_image);
            channelBlue = new Bitmap(buffer_image);

            // Color Channel seçimi yapılan ComboBox değerini RGB olarak değiştirir.
            cb_ColorChannel.Text = "RGB";
            for (int y=0; y<buffer_image.Height; y++)
            {
                for(int x=0; x<buffer_image.Width; x++)
                {
                    // buffer_image'in pixel değerini alır
                    p = buffer_image.GetPixel(x, y);

                    // Seçili pixelin kırmızı rengini colorData değişkenine atar.
                    // tempColor değişkenine RGB rengi aynı olan RGB(colorData,colorData,colorData) şeklinde bir renk değeri atar.
                    // Bu rengi channelRed bitmapinin ilgili pixeline yapıştırır.
                    colorData = (int)p.R;                    
                    tempColor = Color.FromArgb(colorData, colorData, colorData);                    
                    channelRed.SetPixel(x, y, tempColor);

                    // Seçili pixelin yeşil rengini colorData değişkenine atar.
                    // tempColor değişkenine RGB rengi aynı olan RGB(colorData,colorData,colorData) şeklinde bir renk değeri atar.
                    // Bu rengi channelGreen bitmapinin ilgili pixeline yapıştırır.
                    colorData = (int)p.G;
                    tempColor = Color.FromArgb(colorData, colorData, colorData);
                    channelGreen.SetPixel(x, y, tempColor);

                    // Seçili pixelin mavi rengini colorData değişkenine atar.
                    // tempColor değişkenine RGB rengi aynı olan RGB(colorData,colorData,colorData) şeklinde bir renk değeri atar.
                    // Bu rengi channelBlue bitmapinin ilgili pixeline yapıştırır.
                    colorData = (int)p.B;
                    tempColor = Color.FromArgb(colorData, colorData, colorData);
                    channelBlue.SetPixel(x, y, tempColor);
                }
            }
        }

        // Resmin ölçeklendirilme işlemlerini yürüten fonksiyon
        private void ImageScale()
        {
            Cursor.Current = Cursors.WaitCursor;

            int scaleX = Int32.Parse(tb_X.Text);
            int scaleY = Int32.Parse(tb_Y.Text);
            Bitmap scaledImage = new Bitmap(scaleX, scaleY);

            int ratioX = (int)((buffer_image.Width << 16) / scaleX) + 1;
            int ratioY = (int)((buffer_image.Height << 16) / scaleY) + 1;
            int x2, y2;

            Debug.WriteLine(scaleX + ", " + scaleY);

            for (int y = 0; y<scaleY; y++)
            {
                for (int x=0; x<scaleX; x++)
                {
                    x2 = ((x * ratioX) >> 16);
                    y2 = ((y * ratioY) >> 16);
                    try { scaledImage.SetPixel(x, y, buffer_image.GetPixel(x2, y2)); }
                    catch (Exception e) { MessageBox.Show("Image not scaled!"); }
                    
                }
            }

            buffer_image = new Bitmap(scaledImage);
            Reflesh();
            mainCanvas.Image = buffer_image;
            Debug.WriteLine(buffer_image.Width + ", " + buffer_image.Height);
            GC.Collect();

            Cursor.Current = Cursors.Arrow;
        }

#endregion

#region Form Events
        private void Form1_Load(object sender, EventArgs e)
        {
            Console.WriteLine("FormLoaded!");
        }

        private void txt_OpenDialog_Click(object sender, EventArgs e)
        {
            OpenImage();
        }

        private void leftRotationClick(object sender, EventArgs e)
        {
            LeftRotation();
        }

        private void rightRotationClick(object sender, EventArgs e)
        {
            RightRotation();
        }

        private void mirroringClick(object sender, EventArgs e)
        {
            MirroringL2R();
        }

        private void grayScaleClick(object sender, EventArgs e)
        {
            GrayScale();
        }

        private void negativeInvertClick(object sender, EventArgs e)
        {
            NegativeInvert();
        }

        private void btnResetClick(object sender, EventArgs e)
        {
            Reset();
        }

        private void btnMainSaveClick(object sender, EventArgs e)
        {
            SaveImage();
        }

        private void tsm_Open_Click(object sender, EventArgs e)
        {
            if(opened)
            {
                if (MessageBox.Show("Yeni bir dosya açmak istediğinize emin misiniz?",
                        "Uyarı", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
                {
                    OpenImage();
                }
            }
            else { OpenImage(); }                    
        }

        private void tsm_Save_Click(object sender, EventArgs e)
        {
            SaveImage();    
        }

        private void tsm_RotateLeft_Click(object sender, EventArgs e)
        {
            LeftRotation();
        }

        private void tsm_RotateRight_Click(object sender, EventArgs e)
        {
            RightRotation();
        }

        private void tsm_Mirroring_Click(object sender, EventArgs e)
        {
            MirroringL2R();
        }

        private void tsm_GrayScaling_Click(object sender, EventArgs e)
        {
            GrayScale();
        }

        private void tsm_ColorInverting_Click(object sender, EventArgs e)
        {
            NegativeInvert();
        }

        private void tsm_Reset_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Değişiklikleri sıfırlamak istediğinize emin misiniz?",
                "Reset", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
            {
                Reset();
            }
        }

        private void tsm_Help_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Kocaeli Üniversitesi Yazılım Laboratuvarı - 1\n\n150202041 Berkay Ezdemir\n" +
                "150201216 İbrahim Burak Ezdemir", "About", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void cb_ColorChannel_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cb_ColorChannel.Text == "Red") { mainCanvas.Image = channelRed; }
            else if (cb_ColorChannel.Text == "Green") { mainCanvas.Image = channelGreen; }
            else if (cb_ColorChannel.Text == "Blue") { mainCanvas.Image = channelBlue; }
            else { mainCanvas.Image = buffer_image; }
        }

        private void cb_Hisogram_SelectedIndexChanged(object sender, EventArgs e)
        {
            histogramCanvas.SizeMode = PictureBoxSizeMode.Zoom;
            if (cb_Hisogram.Text == "Red") { histogramCanvas.Image = histRed; }
            else if (cb_Hisogram.Text == "Green") { histogramCanvas.Image = histGreen; }
            else if (cb_Hisogram.Text == "Blue") { histogramCanvas.Image = histBlue; }
            else { histogramCanvas.Image = histRGB; }
        }

        private void btn_Scale_Click(object sender, EventArgs e)
        {
            ImageScale();
        }
        
        #endregion
    }
}