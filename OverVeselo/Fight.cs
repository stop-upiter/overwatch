using System;
using System.Windows.Forms;
using InsideLibrary;

namespace OverVeselo
{
    /// <summary>
    /// Часть класса Fight - форма для битвы.
    /// </summary>
    /// <remarks>
    /// Здесь дополнительные (невизуальные) поля и некоторые методы.
    /// </remarks>
    public partial class Fight : Form
    {
        /// <summary>
        /// Поле для номера текущего раунда.
        /// </summary>
        int raund = 1;

        /// <summary>
        /// Поле для номера текущего выстрела.
        /// </summary>
        int count;

        /// <summary>
        /// Поле для интервала первого таймера -
        /// скорость добавления строчек-логов игры в listBox1.
        /// </summary>
        int intervalTimer1;

        /// <summary>
        /// Поле для определения закончилась ли уже игра -
        /// есть ли победитель.
        /// </summary>
        bool play = true;

        /// <summary>
        /// Логическое выражение - сейчас очередь игрока?
        /// </summary>
        bool turnOfPlayer;

        /// <summary>
        /// Логическое выражение - сейчас автоигра?
        /// </summary>
        bool autogame;

        /// <summary>
        /// Юнит игрока - все сведения о его персонаже.
        /// </summary>
        Unit player;

        /// <summary>
        /// Юнит компьютера - все сведения о его персонаже.
        /// </summary>
        Unit computer;

        /// <summary>
        /// Форма выбора, из которой вызвали эту.
        /// </summary>
        /// <remarks>
        /// Нужна для зацикливания решения.
        /// Используется лишь один раз при закрытии этой формы.
        /// </remarks>
        Form1 parent;

        /// <summary>
        /// Делегат для обычной атаки игрока.
        /// </summary>
        EventHandler shotP;

        /// <summary>
        /// Делегат для обычной атаки компьютера.
        /// </summary>
        EventHandler shotC;

        /// <summary>
        /// Делегат для атаки с прицеливанием игрока.
        /// </summary>
        EventHandler headP;

        /// <summary>
        /// Делегат для атаки с прицеливанием компьютера.
        /// </summary>
        EventHandler headC;

        /// <summary>
        /// Делагат для возврата к форме parent при закрытии этой формы.
        /// </summary>
        FormClosingEventHandler handler;

        /// <summary>
        /// Делегат для автосохранения при закрытии формы.
        /// </summary>
        FormClosingEventHandler saving;

        /// <summary>
        /// Конструктор класса Fight без параметров.
        /// </summary>
        /// <remarks>
        /// Здесь происходит простая инициализация компонентов.
        /// </remarks>
        public Fight()
        {
            InitializeComponent();
            turnOfPlayer = true;
            autogame = false;
            intervalTimer1 = 100;
        }

        /// <summary>
        /// Конструктор класса Fight с тремя параметрами.
        /// </summary>
        /// <param name="player">
        /// Юнит игрока.
        /// </param>
        /// <param name="computer">
        /// Юнит компьютера.
        /// </param>
        /// <param name="parent">
        /// Форма выбора, из которой вызвали эту.
        /// </param>
        public Fight(Unit player, Unit computer, Form1 parent) : this()
        {
            this.player = player;
            this.computer = computer;            
            this.parent = parent;

            if (player.GetLife() == 0)
            {
                player.Life = "1";
                listBox1.Items.Add("Игрок получил капельку живой воды!");
                listBox1.Items.Add("Осторожнее, жизнь игрока = 1");
            }

            if (computer.GetLife() == 0)
            {
                computer.Life = "1";
                listBox1.Items.Add("Компьютер получил капельку живой воды!");
                listBox1.Items.Add("Осторожнее, жизнь копьютера = 1");
            }

            handler = (o, t) => { parent.Close(); };
            saving = (o, t) =>
            {
                if (this.play && !label1.Visible)
                {
                   ManagerXML.SaveXML(player, computer, raund, button2.Enabled, "autosavedGame.xml");
                }
            };
            FormClosing += saving;
            FormClosing += handler;
            

            EventHandler refr = (o, et) => RefreshingText();

            shotP = (o, e) => Shot("Игрок", "Компьютер", player, computer);
            shotP += refr;

            shotC = (o, e) => Shot("Компьютер", "Игрок", computer, player);
            shotC += refr;

            headP = (o, e) => Head("Игрок", "Компьютер", player, computer);
            headP += refr;

            headC = (o, e) => Head("Компьютер", "Игрок", computer, player);
            headC += refr;

            pictureBox2.Image = parent.imageList1.Images[player.Picture];
            pictureBox1.Image = parent.imageList1.Images[computer.Picture];


            //this.FormClosing += 


            RefreshingText();
        }

        /// <summary>
        /// Конструктор класса Fight с двумя параметрами.
        /// </summary>
        /// <param name="tuple">
        /// Кортеж с двумя юнитами - игроком и компьютером,
        /// целым числом - номером раунда,
        /// логическим значением - сейчас ход игрока?
        /// </param>
        /// <param name="parent">
        /// Форма выбора, из которой вызвали эту.
        /// </param>
        public Fight(Tuple<Unit, Unit, int, bool> tuple, Form1 parent):
            this(tuple.Item1, tuple.Item2, parent)
        {
            raund = tuple.Item3;
            label3.Text = $"Раунд {raund}";

            turnOfPlayer = tuple.Item4;
            ChangeEnebledButton();
        }
        
