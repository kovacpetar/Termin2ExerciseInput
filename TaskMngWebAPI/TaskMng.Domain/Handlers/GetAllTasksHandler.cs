using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskMng.Domain.Interfaces;
using TaskMng.Domain.Models;
using TaskMng.Domain.Queries;

namespace TaskMng.Domain.Handlers
{
    public class GetAllTasksHandler : IRequestHandler<GetAllTasksQuery, List<ToDoTask>>
    {
        private readonly ITaskRepository _taskRepository;

        public GetAllTasksHandler(
            ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        public async Task<List<ToDoTask>> Handle(GetAllTasksQuery request, CancellationToken cancellationToken)
        {
            return await _taskRepository.GetAllTasks();
        }
    }
}
