using System;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using InsideLibrary;

namespace OverVeselo
{
    /// <summary>
    /// Часть класса Form1.
    /// </summary>
    /// <remarks>
    /// Здесь дополнительные (невизуальные) поля и некоторые методы.
    /// </remarks>
    public partial class Form1 : Form
    {
        /// <summary>
        /// Форма fight типа Fight для реализации битвы.
        /// </summary>
        /// <remarks>
        /// Для каждой новой битвы создается новая форма.
        /// </remarks>
        Fight fight;

        /// <summary>
        /// Объект parser типа ParserCSV для парсинга из csv файла
        /// и для хранения распарсенной информации.
        /// </summary>
        ParserCSV parser;

        /// <summary>
        /// Объект list типа BindingList из юнитов.
        /// </summary>
        /// <remarks>
        /// Нужен для представления текущих элементов таблицы dataGridView.
        /// </remarks>
        BindingList<Unit> list;

        /// <summary>
        /// Объект original типа BindingList из юнитов.
        /// </summary>
        /// <remarks>
        /// Нужен для сохранения первоначального списка юнитов в таблице.
        /// </remarks>
        BindingList<Unit> original;

        /// <summary>
        /// Делегат для сохранения фильтрации при сортировке таблицы.
        /// </summary>
        DataGridViewCellEventHandler cellEventHandler;

        /// <summary>
        /// Кортеж с двумя юнитами - игроком и компьютером,
        /// целым числом - номером раунда,
        /// логическим значением - сейчас ход игрока?
        /// </summary>
        /// <remarks>
        /// Используется для реализации сохраненной игры.
        /// </remarks>
        Tuple<Unit, Unit, int, bool> lastGame;

        /// <summary>
        /// Массив из булеанов 
        /// для выбора текущего порядка сортировки столбца.
        /// </summary>
        /// <remarks>
        /// См метод SortColumn.
        /// </remarks>
        bool[] sorted;

        /// <summary>
        /// Поле - индекс текущей картинки из imageList1 в pictireBox1.
        /// </summary>
        int currentPict;

        /// <summary>
        /// Конструктор Form1.
        /// </summary>
        /// <remarks>
        /// Здесь происходит инициализация компонентов формы,
        /// полей, 
        /// подписание некоторых событий на делегаты.
        /// </remarks>
        public Form1()
        {
            InitializeComponent();

            pictureBox1.Image = imageList2.Images[Unit.random.Next(0, imageList2.Images.Count)]; 

            DialogBox.ShowBox("start");

            Unit.imagesCount = imageList1.Images.Count;
            sorted = new bool[6];

            // Если кто-то удалил файл, то программа не сломается.
            // Создастся пустой парсер.
            // Он даст программе работать, но
            // играть вы не сможете, пока не выберете новый файл
            // или пока вы не откроете сохранёную игру.
            try
            {
                parser = new ParserCSV("Overwatch.csv");
            }
            catch (System.IO.FileNotFoundException)
            {
                parser = new ParserCSV();
            }
            catch (Exception ex)
            {
                DialogBox.ShowBox("В автоматически выбранном csv-файле возникла такая ошибка:\n"+ex.Message, 
                    "Только начали, а уже какие-то проблемы :с", BoxType.Warning);
                parser = new ParserCSV();
            }

            original = new BindingList<Unit>();
            foreach (var item in parser.TableInfo)
            {
                original.Add(item);
            }
            list = original;
            dataGridView.DataSource = list;

            dataGridView.RowHeadersWidthSizeMode = 
                DataGridViewRowHeadersWidthSizeMode.DisableResizing;

            // Здесь происходит обновление заголовков таблицы.
            // Это типо фича, да =)
            // Сами виноваты. Надо соблюдать регламент. ЫЫЫ.
            for (int i = 0; i < parser.Columns; i++)
            { dataGridView.Columns[i].HeaderText = parser.Header[i]; }

            // Когда меняется выбранная строка, 
            // обновляется информация в pictureBox1 и textBox7.
            dataGridView.SelectionChanged += new EventHandler(WriteInfoAboutSelectedRow);

            // Когда меняется значение ячейки,
            // переписывается информация в pictureBox1 и textBox7
            // (так как переписать могли выбранную строку),
            // ещё раз применяется текущий фильтр
            // (так как измененное значение может не соответствовать фильтру).
            dataGridView.CellValueChanged += new DataGridViewCellEventHandler(WriteInfoAboutSelectedRow);
            cellEventHandler = new DataGridViewCellEventHandler(button8_do_filter_Click);
            dataGridView.CellValueChanged += cellEventHandler;

            // Если в первоначальном распарсенном csv-файле есть столбцы,
            // то значит в нем есть строки.
            // Тогда выберем первую из строк в dataGridView.
            if (parser.Columns > 0)
            { dataGridView.Rows[0].Selected = true; }

            // Когда пользователь дважды нажимает на заголовок в dataGridView,
            // происходит сортировка по значениям этой таблицы.
            dataGridView.ColumnHeaderMouseDoubleClick += new DataGridViewCellMouseEventHandler(SortColumn);

            // Когда эти textBox покидает фокус,
            // происходит проверка записанного в них значения.
            // Разрешены только неотрицательные числа типа double.
            textBox4.Leave += new EventHandler(ChangedText);
            textBox5.Leave += new EventHandler(ChangedText);
            textBox6.Leave += new EventHandler(ChangedText);

            // Когда эти comboBox покидает фокус,
            // происходит проверка записанного в них значения.
            // ComboBox позволяет пользователю писать что-то своё.
            // Так вот, это своё произвольное значение стирается тут.
            comboBox1.Leave += new EventHandler(ClearCombobox);
            comboBox2.Leave += new EventHandler(ClearCombobox);
            comboBox3.Leave += new EventHandler(ClearCombobox);

        }

