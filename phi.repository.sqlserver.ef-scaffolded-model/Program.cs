using System;
using System.Linq;
using Phi.Repository.SqlServer.Data;
using Phi.Repository.SqlServer.Models;

namespace Phi.Repository.SqlServer;

internal class Program
{
    private static void Main()
    {
        using var db = new PhiContext();

        // Note: This sample requires the database to be created before running.

        // Read
        Console.WriteLine("Querying for a language");
        var lang = db.Languages
            .OrderBy(l => l.Id)
            .First();

        // Create
        Console.WriteLine("Inserting a new blog");
        db.Add(
            new Blog
            {
                Theme = "Some Topic",
                Header = "Some Clickbait Title",
                Article = "Some Text",
		Language = lang
            });
        db.SaveChanges();

        // Read
        Console.WriteLine("Querying for a blog");
        var blog = db.Blogs
            .OrderBy(b => b.Id)
            .First();

        // Create
        Console.WriteLine("Inserting a new user");
        db.Add(
            new PhiUser
            {
                Id = System.Guid.NewGuid().ToString(),
                UserName = "A user"
            });
        db.SaveChanges();

        // Read
        Console.WriteLine("Querying for a user");
        var user = db.PhiUsers
            .OrderBy(p => p.Id)
            .First();

        // Update
        Console.WriteLine("Updating the blog and adding a post");
        blog.Theme = "Updated Topic";
        blog.BlogComments.Add(
            new BlogComment
            {
                BlogId = 1, 
                PhiUser = user,
                Text = "Some Text"
            });
        db.SaveChanges();

        // Delete
        Console.WriteLine("Delete the blog");
        //db.Remove(blog);
        //db.SaveChanges();

        Console.WriteLine("Finished");
    }
}