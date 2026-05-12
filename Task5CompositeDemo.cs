namespace Lab3.Task5.Composite;

public static class Task5CompositeDemo
{
    public static void Run()
    {
        Console.WriteLine("=== Task 5. Composite ===");

        var table = new LightElementNode("table", LightElementDisplayType.Block, LightElementClosingType.Pair, "table", "table-striped");

        var headerRow = new LightElementNode("tr", LightElementDisplayType.Block, LightElementClosingType.Pair);
        headerRow.AddChild(CreateCell("Name", "th"));
        headerRow.AddChild(CreateCell("Role", "th"));
        headerRow.AddChild(CreateCell("Level", "th"));
        table.AddChild(headerRow);

        table.AddChild(CreateDataRow("Arthas", "Warrior", "42"));
        table.AddChild(CreateDataRow("Jaina", "Mage", "38"));

        Console.WriteLine($"Children count: {table.ChildrenCount}");
        Console.WriteLine(table.OuterHtml());
        Console.WriteLine(table.InnerHtml());

        // Demonstrate Iterator (depth-first)
        Console.WriteLine("--- Depth-first traversal ---");
        foreach (var node in LightNodeIterator.DepthFirst(table))
        {
            if (node is LightElementNode el)
                Console.WriteLine($"Element: {el.TagName}");
            else if (node is LightTextNode txt)
                Console.WriteLine($"Text: {txt.Text}");
        }

        // Demonstrate Visitor
        var stats = new HtmlStatisticsVisitor();
        table.Accept(stats);
        Console.WriteLine($"Elements: {stats.ElementCount}, Text nodes: {stats.TextCount}");

        // Demonstrate Command (add/undo)
        var extraRow = CreateDataRow("Thrall", "Shaman", "40");
        var cmd = new AddChildCommand(table, extraRow);
        cmd.Execute();
        Console.WriteLine("After AddChildCommand: Children count = " + table.ChildrenCount);
        cmd.Undo();
        Console.WriteLine("After Undo: Children count = " + table.ChildrenCount);

        // Demonstrate State (hide header)
        Console.WriteLine("--- Hiding header row ---");
        headerRow.SetState(new HiddenState());
        Console.WriteLine(table.OuterHtml());
    }

    private static LightElementNode CreateCell(string text, string tagName)
    {
        var cell = new LightElementNode(tagName, LightElementDisplayType.Inline, LightElementClosingType.Pair);
        cell.AddChild(new LightTextNode(text));
        return cell;
    }

    private static LightElementNode CreateDataRow(string name, string role, string level)
    {
        var row = new LightElementNode("tr", LightElementDisplayType.Block, LightElementClosingType.Pair);
        row.AddChild(CreateCell(name, "td"));
        row.AddChild(CreateCell(role, "td"));
        row.AddChild(CreateCell(level, "td"));
        return row;
    }
}