﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPFTutorial
{
    /// <summary>
    /// CalculateControl.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class CalculateControl : UserControl, INotifyPropertyChanged
    {
        public CalculateControl()
        {
            InitializeComponent();
        }
        void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public Brush TextBoxForeground { get; set; } = Brushes.Black;
        public Brush TextBoxBackground { get; set; } = Brushes.White;
        public Brush UserControlBackground { get; set; } = Brushes.White;

        public static readonly DependencyProperty Value1Property =
            DependencyProperty.Register("Value1", typeof(decimal), typeof(CalculateControl), new PropertyMetadata(0m, OnValueChanged, CoerceLimitValue));

        public static readonly DependencyProperty Value2Property =
            DependencyProperty.Register("Value2", typeof(decimal), typeof(CalculateControl), new PropertyMetadata(0m, OnValueChanged, CoerceLimitValue));

        public static readonly DependencyProperty OperatorProperty =
           DependencyProperty.Register("Operator", typeof(string), typeof(CalculateControl), new PropertyMetadata("+", OnValueChanged), new ValidateValueCallback(IsValidOperator));

        public static readonly DependencyProperty DesignModeProperty =
            DependencyProperty.Register("DesignMode", typeof(DesignMode), typeof(CalculateControl), new PropertyMetadata(DesignMode.DARK, OnDesignModeChanged));

        public string Operator
        {
            get { return (string)GetValue(OperatorProperty); }
            set { SetValue(OperatorProperty, value); }
        }

        public decimal Value1
        {
            get { return (decimal)GetValue(Value1Property); }
            set { SetValue(Value1Property, value); }
        }

        public decimal Value2
        {
            get { return (decimal)GetValue(Value2Property); }
            set { SetValue(Value2Property, value); }
        }
        public DesignMode DesignMode
        {
            get { return (DesignMode)GetValue(DesignModeProperty); }
            set { SetValue(DesignModeProperty, value); }
        }
        private static object CoerceLimitValue(DependencyObject d, object baseValue)
        {
            decimal value = (decimal)baseValue;

            if (value < -9999)
            {
                return -9999m;
            }
            else if (value > 9999)
            {
                return 9999m;
            }
            else
            {
                return value;
            }
        }

        private static bool IsValidOperator(object value)
        {
            string oper = (string)value;

            return oper switch
            {
                "+" or "-" or "*" or "/" => true,
                _ => false,
            };
        }

        private void ChangeDesignMode(DesignMode designMode)
        {
            if (designMode == DesignMode.WHITE)
            {
                TextBoxForeground = Brushes.Black;
                TextBoxBackground = Brushes.White;
                UserControlBackground = Brushes.Black;
            }
            else
            {
                TextBoxForeground = Brushes.White;
                TextBoxBackground = Brushes.DarkGray;
                UserControlBackground = Brushes.Black;
            }

            OnPropertyChanged(nameof(TextBoxForeground));
            OnPropertyChanged(nameof(TextBoxBackground));
            OnPropertyChanged(nameof(UserControlBackground));
        }


        private static void OnDesignModeChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            CalculateControl calculateControl = (CalculateControl)d;
            if(e.NewValue != e.OldValue)
            {
                if(e.NewValue is DesignMode designMode)
                {
                    calculateControl.ChangeDesignMode(designMode);
                }
            }
        }
 

        private static void OnValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            CalculateControl calculateControl = (CalculateControl)d;
            calculateControl.OnPropertyChanged(nameof(Result));
        }

        public decimal Result => Operator switch
        {
            "+" => Value1 + Value2,
            "-" => Value1 - Value2,
            "*" => Value1 * Value2,
            "/" => Value2 == 0 ? 0 : Math.Round(Value1 / Value2, 2),
            _ => 0
        };
    }
}