        /// <summary>
        /// Метод для вывода информации о текущем выбранном юните.
        /// </summary>
        /// <param name="o">
        /// Объект o.
        /// </param>
        /// <param name="e">
        /// Аргументы события e.
        /// </param>
        /// <remarks>
        /// Параметры в данном методе нужны только для того,
        /// чтобы без проблем записать потом его в EventHandler.
        /// </remarks>
        void WriteInfoAboutSelectedRow(object o, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count > 0)
            {
                var tmp = dataGridView.SelectedRows[0].Cells;
                string text = $"Герой {tmp[0].Value}" +
                        $"{Environment.NewLine}";
                text += $"Урон в секунду = {tmp[1].Value}" +
                        $"{Environment.NewLine}";
                text += $"Урон от хэдшота = {tmp[2].Value}" +
                    $"{Environment.NewLine}";
                text += $"Урон от одного удара = {tmp[3].Value}" +
                        $"{Environment.NewLine}";
                text += $"Жизнь = {tmp[4].Value}" +
                    $"{Environment.NewLine}";
                text += $"reload = {tmp[5].Value}" +
                        $"{Environment.NewLine}";

                textBox7.Text = text;

                currentPict = ParseCellToInt(tmp[6]);
                pictureBox1.Image = imageList1.Images[currentPict];

            }
            else
            {
                textBox7.Clear();
            }

            int ParseCellToInt(DataGridViewCell cell)
            {
                int numb;
                return int.TryParse(cell.Value.ToString(), out numb) ? numb : 0;
            }
        }

        /// <summary>
        /// Метод для очистки неправильной информации в comboBox.
        /// </summary>
        /// <param name="o">
        /// Объект o - comboBox.
        /// </param>
        /// <param name="e">
        /// Аргументы события e.
        /// </param>
        /// <remarks>
        /// Параметр e в данном методе нужен только для того,
        /// чтобы без проблем записать потом метод в EventHandler.
        /// </remarks>
        void ClearCombobox(object o, EventArgs e)
        {
            string text = (o as ComboBox).Text;
            if (text != ">" && text != "<"
                && text != "=" && text != "<="
                && text != ">=")
            {
                (o as ComboBox).Text = String.Empty;
            }
        }

