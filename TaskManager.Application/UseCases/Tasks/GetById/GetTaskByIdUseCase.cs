using TaskManager.Communication.Responses;

namespace TaskManager.Application.UseCases.Tasks.GetById
{
    public class GetTaskByIdUseCase
    {
        public ResponseTaskJson Execute(int id)
        {
            return new ResponseTaskJson
            {
                Id = id,
                Name = "Task name",
                Description = "Task description",
                Priority = 0,
                Deadline = new DateOnly(year: 2025, month: 5, day: 1),
                Status = (Communication.Enums.TaskStatus)1
            };
        }
    }
}
