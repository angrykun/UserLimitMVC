﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserLimitMVC.Model;
using UserLimitMVC.Model.User;
using UserLimitMVC.IDAL;

namespace UserLimitMVC.DAL
{
    /// <summary>
    /// Role仓储类
    /// </summary>
    public class RoleRepository : BaseRepository<Role>, IRoleRepository
    {
    }
}