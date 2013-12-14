using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace RandomSurvival_Jar_Installer
{
    public partial class Gyik : Form
    {
        public List<string> _kerdesek = new List<string>();
        public Gyik()
        {
            InitializeComponent();
            _kerdesek.Add("----------------------------------------");
            _kerdesek.Add("Hogyan lehet telkem?");
            _kerdesek.Add("Hogyan tudok GoldBlockot szerezni?");
            _kerdesek.Add("Hogyan tudok pénzt szerezni?");
            _kerdesek.Add("Mit tudok a pénzzel kezdeni?");
            _kerdesek.Add("Mik azok az eventek és hol vannak?");
            _kerdesek.Add("Mi az a MobArena?");
            _kerdesek.Add("Milyen parancsokat használhatok?");
            _kerdesek.Add("Mi az a spammolás?");
            _kerdesek.Add("Mit jelentenek a színek?");
            _kerdesek.Add("Hogyan lehetek Builder?");
            _kerdesek.Add("Hogyan lehetek Moderátor?");
            _kerdesek.Add("Hogyan lehetek Admin?");
            _kerdesek.Add("Kitől kérhetek segítséget?");
            _kerdesek.Add("Mi az a Forge?");
            _kerdesek.Add("Nem működik a Minecraftom! Mit csináljak?");
            _kerdesek.Add("Nem működnek a letöltött modok, mit tegyek?");
            listBox1.DataSource = _kerdesek;
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex == 0)
            {
                richTextBox1.Text = "Válassz kérdést a bal oldalon lévő listából. Ha nincsen a kérdésed a listán, kérlek szólj nekünk játékon belül.\n\nInterakció: küldj nekünk e-mailt, hogy hamarabb hozzáadhassuk a kérdésedet a programhoz, és válaszoljunk rá!";
                button2.Visible = true;
                button2.Text = "E-Mail";
            }
            if (listBox1.SelectedIndex == 1)
            {
                richTextBox1.Text = "Telked úgy lehet, hogy GoldBlockért veszel. Egy telek városon belül 24 goldblock, városon kívül és villakerületben pedig a programban található kalkulátort használjuk a telek árának kiszámításához. Ezt te is megteheted, ha a megfelelő parancsokat használod. \n\nInterakció: a parancsok listájáért kattints a Parancsok gombra.";
                button2.Visible = true;
                button2.Text = "Parancsok";
            }
            if (listBox1.SelectedIndex == 2)
            {
                button2.Visible = false;
                richTextBox1.Text = "GoldBlockot több módon is szerezhetsz. \n1: Bányászol addig amíg nem jön össze elég aranyérc GoldBlock előállításához, vagy \n2: Eventekre jársz, MobArénába mész, ahol pénzt kapsz, ezáltal a Boltban tudsz vásárolni GoldBlockot.";
            }
            if (listBox1.SelectedIndex == 3)
            {
                richTextBox1.Text = "Pénzt Eventeken tudsz szerezni. Ha teljesítesz egy eventet, és megnyomod a gombot a végén, akkor az egy adott összeget ír a számládra jóvá. A számládon található pénzből vásárolhatsz a boltban. Hogy hogyan jutsz el a boltba és hogyan ellenőrzöd a számládon lévő összeget, nézd meg a parancsokat.\n\nInterakció: a parancsok listájáért kattints a Parancsok gombra.";
                button2.Visible = true;
                button2.Text = "Parancsok";
            }
            if (listBox1.SelectedIndex == 4)
            {
                button2.Visible = false;
                richTextBox1.Text = "A szerzett pénzt nem csak GoldBlockra, hanem CommandBlockon kívül az összes Minecraftban megtalálható block megvásárlására is költheted, illetve felszerelésedet is fejlesztheted/javíthatod vele.";
            }
            if (listBox1.SelectedIndex == 5)
            {
                richTextBox1.Text = "Az eventek különböző minijátékok, amik teljesítéséért pénzjutalom jár. Egy event nehézségétől és hosszúságától függ a teljesítéséért járó jutalom mennyisége. 24 óránként teljesítheted pénzjutalomért az eventeket, de ha 24 órán belül kétszer teljesítesz egy eventet, az csak egyszer ad neked pénzt. Hogy hogyan jutsz az eventekhez, azt megnézheted a Parancsok listájában. \n\nInterakció: a parancsok listájáért kattints a Parancsok gombra";
                button2.Visible = true;
                button2.Text = "Parancsok";
            }
            if (listBox1.SelectedIndex == 6)
            {
                richTextBox1.Text = "A MobAréna egy olyan speciálisan kialakított aréna, ahol különböző hullámokban különböző típusú és erősségű mobok támadnak rád. A feladat csupán 1 dolog: éld túl. Minél tovább túléled, annál nagyobb jutalmat kapsz. 4 féle kaszt közül választhatsz, mielőtt bemész a MobArénába, ezek mind különböző dolgokban jók. Érdemes többen menni, ugyanis a nyeremény nem oszlik meg, de a túlélés esélye megnő jelentősen. Hogy hogyan juthatsz a mobarénába, azt megtudhatod a parancsok listájából. \n\nInterakció: a parancsok listájáért kattints a Parancsok gombra";
                button2.Text = "Parancsok";
                button2.Visible = true;
            }
            if (listBox1.SelectedIndex == 7)
            {
                richTextBox1.Text = "A parancsokat rangokra osztva megtalálod ebben a programban. Hogy megnézd őket, kattints az alábbi gombra. \n\nInterakció: a parancsok listájáért kattins a Parancsok gombra";
                button2.Visible = true;
                button2.Text = "Parancsok";
            }
            if (listBox1.SelectedIndex == 8)
            {
                button2.Visible = false;
                richTextBox1.Text = "A spammolás egy olyan tevékenység, amely ugyanazon üzenet többszöri leírását jelenti, például:\nMiért?\nMiért?\nMiért?\nMiért? Rendkívül idegesítő jelenség, amely büntetéseként némítás jár a spammoló játékosra. Kérünk mindenkit, hogy ha spammoló játékost lát, próbálja meg felhívni a figyelmét arra, hogy ez idegesítő dolog.";
            }
            if (listBox1.SelectedIndex == 9)
            {
                button2.Visible = false;
                richTextBox1.Text = "A színek különböző rangokat jelentenek:\nFehér: Newbie, azaz kezdő, ilyen mindenki alapból\nSárga: Builder, azaz van saját telke\nPiros: Moderátor, a szerver csapatának tagja, tőle kérhetsz segítséget\nVilágoskék: VIP,A szerver támogatója\nIndigókék: Admin, a szerver tulajdonosai és karbantartói, technikai kérdésekkel fordulj hozzájuk.";
            }
            if (listBox1.SelectedIndex == 10)
            {
                button2.Visible = false;
                richTextBox1.Text = "Builder úgy lehetsz, hogy saját telket szerzel magadnak. Ha megvan a telek árának megfelelő GoldBlock, szólsz egy moderátornak vagy adminnak, aki ad neked egy telket, ezáltal a rangod automatikusan Builder lesz.";
            }
            if (listBox1.SelectedIndex == 11)
            {
                button2.Visible = false;
                richTextBox1.Text = "Moderátor csak úgy lehetsz, ha megfelelsz a felvételi kritériumoknak, és éppen van moderátor felvétel. Ez egy bizalmi feladat, alaposan ismernünk kell ahhoz, hogy megkaphasd ezt a rangot. Érdeklődj egy adminnál, hogy van-e felvétel.";
            }
            if (listBox1.SelectedIndex == 12)
            {
                button2.Visible = false;
                richTextBox1.Text = "Az Admin rang átlag játékos számára elérhetetlen feladatkör. Ezt a rangot csak olyan Moderátorok érdemlik ki, akik rengeteget tesznek a szerverért, és a főadminok megfelelőnek találják őt ehhez a ranghoz.";
            }
            if (listBox1.SelectedIndex == 13)
            {
                button2.Visible = false;
                richTextBox1.Text = "Bátran fordulhatsz segítségért akárkihez. Játékkal kapcsolatos (hogyan craftoljak?) kérdéseket a teljes népnek felteheted, szerverrel kapcsolatos kérdéseket és hibákat (nem jó a bolt..:( ) egy Moderátornak jelentsd, aki továbbítja egy adminnal a kérdést, játéktechnikai kérdésekkel (nem jók a modok, crashel a kliensem, kifagyok stb...) pedig egy Adminhoz fordulhatsz bizalommal.";
            }
            if (listBox1.SelectedIndex == 14)
            {
                button2.Visible = false;
                richTextBox1.Text = "A Forge egy olyan modbetöltő mod, amely szükséges a programban található extra modok futtatásához. Hogy Forge ModLoadered legyen, ezáltal futtathasd a modokat, a legegyszerűbb dolog az, ha a programban található Minecraft Cracked klienst letöltöd, ami tartalmaz sok verzióhoz Forge-os klienst. Egy legördülő listából választhatsz Minecraft verziót a programban, itt a Forge használatához használd a '1.x.x_Forge' verziót. Külsőleg is telepítheted, ennek metódusához látogass el az alábbi oldalra: http://www.minecraftdl.com/forge-modloader-fml-mod/";
            }
            if (listBox1.SelectedIndex == 15)
            {
                button2.Visible = false;
                richTextBox1.Text = "Kérlek lépj velünk kapcsolatba Facebookon, és megpróbáljuk megoldani a problémádat! Szükségünk lesz 1-2 dologra, amit majd ott, a problémától függően megkapsz, és ha elküldöd nekünk, könnyebben segíthetünk.";
            }
            if (listBox1.SelectedIndex == 16)
            {
                button2.Visible = false;
                richTextBox1.Text = "Valószínűsíthetően a Forge verziója nem kompatibilis a moddal. A Forge egy dinamikusan, naponta fejlődő mod, melyben számos dolog változik minden egyes kiadással, és ezt nem tudja sok modfejlesztő követni. Mivel a programban található Forge folyamatosan frissül, a modok viszont nem, használd a Tisztítás gombot, majd próbálj meg ";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex == 1 || listBox1.SelectedIndex == 3 || listBox1.SelectedIndex == 5 || listBox1.SelectedIndex == 6 || listBox1.SelectedIndex == 7)
            {
                Form2 parancsok = new Form2();
                parancsok.ShowDialog();
            }
            if (listBox1.SelectedIndex == 0)
            {
                System.Diagnostics.Process.Start("mailto:ezres@outlook.com,survival.random@gmail.com?subject=GYIK");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
