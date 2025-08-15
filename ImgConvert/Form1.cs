using System.Drawing.Imaging;

//#nullable enable

namespace ImgConvert
{



    public partial class Form1 : Form
    {
        public enum Format
        {
            f16bit,
            f16dither,
            f8bit,
            f8dither,
            f24bit
        }

        public Bitmap input_bitmapa = new(1, 1);
        public Bitmap output_bitmapa = new(1, 1);
        public byte r, g, b, r1, g1, b1, licz;
        public Color rgb;
        public byte[,] binary8 = new byte[1, 1];
        public UInt16[,] binary16 = new UInt16[1, 1];
        public Format format = Format.f24bit;
        Random rnd = new Random();

        public byte rgb24to8bit(byte r, byte g, byte b)
        {
            return (byte)((r >> 5) | ((g >> 5) << 3) | (b & 192));
        }
        public UInt16 rgb24to16bit(byte R, byte G, byte B)
        {
            return (UInt16)(((R & 0xF8) << 8) | ((G & 0xFC) << 3) | (B >> 3));
        }
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            openFileDialog1.Filter = "Image Files(*.BMP;*.JPG;*.GIF;*.PNG)|*.BMP;*.JPG;*.GIF;*.JPEG;*.PNG";
            openFileDialog1.FileName = "";


            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                input_bitmapa.Dispose();
                output_bitmapa.Dispose();
                input_bitmapa = (Bitmap)Image.FromFile(openFileDialog1.FileName);
                output_bitmapa = input_bitmapa.Clone(new Rectangle(0, 0, input_bitmapa.Width, input_bitmapa.Height), PixelFormat.Format24bppRgb);
                pictureBox1.Image = output_bitmapa;
                Text = "Image Converter by ProteusPL [" + input_bitmapa.Width.ToString() + "x" + input_bitmapa.Height.ToString() + "]";

                //button2.Enabled = true;
                button3.Enabled = true;
                button4.Enabled = true;
                button5.Enabled = true;
                button6.Enabled = true;
                //button7.Enabled = true;
                button9.Enabled = true;


            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            pictureBox1.AllowDrop = true;
            AllowTransparency = false;
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            input_bitmapa.Dispose();
            output_bitmapa.Dispose();
            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            button2.Enabled = false;
            button3.Enabled = false;
            button4.Enabled = false;
            button5.Enabled = false;
            button6.Enabled = false;
            button7.Enabled = false;
            button8.Enabled = false;

