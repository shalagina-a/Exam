using System.Media;

namespace AlarmClock
{
    public partial class AlarmForm : Form
    {
        private bool alarmSet;
        private SoundPlayer alarmSound;

        private int hours = 0;
        private int minutes = 0;
        public AlarmForm()
        {
            InitializeComponent();

            this.BackColor = Color.AliceBlue;
            button1.BackColor = Color.LightSteelBlue;

            numericUpDown1.Maximum = 23;
            numericUpDown2.Maximum = 59;

            this.Width = 500;
            this.Height = 500;

            alarmSound = new SoundPlayer("D:\\Для учебы\\Программирование\\Exam\\alarm.wav");

            alarmSet = false;

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label1.Text = "Сейчас: " + DateTime.Now.ToString("HH:mm:ss");

            timer2.Start();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            alarmSet = checkBox1.Checked;

            if (checkBox1.Checked)
            {
                numericUpDown1.Enabled = false;
                numericUpDown2.Enabled = false;

                hours = (int)numericUpDown1.Value;
                minutes = (int)numericUpDown2.Value;
            }
            else
            {
                numericUpDown1.Enabled = true;
                numericUpDown2.Enabled = true;
            }

        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if ((alarmSet) && (DateTime.Now.Hour == hours) && (DateTime.Now.Minute == minutes))
            {
                alarmSound.Play();
                checkBox1.Checked = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void отобразитьСкрытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Show();
        }

        private void оПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Будильник\n\nУрФУ\n\n©2023", "О программе", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}