using System;

namespace BetterDo.Models
{
    /// <summary>
    /// A TodoItem represents a specific task a person wants to accomplish.
    /// 
    /// A TodoItem has a unique identifier (ID), a Title, and a completed flag.
    /// 
    /// </summary>
    public class TodoItem
    {
        public Guid ID { get; set; }
        public string Title { get; set; }
        public bool Completed { get; set; }
    }
}
