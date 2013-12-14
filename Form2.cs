using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace RandomSurvival_Jar_Installer
{
    public partial class Form2 : Form
    {
        #region változók
        List<string> _csoportok = new List<string>();
        List<string> _parancsok_Newbie= new List<string>();
        List<string> _parancsok_Builder = new List<string>();
        List<string> _parancsok_Moderator = new List<string>();
        List<string> _seged1 = new List<string>();
        List<string> _seged2 = new List<string>();
        #endregion
        public Form2()
        {
            InitializeComponent();
            #region Lista feltöltése
            _csoportok.Add("Newbie");
            _csoportok.Add("Builder");
            _csoportok.Add("Moderátor");
            _parancsok_Newbie.Add("back"); //0
            _parancsok_Newbie.Add("reply [név] ");      //1
            _parancsok_Newbie.Add("mail [név] [üzenet]");       //2
            _parancsok_Newbie.Add("helpop");        //3
            _parancsok_Newbie.Add("itemdb");        //4
            _parancsok_Newbie.Add("sethome [home_neve]");       //5
            _parancsok_Newbie.Add("home [home_neve]");      //6
            _parancsok_Newbie.Add("afk");       //7
            _parancsok_Newbie.Add("msg [név] [üzenet]");        //8
            _parancsok_Newbie.Add("tpaccept [név]");        //9
            _parancsok_Newbie.Add("tpdeny [név]");        //10
            _parancsok_Builder.Add("info");        //11
            _parancsok_Builder.Add("clearinventory");        //12
            _parancsok_Builder.Add("enderchest");        //13
            _parancsok_Builder.Add("compass");        //14
            _parancsok_Builder.Add("delhome [home_név]");        //15
            _parancsok_Builder.Add("tpa [név]");        //16
            _parancsok_Builder.Add("tpahere [név]"); //17
            _parancsok_Builder.Add("money");        //17
            _parancsok_Builder.Add("money pay [név] [összeg]");        //18
            _parancsok_Builder.Add("ignore");        //19
            _parancsok_Builder.Add("warp [warp_név]");        //20
            _parancsok_Builder.Add("region addmember [név] [teleknév]");        //21
            _parancsok_Builder.Add("region removemember [név] [teleknév]");        //22
            _parancsok_Builder.Add("region list [neved]");        //23
            _parancsok_Builder.Add("wand");      //24
            _parancsok_Builder.Add("expand vert");             //25
            _parancsok_Builder.Add("recipe [item] [db]");           //26
            _parancsok_Moderator.Add("toggledownfall");        //27
            _parancsok_Moderator.Add("kick [név]");        //28
            _parancsok_Moderator.Add("essentials");        //29
            _parancsok_Moderator.Add("mute [név]");        //30
            _parancsok_Moderator.Add("tempban [név] [év]y [hónap]m [hét]w [nap]d [óra]h [perc]m [másodperc]s");        //31
            _parancsok_Moderator.Add("minden WE parancs");        //32
            _parancsok_Moderator.Add("manuadd [név] [csoport]");        //33
            _parancsok_Moderator.Add("fly"); //34
            _parancsok_Moderator.Add("getpos"); //35
            _parancsok_Moderator.Add("god");    //36   
            _parancsok_Moderator.Add("ext");    //37
            #endregion
            comboBox1.DataSource = _csoportok;
            listBox1.DataSource = _parancsok_Newbie;
            _seged1.AddRange(_parancsok_Newbie);
            _seged1.AddRange(_parancsok_Builder);
            _seged2.AddRange(_seged1);
            _seged2.AddRange(_parancsok_Moderator);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                listBox1.DataSource = _parancsok_Newbie;
            }
            if (comboBox1.SelectedIndex == 1)
            {
                listBox1.DataSource = _seged1;
            }
            if (comboBox1.SelectedIndex == 2)
            {
                listBox1.DataSource = _seged2;
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {

        }
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex == 0)
            {
                richTextBox1.Text = "Visszateleportál";
            }
            if (listBox1.SelectedIndex == 1)
            {
                richTextBox1.Text = ("Válaszol a játékos privát üzenetére.\n\n[név] = A játékos neve akinek válaszolni akarsz");
            }
            if (listBox1.SelectedIndex == 2)
            {
                richTextBox1.Text = "E-Mailt küld játékon belül a játékosnak.\n\n[név] = A játékos neve akinek levelet akarsz írni\n[üzenet] = A levél tartalma";
            }
            if (listBox1.SelectedIndex == 3)
            {
                richTextBox1.Text = ("Segítséget kér egy online staff tagtól.");
            }
            if (listBox1.SelectedIndex == 4)
            {
                richTextBox1.Text = ("Kijelzi a kezedben lévő tárgy adatait, kihasználtságát, ID-jét és egyebeket.");
            }
            if (listBox1.SelectedIndex == 5)
            {
                richTextBox1.Text = ("Beállítja az otthonodat.\n\n[home_neve] = Builder rangtól több otthonod is lehet, ezzel a névvel azonosíthatod az adott otthont..");
            }
            if (listBox1.SelectedIndex == 6)
            {
                richTextBox1.Text = ("Hazateleportál.\n\n[home_neve] = Az adott nevű lakásba teleportál téged, ha Builder vagy és van több otthonod.");
            }
            if (listBox1.SelectedIndex == 7)
            {
                richTextBox1.Text = ("Away From Keyboard státuszba rak, illetve kivesz belőle. Ha AFK vagy és nem tudsz mozogni, használd ezt a parancsot.");
            }
            if (listBox1.SelectedIndex == 8)
            {
                richTextBox1.Text = ("Privát üzenetet küld a játékosnak.\n\n[név] = A játékos neve akinek írni akarsz\n[üzenet] = Az üzenet amit akarsz írni");
            }
            if (listBox1.SelectedIndex == 9)
            {
                richTextBox1.Text = ("Elfogadja egy másik játékos által indított teleportálási kérelmet.\n\n[név] = A játékos neve, aki küldte neked a kérelmet.");
            }
            if (listBox1.SelectedIndex == 10)
            {
                richTextBox1.Text = ("Elutasítja egy másik játékos által indított teleportálási kérelmet.\n\n[név] = A játékos neve, aki küldte neked a kérelmet.");
            }
            if (listBox1.SelectedIndex == 11)
            {
                richTextBox1.Text = ("Megosztja veled a szerver információit.");
            }
            if (listBox1.SelectedIndex == 12)
            {
                richTextBox1.Text = ("Kiüríti a saját inventorydat. \n\nFIGYELEM!! NEM VISSZAFORDÍTHATÓ!");
            }
            if (listBox1.SelectedIndex == 13)
            {
                richTextBox1.Text = ("Megnézheted vele az enderchested tartalmát.");
            }
            if (listBox1.SelectedIndex == 14)
            {
                richTextBox1.Text = ("Megmutatja, éppen merre nézel a világban.");
            }
            if (listBox1.SelectedIndex == 15)
            {
                richTextBox1.Text = ("Törli az otthonodat, aminek a nevét megadtad.\n\n[home_név] = Az otthon neve.");
            }
            if (listBox1.SelectedIndex == 16)
            {
                richTextBox1.Text = ("Teleportálási kérelmet küld egy játékoshoz.\n\n[név] = A játékos neve, akihez akarsz teleportálni.");
            }
            if (listBox1.SelectedIndex == 17)
            {
                richTextBox1.Text = ("Teleportálási kérelmet küld egy játékoshoz.\n\n[név] = A játékos neve, akit magadhoz akarsz teleportálni.");
            }
            if (listBox1.SelectedIndex == 18)
            {
                richTextBox1.Text = ("Ellenőrzi, mennyi pénz van a számládon.");
            }
            if (listBox1.SelectedIndex == 19)
            {
                richTextBox1.Text = ("Fizet egy játékosnak adott összeget");
            }
            if (listBox1.SelectedIndex == 20)
            {
                richTextBox1.Text = "Figyelmen kívül hagy egy játékost.";
            }
            if (listBox1.SelectedIndex == 21)
            {
                richTextBox1.Text = ("Egy adott warpponthoz teleportál.\n\n[név] = A warppont neve.");
            }
            if (listBox1.SelectedIndex == 22)
            {
                richTextBox1.Text = ("Hozzáad a telkedhez egy játékost.\n\n[teleknév] = A telked neve, ahogy le lett védve. Ezt egy csonttal tudod ellenőrizni (jobb klikk a telekre)\n[név] = A játékos neve akit hozzá akarsz adni a telekhez.");
            }
            if (listBox1.SelectedIndex == 23)
            {
                richTextBox1.Text = ("Törli a telkedről a játékost.\n\n[teleknév] = A telked neve, ahogy le lett védve. Ezt egy csonttal tudod ellenőrizni (jobb klikk a telekre)\n[név] = A játékos neve akit törölni akarsz a telekről.");
            }
            if (listBox1.SelectedIndex == 24)
            {
                richTextBox1.Text = ("Listázza a nevedhez tartozó telkeket.\n\n[neved] = A te neved...");
            }
            if (listBox1.SelectedIndex == 25)
            {
                richTextBox1.Text = "A kezedbe nyom egy fa baltát, amit a telek területének megnézésére használhatsz. \n\nJobb egérgombbal az egyik, bal egérgombbal a másik pontot jelölheted ki, és ezek között hajthatsz végre egy műveletet, két darab / jellel kell beírni! ( //wand ).";
            }
            if (listBox1.SelectedIndex == 26)
            {
                richTextBox1.Text = "A //wand paranccsal kijelölt területhez tartozó összes blockszámot megadja. Ezt használhatod a telekár-számításhoz! \n\nA parancsot két darab / jellel kell beírni ( //expand vert )";
            }
            if (listBox1.SelectedIndex == 27)
            {
                richTextBox1.Text = "Megmutatja, hogyan kell craftolni az itemet. \n\n[item] = Az item neve, vagy azonosítószáma amit craftolni akarsz\n\n[db] = A darabszám amennyit craftolni akarsz.";
            }
            if (listBox1.SelectedIndex == 28)
            {
                richTextBox1.Text = ("Ki-vagy bekapcsolja a csapadékot a világban.");
            }
            if (listBox1.SelectedIndex == 29)
            {
                richTextBox1.Text = ("Kickeli a játékost a szerverről.\n\n[név] = A játékos akit kickelni akarsz.");
            }
            if (listBox1.SelectedIndex == 30)
            {
                richTextBox1.Text = ("Információkat jelenít meg a jelenlegi pluginverzióról.");
            }
            if (listBox1.SelectedIndex == 31)
            {
                richTextBox1.Text = ("Lenémítja a játékost.\n\n[név] = A némítandó játékos neve.");
            }
            if (listBox1.SelectedIndex == 32)
            {
                richTextBox1.Text = ("Ideiglenesen bannolja a játékost.\n\n[év] [hónap] [hét] [nap] [óra] [perc] [másodperc] = Az idő amíg bannolva legyen a játékos.");
            }
            if (listBox1.SelectedIndex == 33)
            {
                richTextBox1.Text = "Az összes WorldEdithez tartozó parancs használható.";
            }
            if (listBox1.SelectedIndex == 34)
            {
                richTextBox1.Text = ("Hozzáad egy játékost egy csoporthoz.\n\n[név] = A játékos neve.\n[csoport] = A csoport ahova hozzá akarod adni (Newbie, Builder)");
            }
            if (listBox1.SelectedIndex == 35)
            {
                richTextBox1.Text = ("Bekapcsolja a repülési módot, pont úgy, mint creative módban.");
            }
            if (listBox1.SelectedIndex == 36)
            {
                richTextBox1.Text = "Megmutatja hogy milyen koordinátán vagy jelenleg a világon";
            }
            if (listBox1.SelectedIndex == 37)
            {
                richTextBox1.Text = "Istenmódba kapcsol, azaz halhatatlan leszel.";
            }
            if (listBox1.SelectedIndex == 38)
            {
                richTextBox1.Text = "Ha esetleg mégis sikerülne lángra kapnod, ezzel a paranccsal elolthatod magad.";
            }
        }
    }
}
