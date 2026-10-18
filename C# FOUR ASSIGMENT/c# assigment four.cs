using System;
using System.Windows.Forms;

namespace RegistrationFeeSystem
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void calculateButton_Click(object sender, EventArgs e)
        {
            // 1. Validation for Student Name and ID
            if (string.IsNullOrWhiteSpace(txtStudentName.Text))
            {
                MessageBox.Show("Please enter the student name.", "Validation Error");
                txtStudentName.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtStudentId.Text))
            {
                MessageBox.Show("Please enter the student ID.", "Validation Error");
                txtStudentId.Focus();
                return;
            }

            // 2. Numeric Validation using TryParse
            if (!int.TryParse(txtNumberOfCourses.Text, out int numberOfCourses) || numberOfCourses <= 0)
            {
                MessageBox.Show("Please enter a valid number of courses.", "Validation Error");
                txtNumberOfCourses.Focus();
                return;
            }

            if (!int.TryParse(txtStudyLevel.Text, out int studyLevel) || studyLevel < 1 || studyLevel > 4)
            {
                MessageBox.Show("Study level must be between 1 and 4.", "Validation Error");
                txtStudyLevel.Focus();
                return;
            }

            if (!double.TryParse(txtTransportFee.Text, out double transportFee) || transportFee < 0)
            {
                MessageBox.Show("Please enter a valid transport fee.", "Validation Error");
                txtTransportFee.Focus();
                return;
            }

            // 3. Fee Calculations
            double courseRate = 50; // $50 per course
            double tuitionFee = numberOfCourses * courseRate;

            // Example Discount logic (e.g. 10% discount for tuition fee)
            double discountRate = 0.10;
            double discount = tuitionFee * discountRate;

            double finalAmount = (tuitionFee - discount) + transportFee;

            // 4. Display Outputs in Labels / TextBoxes
            lblNameResult.Text = "Name : " + txtStudentName.Text;
            lblIdResult.Text = "Id : " + txtStudentId.Text;
            lblCoursesResult.Text = "Number Courses : " + numberOfCourses;
            lblStudyYearResult.Text = "Study year : " + studyLevel;
            lblTransportFeeResult.Text = "Transport Fee : " + transportFee;
            lblDiscountResult.Text = "Discount : " + discount;
            lblTuitionFeeResult.Text = "Tution fee : " + tuitionFee;
            lblFinalAmountResult.Text = "Final Amount : " + finalAmount;
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            txtStudentName.Text = "";
            txtStudentId.Text = "";
            txtNumberOfCourses.Text = "";
            txtStudyLevel.Text = "";
            txtTransportFee.Text = "";

            lblNameResult.Text = "Name :";
            lblIdResult.Text = "Id :";
            lblCoursesResult.Text = "Number Courses :";
            lblStudyYearResult.Text = "Study year :";
            lblTransportFeeResult.Text = "Transport Fee :";
            lblDiscountResult.Text = "Discount :";
            lblTuitionFeeResult.Text = "Tution fee :";
            lblFinalAmountResult.Text = "Final Amount :";

            txtStudentName.Focus();
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}