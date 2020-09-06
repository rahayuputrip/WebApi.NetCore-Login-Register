﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebCore.Context;
using WebCore.Model;

namespace WebCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly MyContext myContext;

        public RoleController(MyContext context)
        {
            myContext = context;
        }

        [HttpGet]
        public List<Role> GetAll()
        {
            List<Role> list = new List<Role>();
            foreach (var role in myContext.Roles)
            {
                list.Add(role);
            }
            return list;
        }

        [HttpPost]
        public IActionResult Create(Role role)
        {
            var roles = new Role();
            roles.Name = role.Name;
            myContext.Roles.AddAsync(role);
            myContext.SaveChanges();
            return Ok("Role Successfully Created");

        }

    }
}