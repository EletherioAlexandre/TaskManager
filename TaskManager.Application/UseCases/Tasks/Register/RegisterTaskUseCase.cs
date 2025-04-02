using TaskManager.Communication.Requests;
using TaskManager.Communication.Responses;

namespace TaskManager.Application.UseCases.Tasks.Register
{
    public class RegisterTaskUseCase
    {
        public ResponseRegisterTask Execute(RequestTasksJson request)
        {
            return new ResponseRegisterTask
            {
                Id = 1,
                Name = request.Name
            };
        }
    }
}
