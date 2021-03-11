using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace InsideLibrary
{
    /// <summary>
    /// Класс DialogBox для вывода 
    /// диалогового окна MessageBox с сообщением определенного типа.
    /// </summary>
    public static class DialogBox
    {
        /// <summary>
        /// Словарь с делегатами вызова диалоговых окон разного типа.
        /// </summary>
        static Dictionary<BoxType, Action<string, string>> boxes = new Dictionary<BoxType, Action<string, string>>
        {
            [BoxType.Info] = (mes, head) => MessageBox.Show(mes, head, MessageBoxButtons.OK, MessageBoxIcon.Information),
            [BoxType.Error] = (mes, head) => MessageBox.Show(mes, head, MessageBoxButtons.OK, MessageBoxIcon.Error),
            [BoxType.Warning] = (mes, head) => MessageBox.Show(mes, head, MessageBoxButtons.OK, MessageBoxIcon.Warning),
            [BoxType.Else] = (mes, head) => MessageBox.Show(mes, head, MessageBoxButtons.OK)
        };

        /// <summary>
        /// Словать с делегатами вызова диалоговых окон с определённым контентом.
        /// </summary>
        static Dictionary<string, Action> dialogues = new Dictionary<string, Action>
        {
            ["start"] = () => ShowBox(
                "Добро пожаловать в добрую игру! Для начала вам нужно кое-что узнать =)" +
                "\n\nЯ не разрешаю вам использовать символы '>', '<', ';'" +
                "\nв именах героев. Если вы - вредина и написали '>', '<', то они удалятся, " +
                "а вот наличие ';' не даст вам работать с файликом. Аккуратнее, пожалуйста!" +
                "\nЧисла в таблице должны быть неотрицательными, " +
                "иначе они обнулятся." +
                "\nЕсли вы закроете программу во время боя, битва автоматически сохранится (если она, конечно, уже не закончилась)" +
                "\nА еще в формах можно менять размер, но это только для того, чтобы вы насладились их фоновыми картинками =)" +
                "\n\nПриятной игры!",
                "ДИСКЛЕЙМЕР",
                BoxType.Info),
            ["???"] = () => ShowBox("Привет-привет! Давай расскажу как происходит бой!" +
                "\n\n\tТы, наверное, уже заметил, что у тебя есть два способа атаки: " +
                "обычная атака и атака с прицеливанием. Компьютер тоже использует эти два способа с вероятностью 2 к 1." +
                "\nВ обычной атаке есть 5 выстрелов и большая вероятность попасть - аж целых 7 из 10! " +
                "Но нанесешь при попадании урон ты только в 10% от своей силы. " +
                "\nПри атаке с прицеливанием у тебя есть всего 3 попытки и вероятность попадания ниже - 3 из 10, " +
                "но зато какие возможности! Ты можешь нанести урон в 40% от своей силы. " +
                "А в 2 из 10 случаев даже может пройти суперудар - 100% от headshot!" +
                "\n\n\tКстати говоря, моё дополнения для более логичной игры: " +
                "если сила урона в секунду у персонажа нулевая, " +
                "используется сила одного удара (single shot)." +
                "\nА ещё если у персонажа изначально было нулевое количество жизненных сил, " +
                "то я увеличиваю их на 1. Чтобы у нас не сражались зомби =)" +
                "\n\nСпасибо за внимание! Приятной игры!",
                "Небольшая справочка",
                BoxType.Info)
        };

        /// <summary>
        /// Метод для вызова диалогового окна определенного типа.
        /// </summary>
        /// <param name="message">
        /// Текст сообщения в диалоговом окне.
        /// </param>
        /// <param name="header">
        /// Заголовок диалогового окна.
        /// </param>
        /// <param name="type">
        /// Тип диалогового окна.
        /// </param>
        public static void ShowBox(string message, string header, BoxType type)
        {
            boxes[type](message, header);
        }

        /// <summary>
        /// Метод для вызова диалогового окна определенного типа 
        /// с заголовком по умолчанию.
        /// </summary>
        /// <param name="message">
        /// Текст сообщения в диалоговом окне.
        /// </param>
        /// <param name="type">
        /// Тип диалогового окна.
        /// </param>
        public static void ShowBox(string message, BoxType type)
        {
            string header = "А вы знаете что";
            if (type == BoxType.Error)
            {
                header = "Вы пытались сломать формочку";
            }
            else if (type == BoxType.Warning)
            {
                header = "Осторожнее!";
            }
            else if (type == BoxType.Else)
            {
                header = "";
            }

            boxes[type](message, header);
        }

        /// <summary>
        /// Метод для вызова определенного диалогового окна.
        /// </summary>
        /// <param name="theDialog">
        /// Ключ-название этого окна.
        /// </param>
        public static void ShowBox(string theDialog)
        {
            if (dialogues.ContainsKey(theDialog))
            {
                dialogues[theDialog]();
            }
        }
    }
}
