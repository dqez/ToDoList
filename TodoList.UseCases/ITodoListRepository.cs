using TodoList.Core;

namespace TodoList.UseCases
{
    public interface ITodoListRepository
    {
        void AddTodoItem(TodoItem item);
        void UpdateTodoItem(TodoItem item);
        void RemoveTodoItem(int id);

        IEnumerable<TodoItem> GetAllTodoItems();
        TodoItem? GetTodoItemById(int id);

    }
}
