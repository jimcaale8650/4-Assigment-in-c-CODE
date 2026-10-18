using System;
using System.Windows.Forms;

namespace VehicleRentalManagementSystem
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btncalculate_Click(object sender, EventArgs e)
        {
            // 1. Validation for Customer Name
            if (string.IsNullOrWhiteSpace(txtname.Text))
            {
                MessageBox.Show("Please enter the customer name.", "Validation Error");
                txtname.Focus();
                return;
            }
            string customerName = txtname.Text;

            // 2. Numeric Validation using TryParse
            if (!int.TryParse(txtage.Text, out int age))
            {
                MessageBox.Show("Please enter a valid age.", "Validation Error");
                txtage.Focus();
                return;
            }

            if (!int.TryParse(txtdays.Text, out int rentalDays))
            {
                MessageBox.Show("Please enter a valid number of rental days.", "Validation Error");
                txtdays.Focus();
                return;
            }

            if (!int.TryParse(txtexperience.Text, out int drivingExperience))
            {
                MessageBox.Show("Please enter valid years of driving experience.", "Validation Error");
                txtexperience.Focus();
                return;
            }

            // Age and Rental Days Rules
            if (age < 18 || age > 80)
            {
                MessageBox.Show("Customer age must be between 18 and 80.", "Validation Error");
                return;
            }

            if (rentalDays < 1 || rentalDays > 30)
            {
                MessageBox.Show("Rental days must be between 1 and 30.", "Validation Error");
                return;
            }

            // 3. Determine Vehicle Type and Daily Rate
            string vehicleType = "";
            double dailyRate = 0;

            if (rdoeconomy.Checked)
            {
                vehicleType = "Economy";
                dailyRate = 40;
            }
            else if (rdosuv.Checked)
            {
                vehicleType = "SUV";
                dailyRate = 70;
            }
            else if (rdoluxury.Checked)
            {
                vehicleType = "Luxury";
                dailyRate = 120;
            }
            else
            {
                MessageBox.Show("Please select a vehicle type.", "Validation Error");
                return;
            }

            // Driving Experience / Eligibility Check for Luxury
            if (rdoluxury.Checked && (age < 25 || drivingExperience < 3))
            {
                MessageBox.Show("To rent a Luxury car, customer must be at least 25 years old and have 3+ years of driving experience.", "Rental Rejected");
                return;
            }

            // 4. Cost Calculations
            double basicRentalCost = dailyRate * rentalDays;

            // Discount based on rental days (e.g., 7+ days gets 10% discount)
            double discountRate = 0;
            if (rentalDays >= 7)
            {
                discountRate = 0.10;
            }
            double discount = basicRentalCost * discountRate;

            // Insurance Cost ($15 per day)
            double insuranceCost = 0;
            if (chkinsurance.Checked)
            {
                insuranceCost = 15 * rentalDays;
            }

            // Young Driver Surcharge (Under 25 pays additional $20 per day)
            double youngDriverSurcharge = 0;
            if (age < 25)
            {
                youngDriverSurcharge = 20 * rentalDays;
            }

            double finalRentalCost = (basicRentalCost - discount) + insuranceCost + youngDriverSurcharge;

            // 5. Display Results in ListBox (lstresults)
            lstresults.Items.Clear();
            lstresults.Items.Add("Rental Details");
            lstresults.Items.Add("-----------------------------------------");
            lstresults.Items.Add("Customer Name        : " + customerName);
            lstresults.Items.Add("Customer Age         : " + age);
            lstresults.Items.Add("Driving Experience   : " + drivingExperience + " years");
            lstresults.Items.Add("Vehicle Type         : " + vehicleType);
            lstresults.Items.Add("Daily Rate           : $" + dailyRate.ToString("F2"));
            lstresults.Items.Add("Rental Days          : " + rentalDays);
            lstresults.Items.Add("Basic Rental Cost    : $" + basicRentalCost.ToString("F2"));
            lstresults.Items.Add("Discount             : $" + discount.ToString("F2"));
            lstresults.Items.Add("Insurance Cost       : $" + insuranceCost.ToString("F2"));
            lstresults.Items.Add("Young Driver Surcharge: $" + youngDriverSurcharge.ToString("F2"));
            lstresults.Items.Add("Final Rental Cost    : $" + finalRentalCost.ToString("F2"));
            lstresults.Items.Add("-----------------------------------------");
            lstresults.Items.Add("Rental Status        : Approved");
        }

        private void btnclear_Click(object sender, EventArgs e)
        {
            txtname.Text = "";
            txtage.Text = "";
            txtdays.Text = "";
            txtexperience.Text = "";
            rdoeconomy.Checked = false;
            rdosuv.Checked = false;
            rdoluxury.Checked = false;
            chkinsurance.Checked = false;
            lstresults.Items.Clear();
            txtname.Focus();
        }

        private void btnexit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}