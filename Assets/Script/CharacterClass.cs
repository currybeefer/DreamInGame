using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterClass
{
    public const int DETECTIVE = 0;
    public const int SUSPECT = 1;
    public const int MURDERER = 2;
    private string name_;
    private int identity_;
    private string story_;

    public CharacterClass(string name, int identity, string story)
    {
        name_ = name;
        identity_ = identity;
        story_ = story;
    }

    public string GetName()
    {
        return name_;
    }

    public int GetIdentity()
    {
        return identity_;
    }

    public string GetStory()
    {
        return story_;
    }
}
