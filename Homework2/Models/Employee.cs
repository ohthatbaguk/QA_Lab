using Homework2.BaseEntities;
using Homework2.Interface;

namespace Homework2.Models
{
    public class Employee : BaseUser,IDescriptionable
    {
        public Employee()
        {
        }

        public void Description()
        {
            throw new System.NotImplementedException();
        }
    }
}