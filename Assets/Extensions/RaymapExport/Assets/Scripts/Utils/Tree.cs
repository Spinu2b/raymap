﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Extensions.RayExportOld2.Assets.Scripts.Utils
{
    public class ParentChildPair<T, KeyType>
    {
        public T Parent;
        public T Child;

        public KeyType ParentId;
        public KeyType ChildId;

        public ParentChildPair(T Parent, T Child, KeyType ParentId, KeyType ChildId)
        {
            this.Parent = Parent;
            this.Child = Child;
            this.ParentId = ParentId;
            this.ChildId = ChildId;
        }
    }

    public class TreeBuildingNodeInfo<T, KeyType>
    {
        public KeyType ParentId;
        public KeyType NodeId;
        public T Node;

        public TreeBuildingNodeInfo(KeyType ParentId, KeyType NodeId, T Node)
        {
            this.ParentId = ParentId;
            this.NodeId = NodeId;
            this.Node = Node;
        }
    }

    public class TreeBuildingNodesSet<T, KeyType>
    {
        List<TreeBuildingNodeInfo<T, KeyType>> BuildingNodes;

        public TreeBuildingNodesSet(List<TreeBuildingNodeInfo<T, KeyType>> BuildingNodes)
        {
            this.BuildingNodes = BuildingNodes;
        }

        public Queue<TreeBuildingNodeInfo<T, KeyType>> ToBuildingTreeNodesQueue()
        {
            return new Queue<TreeBuildingNodeInfo<T, KeyType>>(BuildingNodes);
        }

        public TreeBuildingNodesSet<T, KeyType> Difference(TreeBuildingNodesSet<T, KeyType> Other)
        {
            return new TreeBuildingNodesSet<T, KeyType>(
                BuildingNodes.Where(x => !Other.BuildingNodes.Any(y => y.NodeId.Equals(x.NodeId))).ToList()
                );
        }
    }

    public class TreeNodeContainer<T, KeyType>
    {
        public T Node;
        public KeyType Id;

        public List<TreeNodeContainer<T, KeyType>> Children;

        public TreeNodeContainer(KeyType Id, T Node)
        {
            this.Node = Node;
            this.Id = Id;
            this.Children = new List<TreeNodeContainer<T, KeyType>>();
        }

        public void TraverseAndCollectAll(List<TreeNodeIterator<T, KeyType>> Nodes)
        {
            Nodes.Add(new TreeNodeIterator<T, KeyType>(Id, Node));

            foreach (var Child in Children)
            {
                Child.TraverseAndCollectAll(Nodes);
            }
        }

        public void TraverseChildParentPairsAndCollectAll(List<ParentChildPair<T, KeyType>> pairs)
        {
            foreach (var Child in Children)
            {
                pairs.Add(new ParentChildPair<T, KeyType>(this.Node, Child.Node, this.Id, Child.Id));
            }
            foreach (var Child in Children)
            {
                Child.TraverseChildParentPairsAndCollectAll(pairs);
            }
        }

        public bool TraverseAndAddNode(KeyType ParentIdentifier, KeyType NodeIdentifier, T Node)
        {
            if (Id.Equals(ParentIdentifier))
            {
                Children.Add(new TreeNodeContainer<T, KeyType>(NodeIdentifier, Node));
                return true;
            }
            else
            {
                foreach (var Child in Children)
                {
                    if (Child.TraverseAndAddNode(ParentIdentifier, NodeIdentifier, Node))
                    {
                        return true;
                    }
                }
                return false;
            }
        }
    }

    public class TreeNodeIterator<T, KeyType>
    {
        public KeyType Id;
        public T Node;

        public TreeNodeIterator(KeyType Id, T Node)
        {
            this.Id = Id;
            this.Node = Node;
        }
    }

    public class Tree<T, KeyType>
    {
        public TreeNodeContainer<T, KeyType> Root;

        public T GetRoot()
        {
            return Root.Node;
        }

        public void AddNode(
            KeyType parentIdentifier,
            KeyType nodeIdentifier,
            T node)
        {
            if (parentIdentifier == null)
            {
                if (Root == null)
                {
                    Root = new TreeNodeContainer<T, KeyType>(nodeIdentifier, node);
                }
                else
                {
                    throw new InvalidOperationException("The tree already contains root element!");
                }
            }
            else
            {
                if (Root.TraverseAndAddNode(parentIdentifier, nodeIdentifier, node))
                {
                    return;
                }
                else
                {
                    throw new InvalidOperationException("Did not find parent node of that id! " + nodeIdentifier);
                }
            }
        }

        public IEnumerable<TreeNodeIterator<T, KeyType>> IterateNodes()
        {
            List<TreeNodeIterator<T, KeyType>> nodes = new List<TreeNodeIterator<T, KeyType>>();
            if (Root != null)
            {
                Root.TraverseAndCollectAll(nodes);
            }
            foreach (var node in nodes)
            {
                yield return node;
            }
        }

        public IEnumerable<ParentChildPair<T, KeyType>> IterateParentChildPairs()
        {
            List<ParentChildPair<T, KeyType>> pairs = new List<ParentChildPair<T, KeyType>>();
            if (Root != null)
            {
                Root.TraverseChildParentPairsAndCollectAll(pairs);
            }
            foreach (var pair in pairs)
            {
                yield return pair;
            }
        }

        public IEnumerable<ParentChildPair<T, KeyType>> IterateParentChildPairsWithRoot()
        {
            List<ParentChildPair<T, KeyType>> pairs = new List<ParentChildPair<T, KeyType>>();
            if (Root != null)
            {
                pairs.Add(new ParentChildPair<T, KeyType>(default(T), Root.Node, default(KeyType), Root.Id));
                Root.TraverseChildParentPairsAndCollectAll(pairs);
            }
            foreach (var pair in pairs)
            {
                yield return pair;
            }
        }

        public bool Contains(KeyType Id)
        {
            foreach (var node in IterateNodes())
            {
                if (node.Id.Equals(Id))
                {
                    return true;
                }
            }
            return false;
        }

        public static Tree<T, KeyType> BuildTreeWithProperNodesPuttingOrder(
            Tree<T, KeyType> ExistingTree,
            Queue<TreeBuildingNodeInfo<T, KeyType>> TreeBuildingNodes)
        {
            Tree<T, KeyType> result;
            if (ExistingTree == null)
            {
                result = new Tree<T, KeyType>();
            }
            else
            {
                result = ExistingTree;
            }

            while (TreeBuildingNodes.Count != 0)
            {
                var Node = TreeBuildingNodes.Dequeue();
                if (result.Contains(Node.ParentId))
                {
                    result.AddNode(
                        Node.ParentId,
                        Node.NodeId,
                        Node.Node
                    );
                }
                else if (Node.ParentId == null)
                {
                    result.AddNode(
                        default(KeyType),
                        Node.NodeId,
                        Node.Node
                        );
                }
                else
                {
                    TreeBuildingNodes.Enqueue(Node);
                }
            }
            return result;
        }

        public TreeBuildingNodesSet<T, KeyType> GetTreeBuildingNodes()
        {
            var resultList = new List<TreeBuildingNodeInfo<T, KeyType>>();
            if (Root != null)
            {
                resultList.Add(new TreeBuildingNodeInfo<T, KeyType>(default(KeyType), Root.Id, GetRoot()));
            }
            foreach (var parentChildPair in IterateParentChildPairs())
            {
                resultList.Add(new TreeBuildingNodeInfo<T, KeyType>(parentChildPair.ParentId, parentChildPair.ChildId, parentChildPair.Child));
            }
            return new TreeBuildingNodesSet<T, KeyType>(resultList);
        }

        public TargetTreeType MapTree<TargetTreeType, TargetTreeNodeType>(Func<T, TargetTreeNodeType> mappingDelegate) where TargetTreeType : Tree<TargetTreeNodeType, KeyType>
        {
            var result = new Tree<TargetTreeNodeType, KeyType>();
            foreach (var childParentPair in IterateParentChildPairsWithRoot())
            {
                result.AddNode(parentIdentifier: childParentPair.ParentId, nodeIdentifier: childParentPair.ChildId,
                    node: mappingDelegate(childParentPair.Child));
            }
            return (TargetTreeType)result;
        }
    }
}
