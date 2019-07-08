using System;
using System.Collections.Generic;
using System.Text;

namespace Monaco.Algorithms.Structures
{
    public interface IPathTrieNode<T> 
    {
        IPathTrieNode<T> Parent { get; set; }
        T Value { get; set; }
        string Name { get; }
        string PathKey { get; }

        void AddChild(string name, T value);
        void RemoveChild(string name);
        bool ContainsChild(string name);
        bool TryGetChild(string name, out IPathTrieNode<T> node);
        void AttachChild(IPathTrieNode<T> node);
        IPathTrieNode<T> DetachChild(string name);

        IEnumerable<IPathTrieNode<T>> Children();
        IEnumerable<IPathTrieNode<T>> Ancestors();
        IEnumerable<IPathTrieNode<T>> SelfAndDescendantsDepthFirst();
        IEnumerable<IPathTrieNode<T>> SelfAndDescendantsBreadthFirst();
        IEnumerable<IPathTrieNode<T>> DescendantsDepthFirst();
        IEnumerable<IPathTrieNode<T>> DescendantsBreadthFirst();
    }
}
