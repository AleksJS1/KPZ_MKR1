using System.Collections.Generic;
using System.Linq;

namespace Lab3.Task5.Composite;

public enum LightElementDisplayType
{
    Block,
    Inline
}

public enum LightElementClosingType
{
    Single,
    Pair
}

internal sealed class LightElementTemplate
{
    public LightElementTemplate(string tagName, LightElementDisplayType displayType, LightElementClosingType closingType)
    {
        TagName = tagName;
        DisplayType = displayType;
        ClosingType = closingType;
    }

    public string TagName { get; }

    public LightElementDisplayType DisplayType { get; }

    public LightElementClosingType ClosingType { get; }
}

internal static class LightElementTemplateCache
{
    private static readonly Dictionary<(string, LightElementDisplayType, LightElementClosingType), LightElementTemplate> Cache = new();

    public static LightElementTemplate Get(string tagName, LightElementDisplayType displayType, LightElementClosingType closingType)
    {
        var key = (tagName, displayType, closingType);
        if (!Cache.TryGetValue(key, out var template))
        {
            template = new LightElementTemplate(tagName, displayType, closingType);
            Cache[key] = template;
        }

        return template;
    }
}

public sealed class LightElementNode : LightNode
{
    private readonly LightElementTemplate template;
    private readonly List<LightNode> children = new();
    private readonly List<string> cssClassList;

    public LightElementNode(string tagName, LightElementDisplayType displayType, LightElementClosingType closingType, params string[] cssClasses)
    {
        template = LightElementTemplateCache.Get(tagName, displayType, closingType);
        cssClassList = new List<string>(cssClasses);
        CssClasses = cssClassList;
        OnClassListApplied();
    }

    public string TagName => template.TagName;

    public LightElementDisplayType DisplayType => template.DisplayType;

    public LightElementClosingType ClosingType => template.ClosingType;

    public IReadOnlyList<string> CssClasses { get; }

    public ILightElementState State { get; private set; }

    public int ChildrenCount => children.Count;

    public IReadOnlyList<LightNode> Children => children;

    public void AddChild(LightNode child)
    {
        children.Add(child);
        child.OnInserted(this);
        OnInserted(this);
    }

    public bool RemoveChild(LightNode child)
    {
        var removed = children.Remove(child);
        if (removed)
        {
            child.OnRemoved(this);
            OnRemoved(this);
        }

        return removed;
    }

    public override string OuterHtml()
    {
        string RenderCore()
        {
            if (ClosingType == LightElementClosingType.Single)
            {
                return $"<{TagName}{CssClassAttribute()} />";
            }

            return $"<{TagName}{CssClassAttribute()}>" + InnerHtml() + $"</{TagName}>";
        }

        return State.Render(this, RenderCore);
    }

    public override string InnerHtml()
    {
        var html = string.Join(string.Empty, children.Select(child => child.OuterHtml()));
        OnTextRendered();
        return html;
    }

    private string CssClassAttribute()
    {
        return CssClasses.Count == 0 ? string.Empty : $" class=\"{string.Join(' ', CssClasses)}\"";
    }

    public void SetState(ILightElementState newState)
    {
        State = newState ?? new VisibleState();
    }
}