            output_bitmapa.Dispose();
            output_bitmapa = input_bitmapa.Clone(new Rectangle(0, 0, input_bitmapa.Width, input_bitmapa.Height), input_bitmapa.PixelFormat);
            pictureBox1.Image = output_bitmapa;
            format = Format.f24bit;
            //button2.Enabled = true;
            button3.Enabled = true;
            button4.Enabled = true;
            button5.Enabled = true;
            button6.Enabled = true;
            button7.Enabled = true;
            button8.Enabled = true;
        }
        // 16bit
        private void button3_Click(object sender, EventArgs e)
        {
            button2.Enabled = false;
            button3.Enabled = false;
            button4.Enabled = false;
            button5.Enabled = false;
            button6.Enabled = false;
            button7.Enabled = false;
            button8.Enabled = false;

            output_bitmapa.Dispose();
            output_bitmapa = new Bitmap(input_bitmapa.Width, input_bitmapa.Height, PixelFormat.Format24bppRgb);
            GC.Collect();
            binary16 = new UInt16[input_bitmapa.Height, input_bitmapa.Width];
            GC.Collect();
            progressBar1.Value = 0;
            progressBar1.Maximum = input_bitmapa.Width * input_bitmapa.Height;

            for (UInt16 y = 0; y < input_bitmapa.Height; y++)
            {
                for (UInt16 x = 0; x < input_bitmapa.Width; x++)
                {
                    rgb = input_bitmapa.GetPixel(x, y);
                    b = rgb.B;
                    g = rgb.G;
                    r = rgb.R;

                    rgb = Color.FromArgb((r & 0xF8), (g & 0xFC), (b >> 3) << 3);
                    binary16[y, x] = rgb24to16bit(r, g, b);
                    output_bitmapa.SetPixel(x, y, rgb);

                    progressBar1.Increment(1);
                    Application.DoEvents();
                }
                // pictureBox1.Image = output_bitmapa;
            }
            pictureBox1.Image = output_bitmapa;
            format = Format.f16bit;
            button2.Enabled = true;
            //button3.Enabled = true;
            button4.Enabled = true;
            button5.Enabled = true;
            button6.Enabled = true;
            button7.Enabled = true;
            button8.Enabled = true;
        }
        // 8bit
        private void button4_Click(object sender, EventArgs e)
        {
            button2.Enabled = false;
            button3.Enabled = false;
            button4.Enabled = false;
            button5.Enabled = false;
            button6.Enabled = false;
            button7.Enabled = false;
            button8.Enabled = false;

            output_bitmapa.Dispose();
            output_bitmapa = new Bitmap(input_bitmapa.Width, input_bitmapa.Height, PixelFormat.Format24bppRgb);

            progressBar1.Value = 0;
            progressBar1.Maximum = input_bitmapa.Width * input_bitmapa.Height;
            GC.Collect();
            binary8 = new byte[input_bitmapa.Height, input_bitmapa.Width];
            GC.Collect();

            for (UInt16 y = 0; y < input_bitmapa.Height; y++)
            {
                for (UInt16 x = 0; x < input_bitmapa.Width; x++)
                {
                    rgb = input_bitmapa.GetPixel(x, y);
                    b = rgb.B;
                    g = rgb.G;
                    r = rgb.R;
                    r1 = (byte)(r >> 5);
                    g1 = (byte)(g >> 5);
                    b1 = (byte)(b >> 6);
                    rgb = Color.FromArgb(r1 << 5, g1 << 5, b1 << 6);
                    binary8[y, x] = rgb24to8bit(r, g, b);
                    output_bitmapa.SetPixel(x, y, rgb);

                    progressBar1.Increment(1);
                    Application.DoEvents();
                }
                // pictureBox1.Image = output_bitmapa;
            }
            pictureBox1.Image = output_bitmapa;
            format = Format.f8bit;
            button2.Enabled = true;
            button3.Enabled = true;
            //button4.Enabled = true;
            button5.Enabled = true;
            button6.Enabled = true;
            button7.Enabled = true;
            button8.Enabled = true;
        }
        // 8bit dither
        private void button6_Click(object sender, EventArgs e)
        {
            button2.Enabled = false;
            button3.Enabled = false;
            button4.Enabled = false;
            button5.Enabled = false;
            button6.Enabled = false;
            button7.Enabled = false;
            button8.Enabled = false;

            output_bitmapa.Dispose();
            output_bitmapa = new Bitmap(input_bitmapa.Width, input_bitmapa.Height, PixelFormat.Format24bppRgb);

            progressBar1.Value = 0;
            progressBar1.MarqueeAnimationSpeed = 0;
            progressBar1.Maximum = input_bitmapa.Width * input_bitmapa.Height;
            GC.Collect();
            binary8 = new byte[input_bitmapa.Height, input_bitmapa.Width];
            GC.Collect();

            for (UInt16 y = 0; y < input_bitmapa.Height; y++)
            {
                for (UInt16 x = 0; x < input_bitmapa.Width; x++)
                {
                    rgb = input_bitmapa.GetPixel(x, y);
                    b = rgb.B;
                    g = rgb.G;
                    r = rgb.R;
                    r1 = (byte)Math.Min((rnd.Next() & 31) + r, 255);
                    g1 = (byte)Math.Min((rnd.Next() & 31) + g, 255);
                    b1 = (byte)Math.Min((rnd.Next() & 61) + b, 255);
                    rgb = Color.FromArgb(r1, g1, b1);

                    // binary8[y][x] = RGB24TO8BIT(r1, g1, b1);
                    // b = (rgb >> 16) & 0xC0;
                    // g = (rgb >> 8) & 0xE0;
                    // r = rgb & 0xE0;
                    binary8[y, x] = rgb24to8bit(r1, g1, b1);
                    output_bitmapa.SetPixel(x, y, rgb);
                    progressBar1.Increment(1);
                    Application.DoEvents();
                }
                // pictureBox1.Image = output_bitmapa;

            }
            pictureBox1.Image = output_bitmapa;
            format = Format.f8dither;
            button2.Enabled = true;
            button3.Enabled = true;
            button4.Enabled = true;
            button5.Enabled = true;
            //button6.Enabled = true;
            button7.Enabled = true;
            button8.Enabled = true;
        }
        // 16bit dither
        private void button5_Click(object sender, EventArgs e)
        {

            button2.Enabled = false;
            button3.Enabled = false;
            button4.Enabled = false;
            button5.Enabled = false;
            button6.Enabled = false;
            button7.Enabled = false;
            button8.Enabled = false;

            output_bitmapa.Dispose();
            output_bitmapa = new Bitmap(input_bitmapa.Width, input_bitmapa.Height, PixelFormat.Format24bppRgb);

            progressBar1.Value = 0;
            progressBar1.MarqueeAnimationSpeed = 0;
            progressBar1.Maximum = input_bitmapa.Width * input_bitmapa.Height;
            GC.Collect();
            binary16 = new UInt16[input_bitmapa.Height, input_bitmapa.Width];
            GC.Collect();

            for (UInt16 y = 0; y < input_bitmapa.Height; y++)
            {
                for (UInt16 x = 0; x < input_bitmapa.Width; x++)
                {
                    rgb = input_bitmapa.GetPixel(x, y);
                    b = rgb.B;
                    g = rgb.G;
                    r = rgb.R;
                    r1 = (byte)Math.Min((rnd.Next() & 7) + r, 255);
                    g1 = (byte)Math.Min((rnd.Next() & 3) + g, 255);
                    b1 = (byte)Math.Min((rnd.Next() & 7) + b, 255);
                    rgb = Color.FromArgb(r1, g1, b1);

                    // binary8[y][x] = RGB24TO8BIT(r1, g1, b1);
                    // b = (rgb >> 16) & 0xC0;
                    // g = (rgb >> 8) & 0xE0;
                    // r = rgb & 0xE0;
                    binary16[y, x] = rgb24to8bit(r1, g1, b1);
                    output_bitmapa.SetPixel(x, y, rgb);
                    progressBar1.Increment(1);
                    Application.DoEvents();
                }
                // pictureBox1.Image = output_bitmapa;

            }
            pictureBox1.Image = output_bitmapa;
            format = Format.f8dither;
            button2.Enabled = true;
            button3.Enabled = true;
            button4.Enabled = true;
            //button5.Enabled = true;
            button6.Enabled = true;
            button7.Enabled = true;
            button8.Enabled = true;

        }

