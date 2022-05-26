using System;
using System.Collections.Generic;
using System.Linq;

namespace AutoComplete
{
    public class Autocomplete : Trie
    {
        public List<string> GetMatches(string prefix)
        {
            List<string> possibles = new();
            if (FindPrefix(prefix.ToCharArray()))
            {
                TrieNode lastNode = GetLastNodeOfPrefix(prefix.ToCharArray());
                if (lastNode.endOfWord)
                {
                    possibles.Add(prefix);
                }
                foreach (char letter in lastNode.children.Keys)
                {
                    string possibility = prefix;
                    possibility += letter;
                    if (lastNode.children[letter].endOfWord)
                    {
                        possibles.Add(possibility);
                    }
                    NewLastNode(lastNode.children[letter], possibility, possibles);
                }
            }
            return possibles;
        }

        public bool FindPrefix(char[] chars)
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

        public TrieNode GetLastNodeOfPrefix(char[] chars)
        {
            TrieNode lastNode = new();
            TrieNode tempRoot = Root;
            for (int i = 0; i < chars.Count(); i++)
            {
                if (tempRoot.children.Keys.Contains(chars[i]))
                {
                    tempRoot = tempRoot.children[chars[i]];
                }
                if (i == chars.Count()-1)
                {
                    lastNode = tempRoot;
                }
            }
            return lastNode;
        }

        public List<string> NewLastNode(TrieNode lastNode, string partialWord, List<string> possibles)
        {
            foreach (char letter in lastNode.children.Keys)
            {
                string possibility = partialWord;
                possibility += letter;
                if (lastNode.children[letter].endOfWord)
                {
                    possibles.Add(possibility);
                }
                NewLastNode(lastNode.children[letter], possibility, possibles);
            }
            return possibles;
        }
    }   
}
