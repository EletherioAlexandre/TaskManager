using TaskManager.Communication.Enums;
using TaskStatus = TaskManager.Communication.Enums.TaskStatus;

namespace TaskManager.Communication.Requests
{
    public class RequestTasksJson
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public TaskPriority Priority { get; set; }
        public DateOnly Deadline { get; set; }
        public TaskStatus Status { get; set; }
    }
}
