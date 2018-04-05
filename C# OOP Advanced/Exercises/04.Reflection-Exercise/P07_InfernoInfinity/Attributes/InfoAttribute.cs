﻿using System;
using System.Collections.Generic;

namespace P07_InfernoInfinity.Attributes
{
    public class InfoAttribute : Attribute
    {
        public InfoAttribute(string author, int revision, string description, params string[] reviewers)
        {
            this.Author = author;
            this.Revision = revision;
            this.Description = description;
            this.Reviewers = new List<string>(reviewers);
        }

        public string Author { get; private set; }

        public int Revision { get; private set; }

        public string Description { get; private set; }

        public List<string> Reviewers { get; private set; }
    }
}
