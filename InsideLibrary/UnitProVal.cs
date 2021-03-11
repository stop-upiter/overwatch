using System;

namespace InsideLibrary
{
    /// <summary>
    /// Часть класса Unit.
    /// </summary>
    /// <remarks>
    /// Здесь находятся свойства и поля класса.
    /// </remarks>
    public partial class Unit
    {
        /// <summary>
        /// Количество всех доступных для выбора изображений.
        /// </summary>
        public static int imagesCount = 1;

        /// <summary>
        /// Статическое поле рандом.
        /// </summary>
        /// <remarks>
        /// Нужно для рандомайзера во всей программе.
        /// </remarks>
        public static Random random = new Random();

        /// <summary>
        /// Поле - счётчик, хранящее 
        /// номер следующего по счету для создания юнита.
        /// </summary>
        static uint counter;

        /// <summary>
        /// Приватное поле героя для имени героя.
        /// </summary>
        /// <remarks>
        /// Дефолтное значение нужно для случая,
        /// когда изначально введено пустое значение имени.
        /// </remarks>
        private string heroes = "Anonimous";

        /// <summary>
        /// Публичное свойство героя для
        /// получения имени героя из вне,
        /// безопасного изменения имени героя.
        /// </summary>
        /// <remarks>
        /// <para>
        /// Символы '<', '>', ';' запрещены,
        /// так как они могут сломать xml, csv.
        /// </para>
        /// <para>
        /// Я запрещаю данные символы потому,
        /// что никто не запретил мне их запрещать :р
        /// </para>
        /// </remarks>
        public string Heroes
        {
            get { return heroes; }
            set
            {
                string tmp = value;

                if (tmp != null)
                {
                    tmp = tmp.Trim();
                    tmp = tmp.Replace("<", String.Empty);
                    tmp = tmp.Replace(">", String.Empty);
                    tmp = tmp.Replace(";", String.Empty);

                    if (!String.IsNullOrWhiteSpace(tmp))
                    {
                        heroes = tmp;
                    }
                }
            }
        }

        /// <summary>
        /// Приватное поле damagePerSecond для хранения силы урона.
        /// </summary>
        /// <remarks>
        /// Дефолтное значение нужно для случая,
        /// когда изначально введено пустое значение.
        /// </remarks>
        private double damagePerSecond = 0;

        /// <summary>
        /// Публичное свойство DamagePerSecond для
        /// получения значения силы урона в строковом виде из вне,
        /// безопасного изменения значения силы урона.
        /// </summary>
        /// <remarks>
        /// <para>
        /// Свойство имеет тип string, так как
        /// из таблицы оно приходит в виде string.
        /// </para>
        /// <para>
        /// Значение infinity проверяется отдельно, так как
        /// оно парсится не в каждой локали так,
        /// как надо.
        /// </para>
        /// </remarks>
        public string DamagePerSecond
        {
            get { return damagePerSecond.ToString(); }
            set
            {
                string tmp = value;
                if (tmp != null)
                {
                    double numb;

                    tmp = tmp.Replace('.', ',');

                    if (double.TryParse(tmp, out numb))
                    {
                        if (numb >= 0)
                        {
                            damagePerSecond = numb;
                        }
                    }
                    else if (tmp == "infinity")
                    { 
                        damagePerSecond = double.PositiveInfinity; 
                    }
                }
            }
        }

        /// <summary>
        /// Приватное поле headshotDPS для хранения силы суперудара.
        /// </summary>
        /// <remarks>
        /// Дефолтное значение нужно для случая,
        /// когда изначально введено пустое значение.
        /// </remarks>
        private double headshotDPS = 0;

        /// <summary>
        /// Публичное свойство HeadshotDPS для
        /// получения значения силы суперудара в строковом виде из вне,
        /// безопасного изменения значения силы суперудара.
        /// </summary>
        /// <remarks>
        /// <para>
        /// Свойство имеет тип string, так как
        /// из таблицы оно приходит в виде string.
        /// </para>
        /// <para>
        /// Значение infinity проверяется отдельно, так как
        /// оно парсится не в каждой локали так,
        /// как надо.
        /// </para>
        /// </remarks>
        public string HeadshotDPS
        {
            get { return headshotDPS.ToString(); }
            set
            {
                string tmp = value;

                if (tmp != null)
                {
                    double numb;

                    tmp = tmp.Replace('.', ',');

                    if (double.TryParse(tmp, out numb))
                    {
                        if (numb >= 0)
                        {
                            headshotDPS = numb;
                        }
                    }
                    else if (tmp == "infinity")
                    { 
                        headshotDPS = double.PositiveInfinity; 
                    }
                }
            }
        }