        private void button7_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Filter = "Binary Files(*.BIN;*.RAW)|*.BIN;*.RAW";
            saveFileDialog1.FilterIndex = 2;
            progressBar1.Value = 0;
            progressBar1.Maximum = input_bitmapa.Width * input_bitmapa.Height;

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                using (FileStream fs = File.Create(saveFileDialog1.FileName))
                {
                    for (UInt16 y = 0; y < input_bitmapa.Height; y++)
                    {
                        for (UInt16 x = 0; x < input_bitmapa.Width; x++)
                        {
                            switch (format)
                            {
                                case Format.f16bit:
                                    fs.WriteByte((byte)((binary16[y, x]) & 0xff));
                                    fs.WriteByte((byte)((binary16[y, x]) >> 8));
                                    progressBar1.Increment(1);
                                    Application.DoEvents();
                                    break;
                                case Format.f16dither:
                                    fs.WriteByte((byte)((binary16[y, x]) & 0xff));
                                    fs.WriteByte((byte)((binary16[y, x]) >> 8));
                                    progressBar1.Increment(1);
                                    Application.DoEvents();
                                    break;
                                case Format.f8bit:
                                    fs.WriteByte(binary8[y, x]);
                                    progressBar1.Increment(1);
                                    Application.DoEvents();
                                    break;
                                case Format.f8dither:
                                    fs.WriteByte(binary8[y, x]);
                                    progressBar1.Increment(1);
                                    Application.DoEvents();
                                    break;
                                case Format.f24bit:
                                    break;
                                default:
                                    break;
                            }


                            Application.DoEvents();
                        }

                    }
                    fs.Close();
                }
            }

        }

        private void Form1_HelpButtonClicked(object sender, System.ComponentModel.CancelEventArgs e)
        {
            MessageBox.Show("Image converter by ProteusPL (c)2025.\tJebaæ PIS !!!");
        }

        private void button8_Click(object sender, EventArgs e)
        {
            string filename = Path.GetFileNameWithoutExtension(openFileDialog1.FileName);

            string line = "", kolon = ",";
            progressBar1.Value = 0;
            progressBar1.Maximum = input_bitmapa.Height - 1;

            filename = filename.Replace(" ", "_");
            textBox1.Text = "//\r\n// File generated by Image Converter  by ProteusPL (c)2025.\r\n//\r\n\r\n";
            textBox1.Text += "#include \"pgmspace.h\"\r\n";
            textBox1.Text += "\r\n#ifndef _H_" + filename.ToUpper() + "_H";
            textBox1.Text += "\r\n#define _H_" + filename.ToUpper() + "_H\r\n\r\n";

            switch (format)
            {
                case Format.f16bit:
                    textBox1.Text += "const  uint16_t data_" + filename + "[" + input_bitmapa.Width * input_bitmapa.Height + "] = PROGMEM {\r\n";
                    break;
                case Format.f16dither:
                    textBox1.Text += "const  uint16_t data_" + filename + "[" + input_bitmapa.Width * input_bitmapa.Height + "] = PROGMEM {\r\n";
                    break;
                case Format.f8bit:
                    textBox1.Text += "const  uint8_t data_" + filename + "[" + input_bitmapa.Width * input_bitmapa.Height + "] = PROGMEM {\r\n";
                    break;
                case Format.f8dither:
                    textBox1.Text += "const  uint8_t data_" + filename + "[" + input_bitmapa.Width * input_bitmapa.Height + "] = PROGMEM {\r\n";
                    break;
                case Format.f24bit:
                    textBox1.Text += "const  uint32_t data_" + filename + "[" + input_bitmapa.Width * input_bitmapa.Height + "] = PROGMEM {\r\n";
                    break;
                default:
                    break;
            }
            licz = 0; line = "";
            for (UInt16 y1 = 0; y1 < input_bitmapa.Height; y1++)
            {
                for (UInt16 x1 = 0; x1 < input_bitmapa.Width; x1++)
                {
                    licz++;
                    switch (format)
                    {
                        case Format.f8bit:
                        case Format.f8dither:

                            if ((x1 == (input_bitmapa.Width - 1)) && (y1 == input_bitmapa.Height - 1)) kolon = "";
                            line += "0x" + binary8[y1, x1].ToString("X2") + kolon;
                            if (licz == 16)
                            {
                                licz = 0;
                                textBox1.Text += line + "\r\n";
                                line = "";
                            }

                            break;
                        case Format.f16bit:
                        case Format.f16dither:

                            if ((x1 == (input_bitmapa.Width - 1)) && (y1 == input_bitmapa.Height - 1)) kolon = "";
                            line += "0x" + binary16[y1, x1].ToString("X4") + kolon;
                            if (licz == 16)
                            {
                                licz = 0;
                                textBox1.Text += line + "\r\n";
                                line = "";
                            }

                            break;

                        case Format.f24bit:
                            if ((x1 == (input_bitmapa.Width - 1)) && (y1 == input_bitmapa.Height - 1)) kolon = "";
                            Color pixelColor = input_bitmapa.GetPixel(x1, y1);
                            UInt32 rgb24 = (UInt32)((pixelColor.R << 16) | (pixelColor.G << 8) | pixelColor.B);
                            line += "0x" + rgb24.ToString("X6") + kolon;
                            if (licz == 16)
                            {
                                licz = 0;
                                textBox1.Text += line + "\r\n";
                                line = "";
                            }
                            break;
                        default:
                            break;
                    }




                }

                progressBar1.Increment(1);
                Application.DoEvents();

            }
            textBox1.Text += line + "};\r\n";
            textBox1.Text += "\r\n#endif // " + filename.ToUpper() + "_H\r\n\r\n";

            //textBox1.Visible = true;
            saveFileDialog1.Filter = "C header file(*.h;*.hpp)|*.h;*.hpp";
            saveFileDialog1.FilterIndex = 2;
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                File.WriteAllText(saveFileDialog1.FileName, textBox1.Text);
            }
        }


        private void pictureBox1_DragDrop(object sender, DragEventArgs e)
        {
#pragma warning disable CS8600 // Konwertowanie litera³u null lub mo¿liwej wartoœci null na nienullowalny typ.
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
#pragma warning restore CS8600 // Konwertowanie litera³u null lub mo¿liwej wartoœci null na nienullowalny typ.


            // pictureBox1.Image = Image.FromFile(files[0]);
            input_bitmapa.Dispose();
            output_bitmapa.Dispose();
            if (files != null && files.Length != 0)
            {
                openFileDialog1.FileName = files[0];
                input_bitmapa = (Bitmap)Image.FromFile(files[0], true);
                output_bitmapa = input_bitmapa.Clone(new Rectangle(0, 0, input_bitmapa.Width, input_bitmapa.Height), PixelFormat.Format24bppRgb);

                pictureBox1.Image = input_bitmapa;
                Text = "Image Converter by ProteusPL [" + input_bitmapa.Width.ToString() + "x" + input_bitmapa.Height.ToString() + "]";

                button9.Enabled = true;
                button3.Enabled = true;
                button4.Enabled = true;
                button5.Enabled = true;
                button6.Enabled = true;

            }

        }

        private void pictureBox1_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;

        }

        private void Form1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.All;
            else
            {
                String[] strGetFormats = e.Data.GetFormats();
                e.Effect = DragDropEffects.None;
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {

            saveFileDialog1.Filter = "BMP file format|*.bmp|JPG file format|*.jpg|PNG file format|*.png";
            saveFileDialog1.FilterIndex = 3;

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)

            {
                if (saveFileDialog1.FilterIndex == 1)
                {
                    if (File.Exists(saveFileDialog1.FileName)) File.Delete(saveFileDialog1.FileName);
                    output_bitmapa.Save(saveFileDialog1.FileName, ImageFormat.Bmp);
                    //MessageBox.Show(saveFileDialog1.FileName);
                }
                else if (saveFileDialog1.FilterIndex == 2)
                {
                    if (File.Exists(saveFileDialog1.FileName)) File.Delete(saveFileDialog1.FileName);
                    output_bitmapa.Save(saveFileDialog1.FileName, ImageFormat.Jpeg);
                    // MessageBox.Show("JPG format selected.");
                }
                else if (saveFileDialog1.FilterIndex == 3)
                {
                    if (File.Exists(saveFileDialog1.FileName)) File.Delete(saveFileDialog1.FileName);
                    output_bitmapa.Save(saveFileDialog1.FileName, ImageFormat.Png);
                    //MessageBox.Show("PNG format selected.");
                }
                else
                {
                    MessageBox.Show("Unsupported format selected.");
                }

            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            input_bitmapa.Dispose();
            output_bitmapa.Dispose();
        }
    }
}
