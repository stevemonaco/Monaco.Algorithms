﻿using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections;

namespace Monaco.Algorithms.Structures
{
    public class PathTrieNode<T> : IPathTrieNode<T>, IEnumerable<IPathTrieNode<T>>
    {
        private IDictionary<string, IPathTrieNode<T>> children;

        public IPathTrieNode<T> Parent { get; set; }
        public T Value { get; set; }
        public string Name { get; private set; }

        public PathTrieNode(string name, T value)
        {
            Value = value;
            Name = name;
        }

        /// <summary>
        /// Returns the path key
        /// </summary>
        /// <returns></returns>
        public string PathKey => "/" + string.Join("/", SelfAndAncestors().Select(x => x.Name).Reverse().ToList());

        public void AddChild(string name, T value)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException($"{nameof(AddChild)}: parameter '{nameof(name)}' was null or empty");

            if (children is null)
                children = new Dictionary<string, IPathTrieNode<T>>();

            if (children.ContainsKey(name))
                throw new ArgumentException($"{nameof(AddChild)}: child element with {nameof(name)} '{name}' already exists");

            var node = new PathTrieNode<T>(name, value);
            node.Parent = this;
            children.Add(name, node);
        }

        public void AttachChild(IPathTrieNode<T> node)
        {
            if(node is null)
                throw new ArgumentException($"{nameof(AttachChild)}: parameter '{nameof(node)}' was null or empty");

            if (children is null)
                children = new Dictionary<string, IPathTrieNode<T>>();

            if (children.ContainsKey(node.Name))
                throw new ArgumentException($"{nameof(AttachChild)}: child element with {nameof(node.Name)} '{node.Name}' already exists");

            node.Parent = this;
            children.Add(node.Name, node);
        }

        public IPathTrieNode<T> DetachChild(string name)
        {
            if (name is null)
                throw new ArgumentException($"{nameof(DetachChild)}: parameter '{nameof(name)}' was null or empty");

            if (children is null)
                throw new ArgumentException($"{nameof(DetachChild)}: child element with {nameof(name)} '{name}' does not exist");

            if (children.TryGetValue(name, out var node))
            {
                node.Parent = null;
                children.Remove(name);
                return node;
            }
            else
                throw new KeyNotFoundException($"{nameof(DetachChild)}: child element with {nameof(name)} '{name}' does not exist");
        }

        public void RemoveChild(string name)
        {
            if(name is null)
                throw new ArgumentException($"{nameof(RemoveChild)}: parameter '{nameof(name)}' was null or empty");

            if (children is null)
                throw new ArgumentException($"{nameof(RemoveChild)}: child element with {nameof(name)} '{name}' does not exist");

            if (children.ContainsKey(name))
                children.Remove(name);
            else
                throw new KeyNotFoundException($"{nameof(RemoveChild)}: child element with {nameof(name)} '{name}' does not exist");
        }

        public bool ContainsChild(string name)
        {
            if (name is null)
                throw new ArgumentException($"{nameof(ContainsChild)}: parameter '{nameof(name)}' was null or empty");

            if (children is null)
                return false;

            return children.ContainsKey(name);
        }

        public bool TryGetChild(string name, out IPathTrieNode<T> node)
        {
            if(name is null)
                throw new ArgumentException($"{nameof(TryGetChild)}: parameter '{nameof(name)}' was null or empty");

            node = default;

            if (children is null)
                return false;

            if (children.TryGetValue(name, out node))
                return true;

            return false;
        }

        /// <summary>
        /// Ancestors of the specified node.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<IPathTrieNode<T>> Ancestors()
        {
            if (Parent is null)
                yield break;

            var parentVisitor = Parent;

            while (parentVisitor.Parent != null)
            {
                yield return parentVisitor;
                parentVisitor = parentVisitor.Parent;
            }
        }

        public IEnumerable<IPathTrieNode<T>> SelfAndAncestors()
        {
            if (Parent is null)
                yield break;

            yield return this;

            var parentVisitor = Parent;

            while (parentVisitor.Parent != null)
            {
                yield return parentVisitor;
                parentVisitor = parentVisitor.Parent;
            }
        }

        public IEnumerator<IPathTrieNode<T>> GetEnumerator()
        {
            if (children is null)
                yield break;

            foreach (var child in children)
            {
                yield return child.Value;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public IEnumerable<IPathTrieNode<T>> SelfAndDescendantsDepthFirst()
        {
            var nodeStack = new Stack<IPathTrieNode<T>>();

            nodeStack.Push(this);

            while (nodeStack.Count > 0)
            {
                var node = nodeStack.Pop();
                yield return node;
                foreach (var child in node.Children())
                    nodeStack.Push(child);
            }
        }

        public IEnumerable<IPathTrieNode<T>> SelfAndDescendantsBreadthFirst()
        {
            var nodeQueue = new Queue<IPathTrieNode<T>>();

            nodeQueue.Enqueue(this);

            while (nodeQueue.Count > 0)
            {
                var node = nodeQueue.Dequeue();
                yield return node;
                foreach (var child in node.Children())
                    nodeQueue.Enqueue(child);
            }
        }

        public IEnumerable<IPathTrieNode<T>> DescendantsDepthFirst()
        {
            if (children is null)
                yield break;

            var nodeStack = new Stack<IPathTrieNode<T>>(children.Values);

            while (nodeStack.Count > 0)
            {
                var node = nodeStack.Pop();
                yield return node;
                foreach (var child in node.Children())
                    nodeStack.Push(child);
            }
        }

        public IEnumerable<IPathTrieNode<T>> DescendantsBreadthFirst()
        {
            if (children is null)
                yield break;

            var nodeQueue = new Queue<IPathTrieNode<T>>();

            nodeQueue.Enqueue(this);

            while (nodeQueue.Count > 0)
            {
                var node = nodeQueue.Dequeue();
                yield return node;
                foreach (var child in node.Children())
                    nodeQueue.Enqueue(child);
            }
        }

        public IEnumerable<IPathTrieNode<T>> Children()
        {
            if(children is null)
                yield break;

            foreach (var child in children.Values)
                yield return child;
        }

    }
}
