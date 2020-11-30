using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace TestManager.Models
{
    /// <summary>
    /// Name as C4iTask;
    /// Naming to  "Task" may have potential naming conflicts with System.Threading.Tasks.Task;
    /// </summary>
    public class C4iTask
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public bool IsCompleted { get; set; } = false;

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DueDate { get; set; } = DateTime.Now.Date;

        internal static C4iTask FromCollection(FormCollection collection)
        {
            string name = collection["Name"];
            DateTime DueDate =  string.IsNullOrWhiteSpace(collection["DueDate"])  ? DateTime.Now : Convert.ToDateTime(collection["DueDate"]).Date;
            bool isCompleted = collection["IsCompleted"] != null && Convert.ToBoolean(collection["IsCompleted"].Split(',')[0]);

            return new C4iTask()
            {
                Name = name,
                DueDate = DueDate,
                IsCompleted = isCompleted
            };
        }
    }
}