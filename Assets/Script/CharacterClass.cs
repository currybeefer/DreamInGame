using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterClass
{
    public enum IdentityType
    {
        Detective,
        Murder,
        Suspect
    }
    private string name_;
    private IdentityType identity_;
    private string story_;

    public CharacterClass(string name, IdentityType identity, string story)
    {
        name_ = name;
        identity_ = identity;
        story_ = story;
    }

    public string GetName()
    {
        return name_;
    }

    public IdentityType GetIdentity()
    {
        return identity_;
    }

    public string GetStory()
    {
        return story_;
    }

    public void SetName(string name)
    {
        name_ = name;
    }

    public void SetStory(string story)
    {
        story_ = story;
    }

    public void SetIdentity(IdentityType identity)
    {
        identity_ = identity;
    }
}
