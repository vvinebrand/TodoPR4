// <copyright file="TodoList.cs" company="NATK">
// Copyright (c) NATK. All rights reserved.
// </copyright>

using System.Collections.ObjectModel;

namespace Todo.Core;

/// <summary>
/// Simple in-memory todo list.
/// </summary>
public sealed class TodoList
{
    private readonly List<TodoItem> items = new();

    /// <summary>
    /// Gets a read-only view of items.
    /// </summary>
    public ReadOnlyCollection<TodoItem> Items => items.AsReadOnly();

    /// <summary>
    /// Gets the number of items in the list.
    /// </summary>
    public int Count => items.Count;

    /// <summary>
    /// Adds a new item to the list.
    /// </summary>
    /// <param name="title">Item title.</param>
    /// <returns>The created item.</returns>
    public TodoItem Add(string title)
    {
        var item = new TodoItem(title);
        items.Add(item);
        return item;
    }

    /// <summary>
    /// Removes an item by its identifier.
    /// </summary>
    /// <param name="id">Item id.</param>
    /// <returns><see langword="true"/> if an item was removed; otherwise <see langword="false"/>.</returns>
    public bool Remove(Guid id) => items.RemoveAll(i => i.Id == id) > 0;

    /// <summary>
    /// Finds items by substring in title (case-insensitive).
    /// </summary>
    /// <param name="substring">Substring to search. If null, treated as empty string.</param>
    /// <returns>Matching items.</returns>
    public IEnumerable<TodoItem> Find(string? substring)
    {
        var needle = substring ?? string.Empty;

        return items.Where(i =>
            i.Title.Contains(needle, StringComparison.OrdinalIgnoreCase));
    }
}
