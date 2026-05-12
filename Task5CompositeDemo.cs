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