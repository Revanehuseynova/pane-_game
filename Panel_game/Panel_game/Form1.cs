namespace Panel_game
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Random r = new Random();
        Random g = new Random();
        Random b = new Random();

        Random xL = new Random();
        Random yL = new Random();
        int count = 0;
        private void Form1_Load(object sender, EventArgs e)
        {
        }
        private void button1_Click(object sender, EventArgs e)
        {
            count++;
            label2.Text = count.ToString();
            Panel p = new Panel();
            p.Size = new Size(60, 60);
            p.Location = new Point(xL.Next(0, 700), yL.Next(0, 280));
            p.BackColor = Color.FromArgb(r.Next(0, 256), g.Next(0, 256), b.Next(0, 256));
            p.Tag = "panel";
            this.Controls.Add(p);
            if (p.Bounds.IntersectsWith(pictureBox1.Bounds))
            {
                DialogResult d = MessageBox.Show("Oyun bitdi! Xalınız: " + count, "Məlumat", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (d == DialogResult.OK)
                {
                    count = 0;
                    label2.Text = count.ToString();

                    for (int i = this.Controls.Count - 1; i >= 0; i--)
                    {
                        if (this.Controls[i] is Panel && this.Controls[i].Tag != null && this.Controls[i].Tag.ToString() == "panel")
                        {
                            this.Controls.RemoveAt(i);
                        }
                    }

                    pictureBox1.Location = new Point(xL.Next(0, 700), yL.Next(0, 280));
                }
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            pictureBox1.Location = new Point(xL.Next(0, 700), yL.Next(0, 280));

            for (int i = 0; i < this.Controls.Count; i++)
            {
                if (this.Controls[i] is Panel && this.Controls[i].Tag != null)
                {
                    if (pictureBox1.Bounds.IntersectsWith(this.Controls[i].Bounds))
                    {
                        pictureBox1.Location = new Point(xL.Next(0, 700), yL.Next(0, 280));
                        i = -1;
                    }
                }
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult d = MessageBox.Show("Proqramdan çıxış edilsinmi?", "Sual", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (d == DialogResult.Yes)
            {
                Close();
            }
        }
    }
}