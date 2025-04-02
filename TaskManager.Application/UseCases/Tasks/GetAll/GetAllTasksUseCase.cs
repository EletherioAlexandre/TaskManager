using TaskManager.Communication.Responses;

namespace TaskManager.Application.UseCases.Tasks.GetAll
{
    public class GetAllTasksUseCase
    {
        public ResponseAllTasksJson Execute()
        {
            return new ResponseAllTasksJson
            {
                Tasks = new List<ResponseShortsTasksJson>
                {
                    new ResponseShortsTasksJson
                    {
                        Id = 1,
                        Name = "Task name here",
                        Description = "Task description here",
                    }
                }
            };
        }
    }
}
