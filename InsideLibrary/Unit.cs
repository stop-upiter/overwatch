using System;

namespace InsideLibrary
{
    /// <summary>
    /// Часть класса Unit.
    /// </summary>
    /// <remarks>
    /// Здесь находятся конструкторы и методы класса.
    /// </remarks>
    public partial class Unit
    {
        /// <summary>
        /// Внутрибиблиотечный конструктор класса Unit 
        /// с отдельными параметрами под каждое нужное значение.
        /// </summary>
        /// <param name="hero">
        /// Значение имени героя.
        /// </param>
        /// <param name="damage">
        /// Значение силы урона.
        /// </param>
        /// <param name="headshot">
        /// Значение силы суперудара.
        /// </param>
        /// <param name="single">
        /// Значение сиды одного удара.
        /// </param>
        /// <param name="hp">
        /// Значение количества жизненных сил.
        /// </param>
        /// <param name="useless">
        /// Значение reload.
        /// </param>
        internal Unit
            (string hero, string damage,
            string headshot, string single,
            string hp, string useless)
        {
            Heroes = hero;
            DamagePerSecond = damage;
            HeadshotDPS = headshot;
            SingleShot = single;
            Life = hp;
            Reload = useless;

            picture = random.Next(0, imagesCount);

            id = counter;
            counter++;
        }

        /// <summary>
        /// Публичный конструктор класса Unit
        /// с одний параметром - массивом нужных данных.
        /// </summary>
        /// <param name="array">
        /// Массив из 6 элементов:
        /// значение имени героя,
        /// значение силы урона,
        /// значение силы суперудара,
        /// значение сиды одного удара,
        /// значение количества жизненных сил,
        /// значение reload.
        /// </param>
        public Unit(string[] array) :
            this(array[0], array[1],
                array[2], array[3],
                array[4], array[5]) { }

        /// <summary>
        /// Публичный конструктор класса Unit
        /// с двумя параметрами - массивом нужных данных
        /// и номером изображения данного персонажа,
        /// находящегося в imageList1 в Form1.
        /// </summary>
        /// <param name="array">
        /// Массив из 6 элементов:
        /// значение имени героя,
        /// значение силы урона,
        /// значение силы суперудара,
        /// значение сиды одного удара,
        /// значение количества жизненных сил,
        /// значение reload.
        /// </param>
        /// <param name="picture">
        /// Номер изображения данного персонажа,
        /// находящегося в imageList1 в Form1.
        /// </param>
        public Unit(string[] array, string picture) :
            this(array)
        {
            int pict = int.Parse(picture);
            if (pict < 0 || pict>=imagesCount)
            {
                pict = random.Next(0, imagesCount);
            }

            this.picture = pict;
        }

        /// <summary>
        /// Публичный конструктор класса Unit
        /// с тремя параметрами - массивом нужных данных,
        /// номером изображения данного персонажа,
        /// находящегося в imageList1 в Form1,
        /// значением идентифитатора.
        /// </summary>
        /// <param name="array">
        /// Массив из 6 элементов:
        /// значение имени героя,
        /// значение силы урона,
        /// значение силы суперудара,
        /// значение сиды одного удара,
        /// значение количества жизненных сил,
        /// значение reload.
        /// </param>
        /// <param name="picture">
        /// Номер изображения данного персонажа,
        /// находящегося в imageList1 в Form1.
        /// </param>
        /// <param name="id">
        /// Значение идентификатора, полученное ранее.
        /// </param>
        /// <remarks>
        /// Данный конструктор нужен для работы с копиями уже созданных юнитов.
        /// Работать с этим на свой страх и риск.
        /// </remarks>
        public Unit(string[] array, string picture, uint id) :
            this(array, picture)
        {
            this.id = id;
            counter--;
        }

        /// <summary>
        /// Переопределенный метод привидения к строке
        /// для класса Unit.
        /// </summary>
        /// <returns>
        /// Инфомацию о персонаже, 
        /// представленную в строковом виде.
        /// </returns>
        public override string ToString()
        {
            return $"Герой {Heroes}" +
                        $"{Environment.NewLine}"+
            $"Урон в секунду = {DamagePerSecond}" +
                    $"{Environment.NewLine}"+
                    $"Урон от хэдшота = {HeadshotDPS}" +
                $"{Environment.NewLine}"
            +$"Урон от одного удара = {SingleShot}" +
                    $"{Environment.NewLine}"
                    + $"Жизнь = {Life}" +
                $"{Environment.NewLine}"
            +$"reload = {Reload}" +
                    $"{Environment.NewLine}";
        }

        /// <summary>
        /// Публичный метод для получения значения силы урона в типе double.
        /// </summary>
        /// <returns>
        /// Силу урона в типе double.
        /// </returns>
        public double GetDamage() => damagePerSecond;

        /// <summary>
        /// Публичный метод для получения значения силы суперудара в типе double.
        /// </summary>
        /// <returns>
        /// Силу суперудара в типе double.
        /// </returns>
        public double GetHeadshot() => headshotDPS;

        /// <summary>
        /// Публичный метод для получения значения силы одного удара в типе double.
        /// </summary>
        /// <returns>
        /// Силу одного удара в типе double.
        /// </returns>
        public double GetSingleshot() => singleShot;

        /// <summary>
        /// Публичный метод для получения значения количества жизненных сил в типе double.
        /// </summary>
        /// <returns>
        /// Количество жизненных сил в типе double.
        /// </returns>
        public double GetLife() => life;

        /// <summary>
        /// Публичный метод для получения значения reload в типе double.
        /// </summary>
        /// <returns>
        /// Reload в типе double.
        /// </returns>
        public double GetReload() => reload;

        /// <summary>
        /// Публичный метод для проверки юнита на тривиальность.
        /// </summary>
        /// <returns>
        /// Является ли юнит тривиальным?
        /// </returns>
        public bool IsEmpty()
        {
            return heroes == "Anonimous"
                && damagePerSecond == 0 
                && headshotDPS == 0 
                && singleShot == 0 
                && life == 0 
                && reload == 0;
        }
    }
}
