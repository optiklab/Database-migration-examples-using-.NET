using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Phi.Repository.Sqlite.Models;

public class Blog
{
    public int BlogId { get; set; }
    public string Url { get; set; }

    public List<Post> Posts { get; } = new();
}