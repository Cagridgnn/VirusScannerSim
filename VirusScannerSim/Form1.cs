using System;
using System.Drawing;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VirusScannerSim
{
    public partial class Form1 : Form
    {
        // Değişken isimlerini çakışma olmaması için tamamen değiştirdik
        private Button butonDosyaSec;
        private Button butonTara;
        private ListBox listeSonuclar;
        private ProgressBar ilerlemeCubugu;
        private Label etiketYol;
        private Label etiketDurum;
        private string taranacakYol = "";

        public Form1()
        {
            InitializeComponent();
            ArayuzuKodlaOlustur();
        }

        private void ArayuzuKodlaOlustur()
        {
            this.Text = "🛡️ Güvenli Tarama Sistemi";
            this.Size = new Size(500, 550);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;

            // Buton: Klasör Seç
            butonDosyaSec = new Button { Text = "Klasör Seç", Location = new Point(20, 20), Size = new Size(110, 35) };
            butonDosyaSec.Click += ButonDosyaSec_Click;

            // Buton: Taramayı Başlat
            butonTara = new Button { Text = "Sistemi Tara", Location = new Point(140, 20), Size = new Size(110, 35), Enabled = false };
            butonTara.Click += ButonTara_Click;

            // Bilgilendirme Etiketleri
            etiketYol = new Label { Text = "Hedef: Bekleniyor...", Location = new Point(20, 65), Size = new Size(440, 20) };
            listeSonuclar = new ListBox { Location = new Point(20, 95), Size = new Size(440, 290) };
            ilerlemeCubugu = new ProgressBar { Location = new Point(20, 400), Size = new Size(440, 25) };
            etiketDurum = new Label { Text = "Durum: Hazır", Location = new Point(20, 440), Size = new Size(440, 20), Font = new Font(this.Font, FontStyle.Bold) };

            this.Controls.Add(butonDosyaSec);
            this.Controls.Add(butonTara);
            this.Controls.Add(etiketYol);
            this.Controls.Add(listeSonuclar);
            this.Controls.Add(ilerlemeCubugu);
            this.Controls.Add(etiketDurum);
        }

        private void ButonDosyaSec_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog fbd = new FolderBrowserDialog())
            {
                if (fbd.ShowDialog() == DialogResult.OK)
                {
                    taranacakYol = fbd.SelectedPath;
                    etiketYol.Text = "Hedef: " + taranacakYol;
                    butonTara.Enabled = true;
                    listeSonuclar.Items.Add("Dizin başarıyla bağlandı.");
                }
            }
        }

        private async void ButonTara_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(taranacakYol)) return;

            listeSonuclar.Items.Clear();
            ilerlemeCubugu.Value = 0;
            int tehditSayisi = 0;
            butonTara.Enabled = false;

            try
            {
                string[] dosyalar = Directory.GetFiles(taranacakYol);
                ilerlemeCubugu.Maximum = dosyalar.Length;

                foreach (string dosya in dosyalar)
                {
                    FileInfo f = new FileInfo(dosya);
                    // Basit virüs tespit mantığı
                    bool riskli = f.Name.ToLower().Contains("virus") || f.Extension == ".bat" || f.Extension == ".exe";

                    await Task.Delay(100); // Kullanıcıya tarama hissi ver

                    if (riskli)
                    {
                        listeSonuclar.Items.Add("[KRİTİK] " + f.Name + " - Tehdit Tespit Edildi!");
                        tehditSayisi++;
                    }
                    else
                    {
                        listeSonuclar.Items.Add("[TEMİZ] " + f.Name);
                    }

                    ilerlemeCubugu.Value++;
                    listeSonuclar.TopIndex = listeSonuclar.Items.Count - 1; // Otomatik kaydır
                }
                etiketDurum.Text = $"✅ İşlem Tamam: {tehditSayisi} Riskli Dosya!";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Sistem Hatası: " + ex.Message);
            }
            finally { butonTara.Enabled = true; }
        }
    }
}