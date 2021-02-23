using System;

namespace Homework2.BaseEntities
{
    public abstract class BaseUser
    {
        public Guid UserId { get; set; }
        public string FullName { get; set; }
    }
}