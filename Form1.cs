using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SpellCheck
{  

    public partial class Form1 : Form
    {
        /*Тут идёт проверка орфографии через свойство SpellCheck текстбокса из WPF (не из Win Forms). 
         * Для импорта впф-текстбокса мы подключили в References библиотеки:
         *  System.Xaml
         *  WindowsFormsIntegration
         *  PresentationCore
         *  PresentationFramework.
         *  В ElementHost -- контейнер для впф-элементов --  мы добавляем текстбокс из впф.
         *  */
        System.Windows.Controls.TextBox textBox1 = new System.Windows.Controls.TextBox();
        string file_content;
        string file_path;
        OpenFileDialog file_dialog = new OpenFileDialog();
        public Form1()
        {
            InitializeComponent();
            file_dialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            this.textBox1.SpellCheck.IsEnabled = true;
            this.textBox1.SpellCheck.CustomDictionaries.Add(new Uri("../lexicon.lex", UriKind.Relative));
            this.elementHost1.Child = this.textBox1;
        }
        private void button_open_file_Click(object sender, EventArgs e)
        {
            if (this.file_dialog.ShowDialog() == DialogResult.Cancel)
                return;
            this.file_path = this.file_dialog.FileName;
            this.file_content = System.IO.File.ReadAllText(this.file_path);
            this.textBox1 = new System.Windows.Controls.TextBox();
            this.textBox1.SpellCheck.IsEnabled = true;
            this.textBox1.Text = this.file_content;
            this.elementHost1.Child = this.textBox1;
            MessageBox.Show("Успешно!");
        }
    }
}
