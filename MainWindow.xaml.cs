using System;
using System.Windows;
using System.Windows.Media;

namespace Prog122_S24_CheckBoxesandRadioButtons
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        // Part 1: Practice
        private void OnCheckStatusClicked(object sender, RoutedEventArgs e)
        {
            string status = "CheckBoxes: " +
                            (CheckBox1.IsChecked == true ? "Option 1 checked " : "Option 1 unchecked ") +
                            (CheckBox2.IsChecked == true ? "Option 2 checked " : "Option 2 unchecked ") +
                            "\nRadioButtons: " +
                            (RadioButton1.IsChecked == true ? "Option A selected" : "Option B selected");

            StatusLabel.Content = status;
        }

        // Part 2: Real World
        private void OnCreateOrderClicked(object sender, RoutedEventArgs e)
        {
            string orderName = OrderNameTextBox.Text;
            bool isOverNight = OvernightCheckBox.IsChecked == true;
            bool isPerishable = PerishableCheckBox.IsChecked == true;

            Order newOrder = new Order(orderName, isOverNight, isPerishable);
            OrderDetailsLabel.Content = newOrder.ToString();
        }

        // Part 3: Change Theme
        private void OnThemeChanged(object sender, RoutedEventArgs e)
        {
            if (Theme1.IsChecked == true)
            {
                this.Background = new SolidColorBrush(Colors.LightBlue);
            }
            else if (Theme2.IsChecked == true)
            {
                this.Background = new SolidColorBrush(Colors.LightGreen);
            }
            else if (Theme3.IsChecked == true)
            {
                this.Background = new SolidColorBrush(Colors.LightCoral);
            }
            else if (Theme4.IsChecked == true)
            {
                this.Background = new SolidColorBrush(Colors.LightGoldenrodYellow);
            }
        }

        // Part 4: Binary Converter
        private void OnConvertToBinaryClicked(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(NumberInput.Text, out int number) && number >= 1 && number <= 255)
            {
                string binary = Convert.ToString(number, 2).PadLeft(8, '0');

                Bit7.IsChecked = binary[0] == '1';
                Bit6.IsChecked = binary[1] == '1';
                Bit5.IsChecked = binary[2] == '1';
                Bit4.IsChecked = binary[3] == '1';
                Bit3.IsChecked = binary[4] == '1';
                Bit2.IsChecked = binary[5] == '1';
                Bit1.IsChecked = binary[6] == '1';
                Bit0.IsChecked = binary[7] == '1';

                BinaryOutputLabel.Content = "Binary: " + binary;
            }
        }

        private void OnConvertFromBinaryClicked(object sender, RoutedEventArgs e)
        {
            string binary = $"{(Bit7.IsChecked == true ? '1' : '0')}" +
                            $"{(Bit6.IsChecked == true ? '1' : '0')}" +
                            $"{(Bit5.IsChecked == true ? '1' : '0')}" +
                            $"{(Bit4.IsChecked == true ? '1' : '0')}" +
                            $"{(Bit3.IsChecked == true ? '1' : '0')}" +
                            $"{(Bit2.IsChecked == true ? '1' : '0')}" +
                            $"{(Bit1.IsChecked == true ? '1' : '0')}" +
                            $"{(Bit0.IsChecked == true ? '1' : '0')}";

            int number = Convert.ToInt32(binary, 2);
            NumberOutputLabel.Content = "Number: " + number;
        }
    }

    public class Order
    {
        public string OrderName { get; set; }
        public bool IsOverNight { get; set; }
        public bool IsPerishable { get; set; }

        public Order(string orderName, bool isOverNight, bool isPerishable)
        {
            OrderName = orderName;
            IsOverNight = isOverNight;
            IsPerishable = isPerishable;
        }

        public override string ToString()
        {
            return $"Name: {OrderName}\nOvernight Delivery: {IsOverNight}\nPerishable: {IsPerishable}";
        }
    }
}
