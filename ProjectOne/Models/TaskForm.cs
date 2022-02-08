using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectOne.Models
{
    public class TaskForm
    {
        [Key]
        [Required]
        public int TaskId { get; set; }

        [Required(ErrorMessage = "Please enter a task.")]
        public string TaskName { get; set; }

        public string DueDate { get; set; }

        [Required]
        [Range(1, 4)]
        public int Quadrant { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }

        public bool Completed { get; set; }
    }
}
