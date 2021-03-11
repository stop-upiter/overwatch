using System;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using System.IO;
using InsideLibrary;

namespace OverVeselo
{
    /// <summary>
    /// Часть класса Form1.
    /// </summary>
    /// <remarks>
    /// Здесь методы, привязанные к нажатию кнопок формы.
    /// </remarks>
    public partial class Form1 : Form
    {
        /// <summary>
        /// Метод кнопки "выбрать"/"вернуться к выбору".
        /// </summary>
        /// <param name="sender">
        /// Объект button1.
        /// </param>
        /// <param name="e">
        /// Аргументы события e.
        /// </param>
        private void button1_choose_Click(object sender, EventArgs e)
        {
            // 1-ое состояние кнопки. 
            // После выбора режима сохраненная игра.
            if (button1.Text == "вернуться к выбору")
            {
                button5.Visible = false;
                button6.Visible = false;

                dataGridView.Enabled = true;
                button3.Enabled = true;
                button2.Enabled = true;

                button4.Text = "сохраненная игра";
                button1.Text = "выбрать";

                WriteInfoAboutSelectedRow(new object(), new EventArgs());
            }
            // 0-е состояние кнопки.
            // В режиме выбора персонажей.
            else if (dataGridView.Rows.Count > 0)
            {


                DataGridViewCellCollection selected = dataGridView.SelectedRows[0].Cells;
                int indexPlayer = dataGridView.SelectedRows[0].Index;
                string[] values = new string[6];
                for (int i = 0; i < 6; i++)
                {
                    values[i] = selected[i].Value.ToString();
                }

                Unit player = new Unit(values, currentPict.ToString(), uint.Parse(selected[7].Value.ToString()));

                button9_delete_filter_Click(button9, new EventArgs());

                int indexComp;
                uint idComp;
                do
                {
                    indexComp = Unit.random.Next(0, dataGridView.Rows.Count);
                    idComp = uint.Parse(dataGridView.Rows[indexComp].Cells[7].Value.ToString());

                } while (idComp == player.Id);

                selected = dataGridView.Rows[indexComp].Cells;
                values = new string[6];
                for (int i = 0; i < 6; i++)
                {
                    values[i] = selected[i].Value.ToString();
                }
                Unit computer = new Unit(values, selected[6].Value.ToString());

                fight = new Fight(player, computer, this);

                this.Hide();
                fight.Show();
                
            }
        }

        /// <summary>
        /// Метод кнопки "фильтровать".
        /// </summary>
        /// <param name="sender">
        /// Объект button2.
        /// </param>
        /// <param name="e">
        /// Аргументы события e.
        /// </param>
        /// <remarks>
        /// Метод для того, чтобы показать фильтр.
        /// </remarks>
        private void button2_show_filter_Click(object sender, EventArgs e)
        {
            panel.Visible = true;
            dataGridView.Enabled = false;
            button1.Enabled = false;
            button2.Enabled = false;
            button3.Enabled = false;
            button4.Enabled = false;
            textBox7.Enabled = false;
        }

        /// <summary>
        /// Метод кнопки "выбрать файл".
        /// </summary>
        /// <param name="sender">
        /// Объект button3.
        /// </param>
        /// <param name="e">
        /// Аргументы события e.
        /// </param>
        /// <remarks>
        /// Метод для того, чтобы выбрать csv-файл.
        /// </remarks>
        private void button3_choose_file_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Таблицы в типе csv|*.csv";
            openFileDialog1.FileName = "";
            openFileDialog1.Title = "Выберите csv-файл с персонажами для игры =)";
            
            openFileDialog1.ShowDialog(this);
            if (File.Exists(openFileDialog1.FileName))
            {
                try
                {
                    parser = new ParserCSV(openFileDialog1.FileName);

                    original = new BindingList<Unit>();
                    foreach (var item in parser.TableInfo)
                    {
                        original.Add(item);
                    }
                    list = original;
                    dataGridView.DataSource = list;

                    button9_delete_filter_Click(sender, e);

                    for (int i = 0; i < dataGridView.Columns.Count - 2; i++)
                    {
                        dataGridView.Columns[i].HeaderText = parser.Header[i];
                    }

                    if (dataGridView.Rows.Count > 0)
                    {
                        dataGridView.Rows[0].Selected = true;
                    }
                }
                catch (Exception ex)
                {
                    DialogBox.ShowBox(ex.Message, BoxType.Error);
                }
            }
        }

        /// <summary>
        /// Метод кнопки "сохраненная игра".
        /// </summary>
        /// <param name="sender">
        /// Объект button4.
        /// </param>
        /// <param name="e">
        /// Аргументы события e.
        /// </param>
        /// <remarks>
        /// Метод для того, чтобы открыть из файла сохранённую игру.
        /// </remarks>
        private void button4_saved_game_Click(object sender, EventArgs e)
        {
            if (button4.Text == "сохраненная игра")
            {
                openFileDialog1.Filter = "Файлы типа xml|*.xml";
                openFileDialog1.FileName = "";
                openFileDialog1.Title = "Выберите xml-файл с сохраненной игрой =)";
                openFileDialog1.ShowDialog(this);

                if (File.Exists(openFileDialog1.FileName))
                {
                    try
                    {
                        lastGame = ManagerXML.ParseXMLForGame(openFileDialog1.FileName);

                        button5.Visible = true;
                        button6.Visible = true;

                        button5_Click(sender, e);

                        panel.Visible = false;
                        dataGridView.Enabled = false;
                        button3.Enabled = false;
                        button2.Enabled = false;
                        button4.Text = "играть";
                        button1.Text = "вернуться к выбору";
                    }
                    catch (Exception ex)
                    {
                        DialogBox.ShowBox(ex.Message, BoxType.Error);
                    }
                }
            }
            else
            {
                fight = new Fight(lastGame, this);
                this.Hide();
                button1_choose_Click(sender, e);
                fight.Show();
                
            }
        }

