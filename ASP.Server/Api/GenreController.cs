﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ASP.Server.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASP.Server.Database;

namespace ASP.Server.Api
{
    [Route("/api/[controller]/[action]")]
    [ApiController]
    public class GenreController : ControllerBase
    {
        private readonly LibraryDbContext libraryDbContext;

        public GenreController(LibraryDbContext libraryDbContext)
        {
            this.libraryDbContext = libraryDbContext;
        }


        //Get all genres 
        public ActionResult<List<Genre>> GetGenres()
        {
            return libraryDbContext.Genre.ToList();
        }
    }
}
