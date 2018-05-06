using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CST_117_Exercise_4
{
    public partial class SecondsConversionForm : Form
    {
        int seconds = 0;
        int minutes = 0;
        int hours = 0;
        int days = 0;

        public SecondsConversionForm()
        {
            InitializeComponent();
        }

        private void calculateButton_Click(object sender, EventArgs e)
        {
            seconds = 0;
            minutes = 0;
            hours = 0;
            days = 0;
            bool result = Int32.TryParse(secondsTextBox.Text, out seconds);
            if (result) {
                convert();
                writeMessage();
            } else {
                MessageBox.Show("Please enter an Integer for seconds.");
            }
        }
        private void convert()
        {
            if (seconds >= 86400) {
                calculateDays();
            } else if (seconds >= 3600) {
                calculateHours();
            } else if (seconds >= 60) {
                calculateMinutes();
            }
        }
        private void calculateDays()
        {
            days = seconds / 86400;
            seconds = seconds % 86400;
            calculateHours();
        }
        private void calculateHours()
        {
            hours = seconds / 3600;
            seconds = seconds % 3600;
            calculateMinutes();
        }
        private void calculateMinutes()
        {
            minutes = seconds / 60;
            seconds = seconds % 60;
        }

        private void writeMessage()
        {
            resultLabel.Text = "Seconds: "+seconds+"\n" +
                "Minutes: "+minutes+"\n"+
                "Hours: "+hours+"\n"+
                "Days: "+days;
        }
    }
}
