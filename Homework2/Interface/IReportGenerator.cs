using System.Collections.Generic;
using Homework2.BaseEntities;

namespace Homework2.Interface
{
    public interface IReportGenerator
    {
        void Report(List<BaseUser> users);
    }
}