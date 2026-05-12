namespace Lab3.Task5.Composite;

public sealed class HtmlStatisticsVisitor : ILightNodeVisitor
{
    public int ElementCount { get; private set; }

    public int TextCount { get; private set; }

    public void VisitElement(LightElementNode element)
    {
        ElementCount++;
    }

    public void VisitText(LightTextNode text)
    {
        TextCount++;
    }
}