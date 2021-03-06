using System;
using System.Collections.Generic;
using System.Linq;

namespace AutoComplete
{
    public class Trie
    {
        public TrieNode Root;

        public Trie()
        {
            Root = new TrieNode();
        }

        public void Insert(string word)
        {
            char[] chars = word.ToCharArray();
            TrieNode tempRoot = Root;
            int total = chars.Count() - 1;
            for (int i = 0; i < chars.Count(); i++)
            {
                TrieNode newTrie;
                if (tempRoot.children.Keys.Contains(chars[i]))
                {
                    tempRoot = tempRoot.children[chars[i]];
                }
                else
                {
                    newTrie = new TrieNode();

                    if (total == i)
                    {
                        newTrie.endOfWord = true;
                    }

                    tempRoot.children.Add(chars[i], newTrie);
                    tempRoot = newTrie;
                }
            }
        }

        public bool Remove(string word)
        {
            char[] chars = word.ToCharArray();
            TrieNode tempRoot = Root;
            int total = chars.Count() - 1;
            if (FindWord(chars))
            {
                for (int i = 0; i < chars.Count(); i++)
                {
                    if (tempRoot.children.Keys.Count() == 1)
                    {
                        tempRoot.children = new Dictionary<char, TrieNode>();
                        return true;
                    }
                }
            }
            return false;
        }

        private bool FindWord(char[] chars)
        {
            TrieNode tempRoot = Root;
            for (int i = 0; i < chars.Count(); i++)
            {
                if (tempRoot.children.Keys.Contains(chars[i]))
                {
                    tempRoot = tempRoot.children[chars[i]];
                }
                else
                {
                    return false;
                }
            }
            return true;
        }
    }
}
