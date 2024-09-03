using System;
using System.ComponentModel.DataAnnotations;

namespace TaskManagementApp.Models
{
    public class TaskEntity
    {
        public int Id { get; set; }

        [Required]
        public string? Title { get; set; }

        public string? Description { get; set; }

        [Required]
        public DateTime CreatedDate { get; set; }

        public DateTime? DueDate { get; set; }

        public bool IsCompleted { get; set; }

        public TaskStatusEnum Status { get; set; } 
    }

    public enum TaskStatusEnum
    {
        Pending,
        InProgress,
        Completed
    }
}
