<Window x:Class="MoneyApp.MainWindow"
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
        xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
        xmlns:local="clr-namespace:MoneyApp"
        mc:Ignorable="d"
        Title="Операции с Money" Height="650" Width="800"
        WindowStartupLocation="CenterScreen"
        MinHeight="500" MinWidth="650"
        >
    <Grid Margin="20">
        <Grid.RowDefinitions>
            <RowDefinition Height="Auto"/>
            <!-- Ввод -->
            <RowDefinition Height="Auto"/>
            <!-- Кнопки -->
            <RowDefinition Height="*"/>
            <!-- Результат -->
            <RowDefinition Height="Auto"/>
            <!-- Кнопка Очистки -->
        </Grid.RowDefinitions>

        <Grid.ColumnDefinitions>
            <ColumnDefinition Width="*"/>
            <ColumnDefinition Width="*"/>
        </Grid.ColumnDefinitions>

        <!-- панель ввода -->
        <Border Grid.Row="0" Grid.Column="0" Grid.ColumnSpan="2"
                BorderBrush="Gray" BorderThickness="1" Padding="10" Margin="0,0,0,10">
            <Grid>
                <Grid.ColumnDefinitions>
                    <ColumnDefinition Width="Auto"/>
                    <!-- метки -->
                    <ColumnDefinition Width="*"/>
                    <!-- поля -->
                    <ColumnDefinition Width="Auto"/>
                    <!-- метки -->
                    <ColumnDefinition Width="*"/>
                    <!-- поля -->
                </Grid.ColumnDefinitions>
                <Grid.RowDefinitions>
                    <RowDefinition Height="Auto"/>
                    <RowDefinition Height="Auto"/>
                    <RowDefinition Height="Auto"/>
                    <RowDefinition Height="Auto"/>
                </Grid.RowDefinitions>
                
                <!-- Элементы для отображения текста -->
                <Label Grid.Row="0" Grid.Column="0" FontWeight="Bold">Сумма 1:</Label>
                <Label Grid.Row="1" Grid.Column="0" Margin="15,0,5,5" Target="{Binding ElementName=txtRub1}">Рубли:</Label>
                <TextBox Grid.Row="1" Grid.Column="1" x:Name="txtRub1" Margin="0,0,10,5" 
                         VerticalContentAlignment="Center" ToolTip="Целое неотрицательное число"/>

                <Label Grid.Row="2" Grid.Column="0" Margin="15,0,5,5" Target="{Binding ElementName=txtKop1}">Копейки:</Label>
                <TextBox Grid.Row="2" Grid.Column="1" x:Name="txtKop1" Margin="0,0,10,5" 
                         VerticalContentAlignment="Center" ToolTip="Число от 0 до 99"/>

                <Label Grid.Row="0" Grid.Column="2" FontWeight="Bold">Сумма 2:</Label>
                <Label Grid.Row="1" Grid.Column="2" Margin="15,0,5,5" Target="{Binding ElementName=txtRub2}">Рубли:</Label>
                <TextBox Grid.Row="1" Grid.Column="3" x:Name="txtRub2" Margin="0,0,0,5" 
                         VerticalContentAlignment="Center" ToolTip="Целое неотрицательное число"/>

                <Label Grid.Row="2" Grid.Column="2" Margin="15,0,5,5" Target="{Binding ElementName=txtKop2}">Копейки:</Label>
                <TextBox Grid.Row="2" Grid.Column="3" x:Name="txtKop2" Margin="0,0,0,5" 
                         VerticalContentAlignment="Center" ToolTip="Число от 0 до 99"/>

                <Label Grid.Row="3" Grid.Column="0" Margin="25,12,5,5" FontWeight="Bold"
                       Target="{Binding ElementName=txtUintValue}">Число:</Label>
                <TextBox Grid.Row="3" Grid.Column="1" x:Name="txtUintValue" Margin="0,10,10,5"
                         VerticalContentAlignment="Center" ToolTip="Целое 
                         неотрицательное число для операций вычитания"/>

            </Grid>
        </Border>

        <!-- панель операций -->
        <Border Grid.Row="1" Grid.Column="0" Grid.ColumnSpan="2"
                BorderBrush="Gray" BorderThickness="1" Padding="5" Margin="129,0,101,10">
            <WrapPanel Orientation="Horizontal" HorizontalAlignment="Center">
                <!-- бинарные -->
                <Button Content="M1 - M2" x:Name="BtnSubtractM1M2" Click="BtnSubtractM1M2_Click" 
                        Margin="3" Padding="8,3"/>
                <Button Content="M1 - UInt" x:Name="BtnSubtractM1Uint" Click="BtnSubtractM1Uint_Click" 
                        Margin="3" Padding="8,3"/>
                <Button Content="UInt - M1" x:Name="BtnSubtractUintM1" Click="BtnSubtractUintM1_Click" 
                        Margin="3" Padding="8,3"/>
                <Separator Margin="10, 0"/>
                <!-- унарные -->
                <Button Content="M1 ++" x:Name="BtnIncrementM1" Click="BtnIncrementM1_Click" 
                        Margin="3" Padding="8,3" ToolTip="Увеличить Сумму 1 на 1 коп."/>
                <Button Content="M1 --" x:Name="BtnDecrementM1" Click="BtnDecrementM1_Click" 
                        Margin="3" Padding="8,3" ToolTip="Уменьшить Сумму 1 на 1 коп."/>
                <Separator Margin="10, 0"/>
                <!-- приведение -->
                <Button Content="(uint)M1" x:Name="BtnCastUintM1" Click="BtnCastUintM1_Click" 
                        Margin="3" Padding="8,3" ToolTip="Привести Сумму 1 к uint (рубли)"/>
                <Button Content="(double)M1" x:Name="BtnCastDoubleM1" Click="BtnCastDoubleM1_Click" 
                        Margin="3" Padding="8,3" ToolTip="Привести Сумму 1 к double (копейки)"/>
            </WrapPanel>
        </Border>

        
        <GroupBox Header="История операций" Grid.Row="2" Grid.Column="0" Grid.ColumnSpan="2" 
                  Margin="0,0,0,5" >
            <ScrollViewer VerticalScrollBarVisibility="Auto">
                <TextBlock x:Name="ResultsLog" TextWrapping="Wrap" />
            </ScrollViewer>
        </GroupBox>

        <Button Grid.Row="3" Grid.Column="1" x:Name="BtnClearLog"
                HorizontalAlignment="Right"
                Content="Очистить историю операций" Click="BtnClearLog_Click"
                Margin="3" Padding="8,3"/>

    </Grid>
