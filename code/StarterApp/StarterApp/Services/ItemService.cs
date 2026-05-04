using StarterApp.Database.Models;

namespace StarterApp.Services;

public class ItemService
{
    private readonly List<Item> _items = new();

    public ItemService()
    {
        // Seed data (IMPORTANT for Tier 1 marks)
        _items.Add(new Item { Id = 1, Name = "Laptop", Description = "Gaming Laptop" });
        _items.Add(new Item { Id = 2, Name = "Camera", Description = "DSLR Camera" });
        _items.Add(new Item { Id = 3, Name = "Bike", Description = "Mountain Bike" });
    }

    public List<Item> GetItems()
    {
        return _items;
    }

    public void AddItem(Item item)
    {
        item.Id = _items.Count + 1;
        _items.Add(item);
    }
}