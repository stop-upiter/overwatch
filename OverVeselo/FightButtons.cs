using System;
using System.Windows.Forms;
using InsideLibrary;

namespace OverVeselo
{
    /// <summary>
    /// Часть класса Fight - форма для битвы.
    /// </summary>
    /// <remarks>
    /// Здесь методы, привязанные к нажатию кнопок формы.
    /// </remarks>
    public partial class Fight : Form
    {
        /// <summary>
        /// Метод кнопки "обычная атака".
        /// </summary>
        /// <param name="sender">
        /// Объект button1.
        /// </param>
        /// <param name="e">
        /// Аргументы события e.
        /// </param>
        /// <remarks>
        /// Метод для того, чтобы игрок провел обычную атаку.
        /// </remarks>
        private void button1_Click(object sender, EventArgs e)
        {
            label1.Visible = false;
            DisenabledButtons();
            count = 1;
            listBox1.Items.Clear();
            listBox1.Items.Add("Ваш ход: обычная атака");
            timer1.Interval = intervalTimer1;
            timer1.Tick += shotP;
            timer1.Start();
            turnOfPlayer = false;

        }

        /// <summary>
        /// Метод кнопки "атака с прицеливанием".
        /// </summary>
        /// <param name="sender">
        /// Объект button2.
        /// </param>
        /// <param name="e">
        /// Аргументы события e.
        /// </param>
        /// <remarks>
        /// Метод для того, чтобы игрок провел атаку с прицеливанием.
        /// </remarks>
        private void button2_Click(object sender, EventArgs e)
        {
            label1.Visible = false;
            DisenabledButtons();
            count = 1;
            listBox1.Items.Clear();
            listBox1.Items.Add("Ваш ход: атака с прицеливанием");
            timer1.Interval = intervalTimer1;
            timer1.Tick += headP;
            timer1.Start();
            turnOfPlayer = false;
        }

        /// <summary>
        /// Метод кнопки "ход компьютера".
        /// </summary>
        /// <param name="sender">
        /// Объект button3.
        /// </param>
        /// <param name="e">
        /// Аргументы события e.
        /// </param>
        /// <remarks>
        /// Метод для того, чтобы компьютер провел атаку.
        /// </remarks>
        private void button3_Click(object sender, EventArgs e)
        {
            label1.Visible = false;
            DisenabledButtons();
            raund++;
            label3.Text = $"Раунд {raund}";
            count = 1;
            timer1.Interval = intervalTimer1;
            
            if (Unit.random.Next(0, 3) < 2)
            {

                listBox1.Items.Add("Ход компьютера: обычная атака");
                timer1.Tick += shotC;

                timer1.Start();
            }
            else
            {
                listBox1.Items.Add("Ход компьютера: атака с прицеливанием");
                timer1.Tick += headC;
                timer1.Start();
            }
            turnOfPlayer = true;
        }

        /// <summary>
        /// Метод кнопки "сохранить игру как".
        /// </summary>
        /// <param name="sender">
        /// Объект button4.
        /// </param>
        /// <param name="e">
        /// Аргументы события e.
        /// </param>
        /// <remarks>
        /// Метод для того, чтобы сохранить текущее состояние игры в файле xml.
        /// </remarks>
        private void button4_saved_game_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Filter = "Файлы типа xml|*.xml";
            saveFileDialog1.FileName = "SavedGame.xml";
            saveFileDialog1.Title = "Сохраняем вашу игру";
            saveFileDialog1.ShowDialog();


            try
            {
                ManagerXML.SaveXML(player, computer, raund, button1.Enabled, saveFileDialog1.FileName);
            }
            catch
            {
                MessageBox.Show("Что-то пошло не так! Попробуйте еще раз!",
                    "Упс... проблемочка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }

            label1.Visible = true;

        }

        /// <summary>
        /// Метод кнопки "автоигра".
        /// </summary>
        /// <param name="sender">
        /// Объект button5.
        /// </param>
        /// <param name="e">
        /// Аргументы события e.
        /// </param>
        /// <remarks>
        /// Метод для того, чтобы игрок не парился и лишь наблюдал за игрой.
        /// </remarks>
        private void button5_Click(object sender, EventArgs e)
        {
            DisenabledButtons();
            button4.Visible = false;
            intervalTimer1 = 50;
            timer2.Interval = 600;
            timer2.Tick += (o, er) =>
            {
                if (turnOfPlayer)
                {
                    if (Unit.random.Next(0, 3) < 2)
                    {
                        button1_Click(o, er);
                    }
                    else
                    {
                        button2_Click(o, er);
                    }
                }
                else
                {
                    button3_Click(o, er);
                }

            };

            autogame = true;
            button5.Enabled = false;
            timer2.Start();

            
        }

        /// <summary>
        /// Метод кнопки "новая игра".
        /// </summary>
        /// <param name="sender">
        /// Объект button6.
        /// </param>
        /// <param name="e">
        /// Аргументы события e.
        /// </param>
        /// <remarks>
        /// Метод для того, чтобы закрыть эту форму и вернуться к parent.
        /// </remarks>
        private void button6_Click(object sender, EventArgs e)
        {
            parent.Show();
            FormClosing -= handler;
            this.Close();
        }

        /// <summary>
        /// Метод кнопки "???" - информационная справка о бое.
        /// </summary>
        /// <param name="sender">
        /// Объект button7.
        /// </param>
        /// <param name="e">
        /// Аргументы события e.
        /// </param>
        /// <remarks>
        /// Метод для того, чтобы вывести справочную информацию о бое.
        /// </remarks>
        private void button7_Click(object sender, EventArgs e)
        {
            DialogBox.ShowBox("???");
        }
    }
}
