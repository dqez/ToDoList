using TodoList.Core;
using TodoList.UseCases;

namespace TodoList.Infrastructure
{
    public class InMemoryTodoListRepository : ITodoListRepository
    {
        private readonly List<TodoItem> _items;

        public InMemoryTodoListRepository()
        {
            _items = [];
        }

        public void AddTodoItem(TodoItem item)
        {
            _items.Add(item);
        }

        public IEnumerable<TodoItem> GetAllTodoItems()
        {
            return _items;
        }

        public TodoItem? GetTodoItemById(int id)
        {
            return _items.FirstOrDefault(i => i.Id == id);
        }

        public void RemoveTodoItem(int id)
        {
            var item = GetTodoItemById(id);
            if (item != null)
            {
                _items.Remove(item);
            }
        }

        public void UpdateTodoItem(TodoItem item)
        {
            var existingItem = GetTodoItemById(item.Id);
            if (existingItem != null)
            {
                existingItem.Title = item.Title;
                existingItem.Description = item.Description;
                existingItem.IsCompleted = item.IsCompleted;
                existingItem.UpdatedDate = DateTime.Now;
            }
        }


    }
}


