using TodoList.Core;

namespace TodoList.UseCases
{
    public class TodoListManager
    {
        private readonly ITodoListRepository _repository;

        public TodoListManager(ITodoListRepository repository)
        {
            _repository = repository;
        }

        public void AddTodoItem(TodoItem item)
        {
            _repository.AddTodoItem(item);
        }

        public void UpdateTodoItem(TodoItem item)
        {
            _repository.UpdateTodoItem(item);
        }

        public void RemoveTodoItem(int id)
        {
            _repository.RemoveTodoItem(id);
        }

        public IEnumerable<TodoItem> GetAllTodoItems()
        {
            return _repository.GetAllTodoItems();
        }
        
        public TodoItem? GetTodoItemById(int id)
        {
            return _repository.GetTodoItemById(id);
        }

    }
}