        /// <summary>
        /// Метод для сортировки таблицы по определенному столбцу.
        /// </summary>
        /// <param name="o">
        /// Объект o.
        /// </param>
        /// <param name="e">
        /// DataGridViewCellMouseEventArgs - 
        /// аргументы события взаимодействия мыши и ячейки dataGridView e.
        /// </param>
        /// <remarks>
        /// Параметр e в данном методе нужны только для того,
        /// чтобы без проблем записать потом метод 
        /// в DataGridViewCellMouseEventHandler.
        /// </remarks>
        void SortColumn(object o, DataGridViewCellMouseEventArgs e)
        {
            int i = e.ColumnIndex;
            switch (i)
            {
                case 0:
                    Func<Unit, string> tmp0 = a => a.Heroes;
                    if (sorted[0])
                    {
                        SortDown<string>(tmp0);
                    }
                    else
                    {
                        Sort<string>(tmp0);
                    }

                    sorted[0] = !sorted[0];
                    break;

                case 1:
                    Func<Unit, double> tmp1 = a => a.GetDamage();

                    if (sorted[1])
                    {
                        SortDown<double>(tmp1);
                    }
                    else
                    {
                        Sort<double>(tmp1);
                    }

                    sorted[1] = !sorted[1];
                    break;

                case 2:
                    Func<Unit, double> tmp2 = a => a.GetHeadshot();

                    if (sorted[2])
                    {
                        SortDown<double>(tmp2);
                    }
                    else
                    {
                        Sort<double>(tmp2);
                    }

                    sorted[2] = !sorted[2];
                    break;

                case 3:
                    Func<Unit, double> tmp3 = a => a.GetSingleshot();

                    if (sorted[3])
                    {
                        SortDown<double>(tmp3);
                    }
                    else
                    {
                        Sort<double>(tmp3);
                    }

                    sorted[3] = !sorted[3];
                    break;

                case 4:
                    Func<Unit, double> tmp4 = a => a.GetLife();

                    if (sorted[4])
                    {
                        SortDown<double>(tmp4);
                    }
                    else
                    {
                        Sort<double>(tmp4);
                    }

                    sorted[4] = !sorted[4];
                    break;

                case 5:
                    Func<Unit, double> tmp5 = a => a.GetReload();

                    if (sorted[5])
                    {
                        SortDown<double>(tmp5);
                    }
                    else
                    {
                        Sort<double>(tmp5);
                    }

                    sorted[5] = !sorted[5];
                    break;
            }

            void Sort<T>(Func<Unit, T> predicate)
            {
                var tmp = list.OrderBy<Unit, T>(predicate);
                BindingList<Unit> temper = new BindingList<Unit>();

                foreach (var item in tmp)
                {
                    temper.Add(item);
                }

                list = temper;
                
                dataGridView.DataSource = list;
                
            }

            void SortDown<T>(Func<Unit, T> predicate)
            {
                var tmp = list.OrderByDescending<Unit, T>(predicate);
                BindingList<Unit> temper = new BindingList<Unit>();

                foreach (var item in tmp)
                {
                    temper.Add(item);
                }

                list = temper;
                
                dataGridView.DataSource = list;
                
            }
        }

        /// <summary>
        /// Метод для проверки введенной информации 
        /// и очистки неправильной информации в textBox.
        /// </summary>
        /// <param name="o">
        /// Объект o - textBox.
        /// </param>
        /// <param name="e">
        /// Аргументы события e.
        /// </param>
        /// <remarks>
        /// Параметр e в данном методе нужен только для того,
        /// чтобы без проблем записать потом метод в EventHandler.
        /// </remarks>
        void ChangedText(object o, EventArgs e)
        {
            var str = (o as TextBox).Text;
            if (str == null)
            {
                str = "0";
            }
            
            str = str.Replace('.', ',');
            double numb;

            if (!double.TryParse(str, out numb))
            {
                (o as TextBox).Text = "0";
            }
            else
            {
                if (numb < 0)
                {
                    (o as TextBox).Text = "0";
                }
                else
                {
                    (o as TextBox).Text = numb.ToString();
                }
            }
        }
    }
}
