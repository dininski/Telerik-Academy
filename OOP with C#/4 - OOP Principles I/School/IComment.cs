using System;
using System.Collections.Generic;

namespace SchoolLibrary
{
    public interface IComment
    {
        string[] Comment { get; }
        void AddComment(string newComment);
    }
}
