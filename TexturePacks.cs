using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Net;

namespace RandomSurvival_Jar_Installer
{
    public partial class TexturePacks : Form
    {
        public delegate void ProgressChangeDelegate(double Persentage, ref bool Cancel);
        public delegate void Completedelegate();
        WebClient webClient = new WebClient();
        List<string> _packok = new List<string>();
        List<string> _tipus = new List<string>();
        List<string> _16 = new List<string>();
        List<string> _64 = new List<string>();
        List<string> _felbontas = new List<string>();
        public string envPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop).ToString() + @"\error.txt"; //C:\users\név\asztal\error.txt
        public string desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop).ToString();
        public string appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData).ToString();
        public string date = DateTime.Now.ToString();
        public string error;
        public string mc;
        public string webLink;
        public string resourcePackname;
        public TexturePacks()
        {
            InitializeComponent();
            _packok.Add("SphaX - PureBDCraft");
            _packok.Add("SixtyGig ResourcePack");
            _packok.Add("R3D.CRAFT - Default Realism");
            _packok.Add("R3D.CRAFT - Smooth Realism");
            _packok.Add("PaperCutOut");
            _felbontas.Add("32px");
            _felbontas.Add("64px");
            _felbontas.Add("128px");
            _felbontas.Add("256px");
            _felbontas.Add("512px");
            _tipus.Add("Sima Minecraft (Crackelt vagy Eredeti)");
            _tipus.Add("Hu-Minecraft");
            _tipus.Add("EmpireCraft");
            _tipus.Add("MesterMC");
            _tipus.Add("CoolCraft");
            _tipus.Add("DiceCraft");
            _tipus.Add("Nincs a listán, segíts!");
            _16.Add("16px");
            _64.Add("64px");
            listBox1.DataSource = _packok;
            comboBox1.DataSource = _felbontas;
            label4.Text = null;
            comboBox2.DataSource = _tipus;
            progressBar1.Visible = false;
        }
        void web_DownloadProgressChanged1(object sender, DownloadProgressChangedEventArgs e)
        {
            try
            {
                progressBar1.Visible = true;
                int bytesin = int.Parse(e.BytesReceived.ToString());
                int totalbytes = int.Parse(e.TotalBytesToReceive.ToString());
                int kb1 = bytesin / 1024;
                int kb2 = totalbytes / 1024;
                label4.Text = kb1.ToString() + @"kb\" + kb2 + "kb \n(" + e.ProgressPercentage.ToString() + "%)";
                progressBar1.Value = e.ProgressPercentage;
            }
            catch (StackOverflowException a)
            {
                error = a.ToString();
                log(108);
            }
            catch (Exception a)
            {
                error = a.ToString();
                log(100);
            }
        }
        private void DownloadCompleted(object sender, AsyncCompletedEventArgs e)
        {
            label4.Text = null;
            progressBar1.Value = 0;
            progressBar1.Visible = false;
        }
        public void log(int errorCode)  //logger
        {
            try
            {
                File.AppendAllText(envPath, "\n[" + date + "]");
                File.AppendAllText(envPath, "\n" + error);
                DialogResult dres = MessageBox.Show("A program futása közben váratlan hiba lépett fel. \nSzeretnéd megtekinteni a logot? \n\nHibakód: " + errorCode, "Hibakód: " + errorCode, MessageBoxButtons.YesNo);
                if (dres == DialogResult.Yes)
                {
                    System.Diagnostics.Process.Start(envPath); //file megnyitása Process hívással
                }
                if (dres == DialogResult.No)
                {

                }
            }
            catch (FileNotFoundException a)
            {
                error = a.ToString();
                log(106);
            }
            catch (Exception b)
            {
                error = b.ToString();
                log(100);
            }
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex == 1)

            {
                comboBox1.DataSource = _64;
            }
            if (listBox1.SelectedIndex == 0 || listBox1.SelectedIndex == 2)
            {
                comboBox1.DataSource = _felbontas;
            }
            if (listBox1.SelectedIndex == 4)
            {
                comboBox1.DataSource = _16;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (comboBox2.SelectedIndex == 0)  //Sima vagy crackelt
                {
                    mc = @"\.minecraft";
                }
                if (comboBox2.SelectedIndex == 1)  //Hu-minecraft
                {
                    mc = @"\.hu-minecraft";
                }
                if (comboBox2.SelectedIndex == 2) //EmpireCraft
                {
                    mc = @"\.empirecraft";
                }
                if (comboBox2.SelectedIndex == 3) //MesterMC
                {
                    mc = @"\.MesterMC.hu";
                }
                if (comboBox2.SelectedIndex == 4)  //CoolCraft
                {
                    mc = @"\.coolcraft";
                }
                if (comboBox2.SelectedIndex == 5) //DiceCraft
                {
                    mc = @"\.dicecraft.eu";
                }
                if (comboBox2.SelectedIndex == 6)  //Nincs a listán --> facebookra irányít
                {
                    DialogResult dres = MessageBox.Show("Ha az általad használt kiadó vagy verzió nincs a programban, kérlek, írj egy levelet nekünk és mi hozzáadjuk a legközelebbi verzióban!\nSzeretnél most üzenetet írni?", "Mi lesz most?", MessageBoxButtons.YesNo);
                    if (dres == DialogResult.Yes)
                    {
                        System.Diagnostics.Process.Start("http://www.facebook.com/messages/RandomSurvival");
                    }
                    if (dres == DialogResult.No)
                    {

                    }
                }
                if (listBox1.SelectedIndex == 0)            //Sphax PureDBcraft    http://bdcraft.net/download/?z=Sphax%20PureBDcraft%20512x%20MC17&dl=bdcdf462f66b2792a94ccdd5f4c1b5b783b
                {
                    if (comboBox1.SelectedIndex == 0)
                    {
                        webLink = "https://dl.dropboxusercontent.com/s/3jc8ho2bs1li1q8/Sphax%20PureBDcraft%20%2032x%20MC16.zip?dl=1&token_hash=AAFd4DZGKfhQYkb4QmxKGq9K4EM1q1STaZO3ucv-BSfHDw";
                        resourcePackname = "Sphax PureBDcraft_32.zip";
                    }
                    if (comboBox1.SelectedIndex == 1)
                    {
                        webLink = "https://dl.dropboxusercontent.com/s/6mws753txyx1uqb/Sphax%20PureBDcraft%20%2064x%20MC16.zip?dl=1&token_hash=AAHOK3Wpr25aPbGmQ2TWhAkCBJ9TNUHTbgjtF8_7AyBmMQ";
                        resourcePackname = "Sphax PureBDcraft_64.zip";
                    }
                    if (comboBox1.SelectedIndex == 2)
                    {
                        webLink = "https://dl.dropboxusercontent.com/s/rq5nlsvt34h4k1t/Sphax%20PureBDcraft%20128x%20MC16.zip?dl=1&token_hash=AAGTWu7EWz9p8PN8gQw3QbvCDGBPPL4b5J7wlXuLqlBKqA";
                        resourcePackname = "Sphax PureBDcraft_128.zip";
                    }
                    if (comboBox1.SelectedIndex == 3)
                    {
                        webLink = "https://dl.dropboxusercontent.com/s/zpn9cbwutcgu5om/Sphax%20PureBDcraft%20256x%20MC16.zip?dl=1&token_hash=AAE5_W0fA12dH2AASf0EWn0ihTysMjvksVtBT_dFcJtXgw";
                        resourcePackname = "Sphax PureBDcraft_256.zip";
                    }
                    if (comboBox1.SelectedIndex == 4)
                    {
                        webLink = "https://dl.dropboxusercontent.com/s/oq8w4ks4k6ar9u5/Sphax%20PureBDcraft%20512x%20MC16.zip?dl=1&token_hash=AAHqgrK6B8rtaZucr8tgwJxDg4E9UrWQ84wWtczxLF919A";
                        resourcePackname = "Sphax PureBDcraft_512.zip";
                    }
                }
                if (listBox1.SelectedIndex == 1)            //Sixty gig
                {
                    if (comboBox1.SelectedIndex == 0)
                    {
                        webLink = "https://dl.dropboxusercontent.com/s/lktdqpjcs0r3owo/SixtyGig_Core_64x_MC17.zip?dl=1&token_hash=AAERf_K11W4t8MTJSHOWmJTWfxRGP43RFUkna56aNUwdtQ";
                        resourcePackname = "SixtyGig_Core_64x_MC17.zip";
                    }
                }
                if (listBox1.SelectedIndex == 2)            //r3d craft
                {
                    if (comboBox1.SelectedIndex == 0)
                    {
                        webLink = "https://dl.dropboxusercontent.com/s/efgbofnkc1t5h56/%5B1.6.2%5D_R3D.CRAFT_Default_Realism_32x_v0.1.1.zip?dl=1&token_hash=AAGD6ilhTBViW0Rrpo631QUqejcHI1qFw4Gq-YF1TawJeg";
                        resourcePackname = "R3D.CRAFT_DefaultRealism_32x_v0.1.1.zip";
                    }
                    if (comboBox1.SelectedIndex == 1)
                    {
                        webLink = "https://dl.dropboxusercontent.com/s/maq5khqiix6ymgn/%5B1.6.2%5D_R3D.CRAFT_Default_Realism_64x_v0.1.1.zip?dl=1&token_hash=AAFcunYQrEwbOXm53x9U-qTm62IAu7CCl8Z2lu-lQQGO9A";
                        resourcePackname = "R3D.CRAFT_DefaultRealism_64x_v0.1.1.zip";
                    }
                    if (comboBox1.SelectedIndex == 2)
                    {
                        webLink = "https://dl.dropboxusercontent.com/s/ybcppidfy3i2i1e/%5B1.6.2%5D_R3D.CRAFT_Default_Realism_128x_v0.1.1.zip?dl=1&token_hash=AAHSEM7mFrnlxUzl2aS0VHZvOmF3SWFjHU5Lp5SJHgclng";
                        resourcePackname = "R3D.CRAFT_DefaultRealism_128x_v0.1.1.zip";
                    }
                    if (comboBox1.SelectedIndex == 3)
                    {
                        webLink = "https://dl.dropboxusercontent.com/s/o99fc5e2wsxd20e/%5B1.6.2%5D_R3D.CRAFT_Default_Realism_256x_v0.1.1.zip?dl=1&token_hash=AAE3Ifot53mUPa331mclLq7G6A3y1Iw1tj3ORYcEDa9wPg";
                        resourcePackname = "R3D.CRAFT_DefaultRealism_256x_v0.1.1.zip";
                    }
                    if (comboBox1.SelectedIndex == 4)
                    {
                        webLink = "https://dl.dropboxusercontent.com/s/7tvbssvt2fxc79n/%5B1.6.2%5D_R3D.CRAFT_Default_Realism_512x_v0.1.1.zip?dl=1&token_hash=AAF8yhjLsFp2L1Fp_UI4es6aDejU3gNnq7O08VVfOmBETA";
                        resourcePackname = "R3D.CRAFT_DefaultRealism_512x_v0.1.1.zip";
                    }
                }
                if (listBox1.SelectedIndex == 3)            //R3D craft smooth
                {
                    if (comboBox1.SelectedIndex == 0)
                    {
                        webLink = "https://dl.dropboxusercontent.com/s/y926bn0j35ehk6d/%5B1.6.2%5D_R3D.CRAFT_Smooth_Realism_32x_v0.1.1.zip?dl=1&token_hash=AAEwemhSgpBh6MlYNwvsXMq_7rvmUxK_eFfpDqCSyVSTUA";
                        resourcePackname = "R3D.CRAFT_SmoothRealism_32x_v0.1.1.zip";
                    }
                    if (comboBox1.SelectedIndex == 1)
                    {
                        webLink = "https://dl.dropboxusercontent.com/s/mhxb2e43h2gtblt/%5B1.6.2%5D_R3D.CRAFT_Smooth_Realism_64x_v0.1.1.zip?dl=1&token_hash=AAGQB45lXtB4r-ZX6EepqkfH7McBSl6sCllq6BZaT8bAFg";
                        resourcePackname = "R3D.CRAFT_SmoothRealism_32x_v0.1.1.zip";
                    }
                    if (comboBox1.SelectedIndex == 2)
                    {
                        webLink = "https://dl.dropboxusercontent.com/s/9wot7nrs7j95vwp/%5B1.6.2%5D_R3D.CRAFT_Smooth_Realism_128x_v0.1.1.zip?dl=1&token_hash=AAFCjOS3Cw45lIcWkIUK4oaGD30VnrtpDgq-rHzJAa1-Vg";
                        resourcePackname = "R3D.CRAFT_SmoothRealism_32x_v0.1.1.zip";
                    }
                    if (comboBox1.SelectedIndex == 3)
                    {
                        webLink = "https://dl.dropboxusercontent.com/s/jbsedkxeyio6420/%5B1.6.2%5D_R3D.CRAFT_Smooth_Realism_256x_v0.1.1.zip?dl=1&token_hash=AAFG30Xf9DtZf5K9WppfbAH8Atm0yYlaNFe3mUk9WJHqug";
                        resourcePackname = "R3D.CRAFT_SmoothRealism_32x_v0.1.1.zip";
                    }
                    if (comboBox1.SelectedIndex == 4)
                    {
                        webLink = "https://dl.dropboxusercontent.com/s/vcqyw04g5vugwed/%5B1.6.2%5D_R3D.CRAFT_Smooth_Realism_512x_v0.1.1.zip?dl=1&token_hash=AAEaLUi3s7b-6AxwDCYTB9D2BU4s2Mmc7uoGwu8_hroOCw";
                        resourcePackname = "R3D.CRAFT_SmoothRealism_32x_v0.1.1.zip";
                    }
                }
                if (listBox1.SelectedIndex == 4)            //PaperCutOut
                {
                    if (comboBox1.SelectedIndex == 0)
                    {
                        webLink = "http://cdn.planetminecraft.com/files/resource_media/texture/paper_cutout_2_01.zip";
                        resourcePackname = "Paper_CutOut_2_01.zip";
                    }
                }
                webClient.DownloadFileAsync(new Uri(webLink), appDataPath+mc+@"\resourcepacks\" + resourcePackname);
                webClient.DownloadFileCompleted += new AsyncCompletedEventHandler(DownloadCompleted);
                webClient.DownloadProgressChanged += new DownloadProgressChangedEventHandler(web_DownloadProgressChanged1);
            }
            catch (WebException x)
            {
                error = x.ToString();
                log(104);
            }
            catch (DirectoryNotFoundException a)
            {
                error = a.ToString();
                log(102);
            }
            catch (Exception b)
            {
                error = b.ToString();
                log(100);
            }
        }

        private void TexturePacks_Load(object sender, EventArgs e)
        {
            if (!Directory.Exists(desktop + @"\RandomSurvival\ResourcePacks"))
            {
                Directory.CreateDirectory(desktop + @"\RandomSurvival\ResourcePacks");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex == 0)
            {
                System.Diagnostics.Process.Start("http://www.minecraftdl.com/sphax-purebdcraft-texture-pack");
            }
            if (listBox1.SelectedIndex == 1)
            {
                System.Diagnostics.Process.Start("http://www.minecraftdl.com/sixtygig-texture-pack/");
            }
            if (listBox1.SelectedIndex == 2)
            {
                System.Diagnostics.Process.Start("http://www.minecraftdl.com/r3d-craft-texture-pack/");
            }
            if (listBox1.SelectedIndex == 3)
            {
                System.Diagnostics.Process.Start("http://www.minecraftdl.com/davids-detailed-texture-pack/");
            }
            if (listBox1.SelectedIndex == 4)
            {
                System.Diagnostics.Process.Start("http://www.minecraftdl.com/paper-cutout-texture-pack/");
            }
        }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }
    }
}
