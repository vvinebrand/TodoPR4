// <copyright file="Program.cs" company="NATK">
// Copyright (c) NATK. All rights reserved.
// </copyright>

using Todo.Core;

static void PrintHelp()
{
    Console.WriteLine("Simple Todo CLI. Commands: add <task>, remove <index>, list, find <text>, exit");
}

var list = new TodoList();
PrintHelp();

while (true)
{
    Console.Write("> ");
    var input = Console.ReadLine();

    if (string.IsNullOrWhiteSpace(input))
    {
        continue;
    }

    var parts = input.Split(' ', 2, StringSplitOptions.RemoveEmptyEntries);
    var cmd = parts[0].ToLowerInvariant();
    var arg = parts.Length > 1 ? parts[1] : string.Empty;

    switch (cmd)
    {
        case "add":
            if (string.IsNullOrWhiteSpace(arg))
            {
                Console.WriteLine("Usage: add <task>");
                break;
            }

            list.Add(arg);
            Console.WriteLine("Added.");
            break;

        case "remove":
            if (!int.TryParse(arg, out var index))
            {
                Console.WriteLine("Usage: remove <index>");
                break;
            }

            if (index < 0 || index >= list.Items.Count)
            {
                Console.WriteLine("Index out of range.");
                break;
            }

            var id = list.Items[index].Id;
            _ = list.Remove(id);
            Console.WriteLine("Removed.");
            break;

        case "list":
            if (list.Items.Count == 0)
            {
                Console.WriteLine("(empty)");
                break;
            }

            for (var i = 0; i < list.Items.Count; i++)
            {
                var item = list.Items[i];
                Console.WriteLine($"{i}: [{(item.IsDone ? 'x' : ' ')}] {item.Title} ({item.Id})");
            }

            break;

        case "find":
            foreach (var item in list.Find(arg))
            {
                Console.WriteLine($"- {item.Title} ({item.Id})");
            }

            break;

        case "exit":
            return;

        case "help":
            PrintHelp();
            break;

        default:
            Console.WriteLine("Unknown command. Type 'help'.");
            break;
    }
}
