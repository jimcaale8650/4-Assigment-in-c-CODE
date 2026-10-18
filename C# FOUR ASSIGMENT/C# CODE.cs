using System;
using System.Windows.Forms;

namespace HotelRoomBookingSystem
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void calculateButton_Click(object sender, EventArgs e)
        {
            // 1. Validate Guest Name
            if (string.IsNullOrWhiteSpace(guestNameTextBox.Text))
            {
                MessageBox.Show("Please enter a valid guest name.", "Validation Error");
                guestNameTextBox.Focus();
                return;
            }
            string guestName = guestNameTextBox.Text;

            // 2. Validate Numeric Inputs using TryParse
            if (!int.TryParse(guestAgeTextBox.Text, out int guestAge))
            {
                MessageBox.Show("Guest Age must be a valid number.", "Validation Error");
                guestAgeTextBox.Focus();
                return;
            }

            if (!int.TryParse(numberOfNightsTextBox.Text, out int nights))
            {
                MessageBox.Show("Number of Nights must be a valid number.", "Validation Error");
                numberOfNightsTextBox.Focus();
                return;
            }

            if (!int.TryParse(numberOfGuestTextBox.Text, out int guests))
            {
                MessageBox.Show("Number of Guest must be a valid number.", "Validation Error");
                numberOfGuestTextBox.Focus();
                return;
            }

            // 3. Check Ranges & Accommodation Limits
            if (guestAge < 18 || guestAge > 90)
            {
                MessageBox.Show("Guest age must be between 18 and 90.", "Validation Error");
                return;
            }

            if (nights < 1 || nights > 30)
            {
                MessageBox.Show("Number of nights must be between 1 and 30.", "Validation Error");
                return;
            }

            if (guests < 1 || guests > 6)
            {
                MessageBox.Show("Number of guests must be between 1 and 6.", "Validation Error");
                return;
            }

            // Room Type Guest Capacity Rules
            if (hightRadioButton.Checked && guests > 6) // Suite / Hight
            {
                MessageBox.Show("A Suite can accommodate a maximum of 6 guests.", "Capacity Error");
                return;
            }
            if (standardRadioButton.Checked && guests > 2)
            {
                MessageBox.Show("Standard rooms can accommodate a maximum of 2 guests.", "Capacity Error");
                return;
            }
            if (normalRadioButton.Checked && guests > 4) // Deluxe/Normal
            {
                MessageBox.Show("Deluxe rooms can accommodate a maximum of 4 guests.", "Capacity Error");
                return;
            }

            // Bool flag for booking approval
            bool isBookingApproved = true;

            // 4. Room Rates using switch statement
            decimal ratePerNight = 0m;

            if (standardRadioButton.Checked)
            {
                ratePerNight = 50m;
            }
            else if (normalRadioButton.Checked)
            {
                ratePerNight = 80m;
            }
            else if (hightRadioButton.Checked)
            {
                ratePerNight = 130m;
            }
            else
            {
                MessageBox.Show("Please select a Room Type.", "Selection Error");
                return;
            }

            // 5. Cost Calculations
            decimal subtotal = ratePerNight * nights * guests;

            // Discount based on nights
            decimal nightDiscountRate = 0m;
            if (nights >= 1 && nights <= 4)
            {
                nightDiscountRate = 0m;
            }
            else if (nights >= 5 && nights <= 9)
            {
                nightDiscountRate = 0.05m; // 5% discount
            }
            else if (nights >= 10)
            {
                nightDiscountRate = 0.12m; // 12% discount
            }

            decimal discountAmount = subtotal * nightDiscountRate;
            decimal discountedTotal = subtotal - discountAmount;

            // Breakfast selected: add $10 per guest per night
            decimal breakfastTotal = 0m;
            if (breakFastCheckBox.Checked)
            {
                breakfastTotal = 10m * guests * nights;
            }

            // More than 4 guests: add 5% service surcharge
            decimal serviceSurcharge = 0m;
            if (guests > 4)
            {
                serviceSurcharge = discountedTotal * 0.05m;
            }

            decimal totalBeforeSenior = discountedTotal + breakfastTotal + serviceSurcharge;

            // Guests aged 60 or above: receive an additional 5% senior discount
            decimal seniorDiscount = 0m;
            if (guestAge >= 60)
            {
                seniorDiscount = totalBeforeSenior * 0.05m;
            }

            decimal finalTotal = totalBeforeSenior - seniorDiscount;

            // 6. Display Booking Details in Output Box/Label
            if (isBookingApproved)
            {
                bookingDetailsListBox.Items.Clear(); // Ama bookingDetailsTextBox haduu yahay TextBox multi-line
                bookingDetailsListBox.Items.Add("=== BOOKING APPROVED ===");
                bookingDetailsListBox.Items.Add($"Guest Name: {guestName}");
                bookingDetailsListBox.Items.Add($"Age: {guestAge} | Nights: {nights} | Guests: {guests}");
                bookingDetailsListBox.Items.Add($"Base Room Cost: {subtotal:C}");
                bookingDetailsListBox.Items.Add($"Night Discount: -{discountAmount:C}");
                if (breakFastCheckBox.Checked)
                    bookingDetailsListBox.Items.Add($"Breakfast Total: +{breakfastTotal:C}");
                if (guests > 4)
                    bookingDetailsListBox.Items.Add($"Service Surcharge (5%): +{serviceSurcharge:C}");
                if (guestAge >= 60)
                    bookingDetailsListBox.Items.Add($"Senior Discount (5%): -{seniorDiscount:C}");
                bookingDetailsListBox.Items.Add("----------------------------------------");
                bookingDetailsListBox.Items.Add($"FINAL TOTAL: {finalTotal:C}");
            }
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            guestNameTextBox.Text = "";
            guestAgeTextBox.Text = "";
            numberOfNightsTextBox.Text = "";
            numberOfGuestTextBox.Text = "";
            standardRadioButton.Checked = false;
            normalRadioButton.Checked = false;
            hightRadioButton.Checked = false;
            breakFastCheckBox.Checked = false;
            bookingDetailsListBox.Items.Clear();
            guestNameTextBox.Focus();
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}