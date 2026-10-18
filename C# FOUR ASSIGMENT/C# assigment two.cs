using System;
using System.Windows.Forms;

namespace AirlineTicketBookingSystem
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void calculateButton_Click(object sender, EventArgs e)
        {
            // 1. Passenger Name Validation
            if (string.IsNullOrWhiteSpace(passengerNameTextBox.Text))
            {
                MessageBox.Show("Please enter passenger name.", "Error");
                passengerNameTextBox.Focus();
                return;
            }
            string passengerName = passengerNameTextBox.Text;

            // 2. Numeric Validation using TryParse
            if (!int.TryParse(passengerAgeTextBox.Text, out int age))
            {
                MessageBox.Show("Invalid age format.", "Error");
                passengerAgeTextBox.Focus();
                return;
            }

            if (!int.TryParse(numberOfTicketsTextBox.Text, out int tickets))
            {
                MessageBox.Show("Invalid number of tickets.", "Error");
                numberOfTicketsTextBox.Focus();
                return;
            }

            if (!double.TryParse(baggageWeightTextBox.Text, out double baggageWeight))
            {
                MessageBox.Show("Invalid baggage weight.", "Error");
                baggageWeightTextBox.Focus();
                return;
            }

            // 3. Validation Rules Check
            bool bookingApproved = true;

            if (age < 1 || age > 100)
            {
                MessageBox.Show("Passenger age must be between 1 and 100 years.", "Validation Error");
                return;
            }

            if (tickets < 1 || tickets > 5)
            {
                MessageBox.Show("Number of tickets must be between 1 and 5.", "Validation Error");
                return;
            }

            double maxBaggageAllowed = 50.0 * tickets; // 50 kg per passenger
            if (baggageWeight < 0 || baggageWeight > maxBaggageAllowed)
            {
                MessageBox.Show($"Baggage weight cannot be negative and cannot exceed {maxBaggageAllowed} kg.", "Validation Error");
                return;
            }

            // Age below 12 cannot book First Class
            if (age < 12 && firstClassRadioButton.Checked)
            {
                bookingApproved = false;
                MessageBox.Show("Booking Rejected: Passengers below 12 years cannot book First Class.", "Booking Rejected");
                return;
            }

            // 4. Determine Travel Class Ticket Price
            decimal ticketPrice = 0m;
            if (firstClassRadioButton.Checked)
            {
                ticketPrice = 300m; // Example price for First Class
            }
            else if (normalClassRadioButton.Checked)
            {
                ticketPrice = 150m; // Example price for Normal Class
            }
            else if (businessClassRadioButton.Checked)
            {
                ticketPrice = 250m; // Example price for Business Class
            }
            else
            {
                MessageBox.Show("Please select a travel class.", "Validation Error");
                return;
            }

            // 5. Cost Calculations
            decimal basicTicketCost = ticketPrice * tickets;

            // Ticket Quantity Discount
            decimal ticketDiscountRate = 0m;
            if (tickets >= 3 && tickets <= 4)
            {
                ticketDiscountRate = 0.05m; // 5%
            }
            else if (tickets == 5)
            {
                ticketDiscountRate = 0.10m; // 10%
            }

            decimal ticketDiscount = basicTicketCost * ticketDiscountRate;
            decimal costAfterTicketDiscount = basicTicketCost - ticketDiscount;

            // Age Discount (Child 20% OR Senior 10%)
            decimal ageDiscountRate = 0m;
            if (age < 12)
            {
                ageDiscountRate = 0.20m; // 20% child discount
            }
            else if (age >= 60)
            {
                ageDiscountRate = 0.10m; // 10% senior discount
            }

            decimal ageDiscount = costAfterTicketDiscount * ageDiscountRate;
            decimal costAfterAgeDiscount = costAfterTicketDiscount - ageDiscount;

            // Travel Insurance ($25 Per Ticket)
            decimal insuranceCost = 0m;
            if (addInsuranceCheckBox.Checked)
            {
                insuranceCost = 25m * tickets;
            }

            // Baggage: Up to 20 kg per passenger is Free
            decimal totalCost = costAfterAgeDiscount + insuranceCost;

            // 6. Display Output
            if (bookingApproved)
            {
                bookingDetailsListBox.Items.Clear();
                bookingDetailsListBox.Items.Add("=== AIRLINE BOOKING DETAILS ===");
                bookingDetailsListBox.Items.Add($"Passenger Name: {passengerName}");
                bookingDetailsListBox.Items.Add($"Age: {age} | Tickets: {tickets} | Baggage: {baggageWeight} kg");
                bookingDetailsListBox.Items.Add($"Basic Ticket Cost: {basicTicketCost:C}");
                if (ticketDiscount > 0)
                    bookingDetailsListBox.Items.Add($"Ticket Discount: -{ticketDiscount:C}");
                if (ageDiscount > 0)
                    bookingDetailsListBox.Items.Add($"Age Discount: -{ageDiscount:C}");
                if (addInsuranceCheckBox.Checked)
                    bookingDetailsListBox.Items.Add($"Travel Insurance: +{insuranceCost:C}");
                bookingDetailsListBox.Items.Add("-----------------------------------------");
                bookingDetailsListBox.Items.Add($"TOTAL COST: {totalCost:C}");
            }
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            passengerNameTextBox.Text = "";
            passengerAgeTextBox.Text = "";
            numberOfTicketsTextBox.Text = "";
            baggageWeightTextBox.Text = "";
            firstClassRadioButton.Checked = false;
            normalClassRadioButton.Checked = false;
            businessClassRadioButton.Checked = false;
            addInsuranceCheckBox.Checked = false;
            bookingDetailsListBox.Items.Clear();
            passengerNameTextBox.Focus();
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}