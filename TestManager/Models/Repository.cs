using System;
using System.Collections.Generic;
using System.Linq;
using TestManager.Models;

namespace TestManager
{
    /// <summary>
    /// persistence data to databse, or...
    /// </summary>
    public class Repository
    {
        private static readonly Lazy<Repository> lazy = new Lazy<Repository>(() => new Repository());

        public static Repository Instance { get { return lazy.Value; } }
        public List<C4iTask> C4iTasks { get; private set; }

        private Repository()
        {
            C4iTasks = new List<C4iTask>()
            {
                new C4iTask{ Id = 0, Name = "Sample C4iTask", DueDate = DateTime.Now, IsCompleted = true},
            };
        }
       
        internal void DeleteC4iTask(int id)
        {
            var C4iTask = C4iTasks.FirstOrDefault(t=>t.Id == id);

            if(C4iTask != null)
            {
                C4iTasks.Remove(C4iTask);
            }
        }

        internal void AddC4iTask(C4iTask C4iTask)
        {
            C4iTask.Id = C4iTasks.Count;
            C4iTasks.Add(C4iTask);
        }

        internal C4iTask GetC4iTask(int id)
        {
           return C4iTasks.FirstOrDefault(t => t.Id == id)?? new C4iTask();
        }

        internal void UpdateC4iTask(C4iTask C4iTask)
        {
            var ta = C4iTasks.FirstOrDefault(t => t.Id == C4iTask.Id);
            ta.Name = C4iTask.Name;
            ta.DueDate = C4iTask.DueDate;
            ta.IsCompleted = C4iTask.IsCompleted;

        }
    }
}