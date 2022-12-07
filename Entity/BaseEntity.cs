using Entity.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public int State { get; set; }

        public BaseEntity()
        {
            State = (int)EntitiesState.ACTIVE;
        }

        public void ChangeState(int state)
        {
            State = state;
        }
    }
}