        /// <summary>
        /// Метод для обычной атаки.
        /// </summary>
        /// <param name="atacker">
        /// Текстовое название атакующего.
        /// </param>
        /// <param name="defender">
        /// Текстовое название защищающегося.
        /// </param>
        /// <param name="atack">
        /// Юнит атакующего.
        /// </param>
        /// <param name="defen">
        /// Юнит защищающегося.
        /// </param>
        void Shot(string atacker, string defender, Unit atack, Unit defen)
        {

            string text = $"Выстрел {count}: ";
            if (Unit.random.Next(0, 10) > 6)
            {
                text += "промах";
                listBox1.Items.Add(text);
            }
            else
            {
                text += "удар!";
                listBox1.Items.Add(text);
                double tmp = defen.GetLife();

                if (atack.GetDamage() == 0)
                {
                    if (atack.GetSingleshot() != 0)
                    {
                        listBox1.Items.Add($"{defender} теряет {0.1 * atack.GetSingleshot()}");
                        tmp -= 0.1 * atack.GetSingleshot();
                    }
                    else
                    {
                        listBox1.Items.Add($"{atacker} не может атаковать :c");
                    }
                }
                else
                {
                    listBox1.Items.Add($"{defender} теряет {0.1 * atack.GetDamage()}");
                    tmp -= 0.1 * atack.GetDamage();
                }

                if (tmp <= 0)
                {
                    timer1.Stop();
                    ChangeEnebledButton();
                    
                    timer1.Tick -= shotP;
                    timer1.Tick -= shotC;
                    listBox1.Items.Add($"{defender} умер!");
                    defen.Life = "0";
                    play = false;
                }
                else
                {
                    defen.Life = tmp.ToString();
                }

            }

            count++;
            if (count > 5)
            {
                listBox1.Items.Add(Environment.NewLine);
                timer1.Stop();
                ChangeEnebledButton();
                timer1.Tick -= shotP;
                timer1.Tick -= shotC;
                count = 1;
            }

            if (!play)
            {
                label3.Text = $"{atacker} победил!";
                timer2.Stop();
                button6.Visible = true;
                button6.Focus();

                button1.Enabled = false;
                button2.Enabled = false;
                button3.Enabled = false;

                button5.Visible = false;
                button4.Visible = false;
                
            }
        }

        /// <summary>
        /// Метод для атаки с прицеливанием.
        /// </summary>
        /// <param name="atacker">
        /// Текстовое название атакующего.
        /// </param>
        /// <param name="defender">
        /// Текстовое название защищающегося.
        /// </param>
        /// <param name="atack">
        /// Юнит атакующего.
        /// </param>
        /// <param name="defen">
        /// Юнит защищающегося.
        /// </param>
        void Head(string atacker, string defender, Unit atack, Unit defen)
        {
            string text = $"Выстрел {count}: ";
            if (Unit.random.Next(0, 10) > 2)
            {
                text += "промах";
                listBox1.Items.Add(text);
            }
            else
            {
                text += "удар!";
                listBox1.Items.Add(text);
                double tmp = defen.GetLife();

                if (Unit.random.Next(0, 10) < 2)
                {
                    if (atack.GetHeadshot() == 0)
                    {
                        listBox1.Items.Add($"{atacker} не может провести headshot!!!");
                    }
                    else
                    {
                        listBox1.Items.Add($"Headshot! {defender} теряет {atack.GetHeadshot()}");
                        tmp -= atack.GetHeadshot();
                    }
                }
                else
                {
                    if (atack.GetDamage() == 0)
                    {
                        if (atack.GetSingleshot() != 0)
                        {
                            listBox1.Items.Add($"{defender} теряет {0.4 * atack.GetSingleshot()}");
                            tmp -= 0.4 * atack.GetSingleshot();
                        }
                        else
                        {
                            listBox1.Items.Add($"{atacker} не может атаковать :c");
                        }
                    }
                    else
                    {
                        listBox1.Items.Add($"{defender} теряет {0.4 * atack.GetDamage()}");
                        tmp -= 0.4 * atack.GetDamage();
                    }
                }

                if (tmp <= 0)
                {
                    timer1.Stop();
                    ChangeEnebledButton();
                    timer1.Tick -= headP;
                    timer1.Tick -= headC;
                    listBox1.Items.Add($"{defender} умер!");
                    defen.Life = "0";
                    play = false;
                }
                else
                {
                    defen.Life = tmp.ToString();
                }
            }

            count++;
            if (count > 3)
            {
                listBox1.Items.Add(Environment.NewLine);
                timer1.Stop();
                ChangeEnebledButton();
                timer1.Tick -= headP;
                timer1.Tick -= headC;
                count = 1;
            }

            if (!play)
            {
                label3.Text = $"{atacker} победил!";
                timer2.Stop();
                button6.Visible = true;
                button6.Focus();
                button1.Enabled = false;
                button2.Enabled = false;
                button3.Enabled = false;

                button5.Visible = false;
                button4.Visible = false;
            }
        }

        /// <summary>
        /// Метод для смены очереди между игроком и компьютером 
        /// посредством смены кнопок, доступных для нажатия.
        /// </summary>
        void ChangeEnebledButton()
        {
            if (!autogame)
            {
                button1.Enabled = turnOfPlayer;
                button2.Enabled = turnOfPlayer;
                button3.Enabled = !turnOfPlayer;
            }
        }

        /// <summary>
        /// Метод чтобы сделать кнопки 
        /// действия в битве недоступными для нажатия.
        /// </summary>
        void DisenabledButtons()
        {
            button1.Enabled = false;
            button2.Enabled = false;
            button3.Enabled = false;
        }

        /// <summary>
        /// Метод для обновления информации о сражающихся в textBox.
        /// </summary>
        void RefreshingText()
        {
            textBox1.Text = player.ToString();
            textBox2.Text = computer.ToString();
        }
    }
}
