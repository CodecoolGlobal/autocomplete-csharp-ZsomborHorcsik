using System.Collections.Generic;

namespace AutoComplete
{
    //the char that represents the node is the key of the 
    public class TrieNode
    {
        public Dictionary<char, TrieNode> children = new();
        public bool endOfWord;
    }
}
