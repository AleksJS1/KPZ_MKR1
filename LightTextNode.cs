namespace Lab3.Task5.Composite;

public sealed class LightTextNode : LightNode
{
    public LightTextNode(string text)
    {
        Text = text;
    }

    public string Text { get; }

    public override string OuterHtml()
    {
        return Text;
    }

    public override string InnerHtml()
    {
        return Text;
    }

    public override void Accept(ILightNodeVisitor visitor)
    {
        visitor.VisitText(this);
    }
}