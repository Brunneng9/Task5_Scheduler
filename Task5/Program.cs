using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Task5_Scheduler
{
    class Program
    {
        static void Main(string[] args)
        {
            Priority priority;
            Complexity complexity;
            DataTable table = new DataTable();
            table.Columns.Add("Priority", typeof(string));
            table.Columns.Add("Complexity", typeof(int));


            Console.WriteLine("Lets create our schedule");
            int sum = 0;
            int value = 1;
            int number = 1;
            char input;
            while (value != 0)
            {
                priority = Priority.Error;
                complexity = Complexity.Error;
                Console.WriteLine($"Task # {number}");
                Console.WriteLine("Select task priority:");
                Console.WriteLine("1 - High");
                Console.WriteLine("2 - Medium");
                Console.WriteLine("3 - Low");
                try
                {
                    input = Convert.ToChar(Console.ReadLine());
                }
                catch
                {
                    Console.WriteLine("Try to follow instructions nex time");
                    return;
                }
                if (input == '1')
                {
                    priority = Priority.High;
                }
                else if (input == '2')
                {
                    priority = Priority.Medium;
                }
                else if (input == '3')
                {
                    priority = Priority.Medium;
                }
                Console.WriteLine("Select task complexity:");
                Console.WriteLine("1 - Complex");
                Console.WriteLine("2 - Average");
                Console.WriteLine("3 - Easy");
                input = Convert.ToChar(Console.ReadLine());
                if (input == '1')
                {
                    complexity = Complexity.Complex;
                }
                else if (input == '2')
                {
                    complexity = Complexity.Average;
                }
                else if (input == '3')
                {
                    complexity = Complexity.Complex;
                }
                Console.WriteLine("Create another task?");
                Console.WriteLine("1 - Yes");
                Console.WriteLine("2 - No");
                try
                {
                    input = Convert.ToChar(Console.ReadLine());
                }
                catch
                {
                    Console.WriteLine("Try to follow instructions nex time");
                    return;
                }
                if (input == '1')
                {
                    number++;
                }
                else if (input == '2')
                {
                    value = 0;
                }
                else
                {
                    Console.WriteLine("Try to follow instructions nex time");
                    return;
                }
                if (priority == Priority.Error || complexity == Complexity.Error)
                {
                    Console.WriteLine("Try to follow instructions nex time");
                    return;
                }
                table.Rows.Add(priority, (int)complexity);




            }

            for (int i = 0; i < number; i++)
            {
                sum = sum + (table.Rows[i].Field<int>(1));
            }

            Console.WriteLine($"Total time needed = {sum} hours");



            Console.WriteLine("Select task priority:");
            Console.WriteLine("1 - High");
            Console.WriteLine("2 - Medium");
            Console.WriteLine("3 - Low");
            input = Convert.ToChar(Console.ReadLine());
            if (input == '1')
            {
                priority = Priority.High;
            }
            else if (input == '2')
            {
                priority = Priority.Medium;
            }
            else if (input == '3')
            {
                priority = Priority.Medium;
            }
            else
            {
                Console.WriteLine("Try to follow instructions nex time");
                return;
            }
            sum = 0;
            string s = priority.ToString();
            for (int i = 0; i < number; i++)
            {
                if (s == table.Rows[i].Field<string>(0))
                {
                    sum++;
                }
            }
            Console.WriteLine($"Number of tasks with {priority} priority = {sum}");

            Console.WriteLine("Please enter a number of days");
            string daysNumber = Console.ReadLine();
            int daysNumberInt;
            try
            {
                daysNumberInt = int.Parse(daysNumber);
            }
            catch
            {
                Console.WriteLine("Value should be integer");
                return;
            }
            int hoursQuantity = daysNumberInt * 24;
            List<int> taskList = new List<int>();
            int taskPosition = 1;


            for (int i = 0; i < number; i++)
            {
                if (hoursQuantity > 0)
                {
                    if ((table.Rows[i].Field<string>(0) == "High"))
                    {
                        taskList.Add(i + 1);
                        hoursQuantity = hoursQuantity - (table.Rows[i].Field<int>(1));
                        taskPosition++;
                    }
                }
            }
            for (int i = 0; i < number; i++)
            {
                if (hoursQuantity > 0)
                {
                    if ((table.Rows[i].Field<string>(0) == "Medium"))
                    {
                        taskList.Add(i + 1);
                        hoursQuantity = hoursQuantity - (table.Rows[i].Field<int>(1));
                        taskPosition++;
                    }
                }

            }
            for (int i = 0; i < number; i++)
            {
                if (hoursQuantity > 0)
                {
                    if ((table.Rows[i].Field<string>(0) == "Low"))
                    {
                        taskList.Add(i + 1);
                        hoursQuantity = hoursQuantity - (table.Rows[i].Field<int>(1));
                        taskPosition++;
                    }
                }

            }
            if (hoursQuantity < 0)
            {
                taskList.Remove(taskPosition - 1);
            }
            Console.WriteLine("You are able to complete next tasks");
            foreach (int position in taskList)
            {
                Console.Write($"{position}  ");
            }
            




        }
    }
}
        enum Priority
        {
            Error,
            High,
            Medium,
            Low
        }
        enum Complexity
        {
            Error = 0,
            Complex = 4,
            Average = 2,
            Easy = 1

        }

        
    

