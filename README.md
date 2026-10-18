# 4-Assigment-in-c-CODE


C# Windows Forms Lab Assignments (README)
This repository contains four comprehensive C# Windows Forms applications built with Visual Studio, demonstrating form designs, input validation, control logic, cost calculations, and user experience patterns.

1. Hotel Room Booking System
📌 Overview
The Hotel Room Booking System allows guests or reception staff to calculate the total stay cost based on room types, duration, guest capacity, and selected add-ons.

🛠️ Key Features & Validation Rules
Input Validation:

Uses int.TryParse to validate guest age, number of nights, and number of guests.

Ensures guest age is within 18–90 years.

Restricts booking duration between 1–30 nights.

Restricts capacity between 1–6 guests.

Room Capacity Constraints:

Standard: Max 2 guests.

Normal (Deluxe): Max 4 guests.

Hight (Suite): Max 6 guests.

Pricing & Discounts:

Rates: Standard ($50/night), Normal ($80/night), Hight ($130/night).

Nights Discount: 5% for 5–9 nights; 12% for 10+ nights.

Breakfast Option: Adds $10 per guest per night.

Service Surcharge: 5% added if total guests exceed 4.

Senior Discount: Additional 5% discount for guests aged 60 or above.

2. Airline Ticket Booking System
📌 Overview
The Airline Ticket Booking System processes flight reservations, evaluating passenger eligibility, ticket quantities, luggage constraints, and applicable travel discounts.

🛠️ Key Features & Validation Rules
Passenger Eligibility & Rules:

Validates age (between 1 and 100 years).

Limits ticket purchases between 1 and 5 tickets.

Restricts luggage to a maximum of 50 kg per passenger.

First Class Restriction: Rejects bookings for passengers under 12 years attempting to book First Class.

Cost Structure & Discounts:

Ticket Quantity Discounts: 5% discount for 3–4 tickets; 10% discount for 5 tickets.

Age Discounts: 20% child discount (<12 years); 10% senior discount (≥60 years).

Travel Insurance Option: Adds $25 per ticket.

Baggage Allowance: Free up to 20 kg per passenger.

3. Vehicle Rental Management System
📌 Overview
The Vehicle Rental Management System manages vehicle rentals by validating driver qualifications, rental period, vehicle selection, and optional insurance policies.

🛠️ Key Features & Validation Rules
Driver & Rental Validations:

Customer age must be between 18 and 80 years.

Rental period must be between 1 and 30 days.

Luxury Vehicle Rule: Demands a minimum driver age of 25 years and at least 3 years of driving experience.

Vehicle Options & Rates:

Economy: $40/day.

SUV: $70/day.

Luxury: $120/day.

Surcharges & Discounts:

Long-Term Discount: 10% discount for rentals of 7 days or more.

Insurance Add-on: $15 per day.

Young Driver Surcharge: Additional $20 per day fee for drivers under 25 years old.

4. Course Registration Fee System
📌 Overview
The Course Registration Fee System calculates tuition, transport, and overall academic enrollment fees for university students based on course loads and study levels.

🛠️ Key Features & Validation Rules
Student Data Processing:

Validates non-empty input for Student Name and Student ID.

Validates course range and limits study levels between Year 1 and Year 4.

Financial Calculations:

Base tuition calculated per course ($50/course).

Applies standard academic discounts to total tuition fees.

Factoring in additional transport fees.

Generates an itemized breakdown including student ID, level, discounts, and total final fee.

💻 Tech Stack & Requirements
Language: C# (.NET Framework / .NET Core)

UI Framework: Windows Forms (WinForms)

IDE: Microsoft Visual Studio 2019 / 2022