</Window>




using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MoneyApp
{

    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
        {
            private readonly StringBuilder _log = new StringBuilder();

            public MainWindow()
            {
                InitializeComponent();
            }


            /// <summary>
            /// Показывает сообщение об ошибке.
            /// </summary>
            private void ShowError(string message)
            {
                MessageBox.Show(message, "Ошибка Ввода/Операции", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            /// <summary>
            /// добавляет запись в лог на экране.
            /// </summary>
            private void LogResult(string message)
            {
                _log.AppendLine(message);
                ResultsLog.Text = _log.ToString();
            }

            /// <summary>
            /// Пытается создать объект Money из пары TextBox,
            /// Показывает MessageBox в случае ошибки.
            /// </summary>
            /// <param name="money">Выходной параметр, содержит null в случае неудачи.</param>
            /// <returns>True, если объект Money успешно создан.</returns>
            private bool TryGetMoney(
                 TextBox rubTb,
                 TextBox kopTb,
            string sourceName,
                 out Money? money)
            {
                money = null;
                string errorMessage;

                if (!InputValidator.TryParseUint(rubTb.Text, $"Рубли ({sourceName})", 
                    out uint rubs, out errorMessage))
                {
                    ShowError(errorMessage);
                    rubTb.Focus();
                    rubTb.SelectAll();
                    return false;
                }

                if (!InputValidator.TryParseByteInRange(kopTb.Text, $"Копейки ({sourceName})", 
                    0, 99, out byte kops, out errorMessage))
                {
                    ShowError(errorMessage);
                    kopTb.Focus();
                    kopTb.SelectAll();
                    return false;
                }

            /// <summary>
            /// Если валидация прошла, создаем объект
            ///  <summary>
                else
                {
                    money = new Money(rubs, kops);
                    return true;
                }
                }

            /// <summary>
            /// Пытается получить uint из TextBox,
            /// </summary>
            private bool TryGetUint(TextBox tb, string fieldName, out uint value)
            {
                if (!InputValidator.TryParseUint(tb.Text, fieldName, out value, out string errorMessage))
                {
                    ShowError(errorMessage);
                    tb.Focus();
                    tb.SelectAll();
                    return false;
                }
                return true;
            }


        /// <summary>
        /// Обработчики Нажатия Кнопок
        /// Бинарные 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnSubtractM1M2_Click(object sender, RoutedEventArgs e)
            {

                    if (!TryGetMoney(txtRub1, txtKop1, "Сумма 1", out Money? m1) || m1 == null)
                        return;

                    if (!TryGetMoney(txtRub2, txtKop2, "Сумма 2", out Money? m2) || m2 == null)
                        return;

                    Money result = m1 - m2;
                    LogResult($"({m1}) - ({m2})  =  {result}");

            }

            private void BtnSubtractM1Uint_Click(object sender, RoutedEventArgs e)
            {

                    if (!TryGetMoney(txtRub1, txtKop1, "Сумма 1", out Money? m1) || m1 == null)
                        return;

                    if (!TryGetUint(txtUintValue, "Число (uint)", out uint value))
                        return;

                    Money result = m1 - value;
                    LogResult($"({m1}) - {value} руб.  =  {result}");

            }

            private void BtnSubtractUintM1_Click(object sender, RoutedEventArgs e)
            {

                    if (!TryGetMoney(txtRub1, txtKop1, "Сумма 1", out Money? m1) || m1 == null)
                        return;

                    if (!TryGetUint(txtUintValue, "Число (uint)", out uint value))
                        return;

                    Money result = value - m1;
                    LogResult($"{value} руб. - ({m1})  =  {result}");
                
            }

            /// <summary>
            /// Унарные 
            /// </summary>
            /// <param name="sender"></param>
            /// <param name="e"></param>
            private void BtnIncrementM1_Click(object sender, RoutedEventArgs e)
            {

                    if (!TryGetMoney(txtRub1, txtKop1, "Сумма 1", out Money? m1) || m1 == null)
                        return;

                    Money original = new Money(m1.Rubles, m1.Kopeks); 
                    m1++; 

                    LogResult($"++({original})  =  {m1}");

                /// <summary>
                /// Обновляем поля ввода, чтобы видеть результат
                /// <summary>
                    txtRub1.Text = m1.Rubles.ToString();
                    txtKop1.Text = m1.Kopeks.ToString();

            }

            private void BtnDecrementM1_Click(object sender, RoutedEventArgs e)
            {

                    if (!TryGetMoney(txtRub1, txtKop1, "Сумма 1", out Money? m1) || m1 == null)
                        return;

                    Money original = new Money(m1.Rubles, m1.Kopeks); 
                    m1--; 

                    LogResult($"--({original})  =  {m1}");

                    txtRub1.Text = m1.Rubles.ToString();
                    txtKop1.Text = m1.Kopeks.ToString();

            }

            /// <summary>
            /// Приведение Типов 
            /// </summary>
            /// <param name="sender"></param>
            /// <param name="e"></param>
            private void BtnCastUintM1_Click(object sender, RoutedEventArgs e)
            {
                    if (!TryGetMoney(txtRub1, txtKop1, "Сумма 1", out Money? m1) || m1 == null)
                        return;
                /// <summary>
                /// Неявное приведение
                /// <summary>
                uint result = m1; 

                    LogResult($"(uint)({m1})  =  {result}");
            }

            private void BtnCastDoubleM1_Click(object sender, RoutedEventArgs e)
            {
                    if (!TryGetMoney(txtRub1, txtKop1, "Сумма 1", out Money? m1) || m1 == null)
                        return;
                /// <summary>
                /// Явное приведение
                /// <summary>
                double result = (double)m1; 

                    LogResult($"(double)({m1})  =  {result.ToString("F2", CultureInfo.InvariantCulture)}");
            }

            /// <summary>
            /// Управление логом
            /// </summary>
            /// <param name="sender"></param>
            /// <param name="e"></param>
            private void BtnClearLog_Click(object sender, RoutedEventArgs e)
            {
                _log.Clear();
                ResultsLog.Text = string.Empty;
            }
        }
    }






using System;

namespace MoneyApp
{
    /// <summary>
    /// Класс для представления денежной величины.
    /// </summary>
    public class Money
    {
        /// <summary>
        /// Свойства с публичным геттером и приватным сеттером,
        /// чтобы изменение шло только через конструктор и операторы.
        /// </summary>

        public uint Rubles { get; private set; }
        public byte Kopeks { get; private set; }

        public Money(uint rubles, byte kopeks)
        {

            if (kopeks > 99)
            {
                throw new ArgumentOutOfRangeException(nameof(kopeks), "Количество копеек не может быть больше 99.");
            }
            this.Rubles = rubles;
            this.Kopeks = kopeks;
        }


        /// <summary>
        /// ++m
        /// </summary>
        /// <param name="m"></param>
        /// <returns></returns>
        public static Money operator ++(Money m)
        {
            long totalKopeks = ((long)m.Rubles * 100 + m.Kopeks) + 1;
            uint newRubles = (uint)(totalKopeks / 100);
            byte newKopeks = (byte)(totalKopeks % 100);
            return new Money(newRubles, newKopeks);
        }

        /// <summary>
        /// --m
        /// </summary>
        /// <param name="m"></param>
        /// <returns></returns>
        public static Money operator --(Money m)
        {
            if (m.Rubles == 0 && m.Kopeks == 0)
            {
                return new Money(0, 0); 
            }

            long totalKopeks = ((long)m.Rubles * 100 + m.Kopeks) - 1;
            uint newRubles = (uint)(totalKopeks / 100);
            byte newKopeks = (byte)(totalKopeks % 100);
            return new Money(newRubles, newKopeks);
        }

        /// <summary>
        /// Money - Money
        /// </summary>
        /// <param name="m1"></param>
        /// <param name="m2"></param>
        /// <returns></returns>
        public static Money operator -(Money m1, Money m2)
        {
            long total1 = (long)m1.Rubles * 100 + m1.Kopeks;
            long total2 = (long)m2.Rubles * 100 + m2.Kopeks;

            long difference = total1 - total2;

            if (difference < 0)
            {
                return new Money(0, 0); 
            }
            else
            {
                uint rub = (uint)(difference / 100);
                byte kop = (byte)(difference % 100);
                return new Money(rub, kop);
            }
        }

        /// <summary>
        /// Money - uint
        /// </summary>
        /// <param name="m"></param>
        /// <param name="rublesToSubtract"></param>
        /// <returns></returns>
        public static Money operator -(Money m, uint rublesToSubtract)
        {
            long totalKopeks = (long)m.Rubles * 100 + m.Kopeks;
            long kopeksToSubtract = (long)rublesToSubtract * 100;

            long difference = totalKopeks - kopeksToSubtract;
            if (difference < 0)
            {
                return new Money(0, 0);
            }
            else
            {
                uint rub = (uint)(difference / 100);
                byte kop = (byte)(difference % 100);
                return new Money(rub, kop);
            }
        }

        /// <summary>
        /// uint - Money
        /// </summary>
        /// <param name="rublesValue"></param>
        /// <param name="m"></param>
        /// <returns></returns>
        public static Money operator -(uint rublesValue, Money m)
        {
            long totalKopeks = (long)rublesValue * 100;
            long kopeksToSubtract = (long)m.Rubles * 100 + m.Kopeks;

            long difference = totalKopeks - kopeksToSubtract;

            if (difference < 0)
            {
                return new Money(0, 0);
            }
            else
            {
                uint rub = (uint)(difference / 100);
                byte kop = (byte)(difference % 100);
                return new Money(rub, kop);
            }
        }



        /// <summary>
        /// uint
        /// </summary>
        /// <param name="m"></param>
        public static implicit operator uint(Money m)
        {
            return m.Rubles;
        }

        /// <summary>
        /// double
        /// </summary>
        /// <param name="m"></param>
        public static explicit operator double(Money m)
        {
            return (double)m.Kopeks / 100.0;
        }

        public override string ToString()
        {
            
            return $"{Rubles} руб. {Kopeks:D2} коп.";
        }
    }
}





using System.Globalization;

namespace MoneyApp
{
    /// <summary>
    /// Статический класс для валидации ввода в WPF приложении.
    /// Методы возвращают true/false и сообщение об ошибке через out параметр.
    /// </summary>
    public static class InputValidator
    {
        /// <summary>
        /// Проверяет строку на возможность преобразования в uint.
        /// </summary>
        /// <param name="inputText">Текст для проверки.</param>
        /// <param name="fieldName">Имя поля (для сообщения об ошибке).</param>
        /// <param name="value">Результат парсинга.</param>
        /// <param name="errorMessage">Сообщение об ошибке, если результат false.</param>
        /// <returns>True, если проверка прошла успешно.</returns>
        public static bool TryParseUint(string inputText, string fieldName, 
            out uint value, out string errorMessage)
        {
            value = 0;
            errorMessage = string.Empty;

            if (string.IsNullOrWhiteSpace(inputText))
            {
                errorMessage = $"Поле '{fieldName}' не должно быть пустым.";
                return false;
            }

            if (uint.TryParse(inputText, NumberStyles.Integer, 
                CultureInfo.InvariantCulture, out value))
            {
                return true; 
            }
            else
            {
                errorMessage = $"Некорректное значение в поле " +
                    $"'{fieldName}'.\nОжидается целое неотрицательное число.";
                return false; 
            }
        }

        /// <summary>
        /// Проверяет строку на возможность преобразования в byte и на вхождение в диапазон.
        /// </summary>
        /// <param name="inputText">Текст для проверки.</param>
        /// <param name="fieldName">Имя поля (для сообщения об ошибке).</param>
        /// <param name="min">Минимальное допустимое значение.</param>
        /// <param name="max">Максимальное допустимое значение.</param>
        /// <param name="value">Результат парсинга.</param>
        /// <param name="errorMessage">Сообщение об ошибке, если результат false.</param>
        /// <returns>True, если проверка прошла успешно.</returns>
        public static bool TryParseByteInRange(string inputText, string fieldName, 
            byte min, byte max, out byte value, out string errorMessage)
        {
            value = 0;
            errorMessage = string.Empty;

            if (string.IsNullOrWhiteSpace(inputText))
            {
                errorMessage = $"Поле '{fieldName}' не должно быть пустым.";
                return false;
            }

            if (!byte.TryParse(inputText, NumberStyles.Integer, 
                CultureInfo.InvariantCulture, out value))
            {
                errorMessage = $"Некорректное значение в поле " +
                    $"'{fieldName}'.\nОжидается целое число.";
                return false; 
            }

            if (value >= min && value <= max)
            {
                return true; 
            }
            else
            {
                errorMessage = $"Значение {value} в поле '{fieldName}'" +
                    $" выходит за допустимый диапазон ({min}-{max}).";
                return false; 
            }
        }


    }
}


