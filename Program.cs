using System;
using System.Linq;
using TaskManagementApp.Data;
using TaskManagementApp.Models;

namespace TaskManagementApp
{
    class Program
    {
        static void Main()
        {
            using (var context = new ApplicationContext())
            {
                context.Database.EnsureCreated();

                Console.WriteLine("1. Add Task");
                Console.WriteLine("2. View Tasks");
                Console.WriteLine("3. Mark Task as Completed");
                var choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddTask(context);
                        break;
                    case "2":
                        ViewTasks(context);
                        break;
                    case "3":
                        MarkTaskAsCompleted(context);
                        break;
                    default:
                        Console.WriteLine("Invalid choice.");
                        break;
                }
            }
        }

        private static void AddTask(ApplicationContext context)
        {
            Console.Write("Enter task title: ");
            var title = Console.ReadLine();

            Console.Write("Enter task description: ");
            var description = Console.ReadLine();

            Console.Write("Enter due date (optional, format: yyyy-MM-dd): ");
            var dueDateInput = Console.ReadLine();
            DateTime? dueDate = string.IsNullOrEmpty(dueDateInput) ? (DateTime?)null : DateTime.Parse(dueDateInput);

            // Проверка даты дедлайна
            if (dueDate.HasValue && dueDate.Value < DateTime.Now)
            {
                Console.WriteLine("Due date cannot be earlier than the current date.");
                return;
            }

            var task = new TaskEntity
            {
                Title = title,
                Description = description,
                CreatedDate = DateTime.Now,
                DueDate = dueDate,
                IsCompleted = false,
                Status = TaskStatusEnum.Pending
            };

            context.Tasks.Add(task);
            context.SaveChanges();

            Console.WriteLine("Task added successfully.");
        }

        private static void ViewTasks(ApplicationContext context)
        {
            var tasks = context.Tasks.ToList();
            foreach (var task in tasks)
            {
                Console.WriteLine($"ID: {task.Id}, Title: {task.Title}, Completed: {task.IsCompleted}, Status: {task.Status}");
            }
        }

        private static void MarkTaskAsCompleted(ApplicationContext context)
        {
            Console.Write("Enter task ID to mark as completed: ");
            if (int.TryParse(Console.ReadLine(), out int taskId))
            {
                var task = context.Tasks.Find(taskId);
                if (task != null)
                {
                    task.IsCompleted = true;
                    task.Status = TaskStatusEnum.Completed;
                    context.Tasks.Update(task);
                    context.SaveChanges();
                    Console.WriteLine("Task marked as completed.");
                }
                else
                {
                    Console.WriteLine("Task not found.");
                }
            }
            else
            {
                Console.WriteLine("Invalid task ID.");
            }
        }
    }
}
