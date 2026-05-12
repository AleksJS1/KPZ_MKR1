namespace Lab3.Task5.Composite;

public abstract class LightNode
{
    public LightNode()
    {
        OnCreated();
    }

    public abstract string OuterHtml();

    public abstract string InnerHtml();

    // Template Method hooks (no-op defaults)
    protected virtual void OnCreated() { }

    protected virtual void OnInserted(LightElementNode parent) { }

    protected virtual void OnRemoved(LightElementNode parent) { }

    protected virtual void OnStylesApplied() { }

    protected virtual void OnClassListApplied() { }

    protected virtual void OnTextRendered() { }

    // Visitor acceptance
    public abstract void Accept(ILightNodeVisitor visitor);
}