        /// <summary>
        /// Метод кнопки "мой игрок".
        /// </summary>
        /// <param name="sender">
        /// Объект button5.
        /// </param>
        /// <param name="e">
        /// Аргументы события e.
        /// </param>
        /// <remarks>
        /// Метод для того, чтобы показывать информацию 
        /// о персонаже игрока из сохраненной игры.
        /// </remarks>
        private void button5_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = imageList1.Images[lastGame.Item1.Picture % imageList1.Images.Count];
            textBox7.Text = lastGame.Item1.ToString();
        }

        /// <summary>
        /// Метод кнопки "противник".
        /// </summary>
        /// <param name="sender">
        /// Объект button6.
        /// </param>
        /// <param name="e">
        /// Аргументы события e.
        /// </param>
        /// <remarks>
        /// Метод для того, чтобы показывать информацию 
        /// о персонаже компьютера из сохраненной игры.
        /// </remarks>
        private void button6_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = imageList1.Images[lastGame.Item2.Picture % imageList1.Images.Count];
            textBox7.Text = lastGame.Item2.ToString();
        }

        /// <summary>
        /// Метод кнопки "применить фильтры".
        /// </summary>
        /// <param name="sender">
        /// Объект button8.
        /// </param>
        /// <param name="e">
        /// Аргументы события e.
        /// </param>
        /// <remarks>
        /// Метод для того, чтобы применить фильтры, указанные пользователем,
        /// на всю таблицу dataGridView.
        /// </remarks>
        private void button8_do_filter_Click(object sender, EventArgs e)
        {
            void ChangeList(Func<Unit, bool> predicate)
            {
                var tmp = list.Where<Unit>(predicate);
                BindingList<Unit> temper = new BindingList<Unit>();
                foreach (var item in tmp)
                {
                    temper.Add(item);
                }
                list = temper;
            }

            list = original;
            panel.Visible = false;
            dataGridView.Enabled = true;
            button1.Enabled = true;
            button2.Enabled = true;
            button3.Enabled = true;
            button4.Enabled = true;
            textBox7.Enabled = true;


            double t4 = 0;
            double.TryParse(textBox4.Text, out t4);

            switch (comboBox1.SelectedIndex)
            {
                case 1:
                    ChangeList(unit => unit.GetDamage() > t4);
                    break;
                case 2:
                    ChangeList(unit => unit.GetDamage() < t4);
                    break;
                case 3:
                    ChangeList(unit => unit.GetDamage() == t4);
                    break;
                case 4:
                    ChangeList(unit => unit.GetDamage() >= t4);
                    break;
                case 5:
                    ChangeList(unit => unit.GetDamage() <= t4);
                    break;
            }

            double t5 = 0;
            double.TryParse(textBox5.Text, out t5);

            switch (comboBox2.SelectedIndex)
            {
                case 1:
                    ChangeList(unit => unit.GetLife() > t5);
                    break;
                case 2:
                    ChangeList(unit => unit.GetLife() < t5);
                    break;
                case 3:
                    ChangeList(unit => unit.GetLife() == t5);
                    break;
                case 4:
                    ChangeList(unit => unit.GetLife() >= t5);
                    break;
                case 5:
                    ChangeList(unit => unit.GetLife() <= t5);
                    break;
            }

            double t6 = 0;
            double.TryParse(textBox6.Text, out t6);

            switch (comboBox3.SelectedIndex)
            {
                case 1:
                    ChangeList(unit => unit.GetHeadshot() > t6);
                    break;
                case 2:
                    ChangeList(unit => unit.GetHeadshot() < t6);
                    break;
                case 3:
                    ChangeList(unit => unit.GetHeadshot() == t6);
                    break;
                case 4:
                    ChangeList(unit => unit.GetHeadshot() >= t6);
                    break;
                case 5:
                    ChangeList(unit => unit.GetHeadshot() <= t6);
                    break;
            }
            dataGridView.CellValueChanged -= cellEventHandler;
            dataGridView.DataSource = list;
            dataGridView.CellValueChanged += cellEventHandler;
        }

        /// <summary>
        /// Метод кнопки "скинуть фильтры".
        /// </summary>
        /// <param name="sender">
        /// Объект button9.
        /// </param>
        /// <param name="e">
        /// Аргументы события e.
        /// </param>
        /// <remarks>
        /// <para>
        /// Метод для того, чтобы скинуть все ранее применённые фильтры.
        /// </para>
        /// <para>
        /// Также скидывает всю сортировку.
        /// </para>
        /// </remarks>
        private void button9_delete_filter_Click(object sender, EventArgs e)
        {
            panel.Visible = false;
            dataGridView.Enabled = true;
            button1.Enabled = true;
            button2.Enabled = true;
            button3.Enabled = true;
            button4.Enabled = true;
            textBox7.Enabled = true;

            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();

            comboBox1.SelectedIndex = 0;
            comboBox2.SelectedIndex = 0;
            comboBox3.SelectedIndex = 0;

            list = original;
            dataGridView.DataSource = list;
        }
    }
}
