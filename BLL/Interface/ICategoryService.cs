﻿using BLL.Interface.Actions;
using BLL.Response;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interface
{
    public interface ICategoryService : ICreate<Category>, IGet<Category>
    {

    }
}
