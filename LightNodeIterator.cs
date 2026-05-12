using System.Collections.Generic;

namespace Lab3.Task5.Composite;

public static class LightNodeIterator
{
    public static IEnumerable<LightNode> DepthFirst(LightNode root)
    {
        if (root is LightElementNode el)
        {
            foreach (var n in el.TraverseDepthFirst())
                yield return n;
        }
        else
        {
            yield return root;
        }
    }

    public static IEnumerable<LightNode> BreadthFirst(LightNode root)
    {
        if (root is LightElementNode el)
        {
            foreach (var n in el.TraverseBreadthFirst())
                yield return n;
        }
        else
        {
            yield return root;
        }
    }
}