        /// <summary>
        /// Приватное поле singleShot для хранения силы одного удара.
        /// </summary>
        /// <remarks>
        /// <para>
        /// Дефолтное значение нужно для случая,
        /// когда изначально введено пустое значение.
        /// </para>
        /// <para>
        /// Так как техническое задание данной работы
        /// не даёт точного объяснения для применения этой характеристики,
        /// эта характеристика нужна лишь для отображения в таблице.
        /// </para>
        /// </remarks>
        private double singleShot = 0;

        /// <summary>
        /// Публичное свойство SingleShot для
        /// получения значения силы одного удара в строковом виде из вне,
        /// безопасного изменения значения силы одного удара.
        /// </summary>
        /// <remarks>
        /// <para>
        /// Свойство имеет тип string, так как
        /// из таблицы оно приходит в виде string.
        /// </para>
        /// <para>
        /// Значение infinity проверяется отдельно, так как
        /// оно парсится не в каждой локали так,
        /// как надо.
        /// </para>
        /// </remarks>
        public string SingleShot
        {
            get { return singleShot.ToString(); }
            set
            {
                string tmp = value;

                if (tmp != null)
                {
                    double numb;

                    tmp = tmp.Replace('.', ',');

                    if (double.TryParse(tmp, out numb))
                    {
                        if (numb >= 0)
                        {
                            singleShot = numb;
                        }
                    }
                    else if (tmp == "infinity")
                    {
                        singleShot = double.PositiveInfinity;
                    }
                }
            }
        }

        /// <summary>
        /// Приватное поле life для хранения количества жизненных сил.
        /// </summary>
        /// <remarks>
        /// Дефолтное значение нужно для случая,
        /// когда изначально введено пустое значение.
        /// </remarks>
        private double life = 0;

        /// <summary>
        /// Публичное свойство Life для
        /// получения значения количества жизненных сил в строковом виде из вне,
        /// безопасного изменения значения количества жизненных сил.
        /// </summary>
        /// <remarks>
        /// <para>
        /// Свойство имеет тип string, так как
        /// из таблицы оно приходит в виде string.
        /// </para>
        /// <para>
        /// Значение infinity проверяется отдельно, так как
        /// оно парсится не в каждой локали так,
        /// как надо.
        /// </para>
        /// </remarks>
        public string Life
        {
            get { return life.ToString(); }
            set
            {
                string tmp = value;

                if (tmp != null)
                {
                    double numb;

                    tmp = tmp.Replace('.', ',');

                    if (double.TryParse(tmp, out numb))
                    {
                        if (numb >= 0)
                        {
                            life = numb;
                        }
                    }
                    else if (tmp == "infinity")
                    { 
                        life = double.PositiveInfinity; 
                    }
                }
            }
        }

        /// <summary>
        /// Приватное поле reload для хранения неведомой фигни.
        /// </summary>
        /// <remarks>
        /// <para>
        /// Дефолтное значение нужно для случая,
        /// когда изначально введено пустое значение.
        /// </para>
        /// <para>
        /// Так как техническое задание данной работы
        /// не даёт точного объяснения для применения этой характеристики,
        /// эта характеристика нужна лишь для отображения в таблице.
        /// </para>
        /// </remarks>
        private double reload = 0;

        /// <summary>
        /// Публичное свойство Reload для
        /// получения значения reload в строковом виде из вне,
        /// безопасного изменения значения reload.
        /// </summary>
        /// <remarks>
        /// <para>
        /// Свойство имеет тип string, так как
        /// из таблицы оно приходит в виде string.
        /// </para>
        /// <para>
        /// Значение infinity проверяется отдельно, так как
        /// оно парсится не в каждой локали так,
        /// как надо.
        /// </para>
        /// </remarks>
        public string Reload
        {
            get { return reload.ToString(); }
            set
            {
                string tmp = value;

                if (tmp != null)
                {
                    double numb;

                    tmp = tmp.Replace('.', ',');

                    if (double.TryParse(tmp, out numb))
                    {
                        if (numb >= 0)
                        {
                            reload = numb;
                        }
                    }
                    else if (tmp == "infinity")
                    { 
                        reload = double.PositiveInfinity; 
                    }
                }
            }
        }

        /// <summary>
        /// Приватное поле picture для хранения 
        /// номера изображения данного персонажа,
        /// находящегося в imageList1 в Form1.
        /// </summary>
        /// <remarks>
        /// Значение номера изображения присваивается рандомно.
        /// </remarks>
        private int picture;

        /// <summary>
        /// Публичное свойство только для чтения
        /// номера изображения данного персонажа,
        /// находящегося в imageList1 в Form1.
        /// </summary>
        public int Picture
        {
            get { return picture; }
        }

        /// <summary>
        /// Поле id - 
        /// уникальный идентифицирующий номер юнита.
        /// </summary>
        private uint id;

        /// <summary>
        /// Свойство Id - 
        /// уникальный идентифицирующий номер юнита.
        /// </summary>
        public uint Id
        {
            get => id;
            set { }
        }
    }
}
