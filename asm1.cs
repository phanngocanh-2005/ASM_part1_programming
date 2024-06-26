using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASM
{
    internal class Program
    {
        static void Main(string[] args)
        { 

            string customer_name;
            double last_month;
            double this_month;
            string toc;
            int number = 0; // Initialize number of people
            double consumption;
            double price;
            double total_bill;

            // Function 1: Input Handling and Initialization
            InputHandlingAndInitialization(out customer_name, out last_month, out this_month, out toc);

            // Function 2: Calculate Consumption and Price
            consumption = CalculateConsumptionAndPrice(last_month, this_month, toc, out number, out price);

            // Function 3: Calculate Total Bill
            total_bill = CalculateTotalBill(consumption, price);

            // Function 4: Display Results
            DisplayResults(customer_name, last_month, this_month, toc, consumption, total_bill);

            Console.ReadLine();
        }

        // Function 1: Input Handling and Initialization
        static void InputHandlingAndInitialization(out string customer_name, out double last_month, out double this_month, out string toc)
        {
            Console.WriteLine("Enter customer name:");
            customer_name = Console.ReadLine();

            Console.WriteLine("Enter last month’s water meter readings:");
            last_month = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Enter this month’s water meter readings:");
            this_month = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Enter type of customer:");
            toc = Console.ReadLine();
        }

        // Function 2: Calculate Consumption and Price
        static double CalculateConsumptionAndPrice(double last_month, double this_month, string toc, out int number, out double price)
        {
            double consumption = this_month - last_month;
            number = 0;
            price = 0;

            if (toc == "Household customer")
            {
                Console.WriteLine("Enter number of people:");
                number = Convert.ToInt32(Console.ReadLine());

                if (number <= 0)
                {
                    Console.WriteLine("Invalid input for number of people. Please enter a valid number.");
                    return 0;
                }

                consumption /= number; // Calculate consumption per person
            }

            if (toc == "Household customer")
            {
                if (consumption <= 10)
                {
                    price = 5.973;
                }
                else if (consumption <= 20)
                {
                    price = 7.052;
                }
                else if (consumption <= 30)
                {
                    price = 8.699;
                }
                else
                {
                    price = 15.929;
                }
            }
            else if (toc == "Administrative agency, public services")
            {
                price = 9.955;
            }
            else if (toc == "Production units")
            {
                price = 11.615;
            }
            else if (toc == "Business services")
            {
                price = 22.068;
            }
            else
            {
                Console.WriteLine("Invalid type of customer.");
            }

            return consumption;
        }

        // Function 3: Calculate Total Bill
        static double CalculateTotalBill(double consumption, double price)
        {
            double total_bill = (consumption * price) + ((consumption * price) * 0.1) + ((consumption * price) * 0.1);
            return total_bill;
        }

        // Function 4: Display Results
        static void DisplayResults(string customer_name, double last_month, double this_month, string toc, double consumption, double total_bill)
        {
            Console.WriteLine("Customer name: {0}", customer_name);
            Console.WriteLine("Last month’s water meter readings: {0}", last_month);
            Console.WriteLine("This month’s water meter readings: {0}", this_month);
            Console.WriteLine("Type of customer: {0}", toc);
            Console.WriteLine("Consumption: {0}", consumption);
            Console.WriteLine("Total water bill: {0}", total_bill);
        }
    }
}
