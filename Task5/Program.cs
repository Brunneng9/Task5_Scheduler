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
            int input;
            while (value != 0)
            {
                priority = Priority.Error;
                complexity = Complexity.Error;
                Console.WriteLine($"Task # {number}");
                Console.WriteLine("Select task priority:");
                Console.WriteLine("1 - High");
                Console.WriteLine("2 - Medium");
                Console.WriteLine("3 - Low");
			
				input = GetOneOfPossibleNumbers(3);

                if (input == 1)
                {
                    priority = Priority.High;
                }
                else if (input == 2)
                {
                    priority = Priority.Medium;
                }
                else 
                {
                    priority = Priority.Low;
                }

                Console.WriteLine("Select task complexity:");
                Console.WriteLine("1 - Complex");
                Console.WriteLine("2 - Average");
                Console.WriteLine("3 - Easy");
                input = GetOneOfPossibleNumbers(3);
				if (input == 1)
                {
                    complexity = Complexity.Complex;
                }
                else if (input == 2)
                {
                    complexity = Complexity.Average;
                }
                else
                {
                    complexity = Complexity.Easy;
                }
                Console.WriteLine("Create another task?");
                Console.WriteLine("1 - Yes");
                Console.WriteLine("2 - No");
				
				input = GetOneOfPossibleNumbers(2);
                if (input == 1)
                {
                    number++;
                }
                else 
                {
                    value = 0;
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
            input = GetOneOfPossibleNumbers(3);
            if (input == 1)
            {
                priority = Priority.High;
            }
            else if (input == 2)
            {
                priority = Priority.Medium;
            }
            else 
            {
                priority = Priority.Low;
            }
            
            sum = 0;
            
            for (int i = 0; i < number; i++)
            {
                if (priority.ToString() == table.Rows[i].Field<string>(0))
                {
                    sum++;
                }
            }
            Console.WriteLine($"Number of tasks with {priority} priority = {sum}");

		
			Console.WriteLine("Please enter a number of days");

			int daysNumber = GetPositiveIntegerValueFromConsole();
            
            int hoursQuantity = daysNumber * 24;
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
            Console.ReadKey();




        }

		private static int GetOneOfPossibleNumbers(int quantity)
		{
			int enteredValue;
			while (true)
			{
				if (int.TryParse(Console.ReadLine(), out enteredValue) && enteredValue > 0)
				{
					if (enteredValue <= quantity)
					{
						goto ReturnResult;
					}
					else
					{
						Console.WriteLine($"Value should be less or equal {quantity}");
					}

				}
				
				else
				{
					Console.WriteLine("Value should be positive integer");
				}

			}
			ReturnResult:
			return enteredValue;
		}

		private static int GetPositiveIntegerValueFromConsole()
		{
			int intValue;
		while(true)
		{
		if (int.TryParse(Console.ReadLine(), out intValue) && intValue > 0)
		{
					break;
		}
		else
		{
					Console.WriteLine("Value should be integer positive");
		}
		}
			return intValue;
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

        
    

