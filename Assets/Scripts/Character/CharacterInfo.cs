using UnityEngine;
using System;

[Serializable]
public class CharacterInfo
{
    public enum IdentityType
    {
        Detective,
        Murderer,
        Suspect
    }
    private string name_;
    private IdentityType identity_;
    private string story_;

    public CharacterInfo()
    {
        Debug.Log("Character created");
        name_ = "";
        story_ = "";
        identity_ = IdentityType.Suspect;
    }

    public CharacterInfo(string name, IdentityType identity, string story)
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
        Debug.Log("character " + name_ + " \'s name updated");
    }

    public void SetStory(string story)
    {
        Debug.Log("character " + name_ + " \'s story updated");
        story_ = story;
    }

    public void SetIdentity(IdentityType identity)
    {
        Debug.Log("character " + name_ + " \'s identity updated");
        identity_ = identity;
    }
}
