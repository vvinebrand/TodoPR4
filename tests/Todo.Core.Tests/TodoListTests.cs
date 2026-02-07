// <copyright file="TodoListTests.cs" company="NATK">
// Copyright (c) NATK. All rights reserved.
// </copyright>

using Todo.Core;
using Xunit;

namespace Todo.Core.Tests;

public sealed class TodoListTests
{
    [Fact]
    public void AddIncrementsCount()
    {
        var list = new TodoList();

        _ = list.Add("task");

        Assert.Equal(1, list.Count);
    }

    [Fact]
    public void RemoveByIdWorks()
    {
        var list = new TodoList();
        var item = list.Add("a");

        Assert.True(list.Remove(item.Id));
        Assert.Equal(0, list.Count);
    }

    [Fact]
    public void FindIsCaseInsensitive()
    {
        var list = new TodoList();
        _ = list.Add("Buy Milk");
        _ = list.Add("Walk dog");

        var result = list.Find("milk").ToList();

        Assert.Single(result);
        Assert.Equal("Buy Milk", result[0].Title);
    }
}
