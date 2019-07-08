using System.Collections.Generic;

namespace Monaco.Algorithms.Structures
{
    public interface IPathTrie<T>
    {
        void Add(string path, T value);
        bool TryGetValue(string path, out T value);
        bool TryGetNode(string path, out IPathTrieNode<T> node);
        void RemoveNode(string path);
        void AttachNode(string path);
        int Count();

        IEnumerable<IPathTrieNode<T>> EnumerateDepthFirst();
        IEnumerable<IPathTrieNode<T>> EnumerateBreadthFirst();
    }
}
