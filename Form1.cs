/*
 * Copyright @ Paramod Softworks
 *   1.0.3 verzió
 *  2013.12.14;
 * Amit még csinálni kell:
 * -Bugok keresése
 * -Transporter plugin parancsok hozzáadása
 * 
 * Legutóbbi módosítások:
 * -Gyik UI
 * 
 * 100: ismeretlen hiba
 * 101: A választott verzió támogatása elévült
 * 102: A választott elérési út nem létezik
 * 103: A választott mod letöltése közben hiba történt
 * 104: Nem sikerült csatlakozni az internetre
 * 105: A mappa nem található
 * 106: A fájl elérési útja megváltozott, vagy a fájl nem található
 * 107: Az érték nem megfelelő
 * 108: Memória túlcsordulás
 * 109: Szerver hiba (a fájl nem található a szerveren)
 */ 
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Net;
using System.Diagnostics;
using System.Reflection;

namespace RandomSurvival_Jar_Installer
{
    public partial class Form1 : Form
    {
        #region Változók
        Form2 parancsok = new Form2();
        PanelLogin pl = new PanelLogin();
        public string appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData).ToString(); //C:\users\név\appdata\roaming\
        public string envPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop).ToString() + @"\error.txt"; //C:\users\név\asztal\error.txt
        public string desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        public string date = DateTime.Now.ToString();
        public string mc; //tárolja az adott minecraft típus appdatán belül elfoglalt helyét például: .minecraft vagy .hu-minecraft
        public string filePath;
        public string version;
        public string folderName;
        public string fName;
        public bool isOpenedAlready = false;
        #region licensz
        public string licence = "Copyright (c) 2013, RandomSurvival. Minden jog fenntartva! \nEngedélyezett a forráskód és bináris formában történő felhasználás és terjesztés, módosítással vagy anélkül, amennyiben a következő feltételek teljesülnek: \nA forráskód terjesztésekor meg kell őrizni a fenti szerzői jogi megjegyzést, ezt a feltétellistát és a következő nyilatkozatot. \nBináris formában történő terjesztéskor tovább kell adni a fenti szerzői jogi megjegyzést, ezt a feltétellistát és a következő nyilatkozatot a dokumentációban, illetve a csomaggal részét képező egyéb anyagokban. \nSem a RandomSurvival neve, sem pedig a hozzájárulók neve nem használható fel előzetes írásbeli engedély nélkül a szoftverből származtatott termékek hitelesítésére vagy reklámozására. EZT A SZOFTVERT A SZERZŐI JOG TULAJDONOSAI ÉS A HOZZÁJÁRULÓK ÚGY BIZTOSÍTJÁK, „AHOGY VAN”, ÉS SEMMILYEN NYÍLT VAGY BURKOLT GARANCIA – BELEÉRTVE, DE NEM ERRE KORLÁTOZVA AZ ELADHATÓSÁGOT VAGY EGY ADOTT CÉLRA VALÓ ALKALMATOSSÁGOT – NEM ÉRVÉNYESÍTHETŐ. A SZERZŐI JOG TULAJDONOSAI ÉS A HOZZÁJÁRULÓK SEMMILYEN ESETBEN SEM VONHATÓK FELELŐSSÉGRE A SZOFTVER HASZNÁLATÁBÓL EREDŐ SEMMILYEN KÖZVETLEN, KÖZVETETT, VÉLETLENSZERŰ, KÜLÖNLEGES, PÉLDAADÓ VAGY SZÜKSÉGSZERŰ KÁROKÉRT (BELEÉRTVE, DE NEM ERRE KORLÁTOZVA A HELYETTESÍTŐ TERMÉKEK VAGY SZOLGÁLTATÁSOK BESZERZÉSÉT, ÜZEMKIESÉST, ADATVESZTÉST, ELMARADT HASZNOT VAGY ÜZLETMENET MEGSZAKADÁSÁT), BÁRHOGY IS KÖVETKEZETT BE, VALAMINT A FELELŐSSÉG BÁRMILYEN ELMÉLETÉVEL – AKÁR SZERZŐDÉSBEN, AKÁR OKOZOTT KÁRBAN (BELEÉRTVE A HANYAGSÁGOT ÉS EGYEBET), AKKOR IS, HA AZ ILYEN KÁR LEHETŐSÉGÉRE FELHÍVTÁK A FIGYELMET";
        #endregion
        public long expandVertData;
        public const double osztoVilla = 0.00030896087;
        public const double osztoVarosonKivul = 0.00008850702;
        public bool isOverwriteable = false;
        public string error;
        ProgressBar progressBar = new ProgressBar();
        System.Windows.Forms.Timer timer0 = new System.Windows.Forms.Timer();
        WebClient webClient = new WebClient();
        WebClient webClient1 = new WebClient();
        #region Listák
        List<string> _tipus = new List<string>();
        List<string> _verzio = new List<string>();
        List<string> _telekhely = new List<string>();
        List<string> _modok = new List<string>();
        List<string> _jarok = new List<string>();
        List<string> _tippek = new List<string>();
        #endregion
        #endregion
        public Form1()
        {
                 InitializeComponent();
                #region Lista feltöltése
                _tipus.Add("Sima Minecraft (Crackelt vagy Eredeti)");
                _tipus.Add("Hu-Minecraft");
                _tipus.Add("EmpireCraft");
                _tipus.Add("MesterMC");
                _tipus.Add("CoolCraft");
                _tipus.Add("DiceCraft");
                _tipus.Add("Nincs a listán, segíts!");
                _verzio.Add("1.6.2");
                _verzio.Add("1.6.4");
                _telekhely.Add("Városon kívül");
                _telekhely.Add("Villa");
                _modok.Add("Not Enough Items");
                _modok.Add("OptiFine");
                _modok.Add("Animated Player");
                _modok.Add("FPS Plus");
                _modok.Add("Dynmap");
                _modok.Add("Mouse Tweaks");
                _modok.Add("JourneyMap");
                _modok.Add("MapWriter");
                _modok.Add("HudPlus");
                _modok.Add("AutoRespawn");
                _jarok.Add("1.6.2");
                _jarok.Add("1.6.4");
                _tippek.Add("Tudtad hogy a szerveren igényelhetsz magadnak saját stargatet vagy warpot, goldblockért?");
                _tippek.Add("Tudtad hogy több otthonod is lehet, ha a /sethome után beírod az otthon kívánt nevét?");
                _tippek.Add("Tudtad hogy igazából 5 admin van, de ebből 1 nem jár fel? (nagya2613)");
                _tippek.Add("Tudtad hogy a Minecraft eredetileg egy programozói versenyen készült projekt volt, amit Notch továbbfejlesztett?");
                _tippek.Add("Ha egy tállal jobbegérrel rákattintasz egy gombatehénre, gombalevest kapsz.");
                _tippek.Add("A piston nem tolja el az obszidiánt és a bedrockot.");
                _tippek.Add("A farkas nem támadja meg a creepert, a macska viszont elriasztja.");
                _tippek.Add("A creeper és a skeleton nem lát téged üvegen keresztül.");
                _tippek.Add("Ha vihar van, nappal is tudsz aludni (ilyenkor újra nappal lesz, vihar nélkül).");
                _tippek.Add("Egy endermant nem tudsz eltalálni se tojással, se hógolyóval, de még nyíllal sem.");
                _tippek.Add("A magmakocka nem sérül esés után.");
                _tippek.Add("Ha egy skeleton alatt vagy, önmagát fogja meglőni.");
                _tippek.Add("A Ghast hangja, a játék hangmérnökének macskájától jött.");
                _tippek.Add("A redstone fáklya nem olvasztja meg a jeget vagy a havat.");
                _tippek.Add("A Ghast nem tudja felrobbantani a zúzottkövet.");
                _tippek.Add("Az enderman lenyugszik, ha vízhez ér.");
                _tippek.Add("Egyik pók sem tud jégen felmászni.");
                _tippek.Add("A macska nem sérül az eséstől.");
                _tippek.Add("Egy creeper fel tud mászni a létrán, annak ellenére hogy nincs keze.");
                _tippek.Add("Átlagosan 12 block magasságban van a legtöbb gyémánt.");
                _tippek.Add("Egy chunkon belül átlag 3 gyémánt és 9 arany van.");
                _tippek.Add("Egy teljesen felhúzott íj nagyobb kárt okoz mint a gyémántkard.");
                _tippek.Add("Ha 7-szer ütsz meg egy bárányt, majd mindkét egérgombot lenyomva megnyírod egy ollóval, 5 gyapjút is kaphatsz.");
                _tippek.Add("A creeper modellje egy elrontott malacmodell.");
                _tippek.Add("Pókhálóban a creeper később robban fel.");
                _tippek.Add("Az endben nem csalogathatsz állatokat kajával :(");
                _tippek.Add("Ha a seedet üresen hagyod, a számítógéped helyi idejét fogja használni seednek.");
                _tippek.Add("A gomba biomon nem teremnek szörnyek a barlangokban.");
                _tippek.Add("Ne pazarold a kardodat! Használj inkább ollót a pókhálók levágásához.");
                _tippek.Add("A barlangi pók megmérgezi a csontvázat, de nem öli meg, mert NPC");
                _tippek.Add("Hard és Hardcore módon kívül nem halsz meg mérgezéstől, csak fél szíved lesz.");
                _tippek.Add("A lélekhomokba ütköző hajók nem törnek szét.");
                _tippek.Add("Könnyebb halat fogni, ha esik az eső.");
                _tippek.Add("A magmakocka nem tud úszni a lávában.");
                _tippek.Add("A kis slime nem bántja a játékost, de a kis magmakocka igen.");
                _tippek.Add("Ha egy pók leesik, vagy nekimegy egy kaktusznak, újra semleges lesz.");
                _tippek.Add("A víz és a láva 5 block távolságig megtalálja a legközelebbi lyukat.");
                _tippek.Add("A falap nem tud lángra kapni.");
                _tippek.Add("Víz alatt is tudsz halat fogni.");
                _tippek.Add("Ha 79% vagy feletti az életed, nem kezd el regenerálódni magától.");
                _tippek.Add("Ha a búza földblockja alá egy kerítést raksz, nem fogod tudni letaposni.");
                _tippek.Add("Minden Minecraft világban van egy Mycelium block egy barlangban.");
                _tippek.Add("Ha beleállsz a hóemberbe, az arcát fogod látni nem pedig a tököt.");
                _tippek.Add("A leghatékonyabb eszköz sütésre szén helyett a vödör láva. 1000 másodpercig ég és 1000 itemet süthetsz vele");
                _tippek.Add("Ha keresztüllősz egy nyilat a láván, lángolni fog és Fire Damage-e is lesz.");
                _tippek.Add("Ha felgyújtasz egy tehenet vagy malacot, sült húst fog dobni.");
                _tippek.Add("Van egy rendkívül kicsi esély arra, hogy az eső feltölti az üstöt.");
                _tippek.Add("Nem tudsz kinyitni egy chestet, ha egy macska ül rajta.");
                _tippek.Add("Ha egy sapling útjában egy üveglap van amikor megnő, eltűnteti azt.");
                _tippek.Add("A félblockok nem törik meg a redstone jelet.");
                _tippek.Add("Azok a skeletonok és zombik akik lélekhomokon állnak, nem égnek el nappal.");
                _tippek.Add("Nem vihetsz kutyát a netherbe.");
                _tippek.Add("A betanított kutya megtámad téged, ha meglövőd magad egy nyíllal.");
                _tippek.Add("Az olló nem sérül a gyapjúblock vágásakor.");
                _tippek.Add("Ha kilősz egy robbanni készülő TNT-re egy nyilat, az visszapattan rád.");
                _tippek.Add("A sebző potion gyógyítja, a gyógyító potion sebzi a skeletont.");
                _tippek.Add("A víz elpusztítja a pókhálót.");
                _tippek.Add("Az enderdragon nem pusztítja el a minecartban lévő chestet.");
                _tippek.Add("Ha 256 blockon belül van kiút, a hóember megpróbál kijutni.");
                _tippek.Add("Hard fokozaton a zombi megfertőzi a falusiakat.");
                _tippek.Add("Az alapból generált NPC faluk száma egy átlagos mapon: 4. Ez változhat, ha újabb területeket generál a rendszer.");
                _tippek.Add("Modok nélkül, csalással, csak malac spawnert szerezhetsz.");
                _tippek.Add("Steve maximum 2304 köbméternyi anyagot tud a hátizsákjában cipelni.");
                _tippek.Add("Hajóban vagy Minecartban nem sérülsz az eséstől.");
                _tippek.Add("10 percbe és 40 másodpercbe telik 64 darab item megsütése.");
                _tippek.Add("A rózsák ritkábbak mint a pitypangok.");
                _tippek.Add("Tököt nehezebb találni mint gyémántot.");
                _tippek.Add("Az obszidián alapból nem generálódik, hanem akkor készül, amikor álló lávához hozzáér a víz.");
                _tippek.Add("Az esési sérülés mértéke: m-3, ahol m=magasság (a 4. blocktól kezdve sérülsz)");
                _tippek.Add("Az összes tehén nőstény, mert tejet ad ha jobb egérrel rákattintasz, miközben egy vödör van a kezedben");
                _tippek.Add("Ha megütsz egy farkast, miközben egy kutya vigyáz rád, a kutya megöli a farkast, majd téged is");
                _tippek.Add("A falusi a 4. legmagasabb mob. Steve-nél is magasabb");
                _tippek.Add("A végső ütés az enderdragonnak nem károsítja az eszközeidet");
                _tippek.Add("Herobrine mindig ki lett törölve beta 1.6.6 óta");
                _tippek.Add("5 olyan mob van, amelyik ehető tárgyat dob: malac, tehén, csirke, zombi és malaczombi.");
                _tippek.Add("4 perc 10 másodperc ököllel felszedni egy obszidiánt");
                _tippek.Add("3 milliárd block TNT eltűntet egy bedrockot");
                _tippek.Add("Az aranyalma a való életben 154 tonnát nyomna. Pont, mint egy kisebb bálna.");
                #endregion
                listBox1.DataSource = _tipus;
                listBox2.DataSource = _verzio;
                listBox3.DataSource = _telekhely;
                comboBox2.DataSource = _modok;
                comboBox1.DataSource = _jarok;
                label7.Text = null;
                TipOfTheDay();
        }
        private void button1_Click(object sender, EventArgs e) //fájl átmásolása gombnyomásra
        {
            try
            {
                if (listBox2.SelectedIndex == 0)
                {
                    DialogResult dres = MessageBox.Show("Telepíteni szeretnéd az előzőleg letöltött klienst?", "Megerősítés", MessageBoxButtons.YesNoCancel);
                    if (dres == DialogResult.Yes)
                    {
                        File.Copy(appDataPath + mc + @"\RandomSurvival\1.6.2.jar", appDataPath + mc + version + @"1.6.2.jar", isOverwriteable);
                        MessageBox.Show("A művelet sikeres!", "Siker!");
                    }
                    if (dres == DialogResult.No || dres == DialogResult.Cancel)
                    {

                    }
                }
                if (listBox2.SelectedIndex == 1)
                {
                    DialogResult dres = MessageBox.Show("Telepíteni szeretnéd az előzőleg letöltött klienst?", "Megerősítés", MessageBoxButtons.YesNoCancel);
                    if (dres == DialogResult.Yes)
                    {
                        File.Copy(appDataPath + mc + @"\RandomSurvival\1.6.4.jar", appDataPath + mc + version + @"1.6.4.jar", isOverwriteable);
                        MessageBox.Show("A művelet sikeres!", "Siker!");
                    }
                    if (dres == DialogResult.No || dres == DialogResult.Cancel)
                    {

                    }
                }
            }
            catch (FileNotFoundException a)
            {
                error = a.ToString();
                log(102);
            }
            catch (FileLoadException b)
            {
                error = b.ToString();
                log(106);
            }
        }
        private void button2_Click(object sender, EventArgs e) //biztonsági mentés készítése
        {
            try
            {
                DialogResult result = MessageBox.Show("Ahhoz, hogy mentést készíthets, ugyanúgy ki kell jelölnöd a meglévő verziót, amit szeretnél menteni!\n\nBiztos, hogy a kívánt verzió van kijelölve?", "Figyelmeztetés", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    FolderBrowserDialog fbd = new FolderBrowserDialog();
                    DialogResult dres = fbd.ShowDialog();
                    if (dres == DialogResult.OK)
                    {
                        fbd.RootFolder = Environment.SpecialFolder.Desktop;
                        folderName = fbd.SelectedPath.ToString();
                    }
                    if (Directory.Exists(folderName))
                    {
                        File.Copy(appDataPath + mc + version, folderName);
                        MessageBox.Show("Mentés sikeres a következő helyre:\n" + folderName);
                    }
                }
                if (result == DialogResult.No)
                {
                    MessageBox.Show("Jelöld ki a megfelelő verziót, majd kattints ismét a Mentés gombra!");
                }
            }
            catch (DirectoryNotFoundException a)
            {
                error = a.ToString();
                log(105);
            }
            catch (Exception b)
            {
                error = b.ToString();
                log(100);
            }
        }
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (listBox1.SelectedIndex == 0)  //Sima vagy crackelt
                {
                    mc = @"\.minecraft";
                }
                if (listBox1.SelectedIndex == 1)  //Hu-minecraft
                {
                    mc = @"\.hu-minecraft";
                }
                if (listBox1.SelectedIndex == 2) //EmpireCraft
                {
                    mc = @"\.empirecraft";
                }
                if (listBox1.SelectedIndex == 3) //MesterMC
                {
                    mc = @"\.MesterMC.hu";
                }
                if (listBox1.SelectedIndex == 4)  //CoolCraft
                {
                    mc = @"\.coolcraft";
                }
                if (listBox1.SelectedIndex == 5) //DiceCraft
                {
                    mc = @"\.dicecraft.eu";
                }
                if (listBox1.SelectedIndex == 6)  //Nincs a listán --> facebookra irányít
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
        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (listBox2.SelectedIndex == 0) //1.6.2
                {
                    version = @"\versions\1.6.2\";
                }
                if (listBox2.SelectedIndex == 1) //1.6.4
                {
                    version = @"\versions\1.6.4\";
                }
            }
            catch (Exception a)
            {
                error = a.ToString();
                log(101);
            }
        }
        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start("http://www.facebook.com/RandomSurvival");
            }
            catch (Exception a)
            {
                error = a.ToString();
                log(100);
            }
        }
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start("http://www.randomsurvival.uw.hu");
            }
            catch (Exception a)
            {
                error = a.ToString();
                log(100);
            }
        }
        private void pictureBox3_Click(object sender, EventArgs e)
        {
            try
            {
                string cmd = "mailto:ezres@outlook.com,survival.random@gmail.com?subject=MultiTool";
                System.Diagnostics.Process.Start(cmd);
            }
            catch (Exception a)
            {
                error = a.ToString();
                log(100);
            }
        }
        private void button5_Click(object sender, EventArgs e)
        {

        }
        private void openFileDialog2_FileOk(object sender, CancelEventArgs e)
        {

        }
        public void log(int errorCode)  //logger
        {
            File.AppendAllText(envPath, "\n[" + date + "]\n");
            File.AppendAllText(envPath, "\n" + error);
            DialogResult dres = MessageBox.Show("A program futása közben váratlan hiba lépett fel. \nSzeretnéd megtekinteni a logot? \n\nHibakód: "+errorCode, "Hibakód: "+ errorCode, MessageBoxButtons.YesNo);
            if (dres == DialogResult.Yes)
            {
                System.Diagnostics.Process.Start(envPath); //file megnyitása Process hívással
            }
            if (dres == DialogResult.No)
            {

            }
        }
        private void folderBrowserDialog1_HelpRequest(object sender, EventArgs e)
        {

        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                expandVertData = Convert.ToInt64(textBox1.Text.ToString());
            }
            catch (Exception k)
            {
                k.ToString();
                MessageBox.Show("A mezőben csak számok lehetnek!");
            }
        } //telekár-számító
        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
        private void listBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (listBox3.SelectedIndex == 0)
                {
                    double ertek = expandVertData * osztoVarosonKivul * 0.6;                //telekár kedvezménnyel
                    if (ertek <= 1)
                    {
                        textBox3.Text = "Túl kicsi érték!";
                    }
                    textBox3.Text = Math.Ceiling(ertek).ToString();
                }
                if (listBox3.SelectedIndex == 1)
                {
                    double ertek = expandVertData * osztoVilla * 0.6;               //telekár kedvezménnyel
                    textBox3.Text = Math.Ceiling(ertek).ToString();
                }
            }
            catch (Exception a)
            {
                error = a.ToString();
                log(107);
            }
        }
        private void pictureBox4_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("Szeretnéd megtekinteni a felhasználói szerződést?", "EULA", MessageBoxButtons.YesNo);
            if (res == DialogResult.Yes)
            {
                MessageBox.Show(licence);
            }
            if (res == DialogResult.No)
            {

            }
        }
        private void button4_Click(object sender, EventArgs e)
        {
        }


        private void progressBar1_Click(object sender, EventArgs e)
        {

        }
        private void DownloadCompleted(object sender, AsyncCompletedEventArgs e)
        {
            MessageBox.Show("Letöltés kész!", "Kész!");
            label7.Text = null;
            progressBar1.Value = 0;
        }
        private void button4_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (isOpenedAlready == false)
                {
                    MessageBox.Show("Ezekhez a modokhoz Forge ModLoaderrel modolt kliens szükséges. Ezt a legegyszerűbben úgy érheted el, hogy a programban található Minecraft Cracked-et letöltöd, ebben pedig a listából kiválasztod az 1.6.x_Forge klienst.", "Információ");
                    isOpenedAlready = true;
                }
                if (isOpenedAlready == true)
                {

                }
                if (!Directory.Exists(appDataPath + mc + @"\mods"))
                {
                    Directory.CreateDirectory(appDataPath + mc + @"\mods");
                }
                if (listBox2.SelectedIndex == 0)
                {
                    if (comboBox2.SelectedIndex == 0)
                    {
                        if (File.Exists(appDataPath + mc + @"\mods\CodeChickenCore 0.9.0.6.jar") || File.Exists(appDataPath + mc + @"\mods\NotEnoughItems 1.6.1.5.jar"))
                        {
                            MessageBox.Show("A mod már le van töltve! Letöltöd újra?", "Létező mod");
                        }
                        DialogResult dres = MessageBox.Show("A " + _modok[0] + " mod letöltésére készülsz. A letöltési idő az internetkapcsolatod sebességétől függ. Méret: 575kb. \nFolytatod?", "Letöltés megerősítése", MessageBoxButtons.YesNo);
                        if (dres == DialogResult.Yes)
                        {
                            DialogResult dres1 = MessageBox.Show("A NotEnoughItems modhoz szükséges egy core mod csomag is.\n\nLetöltöd most?", "Core pack letöltés", MessageBoxButtons.YesNo);
                            if (dres1 == DialogResult.Yes)
                            {
                                webClient.DownloadFileAsync(new Uri("http://www.chickenbones.craftsaddle.org/Files/New_Versions/1.6.4/CodeChickenCore%200.9.0.6.jar"), appDataPath + mc + @"\mods\CodeChickenCore 0.9.0.6.jar");
                                webClient.DownloadProgressChanged += new DownloadProgressChangedEventHandler(web_DownloadProgressChanged);
                            }
                           
                                webClient1.DownloadFileAsync(new Uri("http://www.chickenbones.craftsaddle.org/Files/New_Versions/1.6.4/NotEnoughItems%201.6.1.5.jar"), appDataPath + mc + @"\mods\NotEnoughItems 1.6.1.5.jar");
                                webClient1.DownloadProgressChanged += new DownloadProgressChangedEventHandler(web_DownloadProgressChanged);
                                webClient1.DownloadFileCompleted += new AsyncCompletedEventHandler(DownloadCompleted);
                        }
                        if (dres == DialogResult.No)
                        {

                        }
                    }
                    if (comboBox2.SelectedIndex == 1)
                    {
                        DialogResult dres = MessageBox.Show("Az " + _modok[1] + " mod letöltésére készülsz. A letöltési idő az internetkapcsolatod sebességétől függ. Méret: 412kb. \nFolytatod?", "Letöltés megerősítése", MessageBoxButtons.YesNo);
                        if (dres == DialogResult.Yes)
                        {
                            webClient.DownloadFileAsync(new Uri("http://randomsurvival.uw.hu/files/mods/OptiFine.jar"), appDataPath + mc + @"\mods\OptiFine.jar");
                            webClient.DownloadFileCompleted += new AsyncCompletedEventHandler(DownloadCompleted);
                            webClient.DownloadProgressChanged += new DownloadProgressChangedEventHandler(web_DownloadProgressChanged);
                        }
                        if (dres == DialogResult.No)
                        {

                        }
                    }
                    if (comboBox2.SelectedIndex == 2)
                    {
                        DialogResult dres = MessageBox.Show("Az " + _modok[2] + " mod letöltésére készülsz. A letöltési idő az internetkapcsolatod sebességétől függ. Méret: 44kb. \nFolytatod?", "Letöltés megerősítése", MessageBoxButtons.YesNo);
                        if (dres == DialogResult.Yes)
                        {
                            webClient.DownloadFileAsync(new Uri("http://randomsurvival.uw.hu/files/mods/Animated_Player_v1.3.0_mc1.6.4.zip"), appDataPath + mc + @"\mods\Animated_Player_v1.3.0_mc1.6.4.zip");
                            webClient.DownloadFileCompleted += new AsyncCompletedEventHandler(DownloadCompleted);
                            webClient.DownloadProgressChanged += new DownloadProgressChangedEventHandler(web_DownloadProgressChanged);
                        }
                        if (dres == DialogResult.No)
                        {

                        }
                    }
                    if (comboBox2.SelectedIndex == 3)
                    {
                        DialogResult dres = MessageBox.Show("Az " + _modok[3] + " mod letöltésére készülsz. A letöltési idő az internetkapcsolatod sebességétől függ. Méret: 43 kb. \nFolytatod?", "Letöltés megerősítése", MessageBoxButtons.YesNo);
                        if (dres == DialogResult.Yes)
                        {
                            webClient.DownloadFileAsync(new Uri("http://randomsurvival.uw.hu/files/mods/FpsPlus_1.6.4.zip"), appDataPath + mc + @"\mods\FpsPlus_1.6.4.zip");
                            webClient.DownloadFileCompleted += new AsyncCompletedEventHandler(DownloadCompleted);
                            webClient.DownloadProgressChanged += new DownloadProgressChangedEventHandler(web_DownloadProgressChanged);
                        }
                        if (dres == DialogResult.No)
                        {

                        }
                    }
                    if (comboBox2.SelectedIndex == 4)
                    {
                        DialogResult dres = MessageBox.Show("Az " + _modok[4] + " mod letöltésére készülsz. A letöltési idő az internetkapcsolatod sebességétől függ. Méret: 13 Mb. \nFolytatod?", "Letöltés megerősítése", MessageBoxButtons.YesNo);
                        if (dres == DialogResult.Yes)
                        {
                            webClient.DownloadFileAsync(new Uri("http://randomsurvival.uw.hu/files/mods/Dynmap-1.9-forge-9.10.0.jar"), appDataPath + mc + @"\mods\Dynmap-1.9-forge-9.10.0.jar");
                            webClient.DownloadFileCompleted += new AsyncCompletedEventHandler(DownloadCompleted);
                            webClient.DownloadProgressChanged += new DownloadProgressChangedEventHandler(web_DownloadProgressChanged);
                        }
                        if (dres == DialogResult.No)
                        {

                        }
                    }
                    if (comboBox2.SelectedIndex == 5)
                    {
                        DialogResult dres = MessageBox.Show("Az " + _modok[5] + " mod letöltésére készülsz. A letöltési idő az internetkapcsolatod sebességétől függ. Méret: 46kb. \nFolytatod?", "Letöltés megerősítése", MessageBoxButtons.YesNo);
                        if (dres == DialogResult.Yes)
                        {
                            webClient.DownloadFileAsync(new Uri("http://randomsurvival.uw.hu/files/mods/_1.6.4__Mouse_Tweaks_2.3.4.zip"), appDataPath + mc + @"\mods\_1.6.4__Mouse_Tweaks_2.3.4.zip");
                            webClient.DownloadFileCompleted += new AsyncCompletedEventHandler(DownloadCompleted);
                            webClient.DownloadProgressChanged += new DownloadProgressChangedEventHandler(web_DownloadProgressChanged);
                        }
                        if (dres == DialogResult.No)
                        {

                        }
                    }
                    if (comboBox2.SelectedIndex == 6)
                    {
                        DialogResult dres = MessageBox.Show("Az " + _modok[7] + " mod letöltésére készülsz. A letöltési idő az internetkapcsolatod sebességétől függ. Méret: 703kb. \nFolytatod?", "Letöltés megerősítése", MessageBoxButtons.YesNo);
                        if (dres == DialogResult.Yes)
                        {
                            webClient.DownloadFileAsync(new Uri("http://randomsurvival.uw.hu/files/mods/JourneyMap.zip"), appDataPath + mc + @"\mods\JourneyMap.zip");
                            webClient.DownloadFileCompleted += new AsyncCompletedEventHandler(DownloadCompleted);
                            webClient.DownloadProgressChanged += new DownloadProgressChangedEventHandler(web_DownloadProgressChanged);
                        }
                        if (dres == DialogResult.No)
                        {

                        }
                    }
                    if (comboBox2.SelectedIndex == 7)
                    {
                        DialogResult dres = MessageBox.Show("Az "+_modok[7]+" mod letöltésére készülsz. A letöltési idő az internetkapcsolatod sebességétől függ. Méret: 121kb.\nFolytatod?","Letöltés megerősítése",MessageBoxButtons.YesNo);
                        if (dres == DialogResult.Yes)
                        {
                            webClient.DownloadFileAsync(new Uri("http://randomsurvival.uw.hu/files/mapwriter.zip"), appDataPath + mc + @"\mods\mapwriter.zip");
                            webClient.DownloadFileCompleted += new AsyncCompletedEventHandler(DownloadCompleted);
                            webClient.DownloadProgressChanged += new DownloadProgressChangedEventHandler(web_DownloadProgressChanged);
                        }
                        if (dres == DialogResult.No)
                        {

                        }
                    }
                    if (comboBox2.SelectedIndex == 8)
                    {
                        DialogResult dres = MessageBox.Show("Az " + _modok[8] + " mod letöltésére készülsz. A letöltési idő az internetkapcsolatod sebességétől függ. Méret: 17kb.\nFolytatod?", "Letöltés megerősítése", MessageBoxButtons.YesNo);
                        if (dres == DialogResult.Yes)
                        {
                            webClient.DownloadFileAsync(new Uri("http://randomsurvival.uw.hu/files/hudplus.zip"), appDataPath + mc + @"\mods\hudplus.zip");
                            webClient.DownloadFileCompleted += new AsyncCompletedEventHandler(DownloadCompleted);
                            webClient.DownloadProgressChanged += new DownloadProgressChangedEventHandler(web_DownloadProgressChanged);
                        }
                        if (dres == DialogResult.No)
                        {

                        }
                    }
                    if (comboBox2.SelectedIndex == 9)
                    {
                        DialogResult dres = MessageBox.Show("Az " + _modok[9] + " mod letöltésére készülsz. A letöltési idő az internetkapcsolatod sebességétől függ. Méret: 2kb.\nFolytatod?", "Letöltés megerősítése", MessageBoxButtons.YesNo);
                        if (dres == DialogResult.Yes)
                        {
                            webClient.DownloadFileAsync(new Uri("http://randomsurvival.uw.hu/files/AutoRespawn.zip"), appDataPath + mc + @"\mods\AutoRespawn.zip");
                            webClient.DownloadFileCompleted += new AsyncCompletedEventHandler(DownloadCompleted);
                            webClient.DownloadProgressChanged += new DownloadProgressChangedEventHandler(web_DownloadProgressChanged);
                        }
                        if (dres == DialogResult.No)
                        {

                        }
                    }
                }
            }
            catch (WebException a)
            {
                error = a.ToString();
                log(104);
            }
            catch (FileNotFoundException a)
            {
                error = a.ToString();
                log(106);
            }
            catch (DirectoryNotFoundException b)
            {
                error = b.ToString();
                log(102);
            }
        }
        private void button5_Click_1(object sender, EventArgs e)
        {
            if (comboBox2.SelectedIndex == 0)
            {
                MessageBox.Show("A Not Enough Items főként a Tekkit ModPackból ismert mod, amely ugyanolyan funkciókat lát el mint a Too Many Items, annyi különbséggel hogy a tudása körülbelül a duplája az utólag említett modnak. Itt az adott tárgyak Craft receptjeit is meg tudjuk tekinteni, illetve lehetőség van arra is, hogy a mod megmutassa, hány item kell még az adott tárgy elkészítéséhez, szükség szerint automatikusan el is készíti nekünk.\n\nVerzió:1.6.1.4 (Core: 0.9.0.5)", _modok[0] + " információ");
            }
            if (comboBox2.SelectedIndex == 1)
            {
                MessageBox.Show("Az OptiFine mod minden játékos számára kötelezőnek mondható kiegészítő. Segítségével a játék grafikai tulajdonságai jelentősen módosíthatóak, az FPS szám akár triplájára is növelhető a részletes beállítási lehetőségnek köszönhetően. Lehetőségünk van szinte mindent átállítani a teljesítménynövekedés érdekében, amely gyengébb gépeken is futtathatóvá teszi a minecraftot, erősebb gépeken pedig még szebbé.\n\nVerzió: 1.6.4 - HD_U_C6", _modok[1] + " információ");
            }
            if (comboBox2.SelectedIndex == 2)
            {
                MessageBox.Show("Az Animated Player mod a játékos teljes mozgását és mimikáját variálja életszerűvé; megjelennek a térdek, megjelennek a könyökök, illetve a szemöldök is, továbbá a játékos fejmozdítás helyett a szemeit mozgatja amikor körülnéz, egyszerűbben: valóságot visz a minecraft karaktereibe",_modok[2] + " információ");
            }
            if (comboBox2.SelectedIndex == 3)
            {
                MessageBox.Show("Az FPS Plus mod - ahogy a neve is mondja - a teljesítmény növeléséért felelős mod. A titka az, hogy az eddigi lineáris világrajzolási metódust lecseréli vektorgrafikus ábrázolásmódra (sinus és cosinus függvényekkel ábrázolja, hozzáértők kedvéért). Körülbelül 30%-os teljesítménynövekedés érhető el a segítségével, ám ez függ a számítógép felépítésétől is.",_modok[3] + " információ");
            }
            if (comboBox2.SelectedIndex == 4)
            {
                MessageBox.Show("A Dynmap a jól ismert Bukkitos plugin ezúttal Singleplayer változata. Használata annyi, hogy elindítod a játékot, kirendereli a világot, majd ha megvan, a böngésződben a \nhttp://localhost:8123 \ncímre navigálsz, ahol máris elkezdi megmutatni neked hogy hogy néz ki a világ. A mod rengeteg Forge-os modot támogat, többek között a BuildCraft-ot és a Tekkit modpack összes modját.", _modok[4] + " információ");
            }
            if (comboBox2.SelectedIndex == 5)
            {
                MessageBox.Show("A Mouse Tweaks egy olyan mod, amely segítségével a játék egérkímélőbb lesz. Segítségével a műveletek sokkal egyszerűbbek lesznek, például automatikusan lerakosgatja a megfogott blockokat a craftablakoknál, mikor elhúzzuk felettük az egérmutatót, és sok egyéb hasznos funkcióval el van látva.", _modok[5] + " információ");
            }
            if (comboBox2.SelectedIndex == 6)
            {
                MessageBox.Show("A JourneyMap egy - a DynMap-hoz hasonló - mod, mely segítségével feltérképezhetjük 3D-ben a körülöttünk lévő világot, amennyiben kirendereltük már azt. Használata egyszerűbb mint a DynMap-nak, de jóval kisebb gépigényű, és játékon belülről is elérhető, viszont kevésbé részletes és mélységi képet nem ad. Játékon belül nyomjuk meg a \n\nJ (mint János) gombot, vagy\nnavigáljunk böngészőnkben a http://localhost:8080 weboldalra a pálya áttekintéséért.", _modok[7] + " információ");
            }
            if (comboBox2.SelectedIndex == 7)
            {
                MessageBox.Show("A MapWriter mod, egy, a minimapok családjába tartozó mod (hasonlóan Rei minimap modjához). Segítségével könnyen követhetjük hogy merre járunk a világban és hogy közvetlen közelünkben mi van. A mod rendelkezik egy olyan funkcióval is, mint a JourneyMap, azaz teljes képernyőn tudjuk követni hogy merre vagyunk éppen és mi van a közelünkben.",_modok[7] + " információ");
            }
            if (comboBox2.SelectedIndex == 8)
            {
                MessageBox.Show("A HudPlus mod egy rendkívül egyszerű, de nagyon nagyon hasznos mod. Segítségével könnyen követhetjük nyomon, hogy viselt felszerelésünk mennyi ütést bír még, mennyire van elkopva. Követhetjük, hogy íjunkhoz mennyi nyíl van még a hátizsákunkban, a jelenlegi és a következő szinthez szükséges tapasztalati pontjainkat, hogy hol járunk koordinátákat tekintve a világban, illetve hogy hány darab van az adott termékből a kezünkben.",_modok[8] + " információ");
            }
            if (comboBox2.SelectedIndex == 9)
            {
                MessageBox.Show("Az AutoRespawn mod egy olyan mod, amely megkönnyíti az életedet, ha sokszor meghalsz a játékban. Mindössze annyit csinál, hogy helyetted megnyomja az Újraéledés gombot, amikor meghalsz. Ennyi. De nagyon hasznos, főleg lustáknak.", _modok[9] + " információ");
            }
        }
        private void label9_Click(object sender, EventArgs e)
        {

        }
        private void button6_Click(object sender, EventArgs e)          //jar letöltése
        {
            try
            {
                if (comboBox1.SelectedIndex == 0)
                {
                    filePath = appDataPath + mc + @"\RandomSurvival\";
                    if (!Directory.Exists(appDataPath + mc + @"\RandomSurvival"))
                    {
                        Directory.CreateDirectory(appDataPath + mc + @"\RandomSurvival");
                    }
                    //if (File.Exists(appDataPath + mc + version + "1.6.2.jar"))
                    //{
                        File.Delete(appDataPath + mc + version + "1.6.2.jar");
                        webClient.DownloadFileAsync(new Uri("http://randomsurvival.uw.hu/files/jar/1.6.2.jar"), filePath + @"1.6.2.jar");
                        webClient.DownloadFileCompleted += new AsyncCompletedEventHandler(DownloadCompleted);
                        webClient.DownloadProgressChanged += new DownloadProgressChangedEventHandler(web_DownloadProgressChanged);
                    //}
                }
                if (comboBox1.SelectedIndex == 1)
                {
                    filePath = appDataPath + mc + @"\RandomSurvival\";
                    if (!Directory.Exists(appDataPath + mc + @"\RandomSurvival"))
                    {
                        Directory.CreateDirectory(appDataPath + mc + @"\RandomSurvival");
                    }
                    //if (File.Exists(appDataPath + mc + version + "1.6.4.jar"))
                    //{
                    File.Delete(appDataPath + mc + version + "1.6.4.jar");
                    webClient.DownloadFileAsync(new Uri("http://randomsurvival.uw.hu/files/jar/1.6.4.jar"), filePath + @"1.6.4.jar");
                    webClient.DownloadFileCompleted += new AsyncCompletedEventHandler(DownloadCompleted);
                    webClient.DownloadProgressChanged += new DownloadProgressChangedEventHandler(web_DownloadProgressChanged);
                    //}
                }
            }
            catch (WebException a)
            {
                error = a.ToString();
                log(104);
            }
            catch (DirectoryNotFoundException a)
            {
                error = a.ToString();
                log(102);
            }
            catch (Exception a)
            {
                error = a.ToString();
                log(100);
            }
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        void web_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            try
            {
                int bytesin = int.Parse(e.BytesReceived.ToString());
                int totalbytes = int.Parse(e.TotalBytesToReceive.ToString());
                int kb1 = bytesin / 1024;
                int kb2 = totalbytes / 1024;
                label7.Text = kb1.ToString() + @"kb\" + kb2 + "kb \t(" + e.ProgressPercentage.ToString() + "%)";
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
        private void DownloadCompleted_alt(object sender, AsyncCompletedEventArgs e)
        {
            DialogResult dres = MessageBox.Show("Letöltés kész! Elindítod a telepítőt most?", "Kész!",MessageBoxButtons.YesNo);
            label7.Text = null;
            progressBar1.Value = 0;
            progressBar1.Visible = false;
            if (dres == DialogResult.Yes)
            {
                System.Diagnostics.Process.Start(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\RandomSurvival\MinecraftCracked_1.6.4.exe");
            }
            
        }
        private void progressBar1_Click_1(object sender, EventArgs e)
        {

        }
        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                if (comboBox1.SelectedIndex == 0)
                {
                    DialogResult dres = MessageBox.Show("Biztosan vissza szeretnéd állítani az eredeti .jar fájlt?", "Visszaálítás", MessageBoxButtons.YesNo);
                    if (dres == DialogResult.Yes)
                    {
                        if (File.Exists(appDataPath + mc + version + "1.6.2.jar"))
                        {
                            File.Delete(appDataPath + mc + version + "1.6.2.jar");
                            webClient.DownloadFileAsync(new Uri("http://randomsurvival.uw.hu/files/jar/clean/1.6.2.jar"), appDataPath + mc + version + "1.6.2.jar");
                            webClient.DownloadFileCompleted += new AsyncCompletedEventHandler(DownloadCompleted);
                            webClient.DownloadProgressChanged += new DownloadProgressChangedEventHandler(web_DownloadProgressChanged);
                        }
                        if (!File.Exists(appDataPath + mc + version + "1.6.2.jar"))
                        {
                            DialogResult dres1 = MessageBox.Show("Jelenleg nincs telepített .jar fájlod. Ez előfordulhatott egy esetleges letöltési hiba miatt.\n\nLetöltöd most az eredeti .jar fájlt?", "Nem létezik", MessageBoxButtons.YesNo);
                            if (dres1 == DialogResult.Yes)
                            {
                                webClient.DownloadFileAsync(new Uri("http://randomsurvival.uw.hu/files/jar/clean/1.6.2.jar"), appDataPath + mc + version + "1.6.2.jar");
                                webClient.DownloadFileCompleted += new AsyncCompletedEventHandler(DownloadCompleted);
                                webClient.DownloadProgressChanged += new DownloadProgressChangedEventHandler(web_DownloadProgressChanged);
                            }
                        }
                    }
                    if (dres == DialogResult.No)
                    {

                    }
                }
                if (comboBox1.SelectedIndex == 1)
                {
                    DialogResult dres = MessageBox.Show("Biztosan vissza szeretnéd állítani az eredeti .jar fájlt?", "Visszaálítás", MessageBoxButtons.YesNo);
                    if (dres == DialogResult.Yes)
                    {
                        if (File.Exists(appDataPath + mc + version + "1.6.4.jar"))
                        {
                            File.Delete(appDataPath + mc + version + "1.6.4.jar");
                            webClient.DownloadFileAsync(new Uri("http://randomsurvival.uw.hu/files/jar/clean/1.6.4.jar"), appDataPath + mc + version + "1.6.4.jar");
                            webClient.DownloadFileCompleted += new AsyncCompletedEventHandler(DownloadCompleted);
                            webClient.DownloadProgressChanged += new DownloadProgressChangedEventHandler(web_DownloadProgressChanged);
                        }
                        if (!File.Exists(appDataPath + mc + version + "1.6.4.jar"))
                        {
                            DialogResult dres1 = MessageBox.Show("Jelenleg nincs telepített .jar fájlod. Ez előfordulhatott egy esetleges letöltési hiba miatt.\n\nLetöltöd most az eredeti .jar fájlt?", "Nem létezik", MessageBoxButtons.YesNo);
                            if (dres1 == DialogResult.Yes)
                            {
                                webClient.DownloadFileAsync(new Uri("http://randomsurvival.uw.hu/files/jar/clean/1.6.4.jar"), appDataPath + mc + version + "1.6.4.jar");
                                webClient.DownloadFileCompleted += new AsyncCompletedEventHandler(DownloadCompleted);
                                webClient.DownloadProgressChanged += new DownloadProgressChangedEventHandler(web_DownloadProgressChanged);
                            }
                        }
                    }
                    if (dres == DialogResult.No)
                    {

                    }
                }
            }
            catch (Exception a)
            {
                error = a.ToString();
                log(100);
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            try
            {
                if (!File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\RandomSurvival\MinecraftCracked_1.6.4.exe"))
                {
                    webClient.DownloadFileAsync(new Uri("http://randomsurvival.uw.hu/files/MinecraftCracked_1.6.4.exe"), Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\RandomSurvival\MinecraftCracked_1.6.4.exe");
                    webClient.DownloadFileCompleted += new AsyncCompletedEventHandler(DownloadCompleted_alt);
                    webClient.DownloadProgressChanged += new DownloadProgressChangedEventHandler(web_DownloadProgressChanged);
                    webClient1.DownloadFileAsync(new Uri("https://dl.dropboxusercontent.com/sh/9sushmg1tzonvcp/93TrKtRr3W/launcheroptions.txt?dl=1&token_hash=AAHqCBXxXRzdkB_BYjJ1yCTlpqmIfnn3GF6kXS6J9rLmbg"), appDataPath + @"\.minecraft\launcheroptions.txt");
                }
                else
                { 
                    DialogResult dres = MessageBox.Show("A fájl már létezik! Letöltöd újra?", "Létező fájl", MessageBoxButtons.YesNo); 
                    File.Delete(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\RandomSurvival\MinecraftCracked_1.6.4.exe");
                    webClient.DownloadFileAsync(new Uri("http://randomsurvival.uw.hu/files/MinecraftCracked_1.6.4.exe"), Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\RandomSurvival\MinecraftCracked_1.6.4.exe");
                    webClient.DownloadFileCompleted += new AsyncCompletedEventHandler(DownloadCompleted_alt);
                    webClient.DownloadProgressChanged += new DownloadProgressChangedEventHandler(web_DownloadProgressChanged);
                    webClient1.DownloadFileAsync(new Uri("https://dl.dropboxusercontent.com/sh/9sushmg1tzonvcp/93TrKtRr3W/launcheroptions.txt?dl=1&token_hash=AAHqCBXxXRzdkB_BYjJ1yCTlpqmIfnn3GF6kXS6J9rLmbg"), appDataPath + @"\.minecraft\launcheroptions.txt");
                }
            }
            catch (DirectoryNotFoundException a)
            {
                error = a.ToString();
                log(105);
            }
            catch (Exception b)
            {
                error = b.ToString();
                log(100);
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            try
            {
                parancsok.ShowDialog();
            }
            catch (Exception a)
            {
                error = a.ToString();
                log(100);
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Gyik gyik = new Gyik();
            gyik.ShowDialog();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            MessageBox.Show("ChangeLog v1.0.3:\n\n-GYIK UI átszabva\n-GYIK ToolTip-ek hozzáadva.\n\nA következő verzióban (1.0.4):\n-Forge modok 1.6.2-höz\n-Új plugin parancsainak hozzáadása");
        }

        private void button12_Click(object sender, EventArgs e)
        {
            pl.ShowDialog();
        }

        private void label17_Click(object sender, EventArgs e)
        {

        }
        private void TipOfTheDay()
        {
            System.Windows.Forms.Timer timer0 = new System.Windows.Forms.Timer();
            timer0.Tick += (timer_);
            timer0.Interval = 10000;
            timer0.Enabled = true;
            timer0.Start();
            label17.Text = null;
        }
        private void timer_(object sender, EventArgs e)
        {
            Random rand = new Random();
            int randomNumb = rand.Next(0, _tippek.Count);
            label17.Text ="Tipp: " + _tippek[randomNumb];
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (!Directory.Exists(desktop + @"\RandomSurvival"))
            {
                Directory.CreateDirectory(desktop + @"\RandomSurvival");
            }
            webClient.DownloadFileAsync(new Uri("https://dl.dropboxusercontent.com/s/kcoxz8vax2lktjo/eventek.txt?dl=1&token_hash=AAEBdVCQXZZ7qVXPBoAQ0O4A74GvSaj_nGythJ3kVITpZA"), desktop + @"\RandomSurvival\eventek.txt");
        }

        private void button13_Click(object sender, EventArgs e)
        {
            TexturePacks tp = new TexturePacks();
            tp.ShowDialog();
        }
        private void button14_Click(object sender, EventArgs e)
        {
            DialogResult dres = MessageBox.Show("Biztos vagy benne hogy törölni szeretnéd az összes letöltött fájlt? Ez nem visszafordítható művelet!\n\nA fájlok törlése hosszú időt vehet igénybe, a géped teljesítményétől függően. Ha a törlés kész, egy értesítést fogsz kapni a programtól.\n\nHa a program befagyna, kérlek várj, mert az azt jelenti, hogy a törlés folyamatban van!", "Biztos vagy benne?",MessageBoxButtons.YesNo);
            if (dres == DialogResult.Yes)
            {
                if (Directory.Exists(desktop + @"\RandomSurvival"))
                {
                    Directory.Delete(desktop + @"\RandomSurvival",true);
                }
                if (Directory.Exists(appDataPath+mc+@"\RandomSurvival"))
                {
                    Directory.Delete(appDataPath + mc + @"\RandomSurvival", true);
                }
                if (File.Exists(appDataPath + mc + @"\mods\[1.6.4]ArmorStatusHUDv1.15.zip") && File.Exists(appDataPath + mc + @"\mods\[1.6.4]bspkrsCorev5.0.zip"))
                {
                    File.Delete(appDataPath + mc + @"\mods\[1.6.4]ArmorStatusHUDv1.15.zip");
                    File.Delete(appDataPath + mc + @"\mods\[1.6.4]bspkrsCorev5.0.zip");
                }
                if (File.Exists(appDataPath + mc + @"\mods\OptiFine.jar"))
                {
                    File.Delete(appDataPath + mc + @"\mods\OptiFine.jar");
                }
                if (File.Exists(appDataPath + mc + @"\mods\JourneyMap.zip"))
                {
                    File.Delete(appDataPath + mc + @"\mods\JourneyMap.zip");
                }
                if (File.Exists(appDataPath + mc + @"\mods\Dynmap-1.9-forge.9.10.0.jar"))
                {
                    File.Delete(appDataPath + mc + @"\mods\Dynmap-1.9-forge.9.10.0.jar");
                }
                if (File.Exists(appDataPath + mc + @"\mods\CodeChickenCore 0.9.0.6.jar"))
                {
                    File.Delete(appDataPath + mc + @"\mods\CodeChickenCore 0.9.0.6.jar");
                }
                if (File.Exists(appDataPath + mc + @"\mods\NotEnoughItems 1.6.1.5.jar"))
                {
                    File.Delete(appDataPath + mc + @"\mods\NotEnoughItems 1.6.1.5.jar");
                }
                if (File.Exists(appDataPath + mc + @"\mods\mapwriter.zip"))
                {
                    File.Delete(appDataPath + mc + @"\mods\mapwriter.zip");
                }
                if (File.Exists(appDataPath + mc + @"\mods\_1.6.4__Mouse_Tweaks_2.3.4.zip"))
                {
                    File.Delete(appDataPath + mc + @"\mods\_1.6.4__Mouse_Tweaks_2.3.4.zip");
                }
                if (File.Exists(appDataPath + mc + @"\mods\Animated_Player_v1.3.0_mc1.6.4.zip"))
                {
                    File.Delete(appDataPath + mc + @"\mods\Animated_Player_v1.3.0_mc1.6.4.zip");
                }
                if (File.Exists(appDataPath + mc + @"\mods\FpsPlus_1.6.4.zip"))
                {
                    File.Delete(appDataPath + mc + @"\mods\FpsPlus_1.6.4.zip");
                }
                MessageBox.Show("A cleanup process végére ért: A fájlok törölve.", "Siker");
            }
            if (dres == DialogResult.No)
            {

            }
        }

        private void button15_Click(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            string[] asd;
            string line;
            using (StreamReader file = new StreamReader(desktop + @"\RandomSurvival\eventek.txt"))
            {
                while ((line = file.ReadLine()) != null)
                {
                    sb.AppendLine(line.ToString());             //Mi | Mikor | Játékosok száma | jelentkezés módja
                    asd = line.Split('|');
                    MessageBox.Show("A jelenlegi eventek: \n\nEvent: " + asd[0] + "\nIdőpont: "+asd[1] +"\nJelentkezni " + asd[2] + "!!!");
                }
            }
        }
    }
}
