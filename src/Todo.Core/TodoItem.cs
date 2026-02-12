// <copyright file="TodoItem.cs" company="NATK">
// Copyright (c) NATK. All rights reserved.
// </copyright>

namespace Todo.Core;

/// <summary>
/// Represents a single todo entry.
/// </summary>
public sealed class TodoItem
{
    /// <summary>
    /// Gets unique identifier of the item.
    /// </summary>
    public Guid Id { get; } = Guid.NewGuid();

    /// <summary>
    /// Gets the item title.
    /// </summary>
    public string Title { get; private set; }

    /// <summary>
    /// Gets a value indicating whether the item is completed.
    /// </summary>
    public bool IsDone { get; private set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="TodoItem"/> class.
    /// </summary>
    /// <param name="title">Item title.</param>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="title"/> is null.</exception>
    /// <exception cref="ArgumentException">Thrown when <paramref name="title"/> is empty/whitespace.</exception>
    public TodoItem(string title)
    {
        ArgumentNullException.ThrowIfNull(title);

        var trimmed = title.Trim();

        if (string.IsNullOrWhiteSpace(trimmed))
        {
            throw new ArgumentException("Title is required", nameof(title));
        }

        Title = trimmed;
    }

    /// <summary>
    /// Marks item as completed.
    /// </summary>
    public void MarkDone() => IsDone = true;

    /// <summary>
    /// Marks item as not completed.
    /// </summary>
    public void MarkUndone() => IsDone = false;

    /// <summary>
    /// Renames the item.
    /// </summary>
    /// <param name="newTitle">New title.</param>
    /// <exception cref="ArgumentException">Thrown when <paramref name="newTitle"/> is empty/whitespace.</exception>
    public void Rename(string newTitle)
    {
        if (string.IsNullOrWhiteSpace(newTitle))
        {
            throw new ArgumentException("Title is required", nameof(newTitle));
        }

        Title = newTitle.Trim();
    }
}
